using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class AvgPool2D : _Pooling
    {
        public AvgPool2D((int, int)? pool_size = null, (int, int)? strides = null, (int, int)? padding = null, string layout = "NCHW",
                            bool ceil_mode = false, string prefix = null, ParameterDict @params = null)
                        : base(pool_size.HasValue  ? new int[] { 2, 2 } : new int[] { pool_size.Value.Item1, pool_size.Value.Item2 }
                        , strides.HasValue ? new int[] { strides.Value.Item1, strides.Value.Item2 } : new int[] { pool_size.Value.Item1, pool_size.Value.Item2 }
                        , padding.HasValue ? new int[] { 0, 0 } : new int[] { padding.Value.Item1, padding.Value.Item2 }
                        , ceil_mode, false, "avg", layout, null, prefix, @params)
        {
            throw new NotImplementedException();
        }
    }
}
