using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class FTML : Optimizer
    {
        public float Beta1 { get; set; }

        public float Beta2 { get; set; }

        public float Epsilon { get; set; }

        public FTML(float beta1 = 0.6f, float beta2= 0.999f, float epsilon= 1e-8f)
        {
            Beta1 = beta1;
            Beta2 = beta2;
            Epsilon = epsilon;
        }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            NDArrayDict state = new NDArrayDict();
            state["prev_d"] = nd.Zeros(weight.Shape, weight.context, weight.DataType);
            state["prev_v"] = nd.Zeros(weight.Shape, weight.context, weight.DataType);
            state["prev_z"] = nd.Zeros(weight.Shape, weight.context, weight.DataType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);
            var t = index_update_count[index];
            weight = nd.FtmlUpdate(weight, grad, state["prev_d"], state["prev_v"], state["prev_z"], lr, t, Beta1, Beta2, Epsilon, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1);
        }
    }
}
