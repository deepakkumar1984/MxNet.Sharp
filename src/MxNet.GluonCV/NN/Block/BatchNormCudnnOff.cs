using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class BatchNormCudnnOff : BatchNorm
    {
        public BatchNormCudnnOff(int axis = 1, float momentum = 0.9F, float epsilon = 1E-05F, bool center = true, bool scale = true, bool use_global_stats = false, string beta_initializer = "zeros", string gamma_initializer = "ones", string running_mean_initializer = "zeros", string running_variance_initializer = "ones", int in_channels = 0, string prefix = null, ParameterDict @params = null) : base(axis, momentum, epsilon, center, scale, use_global_stats, beta_initializer, gamma_initializer, running_mean_initializer, running_variance_initializer, in_channels, prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
