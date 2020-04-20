using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class HeNormal : VarianceScaling
    {
        public HeNormal(int? seed) : base(scale: 2, mode: "fan_in", distribution: "normal", seed: seed)
        {

        }
    }
}
