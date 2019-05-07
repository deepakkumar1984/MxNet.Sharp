using MxNet.DotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN.Layers.Activations
{
    public class PReLU : BaseLayer, ILayer
    {
        public PReLU()
            : base("prelu")
        {
        }

        public Symbol Build(Symbol x)
        {
            return new Operator("LeakyReLU").SetParam("act_type", "prelu")
                                            .SetInput("data", x)
                                            .CreateSymbol(ID);
        }
    }
}
