using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.IO
{
    internal class IOUtils
    {
        public static NDArrayDict InitData(NDArray[] data, bool allow_empty, string default_name)
        {
            NDArrayDict result = new NDArrayDict();
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

        public static bool HasInstance(NDArrayDict data, DType dtype)
        {
            foreach (var item in data)
            {
                if (item.Value.DataType.Name == dtype.Name)
                    return true;
            }

            return false;
        }

        public static NDArrayDict GetDataByIdx(NDArrayDict data)
        {
            NDArrayDict shuffle_data = new NDArrayDict();

            foreach (var item in data)
            {
                shuffle_data.Add(item.Key, nd.Shuffle(item.Value));
            }

            return shuffle_data;
        }
    }
}
