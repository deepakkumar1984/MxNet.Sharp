using System;
using mx_uint = System.UInt32;
using mx_float = System.Single;
using size_t = System.UInt64;

namespace MxNet.Sparse
{
    public class RowSparseNDArray : BaseSparseNDArray
    {
        public RowSparseNDArray Indices => (RowSparseNDArray) AuxData(0);

        public new RowSparseNDArray Data => (RowSparseNDArray) Data();

        public static RowSparseNDArray operator +(RowSparseNDArray lhs, float scalar)
        {
            return (RowSparseNDArray) nd.PlusScalar(lhs, scalar);
        }

        public static RowSparseNDArray operator +(float scalar, RowSparseNDArray rhs)
        {
            return (RowSparseNDArray) nd.PlusScalar(rhs, scalar);
        }

        public static RowSparseNDArray operator -(RowSparseNDArray lhs, float scalar)
        {
            return (RowSparseNDArray) nd.MinusScalar(lhs, scalar);
        }

        public static RowSparseNDArray operator -(float scalar, RowSparseNDArray rhs)
        {
            return (RowSparseNDArray) nd.RminusScalar(rhs, scalar);
        }

        public static RowSparseNDArray operator *(RowSparseNDArray lhs, float scalar)
        {
            return (RowSparseNDArray) nd.MulScalar(lhs, scalar);
        }

        public static RowSparseNDArray operator *(float scalar, RowSparseNDArray rhs)
        {
            return (RowSparseNDArray) nd.MulScalar(rhs, scalar);
        }

        public static RowSparseNDArray operator /(RowSparseNDArray lhs, float scalar)
        {
            return (RowSparseNDArray) nd.DivScalar(lhs, scalar);
        }

        public static RowSparseNDArray operator /(float scalar, RowSparseNDArray rhs)
        {
            return (RowSparseNDArray) nd.RdivScalar(rhs, scalar);
        }

        public new void CopyTo(NDArray other)
        {
            if (other.SType == StorageStype.Csr)
                throw new Exception("CopyTo does not support destination NDArray stype Csr");
            base.CopyTo(other);
        }

        public void CopyTo(Context other)
        {
            ChangeContext(other);
        }

        public new CSRNDArray ToSType(StorageStype stype)
        {
            if (stype == StorageStype.Csr)
                throw new Exception("cast_storage from row_sparse to Csr is not supported");

            return (CSRNDArray) nd.CastStorage(this, stype);
        }
    }
}