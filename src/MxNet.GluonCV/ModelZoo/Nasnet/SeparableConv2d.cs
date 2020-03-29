using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Nasnet
{
    public class SeparableConv2d : HybridBlock
    {
        public SeparableConv2d(int in_channels, int channels, (int, int) dw_kernel, (int, int) dw_stride, (int, int) dw_padding, bool use_bias= false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
