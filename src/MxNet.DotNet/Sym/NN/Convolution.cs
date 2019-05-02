using uint32_t = System.UInt32;
using uint64_t = System.UInt64;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{
    public enum ConvolutionCudnnTune
    {
        None = 0,
        Fastest = 1,
        LimitedWorkspace = 2,
        Off = 3
    }

    public enum ConvolutionLayout
    {
        None = 0,
        NCDHW = 1,
        NCHW = 2,
        NCW = 3,
        NDHWC = 4,
        NHWC = 5,
        NWC = 6
    }

    public partial class NeuralNet
    {

        #region Fields

        private readonly string[] ConvolutionCudnnTuneValues =
        {
            "None",
            "fastest",
            "limited_workspace",
            "off"
        };

        private readonly string[] ConvolutionLayoutValues =
        {
            "None",
            "NCDHW",
            "NCHW",
            "NCW",
            "NDHWC",
            "NHWC",
            "NWC"
        };

        #endregion

        #region Methods

        public Symbol Convolution(Symbol data,
                                         Symbol weight,
                                         Symbol bias,
                                         Shape kernel,
                                         uint32_t numFilter,
                                         Shape stride = null,
                                         Shape dilate = null,
                                         Shape pad = null,
                                         uint32_t numGroup = 1,
                                         uint64_t workspace = 1024,
                                         bool noBias = false,
                                         ConvolutionCudnnTune cudnnTune = ConvolutionCudnnTune.None,
                                         bool cudnnOff = false,
                                         ConvolutionLayout layout = ConvolutionLayout.None,
                                         string name = "")
        {
            if (stride == null)
                stride = new Shape();

            if (dilate == null)
                dilate = new Shape();

            if (pad == null)
                pad = new Shape();

            return new Operator("Convolution").SetParam("kernel", kernel)
                                              .SetParam("num_filter", numFilter)
                                              .SetParam("stride", stride)
                                              .SetParam("dilate", dilate)
                                              .SetParam("pad", pad)
                                              .SetParam("num_group", numGroup)
                                              .SetParam("workspace", workspace)
                                              .SetParam("no_bias", noBias)
                                              .SetParam("cudnn_tune", ConvolutionCudnnTuneValues[(int)cudnnTune])
                                              .SetParam("cudnn_off", cudnnOff)
                                              .SetParam("layout", ConvolutionLayoutValues[(int)layout])
                                              .SetInput("data", data)
                                              .SetInput("weight", weight)
                                              .SetInput("bias", bias)
                                              .CreateSymbol(name);
            
        }
        #endregion

    }

}
