using System;
using System.Collections.Generic;
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

        public _BaseConvRNNCell(Shape input_shape, int hidden_channels, int[] i2h_kernel, int[] h2h_kernel,
                 int[] i2h_pad, int[] i2h_dilate, int[] h2h_dilate, string i2h_weight_initializer, string h2h_weight_initializer,
                 string i2h_bias_initializer, string h2h_bias_initializer, int dims, string conv_layout, string activation)
        {
            throw new NotImplementedException();
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
