using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class CenterNetDefaultValTransform
    {
        public CenterNetDefaultValTransform(int width, int height, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
