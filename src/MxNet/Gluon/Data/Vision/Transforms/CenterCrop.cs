using MxNet.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class CenterCrop : Block
    {
        private (int, int) _size;
        private ImgInterp _interpolation;

        public CenterCrop((int, int) size, ImgInterp interpolation = ImgInterp.Bilinear) : base(null, null)
        {
            _size = size;
            _interpolation = interpolation;
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return Img.CenterCrop(x, _size, _interpolation).Item1;
        }
    }
}
