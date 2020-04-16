using MxNet.Keras.Constraints;
using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers.AdvancedActivations
{
    public class PReLU : Layer
    {
        public PReLU(string alpha_initializer= "zeros", string alpha_regularizer= null, Constraint alpha_constraint= null, Shape shared_axes = null)
        {
            throw new NotImplementedException();
        }

        public override void Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public override void Build()
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
