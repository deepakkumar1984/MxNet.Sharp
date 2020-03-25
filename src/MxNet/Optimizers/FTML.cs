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
namespace MxNet.Optimizers
{
    public class FTML : Optimizer
    {
        public FTML(float beta1 = 0.6f, float beta2 = 0.999f, float epsilon = 1e-8f)
        {
            Beta1 = beta1;
            Beta2 = beta2;
            Epsilon = epsilon;
        }

        public float Beta1 { get; set; }

        public float Beta2 { get; set; }

        public float Epsilon { get; set; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict();
            state["prev_d"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType);
            state["prev_v"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType);
            state["prev_z"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);
            var t = index_update_count[index];
            weight = nd.FtmlUpdate(weight, grad, state["prev_d"], state["prev_v"], state["prev_z"], lr, t, Beta1, Beta2,
                Epsilon, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1);
        }
    }
}