using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.CNN
{
    public class DeformableConvolution : HybridBlock
    {
        public DeformableConvolution(int channels, (int, int)? kernel_size= null, (int, int)? strides= null, (int, int)? padding= null,
                                    (int, int)?dilation= null, int groups= 1, int num_deformable_group= 1, string layout= "NCHW",
                                    bool use_bias= true, int in_channels= 0, string activation= null, string weight_initializer= null,
                                    string bias_initializer= "zeros", string offset_weight_initializer= "zeros",
                                    string offset_bias_initializer= "zeros", bool offset_use_bias= true,
                                    string op_name= "DeformableConvolution", (int, int)? adj= null,
                                    string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
