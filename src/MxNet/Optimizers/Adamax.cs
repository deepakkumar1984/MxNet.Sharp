using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class Adamax : Optimizer
    {

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

        public Adamax(float learning_rate = 0.00f, float beta1 = 0.9f, float beta2 = 0.999f) : base(learning_rate: learning_rate)
        {
            Beta1 = beta1;
            Beta2 = beta2;
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad, object state)
        {
            throw new NotImplementedException();
        }

        public override object CreateState(int index, NDArray weight)
        {
            throw new NotImplementedException();
        }
    }
}
