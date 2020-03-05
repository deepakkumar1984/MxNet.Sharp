using System;

namespace MxNet.Gluon.Contrib.NN
{
    public class SparseEmbedding : Block
    {
        public SparseEmbedding(int input_dim, int output_dim, DType dtype = null,
            string weight_initializer = null, string prefix = null, ParameterDict @params = null) : base(prefix,
            @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}