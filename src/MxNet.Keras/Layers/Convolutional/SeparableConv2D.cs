using MxNet.Keras.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class SeparableConv2D : _SeparableConv
    {
        public SeparableConv2D(
            int filters,
            (int, int) kernel_size,
            (int, int)? strides = null,
            string padding = "valid",
            string data_format = "",
            (int, int)? dilation_rate = null,
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
                new int[] { kernel_size.Item1, kernel_size.Item2 },
                strides.HasValue ? new int[] { strides.Value.Item1, strides.Value.Item2 } : new int[] { 1, 1 },
                padding,
                data_format,
                dilation_rate.HasValue ? new int[] { dilation_rate.Value.Item1, dilation_rate.Value.Item2 } : new int[] { 1, 1 },
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
