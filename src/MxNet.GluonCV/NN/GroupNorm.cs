using MxNet.Gluon;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class GroupNorm : HybridBlock
    {
        public GroupNorm(int ngroups= 32, int in_channels= 0, int axis= 1, float epsilon= 1e-5f, Initializer beta_initializer= null, Initializer gamma_initializer= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public void Cast(DType dtype)
        {
            throw new NotImplementedException();
        }
    }
}
