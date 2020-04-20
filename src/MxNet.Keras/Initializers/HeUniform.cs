using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class HeUniform : VarianceScaling
    {
        public HeUniform(int? seed) : base(scale: 2, mode: "fan_in", distribution: "uniform", seed: seed)
        {

        }
    }
}
