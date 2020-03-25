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
using System;

namespace MxNet.Initializers
{
    public class Bilinear : Initializer
    {
        public override void InitWeight(string name, ref NDArray arr)
        {
            var weight = new float[arr.Shape.Size];
            var f = (float) Math.Ceiling(arr.Shape[3] / 2f);
            var shape = arr.Shape;
            var c = (2 * f - 1 - f % 2) / (2f * f);
            for (var i = 0; i < arr.Shape.Size; i++)
            {
                var x = i % arr.Shape[3];
                var y = Math.Floor(Convert.ToDouble(i / shape[3])) % shape[2];
                weight[i] = (1 - Math.Abs(x / f - c)) * (1 - (float) Math.Abs(y / f - c));
            }

            arr.SyncCopyFromCPU(weight);
        }
    }
}