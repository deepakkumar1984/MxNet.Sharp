using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class StateInfo
    {
        public Shape Shape { get; set; }

        public string Layout { get; set; }
    }

    public abstract class RecurrentCell : HybridBlock
    {
        public delegate Symbol StateFunc(Symbol x, params object[] args);

        public RecurrentCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public virtual void Reset() => throw new NotImplementedException();

        public abstract StateInfo StateInfo(int batch_size= 0);

        public virtual List<Symbol[]> BeginState(int batch_size = 0, StateFunc func = null, params object[] args) => throw new NotImplementedException();

        public virtual (Symbol[], Symbol[]) Unroll(int length, Symbol[] inputs, List<Symbol[]> begin_state= null, 
                            string layout= "NTC", bool? merge_outputs= null, Symbol valid_length= null) => throw new NotImplementedException();

        private Activation GetActivation(Symbol input, string activation, params object[] args) => throw new NotImplementedException();

        public override NDArray Forward(NDArray input, params NDArray[] args)
        {
            throw new NotImplementedException();
        }
    }
}
