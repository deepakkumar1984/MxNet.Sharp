using MxNet.Keras.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class DepthwiseConv2D : Conv2D
    {
        public DepthwiseConv2D(
            int filters, (int, int) kernel_size, (int, int)? strides = null, string padding = "valid", float depth_multiplier = 1,
            string data_format = "", string activation = null, bool use_bias = true,
            string depthwise_initializer = "glorot_uniform", string bias_initializer = "zeros",
            string depthwise_regularizer = "", string bias_regularizer = "", string activity_regularizer = "",
            Constraint depthwise_constraint = null, Constraint bias_constraint = null) : base(
                filters,
                kernel_size,
                strides,
                padding,
                data_format,
                activation: activation,
                use_bias: use_bias,
                bias_initializer: bias_initializer,
                bias_regularizer: bias_regularizer,
                activity_regularizer: activity_regularizer,
                bias_constraint: bias_constraint)
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
