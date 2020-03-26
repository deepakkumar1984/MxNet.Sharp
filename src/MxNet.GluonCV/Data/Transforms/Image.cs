using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class Image
    {
        public static NDArray ImResize(NDArray src, int w, int h, int interp = 1) => throw new NotImplementedException();

        public static NDArray ResizeLong(NDArray src, int size, int interp = 2) => throw new NotImplementedException();

        public static NDArray ResizeShortWithin(NDArray src, int @short, int max_size, int mult_base= 1, int interp= 2) => throw new NotImplementedException();

        public static NDArray RandomPCALighting(NDArray src, float alphastd, int[] eigval= null, int[,] eigvec= null) => throw new NotImplementedException();

        public static NDArray RandomExpand(NDArray src, float max_ratio = 4, float fill = 0, bool keep_ratio = true) => throw new NotImplementedException();

        public static NDArray RandomFlip(NDArray src, float px = 0, float py = 0, bool copy = true) => throw new NotImplementedException();

        public static NDArray RandomContain(NDArray src, (int, int) size, float fill = 0) => throw new NotImplementedException();

        public static NDArray TenCrop(NDArray src, (int, int) size) => throw new NotImplementedException();
    }
}
