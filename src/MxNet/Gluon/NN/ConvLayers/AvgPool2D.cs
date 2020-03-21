using System;

namespace MxNet.Gluon.NN
{
    public class AvgPool2D : _Pooling
    {
        public AvgPool2D((int, int)? pool_size = null, (int, int)? strides = null, (int, int)? padding = null,
            string layout = "NCHW",
            bool ceil_mode = false, string prefix = null, ParameterDict @params = null)
            : base(!pool_size.HasValue ? new[] {2, 2} : new[] {pool_size.Value.Item1, pool_size.Value.Item2}
                , strides.HasValue
                    ? new[] {strides.Value.Item1, strides.Value.Item2}
                    : new[] {pool_size.Value.Item1, pool_size.Value.Item2}
                , padding.HasValue ? new[] {padding.Value.Item1, padding.Value.Item2} : new[] { 0, 0 }
                , ceil_mode, false, PoolingType.Avg, layout, null, prefix, @params)
        {
            if (layout != "NCHW" && layout != "NHWC")
                throw new Exception("Only NCHW and NHWC layouts are valid for 2D Pooling");
        }
    }
}