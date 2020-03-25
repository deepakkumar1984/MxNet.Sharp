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

namespace MxNet.Optimizers
{
    public class SGLD : Optimizer
    {
        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            return new NDArrayDict();
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);
            grad = grad * RescaleGrad;
            if (ClipGradient.HasValue)
                grad = nd.Clip(grad, -ClipGradient.Value, ClipGradient.Value);

            weight += -lr / 2 * (grad + wd * weight);
            weight += nd.Random.Normal(0, (float) Math.Sqrt(lr), weight.Shape, dtype: weight.DataType,
                ctx: weight.Context);
        }
    }
}