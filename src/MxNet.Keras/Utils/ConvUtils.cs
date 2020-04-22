using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class ConvUtils
    {
        public static int[] NormalizeTuple(int[] value, int n, string name)
        {
            List<int> value_tuple = new List<int>();
            if (value.Length == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    value_tuple.Add(value[0]);
                }
            }
            else
            {
                value_tuple = value.ToList();
            }

            if (value_tuple.Count != n)
                throw new Exception("Length mismatch for value and n");

            return value_tuple.ToArray();
        }

        public string NormalizePadding(string value)
        {
            var padding = value.ToLower();
            var allowed = new string[] { "valid", "same", "causal" };
            
            if (!allowed.Contains(padding))
            {
                throw new Exception("The `padding` argument must be one of \"valid\", \"same\" (or \"causal\" for Conv1D). Received: " + padding.ToString());
            }

            return padding;
        }

        public static NDArray ConvertKernel(NDArray kernel)
        {
            if (!(3 <= kernel.Dimension && kernel.Dimension <= 5))
            {
                throw new Exception("Invalid kernel shape:" + kernel.Shape);
            }

            return kernel;
        }

        public static int ConvOutputLength(int input_length, int filter_size, string padding, int stride, int dilation= 1)
        {
            int output_length = 0;
            Debug.Assert((new string[] { "same", "valid", "full", "causal" }).Contains(padding));
            var dilated_filter_size = filter_size + (filter_size - 1) * (dilation - 1);
            if (padding == "same")
            {
                output_length = input_length;
            }
            else if (padding == "valid")
            {
                output_length = input_length - dilated_filter_size + 1;
            }
            else if (padding == "causal")
            {
                output_length = input_length;
            }
            else if (padding == "full")
            {
                output_length = input_length + dilated_filter_size - 1;
            }
            return (output_length + stride - 1) / stride;
        }

        public static int ConvInputLength(int output_length, int filter_size, string padding, int stride)
        {
            int pad = 0;
            Debug.Assert((new string[] { "same", "valid", "full" }).Contains(padding));
            if (padding == "same")
            {
                pad = filter_size / 2;
            }
            else if (padding == "valid")
            {
                pad = 0;
            }
            else if (padding == "full")
            {
                pad = filter_size - 1;
            }
            return (output_length - 1) * stride - 2 * pad + filter_size;
        }

        public static int DeconvLength(int dim_size, int stride_size, int kernel_size, string padding, int? output_padding, int dilation= 1)
        {
            Debug.Assert((new string[] { "same", "valid", "full" }).Contains(padding));
            int pad = 0;
            // Get the dilated kernel size
            kernel_size = kernel_size + (kernel_size - 1) * (dilation - 1);
            // Infer length if output padding is None, else compute the exact length
            if (output_padding == null)
            {
                if (padding == "valid")
                {
                    dim_size = dim_size * stride_size + Math.Max(kernel_size - stride_size, 0);
                }
                else if (padding == "full")
                {
                    dim_size = dim_size * stride_size - (stride_size + kernel_size - 2);
                }
                else if (padding == "same")
                {
                    dim_size = dim_size * stride_size;
                }
            }
            else
            {
                if (padding == "same")
                {
                    pad = kernel_size / 2;
                }
                else if (padding == "valid")
                {
                    pad = 0;
                }
                else if (padding == "full")
                {
                    pad = kernel_size - 1;
                }

                dim_size = (dim_size - 1) * stride_size + kernel_size - 2 * pad + output_padding.Value;
            }
            return dim_size;
        }
    }
}
