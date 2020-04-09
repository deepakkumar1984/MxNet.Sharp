using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class VarianceScaling : Initializer
    {
        public VarianceScaling(float scale= 1, string mode= "fan_in", string distribution= "normal", int? seed= null)
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
