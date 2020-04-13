using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.FastPose
{
    public class Bottleneck : HybridBlock
    {
        public Bottleneck(int planes, int inplanes, HybridBlock downsample = null, bool reduction = false, string norm_layer = "BatchNorm", FuncArgs kwargs = null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
