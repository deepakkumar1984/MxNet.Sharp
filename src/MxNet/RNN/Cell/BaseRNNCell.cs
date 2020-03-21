using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public abstract class BaseRNNCell
    {
        public virtual SymbolDict Params
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public abstract StateInfo[] StateInfo { get; }

        public virtual Shape[] StateShape
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual string[] GateNames
        {
            get
            {
                return new string[0];
            }
        }

        public BaseRNNCell(string prefix, RNNParams @params = null)
        {
            throw new NotImplementedException();
        }

        public virtual void Reset() => throw new NotImplementedException();

        public abstract void Call(Symbol inputs, Symbol[] states);

        public virtual Symbol[] BeginState(string func = "zeros", FuncArgs kwargs = null)
        {
            throw new NotImplementedException();
        }

        public virtual NDArrayDict UnpackWeights(NDArrayDict args)
        {
            throw new NotImplementedException();
        }

        public virtual NDArrayDict PackWeights(NDArrayDict args)
        {
            throw new NotImplementedException();
        }

        public virtual (Symbol, Symbol[]) Unroll(int length, Symbol[] inputs, Symbol[] begin_state = null, string layout = "NTC", bool? merge_outputs = null)
        {
            throw new NotImplementedException();
        }
    }
}
