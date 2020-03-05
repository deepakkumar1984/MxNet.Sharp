namespace MxNet.Gluon.NN
{
    public class Conv3D : _Conv
    {
        public Conv3D(int channels, (int, int, int) kernel_size, (int, int, int) strides = default,
            (int, int, int) padding = default,
            (int, int, int) dilation = default, int groups = 1, string layout = "NCDHW", int in_channels = 0,
            ActivationActType? activation = null, bool use_bias = true, string weight_initializer = null,
            string bias_initializer = "zeros", string prefix = null, ParameterDict @params = null)
            : base(channels, new[] {kernel_size.Item1, kernel_size.Item2, kernel_size.Item3},
                strides == default ? new[] {1, 1, 1} : new[] {strides.Item1, strides.Item2, strides.Item3},
                padding == default ? new[] {0, 0, 0} : new[] {padding.Item1, padding.Item2, padding.Item3},
                dilation == default ? new[] {1, 1, 1} : new[] {dilation.Item1, dilation.Item2, dilation.Item3},
                groups, layout, in_channels, activation, use_bias,
                weight_initializer, bias_initializer, null, "Convolution", prefix, @params)
        {
        }
    }
}