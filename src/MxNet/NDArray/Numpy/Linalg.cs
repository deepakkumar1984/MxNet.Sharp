using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.ND.Numpy
{
    internal class Linalg
    {
        public ndarray matrix_rank(ndarray M, ndarray tol= null, bool hermitian= false)
        {
            throw new NotImplementedException();
        }

        public ndarray lstsq(ndarray a, ndarray b, string rcond= "warn")
        {
            throw new NotImplementedException();
        }

        public ndarray pinv(ndarray a, float rcond= 1e-15f,bool hermitian= false)
        {
            throw new NotImplementedException();
        }

        public ndarray norm(ndarray x, string ord= null, int? axis= null, bool keepdims= false)
        {
            throw new NotImplementedException();
        }

        public ndarray svd(ndarray a)
        {
            throw new NotImplementedException();
        }

        public ndarray cholesky(ndarray a)
        {
            throw new NotImplementedException();
        }

        public ndarray qr(ndarray a, string mode = "reduced")
        {
            throw new NotImplementedException();
        }

        public ndarray inv(ndarray a)
        {
            throw new NotImplementedException();
        }

        public ndarray det(ndarray a)
        {
            throw new NotImplementedException();
        }

        public ndarray slogdet(ndarray a)
        {
            throw new NotImplementedException();
        }

        public ndarray solve(ndarray a, ndarray b)
        {
            throw new NotImplementedException();
        }

        public ndarray tensorinv(ndarray a, int ind = 2)
        {
            throw new NotImplementedException();
        }

        public ndarray tensorsolve(ndarray a, ndarray b, params int[] axes)
        {
            throw new NotImplementedException();
        }

        public ndarray eigvals(ndarray a)
        {
            throw new NotImplementedException();
        }

        public ndarray eigvalsh(ndarray a, string UPLO = "L")
        {
            throw new NotImplementedException();
        }

        public ndarray eig(ndarray a)
        {
            throw new NotImplementedException();
        }

        public ndarray eigh(ndarray a, string UPLO = "L")
        {
            throw new NotImplementedException();
        }
    }
}
