using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class HardSwish : HybridBlock
    {
        private HardSigmoid _act;
        public HardSwish(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            _act = new HardSigmoid(prefix, @params);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return x * this._act.Call(x);
        }
    }
}
