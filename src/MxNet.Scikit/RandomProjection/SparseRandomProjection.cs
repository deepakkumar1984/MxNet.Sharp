using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.RandomProjection
{
    public class SparseRandomProjection : BaseRandomProjection
    {
        public SparseRandomProjection(int? n_components = null, float? density = null, float eps = 0.1F, bool dense_output = false, int? random_state = null) : base(n_components, eps, dense_output, random_state)
        {
            throw new NotImplementedException();
        }

        internal override NDArray MakeRandomMatrix(int n_components, int n_features)
        {
            throw new NotImplementedException();
        }
    }
}
