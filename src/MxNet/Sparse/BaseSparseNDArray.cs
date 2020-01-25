using System;
using System.Collections.Generic;
using System.Text;
using NDArrayHandle = System.IntPtr;
using mx_uint = System.UInt32;
using mx_float = System.Single;
using size_t = System.UInt64;
using MxNet.Interop;

namespace MxNet.Sparse
{
    public class BaseSparseNDArray : NDArray
    {
        private Dictionary<StorageStype, DType[]> _STORAGE_AUX_TYPES = new Dictionary<StorageStype, DType[]>()
        {
            {
                StorageStype.Csr,
                new DType[]{ DType.Int64, DType.Int64 }
            },
             {
                StorageStype.RowSparse,
                new DType[]{ DType.Int64 }
            }
        };

        internal int NumAux
        {
            get
            {
                return _STORAGE_AUX_TYPES[SType].Length;
            }
        }
        #region Basic Ops
        public static BaseSparseNDArray operator +(BaseSparseNDArray lhs, BaseSparseNDArray rhs)
        {
            return (BaseSparseNDArray)nd.ElemwiseAdd(lhs, rhs);
        }

        public static BaseSparseNDArray operator +(BaseSparseNDArray lhs, mx_float scalar)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public static BaseSparseNDArray operator +(mx_float scalar, BaseSparseNDArray rhs)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public static BaseSparseNDArray operator -(BaseSparseNDArray lhs, BaseSparseNDArray rhs)
        {
            return (BaseSparseNDArray)nd.ElemwiseSub(lhs, rhs);
        }

        public static BaseSparseNDArray operator -(BaseSparseNDArray lhs, mx_float scalar)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public static BaseSparseNDArray operator -(mx_float scalar, BaseSparseNDArray rhs)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public static BaseSparseNDArray operator *(BaseSparseNDArray lhs, BaseSparseNDArray rhs)
        {
            return (BaseSparseNDArray)nd.ElemwiseMul(lhs, rhs);
        }

        public static BaseSparseNDArray operator *(BaseSparseNDArray lhs, mx_float scalar)
        {
            return (BaseSparseNDArray)nd.MulScalar(lhs, scalar);
        }

        public static NDArray operator *(mx_float scalar, BaseSparseNDArray rhs)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public static BaseSparseNDArray operator /(BaseSparseNDArray lhs, BaseSparseNDArray rhs)
        {
            return (BaseSparseNDArray)nd.ElemwiseDiv(lhs, rhs);
        }

        public static BaseSparseNDArray operator /(BaseSparseNDArray lhs, mx_float scalar)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public static BaseSparseNDArray operator /(mx_float scalar, BaseSparseNDArray rhs)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }
        #endregion

        public override uint Size => throw new NotSupportedException("Not supported for Sparse NDArray");

        public override void SyncCopyFromCPU(Array data)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public override NDArray Reshape(params int[] shape)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public override NDArray Reshape(params uint[] shape)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public override NDArray Reshape(Shape shape, bool reverse = false)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        public override NDArray Slice(uint begin, uint end)
        {
            throw new NotSupportedException("Not supported for Sparse NDArray");
        }

        private DType AuxType(int i)
        {
            NativeMethods.MXNDArrayGetAuxType(GetHandle(), i, out var out_type);
            return DType.GetType(out_type);
        }

        private DType[] AuxTypes()
        {
            List<DType> aux_types = new List<DType>();
            int num_aux = NumAux;
            for (int i = 0; i < num_aux; i++)
            {
                aux_types.Add(AuxType(i));
            }

            return aux_types.ToArray();
        }

        public override NumSharp.NDArray AsNumpy()
        {
            return CastStorage(StorageStype.Default).AsNumpy();
        }

        public override NDArray AsType(DType dtype)
        {
            return base.AsType(dtype);
        }

        public void CheckFormat(bool full_check = true)
        {
            NativeMethods.MXNDArraySyncCheckFormat(GetHandle(), full_check);
        }

        public NDArray _Data()
        {
            WaitToRead();
            NativeMethods.MXNDArrayGetDataNDArray(GetHandle(), out var @out);
            return new NDArray(@out);
        }

        internal NDArray AuxData()
        {
            WaitToRead();
            NativeMethods.MXNDArrayGetAuxNDArray(GetHandle(), out var @out);
            return new NDArray(@out);
        }
    }
}
