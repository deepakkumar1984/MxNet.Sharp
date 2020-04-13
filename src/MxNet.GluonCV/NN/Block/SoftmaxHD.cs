using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class SoftmaxHD : HybridBlock
    {
        public SoftmaxHD(Shape axis = null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            Axis = axis;
        }

        public Shape Axis { get; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX);

            return F(x.SymX);
        }

        public NDArrayOrSymbol F(NDArray x)
        {
            var x_max = nd.Max(x, axis: this.Axis, keepdims: true);
            var x_exp = nd.Exp(nd.BroadcastSub(x, x_max));
            var norm = nd.Sum(x_exp, axis: this.Axis, keepdims: true);
            var res = nd.BroadcastDiv(x_exp, norm);
            return res;
        }

        public NDArrayOrSymbol F(Symbol x)
        {
            var x_max = sym.Max(x, axis: this.Axis, keepdims: true);
            var x_exp = sym.Exp(sym.BroadcastSub(x, x_max));
            var norm = sym.Sum(x_exp, axis: this.Axis, keepdims: true);
            var res = sym.BroadcastDiv(x_exp, norm);
            return res;
        }
    }
}
