using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class FeatureAgglomeration : AgglomerativeClustering
    {
        public FeatureAgglomeration(int n_clusters = 2, string affinity = "euclidean", MemoryStream memory = null, NDArray connectivity = null, string compute_full_tree = "auto", string linkage = "ward", Func<NDArray, NDArray> pooling_func = null, float? distance_threshold = null) : base(n_clusters, affinity, memory, connectivity, compute_full_tree, linkage, distance_threshold)
        {
            throw new NotImplementedException();
        }

        public override NDArray Fit(NDArray X, NDArray y = null, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }
    }
}
