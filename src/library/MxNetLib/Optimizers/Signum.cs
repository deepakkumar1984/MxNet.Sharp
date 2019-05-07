using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Optimizers
{
    public class Signum : BaseOptimizer
    {
        private readonly Dictionary<int, NDArray> moments;

        /// <summary>
        /// Whether to apply Nesterov momentum.
        /// </summary>
        /// <value>
        ///   <c>true</c> if nesterov; otherwise, <c>false</c>.
        /// </value>
        public bool Nesterov { get; set; }

        public Signum(float lr = 0.01f, float momentum = 0, float decayRate = 0, bool nesterov = false) : base(lr, "adam")
        {
            moments = new Dictionary<int, NDArray>();
            DecayRate = decayRate;
            Momentum = momentum;
            Nesterov = nesterov;
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad)
        {
            if (!moments.ContainsKey(index))
                moments[index] = nd.Zeros(param.Shape);

            nd.SignumUpdate(param, grad, moments[index], LearningRate, Momentum, DecayRate, 1 / iteration);
        }
    }
}
