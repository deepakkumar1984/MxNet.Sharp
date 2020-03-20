using MxNet.Gluon.RNN;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class BaseConvRNNCell : BaseRNNCell
    {
        public BaseConvRNNCell(Shape input_shape, int num_hidden, (int, int) h2h_kernel, (int, int) h2h_dilate,
                                (int, int) i2h_kernel, (int, int) i2h_stride, (int, int) i2h_pad, (int, int) i2h_dilate,
                                Initializer i2h_weight_initializer, Initializer h2h_weight_initializer, Initializer i2h_bias_initializer,
                                Initializer h2h_bias_initializer, RNNActivation activation, string prefix = "", RNNParams @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public int NumGates
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void Call(Symbol inputs, Symbol[] states)
        {
            throw new NotImplementedException();
        }

        private (Symbol, Symbol) ConvForward(Symbol inputs, Symbol[] states, string name)
        {
            throw new NotImplementedException();
        }
    }
}
