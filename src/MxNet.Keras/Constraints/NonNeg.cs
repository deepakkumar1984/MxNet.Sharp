﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Constraints
{
    public class NonNeg : Constraint
    {
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