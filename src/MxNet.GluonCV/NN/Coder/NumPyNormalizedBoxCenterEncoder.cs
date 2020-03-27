using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class NumPyNormalizedBoxCenterEncoder
    {
        public NumPyNormalizedBoxCenterEncoder(float[] stds = null, float[] mean = null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray) Call(NDArray samples, NDArray matches, NDArray anchors, NDArray refs)
        {
            throw new NotImplementedException();
        }
    }
}
