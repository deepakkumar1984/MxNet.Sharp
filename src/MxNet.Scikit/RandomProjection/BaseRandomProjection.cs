using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.RandomProjection
{
    public abstract class BaseRandomProjection : TransformerMixin
    {
        public BaseRandomProjection(int? n_components = null, float eps= 0.1f, bool dense_output= false, int? random_state= null)
        {
            throw new NotImplementedException();
        }

        internal abstract NDArray MakeRandomMatrix(int n_components, int n_features);

        public override NDArray Fit(NDArray X, NDArray y = null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Transform(NDArray X)
        {
            throw new NotImplementedException();
        }
    }
}
