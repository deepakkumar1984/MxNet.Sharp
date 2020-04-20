using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Constraints
{
    public class MinMaxNorm : Constraint
    {
        public int axis;

        public float max_value;

        public float min_value;

        public float rate;

        public MinMaxNorm(float min_value = 0, float max_value = 1, float rate = 1, int axis = 0)
        {
            this.min_value = min_value;
            this.max_value = max_value;
            this.rate = rate;
            this.axis = axis;
        }

        public override KerasSymbol Call(KerasSymbol w)
        {
            var norms = K.Sqrt(K.Sum(K.Square(w), axis: this.axis, keepdims: true));
            var desired = this.rate * K.Clip(norms, this.min_value, this.max_value) + (1 - this.rate) * norms;
            w *= desired / (K.Epsilon() + norms);
            return w;
        }

        public override ConfigDict GetConfig()
        {
            return new ConfigDict {
                {
                    "min_value",
                    this.min_value},
                {
                    "max_value",
                    this.max_value},
                {
                    "rate",
                    this.rate},
                {
                    "axis",
                    this.axis
                }
            };
        }
    }
}
