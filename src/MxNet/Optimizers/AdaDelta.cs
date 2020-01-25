using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class AdaDelta : Optimizer
    {
        private readonly Dictionary<int, NDArray> accumulators;

        private readonly Dictionary<int, NDArray> delta_accumulators;


        /// <summary>
        /// Adadelta decay factor, corresponding to fraction of gradient to keep at each time step.
        /// </summary>
        /// <value>
        /// The rho.
        /// </value>
        public float Rho { get; set; }

        public AdaDelta(float lr = 1f, float rho = 0.95f, float decayRate = 0, float epsilon = 1e-07f) : base(lr, "adadelta")
        {
            DecayRate = decayRate;
            Rho = rho;
            Epsilon = epsilon;

            accumulators = new Dictionary<int, NDArray>();
            delta_accumulators = new Dictionary<int, NDArray>();
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad)
        {
            if (DecayRate > 0)
            {
                LearningRate = LearningRate * (1 / (1 + DecayRate * iteration));
            }

            if (!accumulators.ContainsKey(index))
            {
                accumulators[index] = nd.Zeros(param.Shape);
                delta_accumulators[index] = nd.Zeros(param.Shape);
            }

            accumulators[index] = (Rho * accumulators[index]) + ((1 - Rho) * nd.Square(grad));
            var update = grad * nd.Sqrt(delta_accumulators[index] + Epsilon) / nd.Sqrt(accumulators[index] + Epsilon);
            param = param - (LearningRate * update);

            delta_accumulators[index] = Rho * delta_accumulators[index] + (1 - Rho) * nd.Square(update);
        }
    }
}
