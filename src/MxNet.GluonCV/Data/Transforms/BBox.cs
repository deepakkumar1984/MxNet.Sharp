using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class BBox
    {
        public static NDArray Crop(NDArray bbox, (int, int, int, int)? crop_box = null, bool allow_outside_center = true) => throw new NotImplementedException();

        public static NDArray Flip(NDArray bbox, (int, int)? size = null, bool flip_x = false, bool flip_y = false) => throw new NotImplementedException();

        public static NDArray Resize(NDArray bbox, (int, int) in_size, (int, int) out_size) => throw new NotImplementedException();

        public static NDArray Translate(NDArray bbox, int x_offset = 0, int y_offset = 0) => throw new NotImplementedException();

        public static NDArray AffineTransform(NDArray pt, NDArray t) => throw new NotImplementedException();

        public static int[] GetRotDir(float[] src_point, float rot_rad) => throw new NotImplementedException();

        public static int[] Get3rdPoint(float[] a, float[] b) => throw new NotImplementedException();

        public static NDArray GetAffineTransform(float[] center, float scale, float rot, (int, int) output_size, NDArray shift = null, bool inv=false) => throw new NotImplementedException();
    }
}
