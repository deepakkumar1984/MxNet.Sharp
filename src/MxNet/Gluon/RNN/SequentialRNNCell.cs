using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class SequentialRNNCell : RecurrentCell
    {
        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SequentialRNNCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
        }

        public void Add(RecurrentCell cell) => throw new NotImplementedException();

        public override List<Symbol[]> BeginState(int batch_size = 0, StateFunc func = null, params object[] args)
        {
            throw new NotImplementedException();
        }

        public (Symbol, List<Symbol[]>) Call(Symbol inputs, List<Symbol[]> states) => throw new NotImplementedException();

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override StateInfo StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override (Symbol[], Symbol[]) Unroll(int length, Symbol[] inputs, List<Symbol[]> begin_state = null, string layout = "NTC", bool? merge_outputs = null, Symbol valid_length = null)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public new SequentialRNNCell this[string i]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
