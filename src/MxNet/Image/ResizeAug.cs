using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class ResizeAug : Augmenter
    {
        public int Size { get; set; }

        public ImgInterp Interp { get; set; }

        public ResizeAug(int size, ImgInterp interp = ImgInterp.Area_Based)
        {
            Size = size;
            Interp = interp;
        }

        public override NDArray Call(NDArray src)
        {
            return Img.ResizeShort(src, Size, Interp);
        }
    }
}
