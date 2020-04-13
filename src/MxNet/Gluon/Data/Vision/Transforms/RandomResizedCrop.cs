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
using OpenCvSharp;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomResizedCrop : Block
    {
        private readonly InterpolationFlags _interpolation;
        private readonly (float, float) _ratio;
        private readonly (float, float) _scale;
        private readonly (int, int) _size;

        public RandomResizedCrop((int, int) size, (float, float)? scale = null, (float, float)? ratio = null,
            InterpolationFlags interpolation = InterpolationFlags.Linear) : base(null, null)
        {
            _size = size;
            _scale = scale.HasValue ? scale.Value : (0.08f, 1.0f);
            _ratio = ratio.HasValue ? ratio.Value : (3.0f / 4.0f, 4.0f / 3.0f);
            _interpolation = interpolation;
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return Img.RandomSizeCrop(x, _size, _scale, _ratio, _interpolation).Item1;
        }
    }
}