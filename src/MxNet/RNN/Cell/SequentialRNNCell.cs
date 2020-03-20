using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class SequentialRNNCell : BaseRNNCell
    {
        public SequentialRNNCell(RNNParams @params = null) : base("", @params)
        {
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public void Add(BaseRNNCell cell)
        {
            throw new NotImplementedException();
        }

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

        public override (Symbol, Symbol[]) Unroll(int length, Symbol[] inputs, Symbol[] begin_state = null, string layout = null, bool? merge_outputs = null)
        {
            throw new NotImplementedException();
        }
    }
}
