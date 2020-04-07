using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class Adagrad : MxNet.Optimizers.AdaGrad, IOptimizer
    {
        public Adagrad(float lr = 0.01f, float eps = 1e-08F, float? clipnorm = null) : base(lr, epsilon: eps)
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
