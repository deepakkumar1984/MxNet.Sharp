using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class Conv3DTranspose : _Conv
    {
        public Conv3DTranspose(int channels, (int, int, int) kernel_size, (int, int, int) strides = default, (int, int, int) padding = default, (int, int, int) output_padding = default,
                   (int, int, int) dilation = default, int groups = 1, string layout = "NCDHW",
                   ActivationActType? activation = null, bool use_bias = true, Initializer weight_initializer = null,
                   string bias_initializer = "zeros", int in_channels = 0, string prefix = null, ParameterDict @params = null)
                   : base(channels, new int[] { kernel_size.Item1, kernel_size.Item2, kernel_size.Item3 },
                         strides == default ? new int[] { 1, 1, 1 } : new int[] { strides.Item1, strides.Item2, strides.Item3 },
                         padding == default ? new int[] { 0, 0, 0 } : new int[] { padding.Item1, padding.Item2, padding.Item3 },
                         dilation == default ? new int[] { 1, 1, 1 } : new int[] { dilation.Item1, dilation.Item2, dilation.Item3 },
                         groups, layout, in_channels, activation, use_bias,
                         weight_initializer, bias_initializer, null, "Convolution", prefix, @params)
        {
        }
    }
}
