using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class CenterNetDefaultTrainTransform
    {
        public CenterNetDefaultTrainTransform(int width, int height, int num_class, float scale_factor= 4, (float, float, float)? mean= null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray, NDArray, NDArray, NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
