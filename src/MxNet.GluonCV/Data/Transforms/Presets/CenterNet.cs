using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class CenterNet
    {
        public static (NDArray, NDArray) TransformTest(NDArrayList imgs, int @short, int max_size= 1024, (float, float, float)? mean= null, (float, float, float)? std =null)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) LoadTest(string[] filenames, int @short, int max_size = 1024, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public static NDArray GetPostTransform(int orig_w, int orig_h, int out_w, int out_h)
        {
            throw new NotImplementedException();
        }

        private static int GetBorder(int border, int size)
        {
            throw new NotImplementedException();
        }
    }
}
