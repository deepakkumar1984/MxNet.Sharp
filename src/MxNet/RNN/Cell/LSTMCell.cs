using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class LSTMCell : BaseRNNCell
    {
        public LSTMCell(int num_hidden, string prefix = "lstm_", RNNParams @params = null, float forget_bias = 1) : base(prefix, @params)
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
