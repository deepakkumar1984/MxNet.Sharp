using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class Conv2D : _Conv
    {
        public Conv2D(int channels, (int, int) kernel_size, (int, int)? strides = null, (int, int)? padding = null, 
                    (int, int) dilation = default, int groups = 1, string layout=  "NCHW", int in_channels = 0,
                    string activation = null, bool use_bias = true, string weight_initializer = null,
                    string bias_initializer = "zeros", string prefix = null, ParameterDict @params = null) 
                    : base(channels, new int[] { kernel_size.Item1, kernel_size.Item2 }, 
                          !strides.HasValue ? new int[] { 1, 1} : new int[] {strides.Value.Item1, strides.Value.Item2 } ,
                          !padding.HasValue ? new int[] { 0, 0 } : new int[] { padding.Value.Item1, padding.Value.Item2 },
                          dilation == default ? new int[] { 1, 1 } : new int[] { dilation.Item1, dilation.Item2 },
                          groups, layout, in_channels, activation, use_bias, 
                          weight_initializer, bias_initializer, null, "Convolution", prefix, @params)
        {
        }
    }
}
