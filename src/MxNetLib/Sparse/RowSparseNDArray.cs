using System;
using System.Collections.Generic;
using System.Text;
using mx_uint = System.UInt32;
using mx_float = System.Single;
using size_t = System.UInt64;

namespace MxNetLib.Sparse
{
    public class RowSparseNDArray : BaseSparseNDArray
    {
        public CSRNDArray this[string slice]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public NDArray Indices
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArray Data
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static RowSparseNDArray operator +(RowSparseNDArray lhs, mx_float scalar)
        {
            return (RowSparseNDArray)nd.PlusScalar(lhs, scalar);
        }

        public static RowSparseNDArray operator +(mx_float scalar, RowSparseNDArray rhs)
        {
            return (RowSparseNDArray)nd.PlusScalar(rhs, scalar);
        }

        public static RowSparseNDArray operator -(RowSparseNDArray lhs, mx_float scalar)
        {
            return (RowSparseNDArray)nd.MinusScalar(lhs, scalar);
        }

        public static RowSparseNDArray operator -(mx_float scalar, RowSparseNDArray rhs)
        {
            return (RowSparseNDArray)nd.RminusScalar(rhs, scalar);
        }

        public static RowSparseNDArray operator *(RowSparseNDArray lhs, mx_float scalar)
        {
            return (RowSparseNDArray)nd.MulScalar(lhs, scalar);
        }

        public static RowSparseNDArray operator *(mx_float scalar, RowSparseNDArray rhs)
        {
            return (RowSparseNDArray)nd.MulScalar(rhs, scalar);
        }

        public static RowSparseNDArray operator /(RowSparseNDArray lhs, mx_float scalar)
        {
            return (RowSparseNDArray)nd.DivScalar(lhs, scalar);
        }

        public static RowSparseNDArray operator /(mx_float scalar, RowSparseNDArray rhs)
        {
            return (RowSparseNDArray)nd.RdivScalar(rhs, scalar);
        }
    }
}
