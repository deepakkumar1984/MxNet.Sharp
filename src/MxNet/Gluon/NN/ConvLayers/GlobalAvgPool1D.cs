using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class GlobalAvgPool1D : _Pooling
    {
        public GlobalAvgPool1D(string layout = "NCW", string prefix = null, ParameterDict @params = null)
                        : base(new int[] { 1 }, null, new int[] { 0 }, true, true, PoolingPoolType.Avg, layout, null, prefix, @params)
        {
        }
    }
}
