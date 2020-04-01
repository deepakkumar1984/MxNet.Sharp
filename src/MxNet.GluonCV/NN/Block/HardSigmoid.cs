using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class HardSigmoid : HybridBlock
    {
        private ReLU6 _act;
        public HardSigmoid(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            _act = new ReLU6(prefix, @params);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return _act.Call(x + 3) / 6;
        }
    }
}
