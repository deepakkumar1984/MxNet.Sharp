using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class _Conv : HybridBlock
    {
        public _Conv(int channels, int[] kernel_size, int[] strides, int[] padding, int[] dilation,
                    int groups, string layout, int in_channels= 0, string activation= null, bool use_bias= true,
                    Initializer weight_initializer = null, string bias_initializer= "zeros", int[] adj = null,
                    string op_name= "Convolution", string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        private Shape[] _infer_weight_shape(string op_name, Shape data_shape)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "conv";
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
