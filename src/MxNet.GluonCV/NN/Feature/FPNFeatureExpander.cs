using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MxNet.Initializers;
using MxNet.Gluon.Contrib.NN;

namespace MxNet.GluonCV.NN
{
    public class FPNFeatureExpander : SymbolBlock
    {
        public FPNFeatureExpander(HybridBlock network, string[] outputs, int[] num_filters, bool use_1x1 = true, bool use_upsample = true,
                            bool use_elewadd = true, bool use_p6 = false, bool p6_conv = true, bool no_bias = true,
                            bool pretrained = false, string norm_layer = null, FuncArgs norm_kwargs = null, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            Construct(p_o, p_i, p_p, num_filters, use_1x1, use_upsample, use_elewadd, use_p6, p6_conv, no_bias, pretrained, norm_layer, norm_kwargs, ctx);
        }

        public FPNFeatureExpander(SymbolBlock network, string[] outputs, int[] num_filters, bool use_1x1 = true, bool use_upsample = true,
                            bool use_elewadd = true, bool use_p6 = false, bool p6_conv = true, bool no_bias = true,
                            bool pretrained = false, string norm_layer = null, FuncArgs norm_kwargs = null, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            Construct(p_o, p_i, p_p, num_filters, use_1x1, use_upsample, use_elewadd, use_p6, p6_conv, no_bias, pretrained, norm_layer, norm_kwargs, ctx);
        }

        public FPNFeatureExpander(string network, string[] outputs, int[] num_filters, bool use_1x1 = true, bool use_upsample = true,
                            bool use_elewadd = true, bool use_p6 = false, bool p6_conv = true, bool no_bias = true,
                            bool pretrained = false, string norm_layer = null, FuncArgs norm_kwargs = null, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            Construct(p_o, p_i, p_p, num_filters, use_1x1, use_upsample, use_elewadd, use_p6, p6_conv, no_bias, pretrained, norm_layer, norm_kwargs, ctx);
        }

        private void Construct(SymbolList outputs, SymbolList inputs, ParameterDict @params, int[] num_filters, bool use_1x1 = true, bool use_upsample = true,
                            bool use_elewadd = true, bool use_p6 = false, bool p6_conv = true, bool no_bias = true,
                            bool pretrained = false, string norm_layer = null, FuncArgs norm_kwargs = null, Context ctx = null)
        {
            Symbol y_p6 = null;
           
            // e.g. For ResNet50, the feature is :
            // outputs = ['stage1_activation2', 'stage2_activation3',
            //            'stage3_activation5', 'stage4_activation2']
            // with regard to [conv2, conv3, conv4, conv5] -> [C2, C3, C4, C5]
            // append more layers with reversed order : [P5, P4, P3, P2]
            var y = outputs.Last();
            var base_features = outputs.Take(outputs.Length - 1).ToArray();
            var num_stages = num_filters.Length + 1;
            var weight_init = new Xavier(rnd_type: "uniform", factor_type: "in", magnitude: 1);
            var tmp_outputs = new List<Symbol>();
            // num_filter is 256 in ori paper
            for (int i = 0; i < base_features.Length; i++)
            {
                var bf = base_features[i];
                var f = num_filters[i];
                if (i == 0)
                {
                    if (use_1x1)
                    {
                        y = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: f, kernel: new Shape(1, 1), pad: new Shape(0, 0), stride: new Shape(1, 1), no_bias: no_bias, symbol_name: $"P{num_stages - i}_conv_lat");

                        if (norm_layer != null)
                        {
                            if (norm_layer == "SyncBatchNorm")
                            {
                                norm_kwargs["key"] = $"P{num_stages - i}_lat_bn";
                                norm_kwargs["name"] = $"P{num_stages - i}_lat_bn";
                            }

                            var bn = LayerUtils.NormLayer(norm_layer, norm_kwargs);

                            y = bn.Call(y);
                        }
                    }
                    if (use_p6 && p6_conv)
                    {
                        // method 2 : use conv (Deformable use this)
                        y_p6 = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: f, kernel: new Shape(3, 3), pad: new Shape(1, 1), stride: new Shape(2, 2), no_bias: no_bias, symbol_name: $"P{num_stages + 1}_conv1");
                        if (norm_layer != null)
                        {
                            if (norm_layer == "SyncBatchNorm")
                            {
                                norm_kwargs["key"] = $"P{num_stages - i}_pre_bn";
                                norm_kwargs["name"] = $"P{num_stages - i}_pre_bn";
                            }

                            var bn = LayerUtils.NormLayer(norm_layer, norm_kwargs);
                            y_p6 = bn.Call(y_p6);
                        }
                    }
                }
                else
                {
                    if (use_1x1)
                    {
                        bf = sym.Convolution(bf, weight_init.InitWeight("weight"), null, num_filter: f, kernel: new Shape(1, 1), pad: new Shape(0, 0), stride: new Shape(1, 1), no_bias: no_bias, symbol_name: $"P{num_stages - i}_conv_lat");

                        if (norm_layer != null)
                        {
                            if (norm_layer == "SyncBatchNorm")
                            {
                                norm_kwargs["key"] = $"P{num_stages - i}_conv1_bn";
                                norm_kwargs["name"] = $"P{num_stages - i}_conv1_bn";
                            }

                            var bn = LayerUtils.NormLayer(norm_layer, norm_kwargs);
                            bf = bn.Call(bf);
                        }
                    }
                    if (use_upsample)
                    {
                        y = sym.UpSampling(y, scale: 2, num_args: 1, sample_type: UpsamplingSampleType.Nearest, symbol_name: $"P{num_stages - i}_upsp");
                    }

                    if (use_elewadd)
                    {
                        // make two symbol alignment
                        // method 1 : mx.sym.Crop
                        // y = mx.sym.Crop(*[y, bf], name="P{}_clip".format(num_stages-i))
                        // method 2 : mx.sym.slice_like
                        y = sym.SliceLike(y, bf, axes: new Shape(2, 3), symbol_name: $"P{num_stages - i}_clip");
                        y = sym.ElemwiseAdd(bf, y, symbol_name: $"P{num_stages - i}_sum");
                    }
                }
                // Reduce the aliasing effect of upsampling described in ori paper
                var @out = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: f, kernel: new Shape(3, 3), pad: new Shape(1, 1), stride: new Shape(1, 1), no_bias: no_bias, symbol_name: $"P{num_stages - i}_conv1");
                if (i == 0 && use_p6 && !p6_conv)
                {
                    // method 2 : use max pool (Detectron use this)
                    y_p6 = sym.Pooling(@out, pool_type: PoolingType.Max, kernel: new Shape(1, 1), pad: new Shape(0, 0), stride: new Shape(2, 2), symbol_name: $"P{num_stages + 1}_pre");
                }
                if (norm_layer != null)
                {
                    if (norm_layer == "SyncBatchNorm")
                    {
                        norm_kwargs["key"] = $"P{num_stages - i}_bn";
                        norm_kwargs["name"] = $"P{num_stages - i}_bn";
                    }

                    var bn = LayerUtils.NormLayer(norm_layer, norm_kwargs);
                    @out = bn.Call(@out);
                }

                tmp_outputs.Add(@out);
            }
           
            if (use_p6)
            {
                outputs = tmp_outputs.Take(tmp_outputs.Count - 1).ToList();
                outputs.Add(y_p6);
            }
            else
            {
                outputs = tmp_outputs.Take(tmp_outputs.Count - 1).ToList();
            }

            base.Construct(outputs, inputs, @params);
        }
    }
}
