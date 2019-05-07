using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Optimizers
{
    public abstract class BaseCls
    {
        /// <summary>
        /// Gets or sets the name of the optimizer function
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the learning rate for the optimizer.
        /// </summary>
        /// <value>
        /// The learning rate.
        /// </value>
        public float LearningRate { get; set; }

        /// <summary>
        /// Parameter that accelerates SGD in the relevant direction and dampens oscillations.
        /// </summary>
        /// <value>
        /// The momentum.
        /// </value>
        public float Momentum { get; set; }

        /// <summary>
        /// Learning rate decay over each update.
        /// </summary>
        /// <value>
        /// The decay rate.
        /// </value>
        public float DecayRate { get; set; }

        /// <summary>
        /// Fuzz factor. Lowest float value but > 0
        /// </summary>
        /// <value>
        /// The epsilon.
        /// </value>
        public float Epsilon { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseOptimizer"/> class.
        /// </summary>
        /// <param name="lr">The lr.</param>
        /// <param name="name">The name.</param>
        public BaseCls(float lr, string name)
        {
            LearningRate = lr;
            Name = name;
        }

        public abstract void Update(int iteration, int index, NDArray param, NDArray grad);

        public float GetLr(int iteration)
        {
            return LearningRate * (1 / (1 + DecayRate * iteration));
        }
    }
}
