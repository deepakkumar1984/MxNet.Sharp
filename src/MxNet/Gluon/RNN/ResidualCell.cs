using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class ResidualCell : ModifierCell
    {
        public ResidualCell(RecurrentCell base_cell) : base(base_cell)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override (Symbol[], Symbol[]) Unroll(int length, Symbol[] inputs, List<Symbol[]> begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            throw new NotImplementedException();
        }
    }
}
