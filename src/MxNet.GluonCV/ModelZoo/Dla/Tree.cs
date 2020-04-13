using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Dla
{
    public class Tree : HybridBlock
    {
        public Tree(int levels, HybridBlock block, int in_channels, int out_channels, int stride= 1, bool level_root= false, int root_dim= 0, int root_kernel_size= 1,
                 int dilation= 1, bool root_residual= false, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
