using MxNet.Initializers;

namespace MxNet.Gluon.NN
{
    public class Conv2D : _Conv
    {
        public Conv2D(int channels, (int, int) kernel_size, (int, int)? strides = null, (int, int)? padding = null,
            (int, int) dilation = default, int groups = 1, string layout = "NCHW", int in_channels = 0,
            ActivationActType? activation = null, bool use_bias = true, Initializer weight_initializer = null,
            string bias_initializer = "zeros", string prefix = null, ParameterDict @params = null)
            : base(channels, new[] {kernel_size.Item1, kernel_size.Item2},
                !strides.HasValue ? new[] {1, 1} : new[] {strides.Value.Item1, strides.Value.Item2},
                !padding.HasValue ? new[] {0, 0} : new[] {padding.Value.Item1, padding.Value.Item2},
                dilation == default ? new[] {1, 1} : new[] {dilation.Item1, dilation.Item2},
                groups, layout, in_channels, activation, use_bias,
                weight_initializer, bias_initializer, null, "Convolution", prefix, @params)
        {
        }
    }
}