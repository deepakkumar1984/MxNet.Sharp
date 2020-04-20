using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Initializers
{
    public class TruncatedNormal : Initializer
    {
        private float mean;

        private int? seed;

        private float stddev;

        public TruncatedNormal(float mean = 0, float stddev = 0.05f, int? seed = null)
        {
            this.mean = mean;
            this.stddev = stddev;
            this.seed = seed;
        }

        public override KerasSymbol Call(Shape shape, DType dtype = null)
        {
            return K.TruncatedNormal(shape, this.mean, this.stddev, dtype: dtype, seed: this.seed);
        }

        public override ConfigDict GetConfig()
        {
            return new ConfigDict {
                {
                    "mean",
                    this.mean},
                {
                    "stddev",
                    this.stddev},
                {
                    "seed",
                    this.seed
                }
            };
        }
    }
}
