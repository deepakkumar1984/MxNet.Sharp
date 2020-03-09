using System;

namespace MxNet.Optimizers
{
    public class Adamax : Optimizer
    {
        public Adamax(float learning_rate = 0.00f, float beta1 = 0.9f, float beta2 = 0.999f) : base(
            learning_rate: learning_rate)
        {
            Beta1 = beta1;
            Beta2 = beta2;
        }

        /// <summary>
        ///     Gets or sets the beta 1 value.
        /// </summary>
        /// <value>
        ///     The beta1.
        /// </value>
        public float Beta1 { get; set; }

        /// <summary>
        ///     Gets or sets the beta 2 value.
        /// </summary>
        /// <value>
        ///     The beta2.
        /// </value>
        public float Beta2 { get; set; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict("mean", "variance");
            state["mean"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            state["variance"] = nd.Zeros(weight.Shape, weight.Context, weight.DataType).ToSType(weight.SType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);

            var t = index_update_count[index];
            lr /= 1 - (float) Math.Pow(Beta1, t);
            grad = grad * RescaleGrad + wd * weight;
            if (ClipGradient.HasValue)
                grad = nd.Clip(grad, -ClipGradient.Value, ClipGradient.Value);

            var m_t = state["mean"];
            var u_t = state["variance"];
            m_t *= Beta1;
            m_t += (1 - Beta1) * grad;
            u_t = nd.Maximum(Beta2 * u_t, nd.Abs(grad));

            weight -= lr * m_t / u_t;
        }
    }
}