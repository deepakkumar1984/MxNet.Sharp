using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.NN.Layers.Activations
{
    public class ReLU : BaseLayer
    {
        public ReLU()
            : base("relu")
        {

        }

        public override Symbol Build(Symbol x)
        {
            return new Operator("Activation").SetParam("act_type", "relu")
                                            .SetInput("data", x)
                                            .CreateSymbol();
        }
    }
}
