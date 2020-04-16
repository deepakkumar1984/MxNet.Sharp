using MxNet.Keras.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class Conv1D : _Conv
    {
        public Conv1D(int filters, int kernel_size, int strides = 1, string padding = "valid", string data_format = "", int dilation_rate = 1, string activation = null, bool use_bias = true, string kernel_initializer = "glorot_uniform", string bias_initializer = "zeros", string kernel_regularizer = "", string bias_regularizer = "", string activity_regularizer = "", Constraint kernel_constraint = null, Constraint bias_constraint = null) : base(1, filters, new int[] { kernel_size }, new int[] { strides }, padding, data_format, new int[] { dilation_rate }, activation, use_bias, kernel_initializer, bias_initializer, kernel_regularizer, bias_regularizer, activity_regularizer, kernel_constraint, bias_constraint)
        {
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
