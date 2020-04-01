using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class BBoxBatchIOU : HybridBlock
    {
        private float _eps;

        private int _offset;

        private HybridBlock _pre;

        public BBoxBatchIOU(int axis = -1, string fmt = "corner", int offset = 0, float eps = 1e-15f, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            this._offset = offset;
            this._eps = eps;
            if (fmt.ToLower() == "center")
            {
                this._pre = new BBoxCenterToCorner(split: true);
            }
            else if (fmt.ToLower() == "corner")
            {
                this._pre = new BBoxSplit(axis: axis, squeeze_axis: true);
            }
            else
            {
                throw new Exception($"Unsupported format: {fmt}. Use 'corner' or 'center'.");
            }
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0]);

            return F(x.SymX, args[0]);
        }

        private NDArrayOrSymbol F(NDArray a, NDArray b)
        {
            var _tup_1 = this._pre.Call(a);
            NDArray al = _tup_1[0];
            NDArray at = _tup_1[1];
            NDArray ar = _tup_1[2];
            NDArray ab = _tup_1[3];
            var _tup_2 = this._pre.Call(b);
            NDArray bl = _tup_2[0];
            NDArray bt = _tup_2[1];
            NDArray br = _tup_2[2];
            NDArray bb = _tup_2[3];
            // (B, N, M)
            var left = nd.BroadcastMaximum(al.ExpandDims(-1), bl.ExpandDims(-2));
            var right = nd.BroadcastMinimum(ar.ExpandDims(-1), br.ExpandDims(-2));
            var top = nd.BroadcastMaximum(at.ExpandDims(-1), bt.ExpandDims(-2));
            var bot = nd.BroadcastMinimum(ab.ExpandDims(-1), bb.ExpandDims(-2));
            // clip with (0, float16.max)
            var iw = nd.Clip(right - left + this._offset, a_min: 0, a_max: 65504);
            var ih = nd.Clip(bot - top + this._offset, a_min: 0, a_max: 65504);
            var i = iw * ih;
            // areas
            var area_a = ((ar - al + this._offset) * (ab - at + this._offset)).ExpandDims(-1);
            var area_b = ((br - bl + this._offset) * (bb - bt + this._offset)).ExpandDims(-2);
            var union = nd.BroadcastAdd(area_a, area_b) - i;
            return i / (union + this._eps);
        }

        private NDArrayOrSymbol F(Symbol a, Symbol b)
        {
            var _tup_1 = this._pre.Call(a);
            Symbol al = _tup_1[0];
            Symbol at = _tup_1[1];
            Symbol ar = _tup_1[2];
            Symbol ab = _tup_1[3];
            var _tup_2 = this._pre.Call(b);
            Symbol bl = _tup_2[0];
            Symbol bt = _tup_2[1];
            Symbol br = _tup_2[2];
            Symbol bb = _tup_2[3];
            // (B, N, M)
            var left = sym.BroadcastMaximum(al.ExpandDims(-1), bl.ExpandDims(-2));
            var right = sym.BroadcastMinimum(ar.ExpandDims(-1), br.ExpandDims(-2));
            var top = sym.BroadcastMaximum(at.ExpandDims(-1), bt.ExpandDims(-2));
            var bot = sym.BroadcastMinimum(ab.ExpandDims(-1), bb.ExpandDims(-2));
            // clip with (0, float16.max)
            var iw = sym.Clip(right - left + this._offset, a_min: 0, a_max: 65504);
            var ih = sym.Clip(bot - top + this._offset, a_min: 0, a_max: 65504);
            var i = iw * ih;
            // areas
            var area_a = ((ar - al + this._offset) * (ab - at + this._offset)).ExpandDims(-1);
            var area_b = ((br - bl + this._offset) * (bb - bt + this._offset)).ExpandDims(-2);
            var union = sym.BroadcastAdd(area_a, area_b) - i;
            return i / (union + this._eps);
        }
    }
}
