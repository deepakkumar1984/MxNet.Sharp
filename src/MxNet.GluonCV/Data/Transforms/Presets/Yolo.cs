using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class Yolo
    {
        public static (NDArrayList, string[]) TransformTest(NDArrayList imgs, int @short = 416, int max_size = 1024, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public static (NDArrayList, string[]) LoadTest(string[] filenames, int @short = 416, int max_size = 1024, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }
    }
}
