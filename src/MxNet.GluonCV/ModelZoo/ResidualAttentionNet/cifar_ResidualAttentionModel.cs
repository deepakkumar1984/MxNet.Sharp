using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ResidualAttentionNet
{
    public class CifarResidualAttentionModel : HybridBlock
    {
        public CifarResidualAttentionModel((float, float, float) scale, (float, float, float) m, int classes = 10, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static CifarResidualAttentionModel GetCifarResidualAttentionModel(int input_size, int num_layers, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static CifarResidualAttentionModel CifarResidualAttentionNet56(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static CifarResidualAttentionModel CifarResidualAttentionNet92(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static CifarResidualAttentionModel CifarResidualAttentionNet452(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }
    }
}
