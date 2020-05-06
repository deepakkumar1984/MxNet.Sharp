using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public class ClusterMixin : BaseEstimator
    {
        internal string _estimator_type = "clusterer";

        public virtual NDArray FitPredict(NDArray X, NDArray y = null)
        {
            throw new NotImplementedException();
        }
    }
}
