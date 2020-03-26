using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class FasterRCNNDefaultValTransform
    {
        public FasterRCNNDefaultValTransform(int @short = 600, int max_size = 1000, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public (NDArray, NDArray, NDArray) Call(NDArray src, NDArray label)
        {
            throw new NotImplementedException();
        }
    }
}
