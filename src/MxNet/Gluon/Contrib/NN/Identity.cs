using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.NN
{
    public class Identity : HybridBlock
    {
        public Identity(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
