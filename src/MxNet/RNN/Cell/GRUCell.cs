using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class GRUCell : BaseRNNCell
    {
        public GRUCell(int num_hidden, string prefix = "lstm_", RNNParams @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public override string[] GateNames => throw new NotImplementedException();

        public override void Call(Symbol inputs, SymbolList states)
        {
            throw new NotImplementedException();
        }
    }
}
