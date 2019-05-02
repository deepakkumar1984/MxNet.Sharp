using mx_float = System.Single;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{
    public enum DropoutMode
    {
        Always = 0,
        Training = 1
    }

    public partial class NeuralNet
    {

        #region Fields

        private readonly string[] DropoutModeValues =
        {
            "always",
            "training"
        };

        #endregion

        #region Methods

        public Symbol Dropout(Symbol data,
                                     mx_float p = 0.5f,
                                     DropoutMode mode = DropoutMode.Training, string name = "")
        {
            return new Operator("Dropout").SetParam("p", p)
                                          .SetParam("mode", DropoutModeValues[(int)mode])
                                          .SetInput("data", data)
                                          .CreateSymbol(name);
        }

        #endregion

    }

}
