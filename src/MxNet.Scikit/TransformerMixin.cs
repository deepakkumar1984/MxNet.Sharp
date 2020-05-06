using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public abstract class TransformerMixin : BaseEstimator
    {
        public virtual NDArray FitTransform(NDArray X, NDArray y = null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public abstract NDArray Fit(NDArray X, NDArray y = null, FuncArgs fit_params = null);

        public abstract NDArray Transform(NDArray X);
    }
}
