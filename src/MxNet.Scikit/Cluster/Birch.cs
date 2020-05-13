using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class Birch : ClusterMixin
    {
        public Birch(float threshold= 0.5f, int branching_factor= 50, int n_clusters= 3, bool compute_labels= true, bool copy= true)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<NDArray> IterateSparseX(NDArray X)
        {
            throw new NotImplementedException();
        }

        public override NDArray Fit(NDArray X, NDArray y = null, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        internal NDArray _Fit(NDArray X)
        {
            throw new NotImplementedException();
        }

        internal _CFNode[] GetLeaves()
        {
            throw new NotImplementedException();
        }

        internal NDArray PartialFit(NDArray X = null, NDArray y = null)
        {
            throw new NotImplementedException();
        }

        internal void CheckFit(NDArray X)
        {
            throw new NotImplementedException();
        }

        public override NDArray Predict(NDArray X, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public NDArray Transform(NDArray X)
        {
            throw new NotImplementedException();
        }

        internal NDArray GlobalClustering(NDArray X)
        {
            throw new NotImplementedException();
        }
    }
}
