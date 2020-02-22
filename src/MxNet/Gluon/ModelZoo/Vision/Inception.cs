using MxNet.Gluon.Contrib.NN;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class Inception
    {
        internal static HybridSequential MakeBasicConv(int channels, (int, int) kernel_size, (int, int)? strides = default, (int, int)? padding = default)
        {
            var output = new HybridSequential(prefix: "");
            output.Add(new Conv2D(channels, kernel_size, strides, padding, use_bias: false));
            output.Add(new BatchNorm(epsilon: 0.001f));
            output.Add(new Activation(ActivationActType.Relu));

            return output;
        }

        internal static HybridSequential MakeBranch(string use_pool, int? channels = null, (int, int)? kernel_size = null, (int, int)? strides = null, (int, int)? padding = null)
        {
            var output = new HybridSequential(prefix: "");
            if (use_pool == "avg")
                output.Add(new AvgPool2D((3, 3), (1, 1), (1, 1)));
            else if (use_pool == "avg")
                output.Add(new MaxPool2D((3, 3), (1, 1)));

            if(channels.HasValue)
                output.Add(MakeBasicConv(channels.Value, kernel_size.Value, strides.Value, padding.Value));

            return output;
        }

        internal static HybridConcurrent MakeA(int pool_features, string prefix = "")
        {
            var output = new HybridConcurrent(axis: 1, prefix: prefix);
            output.Add(MakeBranch("", 64, (1, 1), null, null));

            output.Add(MakeBranch("", 48, (1, 1), null, null));
            output.Add(MakeBranch("", 64, (5, 5), null, (2, 2)));

            output.Add(MakeBranch("", 64, (1, 1), null, null));
            output.Add(MakeBranch("", 96, (3, 3), null, (1, 1)));
            output.Add(MakeBranch("", 96, (3, 3), null, (1, 1)));

            output.Add(MakeBranch("avg", pool_features, (1, 1), null, null));
            return output;
        }

        internal static HybridConcurrent MakeB(string prefix)
        {
            var output = new HybridConcurrent(axis: 1, prefix: prefix);
            output.Add(MakeBranch("", 384, (3, 3), (2, 2), null));

            output.Add(MakeBranch("", 64, (1, 1), null, null));
            output.Add(MakeBranch("", 96, (3, 3), null, (1, 1)));
            output.Add(MakeBranch("", 96, (3, 3), (2, 2), null));

            output.Add(MakeBranch("max"));
            return output;
        }

        internal static HybridConcurrent MakeC(int channels_7x7, string prefix)
        {
            var output = new HybridConcurrent(axis: 1, prefix: prefix);
            output.Add(MakeBranch("", 192, (1, 1), null, null));

            output.Add(MakeBranch("", channels_7x7, (1, 1), null, null));
            output.Add(MakeBranch("", channels_7x7, (1, 1), null, (0, 3)));
            output.Add(MakeBranch("", 192, (7, 1), null, (3, 0)));

            output.Add(MakeBranch("", channels_7x7, (1, 1), null, null));
            output.Add(MakeBranch("", channels_7x7, (7, 1), null, (3, 0)));
            output.Add(MakeBranch("", channels_7x7, (1, 7), null, (0, 3)));
            output.Add(MakeBranch("", channels_7x7, (7, 1), null, (3, 0)));

            output.Add(MakeBranch("avg", 192, (1, 1)));
            return output;
        }

        internal static HybridConcurrent MakeD(string prefix = "")
        {
            var output = new HybridConcurrent(axis: 1, prefix: prefix);
            output.Add(MakeBranch("", 192, (1, 1), null, null));
            output.Add(MakeBranch("", 320, (3, 3), (2, 2), null));

            output.Add(MakeBranch("", 192, (1, 1), null, null));
            output.Add(MakeBranch("", 192, (7, 1), null, (0, 3)));
            output.Add(MakeBranch("", 192, (1, 7), null, (3, 0)));
            output.Add(MakeBranch("", 192, (3, 3), (2, 2), null));

            output.Add(MakeBranch("max"));
            return output;
        }

        internal static HybridConcurrent MakeE(string prefix)
        {
            var output = new HybridConcurrent(axis: 1, prefix: prefix);
            output.Add(MakeBranch("", 320, (1, 1), null, null));

            var branch_3x3 = new HybridSequential(prefix: "");
            branch_3x3.Add(MakeBranch("", 384, (1, 1), null, null));
            output.Add(branch_3x3);

            var branch_3x3_split = new HybridConcurrent(axis: 1, prefix: prefix);
            branch_3x3_split.Add(MakeBranch("", 384, (1, 3), null, (0, 1)));
            branch_3x3_split.Add(MakeBranch("", 384, (3, 1), null, (1, 0)));
            output.Add(branch_3x3_split);

            var branch_3x3dbl = new HybridSequential(prefix: "");
            branch_3x3dbl.Add(MakeBranch("", 448, (1, 1), null, null));
            branch_3x3dbl.Add(MakeBranch("", 384, (3, 3), null, (1, 1)));
            output.Add(branch_3x3dbl);

            var branch_3x3dbl_split = new HybridConcurrent(axis: 1, prefix: prefix);
            branch_3x3dbl_split.Add(MakeBranch("", 384, (1, 3), null, (0, 1)));
            branch_3x3dbl_split.Add(MakeBranch("", 384, (3, 1), null, (1, 0)));
            output.Add(branch_3x3dbl_split);
            output.Add(MakeBranch("avg", 192));

            return output;
        }

        internal static HybridSequential MakeAux(int classes)
        {
            var output = new HybridSequential(prefix: "");
            output.Add(new AvgPool2D((5, 5), (3, 3)));
            output.Add(MakeBasicConv(128, (1, 1)));
            output.Add(MakeBasicConv(768, (5, 5)));
            output.Add(new Flatten());
            output.Add(new Dense(classes));
            return output;
        }

        public static Inception3 GetInception3(bool pretrained = false, Context ctx = null, string root = "", int classes = 1000, string prefix = null, ParameterDict @params = null)
        {
            var net = new Inception3(classes, prefix, @params);
            if (pretrained)
            {
                net.LoadParameters(ModelStore.GetModelFile("inceptionv3"), ctx: ctx);
            }

            return net;
        }
    }

    public class Inception3 : HybridBlock
    {
        public HybridSequential Features { get; set; }
        public Dense Output { get; set; }

        public Inception3(int classes = 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Features = new HybridSequential(prefix: "");
            Features.Add(Inception.MakeBasicConv(32, (3, 3), (2, 2)));
            Features.Add(Inception.MakeBasicConv(32, (3, 3)));
            Features.Add(Inception.MakeBasicConv(64, (3, 3), padding: (1, 1)));
            Features.Add(new MaxPool2D((3, 3), (2, 2)));
            Features.Add(Inception.MakeBasicConv(80, (1, 1)));
            Features.Add(Inception.MakeBasicConv(192, (3, 3)));
            Features.Add(new MaxPool2D((3, 3), (2, 2)));
            Features.Add(Inception.MakeA(32, "A1_"));
            Features.Add(Inception.MakeA(64, "A2_"));
            Features.Add(Inception.MakeA(64, "A3_"));
            Features.Add(Inception.MakeB("B_"));
            Features.Add(Inception.MakeC(128, "C1_"));
            Features.Add(Inception.MakeC(160, "C2_"));
            Features.Add(Inception.MakeC(160, "C3_"));
            Features.Add(Inception.MakeC(192, "C4_"));
            Features.Add(Inception.MakeD("D_"));
            Features.Add(Inception.MakeD("E1_"));
            Features.Add(Inception.MakeD("E2_"));
            Features.Add(new AvgPool2D((8, 8)));
            Features.Add(new Dropout(0.5f));

            Output = new Dense(classes);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x, args);
            x = Output.Call(x, args);
            return x;
        }
    }
}
