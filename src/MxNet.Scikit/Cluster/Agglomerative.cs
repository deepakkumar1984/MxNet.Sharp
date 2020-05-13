using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class Agglomerative
    {
        public static NDArray FixConnectivity(NDArray X, NDArray connectivity, string affinity)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, int, int, NDArray) SingleLinkageTree(NDArray connectivity, int n_samples, int n_nodes, int n_clusters,
                         int n_connected_components, bool return_distance)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, int, int, NDArray, NDArray) WardTree(NDArray X, NDArray connectivity= null, int? n_clusters= null, bool return_distance= false)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, int, int, NDArray, NDArray) LinkageTree(NDArray X, NDArray connectivity = null, int? n_clusters = null, string linkage = "complete", string affinity = "euclidean", bool return_distance = false)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, int, int, NDArray, NDArray) CompleteLinkage(NDArray X, NDArray connectivity = null, int? n_clusters = null, string affinity = "euclidean", bool return_distance = false)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, int, int, NDArray, NDArray) AverageLinkage(NDArray X, NDArray connectivity = null, int? n_clusters = null, string affinity = "euclidean", bool return_distance = false)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, int, int, NDArray, NDArray) SingleLinkage(NDArray X, NDArray connectivity = null, int? n_clusters = null, string affinity = "euclidean", bool return_distance = false)
        {
            throw new NotImplementedException();
        }

        public static NDArray HcCut(int n_clusters, NDArray children, int n_leaves)
        {
            throw new NotImplementedException();
        }
    }
}
