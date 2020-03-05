using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class LSTMCell : HybridRecurrentCell
    {
        private int _hidden_size;
        private string _activation;
        private string _recurrent_activation;
        private int _input_size;

        public LSTMCell(int hidden_size, string activation = "tanh", string recurrent_activation= "sigmoid", string i2h_weight_initializer = null, string h2h_weight_initializer = null,
                        string i2h_bias_initializer = "zeros", string h2h_bias_initializer = "zeros", int input_size = 0,
                        string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            _hidden_size = hidden_size;
            _activation = activation;
            _input_size = input_size;
            _recurrent_activation = recurrent_activation;
            this["i2h_weight"] = Params.Get("i2h_weight", shape: new Shape(hidden_size, input_size), init: Initializer.Get(i2h_weight_initializer), allow_deferred_init: true);
            this["h2h_weight"] = Params.Get("h2h_weight", shape: new Shape(hidden_size, hidden_size), init: Initializer.Get(h2h_weight_initializer), allow_deferred_init: true);
            this["i2h_bias"] = Params.Get("i2h_bias", shape: new Shape(hidden_size), init: Initializer.Get(i2h_bias_initializer), allow_deferred_init: true);
            this["h2h_bias"] = Params.Get("h2h_bias", shape: new Shape(hidden_size), init: Initializer.Get(h2h_bias_initializer), allow_deferred_init: true);
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            return new StateInfo[] 
            {
                new StateInfo() { Layout = "NC", Shape = new Shape(batch_size, _hidden_size) },
                new StateInfo() { Layout = "NC", Shape = new Shape(batch_size, _hidden_size) }
            };
        }

        public override string Alias()
        {
            return "lstm";
        }

        public override (NDArrayOrSymbol, NDArrayOrSymbol[]) HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var prefix = $"t{_counter}_";
            NDArrayOrSymbol states_0 = args[0];
            NDArrayOrSymbol states_1 = args[1];
            NDArrayOrSymbol i2h_weight = args[2];
            NDArrayOrSymbol h2h_weight = args[3];
            NDArrayOrSymbol i2h_bias = args[4];
            NDArrayOrSymbol h2h_bias = args[5];
            NDArrayOrSymbol next_c = null;
            NDArrayOrSymbol next_h = null;

            if (x.IsNDArray)
            {
                var i2h = nd.FullyConnected(x, weight: i2h_weight, bias: i2h_bias, num_hidden: _hidden_size * 4);
                var h2h = nd.FullyConnected(states_0, weight: h2h_weight, bias: h2h_bias, num_hidden: _hidden_size * 4);
                var gates = nd.ElemwiseAdd(i2h, h2h);
                var slice_gates = nd.Split(gates, 4);
                var in_gate = Activation(slice_gates[0], _recurrent_activation);
                var forget_gate = Activation(slice_gates[1], _recurrent_activation);
                var in_transform = Activation(slice_gates[2], _activation);
                var out_gate = Activation(slice_gates[3], _recurrent_activation);
                next_c = nd.ElemwiseAdd(nd.ElemwiseMul(forget_gate, states_1),
                                nd.ElemwiseMul(in_gate, in_transform));
                next_h = nd.ElemwiseMul(out_gate, Activation(next_c.NdX, _activation));
            }
            else
            {
                var i2h = sym.FullyConnected(x, weight: i2h_weight, bias: i2h_bias, num_hidden: _hidden_size * 4, symbol_name: prefix + "i2h");
                var h2h = sym.FullyConnected(states_0, weight: h2h_weight, bias: h2h_bias, num_hidden: _hidden_size * 4, symbol_name: prefix + "h2h");
                var gates = sym.ElemwiseAdd(i2h, h2h, symbol_name: prefix + "plus0");
                var slice_gates = sym.Split(gates, 4, symbol_name: prefix + "slice");
                var in_gate = Activation(slice_gates[0], _recurrent_activation, name: prefix + "i");
                var forget_gate = Activation(slice_gates[1], _recurrent_activation, name: prefix + "f");
                var in_transform = Activation(slice_gates[2], _activation, name: prefix + "c");
                var out_gate = Activation(slice_gates[3], _recurrent_activation, name: prefix + "o");
                next_c = sym.ElemwiseAdd(sym.ElemwiseMul(forget_gate, states_1, symbol_name: prefix + "mul0"),
                                sym.ElemwiseMul(in_gate, in_transform, symbol_name: prefix + "mul1"), symbol_name: prefix + "state");
                next_h = sym.ElemwiseMul(out_gate, Activation(next_c.SymX, _activation, name: prefix + "i2h"), symbol_name: prefix + "out");
            }

            return (next_h, new NDArrayOrSymbol[] { next_h, next_c });
        }
    }
}
