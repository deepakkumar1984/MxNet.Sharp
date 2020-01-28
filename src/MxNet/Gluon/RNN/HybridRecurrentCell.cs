using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public partial class HybridRecurrentCell : RecurrentCell
    {
        public HybridRecurrentCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override StateInfo StateInfo(int batch_size = 0)
        {
            return null;
        }
    }
}
