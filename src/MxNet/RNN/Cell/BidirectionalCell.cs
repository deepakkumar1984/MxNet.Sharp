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

        public override void Call(Symbol inputs, SymbolList states)
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

        public override SymbolList BeginState(string func = "zeros", FuncArgs kwargs = null)
        {
            throw new NotImplementedException();
        }

        public override (Symbol, SymbolList) Unroll(int length, SymbolList inputs, SymbolList begin_state = null, string layout = null, bool? merge_outputs = null)
        {
            throw new NotImplementedException();
        }
    }
}
