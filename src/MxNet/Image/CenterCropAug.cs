using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class CenterCropAug : Augmenter
    {
        public (int, int) Size { get; set; }

        public ImgInterp Interp { get; set; }

        public CenterCropAug((int, int) size, ImgInterp interp = ImgInterp.Area_Based)
        {
            Size = size;
            Interp = interp;
        }

        public override NDArray Call(NDArray src)
        {
            return Img.CenterCrop(src, Size, Interp).Item1;
        }
    }
}
