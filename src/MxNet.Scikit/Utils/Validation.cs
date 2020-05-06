using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Utils
{
    public class Validation
    {
        public static bool AssertAllFinite(NDArray X, bool allow_nan= false, DType msg_dtype= null)
        {
            throw new NotImplementedException();
        }

        public static NDArray AsFloatArray(NDArray X, bool copy= true, bool force_all_finite= true)
        {
            throw new NotImplementedException();
        }

        public static int NumSamples(NDArray x)
        {
            return x.Shape[0];
        }

        public static bool CheckConsistentLength(NDArrayList arrays)
        {
            throw new NotImplementedException();
        }

        public static NDArray MakeIndexable(NDArray x)
        {
            if(x.SType == StorageStype.RowSparse)
                return nd.CastStorage(x, StorageStype.Csr);

            return x;
        }

        public static NDArray MakeIndexable(Array x)
        {
            return nd.Array(x);
        }

        public static NDArrayList Indexable(NDArrayList iterables)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList Indexable(Array[] iterables)
        {
            throw new NotImplementedException();
        }

        public static NDArray EnsureSparseFormat(NDArray spmatrix, bool accept_sparse, DType dtype, bool copy, bool force_all_finite, bool accept_large_sparse)
        {
            throw new NotImplementedException(); 
        }
    }
}
