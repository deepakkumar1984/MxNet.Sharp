using MxNet.SciKit.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public abstract class RegressorMixin : BaseEstimator
    {
        public RegressorMixin()
        {
            _estimator_type = "regressor";
        }

        public bool MultiOutput
        {
            get
            {
                if (tags.ContainsKey("multioutput"))
                    return (bool)tags["multioutput"];

                return false;
            }
            set
            {
                tags.Add("multioutput", value);
            }
        }

        public abstract NDArray Fit(NDArray X, NDArray y);

        public abstract NDArray Predict(NDArray X);

        public virtual NDArray Score(NDArray X, NDArray y, NDArray sample_weight = null)
        {
            var y_pred = this.Predict(X);
            // XXX: Remove the check in 0.23
            var (y_type, _, _, _) = Regression.CheckRegTargets(y, y_pred, null);
            if (y_type == "continuous-multioutput")
            {
                Logger.Warning("The default value of multioutput (not exposed in score method) will change from 'variance_weighted' to 'uniform_average' in 0.23 to keep consistent with 'metrics.r2_score'. To specify the default value manually and avoid the warning, please either call 'metrics.r2_score' directly or make a custom scorer with 'metrics.make_scorer' (the built-in scorer 'r2' uses multioutput='uniform_average').");
            }

            return Regression.R2Score(y, y_pred, sample_weight: sample_weight, multioutput: "variance_weighted");
        }
    }
}
