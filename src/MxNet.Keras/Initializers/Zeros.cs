using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Initializers
{
    public class Zeros : Initializer
    {
        public override KerasSymbol Call(Shape shape, DType dtype = null)
        {
            return K.Constant(0, shape: shape, dtype: dtype);
        }
    }
}
