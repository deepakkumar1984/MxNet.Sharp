using System.Collections.Generic;
using MxNet.Gluon.NN;
using MxNet.Initializers;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class VGG : HybridBlock
    {
        private static readonly Dictionary<int, (int[], int[])> vgg_spec = new Dictionary<int, (int[], int[])>
        {
            {11, (new[] {1, 1, 2, 2, 2}, new[] {64, 128, 256, 512, 512})},
            {13, (new[] {2, 2, 2, 2, 2}, new[] {64, 128, 256, 512, 512})},
            {16, (new[] {2, 2, 3, 3, 3}, new[] {64, 128, 256, 512, 512})},
            {19, (new[] {2, 2, 4, 4, 4}, new[] {64, 128, 256, 512, 512})}
        };

        public VGG(int[] layers, int[] filters, int classes = 1000, bool batch_norm = false, string prefix = null,
            ParameterDict @params = null) : base(prefix, @params)
        {
            Features = MakeFeatures(layers, filters, batch_norm);
            Features.Add(new Dense(4096, ActivationActType.Relu, weight_initializer: "normal"));
            Features.Add(new Dropout(0.5f));
            Features.Add(new Dense(4096, ActivationActType.Relu, weight_initializer: "normal"));
            Features.Add(new Dropout(0.5f));

            Output = new Dense(classes, weight_initializer: "normal");
        }

        public HybridSequential Features { get; set; }
        public Dense Output { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x, args);
            x = Output.Call(x, args);
            return x;
        }

        private HybridSequential MakeFeatures(int[] layers, int[] filters, bool batch_norm = false)
        {
            var featurizer = new HybridSequential("");
            for (var i = 0; i < layers.Length; i++)
            {
                var num = layers[i];
                for (var j = 0; i < num; j++)
                {
                    featurizer.Add(new Conv2D(filters[i], (3, 3), (1, 1),
                        weight_initializer: new Xavier("gaussian", "out", 2)));
                    if (batch_norm)
                        featurizer.Add(new BatchNorm());

                    featurizer.Add(new Activation(ActivationActType.Relu));
                }

                featurizer.Add(new MaxPool2D(strides: (2, 2)));
            }

            return featurizer;
        }

        public static VGG GetVgg(int num_layers, bool pretrained = false, Context ctx = null, string root = "",
            bool batch_norm = false)
        {
            var (layers, filters) = vgg_spec[num_layers];
            var net = new VGG(layers, filters, batch_norm: batch_norm);
            if (pretrained)
            {
                var batch_norm_suffix = batch_norm ? "_bn" : "";
                net.LoadParameters(ModelStore.GetModelFile($"vgg{num_layers}{batch_norm_suffix}"), ctx);
            }

            return net;
        }

        public static VGG Vgg11(bool pretrained = false, Context ctx = null, string root = "")
        {
            return GetVgg(11, pretrained, ctx, root);
        }

        public static VGG Vgg13(bool pretrained = false, Context ctx = null, string root = "")
        {
            return GetVgg(13, pretrained, ctx, root);
        }

        public static VGG Vgg16(bool pretrained = false, Context ctx = null, string root = "")
        {
            return GetVgg(16, pretrained, ctx, root);
        }

        public static VGG Vgg19(bool pretrained = false, Context ctx = null, string root = "")
        {
            return GetVgg(19, pretrained, ctx, root);
        }

        public static VGG Vgg11_BN(bool pretrained = false, Context ctx = null, string root = "")
        {
            return GetVgg(11, pretrained, ctx, root, true);
        }

        public static VGG Vgg13_BN(bool pretrained = false, Context ctx = null, string root = "")
        {
            return GetVgg(13, pretrained, ctx, root, true);
        }

        public static VGG Vgg16_BN(bool pretrained = false, Context ctx = null, string root = "")
        {
            return GetVgg(16, pretrained, ctx, root, true);
        }

        public static VGG Vgg19_BN(bool pretrained = false, Context ctx = null, string root = "")
        {
            return GetVgg(19, pretrained, ctx, root, true);
        }
    }
}