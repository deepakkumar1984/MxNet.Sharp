using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Optimizers
{
    public class RMSProp : BaseOptimizer
    {
        private readonly Dictionary<int, NDArray> accumulators;

        /// <summary>
        /// RMSProp decay factor, corresponding to fraction of gradient to keep at each time step.
        /// </summary>
        /// <value>
        /// The rho.
        /// </value>
        public float Rho { get; set; }

        public RMSProp(float lr = 0.001f, float rho = 0.9f, float decayRate = 0, float epsilon = 1e-07f) : base(lr, "adam")
        {
            accumulators = new Dictionary<int, NDArray>();
            DecayRate = decayRate;
            Rho = rho;
            Epsilon = epsilon;
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad)
        {
            if (!accumulators.ContainsKey(index))
                accumulators[index] = nd.Zeros(param.Shape);

            nd.RmspropUpdate(param, grad, accumulators[index], LearningRate, Rho, Epsilon, DecayRate, 1 / iteration);
        }
    }
}
