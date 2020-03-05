namespace MxNet.Optimizers
{
    public class Ftlr : Optimizer
    {
        public Ftlr(float lamda1 = 0.1f, float learning_rate = 0.1f, float beta = 1) : base(
            learning_rate: learning_rate)
        {
            Lamda1 = lamda1;
            Beta = beta;
        }

        public float Lamda1 { get; set; }

        public float Beta { get; set; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict();
            state["z"] = nd.Zeros(weight.Shape, weight.context, weight.DataType);
            state["n"] = nd.Zeros(weight.Shape, weight.context, weight.DataType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);
            var t = index_update_count[index];
            weight = nd.FtrlUpdate(weight, grad, state["z"], state["n"], lr, Lamda1, Beta, wd, RescaleGrad,
                ClipGradient.HasValue ? ClipGradient.Value : -1);
        }
    }
}