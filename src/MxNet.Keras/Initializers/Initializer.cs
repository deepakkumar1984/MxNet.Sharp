using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public abstract class Initializer
    {
        public abstract KerasSymbol Call(Shape shap, DType dtype = null);

        public virtual ConfigDict GetConfig()
        {
            return new ConfigDict();
        }
    }
}
