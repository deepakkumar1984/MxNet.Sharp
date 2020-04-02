using MxNet.Gluon;
using MxNet.Gluon.NN;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class ConvPredictor : HybridBlock
    {
        private Conv2D predictor;

        public ConvPredictor(int num_channel, (int, int) kernel, (int, int)? pad= null, (int, int)? stride= null,
                 ActivationType activation= ActivationType.Relu, bool use_bias= true, int in_channels= 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            this.predictor = new Conv2D(num_channel, kernel, strides: stride, padding: pad, activation: activation, use_bias: use_bias, in_channels: in_channels, weight_initializer: new Xavier(magnitude: 2), bias_initializer: "zeros");
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return this.predictor.Call(x);
        }
    }
}
