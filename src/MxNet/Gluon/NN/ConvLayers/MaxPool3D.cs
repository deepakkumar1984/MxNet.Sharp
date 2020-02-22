using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class MaxPool3D : _Pooling
    {
        public MaxPool3D((int, int, int)? pool_size = null, (int, int, int)? strides = null, (int, int, int)? padding = null, string layout = "NCDHW",
                            bool ceil_mode = false, string prefix = null, ParameterDict @params = null)
                        : base(pool_size.HasValue  ? new int[] { 2, 2, 2 } : new int[] { pool_size.Value.Item1, pool_size.Value.Item2, pool_size.Value.Item3 }
                        , strides.HasValue ? new int[] { strides.Value.Item1, strides.Value.Item2, strides.Value.Item3 } : new int[] { pool_size.Value.Item1, pool_size.Value.Item2, pool_size.Value.Item3 }
                        , padding.HasValue ? new int[] { 0, 0, 0 } : new int[] { padding.Value.Item1, padding.Value.Item2, padding.Value.Item3 }
                        , ceil_mode, false, PoolingPoolType.Max, layout, null, prefix, @params)
        {
            if (layout != "NCDHW" && layout != "NDHWC")
                throw new Exception("Only NCDHW and NDHWC layouts are valid for 3D Pooling");
        }
    }
}
