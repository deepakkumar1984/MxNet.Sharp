using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class ZoneoutCell : ModifierCell
    {
        public ZoneoutCell(RecurrentCell base_cell) : base(base_cell)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "zoneout";
        }

        public override void Reset() => throw new NotImplementedException();

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
