using System;

namespace MxNet.Optimizers
{
    public class Nadam : Optimizer
    {
        public Nadam(float learning_rate = 0.001f, float beta1 = 0.9f, float beta2 = 0.999f, float epsilon = 1e-8f,
            float schedule_decay = 0.004f) : base(learning_rate: learning_rate)
        {
            Beta1 = beta1;
            Beta2 = beta2;
            Epsilon = epsilon;
            ScheduleDecay = schedule_decay;
            MSchedule = 1;
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

        public float Epsilon { get; set; }

        public float ScheduleDecay { get; set; }

        public float MSchedule { get; set; }

        public override NDArrayDict CreateState(int index, NDArray weight)
        {
            var state = new NDArrayDict("mean", "variance");
            state["mean"] = nd.Zeros(weight.Shape, weight.context, weight.DataType).ToSType(weight.SType);
            state["variance"] = nd.Zeros(weight.Shape, weight.context, weight.DataType).ToSType(weight.SType);
            return state;
        }

        public override void Update(int index, NDArray weight, NDArray grad, NDArrayDict state)
        {
            UpdateCount(index);
            var lr = GetLr(index);
            var wd = GetWd(index);

            var t = index_update_count[index];
            grad = grad * RescaleGrad + wd * weight;
            if (ClipGradient.HasValue)
                grad = nd.Clip(grad, -ClipGradient.Value, ClipGradient.Value);

            var momentum_t = Beta1 * (1 - 0.5f * (float) Math.Pow(0.96, t * ScheduleDecay));
            var momentum_t_1 = Beta1 * (1 - 0.5f * (float) Math.Pow(0.96, (t + 1) * ScheduleDecay));
            MSchedule = MSchedule * momentum_t;
            var m_schedule_next = MSchedule * momentum_t_1;
            var m_t = state["mean"];
            var v_t = state["variance"];

            m_t *= Beta1;
            m_t += (1 - Beta1) * grad;
            v_t *= Beta2;
            v_t += (1 - Beta2) * grad * grad;

            var grad_prime = grad / (1 - MSchedule);
            var m_t_prime = m_t / (1 - m_schedule_next);
            var v_t_prime = v_t / (1 - (float) Math.Pow(Beta2, t));
            var m_t_bar = (1 - momentum_t) * grad_prime + momentum_t_1 * m_t_prime;

            weight -= lr * m_t_bar / (nd.Sqrt(v_t_prime) + Epsilon);
        }
    }
}