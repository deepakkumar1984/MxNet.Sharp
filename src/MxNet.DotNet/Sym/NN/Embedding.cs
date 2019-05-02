using mx_float = System.Single;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{
    public enum EmbeddingDtype
    {
        Float16 = 0,
        Float32 = 1,
        Float64 = 2,
        Int32 = 3,
        Uint8 = 4
    }

    public partial class NeuralNet
    {

        #region Fields

        private readonly string[] EmbeddingDtypeValues =
        {
            "float16",
            "float32",
            "float64",
            "int32",
            "uint8"
        };

        #endregion

        #region Methods

        public Symbol Embedding(Symbol data,
                                       Symbol weight,
                                       int inputDim,
                                       int outputDim,
                                       EmbeddingDtype dtype = EmbeddingDtype.Float32,
                                       string name = "")
        {
            return new Operator("Embedding").SetParam("input_dim", inputDim)
                                            .SetParam("output_dim", outputDim)
                                            .SetParam("dtype", EmbeddingDtypeValues[(int)dtype])
                                            .SetInput("data", data)
                                            .SetInput("weight", weight)
                                            .CreateSymbol(name);
        }

        #endregion

    }

}
