using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{

    public partial class NeuralNet
    {

        #region Methods

        public Symbol Concat(IList<Symbol> data,
                                    int numArgs,
                                    int dim = 1, string name = "")
        {
            return new Operator("Concat").SetParam("num_args", numArgs)
                                         .SetParam("dim", dim)
                                         .Set(data)
                                         .CreateSymbol(name);
        }

        #endregion

    }

}
