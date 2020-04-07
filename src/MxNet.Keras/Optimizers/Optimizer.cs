using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public interface IOptimizer
    {
        KerasSymbol Lr { get; set; }

        KerasSymbol Decay { get; set; }

        ConfigDict GetConfig();
    }
}
