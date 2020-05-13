using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public abstract class BaseSpectral : BiClusterMixin
    {
        public BaseSpectral(int n_clusters= 3, string svd_method= "randomized", int? n_svd_vecs= null, bool mini_batch= false, string @init= "k-means++", int n_init= 10, int? n_jobs= null, int? random_state= null)
        {
            throw new NotImplementedException();
        }

        internal virtual void CheckParameters()
        {
            throw new NotImplementedException();
        }

        public virtual NDArray Fit(NDArray X, NDArray y = null)
        {
            throw new NotImplementedException();
        }

        public virtual (NDArray, NDArray) SVD(NDArray array, int n_components, int n_discard)
        {
            throw new NotImplementedException();
        }

        public virtual (NDArray, NDArray) SVD(NDArray data, int n_clusters)
        {
            throw new NotImplementedException();
        }

        internal abstract NDArray FitInternal(NDArray X);
    }
}
