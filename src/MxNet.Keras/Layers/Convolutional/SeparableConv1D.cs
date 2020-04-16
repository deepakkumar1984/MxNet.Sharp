using MxNet.Keras.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class SeparableConv1D : _SeparableConv
    {
        public SeparableConv1D(
            int filters,
            int kernel_size,
            int strides = 1,
            string padding = "valid",
            string data_format = "",
            int dilation_rate = 1,
            int depth_multiplier = 1,
            string activation = null,
            bool use_bias = true,
            string depthwise_initializer = "glorot_uniform",
            string pointwise_initializer = "glorot_uniform",
            string bias_initializer = "zeros",
            string depthwise_regularizer = "",
            string pointwise_regularizer = "",
            string bias_regularizer = "",
            string activity_regularizer = "",
            Constraint depthwise_constraint = null,
            Constraint pointwise_constraint = null,
            Constraint bias_constraint = null) : base(
                1,
                filters,
                new int[] { kernel_size },
                new int[] { strides },
                padding,
                data_format,
                new int[] { dilation_rate },
                depth_multiplier,
                activation,
                use_bias,
                depthwise_initializer,
                pointwise_initializer,
                bias_initializer,
                depthwise_regularizer,
                pointwise_regularizer,
                bias_regularizer,
                activity_regularizer,
                depthwise_constraint,
                pointwise_constraint,
                bias_constraint)
        {
        }
    }
}
