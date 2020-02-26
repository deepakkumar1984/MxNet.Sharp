using MxNet.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class CropResize : HybridBlock
    {
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private (int, int)? _size;
        private ImgInterp? _interpolation;

        public CropResize(int x, int y, int width, int height, (int, int)? size= null, ImgInterp? interpolation= null)
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
                    output = nd.Image.Resize(output, new Shape(_size.Value.Item1, _size.Value.Item2), false, (int)_interpolation);
            }
            else
            {
                output = sym.Image.Crop(x, _x, _y, _width, _height);
                if (_size.HasValue)
                    output = sym.Image.Resize(output, new Shape(_size.Value.Item1, _size.Value.Item2), false, (int)_interpolation);
            }

            return output;
        }
    }
}
