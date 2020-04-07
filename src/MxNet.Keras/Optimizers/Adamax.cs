using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class Adamax : MxNet.Optimizers.Adamax, IOptimizer
    {
        public Adamax(float lr = 0, float beta1 = 0.9F, float beta2 = 0.999F, float decay = 0, float? clipnorm = null) : base(lr, beta1, beta2)
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
