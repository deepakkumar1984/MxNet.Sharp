using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class RNNCell : BaseRNNCell
    {
        public RNNCell(int num_hidden, ActivationType activation = ActivationType.Tanh, string prefix = "rnn_", RNNParams @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public override string[] GateNames => throw new NotImplementedException();

        public override void Call(Symbol inputs, Symbol[] states)
        {
            throw new NotImplementedException();
        }
    }
}
