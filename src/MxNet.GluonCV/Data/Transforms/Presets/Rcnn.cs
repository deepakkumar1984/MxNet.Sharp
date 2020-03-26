using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class RCnn
    {
        public static (NDArrayList, string[]) TransformTest(NDArrayList imgs, int @short = 600, int max_size = 1000, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public static (NDArrayList, string[]) LoadTest(string[] filenames, int @short = 600, int max_size = 1000, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }
    }
}
