using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class RELU6 : HybridBlock
    {
        public RELU6(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Clip(x, 0, 6);

            return sym.Clip(x, 0, 6);
        }
    }

    public class LinearBottleneck : HybridBlock
    {
        private bool use_shortcut;
        private HybridSequential output;

        public LinearBottleneck(int in_channels, int channels, int t, int stride, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            use_shortcut = (stride == 1 && in_channels == channels);
            output = new HybridSequential();
            MobileNet.AddConv(output, in_channels * t, relu6: true);
            MobileNet.AddConv(output, in_channels * t, kernel: 3, stride: stride, pad: 1, num_group: in_channels, relu6: true);
            MobileNet.AddConv(output, channels, active: false, relu6: true);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var @out = output.Call(x);
            if(use_shortcut)
            {
                if (x.IsNDArray)
                    @out = nd.ElemwiseAdd(@out.NdX, x.NdX);
                else
                    @out = sym.ElemwiseAdd(@out.SymX, x.SymX);
            }

            return @out;
        }
    }

    public class MobileNet : HybridBlock
    {
        public MobileNet(float multiplier= 1, int classes= 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();

        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        internal static void AddConv(HybridSequential @out, int channels= 1, int kernel= 1, int stride= 1, int pad= 0,
                                        int num_group= 1, bool active= true, bool relu6= false)
        {
            throw new NotImplementedException();
        }

        internal static void AddConvDW(HybridSequential @out, int dw_channels, int channels = 1, int stride = 1, bool relu6 = false)
        {
            throw new NotImplementedException();
        }

        public static MobileNet GetMobileNet(float multiplier, bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static MobileNet MobileNet1_0(bool pretrained = false, Context ctx = null, string root = "./models") => GetMobileNet(1, pretrained, ctx, root);

        public static MobileNet MobileNet0_75(bool pretrained = false, Context ctx = null, string root = "./models") => GetMobileNet(0.75f, pretrained, ctx, root);

        public static MobileNet MobileNet0_5(bool pretrained = false, Context ctx = null, string root = "./models") => GetMobileNet(0.5f, pretrained, ctx, root);

        public static MobileNet MobileNet0_25(bool pretrained = false, Context ctx = null, string root = "./models") => GetMobileNet(0.25f, pretrained, ctx, root);
    }

    public class MobileNetV2 : HybridBlock
    {
        public MobileNetV2(float multiplier = 1, int classes = 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();

        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static MobileNet GetMobileNetV2(float multiplier, bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static MobileNet MobileNetV2_1_0(bool pretrained = false, Context ctx = null, string root = "./models") => GetMobileNetV2(1, pretrained, ctx, root);

        public static MobileNet MobileNetV2_0_75(bool pretrained = false, Context ctx = null, string root = "./models") => GetMobileNetV2(0.75f, pretrained, ctx, root);

        public static MobileNet MobileNetV2_0_5(bool pretrained = false, Context ctx = null, string root = "./models") => GetMobileNetV2(0.5f, pretrained, ctx, root);

        public static MobileNet MobileNetV2_0_25(bool pretrained = false, Context ctx = null, string root = "./models") => GetMobileNetV2(0.25f, pretrained, ctx, root);
    }
}
