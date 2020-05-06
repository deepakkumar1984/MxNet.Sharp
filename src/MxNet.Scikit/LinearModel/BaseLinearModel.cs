using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.LinearModel
{
    public abstract class BaseLinearModel : RegressorMixin
    {
        public object _preprocess_data;

        public object coef_;

        public double intercept_;

        internal NDArray DecisionFunction(NDArray X)
        {
            throw new NotImplementedException();
        }

        public override NDArray Predict(NDArray X)
        {
            throw new NotImplementedException();
        }

        internal void SetIntercept(int X_offset, int y_offset, float X_scale)
        {
            throw new NotImplementedException();
        }
    }
}
