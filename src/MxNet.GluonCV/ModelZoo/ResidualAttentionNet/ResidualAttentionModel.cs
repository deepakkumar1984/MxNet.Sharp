using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ResidualAttentionNet
{
    public class ResidualAttentionModel : HybridBlock
    {
        public ResidualAttentionModel((float, float, float) scale, (float, float, float) m, int classes= 1000, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static ResidualAttentionModel GetResidualAttentionModel(int input_size, int num_layers, bool pretrained= false, Context ctx= null, string root= "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ResidualAttentionModel ResidualAttentionNet56(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ResidualAttentionModel ResidualAttentionNet92(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ResidualAttentionModel ResidualAttentionNet128(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ResidualAttentionModel ResidualAttentionNet164(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ResidualAttentionModel ResidualAttentionNet200(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ResidualAttentionModel ResidualAttentionNet236(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ResidualAttentionModel ResidualAttentionNet452(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }
    }
}
