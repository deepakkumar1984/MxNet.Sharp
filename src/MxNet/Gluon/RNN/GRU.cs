using MxNet.Gluon.RNN;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RecurrentNN
{
    public class GRU : RNNLayer
    {
        public GRU(int hidden_size, int num_layers= 1, string layout= "TNC",
                 float dropout= 0, bool bidirectional= false, int input_size= 0,
                 Initializer i2h_weight_initializer= null, Initializer h2h_weight_initializer= null,
                 Initializer i2h_bias_initializer= null, Initializer h2h_bias_initializer= null,
                 DType dtype= null, string prefix = null, ParameterDict @params = null) 
            : base(hidden_size, num_layers, layout, dropout, bidirectional, input_size, i2h_weight_initializer, 
                  h2h_weight_initializer, i2h_bias_initializer, h2h_bias_initializer, "gru", null, null, null, null, null,
                  dtype, false, prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }
    }
}
