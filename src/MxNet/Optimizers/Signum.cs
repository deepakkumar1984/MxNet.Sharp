using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class Signum : Optimizer
    {
        private readonly Dictionary<int, NDArray> moments;

        public Signum(float lr = 0.01f, float momentum = 0, float decayRate = 0) : base(lr, "adam")
        {
            moments = new Dictionary<int, NDArray>();
            DecayRate = decayRate;
            Momentum = momentum;
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad)
        {
            if (!moments.ContainsKey(index))
                moments[index] = nd.Zeros(param.Shape);

            nd.SignumUpdate(param, grad, moments[index], LearningRate, Momentum, DecayRate);
        }
    }
}
