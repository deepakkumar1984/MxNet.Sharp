using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.SEResnet
{
    public class SE_BottleneckV1 : HybridBlock
    {
        public SE_BottleneckV1(int channels, int stride, bool downsample = false, int in_channels = 0, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
