using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class RMSProp : Optimizer
    {
        public float Gamma1 { get; }
        public float Gamma2 { get; }
        public float Epsilon { get; }
        public bool Centered { get; }
        public float ClipWeights { get; }

        public RMSProp(float learning_rate = 0.001f, float gamma1 = 0.9f, float gamma2 = 0.9f,
                    float epsilon = 1e-8f, bool centered = false, float? clip_weights = null) : base(learning_rate: learning_rate)
        {
            Gamma1 = gamma1;
            Gamma2 = gamma2;
            Epsilon = epsilon;
            Centered = centered;
            ClipWeights = clip_weights.HasValue ? clip_weights.Value : -1;
        }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            NDArrayDict state = new NDArrayDict("n", "g", "delta");
            state["n"] = nd.Zeros(weight.Shape, weight.context, weight.DataType).ToSType(weight.SType);
            state["g"] = nd.Zeros(weight.Shape, weight.context, weight.DataType).ToSType(weight.SType);
            state["delta"] = nd.Zeros(weight.Shape, weight.context, weight.DataType).ToSType(weight.SType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);

            if (!Centered)
                weight = nd.RmspropUpdate(weight, grad, state["n"], lr, Gamma1, Epsilon, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, ClipWeights);
            else
                weight = nd.RmspropalexUpdate(weight, grad, state["n"], state["g"], state["delta"], lr, Gamma1, Gamma2, Epsilon, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, ClipWeights);
        }
    }
}
