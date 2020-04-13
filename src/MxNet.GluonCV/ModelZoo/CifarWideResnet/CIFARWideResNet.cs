using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.CifarWideResnet
{
    public class CIFARWideResNet : HybridBlock
    {
        public CIFARWideResNet(HybridBlock block, int[] layers, int[] channels, float drop_rate, int classes= 10, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeLayer(HybridBlock block, int[] layers, int[] channels, float drop_rate, int stride, int stage_index, int in_channels, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARWideResNet GetCIFARWideResNet(int num_layers, int width_factor= 1, float drop_rate= 0, bool pretrained= false, Context ctx= null, string root = "~/mxnet", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARWideResNet CifarWideResNet16_10(float drop_rate = 0, bool pretrained = false, Context ctx = null, string root = "~/mxnet", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARWideResNet CifarWideResNet28_10(float drop_rate = 0, bool pretrained = false, Context ctx = null, string root = "~/mxnet", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARWideResNet CifarWideResNet40_8(float drop_rate = 0, bool pretrained = false, Context ctx = null, string root = "~/mxnet", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }
    }
}
