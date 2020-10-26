using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class NpUtils
    {
        public static ndarray ToCategorial(ndarray y, int? num_classes = null, dtype dtype = null)
        {
            var input_shape = y.shape;
            List<long> new_shape = new List<long>();
            if (input_shape.lastDim == 1 && input_shape.iDims.Length > 1)
            {
                new_shape = input_shape.iDims.Take(input_shape.iDims.Length - 1).ToList();
            }
            else
            {
                new_shape = input_shape.iDims.ToList();
            }

            y = y.ravel();

            if (num_classes.HasValue)
            {
                num_classes = (int)np.max(y) + 1;
            }

            var n = y.shape.iDims[0];
            var categorical = np.zeros((n, num_classes), dtype: dtype);
            categorical[np.arange(n), y] = 1;
            new_shape.Add(num_classes.Value);
            var output_shape = new shape(new_shape);
            categorical = np.reshape(categorical, output_shape);
            return categorical;
        }

        public static ndarray Normalize(ndarray x, int axis = -1, int order = 2)
        {
            var l2 = np.atleast_1d(nd.Norm(x, order, axis)).FirstOrDefault();
            l2[l2 == 0] = 1;
            return (ndarray)(x / np.expand_dims(l2, axis));
        }

        public static ndarray ToChannelFirst(ndarray data)
        {
            Debug.Assert(data != null, "A Numpy data should not be None");
            data = to_channels_first_helper(data);
            return data;
        }

        public static ndarray[] ToChannelFirst(ndarray[] data)
        {
            Debug.Assert(data != null, "A Numpy data should not be None");
            for (int i = 0; i < data.Length; i++)
                data[i] = to_channels_first_helper(data[i]);

            return data;
        }

        private static ndarray to_channels_first_helper(ndarray np_data)
        {
            var data_format = MxNetBackend.ImageDataFormat();
            if (!new string[]{"channels_first", "channels_last"}.Contains(data_format)) {
                throw new ValueError("Unknown data_format " + data_format.ToString());
            }
            var shape = np_data.shape;
            if (shape.iDims.Length == 5)
            {
                np_data = np.transpose(np_data, new long[] { 0, 4, 1, 2, 3 });
            }
            else if (shape.iDims.Length == 4)
            {
                np_data = np.transpose(np_data, new long[] { 0, 3, 1, 2 });
            }
            else if (shape.iDims.Length == 3)
            {
                throw new ValueError("Your data is either a textual data of shape `(num_sample, step, feature)` or a grey scale image of shape `(num_sample, rows, cols)`. Case 1: If your data is time-series or a textual data(probably you are using Conv1D), then there is no need of channel conversion.Case 2: If your data is image(probably you are using Conv2D), then you need to reshape the tension dimensions as follows:`shape = x_input.shape``x_input = x_input.reshape(shape[0], 1, shape[1], shape[2])`Note: Do not use `to_channels_fir()` in above cases.");
            }
            else
            {
                throw new ValueError("Your input dimension tensor is incorrect.");
            }

            return np_data;
        }
    }
}
