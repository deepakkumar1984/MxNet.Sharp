using MxNet.Keras.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class Conv2DTranspose : Conv2D
    {
        public Conv2DTranspose(int filters, (int, int) kernel_size, (int, int)? strides = null, string padding = "valid", string output_padding = "", string data_format = "", (int, int)? dilation_rate = null, string activation = null, bool use_bias = true, string kernel_initializer = "glorot_uniform", string bias_initializer = "zeros", string kernel_regularizer = "", string bias_regularizer = "", string activity_regularizer = "", Constraint kernel_constraint = null, Constraint bias_constraint = null) : base(filters, kernel_size, strides, padding, data_format, dilation_rate, activation, use_bias, kernel_initializer, bias_initializer, kernel_regularizer, bias_regularizer, activity_regularizer, kernel_constraint, bias_constraint)
        {
            throw new NotImplementedException();
        }

        public override void Build()
        {
            throw new NotImplementedException();
        }

        public override void Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public override Shape ComputeOutputShape(Shape input_shape)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
