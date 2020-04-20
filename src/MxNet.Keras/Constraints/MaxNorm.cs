using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Constraints
{
    public class MaxNorm : Constraint
    {
        private int axis;

        private float max_value;

        public MaxNorm(int max_value = 2, int axis = 0)
        {
            this.max_value = max_value;
            this.axis = axis;
        }

        public override KerasSymbol Call(KerasSymbol w)
        {
            var norms = K.Sqrt(K.Sum(K.Square(w), axis: this.axis, keepdims: true));
            var desired = K.Clip(norms, 0, this.max_value);
            w *= desired / (K.Epsilon() + norms);
            return w;
        }

        public override ConfigDict GetConfig()
        {
            ConfigDict dict = new ConfigDict();
            dict.Add("max_value", max_value);
            dict.Add("axis", axis);
            return dict;
        }
    }
}
