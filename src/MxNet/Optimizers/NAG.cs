using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class NAG : Optimizer
    {
        public float Momentum { get; }

        public NAG(float momentum = 0)
        {
            Momentum = momentum;
        }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            NDArrayDict state = new NDArrayDict("momentum");
            if(Momentum != 0)
                state["momentum"] = nd.Zeros(weight.Shape, weight.context, weight.DataType);

            return state;
        }

        public override (NDArrayDict, NDArray) CreateStateMultiPrecision(int index, NDArray weight)
        {
            return base.CreateStateMultiPrecision(index, weight);
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            _update_impl(index, weight, grad, state, false);
        }

        private void _update_impl(int index, NDArray weight, NDArray grad, NDArrayDict state, bool multi_precision = false)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);

            if(!multi_precision)
            {
                if (state["momentum"] != null)
                    weight = nd.NAGMomUpdate(weight, grad, state["momentum"], lr, Momentum, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1);
                else
                    weight = nd.SgdUpdate(weight, grad, lr, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1);
            }
            else
            {
                if (state["momentum"] != null)
                    weight = nd.MPNAGMomUpdate(weight, grad, state["momentum"], state["weight32"], lr, Momentum, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1);
                else
                    weight = nd.MpSgdUpdate(weight, grad, state["weight32"], lr, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1);
            }
        }

        public override void UpdateMultiPrecision(int index, NDArray weight, NDArray grad, (NDArrayDict, NDArray) state)
        {
            base.UpdateMultiPrecision(index, weight, grad, state);
        }
    }
}
