using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class Masking : Layer
    {
        public Masking(float mask_value = 0)
        {
            throw new NotImplementedException();
        }

        public override void Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol[] ComputeMask(KerasSymbol[] inputs, KerasSymbol mask = null)
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
