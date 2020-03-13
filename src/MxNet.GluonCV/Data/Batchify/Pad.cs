using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Batchify
{
    public class Pad
    {
        public Pad(int axis= 0, float pad_val= 0, int num_shards= 1,bool ret_length= false)
        {
            throw new NotImplementedException();
        }

        public NDArray Call(NDArrayList data)
        {
            throw new NotImplementedException();
        }
    }
}
