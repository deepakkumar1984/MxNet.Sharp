using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class GlorotNormal : VarianceScaling
    {
        public GlorotNormal(int? seed) : base(scale: 1, mode: "fan_avg", distribution: "normal", seed: seed)
        {

        }
    }
}
