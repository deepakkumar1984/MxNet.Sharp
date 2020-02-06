using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class Embedding : HybridBlock
    {
        public int Input_Dim { get; }
        public int Output_Dim { get; }
        public DType Dtype { get; }
        public bool Sparse_Grad { get; }
        public Parameter Weight { get; }
        public Embedding(int input_dim, int output_dim, DType dtype = null,
                        string weight_initializer= null, bool sparse_grad= false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Input_Dim = input_dim;
            Output_Dim = output_dim;
            Dtype = dtype;
            Sparse_Grad = sparse_grad;
            Weight = Params.Get(name: "weight", OpGradReq.Write, new Shape(input_dim, output_dim), dtype, init: Initializer.Get(weight_initializer), allow_deferred_init: true, grad_stype: Sparse_Grad ? StorageStype.RowSparse : StorageStype.Default);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol weight = args[0];

            if (x.IsNDArray)
                return nd.Embedding(x.NdX, weight.NdX, Input_Dim, Output_Dim, Dtype, Sparse_Grad);

            return sym.Embedding(x.SymX, weight.SymX, Input_Dim, Output_Dim, Dtype, Sparse_Grad);
        }
    }
}
