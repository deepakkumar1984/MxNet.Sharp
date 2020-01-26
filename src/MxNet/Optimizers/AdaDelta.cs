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
