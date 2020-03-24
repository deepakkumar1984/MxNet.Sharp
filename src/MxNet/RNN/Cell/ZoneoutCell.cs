using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class ZoneoutCell : ModifierCell
    {
        public ZoneoutCell(BaseRNNCell base_cell, float zoneout_outputs= 0, float zoneout_states= 0) : base(base_cell)
        {
            throw new NotImplementedException();
        }

        public override void Call(Symbol inputs, SymbolList states)
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
