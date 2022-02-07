﻿/*****************************************************************************
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
    public class RandomFlipLeftRight : HybridBlock
    {
        private float p;

        public RandomFlipLeftRight(float p)
        {
            this.p = p;
        }

        public override NDArrayOrSymbolList HybridForward(NDArrayOrSymbolList args)
        {
            if (p <= 0)
                return args;

            var x = args[0];
            if (p >= 1)
            {
                if (x.IsNDArray)
                    return nd.Image.FlipLeftRight(x);

                return sym.Image.FlipLeftRight(x);
            }
            else
            {
                if (x.IsNDArray)
                    return nd.Image.RandomFlipLeftRight(x);

                return sym.Image.RandomFlipLeftRight(x);
            }
        }
    }
}