using MxNet.Gluon.RNN;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class ConvGRUCell : BaseConvRNNCell
    {
        public ConvGRUCell(Shape input_shape, int num_hidden, (int, int)? h2h_kernel = null, (int, int)? h2h_dilate = null,
           (int, int)? i2h_kernel = null, (int, int)? i2h_stride = null, (int, int)? i2h_pad = null,
           (int, int)? i2h_dilate = null, Initializer i2h_weight_initializer = null, Initializer h2h_weight_initializer = null,
           Initializer i2h_bias_initializer = null, Initializer h2h_bias_initializer = null, RNNActivation activation = null,
           string prefix = "ConvGRU_", RNNParams @params = null, string conv_layout = "NCHW")
           : base(input_shape, num_hidden, h2h_kernel.HasValue ? h2h_kernel.Value : (3, 3),
                 h2h_dilate.HasValue ? h2h_dilate.Value : (1, 1), i2h_kernel.HasValue ? i2h_kernel.Value : (3, 3),
                 i2h_stride.HasValue ? i2h_stride.Value : (1, 1), i2h_pad.HasValue ? i2h_pad.Value : (1, 1),
                 i2h_dilate.HasValue ? i2h_dilate.Value : (1, 1), i2h_weight_initializer, h2h_weight_initializer,
                 i2h_bias_initializer, h2h_bias_initializer, activation != null ? activation : new RNNActivation("leaky"), prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override string[] GateNames => throw new NotImplementedException();

        public override void Call(Symbol inputs, SymbolList states)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();
    }
}
