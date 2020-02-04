using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.IO
{
    internal class IOUtils
    {
        public static Dictionary<string, NDArray> InitData(NDArray[] data, bool allow_empty, string default_name) => throw new NotImplementedException();

        public static bool HasInstance(NDArray data, DType dtype) => throw new NotImplementedException();

        public static Dictionary<string, NDArray> GetDataByIdx(Dictionary<string, NDArray> data, NDArray idx) => throw new NotImplementedException();
    }
}
