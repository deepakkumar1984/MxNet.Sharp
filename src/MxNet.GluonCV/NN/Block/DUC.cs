using MxNet.Gluon;
using MxNet.Gluon.Contrib.NN;
using MxNet.Gluon.NN;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class DUC : HybridBlock
    {
        private BatchNormCudnnOff bn;

        private Conv2D conv;

        private PixelShuffle2D pixel_shuffle;

        private Activation relu;

        public DUC(int planes, int upscale_factor = 2, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            this.conv = new Conv2D(planes, kernel_size: (3, 3), padding: (1, 1), use_bias: false);
            this.bn = new BatchNormCudnnOff(gamma_initializer: "ones", beta_initializer: "zeros");
            this.relu = new Activation(ActivationType.Relu);
            this.pixel_shuffle = new PixelShuffle2D((upscale_factor, upscale_factor));
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = this.conv.Call(x);
            x = this.bn.Call(x);
            x = this.relu.Call(x);
            x = this.pixel_shuffle.Call(x);
            return x;
        }
    }
}
