using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class Conv1D : _Conv
    {
        public Conv1D(int channels, int kernel_size, int strides = 1, int padding = 0,
                    int dilation = 1, int groups = 1, string layout = "NCW", int in_channels = 0,
                    ActivationActType? activation = null, bool use_bias = true, Initializer weight_initializer = null,
                    string bias_initializer = "zeros", string prefix = null, ParameterDict @params = null)
                    : base(channels, new int[] { kernel_size }, new int[] { strides }, new int[] { padding },
                          new int[] { dilation }, groups, layout, in_channels, activation, use_bias,
                          weight_initializer, bias_initializer, null, "Convolution", prefix, @params)
        {
        }
    }
}
