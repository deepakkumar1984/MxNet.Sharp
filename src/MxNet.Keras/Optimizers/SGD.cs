using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Optimizers
{
    public class SGD : MxNet.Optimizers.SGD, IOptimizer
    {
        public KerasSymbol Lr { get; set; }
        public KerasSymbol Decay { get; set; }

        public SGD(float lr = 0.01f, float momentum = 0, float decay = 0, bool nesterov = false, float? clipnorm = null) : base(lr, momentum)
        {
            throw new NotImplementedException();
        }

        public override float GetLr(int index)
        {
            return base.GetLr(index);
        }

        public override float[] GetLrs(int[] indices)
        {
            return base.GetLrs(indices);
        }

        public ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
