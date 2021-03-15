using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.RNN.ConvRNNCell
{
    public class _ConvGRUCell : _BaseConvRNNCell
    {
        public string[] GateNames
        {
            get
            {
                return new string[] { "_r", "_z", "_o" };
            }
        }


        public _ConvGRUCell(Shape input_shape, int hidden_channels, int[] i2h_kernel, int[] h2h_kernel, int[] i2h_pad, int[] i2h_dilate,
                            int[] h2h_dilate, string i2h_weight_initializer, string h2h_weight_initializer, string i2h_bias_initializer,
                            string h2h_bias_initializer, int dims, string conv_layout, string activation)
            : base(input_shape, hidden_channels, i2h_kernel, h2h_kernel, i2h_pad, i2h_dilate, h2h_dilate, i2h_weight_initializer,
                  h2h_weight_initializer, i2h_bias_initializer, h2h_bias_initializer, dims, conv_layout, activation)
        {
        }

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "conv_gru";
        }

        public override (NDArrayOrSymbol, NDArrayOrSymbol[]) HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
