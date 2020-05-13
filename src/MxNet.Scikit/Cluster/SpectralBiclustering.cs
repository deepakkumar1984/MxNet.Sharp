using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class SpectralBiclustering : BaseSpectral
    {
        public SpectralBiclustering(int n_clusters = 3, string svd_method = "randomized", int? n_svd_vecs = null, bool mini_batch = false, string init = "k-means++", int n_init = 10, int? n_jobs = null, int? random_state = null) : base(n_clusters, svd_method, n_svd_vecs, mini_batch, init, n_init, n_jobs, random_state)
        {
            throw new NotImplementedException();
        }

        internal override NDArray FitInternal(NDArray X)
        {
            throw new NotImplementedException();
        }

        internal override void CheckParameters()
        {
            throw new NotImplementedException();
        }

        internal NDArray FitBestPiecewise(NDArray vectors, int n_best, int n_clusters)
        {
            throw new NotImplementedException();
        }

        internal NDArray ProjectAndCluster(NDArray data, NDArray vectors, int n_clusters)
        {
            throw new NotImplementedException();
        }
    }
}
