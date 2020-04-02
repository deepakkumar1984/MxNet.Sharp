using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class MaximumMatcher : HybridBlock
    {
        private readonly float _threshold;

        public MaximumMatcher(float threshold, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            this._threshold = threshold;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        private NDArrayOrSymbol F(NDArray x)
        {
            var argmax = nd.Argmax(x, axis: -1);
            var match = nd.Where(nd.Pick(x, argmax, axis: -1) >= this._threshold, argmax, nd.OnesLike(argmax) * -1);
            return match;
        }

        private NDArrayOrSymbol F(Symbol x)
        {
            var argmax = sym.Argmax(x, axis: -1);
            var match = sym.Where(sym.Pick(x, argmax, axis: -1) >= this._threshold, argmax, sym.OnesLike(argmax) * -1);
            return match;
        }
    }
}
