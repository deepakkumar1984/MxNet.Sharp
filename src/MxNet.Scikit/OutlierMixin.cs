using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public class OutlierMixin : BaseEstimator
    {
        internal string _estimator_type = "outlier_detector";

        public virtual NDArray FitPredict(NDArray X, NDArray y = null)
        {
            throw new NotImplementedException();
        }
    }
}
