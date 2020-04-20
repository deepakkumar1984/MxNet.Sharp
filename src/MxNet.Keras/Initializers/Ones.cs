using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Initializers
{
    public class Ones : Initializer
    {
        public override KerasSymbol Call(Shape shape, DType dtype = null)
        {
            return K.Constant(1, shape: shape, dtype: dtype);
        }
    }
}
