// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{

    public partial class NeuralNet
    {

        #region Methods

        public Symbol SliceChannel(Symbol data,
                                          int numOutputs,
                                          int axis = 1,
                                          bool squeezeAxis = false,
                                          string name = "")
        {
            return new Operator("SliceChannel").SetParam("num_outputs", numOutputs)
                                               .SetParam("axis", axis)
                                               .SetParam("squeeze_axis", squeezeAxis)
                                               .SetInput("data", data)
                                               .CreateSymbol(name);
        }

        #endregion

    }

}
