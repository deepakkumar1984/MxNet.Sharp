using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class SymbolBlock : HybridBlock
    {
        public SymbolBlock(Symbol[] outputs, Symbol[] inputs, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override NDArray Forward(NDArray input, NDArray[] args)
        {
            throw new NotImplementedException();
        }

        public static SymbolBlock Imports(string symbol_file, string[] input_names, string param_file= null, Context ctx= null)=> throw new NotImplementedException();

        private void ClearCachedOp() => throw new NotImplementedException();

        public override void Cast(DType dtype)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
