using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class DropoutCell : BaseRNNCell
    {
        public DropoutCell(float dropout, string prefix, RNNParams @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public override void Call(Symbol inputs, Symbol[] states)
        {
            throw new NotImplementedException();
        }

        public override (Symbol, Symbol[]) Unroll(int length, Symbol[] inputs, Symbol[] begin_state = null, string layout = null, bool? merge_outputs = null)
        {
            throw new NotImplementedException();
        }
    }
}
