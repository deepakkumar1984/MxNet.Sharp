using MxNet.Image;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class CenterCrop : Block
    {
        private readonly ImgInterp _interpolation;
        private readonly (int, int) _size;

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