using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ResidualAttentionNet
{
    public class AttentionModule_stage1 : HybridBlock
    {
        public AttentionModule_stage1(int channels, int size1= 56, int size2= 28, int size3= 14, (float, float, float)? scale= null, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null,string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
