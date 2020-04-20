using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Initializers
{
    public class RandomUniform : Initializer
    {
        private float maxval;

        private float minval;

        private int? seed;

        public RandomUniform(float minval= -0.05f, float maxval= 0.05f, int? seed= null)
        {
            this.minval = minval;
            this.maxval = maxval;
            this.seed = seed;
        }

        public override KerasSymbol Call(Shape shape, DType dtype = null)
        {
            return K.RandomUniform(shape, this.minval, this.maxval, dtype: dtype, seed: this.seed);
        }

        public override ConfigDict GetConfig()
        {
            return new ConfigDict {
                {
                    "minval",
                    this.minval},
                {
                    "maxval",
                    this.maxval},
                {
                    "seed",
                    this.seed
                }
            };
        }
    }
}
