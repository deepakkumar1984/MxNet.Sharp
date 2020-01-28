using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class DropoutCell : HybridRecurrentCell
    {
        public DropoutCell(float rate, Shape axes = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "dropout";
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override (Symbol[], Symbol[]) Unroll(int length, Symbol[] inputs, List<Symbol[]> begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
