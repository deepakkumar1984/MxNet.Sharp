using uint32_t = System.UInt32;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{

    public partial class NeuralNet
    {

        #region Methods

        public Symbol Reshape(Symbol data,
                                     Shape shape,
                                     bool reverse = false,
                                     string name = "")
        {
            return new Operator("reshape").SetParam("shape", shape)
                                          .SetParam("reverse", reverse)
                                          .SetInput("data", data)
                                          .CreateSymbol(name);
        }

        #endregion

    }

}
