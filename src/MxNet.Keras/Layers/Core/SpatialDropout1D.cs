using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class SpatialDropout1D : Dropout
    {
        public SpatialDropout1D(float rate) : base(rate)
        {
            throw new NotImplementedException();
        }

        internal override Shape GetNoiseShape(KerasSymbol inputs)
        {
            throw new NotImplementedException();
        }
    }
}
