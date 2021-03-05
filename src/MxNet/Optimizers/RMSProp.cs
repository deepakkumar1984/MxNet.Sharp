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
        public RMSProp(float learning_rate = 0.001f, float rho = 0.9f, float momentum = 0.9f,
            float epsilon = 1e-8f, bool centered = false, float? clip_weights = null, bool use_fused_step = true) : base(
            learning_rate: learning_rate, use_fused_step: use_fused_step)
        {
            Rho = rho;
            Momentum = momentum;
            Epsilon = epsilon;
            Centered = centered;
            ClipWeights = clip_weights.HasValue ? clip_weights.Value : -1;
        }

        public float Rho { get; }
        public float Momentum { get; }
        public float Epsilon { get; }
        public bool Centered { get; }
        public float ClipWeights { get; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict("n", "g", "delta");
            state["mean"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            state["var"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            state["mom"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            return state;
        }

        public override void Step(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            this.UpdateCount(index);
            var lr = this.GetLr(index);
            var wd = this.GetWd(index);
            // preprocess grad
            grad *= this.RescaleGrad;
            if (this.ClipGradient != null)
            {
                grad = nd.Clip(grad, -this.ClipGradient.Value, this.ClipGradient.Value);
            }

            grad += wd * weight;
            if (!this.Centered)
            {
                // update var
                state["var"] *= this.Rho;
                state["var"] += (1 - this.Rho) * nd.Square(grad);
                // update weight
                var d = grad / (nd.Sqrt(state["var"]) + this.Epsilon);
                weight -= lr * d;
            }
            else
            {
                // update mean, var, mom
                var _tup_2 = state;
                state["mean"] *= this.Rho;
                state["mean"] += (1 - this.Rho) * grad;
                state["var"] *= this.Rho;
                state["var"] += (1 - this.Rho) * nd.Square(grad);
                state["mom"] *= this.Momentum;
                state["mom"] -= lr * grad / nd.Sqrt(state["var"] - nd.Square(state["mean"]) + this.Epsilon);
                // update weight
                weight[":"] += state["mom"];
            }

            if (this.ClipWeights != 0)
            {
                weight = nd.Clip(weight, -this.ClipWeights, this.ClipWeights);
            }
        }

        public override void FusedStep(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);

            if (!Centered)
                weight = nd.RmspropUpdate(weight, grad, state["var"], lr, Rho, Epsilon, wd, RescaleGrad,
                    ClipGradient.HasValue ? ClipGradient.Value : -1, ClipWeights);
            else
                weight = nd.RmspropalexUpdate(weight, grad, state["mean"], state["var"], state["mom"], lr, Rho, Momentum,
                    Epsilon, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, ClipWeights);
        }
    }
}