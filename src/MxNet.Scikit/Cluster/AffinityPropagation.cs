using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class AffinityPropagation : ClusterMixin
    {
        public AffinityPropagation(float damping= 0.5f, int max_iter= 200, int convergence_iter= 15, bool copy= true, NDArray preference= null, string affinity= "euclidean", bool verbose= false)
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

        public static (NDArray, NDArray, int) affinity_propagation(NDArray S, NDArray preference= null, int convergence_iter= 15, int max_iter= 200, float damping= 0.5f, bool copy= true, bool verbose= false, bool return_n_iter= false)
        {
            throw new NotImplementedException();
        }

        internal static NDArray EqualSimilaritiesAndPreferences(NDArray S, NDArray preference)
        {
            throw new NotImplementedException();
        }
    }
}
