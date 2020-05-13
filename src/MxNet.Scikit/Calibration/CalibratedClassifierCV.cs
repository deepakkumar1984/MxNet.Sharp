using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Calibration
{
    public class CalibratedClassifierCV : ClassifierMixin
    {
        public CalibratedClassifierCV(BaseEstimator base_estimator= null, string method= "sigmoid", int? cv= null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Fit(NDArray X, NDArray y, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Predict(NDArray X)
        {
            throw new NotImplementedException();
        }

        public NDArray PredictProba(NDArray X)
        {
            throw new NotImplementedException();
        }
    }
}
