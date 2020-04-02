using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class NaiveSampler : HybridBlock
    {
        public NaiveSampler(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        private NDArrayOrSymbol F(NDArray x)
        {
            var marker = nd.OnesLike(x);
            var y = nd.Where(x >= 0, marker, marker * -1);
            return y;
        }

        private NDArrayOrSymbol F(Symbol x)
        {
            var marker = sym.OnesLike(x);
            var y = sym.Where(x >= 0, marker, marker * -1);
            return y;
        }
    }
}
