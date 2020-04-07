using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class ConvUtils
    {
        public static int[] NormalizeTuple(int[] value, int n, string name)
        {
            throw new NotImplementedException();
        }

        public string NormalizePadding(string value)
        {
            throw new NotImplementedException();
        }

        public static NDArray ConvertKernel(NDArray kernel)
        {
            throw new NotImplementedException();
        }

        public static int ConvOutputLength(int input_length, int filter_size, string padding, int stride, int dilation= 1)
        {
            throw new NotImplementedException();
        }

        public static int ConvInputLength(int output_length, int filter_size, string padding, int stride)
        {
            throw new NotImplementedException();
        }

        public static int DeconvLength(int dim_size, int stride_size, int kernel_size, string padding, int output_padding, int dilation= 1)
        {
            throw new NotImplementedException();
        }
    }
}
