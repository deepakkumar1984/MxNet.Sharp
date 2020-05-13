using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Calibration
{
    internal class _CalibratedClassifier
    {
        public _CalibratedClassifier(BaseEstimator base_estimator = null, string method = "sigmoid", int? classes = null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray) PreProc(NDArray X)
        {
            throw new NotImplementedException();
        }

        public NDArray Fit(NDArray X, NDArray y, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public NDArray PredictProba(NDArray X)
        {
            throw new NotImplementedException();
        }
    }
}
