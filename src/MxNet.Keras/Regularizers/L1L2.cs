using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Regularizers
{
    public class L1L2 : Regularizer
    {
        public L1L2(float l1 = 0, float l2 = 0)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol Call(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
