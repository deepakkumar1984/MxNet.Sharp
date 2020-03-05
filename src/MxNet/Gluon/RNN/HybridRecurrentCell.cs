using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public abstract class HybridRecurrentCell : RecurrentCell
    {
        public HybridRecurrentCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            return input;
        }

        public abstract (NDArrayOrSymbol, NDArrayOrSymbol[]) HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args);

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            return null;
        }
    }
}
