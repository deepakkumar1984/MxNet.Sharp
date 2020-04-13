using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Centernet
{
    public class IDAUp : HybridBlock
    {
        public IDAUp(int out_channels, int in_channels, float[] up_f, bool use_dcnv2 = false, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
