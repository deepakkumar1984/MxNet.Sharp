using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class Adadelta : MxNet.Optimizers.AdaDelta, IOptimizer
    {
        public Adadelta(float lr = 1, float rho = 0.95F, float epsilon = 1E-08F, float decay = 0, float? clipnorm = null) : base(rho, decay, epsilon)
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
