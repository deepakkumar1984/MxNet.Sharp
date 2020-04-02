using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class FCPredictor : HybridBlock
    {
        private Dense predictor;

        public FCPredictor(int num_output, ActivationType activation= ActivationType.Relu, bool use_bias= true, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            this.predictor = new Dense(num_output, activation: activation, use_bias: use_bias);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return this.predictor.Call(x);
        }
    }
}
