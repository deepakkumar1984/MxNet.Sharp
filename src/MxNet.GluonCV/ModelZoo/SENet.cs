using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo
{
    public class SENet : HybridBlock
    {
        public SENet(int[] layers, int cardinality, int bottleneck_width, bool avg_down= false, int classes= 1000, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeLayer(int channels, int num_layers, int stride, int stage_index, bool avg_down= false, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null)
        {
            throw new NotImplementedException();
        }

        public static SENet GetSENet(int num_layers, int cardinality= 64, int bottleneck_width= 4, bool avg_down= false, bool pretrained= false, Context ctx= null,string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static SENet SENet_154(int cardinality = 64, int bottleneck_width = 4, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            return GetSENet(152, cardinality, bottleneck_width, false, pretrained, ctx, root);
        }

        public static SENet SENet_154e(int cardinality = 64, int bottleneck_width = 4, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            return GetSENet(152, cardinality, bottleneck_width, true, pretrained, ctx, root);
        }
    }

    public class SEBlock : HybridBlock
    {
        public SEBlock(int channels, int cardinality, int bottleneck_width, int stride, bool downsample= false, int downsample_kernel_size= 3, bool avg_down= false,
                 string norm_layer= "BatchNorm", FuncArgs norm_kwargs = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
