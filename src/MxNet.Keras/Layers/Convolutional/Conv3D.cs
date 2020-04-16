using MxNet.Keras.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class Conv3D : _Conv
    {
        public Conv3D(
            int filters,
            (int, int, int) kernel_size,
            (int, int, int)? strides = null,
            string padding = "valid",
            string data_format = "",
            (int, int, int)? dilation_rate = null,
            string activation = null,
            bool use_bias = true,
            string kernel_initializer = "glorot_uniform",
            string bias_initializer = "zeros",
            string kernel_regularizer = "",
            string bias_regularizer = "",
            string activity_regularizer = "",
            Constraint kernel_constraint = null,
            Constraint bias_constraint = null) : base(3,
                                                      filters,
                                                      new int[] { kernel_size.Item1, kernel_size.Item2, kernel_size.Item3 },
                                                      strides.HasValue ? new int[] { strides.Value.Item1, strides.Value.Item2, strides.Value.Item3 } : new int[] { 1, 1, 1 },
                                                      padding,
                                                      data_format,
                                                      dilation_rate.HasValue ? new int[] { dilation_rate.Value.Item1, dilation_rate.Value.Item2, dilation_rate.Value.Item3 } : new int[] { 1, 1, 1 },
                                                      activation,
                                                      use_bias,
                                                      kernel_initializer,
                                                      bias_initializer,
                                                      kernel_regularizer,
                                                      bias_regularizer,
                                                      activity_regularizer,
                                                      kernel_constraint,
                                                      bias_constraint)
        {
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
