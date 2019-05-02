using mx_float = System.Single;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{
    public enum LeakyReLUActType
    {
        Elu = 0,
        Leaky = 1,
        Prelu = 2,
        Rrelu = 3
    }

    public partial class NeuralNet
    {

        #region Fields

        private readonly string[] LeakyReLUActTypeValues =
        {
            "elu",
            "leaky",
            "prelu",
            "rrelu"
        };

        #endregion

        #region Methods

        
        public Symbol LeakyReLU(Symbol data,
                                       LeakyReLUActType actType = LeakyReLUActType.Leaky,
                                       mx_float slope = 0.25f,
                                       mx_float lowerBound = 0.125f,
                                       mx_float upperBound = 0.334f,
                                       string name = "")
        {
            return new Operator("LeakyReLU").SetParam("act_type", LeakyReLUActTypeValues[(int)actType])
                                            .SetParam("slope", slope)
                                            .SetParam("lower_bound", lowerBound)
                                            .SetParam("upper_bound", upperBound)
                                            .SetInput("data", data)
                                            .CreateSymbol(name);
        }

        #endregion

    }

}
