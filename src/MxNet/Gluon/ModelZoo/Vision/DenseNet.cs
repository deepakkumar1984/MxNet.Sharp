using MxNet.Gluon.Contrib.NN;
using MxNet.Gluon.NN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class DenseNet : HybridBlock
    {
        private static Dictionary<int, (int, int, int[])> densenet_spec = new Dictionary<int, (int, int, int[])>()
        {
            { 121, (64, 32, new int[]{ 6, 12, 24, 16})},
              { 161, (96, 48, new int[]{ 6, 12, 36, 24})},
                { 169, (64, 32, new int[]{ 6, 12, 32, 32})},
                  { 201, (64, 32, new int[]{ 6, 12, 48, 32})}
        };

        public HybridSequential Features { get; set; }
        public Dense Output { get; set; }

        public DenseNet(int num_init_features, int growth_rate, int[] block_config,
                        int bn_size= 4, float? dropout= null, int classes= 1000, 
                        string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Features = new HybridSequential(prefix = "");
            Features.Add(new Conv2D(num_init_features, kernel_size: (7, 7), strides: (2, 2), padding: (3, 3), use_bias: false));
            Features.Add(new BatchNorm());
            Features.Add(new Activation(ActivationActType.Relu));
            Features.Add(new MaxPool2D(pool_size: (3, 3), strides: (2, 2), padding: (1, 1)));

            var num_features = num_init_features;
            for(int i=0;i<block_config.Length;i++)
            {
                int num_layers = block_config[i];
                Features.Add(MakeDenseBlock(num_layers, bn_size, growth_rate, dropout, i + 1));
                num_features = num_features + num_layers * growth_rate;
                if(i != block_config.Length - 1)
                {
                    num_features = (int)Math.Truncate(Convert.ToDouble(num_features / 2));
                    Features.Add(MakeTransition(num_features));
                }
            }

            Features.Add(new BatchNorm());
            Features.Add(new Activation(ActivationActType.Relu));
            Features.Add(new AvgPool2D(pool_size: (7, 7)));

            Output = new Dense(classes);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x, args);
            x = Output.Call(x, args);
            return x;
        }

        public static DenseNet GetDenseNet(int num_layers, bool pretrained= false, Context ctx= null, string root= "", int bn_size = 4, float? dropout = null, int classes = 1000)
        {
            var (num_init_features, growth_rate, block_config) = densenet_spec[num_layers];
            var net = new DenseNet(num_init_features, growth_rate, block_config, bn_size, dropout, classes);
            if(pretrained)
            {
                net.LoadParameters(ModelStore.GetModelFile("densenet" + num_layers, root), ctx: ctx);
            }

            return net;
        }

        public static DenseNet DenseNet121(bool pretrained = false, Context ctx = null, string root = "", int bn_size = 4, float? dropout = null, int classes = 1000)
        {
            return GetDenseNet(121, pretrained, ctx, root, bn_size, dropout, classes);
        }

        public static DenseNet DenseNet161(bool pretrained = false, Context ctx = null, string root = "", int bn_size = 4, float? dropout = null, int classes = 1000)
        {
            return GetDenseNet(161, pretrained, ctx, root, bn_size, dropout, classes);
        }

        public static DenseNet DenseNet169(bool pretrained = false, Context ctx = null, string root = "", int bn_size = 4, float? dropout = null, int classes = 1000)
        {
            return GetDenseNet(169, pretrained, ctx, root, bn_size, dropout, classes);
        }

        public static DenseNet DenseNet201(bool pretrained = false, Context ctx = null, string root = "", int bn_size = 4, float? dropout = null, int classes = 1000)
        {
            return GetDenseNet(201, pretrained, ctx, root, bn_size, dropout, classes);
        }

        private static HybridSequential MakeDenseBlock(int num_layers, int bn_size, int growth_rate, float? dropout, int stage_index)
        {
            var block = new HybridSequential(prefix: "stage" + stage_index);
            for (int i = 0; i < num_layers; i++)
            {
                block.Add(MakeDenseLayer(growth_rate, bn_size, dropout));
            }

            return block;
        }

        private static HybridConcurrent MakeDenseLayer(int growth_rate, int bn_size, float? dropout)
        {
            var new_features = new HybridSequential(prefix: "");
            new_features.Add(new BatchNorm());
            new_features.Add(new Activation(ActivationActType.Relu));
            new_features.Add(new Conv2D(bn_size * growth_rate, kernel_size: (1, 1), use_bias: false));
            new_features.Add(new BatchNorm());
            new_features.Add(new Activation(ActivationActType.Relu));
            new_features.Add(new Conv2D(bn_size * growth_rate, kernel_size: (3, 3), padding: (1, 1), use_bias: false));

            if (dropout.HasValue)
                new_features.Add(new Dropout(dropout.Value));

            var result = new HybridConcurrent(axis: 1, prefix: "");
            result.Add(new Identity());
            result.Add(new_features);

            return result;
        }

        private static HybridSequential MakeTransition(int num_output_features)
        {
            var block = new HybridSequential(prefix: "");
            block.Add(new BatchNorm());
            block.Add(new Activation(ActivationActType.Relu));
            block.Add(new Conv2D(num_output_features, kernel_size: (1, 1), use_bias: false));
            block.Add(new AvgPool2D(pool_size: (2, 2), strides: (2, 1)));

            return block;
        }
    }
}
