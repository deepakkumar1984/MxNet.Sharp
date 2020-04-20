using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Initializers
{
    public class Constant : Initializer
    {
        private readonly float value;

        public Constant(float value = 0)
        {
            this.value = value;
        }

        public override KerasSymbol Call(Shape shape, DType dtype = null)
        {
            return K.Constant(0, shape: shape, dtype: dtype);
        }

        public override ConfigDict GetConfig()
        {
            return new ConfigDict {
                {
                    "value",
                    this.value
                }
            };
        }
    }
}
