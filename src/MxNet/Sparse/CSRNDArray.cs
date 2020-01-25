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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slice">
        /// Slice string eg: 0:10, 0:, :9
        /// </param>
        /// <returns></returns>
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

        public NDArray IndPtr
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

        public void CopyTo(CSRNDArray other)
        {
            throw new NotImplementedException();
        }

        public CSRNDArray ToSType(StorageStype stype)
        {
            throw new NotImplementedException();
        }
    }
}
