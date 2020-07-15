using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class Dropout : Layer
    {
        public Shape noise_shape;

        public float rate;

        public int? seed;

        public Dropout(float rate, Shape noise_shape = null, int? seed = null)
        {
            this.rate = (float)Math.Min(1.0, Math.Max(0.0, rate));
            this.noise_shape = noise_shape;
            this.seed = seed;
            this.supports_masking = true;
        }

        internal virtual Shape GetNoiseShape(KerasSymbol inputs)
        {
            if (this.noise_shape == null)
            {
                return this.noise_shape;
            }

            var symbolic_shape = K.Shape(inputs);
            for (int axis = 0; axis < noise_shape.Dimension; axis++)
            {
                var shape = noise_shape[axis];
                if(shape <= 0)
                {
                    noise_shape[axis] = symbolic_shape[axis];
                }
            }

            return noise_shape;
        }

        public override KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            bool training = kwargs.Get<bool>("training");
            foreach (var input in inputs)
            {
                Func<KerasSymbol> dropped_inputs = () => {
                    return K.Dropout(input, this.rate, noise_shape, seed: this.seed);
                };

                if ((0 < this.rate) && (this.rate < 1.0))
                {
                    var noise_shape = this.GetNoiseShape(input);
                    result.Add(K.InTrainPhase(dropped_inputs, input, training: training));
                }
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "rate",
                        this.rate},
                    {
                        "noise_shape",
                        this.noise_shape},
                    {
                        "seed",
                        this.seed}};
            var base_config = base.GetConfig();
            base_config.Update(config);
            return base_config;
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shape)
        {
            return input_shape;
        }
    }
}
