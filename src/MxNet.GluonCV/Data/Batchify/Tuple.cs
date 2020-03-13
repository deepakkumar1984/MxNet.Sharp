using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Batchify
{
    public class Tuple
    {
        public Tuple(Func<NDArray, NDArray> funcs)
        {
            throw new NotImplementedException();
        }

        public NDArrayList Call(NDArrayList data)
        {
            throw new NotImplementedException();
        }
    }
}
