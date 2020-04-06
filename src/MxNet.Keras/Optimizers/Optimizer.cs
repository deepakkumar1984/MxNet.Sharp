using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public abstract class Optimizer
    {
        public Optimizer(float? clipnorm = null, float? clipvalue = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ClipNorm(KerasSymbol g, float c, KerasSymbol n)
        {
            throw new NotImplementedException();
        }
    }
}
