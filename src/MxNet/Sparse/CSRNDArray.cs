using System;
using System.Collections.Generic;
using System.Text;
using mx_uint = System.UInt32;
using mx_float = System.Single;
using size_t = System.UInt64;

namespace MxNet.Sparse
{
    public class CSRNDArray : BaseSparseNDArray
    {
        public NDArray Indices
        {
            get
            {
                return AuxData(1);
            }
        }

        public NDArray IndPtr
        {
            get
            {
                return AuxData(0);
            }
        }

        public new NDArray Data
        {
            get
            {
                return base.Data();
            }
        }

        public static CSRNDArray operator +(CSRNDArray lhs, mx_float scalar)
        {
            return (CSRNDArray)nd.PlusScalar(lhs, scalar);
        }

        public static CSRNDArray operator +(mx_float scalar, CSRNDArray rhs)
        {
            return (CSRNDArray)nd.PlusScalar(rhs, scalar);
        }

        public static CSRNDArray operator -(CSRNDArray lhs, mx_float scalar)
        {
            return (CSRNDArray)nd.MinusScalar(lhs, scalar);
        }

        public static CSRNDArray operator -(mx_float scalar, CSRNDArray rhs)
        {
            return (CSRNDArray)nd.RminusScalar(rhs, scalar);
        }

        public static CSRNDArray operator *(CSRNDArray lhs, mx_float scalar)
        {
            return (CSRNDArray)nd.MulScalar(lhs, scalar);
        }

        public static CSRNDArray operator *(mx_float scalar, CSRNDArray rhs)
        {
            return (CSRNDArray)nd.MulScalar(rhs, scalar);
        }

        public static CSRNDArray operator /(CSRNDArray lhs, mx_float scalar)
        {
            return (CSRNDArray)nd.DivScalar(lhs, scalar);
        }

        public static CSRNDArray operator /(mx_float scalar, CSRNDArray rhs)
        {
            return (CSRNDArray)nd.RdivScalar(rhs, scalar);
        }

        public new void CopyTo(NDArray other)
        {
            if (other.SType == StorageStype.RowSparse)
                throw new Exception("CopyTo does not support destination NDArray stype RowSparse");
            base.CopyTo(other);
        }

        public void CopyTo(Context other)
        {
            this.ChangeContext(other);
        }

        public new CSRNDArray ToSType(StorageStype stype)
        {
            if (stype == StorageStype.RowSparse)
                throw new Exception("cast_storage from csr to row_sparse is not supported");

            return (CSRNDArray)nd.CastStorage(this, stype);
        }
    }
}
