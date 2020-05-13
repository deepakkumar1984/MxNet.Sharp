using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Calibration
{
    internal class __internals__
    {
        public (float, float) SigmoidCalibration(NDArray df, NDArray y, NDArray sample_weight= null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray) CalibrationCurve(NDArray y_true, NDArray y_prob, bool normalize= false, int n_bins= 5,
                      string strategy= "uniform")
        {
            throw new NotImplementedException();
        }
    }
}
