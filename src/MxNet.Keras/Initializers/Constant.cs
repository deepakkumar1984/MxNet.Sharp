using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class Constant : Initializer
    {
        public Constant(float value = 0)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol Call(Shape shap, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
