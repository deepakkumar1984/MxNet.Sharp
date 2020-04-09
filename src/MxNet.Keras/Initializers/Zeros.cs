using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class Zeros : Initializer
    {
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
