using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class ActivityRegularization : Layer
    {
        public ActivityRegularization(float l1 = 0, float l2 = 0)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            throw new NotImplementedException();
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shape)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
