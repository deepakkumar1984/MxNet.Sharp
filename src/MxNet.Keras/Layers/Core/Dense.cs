using MxNet.Keras.Constraints;
using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class Dense : Layer
    {
        public Dense(int units,
                     string activation= "",
                     bool use_bias= true,
                     string kernel_initializer= "glorot_uniform",
                     string bias_initializer= "zeros",
                     string kernel_regularizer= "",
                     string bias_regularizer= "",
                     string activity_regularizer= "",
                     Constraint kernel_constraint= null,
                     Constraint bias_constraint= null,
                     bool sparse_weight= false)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public override void Build(Shape input_shape)
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
