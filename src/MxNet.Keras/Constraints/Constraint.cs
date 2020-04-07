using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Constraints
{
    public abstract class Constraint
    {
        public abstract KerasSymbol Call(KerasSymbol w);

        public abstract ConfigDict GetConfig();
    }
}
