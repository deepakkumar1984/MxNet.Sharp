using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializer
{
    public class RandomUniform : Initializer
    {
        public RandomUniform(float minval= -0.05f, float maxval= 0.05f, int? seed= null)
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
