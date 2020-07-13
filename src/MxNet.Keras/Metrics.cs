using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras
{
    public class Metrics
    {
        public static KerasSymbol BinaryAccuracy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Mean(K.Equal(y_true, K.Round(y_pred)), axis: -1);
        }

        public static KerasSymbol CategoricalAccuracy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Cast(K.Equal(K.Argmax(y_true, axis: -1), K.Argmax(y_pred, axis: -1)), K.FloatX());
        }

        public static KerasSymbol SparseCategoricalAccuracy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Cast(K.Equal(K.Flatten(y_true), K.Cast(K.Argmax(y_pred, axis: -1), K.FloatX())), K.FloatX());
        }

        public static KerasSymbol MultiHotSparseCategoricalAccuracy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Cast(K.Equal(K.Max(y_true, axis: -1), K.Cast(K.Argmax(y_pred, axis: -1), K.FloatX())), K.FloatX());
        }

        public static KerasSymbol TopKCategoricalAccuracy(KerasSymbol y_true, KerasSymbol y_pred, int k = 5)
        {
            return K.Mean(K.InTopK(y_pred, K.Argmax(y_true, axis: -1), k), axis: -1);
        }

        public static KerasSymbol TopKCategoricalAccuracy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Mean(K.InTopK(y_pred, K.Argmax(y_true, axis: -1), 5), axis: -1);
        }

        public static KerasSymbol SparseTopKCategoricalAccuracy(KerasSymbol y_true, KerasSymbol y_pred, int k = 5)
        {
            return K.Mean(K.InTopK(y_pred, K.Cast(K.Flatten(y_true), "int32"), k), axis: -1);
        }

        public static KerasSymbol SparseTopKCategoricalAccuracy(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return K.Mean(K.InTopK(y_pred, K.Cast(K.Flatten(y_true), "int32"), 5), axis: -1);
        }

        public static KerasSymbol MSE(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return Losses.MeanSquaredError(y_true, y_pred);
        }

        public static KerasSymbol MAE(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return Losses.MeanAbsoluteError(y_true, y_pred);
        }

        public static KerasSymbol MSPE(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return Losses.MeanAbsolutePercentageError(y_true, y_pred);
        }

        public static KerasSymbol MSLE(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return Losses.MeanSquaredLogrithmicError(y_true, y_pred);
        }

        public static KerasSymbol Cosine(KerasSymbol y_true, KerasSymbol y_pred)
        {
            return Losses.CosineProximity(y_true, y_pred);
        }

        public static Func<KerasSymbol, KerasSymbol, KerasSymbol> Get(string name)
        {
            switch (name.ToLower())
            {
                case "binary_accuracy":
                    return BinaryAccuracy;
                case "categorical_accuracy":
                    return CategoricalAccuracy;
                case "sparse_categorical_accuracy":
                    return SparseCategoricalAccuracy;
                case "multi_hot_sparse_categorical_accuracy":
                    return MultiHotSparseCategoricalAccuracy;
                case "TopKCategoricalAccuracy":
                    return TopKCategoricalAccuracy;
                case "sparse_topk_categorical_accuracy":
                    return SparseTopKCategoricalAccuracy;
                case "mse":
                    return MSE;
                case "mae":
                    return MAE;
                case "mspe":
                    return MSPE;
                case "msle":
                    return MSLE;
                case "cosine":
                    return Cosine;
                default:
                    throw new Exception("Invalid metric name");
            }
        }
    }
}
