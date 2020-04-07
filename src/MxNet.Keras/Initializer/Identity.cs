using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializer
{
    public class Identity : Initializer
    {
        public Identity(float gain = 1)
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
