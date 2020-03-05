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
                ctx: weight.context);
        }
    }
}