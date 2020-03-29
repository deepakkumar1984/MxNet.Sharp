using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.CifarResnet
{
    public class CIFARResNetV2 : HybridBlock
    {
        public CIFARResNetV2(HybridBlock block, int[] layers, int[] channels, int classes = 10, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeLayer(HybridBlock block, int[] layers, int[] channels, int stride, int stage_index, int in_channels = 0, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARResNetV2 GetCIFARResNetV2(int num_layers, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARResNetV2 Cifar_ResNet20_V2(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARResNetV2 Cifar_ResNet56_V2(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARResNetV2 Cifar_ResNet110_V2(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }
    }
}
