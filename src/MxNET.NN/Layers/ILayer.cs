using MxNet.NN.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN.Layers
{
    public interface ILayer
    {
        Symbol Build(Symbol x);
    }
}
