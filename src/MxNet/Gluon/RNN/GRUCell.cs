using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class GRUCell : HybridRecurrentCell
    {
        public GRUCell(int hidden_size, string i2h_weight_initializer= null, string h2h_weight_initializer= null,
                        string i2h_bias_initializer= "zeros", string h2h_bias_initializer= "zeros", int input_size= 0,
                        string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "gru";
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
