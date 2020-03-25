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
namespace MxNet.Optimizers
{
    public class RMSProp : Optimizer
    {
        public RMSProp(float learning_rate = 0.001f, float gamma1 = 0.9f, float gamma2 = 0.9f,
            float epsilon = 1e-8f, bool centered = false, float? clip_weights = null) : base(
            learning_rate: learning_rate)
        {
            Gamma1 = gamma1;
            Gamma2 = gamma2;
            Epsilon = epsilon;
            Centered = centered;
            ClipWeights = clip_weights.HasValue ? clip_weights.Value : -1;
        }

        public float Gamma1 { get; }
        public float Gamma2 { get; }
        public float Epsilon { get; }
        public bool Centered { get; }
        public float ClipWeights { get; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict("n", "g", "delta");
            state["n"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            state["g"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            state["delta"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);

            if (!Centered)
                weight = nd.RmspropUpdate(weight, grad, state["n"], lr, Gamma1, Epsilon, wd, RescaleGrad,
                    ClipGradient.HasValue ? ClipGradient.Value : -1, ClipWeights);
            else
                weight = nd.RmspropalexUpdate(weight, grad, state["n"], state["g"], state["delta"], lr, Gamma1, Gamma2,
                    Epsilon, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, ClipWeights);
        }
    }
}