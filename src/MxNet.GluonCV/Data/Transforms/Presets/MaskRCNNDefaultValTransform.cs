using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class MaskRCNNDefaultValTransform
    {
        public MaskRCNNDefaultValTransform(int @short = 600, int max_size = 1000, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray, NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
