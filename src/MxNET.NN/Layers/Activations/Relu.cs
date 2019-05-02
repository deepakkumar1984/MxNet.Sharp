using MxNet.NN.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN.Layers.Activations
{
    public class ReLU : BaseLayer, ILayer
    {
        public ReLU()
            : base("relu")
        {

        }

        public Symbol Build(Symbol x)
        {
            return new Operator("Activation").SetParam("act_type", "relu")
                                            .SetInput("data", x)
                                            .CreateSymbol();
        }
    }
}
