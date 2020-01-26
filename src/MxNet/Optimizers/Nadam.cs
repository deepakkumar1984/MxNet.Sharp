using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class Nadam : Optimizer
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

        public float Epsilon { get; set; }

        public float ScheduleDecay { get; set; }

        public Nadam(float learning_rate= 0.001f, float beta1= 0.9f, float beta2= 0.999f, float epsilon= 1e-8f,float schedule_decay = 0.004f):base(learning_rate: learning_rate)
        {
            Beta1 = beta1;
            Beta2 = beta2;
            Epsilon = epsilon;
            ScheduleDecay = schedule_decay;
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
