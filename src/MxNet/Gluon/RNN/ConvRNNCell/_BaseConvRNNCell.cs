using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.Gluon.RNN
{
    public class _BaseConvRNNCell : HybridRecurrentCell
    {
        public int NumGates
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int _hidden_channels;
        public int _channel_axis;
        public int _in_channels;
        public Shape _input_shape;
        public Shape _state_shape;
        public string _conv_layout;
        public Activation _activation;
        public int[] _i2h_kernel;
        public int[] _stride;
        public int[] _i2h_pad;
        public int[] _i2h_dilate;
        public int[] _h2h_kernel;
        public int[] _h2h_dilate;
        public int[] _h2h_pad;

        public _BaseConvRNNCell(Shape input_shape, int hidden_channels, int[] i2h_kernel, int[] h2h_kernel,
                 int[] i2h_pad, int[] i2h_dilate, int[] h2h_dilate, string i2h_weight_initializer, string h2h_weight_initializer,
                 string i2h_bias_initializer, string h2h_bias_initializer, int dims, string conv_layout, Activation activation)
        {
            this._hidden_channels = hidden_channels;
            this._input_shape = input_shape;
            this._conv_layout = conv_layout;
            this._activation = activation;
            // Convolution setting
            Debug.Assert((from spec in new List<int[]>() {
                                i2h_kernel,
                                i2h_pad,
                                i2h_dilate,
                                h2h_kernel,
                                h2h_dilate
                            } select spec.Length == dims).All(x => x),
                    $"For {dims}D convolution, the convolution settings can only be either int or list/tuple of length {dims}");

            var strideTemp = new List<int>();
            for(int i = 0; i< dims; i++)
            {
                strideTemp.Add(1);
            }

            this._i2h_kernel = i2h_kernel;
            this._stride = strideTemp.ToArray();
            this._i2h_pad = i2h_pad;
            this._i2h_dilate = i2h_dilate;
            this._h2h_kernel = h2h_kernel;

            Debug.Assert((from k in this._h2h_kernel select k % 2 == 1).All(x => x), 
                            $"Only support odd number, get h2h_kernel= {new Shape(h2h_kernel)}");

            this._h2h_dilate = h2h_dilate;
            var _tup_1 = this.DecideShapes();
            this._channel_axis = _tup_1.Item1;
            this._in_channels = _tup_1.Item2;
            var i2h_param_shape = _tup_1.Item3;
            var h2h_param_shape = _tup_1.Item4;
            this._h2h_pad = _tup_1.Item5;
            this._state_shape = _tup_1.Item6;

            this["i2h_weight"] = new Parameter("i2h_weight", shape: i2h_param_shape, init: i2h_weight_initializer, allow_deferred_init: true);
            this["h2h_weight"] = new Parameter("h2h_weight", shape: h2h_param_shape, init: h2h_weight_initializer, allow_deferred_init: true);
            this["i2h_bias"] = new Parameter("i2h_bias", shape: new Shape(hidden_channels * this.NumGates), init: i2h_bias_initializer, allow_deferred_init: true);
            this["h2h_bias"] = new Parameter("h2h_bias", shape: new Shape(hidden_channels * this.NumGates), init: h2h_bias_initializer, allow_deferred_init: true);
        }

        public override (NDArrayOrSymbol, NDArrayOrSymbol[]) HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        private (int, int, Shape, Shape, int[], Shape) DecideShapes()
        {
            throw new NotImplementedException();
        }

        private NDArrayOrSymbolList[] ConvForward(NDArrayOrSymbol inputs, NDArrayOrSymbolList[] states, NDArrayOrSymbol i2h_weight,
                                                NDArrayOrSymbol h2h_weight, NDArrayOrSymbol i2h_bias, NDArrayOrSymbol h2h_bias, string prefix)
        {
            throw new NotImplementedException();
        }
    }
}
