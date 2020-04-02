using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MxNet.Initializers;

namespace MxNet.GluonCV.NN
{
    public class FeatureExpander : SymbolBlock
    {
        public FeatureExpander(HybridBlock network, string[] outputs, int[] num_filters, bool use_1x1_transition= true,
                            bool use_bn= true, float reduce_ratio= 1, int min_depth= 128, bool global_pool= false,
                            bool pretrained= false, Context ctx= null, string[] inputs= null, ParameterDict @params = null) : base(null, null, @params)
        {
            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            // append more layers
            var y = p_o.Last();
            var weight_init = new Xavier(rnd_type: "gaussian", factor_type: "out", magnitude: 2);
            foreach (var _tup_2 in num_filters.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
            {
                var i = _tup_2.Item1;
                var f = _tup_2.Item2;
                if (use_1x1_transition)
                {
                    var num_trans = Math.Max(min_depth, Convert.ToInt32(Math.Round(f * reduce_ratio)));
                    
                    y = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: num_trans, kernel: new Shape(1, 1), no_bias: use_bn, symbol_name: $"expand_trans_conv{i}");

                    if (use_bn)
                    {
                        y = sym.BatchNorm(y, null, null, null, null, symbol_name: $"expand_trans_bn{i}");
                    }

                    y = sym.Activation(y, act_type: ActivationType.Relu, symbol_name: $"expand_trans_relu{i}");
                }

                y = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: f, kernel: new Shape(3, 3), pad: new Shape(1, 1), stride: new Shape(2, 2), no_bias: use_bn, symbol_name: $"expand_conv{i}");
                if (use_bn)
                {
                    y = sym.BatchNorm(y, null, null, null, null, symbol_name: $"expand_bn{i}");
                }

                y = sym.Activation(y, act_type: ActivationType.Relu, symbol_name: $"expand_reu{i}");
                p_o.Add(y);
            }
            if (global_pool)
            {
                p_o.Add(sym.Pooling(y, pool_type: PoolingType.Avg, global_pool: true, kernel: new Shape(1, 1)));
            }

            base.Construct(p_o, p_i, p_p);
        }

        public FeatureExpander(Symbol network, string[] outputs, int[] num_filters, bool use_1x1_transition = true,
                            bool use_bn = true, float reduce_ratio = 1, int min_depth = 128, bool global_pool = false,
                            bool pretrained = false, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            // append more layers
            var y = p_o.Last();
            var weight_init = new Xavier(rnd_type: "gaussian", factor_type: "out", magnitude: 2);
            foreach (var _tup_2 in num_filters.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
            {
                var i = _tup_2.Item1;
                var f = _tup_2.Item2;
                if (use_1x1_transition)
                {
                    var num_trans = Math.Max(min_depth, Convert.ToInt32(Math.Round(f * reduce_ratio)));

                    y = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: num_trans, kernel: new Shape(1, 1), no_bias: use_bn, symbol_name: $"expand_trans_conv{i}");

                    if (use_bn)
                    {
                        y = sym.BatchNorm(y, null, null, null, null, symbol_name: $"expand_trans_bn{i}");
                    }

                    y = sym.Activation(y, act_type: ActivationType.Relu, symbol_name: $"expand_trans_relu{i}");
                }

                y = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: f, kernel: new Shape(3, 3), pad: new Shape(1, 1), stride: new Shape(2, 2), no_bias: use_bn, symbol_name: $"expand_conv{i}");
                if (use_bn)
                {
                    y = sym.BatchNorm(y, null, null, null, null, symbol_name: $"expand_bn{i}");
                }

                y = sym.Activation(y, act_type: ActivationType.Relu, symbol_name: $"expand_reu{i}");
                p_o.Add(y);
            }
            if (global_pool)
            {
                p_o.Add(sym.Pooling(y, pool_type: PoolingType.Avg, global_pool: true, kernel: new Shape(1, 1)));
            }

            base.Construct(p_o, p_i, p_p);
        }

        public FeatureExpander(string network, string[] outputs, int[] num_filters, bool use_1x1_transition = true,
                            bool use_bn = true, float reduce_ratio = 1, int min_depth = 128, bool global_pool = false,
                            bool pretrained = false, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            // append more layers
            var y = p_o.Last();
            var weight_init = new Xavier(rnd_type: "gaussian", factor_type: "out", magnitude: 2);
            foreach (var _tup_2 in num_filters.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
            {
                var i = _tup_2.Item1;
                var f = _tup_2.Item2;
                if (use_1x1_transition)
                {
                    var num_trans = Math.Max(min_depth, Convert.ToInt32(Math.Round(f * reduce_ratio)));

                    y = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: num_trans, kernel: new Shape(1, 1), no_bias: use_bn, symbol_name: $"expand_trans_conv{i}");

                    if (use_bn)
                    {
                        y = sym.BatchNorm(y, null, null, null, null, symbol_name: $"expand_trans_bn{i}");
                    }

                    y = sym.Activation(y, act_type: ActivationType.Relu, symbol_name: $"expand_trans_relu{i}");
                }

                y = sym.Convolution(y, weight_init.InitWeight("weight"), null, num_filter: f, kernel: new Shape(3, 3), pad: new Shape(1, 1), stride: new Shape(2, 2), no_bias: use_bn, symbol_name: $"expand_conv{i}");
                if (use_bn)
                {
                    y = sym.BatchNorm(y, null, null, null, null, symbol_name: $"expand_bn{i}");
                }

                y = sym.Activation(y, act_type: ActivationType.Relu, symbol_name: $"expand_reu{i}");
                p_o.Add(y);
            }
            if (global_pool)
            {
                p_o.Add(sym.Pooling(y, pool_type: PoolingType.Avg, global_pool: true, kernel: new Shape(1, 1)));
            }

            base.Construct(p_o, p_i, p_p);
        }
    }
}
