using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Utils
{
    public class DefaultPreprocess : HybridBlock
    {
        public DefaultPreprocess(string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            var mean = nd.Array(new float[] {
                        123.675f,
                        116.28f,
                        103.53f
                    }).Reshape(1, 1, 1, 3);
            var scale = nd.Array(new float[] {
                        58.395f,
                        57.12f,
                        57.375f
                    }).Reshape(1, 1, 1, 3);
            this["init_mean"] = Params.GetConstant("init_mean", mean);
            this["init_scale"] = Params.GetConstant("init_scale", scale);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol init_mean = args[0];
            NDArrayOrSymbol init_scale = args[1];

            if (x.IsNDArray)
                return F(x.NdX, init_mean, init_scale);

            return F(x.SymX, init_mean, init_scale);
        }

        private NDArrayOrSymbol F(NDArray x, NDArray init_mean, NDArray init_scale)
        {
            x = nd.BroadcastSub(x, init_mean);
            x = nd.BroadcastDiv(x, init_scale);
            x = nd.Transpose(x, axes: new Shape(0, 3, 1, 2));
            return x;
        }

        private NDArrayOrSymbol F(Symbol x, Symbol init_mean, Symbol init_scale)
        {
            x = sym.BroadcastSub(x, init_mean);
            x = sym.BroadcastDiv(x, init_scale);
            x = sym.Transpose(x, axes: new Shape(0, 3, 1, 2));
            return x;
        }
    }
}
