using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Optimizers
{
    public class Adamax : Optimizer
    {
        private readonly Dictionary<int, NDArray> ms;
        private readonly Dictionary<int, NDArray> us;

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

        public Adamax(float lr = 0.002f, float beta_1 = 0.9f, float beta_2 = 0.999f, float decayRate = 0, float epsilon = 1e-7f) : base(lr, "adamax")
        {
            ms = new Dictionary<int, NDArray>();
            us = new Dictionary<int, NDArray>();
            Beta1 = beta_1;
            Beta2 = beta_2;
            DecayRate = decayRate;
            Epsilon = epsilon;
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad)
        {
            if (DecayRate > 0)
            {
                LearningRate = LearningRate * (1 / (1 + DecayRate * iteration));
            }

            if (!ms.ContainsKey(index))
                ms[index] = nd.Zeros(param.Shape);

            if (!us.ContainsKey(index))
                us[index] = nd.Zeros(param.Shape);

            var m_t = (Beta1 * ms[index]) + (1 - Beta1) * grad;
            var u_t = nd.Maximum((Beta2 * us[index]), nd.Abs(grad));
            param = param - (LearningRate * m_t / (u_t + Epsilon));

            ms[index] = m_t;
            us[index] = u_t;
        }
    }
}
