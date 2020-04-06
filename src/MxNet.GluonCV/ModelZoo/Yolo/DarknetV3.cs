using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class DarknetV3 : HybridBlock
    {
        internal HybridSequential features;

        internal Dense output;

        public DarknetV3(int[] layers, int[] channels, int classes= 1000, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Debug.Assert(layers.Length == channels.Length - 1, $"len(channels) should equal to len(layers) + 1, given {channels.Length} vs {layers.Length}");
            this.features = new HybridSequential();
            // first 3x3 conv
            this.features.Add(Conv2d(channels[0], 3, 1, 1, norm_layer: norm_layer, norm_kwargs: norm_kwargs));
            for (int i = 0; i < layers.Length; i++)
            {
                int nlayer = layers[i];
                int channel = channels[i];
                Debug.Assert(channel % 2 == 0, $"channel {channel} cannot be divided by 2");
                // add downsample conv with stride=2
                this.features.Add(Conv2d(channel, 3, 1, 2, norm_layer: norm_layer, norm_kwargs: norm_kwargs));
                // add nlayer basic blocks
                foreach (var _ in Enumerable.Range(0, nlayer))
                {
                    this.features.Add(new DarknetBasicBlockV3(channel / 2, norm_layer: norm_layer, norm_kwargs: norm_kwargs));
                }
            }

            // output
            this.output = new Dense(classes);

            RegisterChild(features);
            RegisterChild(output);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = this.features.Call(x);
            if (x.IsNDArray)
                x = nd.Pooling(x, kernel: new Shape(7, 7), global_pool: true, pool_type: PoolingType.Avg);
            else
                x = sym.Pooling(x, kernel: new Shape(7, 7), global_pool: true, pool_type: PoolingType.Avg);
            return this.output.Call(x);
        }

        internal static HybridSequential Conv2d(int channel, int kernel, int padding, int stride, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null)
        {
            var cell = new HybridSequential(prefix: "");
            cell.Add(new Conv2D(channel, kernel_size: (kernel, kernel), strides: (stride, stride), padding: (padding, stride), use_bias: false));
            cell.Add(LayerUtils.NormLayer(norm_layer, norm_kwargs));
            cell.Add(new LeakyReLU(0.1f));
            return cell;
        }

        public static Dictionary<int, (int[], int[])> darknet_spec = new Dictionary<int, (int[], int[])>()
        {
            { 53, (new int[]{1, 2, 8, 8, 4 }, new int[] { 32, 64, 128, 256, 512, 1024}) }
        };

        public static DarknetV3 GetDarknet(string darknet_version, int num_layers, bool pretrained= false, Context ctx= null, string root = "/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            Debug.Assert(darknet_spec.ContainsKey(num_layers), $"Invalid number of layers: {num_layers}");
            var (layers, channels) = darknet_spec[num_layers];
            var net = new DarknetV3(layers, channels, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
            if (pretrained)
            {
                net.LoadParameters(ModelStore.GetModelFile($"darknet{num_layers}", tag: "", root: root), ctx: ctx);
            }
            return net;
        }

        public static DarknetV3 Darknet53(bool pretrained = false, Context ctx = null, string root = "/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            return GetDarknet("v3", 53, pretrained, ctx, root, norm_layer, norm_kwargs);
        }
    }
}
