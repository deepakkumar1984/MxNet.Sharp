using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.RandomProjection
{
    public class GaussianRandomProjection : BaseRandomProjection
    {
        public GaussianRandomProjection(int? n_components = null, float eps = 0.1F, int? random_state = null) : base(n_components, eps, true, random_state)
        {
            throw new NotImplementedException();
        }

        internal override NDArray MakeRandomMatrix(int n_components, int n_features)
        {
            throw new NotImplementedException();
        }
    }
}
