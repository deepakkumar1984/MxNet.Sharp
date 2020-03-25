/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using MxNet.Initializers;

namespace MxNet.Gluon.NN
{
    public class BatchNorm : HybridBlock
    {
        public BatchNorm(int axis = 1, float momentum = 0.9f, float epsilon = 1e-5f, bool center = true,
            bool scale = true,
            bool use_global_stats = false, string beta_initializer = "zeros", string gamma_initializer = "ones",
            string running_mean_initializer = "zeros", string running_variance_initializer = "ones",
            int in_channels = 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Momentum = momentum;
            Epsilon = epsilon;
            Center = center;
            Scale = scale;
            Use_Global_Stats = use_global_stats;
            In_Channels = in_channels;
            Gamma = Params.Get("gamma", scale ? OpGradReq.Write : OpGradReq.Null, new Shape(in_channels),
                init: Initializer.Get(gamma_initializer), allow_deferred_init: true, differentiable: scale);
            Beta = Params.Get("beta", center ? OpGradReq.Write : OpGradReq.Null, new Shape(in_channels),
                init: Initializer.Get(beta_initializer), allow_deferred_init: true, differentiable: center);
            RunningMean = Params.Get("running_mean", OpGradReq.Write, new Shape(in_channels),
                init: Initializer.Get(running_mean_initializer), allow_deferred_init: true);
            RunningVar = Params.Get("running_var", OpGradReq.Write, new Shape(in_channels),
                init: Initializer.Get(running_variance_initializer), allow_deferred_init: true);
        }

        public int Axis { get; set; }
        public float Momentum { get; }
        public float Epsilon { get; }
        public bool Center { get; }
        public bool Scale { get; }
        public bool Use_Global_Stats { get; }
        public int In_Channels { get; }
        public Parameter Gamma { get; set; }
        public Parameter Beta { get; set; }
        public Parameter RunningMean { get; set; }
        public Parameter RunningVar { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var gamma = args[0];
            var beta = args[1];
            var running_mean = args[2];
            var running_var = args[3];

            if (x.IsNDArray)
                return nd.BatchNorm(x.NdX, gamma.NdX, beta.NdX, running_mean.NdX, running_var.NdX);

            return sym.BatchNorm(x.SymX, gamma.SymX, beta.SymX, running_mean.SymX, running_var.SymX,
                symbol_name: "fwd");
        }
    }
}