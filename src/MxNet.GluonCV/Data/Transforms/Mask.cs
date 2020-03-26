using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class Mask
    {
        public static NDArray Flip(NDArrayList polys, (int, int) size, bool flip_x= false, bool flip_y= false)
        {
            throw new NotImplementedException();
        }

        public static NDArray Resize(NDArrayList polys, (int, int) in_size, (int, int) out_size)
        {
            throw new NotImplementedException();
        }

        public static NDArray ToMask(NDArrayList polys, (int, int) size)
        {
            throw new NotImplementedException();
        }

        public static NDArray Fill(NDArrayList polys, NDArray bboxes, (int, int) size, bool fast_fill = true)
        {
            throw new NotImplementedException();
        }
    }
}
