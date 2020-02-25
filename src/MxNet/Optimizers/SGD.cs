using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Optimizers
{
    public class SGD : Optimizer
    {
        private float momentum;
        private bool lazy_update;

        public SGD(float momentum = 0, bool lazy_update = true)
        {
            this.momentum = momentum;
            this.lazy_update = lazy_update;
            this.AggregateNum = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MXNET_OPTIMIZER_AGGREGATION_SIZE")) ? 4 :
                                    Convert.ToInt32(Environment.GetEnvironmentVariable("MXNET_OPTIMIZER_AGGREGATION_SIZE"));
        }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            NDArray m = null;
            if(momentum != 0)
            {
                var stype = lazy_update ? weight.SType : StorageStype.Default;
                m = nd.Zeros(weight.Shape, weight.context, weight.DataType).ToSType(weight.SType);
            }

            return new NDArrayDict() { { "mom", m } };
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            _update_impl(new int[] { index }, weight, grad, (state, null), false);
        }

        public override void UpdateMultiPrecision(int index, NDArray weight, NDArray grad, (NDArrayDict, NDArray) state)
        {
            bool use_multi_precision = MultiPrecision && weight.DataType.Name == DType.Float16.Name;
            _update_impl(new int[] { index }, weight, grad, state, true);
        }

        private void _update_impl(int[] indices, NDArrayList  weights, NDArrayList  grads, (NDArrayDict, NDArray) states, bool multi_precision= false)
        {
            bool aggregate = true;
            Enumerable.Zip(weights, grads, (weight, grad) => {
                aggregate = (aggregate && weight.SType == StorageStype.Default && grad.SType == StorageStype.Default);
                return 0;
            });

            UpdateCount(indices);
            var lrs = GetLrs(indices);
            var wds = GetWds(indices);

            if(aggregate)
            {
                if (!multi_precision)
                {
                    if (momentum > 0)
                        weights = nd.MultiSgdMomUpdate(FlattenList(weights, grads, states.Item1.Values.ToArray()), lrs, wds, momentum, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, weights.Length);
                    else
                        weights = nd.MultiSgdUpdate(FlattenList(weights, grads, states.Item1.Values.ToArray()), lrs, wds, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, weights.Length);
                }
                else
                {
                    if (momentum > 0)
                        weights = nd.MultiMpSgdMomUpdate(FlattenList(weights, grads, states.Item1.Values.ToArray()), lrs, wds, momentum, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, weights.Length);
                    else
                        weights = nd.MultiMpSgdUpdate(FlattenList(weights, grads, states.Item1.Values.ToArray()), lrs, wds, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, weights.Length);
                }
            }
            else
            {
                for(int i = 0; i < indices.Length; i++)
                {
                    var weight = weights[i];
                    var grad = grads[i];
                    
                    var lr = lrs[i];
                    var wd = wds[i];

                    if(!multi_precision)
                    {
                        var state = states.Item1.Count > i ? states.Item1.Values.ToArray()[i] : null;
                        if (state != null)
                        {
                            weight = nd.SgdMomUpdate(weight, grad, state, lr, momentum, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, lazy_update);
                        }
                        else
                        {
                            weight = nd.SgdMomUpdate(weight, grad, null, lr, momentum, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, lazy_update);
                        }
                    }
                    else
                    {
                        if (states.Item1.Count > 0)
                        {
                            weight = nd.MpSgdMomUpdate(weight, grad, states.Item1.First().Value, states.Item2, lr, momentum, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, lazy_update);
                        }
                        else
                        {
                            weight = nd.MpSgdMomUpdate(weight, grad, null, states.Item2, lr, momentum, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, lazy_update);
                        }
                    }
                }
            }
        }
    }
}
