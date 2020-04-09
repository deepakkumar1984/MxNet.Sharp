using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class RandomNormal : Initializer
    {
        public RandomNormal(float mean = 0, float stddev = 0.05f, int? seed = null)
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
