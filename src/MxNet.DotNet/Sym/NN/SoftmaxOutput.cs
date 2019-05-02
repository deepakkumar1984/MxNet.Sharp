using mx_float = System.Single;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{
    public enum SoftmaxActivationMode
    {
        Channel = 0,
        Instance = 1
    }

    public enum SoftmaxOutputNormalization
    {
        Batch = 0,
        Null = 1,
        Valid = 2
    }

    public partial class NeuralNet
    {

        #region Fields

        private string[] SoftmaxOutputNormalizationValues =
        {
            "batch",
            "null",
            "valid"
        };

        #endregion

        #region Methods

        public Symbol SoftmaxOutput(Symbol data,
                                           Symbol label,
                                           mx_float gradScale = 1,
                                           mx_float ignoreLabel = -1,
                                           bool multiOutput = false,
                                           bool useIgnore = false,
                                           bool preserveShape = false,
                                           SoftmaxOutputNormalization normalization = SoftmaxOutputNormalization.Null,
                                           bool outGrad = false,
                                           mx_float smoothAlpha = 0,
                                           string name = "")
        {
            return new Operator("SoftmaxOutput").SetParam("grad_scale", gradScale)
                                                .SetParam("ignore_label", ignoreLabel)
                                                .SetParam("multi_output", multiOutput)
                                                .SetParam("use_ignore", useIgnore)
                                                .SetParam("preserve_shape", preserveShape)
                                                .SetParam("normalization", SoftmaxOutputNormalizationValues[(int)normalization])
                                                .SetParam("out_grad", outGrad)
                                                .SetParam("smooth_alpha", smoothAlpha)
                                                .SetInput("data", data)
                                                .SetInput("label", label)
                                                .CreateSymbol(name);
        }

        #endregion

    }

}
