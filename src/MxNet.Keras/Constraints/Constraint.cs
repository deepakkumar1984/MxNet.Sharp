using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Constraints
{
    public abstract class Constraint
    {
        public abstract KerasSymbol Call(KerasSymbol w);

        public virtual ConfigDict GetConfig()
        {
            return new ConfigDict();
        }
    }
}
