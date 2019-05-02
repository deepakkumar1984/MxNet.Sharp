using uint32_t = System.UInt32;
using uint64_t = System.UInt64;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{
    public enum DeconvolutionCudnnTune
    {
        None = 0,
        Fastest = 1,
        LimitedWorkspace = 2,
        Off = 3
    }

    public enum DeconvolutionLayout
    {
        None = 0,
        NCDHW = 1,
        NCHW = 2,
        NCW = 3,
        NDHWC = 4,
        NHWC = 5
    }

    public partial class NeuralNet
    {

        #region Fields

        private readonly string[] DeconvolutionCudnnTuneValues =
        {
            "None",
            "fastest",
            "limited_workspace",
            "off"
        };

        private readonly string[] DeconvolutionLayoutValues =
        {
            "None",
            "NCDHW",
            "NCHW",
            "NCW",
            "NDHWC",
            "NHWC"
        };

        #endregion

        #region Methods

        public Symbol Deconvolution(Symbol data,
                            Symbol weight,
                            Symbol bias,
                            Shape kernel,
                            uint32_t numFilter,
                            Shape stride = null,
                            Shape dilate = null,
                            Shape pad = null,
                            Shape adj = null,
                            Shape targetShape = null,
                            uint32_t numGroup = 1,
                            uint64_t workspace = 512,
                            bool noBias = true,
                            DeconvolutionCudnnTune cudnnTune = DeconvolutionCudnnTune.None,
                            bool cudnnOff = false,
                            DeconvolutionLayout layout = DeconvolutionLayout.None,
                            string name = "")
        {
            if (stride == null)
                stride = new Shape();

            if (dilate == null)
                dilate = new Shape();

            if (pad == null)
                pad = new Shape();

            if (adj == null)
                adj = new Shape();

            if (targetShape == null)
                targetShape = new Shape();

            return new Operator("Deconvolution").SetParam("kernel", kernel)
                                                .SetParam("num_filter", numFilter)
                                                .SetParam("stride", stride)
                                                .SetParam("dilate", dilate)
                                                .SetParam("pad", pad)
                                                .SetParam("adj", adj)
                                                .SetParam("target_shape", targetShape)
                                                .SetParam("num_group", numGroup)
                                                .SetParam("workspace", workspace)
                                                .SetParam("no_bias", noBias)
                                                .SetParam("cudnn_tune", DeconvolutionCudnnTuneValues[(int)cudnnTune])
                                                .SetParam("cudnn_off", cudnnOff)
                                                .SetParam("layout", DeconvolutionLayoutValues[(int)layout])
                                                .SetInput("data", data)
                                                .SetInput("weight", weight)
                                                .SetInput("bias", bias)
                                                .CreateSymbol(name);
        }

        #endregion

    }

}
