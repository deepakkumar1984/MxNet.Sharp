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
namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomColorJitter : HybridBlock
    {
        private readonly float _brightness;
        private readonly float _contrast;
        private readonly float _hue;
        private readonly float _saturation;

        public RandomColorJitter(float brightness = 0, float contrast = 0, float saturation = 0, float hue = 0)
        {
            _brightness = brightness;
            _contrast = contrast;
            _saturation = saturation;
            _hue = hue;
        }

        public override NDArrayOrSymbolList HybridForward(NDArrayOrSymbolList args)
        {
            var x = args[0];
            if (x.IsNDArray)
                return nd.Image.RandomColorJitter(x, _brightness, _contrast, _saturation, _hue);

            return sym.Image.RandomColorJitter(x, _brightness, _contrast, _saturation, _hue);
        }
    }
}