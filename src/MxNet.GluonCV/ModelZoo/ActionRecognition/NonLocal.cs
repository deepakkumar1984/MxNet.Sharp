using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ActionRecognition
{
    public class NonLocal : HybridBlock
    {
        public NonLocal(int in_channels = 1024, string nonlocal_type = "gaussian", int dim = 3, bool embed = true, Shape embed_dim = null, bool sub_sample = false, bool use_bn = true,
                 string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, Context ctx = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public static NonLocal BuildNonLocalBlock(FuncArgs cfg)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
