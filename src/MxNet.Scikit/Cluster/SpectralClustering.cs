using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class SpectralClustering : ClusterMixin
    {
        public bool Pairwise
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SpectralClustering(int n_clusters= 8, string eigen_solver= null, int? n_components= null,
                 int? random_state= null, int n_init= 10, float gamma= 1, string affinity= "rbf",
                 int n_neighbors= 10, float eigen_tol= 0, string assign_labels= "kmeans",
                 float degree= 3, float coef0= 1, FuncArgs kernel_params = null, int? n_jobs= null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Fit(NDArray X, NDArray y = null, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Predict(NDArray X, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray FitPredict(NDArray X, NDArray y = null, NDArray sample_weight = null)
        {
            return base.FitPredict(X, y, sample_weight);
        }

        public static NDArray spectral_clustering(NDArray affinity, int n_clusters= 8, int? n_components= null,
                                            string eigen_solver= null, int? random_state= null, int n_init= 10,
                                            float eigen_tol= 0, string assign_labels= "kmeans")
        {
            throw new NotImplementedException();
        }
    }
}
