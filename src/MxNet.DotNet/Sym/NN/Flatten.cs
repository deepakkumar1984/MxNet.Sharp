// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{

    public partial class NeuralNet
    {

        #region Methods

        public Symbol Flatten(Symbol data, string name = "")
        {
            return new Operator("Flatten").SetInput("data", data).CreateSymbol(name);
        }

        #endregion

    }

}
