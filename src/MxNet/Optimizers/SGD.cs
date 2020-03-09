using System;
using System.Linq;

namespace MxNet.Optimizers
{
    public class SGD : Optimizer
    {
        private readonly bool lazy_update;
        private readonly float momentum;

        public SGD(float momentum = 0, bool lazy_update = true)
        {
            this.momentum = momentum;
            this.lazy_update = lazy_update;
            AggregateNum = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MXNET_OPTIMIZER_AGGREGATION_SIZE"))
                ? 4
                : Convert.ToInt32(Environment.GetEnvironmentVariable("MXNET_OPTIMIZER_AGGREGATION_SIZE"));
        }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            NDArray m = null;
            if (momentum != 0)
            {
                var stype = lazy_update ? weight.SType : StorageStype.Default;
                m = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            }

            return new NDArrayDict {{"mom", m}};
        }

        public override void Update(int[] indices, NDArrayList weights, NDArrayList grads, NDArrayDict[] states)
        {
            _update_impl(indices, weights, grads, states.Select(x=>(ValueTuple.Create<NDArrayDict, NDArray>(x, null))).ToArray());
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            _update_impl(new[] {index}, weight, grad, new (NDArrayDict, NDArray)[] { (state, null) });
        }

        public override void UpdateMultiPrecision(int[] indices, NDArrayList weights, NDArrayList grads, (NDArrayDict, NDArray)[] states)
        {
            var use_multi_precision = MultiPrecision && weights[0].DataType.Name == DType.Float16.Name;
            _update_impl(indices, weights, grads, states, use_multi_precision);
        }

        public override void UpdateMultiPrecision(int index, NDArray weight, NDArray grad, (NDArrayDict, NDArray) state)
        {
            var use_multi_precision = MultiPrecision && weight.DataType.Name == DType.Float16.Name;
            _update_impl(new[] { index }, weight, grad, new (NDArrayDict, NDArray)[] { (state) }, use_multi_precision);
        }

        private void _update_impl(int[] indices, NDArrayList weights, NDArrayList grads, (NDArrayDict, NDArray)[] states,
            bool multi_precision = false)
        {
            var aggregate = true;
            weights.Zip(grads, (weight, grad) =>
            {
                aggregate = aggregate && weight.SType == StorageStype.Default && grad.SType == StorageStype.Default;
                return 0;
            });

            UpdateCount(indices);
            var lrs = GetLrs(indices);
            var wds = GetWds(indices);

            if (aggregate)
            {
                if (!multi_precision)
                {
                    if (momentum > 0)
                        weights = nd.MultiSgdMomUpdate(FlattenList(weights, grads, states), lrs,
                            wds, momentum, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1,
                            weights.Length, weights);
                    else
                        weights = nd.MultiSgdUpdate(FlattenList(weights, grads), lrs,
                            wds, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, weights.Length, weights);
                }
                else
                {
                    if (momentum > 0)
                        weights = nd.MultiMpSgdMomUpdate(FlattenList(weights, grads, states),
                            lrs, wds, momentum, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1,
                            weights.Length, weights);
                    else
                        weights = nd.MultiMpSgdUpdate(FlattenList(weights, grads, states), lrs,
                            wds, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1, weights.Length, weights);
                }
            }
            else
            {
                for (var i = 0; i < indices.Length; i++)
                {
                    var weight = weights[i];
                    var grad = grads[i];
                    var state = states[i];
                    var lr = lrs[i];
                    var wd = wds[i];

                    if (!multi_precision)
                    {
                        if (state.Item1["mom"] != null)
                            weights[i] = nd.SgdMomUpdate(weight, grad, state.Item1["mom"], lr, momentum, wd, RescaleGrad,
                                ClipGradient.HasValue ? ClipGradient.Value : -1, lazy_update);
                        else
                            weights[i] = nd.SgdMomUpdate(weight, grad, null, lr, momentum, wd, RescaleGrad,
                                ClipGradient.HasValue ? ClipGradient.Value : -1, lazy_update);
                    }
                    else
                    {
                        if (state.Item1["mom"] != null)
                            weights[i] = nd.MpSgdMomUpdate(weight, grad, state.Item1["mom"], state.Item2, lr,
                                momentum, wd, RescaleGrad, ClipGradient.HasValue ? ClipGradient.Value : -1,
                                lazy_update);
                        else
                            weights[i] = nd.MpSgdMomUpdate(weight, grad, null, state.Item2, lr, momentum, wd, RescaleGrad,
                                ClipGradient.HasValue ? ClipGradient.Value : -1, lazy_update);
                    }
                }
            }
        }
    }
}