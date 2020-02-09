using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class RMSProp : Optimizer
    {
        /// <summary>
        /// RMSProp decay factor, corresponding to fraction of gradient to keep at each time step.
        /// </summary>
        /// <value>
        /// The rho.
        /// </value>
        public float Rho { get; set; }

        public RMSProp(float learning_rate= 0.001f, float gamma1= 0.9f, float gamma2= 0.9f,
                    float epsilon= 1e-8f, bool centered= false, float? clip_weights= null) : base(learning_rate: learning_rate)
        {
            throw new NotImplementedException();
        }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            throw new NotImplementedException();
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            throw new NotImplementedException();
        }
    }
}
