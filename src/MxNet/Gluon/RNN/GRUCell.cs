using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class GRUCell : HybridRecurrentCell
    {
        private int _hidden_size;
        private int _input_size;


        public GRUCell(int hidden_size, string i2h_weight_initializer= null, string h2h_weight_initializer= null,
                        string i2h_bias_initializer= "zeros", string h2h_bias_initializer= "zeros", int input_size= 0,
                        string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            _hidden_size = hidden_size;
            _input_size = input_size;
            this["i2h_weight"] = Params.Get("i2h_weight", shape: new Shape(hidden_size, input_size), init: Initializer.Get(i2h_weight_initializer), allow_deferred_init: true);
            this["h2h_weight"] = Params.Get("h2h_weight", shape: new Shape(hidden_size, hidden_size), init: Initializer.Get(h2h_weight_initializer), allow_deferred_init: true);
            this["i2h_bias"] = Params.Get("i2h_bias", shape: new Shape(hidden_size), init: Initializer.Get(i2h_bias_initializer), allow_deferred_init: true);
            this["h2h_bias"] = Params.Get("h2h_bias", shape: new Shape(hidden_size), init: Initializer.Get(h2h_bias_initializer), allow_deferred_init: true);
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            return new StateInfo[] { new StateInfo() { Layout = "NC", Shape = new Shape(batch_size, _hidden_size) } };
        }

        public override string Alias()
        {
            return "gru";
        }

        public override (NDArrayOrSymbol, NDArrayOrSymbol[]) HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var prefix = $"t{_counter}_";
            NDArrayOrSymbol prev_state_h = args[0];
            NDArrayOrSymbol i2h_weight = args[1];
            NDArrayOrSymbol h2h_weight = args[2];
            NDArrayOrSymbol i2h_bias = args[3];
            NDArrayOrSymbol h2h_bias = args[4];
            NDArrayOrSymbol next_h = null;

            if (x.IsNDArray)
            {
                var i2h = nd.FullyConnected(x, weight: i2h_weight, bias: i2h_bias, num_hidden: _hidden_size * 3);
                var h2h = nd.FullyConnected(prev_state_h, weight: h2h_weight, bias: h2h_bias, num_hidden: _hidden_size * 3);
                var i2hsplit = nd.Split(i2h, 3);
                var i2h_r = i2hsplit[0];
                var i2h_z = i2hsplit[1];
                i2h = i2hsplit[2];

                var h2hsplit = nd.Split(h2h, 3);
                var h2h_r = h2hsplit[0];
                var h2h_z = h2hsplit[1];
                h2h = h2hsplit[2];

                var reset_gate = Activation(nd.ElemwiseAdd(i2h_r, h2h_r), "sigmoid");
                var update_gate = Activation(nd.ElemwiseAdd(i2h_z, h2h_z), "sigmoid");
                var next_h_tmp = Activation(nd.ElemwiseAdd(i2h,
                                               nd.ElemwiseMul(reset_gate, h2h)),
                                            "tanh");
                var ones = nd.OnesLike(update_gate);
                next_h = nd.ElemwiseAdd(nd.ElemwiseMul(nd.ElemwiseSub(ones, update_gate),
                                            next_h_tmp),
                                        nd.ElemwiseMul(update_gate, prev_state_h));
            }
            else
            {
                var i2h = sym.FullyConnected(x, weight: i2h_weight, bias: i2h_bias, num_hidden: _hidden_size * 3, symbol_name: prefix + "i2h");
                var h2h = sym.FullyConnected(prev_state_h, weight: h2h_weight, bias: h2h_bias, num_hidden: _hidden_size * 3, symbol_name: prefix + "h2h");
                var i2hsplit = sym.Split(i2h, 3, symbol_name: prefix + "i2h_slice");
                var i2h_r = i2hsplit[0];
                var i2h_z = i2hsplit[1];
                i2h = i2hsplit[2];

                var h2hsplit = sym.Split(h2h, 3, symbol_name: prefix + "h2h_slice");
                var h2h_r = h2hsplit[0];
                var h2h_z = h2hsplit[1];
                h2h = h2hsplit[2];

                var reset_gate = Activation(sym.ElemwiseAdd(i2h_r, h2h_r, symbol_name: prefix + "plus0"), "sigmoid", name: prefix + "r_act");
                var update_gate = Activation(sym.ElemwiseAdd(i2h_z, h2h_z, symbol_name: prefix + "plus1"), "sigmoid", name: prefix + "z_act");
                var next_h_tmp = Activation(sym.ElemwiseAdd(i2h, sym.ElemwiseMul(reset_gate, h2h, symbol_name: prefix + "mul0"), symbol_name: prefix + "plus2"),
                                            "tanh", name: prefix + "h_act");
                var ones = sym.OnesLike(update_gate, symbol_name: prefix + "ones_like0");
                next_h = sym.ElemwiseAdd(sym.ElemwiseMul(sym.ElemwiseSub(ones, update_gate, symbol_name: prefix + "minus0"),
                                            next_h_tmp, symbol_name: prefix + "mul1"),
                                        sym.ElemwiseMul(update_gate, prev_state_h, symbol_name: prefix + "mul2"), symbol_name: prefix + "out");
            }

            return (next_h, new NDArrayOrSymbol[] { next_h });
        }
    }
}
