using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class SpatialDropout2D : Dropout
    {
        public SpatialDropout2D(float rate, string data_format = "") : base(rate)
        {
            throw new NotImplementedException();
        }

        internal override Shape GetNoiseShape(KerasSymbol inputs)
        {
            throw new NotImplementedException();
        }
    }
}
