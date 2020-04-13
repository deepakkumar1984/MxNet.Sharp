using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class NormalizedBoxCenterDecoder : HybridBlock
    {
        public float? _clip;

        public string _format;

        private float[] _stds;

        private BBoxCornerToCenter corner_to_center;

        public NormalizedBoxCenterDecoder(float[] stds, bool convert_anchor = false, float? clip = null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            if (stds == null)
                stds = new float[] { 0.1f, 0.1f, 0.2f, 0.2f };
            Debug.Assert(stds.Length == 4, "Box Encoder requires 4 std values.");
            this._stds = stds;
            this._clip = clip;
            if (convert_anchor)
            {
                this.corner_to_center = new BBoxCornerToCenter(split: true);
            }
            else
            {
                this.corner_to_center = null;
            }
            this._format = convert_anchor ? "corner" : "center";
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0]);

            return F(x.SymX, args[0]);
        }

        private NDArrayOrSymbol F(NDArray x, NDArray anchors)
        {
            NDArrayList a = null;
            if (this.corner_to_center != null)
            {
                a = this.corner_to_center.Call(anchors).NdXList;
            }
            else
            {
                a = anchors.Split(axis: -1, num_outputs: 4);
            }

            var p = nd.Split(x, axis: -1, num_outputs: 4);
            var ox = nd.BroadcastAdd(nd.BroadcastMul(p[0] * this._stds[0], a[2]), a[0]);
            var oy = nd.BroadcastAdd(nd.BroadcastMul(p[1] * this._stds[1], a[3]), a[1]);
            var dw = p[2] * this._stds[2];
            var dh = p[3] * this._stds[3];
            if (this._clip.HasValue)
            {
                dw = nd.MinimumScalar(dw, this._clip.Value);
                dh = nd.MinimumScalar(dh, this._clip.Value);
            }

            dw = nd.Exp(dw);
            dh = nd.Exp(dh);

            var ow = nd.BroadcastMul(dw, a[2]) * 0.5f;
            var oh = nd.BroadcastMul(dh, a[3]) * 0.5f;
            return nd.Concat(new NDArrayList(ox - ow, oy - oh, ox + ow, oy + oh), dim: -1);
        }

        private NDArrayOrSymbol F(Symbol x, Symbol anchors)
        {
            SymbolList a = null;
            if (this.corner_to_center != null)
            {
                a = this.corner_to_center.Call(anchors).SymXList;
            }
            else
            {
                a = sym.Split(anchors, axis: -1, num_outputs: 4);
            }

            var p = sym.Split(x, axis: -1, num_outputs: 4);
            var ox = sym.BroadcastAdd(sym.BroadcastMul(p[0] * this._stds[0], a[2]), a[0]);
            var oy = sym.BroadcastAdd(sym.BroadcastMul(p[1] * this._stds[1], a[3]), a[1]);
            var dw = p[2] * this._stds[2];
            var dh = p[3] * this._stds[3];
            if (this._clip.HasValue)
            {
                dw = sym.MinimumScalar(dw, this._clip.Value);
                dh = sym.MinimumScalar(dh, this._clip.Value);
            }

            dw = sym.Exp(dw);
            dh = sym.Exp(dh);

            var ow = sym.BroadcastMul(dw, a[2]) * 0.5f;
            var oh = sym.BroadcastMul(dh, a[3]) * 0.5f;
            return sym.Concat(new SymbolList(ox - ow, oy - oh, ox + ow, oy + oh), dim: -1);
        }
    }
}
