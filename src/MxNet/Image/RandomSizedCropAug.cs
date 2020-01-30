using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class RandomSizedCropAug : Augmenter
    {
        public (int, int) Size { get; set; }

        public (float, float) Area { get; set; }

        public (float, float) Ratio { get; set; }

        public ImgInterp Interp { get; set; }

        public RandomSizedCropAug((int, int) size, (float, float) area, (float, float) ratio, ImgInterp interp = ImgInterp.Area_Based)
        {
            Size = size;
            Interp = interp;
            Area = area;
            Ratio = ratio;
        }

        public override NDArray Call(NDArray src)
        {
            return Img.RandomSizeCrop(src, Size, Area, Ratio, Interp).Item1;
        }
    }
}
