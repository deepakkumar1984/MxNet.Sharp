using mx_float = System.Single;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{

    public partial class NeuralNet
    {

        #region Fields

        private string[] ActivationActTypeValues =
        {
            "relu",
            "sigmoid",
            "softrelu",
            "tanh"
        };

        #endregion

        #region Methods

        public Symbol Activation(Symbol data, ActivationActType actType, string name = "")
        {
            return new Operator("Activation").SetParam("act_type", ActivationActTypeValues[(int)actType])
                                             .SetInput("data", data)
                                             .CreateSymbol(name);
        }

        #endregion

    }

}
