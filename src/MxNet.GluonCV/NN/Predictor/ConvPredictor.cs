using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class ConvPredictor : HybridBlock
    {
        public ConvPredictor(int num_channel, (int, int)? kernel= null, (int, int)? pad= null, (int, int)? stride= null,
                 string activation= null, bool use_bias= true, int in_channels= 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
