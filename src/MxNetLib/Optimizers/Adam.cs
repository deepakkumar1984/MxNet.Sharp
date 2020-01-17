using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Optimizers
{
    public class Adam : Optimizer
    {
        private readonly Dictionary<int, NDArray> ms;
        private readonly Dictionary<int, NDArray> vs;

        /// <summary>
        /// Gets or sets the beta 1 value.
        /// </summary>
        /// <value>
        /// The beta1.
        /// </value>
        public float Beta1 { get; set; }

        /// <summary>
        /// Gets or sets the beta 2 value.
        /// </summary>
        /// <value>
        /// The beta2.
        /// </value>
        public float Beta2 { get; set; }

        public Adam(float lr = 0.01f, float beta_1 = 0.9f, float beta_2 = 0.999f, float decayRate = 0, float epsilon = 1e-7f) : base(lr, "adam")
        {
            ms = new Dictionary<int, NDArray>();
            vs = new Dictionary<int, NDArray>();
            Beta1 = beta_1;
            Beta2 = beta_2;
            DecayRate = decayRate;
            Epsilon = epsilon;
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad)
        {
            if (!ms.ContainsKey(index))
                ms[index] = nd.Zeros(param.Shape);

            if (!vs.ContainsKey(index))
                vs[index] = nd.Zeros(param.Shape);

            nd.AdamUpdate(param, grad, ms[index], vs[index], LearningRate, Beta1, Beta2, Epsilon, DecayRate);
        }
    }
}
