using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class RMSprop : MxNet.Optimizers.RMSProp, IOptimizer
    {
        public KerasSymbol Lr { get; set; }
        public KerasSymbol Decay { get; set; }

        public ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
