using HDF.PInvoke;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class HDF5Matrix
    {
        public Shape Shape => throw new NotImplementedException();

        public DType DType => throw new NotImplementedException();

        public int NDim => throw new NotImplementedException();

        public int Size => throw new NotImplementedException();

        public HDF5Matrix(string datapath, string dataset, int start= 0, int? end= null, Func<NDArray, NDArray> normalizer = null)
        {
            
            throw new NotImplementedException();

            
        }

        public int Length => throw new NotImplementedException();

        public H5D this[Slice key]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static bool AskToProceedWithOverwrite(string filepath)
        {
            throw new NotImplementedException();
        }
    }
}
