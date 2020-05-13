using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.LinearModel
{
    public class LinearRegression : BaseLinearModel
    {
        public LinearRegression(bool fit_intercept= true, bool normalize= false, bool copy_X= true, int n_jobs= 1)
        {
            throw new NotImplementedException();
        }

        public override NDArray Fit(NDArray X, NDArray y, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }
    }
}
