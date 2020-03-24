using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class ResidualCell : ModifierCell
    {
        public ResidualCell(BaseRNNCell base_cell) : base(base_cell)
        {
            throw new NotImplementedException();
        }

        public override void Call(Symbol inputs, SymbolList states)
        {
            throw new NotImplementedException();
        }

        public override (Symbol, SymbolList) Unroll(int length, SymbolList inputs, SymbolList begin_state = null, string layout = null, bool? merge_outputs = null)
        {
            throw new NotImplementedException();
        }
    }
}
