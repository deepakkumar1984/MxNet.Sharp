using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers.Core
{
    public class Activation : Layer
    {
        public string activation;

        private FuncArgs args;

        public Activation(string activation, FuncArgs kwargs)
        {
            this.supports_masking = true;
            this.activation = activation;
            this.args = kwargs;
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                result.Add(_Call(input));
            }

            return result.ToArray();
        }

        private KerasSymbol _Call(KerasSymbol x)
        {
            switch (activation)
            {
                case "elu":
                    return Activations.Elu(x);
                case "exp":
                    return Activations.Exponential(x);
                case "hard_sigmoid":
                    return Activations.HardSigmoid(x);
                case "linear":
                    return Activations.Linear(x);
                case "relu":
                    return Activations.Relu(x);
                case "selu":
                    return Activations.Selu(x);
                case "sigmoid":
                    return Activations.Sigmoid(x);
                case "softmax":
                    return Activations.Softmax(x);
                case "softplus":
                    return Activations.Softplus(x);
                case "softsign":
                    return Activations.Softsign(x);
                case "tanh":
                    return Activations.Tanh(x);
                default:
                    break;
            }

            return Activations.Linear(x);
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "activation",
                        this.activation}};
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
