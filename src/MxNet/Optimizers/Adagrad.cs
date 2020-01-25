using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class Adagrad : Optimizer
    {
        private readonly Dictionary<int, NDArray> accumulators;


        public Adagrad(float lr = 0.01f, float decayRate = 0, float epsilon = 1e-07f) : base(lr, "adagrad")
        {
            DecayRate = decayRate;
            Epsilon = epsilon;

            accumulators = new Dictionary<int, NDArray>();
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad)
        {
            if (DecayRate > 0)
            {
                LearningRate = LearningRate * (1 / (1 + DecayRate * iteration));
            }

            if (!accumulators.ContainsKey(index))
            {
                accumulators[index] = nd.Zeros(param.Shape);
            }

            accumulators[index] = accumulators[index] + nd.Square(grad);
            param = param - (LearningRate * grad / nd.Sqrt(accumulators[index] + Epsilon));
        }
    }
}
