using MxNet.Gluon.RNN;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RecurrentNN
{
    public class LSTM : RNNLayer
    {
        public LSTM(int hidden_size, int num_layers= 1, string layout= "TNC",
                 float dropout= 0, bool bidirectional= false, int input_size= 0,
                 Initializer i2h_weight_initializer= null, Initializer h2h_weight_initializer= null,
                 Initializer i2h_bias_initializer= null, Initializer h2h_bias_initializer= null,
                 int? projection_size= null, Initializer h2r_weight_initializer= null,
                 float? state_clip_min= null, float?  state_clip_max = null, bool state_clip_nan = false,
                 DType dtype= null, string prefix = null, ParameterDict @params = null) : 
                base(hidden_size, num_layers, layout, dropout, bidirectional, input_size, i2h_weight_initializer, 
                    h2h_weight_initializer, i2h_bias_initializer, h2h_bias_initializer, "lstm", projection_size, 
                    h2r_weight_initializer, state_clip_min, state_clip_max, state_clip_nan, dtype, false, prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }
    }
}
