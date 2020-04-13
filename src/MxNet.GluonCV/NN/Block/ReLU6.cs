using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class ReLU6 : HybridBlock
    {
        public ReLU6(string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if(x.IsNDArray)
                return nd.Clip(x, 0, 6);

            return sym.Clip(x, 0, 6, symbol_name: "relu6");
        }
    }
}
