using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class SpectralCoclustering : BaseSpectral
    {
        public SpectralCoclustering(int n_clusters = 3, string svd_method = "randomized", int? n_svd_vecs = null, bool mini_batch = false, string init = "k-means++", int n_init = 10, int? n_jobs = null, int? random_state = null) : base(n_clusters, svd_method, n_svd_vecs, mini_batch, init, n_init, n_jobs, random_state)
        {
        }

        internal override NDArray FitInternal(NDArray X)
        {
            throw new NotImplementedException();
        }
    }
}
