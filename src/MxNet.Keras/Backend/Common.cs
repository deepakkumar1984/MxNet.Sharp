using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.Keras.Backend
{
    public class Common
    {
        public static string _FLOATX = "float32";
        public static float _EPSILON = 1e-7f;
        public static string _IMAGE_DATA_FORMAT = "channels_last";

        public static float Epsilon()
        {
            return _EPSILON;
        }

        public static void SetEpsilon(float e)
        {
            _EPSILON = e;
        }

        public static string FloatX()
        {
            return _FLOATX;
        }

        public static void SetFloatX(string floatx)
        {
            _FLOATX = floatx;
        }

        public static NDArray CastToFloatX(NDArray x)
        {
            return x.AsType(_FLOATX);
        }

        public static string ImageDataFormat()
        {
            return _IMAGE_DATA_FORMAT;
        }

        public static void SetImageDataFormat(string data_format)
        {
            _IMAGE_DATA_FORMAT = data_format;
        }

        public static string NormalizeDataFormat(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = ImageDataFormat();
            }

            var data_format = value.ToLower();
            if (!new string[]{ "channels_first", "channels_last"}.Contains(data_format)) {
                throw new Exception("The `data_format` argument must be one of \"channels_first\", \"channels_last\". Received: " + value.ToString());
            }

            return data_format;
        }

        public static void SetImageDimOrdering(string dim_ordering)
        {
            string data_format;
            if (!new string[] { "tf", "th" }.Contains(dim_ordering)) {
                throw new Exception("Unknown dim_ordering:" + dim_ordering);
            }

            if (dim_ordering == "th")
            {
                data_format = "channels_first";
            }
            else
            {
                data_format = "channels_last";
            }

            _IMAGE_DATA_FORMAT = data_format;
        }

        public static string ImageDimOrdering()
        {
            if (_IMAGE_DATA_FORMAT == "channels_first")
            {
                return "th";
            }
            else
            {
                return "tf";
            }
        }
    }
}
