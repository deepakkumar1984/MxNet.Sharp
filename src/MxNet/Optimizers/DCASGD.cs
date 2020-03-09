namespace MxNet.Optimizers
{
    public class DCASGD : Optimizer
    {
        public DCASGD(float momentum = 0, float lamda = 0.04f)
        {
            Momentum = momentum;
            Lamda = lamda;
        }

        public float Momentum { get; set; }

        public float Lamda { get; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict("momentum", "prev_weight");
            if (Momentum == 0)
            {
                state["momentum"] = null;
                state["prev_weight"] = weight.Copy();
            }
            else
            {
                state["momentum"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType);
                state["prev_weight"] = weight.Copy();
            }

            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);

            grad = grad * RescaleGrad;
            if (ClipGradient.HasValue)
                grad = nd.Clip(grad, -ClipGradient.Value, ClipGradient.Value);

            if (state["momentum"] != null)
            {
                state["momentum"] *= Momentum;
                state["momentum"] += -lr * (grad + wd * weight + Lamda * grad * grad * (weight - state["prev_weight"]));
            }
            else
            {
                state["momentum"] += -lr * (grad + wd * weight + Lamda * grad * grad * (weight - state["prev_weight"]));
            }

            state["prev_weight"] = weight;
            weight += state["momentum"];
        }
    }
}