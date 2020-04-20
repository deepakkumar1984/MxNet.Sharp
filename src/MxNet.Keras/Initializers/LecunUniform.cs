using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class LecunUniform : VarianceScaling
    {
        public LecunUniform(int? seed) : base(scale: 1, mode: "fan_in", distribution: "uniform", seed: seed)
        {

        }
    }
}
