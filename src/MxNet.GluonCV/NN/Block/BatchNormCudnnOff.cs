using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class BatchNormCudnnOff : BatchNorm
    {
        public BatchNormCudnnOff(int axis = 1, float momentum = 0.9F, float epsilon = 1E-05F, bool center = true, bool scale = true, bool use_global_stats = false, string beta_initializer = "zeros", string gamma_initializer = "ones", string running_mean_initializer = "zeros", string running_variance_initializer = "ones", int in_channels = 0, string prefix = "", ParameterDict @params = null) : base(axis, momentum, epsilon, center, scale, use_global_stats, beta_initializer, gamma_initializer, running_mean_initializer, running_variance_initializer, in_channels, prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var gamma = args[0];
            var beta = args[1];
            var running_mean = args[2];
            var running_var = args[3];

            if (x.IsNDArray)
                return nd.BatchNorm(x.NdX, gamma.NdX, beta.NdX, running_mean.NdX, running_var.NdX, eps: Epsilon, momentum: Momentum, axis: Axis, cudnn_off: true);

            return sym.BatchNorm(x.SymX, gamma.SymX, beta.SymX, running_mean.SymX, running_var.SymX, eps: Epsilon, momentum: Momentum, axis: Axis, cudnn_off: true,
                symbol_name: "fwd");
        }
    }
}
