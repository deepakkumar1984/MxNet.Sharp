using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Nasnet
{
    public class BranchSeparables : HybridBlock
    {
        public BranchSeparables(int in_channels, int out_channels, (int, int) kernel_size, (int, int) stride, (int, int) padding, string norm_layer, FuncArgs norm_kwargs, bool use_bias= false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
