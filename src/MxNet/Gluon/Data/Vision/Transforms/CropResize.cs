using MxNet.Image;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class CropResize : HybridBlock
    {
        private readonly int _height;
        private readonly ImgInterp? _interpolation;
        private (int, int)? _size;
        private readonly int _width;
        private readonly int _x;
        private readonly int _y;

        public CropResize(int x, int y, int width, int height, (int, int)? size = null, ImgInterp? interpolation = null)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _size = size;
            _interpolation = interpolation;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol output = null;
            if (x.IsNDArray)
            {
                output = nd.Image.Crop(x, _x, _y, _width, _height);
                if (_size.HasValue)
                    output = nd.Image.Resize(output, new Shape(_size.Value.Item1, _size.Value.Item2), false,
                        (int) _interpolation);
            }
            else
            {
                output = sym.Image.Crop(x, _x, _y, _width, _height);
                if (_size.HasValue)
                    output = sym.Image.Resize(output, new Shape(_size.Value.Item1, _size.Value.Item2), false,
                        (int) _interpolation);
            }

            return output;
        }
    }
}