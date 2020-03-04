using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class HybridSequentialRNNCell : HybridRecurrentCell
    {
        public HybridSequentialRNNCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
        }

        public void Add(RecurrentCell cell) => throw new NotImplementedException();

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol BeginState(int batch_size = 0, string func = null, FuncArgs args = null)
        {
            return base.BeginState(batch_size, func, args);
        }

        public (Symbol, List<Symbol[]>) Call(Symbol inputs, List<Symbol[]> states) => throw new NotImplementedException();

        public override (NDArrayOrSymbol[], NDArrayOrSymbol[]) Unroll(int length, NDArrayOrSymbol[] inputs, NDArrayOrSymbol[] begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            return base.Unroll(length, inputs, begin_state, layout, merge_outputs, valid_length);
        }

        public new SequentialRNNCell this[string i]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
