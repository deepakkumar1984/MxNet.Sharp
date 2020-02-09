using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    
    public class AdaDelta : Optimizer
    {
        /// <summary>
        /// Adadelta decay factor, corresponding to fraction of gradient to keep at each time step.
        /// </summary>
        /// <value>
        /// The rho.
        /// </value>
        public float Rho { get; set; }

        public float Epsilon { get; set; }

        public AdaDelta(float rho = 0.95f, float decayRate = 0, float epsilon = 1e-07f)
        {
            Rho = rho;
            Epsilon = epsilon;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            var wd = GetWd(index);
            UpdateCount(new int[] { index });
            grad *= RescaleGrad;
            if(ClipGradient.HasValue)
            {
                grad = nd.Clip(grad, -ClipGradient.Value, ClipGradient.Value);
            }

            var acc_g = state["acc_g"];
            var acc_delta = state["acc_delta"];

            acc_g *= Rho;
            acc_g += (1 - Rho) * grad * grad;
            var current_delta = nd.Sqrt(acc_delta + Epsilon) / nd.Sqrt(acc_g + Epsilon) * grad;
            acc_delta *= Rho;
            acc_delta += (1 - Rho) * current_delta * current_delta;
            weight -= current_delta + wd * weight; 
        }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            return new NDArrayDict()
            {
                { "acc_g", nd.Zeros(weight.Shape, weight.context)},
                { "acc_delta", nd.Zeros(weight.Shape, weight.context)}
            };
        }
    }
}
