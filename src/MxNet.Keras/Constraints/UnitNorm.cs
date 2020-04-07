using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Constraints
{
    public class UnitNorm : Constraint
    {
        public UnitNorm(int axis = 0)
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
