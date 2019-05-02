using mx_float = System.Single;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{
    public enum PoolingPoolingConvention
    {
        Full = 0,
        Same = 1,
        Valid = 2
    }

    public enum PoolingPoolType
    {
        Avg = 0,
        Lp = 1,
        Max = 2,
        Sum = 3
    }

    public partial class NeuralNet
    {

        #region Fields

        private readonly string[] PoolingPoolTypeValues =
        {
            "avg",
            "lp",
            "max",
            "sum"
        };

        private readonly string[] PoolingPoolingConventionValues =
        {
            "full",
            "same",
            "valid"
        };

        #endregion

        #region Methods

        public Symbol Pooling(Symbol data,
                                     Shape kernel,
                                     PoolingPoolType poolType = PoolingPoolType.Max,
                                     bool globalPool = false,
                                     bool cudnnOff = false,
                                     PoolingPoolingConvention poolingConvention = PoolingPoolingConvention.Valid,
                                     Shape stride = null,
                                     Shape pad = null,
                                     int p_value = 0,
                                     bool count_include_pad = true,
                                     ConvolutionLayout layout = ConvolutionLayout.None,
                                     string name = "")
        {
            return new Operator("Pooling").SetParam("kernel", kernel)
                                          .SetParam("pool_type", PoolingPoolTypeValues[(int)poolType])
                                          .SetParam("global_pool", globalPool)
                                          .SetParam("cudnn_off", cudnnOff)
                                          .SetParam("stride", stride)
                                          .SetParam("pad", pad)
                                          .SetParam("p_value", p_value)
                                          .SetParam("count_include_pad", count_include_pad)
                                          .SetParam("layout", ConvolutionLayoutValues[(int)layout])
                                          .SetInput("data", data)
                                          .CreateSymbol(name);
        }

        #endregion

    }

}
