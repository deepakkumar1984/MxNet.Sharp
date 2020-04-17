using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class Dropout : Layer
    {
        public Dropout(float rate, Shape noise_shape = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        internal virtual Shape GetNoiseShape(KerasSymbol inputs)
        {
            throw new NotImplementedException();
        }

        public override void Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public override Shape ComputeOutputShape(Shape input_shape)
        {
            throw new NotImplementedException();
        }
    }
}
