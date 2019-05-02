using MxNet.NN.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN.Layers.Activations
{
    public class Exp : BaseLayer, ILayer
    {
        public Exp()
            : base("exp")
        {
        }

        public Symbol Build(Symbol x)
        {
            return new Operator("exp").SetInput("data", x)
                                            .CreateSymbol(ID);
        }
    }
}
