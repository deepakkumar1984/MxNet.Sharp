using MxNet.Keras.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class _SeparableConv : _Conv
    {
        public _SeparableConv(int rank, int filters, int[] kernel_size, int[] strides = null, string padding = "valid", string data_format = "", int[] dilation_rate = null, int depth_multiplier = 1, string activation = null, bool use_bias = true, string depthwise_initializer = "glorot_uniform", string pointwise_initializer = "glorot_uniform", string bias_initializer = "zeros", string depthwise_regularizer = "", string pointwise_regularizer = "", string bias_regularizer = "", string activity_regularizer = "", Constraint depthwise_constraint = null, Constraint pointwise_constraint = null, Constraint bias_constraint = null) : base(rank, filters, kernel_size, strides, padding, data_format, dilation_rate, activation, use_bias, bias_initializer: bias_initializer, bias_regularizer: bias_regularizer, activity_regularizer: activity_regularizer, bias_constraint: bias_constraint)
        {
            throw new NotImplementedException();
        }

        public override void Build(Shape input_shape)
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
    }
}
