using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public class DensityMixin : BaseEstimator
    {
        internal string _estimator_type = "DensityEstimator";

        public virtual NDArray Score(NDArray X, NDArray y = null)
        {
            throw new NotImplementedException();
        }
    }
}
