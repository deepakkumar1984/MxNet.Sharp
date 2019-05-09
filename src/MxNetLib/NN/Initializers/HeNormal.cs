using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.NN.Initializers
{
    public class HeNormal : VarianceScaling
    {
        public HeNormal()
            :base(2, "fan_in", "normal")
        {
            Name = "he_normal";
        }
    }
}
