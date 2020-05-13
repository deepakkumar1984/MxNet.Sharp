using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Calibration
{
    public class _SigmoidCalibration : RegressorMixin
    {
        public override NDArray Fit(NDArray X, NDArray y, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Predict(NDArray X)
        {
            throw new NotImplementedException();
        }
    }
}
