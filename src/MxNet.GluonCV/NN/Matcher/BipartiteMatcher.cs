using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN.Matcher
{
    public class BipartiteMatcher : HybridBlock
    {
        public float _eps;

        public bool _is_ascend;

        public bool _share_max;

        public float _threshold;

        public BipartiteMatcher(float threshold= 1e-12f, bool is_ascend= false, float eps= 1e-12f, bool share_max= true, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            this._threshold = threshold;
            this._is_ascend = is_ascend;
            this._eps = eps;
            this._share_max = share_max;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        private NDArrayOrSymbol F(NDArray x)
        {
            var match = nd.Contrib.BipartiteMatching(x, threshold: this._threshold, is_ascend: this._is_ascend);
            // make sure if iou(a, y) == iou(b, y), then b should also be a good match
            // otherwise positive/negative samples are confusing
            // potential argmax and max
            var pargmax = x.Argmax(axis: -1, keepdims: true);
            var maxs = x.Max(axis: -2, keepdims: true);
            NDArray mask = null;
            if (this._share_max)
            {
                mask = nd.BroadcastGreaterEqual(x + this._eps, maxs);
                mask = nd.Sum(mask, axis: -1, keepdims: true);
            }
            else
            {
                var pmax = nd.Pick(x, pargmax, axis: -1, keepdims: true);
                mask = nd.BroadcastGreaterEqual(pmax + this._eps, maxs);
                mask = nd.Pick(mask, pargmax, axis: -1, keepdims: true);
            }
            var new_match = nd.Where(mask > 0, pargmax, nd.OnesLike(pargmax) * -1);
            var result = nd.Where(match < 0, new_match.Squeeze(axis: -1), match);
            return result;
        }

        private NDArrayOrSymbol F(Symbol x)
        {
            var match = sym.Contrib.BipartiteMatching(x, threshold: this._threshold, is_ascend: this._is_ascend);
            // make sure if iou(a, y) == iou(b, y), then b should also be a good match
            // otherwise positive/negative samples are confusing
            // potential argmax and max
            var pargmax = sym.Argmax(x, axis: -1, keepdims: true);
            var maxs = sym.Max(x, axis: new Shape(-2), keepdims: true);
            Symbol mask = null;
            if (this._share_max)
            {
                mask = sym.BroadcastGreaterEqual(x + this._eps, maxs);
                mask = sym.Sum(mask, axis: -1, keepdims: true);
            }
            else
            {
                var pmax = sym.Pick(x, pargmax, axis: -1, keepdims: true);
                mask = sym.BroadcastGreaterEqual(pmax + this._eps, maxs);
                mask = sym.Pick(mask, pargmax, axis: -1, keepdims: true);
            }
            var new_match = sym.Where(mask > 0, pargmax, sym.OnesLike(pargmax) * -1);
            var result = sym.Where(match < 0, new_match.Squeeze(axis: -1), match);
            return result;
        }
    }
}
