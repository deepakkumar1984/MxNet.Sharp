using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class AgglomerativeClustering : ClusterMixin
    {
        public AgglomerativeClustering(int n_clusters= 2, string affinity= "euclidean", MemoryStream memory= null, NDArray connectivity = null, string compute_full_tree= "auto", string linkage= "ward", float? distance_threshold= null)
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
            return base.FitPredict(X, y);
        }
    }
}
