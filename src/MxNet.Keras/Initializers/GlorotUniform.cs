using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class GlorotUniform : VarianceScaling
    {
        public GlorotUniform(int? seed) : base(scale: 1, mode: "fan_avg", distribution: "uniform", seed: seed)
        {

        }
    }
}
