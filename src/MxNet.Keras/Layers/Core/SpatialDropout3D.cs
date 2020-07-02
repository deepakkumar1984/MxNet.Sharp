using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class SpatialDropout3D : Dropout
    {
        public string data_format;

        public SpatialDropout3D(float rate, string data_format = "") : base(rate)
        {
            this.data_format = K.NormalizeDataFormat(data_format);
            this.input_spec = new InputSpec[] { new InputSpec(ndim: 5) };
        }

        internal override Shape GetNoiseShape(KerasSymbol inputs)
        {
            Shape noise_shape = null;
            var input_shape = K.Shape(inputs);
            if (this.data_format == "channels_first")
            {
                noise_shape = new Shape(input_shape[0], input_shape[1], 1, 1, 1);
            }
            else
            {
                noise_shape = new Shape(input_shape[0], 1, 1, 1, input_shape[4]);
            }

            return noise_shape;
        }
    }
}
