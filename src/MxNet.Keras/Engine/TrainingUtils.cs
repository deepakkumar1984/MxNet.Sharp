using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Engine
{
    public class TrainingUtils
    {
        public static NDArray StandardizeSingleArray(NDArray x)
        {
            if (x == null)
            {
                return null;
            }
            else if (K.IsTensor(x))
            {
                var shape = x.Shape;
                if (shape == null || shape[0] == 0)
                {
                    throw new Exception(String.Format("When feeding symbolic tensors to a model, we expect thetensors to have a static batch size. Got tensor with shape: {0}", shape.ToString()));
                }
                return x;
            }
            else if (x.Dimension == 1)
            {
                x = nd.ExpandDims(x, 1);
            }

            return x;
        }

        public static NDArray StandardizeSingleArray(NDArrayList data, string[] names, Shape[] shapes= null, bool check_batch_axis= true, string exception_prefix= "", bool  check_last_layer_shape= true)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList StandardizeInputData(NDArrayList data, string[] names, Shape[] shapes= null, bool check_batch_axis= true, string exception_prefix= "", bool check_last_layer_shape= true)
        {
            if (names == null)
            {
                if (data != null && data.Length == 0)
                {
                    throw new Exception("Error when checking model " + exception_prefix + ": expected no data");
                }

                return new NDArrayList();
            }

            if (data == null)
            {
                return (from _ in Enumerable.Range(0, names.Length)
                        select new NDArray()).ToList();
            }
            
            data = (from x in data
                    select StandardizeSingleArray(x)).ToList();

            if (data.Length != names.Length)
            {
                if (data[0].Shape != null)
                {
                    throw new Exception("Error when checking model " + exception_prefix + ": the list of Numpy arrays that you are passing to your model is not the size the model expected. Expected to see " + names.Length.ToString() + " array(s), but instead got the following list of " + data.Length.ToString());
                }
                else if (names.Length > 1)
                {
                    throw new Exception("Error when checking model " + exception_prefix + ": you are passing a list as input to your model, but the model expects a list of " + names.Length.ToString());
                }
            }

            // Check shapes compatibility.
            if (shapes != null)
            {
                foreach (var i in Enumerable.Range(0, names.Length))
                {
                    if (shapes[i] != null && !K.IsTensor(data[i]))
                    {
                        var data_shape = data[i].Shape;
                        var shape = shapes[i];
                        if (data[i].Dimension != shape.Dimension)
                        {
                            throw new Exception("Error when checking " + exception_prefix + ": expected " + names[i] + " to have " + shape.Dimension.ToString() + " dimensions, but got array with shape " + data_shape.ToString());
                        }
                        if (!check_batch_axis)
                        {
                            data_shape = data_shape[1];
                            shape = shape[1];
                        }
                        foreach (var _tup_1 in Enumerable.Zip(data_shape.Data, shape.Data, (d, s) => { return (d, s); }))
                        {
                            var dim = _tup_1.Item1;
                            var ref_dim = _tup_1.Item2;
                            if (ref_dim != dim && ref_dim > 0)
                            {
                                // ignore shape difference in last layer only if loss is
                                // multi_hot_sparse_categorical_crossentropy,
                                // last layer can only be dense or activation layer
                                if (!check_last_layer_shape && (names[i].ToLower().StartsWith("dense") || names[i].ToLower().StartsWith("activation")))
                                {
                                    continue;
                                }

                                throw new Exception("Error when checking " + exception_prefix + ": expected " + names[i] + " to have shape " + shape.ToString() + " but got array with shape " + data_shape.ToString());
                            }
                        }
                    }
                }
            }

            return data;
        }

        public static NDArrayList StandardizeSampleOrClassWeight(NDArrayList x_weight, string[] output_names, string weight_type)
        {
            if (x_weight == null || x_weight.Length == 0)
            {
                return (from _ in output_names
                        select new NDArray()).ToList();
            }
            if (output_names.Length == 1)
            {
                if (x_weight.Length == 1)
                {
                    return x_weight;
                }
            }

            if (x_weight.Length != output_names.Length)
            {
                throw new Exception("Provided `" + weight_type + "` was a list of " + x_weight.Length + " elements, but the model has " + output_names.Length + " outputs. You should provide one `" + weight_type + "`array per model output.");
            }

            return x_weight;
        }

        public static NDArrayList StandardizeSampleOrClassWeight(NDArrayDict x_weight, string[] output_names, string weight_type)
        {
            if (x_weight == null || x_weight.Count == 0)
            {
                return (from _ in output_names
                        select new NDArray()).ToList();
            }
            if (output_names.Length == 1)
            {
                if (x_weight.Count == 1)
                {
                    return x_weight.FirstOrDefault().Value;
                }
            }

            if (x_weight.Count != output_names.Length)
            {
                throw new Exception("Provided `" + weight_type + "` was a list of " + x_weight.Count + " elements, but the model has " + output_names.Length + " outputs. You should provide one `" + weight_type + "`array per model output.");
            }

            return x_weight.Values;
        }

        public static NDArrayList StandardizeClassWeight(NDArrayDict class_weight, string[] output_names)
        {
            return StandardizeSampleOrClassWeight(class_weight, output_names, "class_weight");
        }

        public static NDArray StandardizeSampleWeight(NDArrayList sample_weight, string[] output_names)
        {
            return StandardizeSampleOrClassWeight(sample_weight, output_names, "sample_weight");
        }

        public static void CheckArrayLengthConsistency(NDArrayList inputs, NDArrayList targets, NDArrayList weights)
        {
            Func<NDArrayList, int[]> set_of_lengths = x => {
               if(x == null)
                    return new int[0];

                return x.Select(i => i.Shape[0]).ToArray();
            };

            var set_x = set_of_lengths(inputs);
            var set_y = set_of_lengths(targets);
            var set_w = set_of_lengths(weights);

            if (set_x.Length > 1) {
                throw new Exception("All input arrays (x) should have the same number of samples. Got array shapes: " + string.Join("|", (from x in inputs
                    select x.Shape.ToString())));
            }
            if (set_y.Length > 1) {
                throw new Exception("All target arrays (y) should have the same number of samples. Got array shapes: " + string.Join("|", (from y in inputs
                                                                                                                                           select y.Shape.ToString())));
            }
            if (set_x != null && set_y != null && set_x[0] != set_y[0]) {
                throw new Exception("Input arrays should have the same number of samples as target arrays. Found " + set_x[0] + " input samples and " + set_y[0] + " target samples.");
            }
            if (set_w.Length > 1) {
                throw new Exception("All sample_weight arrays should have the same number of samples. Got array shapes: " + string.Join("|", (from w in inputs
                                                                                                                                              select w.Shape.ToString())));
            }
            if (set_y != null && set_w != null && set_y[0] != set_w[0]) {
                throw new Exception("Sample_weight arrays should have the same number of samples as target arrays. Got " + set_y[0] + " input samples and " + set_w[0] + " target samples.");
            }
        }

        public static void CheckLossAndTargetCompatibility(NDArrayList targets, Func<KerasSymbol, KerasSymbol, KerasSymbol>[] loss_fns, Shape[] output_shapes)
        {
            var key_losses = new string[] { "MeanSquaredError", "BinaryCrossentropy", "CategoricalCrossentropy" };
            for(int i = 0; i< targets.Length;i++)
            {
                var y = targets[i];
                var loss = loss_fns[i];
                var shape = output_shapes[i];
                if (y == null || loss == null)
                {
                    continue;
                }
                if (loss.Method.Name == "CategoricalCrossentropy")
                {
                    if (y.Shape.Data.Last() == 1)
                    {
                        throw new Exception("You are passing a target array of shape " + y.Shape.ToString() + " while using as loss `categorical_crossentropy`. `categorical_crossentropy` expects targets to be binary matrices (1s and 0s) of shape (samples, classes). If your targets are integer classes, you can convert them to the expected format via:\n```\nfrom keras.utils import to_categorical\ny_binary = to_categorical(y_int)\n```\n\nAlternatively, you can use the loss function `sparse_categorical_crossentropy` instead, which does expect integer targets.");
                    }
                }

                if (key_losses.Contains(loss.Method.Name))
                {
                    foreach (var _tup_2 in Enumerable.Zip(y.Shape.Data.Skip(1), shape.Data.Skip(1), (t, o) => (t, o)))
                    {
                        var target_dim = _tup_2.Item1;
                        var out_dim = _tup_2.Item2;
                        if (out_dim != 0 && target_dim != out_dim)
                        {
                            throw new Exception("A target array with shape " + y.Shape.ToString() + " was passed for an output of shape " + shape.ToString() + " while using as loss `" + loss.Method.Name + "`. This loss expects targets to have the same shape as the output.");
                        }
                    }
                }
            }
        }

        public static List<List<string>> CollectMetrics(string[] metrics, string[] output_names)
        {
            if (metrics == null)
            {
                return (from _ in output_names
                        select new List<string>()).ToList();
            }

            return (from _ in output_names
                    select metrics.ToList()).ToList();
        }

        public static NDArray BatchShuffle(NDArray index_array, int batch_size)
        {
            var batch_count = Convert.ToInt32(index_array.Shape[0] / batch_size);
            // to reshape we need to be cleanly divisible by batch size
            // we stash extra items and reappend them after shuffling
            var last_batch = index_array[$"{batch_count * batch_size}:"];
            index_array = index_array[$":{batch_count * batch_size}"];
            index_array = index_array.Reshape((batch_count, batch_size));
            index_array = nd.Shuffle(index_array);
            index_array = index_array.Ravel();
            return nd.Concat(new NDArrayList(index_array, last_batch));
        }

        public static (int, int)[] MakeBatches(int size, int batch_size)
        {
            var num_batches = (size + batch_size - 1) / batch_size;
            return (from i in Enumerable.Range(0, num_batches)
                    select ((i * batch_size), (int)Math.Min(size, (i + 1) * batch_size))).ToArray();
        }

        public static Func<KerasSymbol, KerasSymbol, KerasSymbol, KerasSymbol, KerasSymbol> WeightedMaskedObjective(Func<KerasSymbol, KerasSymbol, KerasSymbol> fn)
        {
            if (fn == null)
            {
                return null;
            }

            Func<KerasSymbol, KerasSymbol, KerasSymbol, KerasSymbol, KerasSymbol> weighted = (y_true, y_pred, weights, mask) => {
                // score_array has ndim >= 2
                var score_array = fn(y_true, y_pred);
                if (mask != null)
                {
                    // Cast the mask to floatX to avoid float64 upcasting in Theano
                    mask = K.Cast(mask, K.FloatX());
                    // mask should have the same shape as score_array
                    score_array *= mask;
                    //  the loss per batch should be proportional
                    //  to the number of unmasked samples.
                    score_array /= K.Mean(mask);
                }
                // apply sample weighting
                if (weights != null)
                {
                    // reduce score_array to same ndim as weight array
                    var ndim = K.NDim(score_array);
                    var weight_ndim = K.NDim(weights);
                    score_array = K.Mean(score_array, axis: new Shape(Enumerable.Range(weight_ndim, ndim - weight_ndim).ToList()));
                    score_array *= weights;
                    score_array /= K.Mean(K.Cast(K.NotEqual(weights, K.ZerosLike(weights)), K.FloatX()));
                }

                return K.Mean(score_array);
            };

            return weighted;
        }

        public static NDArray StandardizeWeights(NDArray y, NDArray sample_weight= null, NDArray class_weight= null, string sample_weight_mode= null)
        {
            throw new NotImplementedException();
        }

        public static int CheckNumSamples(NDArrayList ins, int? batch_size = null, int? steps = null, string steps_name = "steps")
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<T> IterSequenceInfinite<T>(Sequence<T> seq)
        {
            throw new NotImplementedException();
        }
    }
}
