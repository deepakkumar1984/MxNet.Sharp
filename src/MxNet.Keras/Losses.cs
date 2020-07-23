using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras
{
    public class Losses
    {
        public static KerasSymbol MeanSquaredError(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Mean(K.Square(y_pred - y_true), axis: -1);
        }

        public static KerasSymbol MeanAbsoluteError(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Mean(K.Abs(y_pred - y_true), axis: -1);
        }

        public static KerasSymbol MeanAbsolutePercentageError(KerasSymbol y_true, KerasSymbol y_pred)
        {
            var diff = K.Abs((y_true - y_pred) / K.Clip(K.Abs(y_true), K.Epsilon(), null));
            return 100 * K.Mean(diff, axis: -1);
        }

        public static KerasSymbol MeanSquaredLogrithmicError(KerasSymbol y_true, KerasSymbol y_pred)
        {
            var first_log = K.Log(K.Clip(y_pred, K.Epsilon(), null) + 1);
            var second_log = K.Log(K.Clip(y_true, K.Epsilon(), null) + 1);
            return K.Mean(K.Square(first_log - second_log), axis: -1);
        }

        public static KerasSymbol SquaredHinge(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Mean(K.Square(K.Maximum(1 - y_true * y_pred, 0)), axis: -1);
        }

        public static KerasSymbol Hinge(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Mean(K.Maximum(1 - y_true * y_pred, 0), axis: -1);
        }

        public static KerasSymbol CategorialHinge(KerasSymbol y_true, KerasSymbol y_pred)
        {
            var pos = K.Sum(y_true * y_pred, axis: -1);
            var neg = K.Max((1 - y_true) * y_pred, axis: -1);
            return K.Maximum(0, neg - pos + 1);
        }

        public static KerasSymbol Logcosh(KerasSymbol y_true, KerasSymbol y_pred)
        {
            var x = y_pred - y_true;
            var _logcosh = x + K.Softplus(-2 * x) - (float)Math.Log(2);
            return K.Mean(_logcosh, axis: -1);
        }

        public static KerasSymbol CategoricalCrossentropy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.CategoricalCrossentropy(y_true, y_pred);
        }

        public static KerasSymbol SparseCategoricalCrossentropy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.SparseCategoricalCrossentropy(y_true, y_pred);
        }

        public static KerasSymbol MultiHotSparseCategoricalCrossentropy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.MultiHotSparseCategoricalCrossentropy(y_true, y_pred);
        }

        public static KerasSymbol BinaryCrossentropy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.BinaryCrossentropy(y_true, y_pred);
        }

        public static KerasSymbol KullbackLeiblerDivergence(KerasSymbol y_true, KerasSymbol y_pred)
        {
            y_true = K.Clip(y_true, K.Epsilon(), 1);
            y_pred = K.Clip(y_pred, K.Epsilon(), 1);
            return K.Sum(y_true * K.Log(y_true / y_pred), axis: -1);
        }

        public static KerasSymbol Poisson(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Mean(y_pred - y_true * K.Log(y_pred + K.Epsilon()), axis: -1);
        }

        public static KerasSymbol CosineProximity(KerasSymbol y_true, KerasSymbol y_pred)
        {
            y_true = K.L2Normalize(y_true, axis: -1);
            y_pred = K.L2Normalize(y_pred, axis: -1);
            return -K.Sum(y_true * y_pred, axis: -1);
        }

        public static Func<KerasSymbol, KerasSymbol, KerasSymbol> Get(string name)
        {
            switch (name)
            {
                case "mean_squared_error":
                    return MeanSquaredError;
                case "mean_absolute_error":
                    return MeanAbsoluteError;
                case "mean_absolute_percentage_error":
                    return MeanAbsolutePercentageError;
                case "mean_squared_logarithmic_error":
                    return MeanSquaredLogrithmicError;
                case "squared_hinge":
                    return SquaredHinge;
                case "hinge":
                    return Hinge;
                case "categorial_hinge":
                    return CategorialHinge;
                case "log_cosh":
                    return Logcosh;
                case "binary_crossentropy":
                    return BinaryCrossentropy;
                case "categorical_crossentropy":
                    return CategoricalCrossentropy;
                case "sparse_categorical_crossentropy":
                    return SparseCategoricalCrossentropy;
                case "multi_hot_sparse_categorical_crossentropy":
                    return MultiHotSparseCategoricalCrossentropy;
                case "kullbackleibler_divergence":
                    return KullbackLeiblerDivergence;
                case "poisson":
                    return Poisson;
                case "cosine_proximity":
                    return CosineProximity;
                default:
                    throw new Exception("Invalid loss function");
            }
        }
    }
}
