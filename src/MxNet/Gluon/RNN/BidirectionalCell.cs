using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class BidirectionalCell : HybridRecurrentCell
    {
        public BidirectionalCell(RecurrentCell l_cell, RecurrentCell r_cell, string output_prefix = "bi_") : base("", null)
        {
            throw new NotImplementedException();
        }

        public (Symbol, List<Symbol[]>) Call(Symbol inputs, List<Symbol[]> states) => throw new NotSupportedException("Bidirectional cannot be stepped. Please use unroll");

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol[] BeginState(int batch_size = 0, string func = null, FuncArgs args = null)
        {
            return base.BeginState(batch_size, func, args);
        }

        public override (NDArrayOrSymbol[], NDArrayOrSymbol[]) Unroll(int length, NDArrayOrSymbol[] inputs, NDArrayOrSymbol[] begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            return base.Unroll(length, inputs, begin_state, layout, merge_outputs, valid_length);
        }
    }
}
