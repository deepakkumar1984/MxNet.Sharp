using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Constraints
{
    public class UnitNorm : Constraint
    {
        private int axis;

        public UnitNorm(int axis = 0)
        {
            this.axis = axis;
        }

        public override KerasSymbol Call(KerasSymbol w)
        {
            return w / (K.Epsilon() + K.Sqrt(K.Sum(K.Square(w), axis: this.axis, keepdims: true)));
        }

        public override ConfigDict GetConfig()
        {
            ConfigDict dict = new ConfigDict();
            dict.Add("axis", axis);
            return dict;
        }
    }
}
