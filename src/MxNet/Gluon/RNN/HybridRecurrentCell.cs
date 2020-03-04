using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class HybridRecurrentCell : RecurrentCell
    {
        public NDArrayOrSymbol[] Outputs { get; set; }
        public HybridRecurrentCell(string prefix, ParameterDict @params) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return null;
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            return null;
        }
    }
}
