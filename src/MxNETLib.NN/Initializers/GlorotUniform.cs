using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.NN.Initializers
{
    public class GlorotUniform : VarianceScaling
    {
        public GlorotUniform()
            :base(1, "fan_avg", "uniform")
        {
            Name = "glorot_uniform";
        }
    }
}
