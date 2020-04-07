using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class Nadam : MxNet.Optimizers.Nadam, IOptimizer
    {
        public Nadam(float lr = 0.001F, float beta1 = 0.9F, float beta2 = 0.999F, float epsilon = 1E-08F, float decay = 0, float? clipnorm = null, float schedule_decay = 0.004F) : base(lr, beta1, beta2, epsilon, schedule_decay)
        {
            throw new NotImplementedException();
        }

        public KerasSymbol Lr { get; set; }
        public KerasSymbol Decay { get; set; }

        public ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
