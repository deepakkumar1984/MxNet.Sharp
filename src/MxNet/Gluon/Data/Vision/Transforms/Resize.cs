using MxNet.Image;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class Resize : HybridBlock
    {
        private readonly ImgInterp _interpolation;
        private readonly bool _keep_ratio;
        private readonly (int, int) _size;

        public Resize((int, int) size, bool keep_ratio = false, ImgInterp interpolation = ImgInterp.Bilinear)
        {
            _size = size;
            _keep_ratio = keep_ratio;
            _interpolation = interpolation;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Image.Resize(x, new Shape(_size.Item1, _size.Item2), _keep_ratio, (int) _interpolation);

            return sym.Image.Resize(x, new Shape(_size.Item1, _size.Item2), _keep_ratio, (int) _interpolation);
        }
    }
}