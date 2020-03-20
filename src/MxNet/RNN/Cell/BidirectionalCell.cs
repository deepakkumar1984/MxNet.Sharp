using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class BidirectionalCell : BaseRNNCell
    {
        public BidirectionalCell(BaseRNNCell l_cell, BaseRNNCell r_cell, string output_prefix = "bi_", 
            RNNParams @params = null) : base("", @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public override void Call(Symbol inputs, Symbol[] states)
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

        public override Symbol[] BeginState(string func = "zeros", FuncArgs kwargs = null)
        {
            throw new NotImplementedException();
        }

        public override (Symbol, Symbol[]) Unroll(int length, Symbol[] inputs, Symbol[] begin_state = null, string layout = null, bool? merge_outputs = null)
        {
            throw new NotImplementedException();
        }
    }
}
