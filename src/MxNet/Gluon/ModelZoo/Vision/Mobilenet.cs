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
            var @out = output.Call(x, args);
            if(use_shortcut)
            {
                if (x.IsNDArray)
                    @out = nd.ElemwiseAdd(@out, x.NdX);
                else
                    @out = sym.ElemwiseAdd(@out, x.SymX);
            }

            return @out;
        }
    }

    public class MobileNet : HybridBlock
    {
        public HybridSequential Features { get; set; }
        public Dense Output { get; set; }

        private int[] dw_channels = new int[] { 32, 64, 128, 128, 256, 256, 512, 512, 512, 512, 512, 512, 1024 };
        private int[] channels = new int[] { 64, 128, 128, 256, 256, 512, 512, 512, 512, 512, 512, 1024, 1024 };
        private int[] strides = new int[] { 1, 2, 1, 2, 1, 2, 1, 1, 1, 1, 1, 2, 1 };

        public MobileNet(float multiplier= 1, int classes= 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Features = new HybridSequential(prefix: "");
            AddConv(Features, Convert.ToInt32(32 * multiplier), kernel: 3, pad: 1, stride: 2);
            for (int i = 0; i < dw_channels.Length; i++)
            {
                int dwc = Convert.ToInt32(multiplier * dw_channels[i]);
                int c = Convert.ToInt32(multiplier * channels[i]);
                int s = strides[i];

                AddConvDW(Features, dwc, c, s);
            }

            Features.Add(new GlobalAvgPool2D());
            Features.Add(new Flatten());

            Output = new Dense(classes);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x, args);
            x = Output.Call(x, args);
            return x;
        }

        internal static void AddConv(HybridSequential @out, int channels= 1, int kernel= 1, int stride= 1, int pad= 0,
                                        int num_group= 1, bool active= true, bool relu6= false)
        {
            @out.Add(new Conv2D(channels, (kernel, kernel), (stride, stride), (pad, pad), groups: num_group, use_bias: false));
            @out.Add(new BatchNorm(scale: true));
            if (active)
            {
                if (relu6)
                    @out.Add(new RELU6());
                else
                    @out.Add(new Activation(ActivationActType.Relu));
            }
        }

        internal static void AddConvDW(HybridSequential @out, int dw_channels, int channels = 1, int stride = 1, bool relu6 = false)
        {
            AddConv(@out, dw_channels, 3, stride, 1, dw_channels, relu6);
            AddConv(@out, channels, relu6: relu6);
        }

        public static MobileNet GetMobileNet(float multiplier, bool pretrained = false, Context ctx = null, string root = "", int classes = 1000, string prefix = null, ParameterDict @params = null)
        {
            var net = new MobileNet(multiplier, classes, prefix, @params);
            if (pretrained)
            {
                net.LoadParameters(ModelStore.GetModelFile($"mobilenet{multiplier}"), ctx: ctx);
            }

            return net;
        }

        public static MobileNet MobileNet1_0(bool pretrained = false, Context ctx = null, string root = "") => GetMobileNet(1, pretrained, ctx, root);

        public static MobileNet MobileNet0_75(bool pretrained = false, Context ctx = null, string root = "") => GetMobileNet(0.75f, pretrained, ctx, root);

        public static MobileNet MobileNet0_5(bool pretrained = false, Context ctx = null, string root = "") => GetMobileNet(0.5f, pretrained, ctx, root);

        public static MobileNet MobileNet0_25(bool pretrained = false, Context ctx = null, string root = "") => GetMobileNet(0.25f, pretrained, ctx, root);
    }

    public class MobileNetV2 : HybridBlock
    {
        public HybridSequential Features { get; set; }
        public HybridSequential Output { get; set; }

        private int[] in_channels_group = new int[] { 32, 16, 24, 24, 32, 32, 32, 64, 64, 64, 64, 96, 96, 96, 160, 160, 160 };
        private int[] channels_group = new int[] { 16, 24, 24, 32, 32, 32, 64, 64, 64, 64, 96, 96, 96, 160, 160, 160, 320 };
        private int[] strides = new int[] { 1, 2, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1 };
        private int[] ts = new int[] { 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 };

        public MobileNetV2(float multiplier = 1, int classes = 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Features = new HybridSequential(prefix: "");
            MobileNet.AddConv(Features, Convert.ToInt32(32 * multiplier), kernel: 3, pad: 1, stride: 2);
            for (int i = 0; i < in_channels_group.Length; i++)
            {
                int in_c = Convert.ToInt32(multiplier * in_channels_group[i]);
                int c = Convert.ToInt32(multiplier * channels_group[i]);
                int s = strides[i];
                int t = ts[i];

                Features.Add(new LinearBottleneck(in_c, c, t, s));
            }

            int last_channel = multiplier > 1 ? Convert.ToInt32((1280 * multiplier)) : 1280;
            MobileNet.AddConv(Features, last_channel, relu6: true);

            Features.Add(new GlobalAvgPool2D());

            Output = new HybridSequential(prefix: "output_");
            Output.Add(new Conv2D(classes, (1, 1), use_bias: false, prefix: "pred_"));
            Output.Add(new Flatten());
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x, args);
            x = Output.Call(x, args);
            return x;
        }

        public static MobileNet GetMobileNetV2(float multiplier, bool pretrained = false, Context ctx = null, string root = "", int classes = 1000, string prefix = null, ParameterDict @params = null)
        {
            var net = new MobileNet(multiplier, classes, prefix, @params);
            if (pretrained)
            {
                net.LoadParameters(ModelStore.GetModelFile($"mobilenetv2_{multiplier}"), ctx: ctx);
            }

            return net;
        }

        public static MobileNet MobileNetV2_1_0(bool pretrained = false, Context ctx = null, string root = "") => GetMobileNetV2(1, pretrained, ctx, root);

        public static MobileNet MobileNetV2_0_75(bool pretrained = false, Context ctx = null, string root = "") => GetMobileNetV2(0.75f, pretrained, ctx, root);

        public static MobileNet MobileNetV2_0_5(bool pretrained = false, Context ctx = null, string root = "") => GetMobileNetV2(0.5f, pretrained, ctx, root);

        public static MobileNet MobileNetV2_0_25(bool pretrained = false, Context ctx = null, string root = "") => GetMobileNetV2(0.25f, pretrained, ctx, root);
    }
}
