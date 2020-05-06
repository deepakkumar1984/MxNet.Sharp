using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Metrics
{
    public class Regression
    {
        internal static (string, NDArray, NDArray, bool) CheckRegTargets(NDArray y_true, NDArray y_pred, NDArray multioutput, string dtype= "numeric")
        {
            throw new NotImplementedException();
        }

        public static NDArray MeanAbsoluteError(NDArray y_true, NDArray  y_pred, NDArray sample_weight= null,string  multioutput= "uniform_average")
        {
            throw new NotImplementedException();
        }

        public static NDArray MeanSquaredError(NDArray y_true, NDArray y_pred, NDArray sample_weight = null, string multioutput = "uniform_average", bool squared = true)
        {
            throw new NotImplementedException();
        }

        public static NDArray MeanSquaredLogError(NDArray y_true, NDArray y_pred, NDArray sample_weight = null, string multioutput = "uniform_average")
        {
            throw new NotImplementedException();
        }

        public static NDArray MedianAbsoluteError(NDArray y_true, NDArray y_pred, NDArray sample_weight = null, string multioutput = "uniform_average")
        {
            throw new NotImplementedException();
        }

        public static NDArray ExplainedVarianceScore(NDArray y_true, NDArray y_pred, NDArray sample_weight = null, string multioutput = "uniform_average")
        {
            throw new NotImplementedException();
        }

        public static NDArray R2Score(NDArray y_true, NDArray y_pred, NDArray sample_weight = null, string multioutput = "uniform_average")
        {
            throw new NotImplementedException();
        }

        public static NDArray MaxError(NDArray y_true, NDArray y_pred)
        {
            throw new NotImplementedException();
        }

        public static NDArray MeanTweedieDeviance(NDArray y_true, NDArray y_pred, NDArray sample_weight = null, float power = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArray MeanPoissonDeviance(NDArray y_true, NDArray y_pred, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public static NDArray MeanGammaDeviance(NDArray y_true, NDArray y_pred, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }
    }
}
