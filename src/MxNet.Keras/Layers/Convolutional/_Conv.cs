using MxNet.Keras.Constraints;
using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class _Conv : Layer
    {
        public _Conv(int rank, int filters, int[] kernel_size, int[] strides= null, string padding= "valid", string data_format= "", int[] dilation_rate= null, string activation= null,
                 bool use_bias= true, string kernel_initializer= "glorot_uniform", string bias_initializer= "zeros", string kernel_regularizer= "", string bias_regularizer= "",
                 string activity_regularizer= "", Constraint kernel_constraint= null, Constraint bias_constraint= null)
        {
            throw new NotImplementedException();
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shape)
        {
            throw new NotImplementedException();
        }

        public override void Build(Shape input_shape)
        {
            throw new NotImplementedException();
        }
    }
}
