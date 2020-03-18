using System;
using MxNet.Gluon;
using MxNet.Gluon.Contrib.NN;
using MxNet.Gluon.NN;

namespace MxNet.GluonCV.ModelZoo
{
    public class SqueezeNet : HybridBlock
    {
        public SqueezeNet(string version, int classes = 1000, string prefix = null, ParameterDict @params = null) :
            base(prefix, @params)
        {
            if (version != "1.0" || version != "1.1")
                throw new NotSupportedException("Unsupported version");

            Features = new HybridSequential();
            if (version == "1.0")
            {
                Features.Add(new Conv2D(96, (7, 7), (2, 2)));
                Features.Add(new Activation(ActivationType.Relu));
                Features.Add(new MaxPool2D((3, 3), (2, 2), ceil_mode: true));
                Features.Add(MakeFire(16, 64, 64));
                Features.Add(MakeFire(16, 64, 64));
                Features.Add(MakeFire(32, 128, 128));
                Features.Add(new MaxPool2D((3, 3), (2, 2), ceil_mode: true));
                Features.Add(MakeFire(32, 128, 128));
                Features.Add(MakeFire(48, 192, 192));
                Features.Add(MakeFire(48, 192, 192));
                Features.Add(MakeFire(64, 256, 256));
                Features.Add(new MaxPool2D((3, 3), (2, 2), ceil_mode: true));
                Features.Add(MakeFire(64, 256, 256));
            }
            else if (version == "1.1")
            {
                Features.Add(new Conv2D(64, (3, 3), (2, 2)));
                Features.Add(new Activation(ActivationType.Relu));
                Features.Add(new MaxPool2D((3, 3), (2, 2), ceil_mode: true));
                Features.Add(MakeFire(16, 64, 64));
                Features.Add(MakeFire(16, 64, 64));
                Features.Add(new MaxPool2D((3, 3), (2, 2), ceil_mode: true));
                Features.Add(MakeFire(32, 128, 128));
                Features.Add(MakeFire(32, 128, 128));
                Features.Add(new MaxPool2D((3, 3), (2, 2), ceil_mode: true));
                Features.Add(MakeFire(48, 192, 192));
                Features.Add(MakeFire(48, 192, 192));
                Features.Add(MakeFire(64, 256, 256));
                Features.Add(MakeFire(64, 256, 256));
            }

            Features.Add(new Dropout(0.5f));


            Output = new HybridSequential();
            Output.Add(new Conv2D(classes, (1, 1)));
            Output.Add(new Activation(ActivationType.Relu));
            Output.Add(new AvgPool2D((13, 13)));
            Output.Add(new Flatten());
        }

        public HybridSequential Features { get; set; }
        public HybridSequential Output { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x, args);
            x = Output.Call(x, args);
            return x;
        }

        private HybridSequential MakeFire(int squeeze_channels, int expand1x1_channels, int expand3x3_channels)
        {
            var output = new HybridSequential("");
            output.Add(MakeFireConv(squeeze_channels, (1, 1)));

            var paths = new HybridConcurrent(1, "");
            paths.Add(MakeFireConv(expand1x1_channels, (1, 1)));
            paths.Add(MakeFireConv(expand3x3_channels, (3, 3), (1, 1)));

            output.Add(paths);

            return output;
        }

        private HybridSequential MakeFireConv(int channels, (int, int) kernel_size, (int, int)? padding = null)
        {
            var output = new HybridSequential("");
            output.Add(new Conv2D(channels, kernel_size, padding));
            output.Add(new Activation(ActivationType.Relu));

            return output;
        }

        public static SqueezeNet GetSqueezeNet(string version, bool pretrained = false, Context ctx = null,
            string root = "", int classes = 1000, string prefix = null, ParameterDict @params = null)
        {
            var net = new SqueezeNet(version, classes, prefix, @params);
            if (pretrained) net.LoadParameters(ModelStore.GetModelFile("squeezenet" + version), ctx);

            return net;
        }

        public static SqueezeNet GetSqueezeNet1_0(bool pretrained = false, Context ctx = null, string root = "",
            int classes = 1000, string prefix = null, ParameterDict @params = null)
        {
            return GetSqueezeNet("1.0", pretrained, ctx, root, classes, prefix, @params);
        }

        public static SqueezeNet GetSqueezeNet1_1(bool pretrained = false, Context ctx = null, string root = "",
            int classes = 1000, string prefix = null, ParameterDict @params = null)
        {
            return GetSqueezeNet("1.1", pretrained, ctx, root, classes, prefix, @params);
        }
    }
}