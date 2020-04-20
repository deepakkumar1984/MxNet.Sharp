using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Constraints
{
    public class NonNeg : Constraint
    {
        public override KerasSymbol Call(KerasSymbol w)
        {
            w *= K.Cast(K.GreaterEqual(w, 0), K.FloatX());
            return w;
        }
    }
}
