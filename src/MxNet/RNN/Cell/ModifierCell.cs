using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class ModifierCell : BaseRNNCell
    {
        public ModifierCell(BaseRNNCell base_cell) : base("", null)
        {
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public override SymbolDict Params => throw new NotImplementedException();

        public override void Call(Symbol inputs, Symbol[] states)
        {
            throw new NotImplementedException();
        }

        public override Symbol[] BeginState(string func = "zeros", FuncArgs kwargs = null)
        {
            throw new NotImplementedException();
        }

        public override NDArrayDict UnpackWeights(NDArrayDict args)
        {
            throw new NotImplementedException();
        }

        public override NDArrayDict PackWeights(NDArrayDict args)
        {
            throw new NotImplementedException();
        }
    }
}
