using MxNet.Keras.Layers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;
namespace MxNet.Keras
{
    public class Activations
    {
        public static KerasSymbol Softmax(KerasSymbol x, int axis = -1)
        {
            var ndim = K.NDim(x);
            if (ndim == 2)
            {
                return K.Softmax(x);
            }
            else if (ndim > 2)
            {
                var e = K.Exp(x - K.Max(x, axis: axis, keepdims: true));
                var s = K.Sum(e, axis: axis, keepdims: true);
                return e / s;
            }
            else if (ndim == 0)
            {
                // x dim is not inferred yet
                return K.Softmax(x);
            }
            else
            {
                throw new Exception($"Cannot apply softmax to a tensor that is 1D. Received input: {x}");
            }
        }

        public static KerasSymbol Elu(KerasSymbol x, float alpha = 1)
        {
            return K.Elu(x, alpha);
        }

        public static KerasSymbol Selu(KerasSymbol x)
        {
            var alpha = 1.6732632423543772f;
            var scale = 1.0507009873554805f;
            return scale * K.Elu(x, alpha);
        }

        public static KerasSymbol Softplus(KerasSymbol x)
        {
            return K.Softplus(x);
        }

        public static KerasSymbol Softsign(KerasSymbol x)
        {
            return K.Softsign(x);
        }

        public static KerasSymbol Relu(KerasSymbol x, float alpha = 0, float? max_value = null, float threshold = 0)
        {
            return K.Relu(x, alpha: alpha, max_value: max_value, threshold: threshold);
        }

        public static KerasSymbol Tanh(KerasSymbol x)
        {
            return K.Tanh(x);
        }

        public static KerasSymbol Sigmoid(KerasSymbol x)
        {
            return K.Sigmoid(x);
        }

        public static KerasSymbol HardSigmoid(KerasSymbol x)
        {
            return K.HardSigmoid(x);
        }

        public static KerasSymbol Exponential(KerasSymbol x)
        {
            return K.Exp(x);
        }

        public static KerasSymbol Linear(KerasSymbol x)
        {
            return x;
        }

        public static KerasObject Serialize(Activation activation)
        {
            return Utils.GenericUtils.SerializeKerasObject(activation);
        }
    }
}
