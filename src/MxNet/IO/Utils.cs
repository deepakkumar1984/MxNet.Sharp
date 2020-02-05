using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.IO
{
    internal class IOUtils
    {
        public static Dictionary<string, NDArray> InitData(NDArray[] data, bool allow_empty, string default_name)
        {
            Dictionary<string, NDArray> result = new Dictionary<string, NDArray>();
            if (data == null)
                return result;

            if (!allow_empty && data.Length == 0)
            {
                throw new Exception("Data cannot be empty when allow_empty is false");
            }

            if (data.Length == 1)
                result.Add(default_name, data[0]);
            else
            {
                for(int i=0;i<data.Length;i++)
                {
                    result.Add($"_{i}_{default_name}", data[i]);
                }
            }

            return result;
        }

        public static bool HasInstance(Dictionary<string, NDArray> data, DType dtype)
        {
            foreach (var item in data)
            {
                if (item.Value.DataType.Name == dtype.Name)
                    return true;
            }

            return false;
        }

        public static Dictionary<string, NDArray> GetDataByIdx(Dictionary<string, NDArray> data)
        {
            Dictionary<string, NDArray> shuffle_data = new Dictionary<string, NDArray>();

            foreach (var item in data)
            {
                shuffle_data.Add(item.Key, nd.Shuffle(item.Value));
            }

            return shuffle_data;
        }
    }
}
