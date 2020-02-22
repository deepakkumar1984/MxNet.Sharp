using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class GlobalMaxPool1D : _Pooling
    {
        public GlobalMaxPool1D(string layout = "NCW", string prefix = null, ParameterDict @params = null)
                        : base(new int[] { 1 }, null, new int[] { 0 }, true, true, PoolingPoolType.Max, layout, null, prefix, @params)
        {
            if (layout != "NCW" && layout != "NWC")
                throw new Exception("Only NCW and NWC layouts are valid for 1D Pooling");
        }
    }
}
