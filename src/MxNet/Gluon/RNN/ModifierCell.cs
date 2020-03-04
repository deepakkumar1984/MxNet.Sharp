using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class ModifierCell : HybridRecurrentCell
    {
        private HybridRecurrentCell BaseCell;

        public ModifierCell(RecurrentCell base_cell) 
            : base(base_cell.Prefix + base_cell.Alias(), base_cell.Params)
        {
            throw new NotImplementedException();
        }

        public override ParameterDict Params => BaseCell.Params;

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
