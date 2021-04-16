/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
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

        public override NDArrayOrSymbolList HybridForward(NDArrayOrSymbolList args)
        {
            var x = args[0];
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