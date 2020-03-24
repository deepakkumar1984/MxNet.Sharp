using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class FusedRNNCell : BaseRNNCell
    {
        public FusedRNNCell(int num_hidden, int num_layers= 1, string mode= "lstm", bool  bidirectional= false,
                 float dropout= 0, bool get_next_state= false, float forget_bias= 1, string prefix = null, RNNParams @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public override string[] GateNames => throw new NotImplementedException();

        public int NumGates
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private NDArray SliceWeight(NDArrayList arr, int li, int lh)
        {
            throw new NotImplementedException();
        }

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

        public override (Symbol, SymbolList) Unroll(int length, SymbolList inputs, SymbolList begin_state = null, string layout = null, bool? merge_outputs = null)
        {
            throw new NotImplementedException();
        }

        public SequentialRNNCell Unfuse()
        {
            throw new NotImplementedException();
        }
    }
}
