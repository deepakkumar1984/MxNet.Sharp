using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class TrainingUtils
    {
        public static NDArray StandardizeSingleArray(NDArray x)
        {
            throw new NotImplementedException();
        }

        public static NDArray StandardizeSingleArray(NDArrayList data, string[] names, Shape[] shapes= null, bool check_batch_axis= true, string exception_prefix= "", bool  check_last_layer_shape= true)
        {
            throw new NotImplementedException();
        }

        public static NDArray StandardizeSampleOrClassWeight(NDArray x, NDArray weight, string[] output_names, string weight_type)
        {
            throw new NotImplementedException();
        }

        public static NDArray StandardizeClassWeight(NDArray class_weight, string[] output_names)
        {
            throw new NotImplementedException();
        }

        public static NDArray StandardizeSampleWeight(NDArray sample_weight, string[] output_names)
        {
            throw new NotImplementedException();
        }

        public static NDArray CheckArrayLengthConsistency(NDArrayList inputs, NDArrayList targets, NDArrayList weights)
        {
            throw new NotImplementedException();
        }

        public static NDArray CheckLossAndTargetCompatibility(NDArrayList targets, string[] loss_fns, Shape[] output_shapes)
        {
            throw new NotImplementedException();
        }

        public static List<Func<KerasSymbol, KerasSymbol, KerasSymbol>[]> CollectMetrics(string[] metrics, string[] output_names)
        {
            throw new NotImplementedException();
        }

        public static NDArray BatchShuffle(NDArray index_array, int batch_size)
        {
            throw new NotImplementedException();
        }

        public static (int, int)[] MakeBatches(int size, int batch_size)
        {
            throw new NotImplementedException();
        }

        public static Func<NDArray, NDArray, NDArray, NDArray, NDArray> WeightedMaskedObjective(Func<NDArray, NDArray, NDArray> fn)
        {
            throw new NotImplementedException();
        }

        public static NDArray StandardizeWeights(NDArray y, NDArray sample_weight= null, NDArray class_weight= null, NDArray sample_weight_mode= null)
        {
            throw new NotImplementedException();
        }

        public static NDArray CheckNumSamples(NDArrayList ins, int? batch_size = null, int? steps = null, string steps_name = "steps")
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<T> IterSequenceInfinite<T>(Sequence<T> seq)
        {
            throw new NotImplementedException();
        }
    }
}
