namespace MxNet.Optimizers
{
    public class Signum : Optimizer
    {
        public Signum(float learning_rate = 0.01f, float momentum = 0.9f, float wd_lh = 0) : base(
            learning_rate: learning_rate)
        {
            Momentum = momentum;
            WdLh = wd_lh;
        }

        public float Momentum { get; set; }

        public float WdLh { get; set; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict();
            state["momentum"] = null;

            if (Momentum != 0)
                state["momentum"] = nd.Zeros(weight.Shape, weight.context, weight.DataType).ToSType(weight.SType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);

            if (state["momentum"] != null)
                weight = nd.SignumUpdate(weight, grad, state["momentum"], lr, Momentum, wd, RescaleGrad,
                    ClipGradient.HasValue ? ClipGradient.Value : -1, WdLh);
            else
                weight = nd.SignsgdUpdate(weight, grad, lr, wd, RescaleGrad,
                    ClipGradient.HasValue ? ClipGradient.Value : -1);
        }
    }
}