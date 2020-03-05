using System;

namespace MxNet.Gluon.NN
{
    public class AvgPool1D : _Pooling
    {
        public AvgPool1D(int pool_size = 2, int? strides = null, int padding = 0, string layout = "NCW",
            bool ceil_mode = false, string prefix = null, ParameterDict @params = null)
            : base(new[] {pool_size}
                , strides.HasValue ? new[] {strides.Value} : new[] {pool_size}
                , new[] {padding}, ceil_mode, false, PoolingPoolType.Avg, layout, null, prefix, @params)
        {
            if (layout != "NCW" && layout != "NWC")
                throw new Exception("Only NCW and NWC layouts are valid for 1D Pooling");
        }
    }
}