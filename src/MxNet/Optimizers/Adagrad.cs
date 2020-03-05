namespace MxNet.Optimizers
{
    public class AdaGrad : Optimizer
    {
        public AdaGrad(float epsilon = 1e-07f)
        {
            Epsilon = epsilon;
        }

        public float Epsilon { get; set; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict("history");
            state["history"] = nd.Zeros(weight.Shape, weight.context, weight.DataType).ToSType(weight.SType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);
            var is_sparse = grad.SType == StorageStype.RowSparse;
            var history = state["history"];

            if (is_sparse)
            {
                nd.SparseAdagradUpdate(weight, grad, history, lr, Epsilon, wd, RescaleGrad,
                    ClipGradient.HasValue ? ClipGradient.Value : -1);
            }
            else
            {
                grad = grad * RescaleGrad;
                if (ClipGradient.HasValue)
                    grad = nd.Clip(grad, -ClipGradient.Value, ClipGradient.Value);

                history += nd.Square(grad);
                var div = grad / nd.Sqrt(history + Epsilon);
                weight += (div + weight * wd) * -lr;
            }
        }
    }
}