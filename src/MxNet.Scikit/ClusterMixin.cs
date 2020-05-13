using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public abstract class ClusterMixin : BaseEstimator
    {
        internal string _estimator_type = "clusterer";

        public abstract NDArray Fit(NDArray X, NDArray y = null, NDArray sample_weight = null);

        public abstract NDArray Predict(NDArray X, NDArray sample_weight = null);

        public virtual NDArray FitPredict(NDArray X, NDArray y = null, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }
    }
}
