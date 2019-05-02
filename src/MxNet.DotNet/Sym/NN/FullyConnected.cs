using mx_float = System.Single;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{

    public partial class NeuralNet
    {

        #region Methods

        public Symbol FullyConnected(Symbol data,
                                            Symbol weight,
                                            Symbol bias,
                                            int numHidden,
                                            bool no_bias = false,
                                            bool flatten = true,
                                            string name = "")
        {
            return new Operator("FullyConnected").SetParam("num_hidden", numHidden)
                                                 .SetParam("no_bias", no_bias)
                                                 .SetParam("flatten", flatten)
                                                 .SetInput("data", data)
                                                 .SetInput("weight", weight)
                                                 .SetInput("bias", bias)
                                                 .CreateSymbol(name);
        }

        #endregion

    }

}
