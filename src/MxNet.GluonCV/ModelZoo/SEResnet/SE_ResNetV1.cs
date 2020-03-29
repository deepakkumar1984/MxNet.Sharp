using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.SEResnet
{
    public class SE_ResNetV1 : HybridBlock
    {
        public SE_ResNetV1(HybridBlock block, int[] layers, int[] channels, int classes= 1000, bool thumbnail= false, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeLayer(HybridBlock block, int[] layers, int[] channels, int stride, int stage_index, int in_channels= 0, string norm_layer = "", bool last_gamma = false)
        {
            throw new NotImplementedException();
        }

        public static SE_ResNetV1 GetSE_ResNetV1(int num_layers, bool pretrained= false, Context ctx= null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static SE_ResNetV1 SE_ResNet18_V1(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static SE_ResNetV1 SE_ResNet34_V1(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static SE_ResNetV1 SE_ResNet50_V1(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static SE_ResNetV1 SE_ResNet101_V1(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static SE_ResNetV1 SE_ResNet152_V1(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }
    }
}
