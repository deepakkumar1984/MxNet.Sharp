using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo
{
    public class WiderResNetA2 : HybridBlock
    {
        public WiderResNetA2(int[] structure, HybridSequential norm_act = null, int classes= 0, bool dilation= false, bool dist_bn= false, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static WiderResNetA2 GetWiderResNetA2(int[] structure, bool pretrained = false, Context ctx = null, string root = "", HybridSequential norm_act = null, bool dilation = false, bool dist_bn = false)
        {
            throw new NotImplementedException();
        }

        public static WiderResNetA2 WiderResNetA2_16(bool pretrained = false, Context ctx = null, string root = "", HybridSequential norm_act = null, bool dilation = false, bool dist_bn = false)
        {
            return GetWiderResNetA2(new int[] { 1, 1, 1, 1, 1, 1 }, pretrained, ctx, root, norm_act, dilation, dist_bn);
        }

        public static WiderResNetA2 WiderResNetA2_20(bool pretrained = false, Context ctx = null, string root = "", HybridSequential norm_act = null, bool dilation = false, bool dist_bn = false)
        {
            return GetWiderResNetA2(new int[] { 1, 1, 1, 3, 1, 1 }, pretrained, ctx, root, norm_act, dilation, dist_bn);
        }

        public static WiderResNetA2 WiderResNetA2_38(bool pretrained = false, Context ctx = null, string root = "", HybridSequential norm_act = null, bool dilation = false, bool dist_bn = false)
        {
            return GetWiderResNetA2(new int[] { 3, 3, 6, 3, 1, 1 }, pretrained, ctx, root, norm_act, dilation, dist_bn);
        }

        public HybridSequential BNRelu(int channels, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null)
        {
            var @out = new HybridSequential(prefix: "");
            var bn = LayerUtils.NormLayer(norm_layer, norm_kwargs);
            @out.Add(LayerUtils.NormLayer(norm_layer, norm_kwargs));
            @out.Add(new Activation(ActivationType.Relu));
            return @out;
        }
    }

    public class IdentityResidualBlock : HybridBlock
    {
        public IdentityResidualBlock(int in_channels, int channels, int strides= 1,  int dilation= 1, int groups= 1,HybridSequential norm_act= null,
                 float? dropout= null, bool dist_bn= false, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
