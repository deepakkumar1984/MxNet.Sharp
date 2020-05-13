using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public abstract class ClassifierMixin : BaseEstimator
    {
        internal string _estimator_type = "classifier";

        public bool MultiOutput { get; set; }

        public abstract NDArray Fit(NDArray X, NDArray y, NDArray sample_weight = null);

        public abstract NDArray Predict(NDArray X);

        public virtual NDArray Score(NDArray X, NDArray y, NDArray sample_weight= null)
        {
            throw new NotImplementedException();
        }
    }
}
