using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Initializers
{
    public class LecunNormal : VarianceScaling
    {
        public LecunNormal(int? seed) : base(scale: 1, mode: "fan_in", distribution: "normal", seed: seed)
        {

        }
    }
}
