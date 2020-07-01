using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class SpatialDropout1D : Dropout
    {
        public InputSpec input_spec;

        public SpatialDropout1D(float rate) : base(rate)
        {
            this.input_spec = new InputSpec(ndim: 3);
        }

        internal override Shape GetNoiseShape(KerasSymbol inputs)
        {
            var input_shape = K.Shape(inputs);
            var noise_shape = (input_shape[0], 1, input_shape[2]);
            return noise_shape;
        }
    }
}
