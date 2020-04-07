using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Constraints
{
    public class MinMaxNorm : Constraint
    {
        public MinMaxNorm(float min_value= 0, float max_value = 1, float rate = 1, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol Call(KerasSymbol w)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
