using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.LinearModel
{
    public class LinearClassifierMixin : ClassifierMixin
    {
        public NDArray DecisionFunction(NDArray X)
        {
            throw new NotImplementedException();
        }

        public virtual NDArray Predict(NDArray X)
        {
            throw new NotImplementedException();
        }

        internal NDArray PredictProbaLr(NDArray X)
        {
            throw new NotImplementedException();
        }
    }
}
