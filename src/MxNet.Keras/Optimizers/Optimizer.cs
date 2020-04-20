using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public interface IOptimizer
    {
        float Lr { get; set; }

        float Decay { get; set; }

        ConfigDict GetConfig();
    }
}
