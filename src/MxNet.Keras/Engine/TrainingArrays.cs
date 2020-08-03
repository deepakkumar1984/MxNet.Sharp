using MxNet.Keras.Callbacks;
using MxNet.Keras.Utils;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Engine
{
    public class TrainingArrays
    {
        public static History FitLoop(Model model, Func<NDArrayList, float[]> fit_function, NDArrayList fit_inputs, string[] out_labels= null, int? batch_size= null, int epochs= 100,
                                int verbose= 1, CallbackList callbacks= null, Func<NDArrayList, float[]> val_function = null, NDArrayList val_inputs= null, bool shuffle= true,
                                string[] callback_metrics= null, int initial_epoch= 0, int? steps_per_epoch= null, int? validation_steps= null)
        {
            NDArrayList ins_batch = null;
            float[] val_outs = null;
            float[] outs = null;
            Dictionary<string, float> batch_logs;
            Model callback_model;
            string count_mode;
            NDArray index_array = null;
            var do_validation = false;
            if (val_function != null && val_inputs != null)
            {
                do_validation = true;
                if (verbose > 0 && fit_inputs != null)
                {
                    Console.WriteLine(String.Format("Train on %d samples, validate on %d samples", fit_inputs[0].Shape[0], val_inputs[0].Shape[0]));
                }
            }

            if (validation_steps != null)
            {
                do_validation = true;
                if (steps_per_epoch == null)
                {
                    throw new Exception("Can only use `validation_steps` when doing step-wise training, i.e. `steps_per_epoch` must be set.");
                }
            }
            else if (do_validation)
            {
                if (!steps_per_epoch.HasValue)
                {
                    throw new Exception("Must specify `validation_steps` to perform validation when doing step-wise training.");
                }
            }

            var num_train_samples = TrainingUtils.CheckNumSamples(fit_inputs, batch_size: batch_size, steps: steps_per_epoch, steps_name: "steps_per_epoch");
            if (num_train_samples > 0)
            {
                index_array = nd.Arange(num_train_samples);
            }

            model.history = new History();
            var _callbacks = new List<Callback> {
                new BaseLogger(stateful_metrics: model.stateful_metric_names.ToArray())
            };

            if (verbose > 0)
            {
                if (steps_per_epoch != null)
                {
                    count_mode = "steps";
                }
                else
                {
                    count_mode = "samples";
                }
                _callbacks.Add(new ProgbarLogger(count_mode, stateful_metrics: model.stateful_metric_names.ToArray()));
            }

            _callbacks.Add(model.history);

            callbacks = new CallbackList(_callbacks.ToArray());
            out_labels = out_labels ?? new string[0];
            // it's possible to callback a different model than itself
            // (used by Sequential models)
            callback_model = model;

            callbacks.SetModel(callback_model);
            callbacks.SetParams(new Dictionary<string, object> {
                {
                    "batch_size",
                    batch_size},
                {
                    "epochs",
                    epochs},
                {
                    "steps",
                    steps_per_epoch},
                {
                    "samples",
                    num_train_samples},
                {
                    "verbose",
                    verbose},
                {
                    "do_validation",
                    do_validation},
                {
                    "metrics",
                    callback_metrics ?? new string[0]}});

            callbacks.OnTrainBegin();
            callback_model.stop_training = false;
            foreach (var cbk in callbacks.callbacks)
            {
                cbk.validation_data = val_inputs;
            }

            // To prevent a slowdown,
            // we find beforehand the arrays that need conversion.
            List<KerasSymbol> feed = new List<KerasSymbol>();
            feed.AddRange(model._feed_inputs);
            feed.AddRange(model._feed_targets);
            feed.AddRange(model._feed_sample_weights);
            
            var indices_for_conversion_to_dense = new List<int>();
            foreach (var i in Enumerable.Range(0, feed.Count))
            {
                if (!K.IsSparse(feed[i]))
                {
                    indices_for_conversion_to_dense.Add(i);
                }
            }

            foreach (var epoch in Enumerable.Range(initial_epoch, epochs - initial_epoch))
            {
                // Reset stateful metrics
                //ToDo: Recheck code
                //foreach (var m in model.stateful_metric_functions)
                //{
                //    m.reset_states();
                //}

                callbacks.OnEpochBegin(epoch);
                var epoch_logs = new Dictionary<string, float>
                {
                };
                if (steps_per_epoch != null)
                {
                    foreach (var step_index in Enumerable.Range(0, steps_per_epoch.Value))
                    {
                        batch_logs = new Dictionary<string, float>
                        {
                        };

                        batch_logs["batch"] = step_index;
                        batch_logs["size"] = 1;
                        callbacks.OnBatchBegin(step_index, batch_logs);
                        outs = fit_function(fit_inputs);

                        for (int i = 0; i < out_labels.Length; i++)
                        {
                            if(batch_logs.ContainsKey(out_labels[i]))
                            {
                                batch_logs.Add(out_labels[i], outs[i]);
                            }
                            else
                            {
                                batch_logs[out_labels[i]] = outs[i];
                            }
                        }
                       
                        callbacks.OnBatchEnd(step_index, batch_logs);
                        if (callback_model.stop_training)
                        {
                            break;
                        }
                    }
                    if (do_validation)
                    {
                        val_outs = TestLoop(model, val_function, val_inputs, steps: validation_steps, verbose: 0);
                        // Same labels assumed.
                        for (int i = 0; i < out_labels.Length; i++)
                        {
                            var l = "val_" + out_labels[i];
                            if (epoch_logs.ContainsKey(l))
                            {
                                epoch_logs.Add(l, val_outs[i]);
                            }
                            else
                            {
                                epoch_logs[l] = val_outs[i];
                            }
                        }
                    }
                }
                else
                {
                    if (shuffle && batch_size.HasValue)
                    {
                        index_array = TrainingUtils.BatchShuffle(index_array, batch_size.Value);
                    }
                    else if (shuffle)
                    {
                        nd.Shuffle(index_array);
                    }

                    var batches = TrainingUtils.MakeBatches(num_train_samples, batch_size.Value);
                    foreach (var _tup_3 in batches.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
                    {
                        var batch_index = _tup_3.Item1;
                        var (batch_start, batch_end) = _tup_3.Item2;
                        var batch_ids = index_array[$"{batch_start}:{batch_end}"];
                        try
                        {
                            ins_batch = GenericUtils.SliceArrays(fit_inputs, batch_ids.ArrayData.Cast<int>().ToArray());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("TypeError while preparing batch. If using HDF5 input data, pass shuffle=\"batch\".");
                        }

                        batch_logs = new Dictionary<string, float>();
                        batch_logs["batch"] = batch_index;
                        batch_logs["size"] = batch_ids.Shape[0];
                        callbacks.OnBatchBegin(batch_index, batch_logs);
                        foreach (var i in indices_for_conversion_to_dense)
                        {
                            ins_batch[i] = ins_batch[i];
                        }

                        outs = fit_function(ins_batch);
                        for (int i = 0; i < out_labels.Length; i++)
                        {
                            if (batch_logs.ContainsKey(out_labels[i]))
                            {
                                batch_logs.Add(out_labels[i], outs[i]);
                            }
                            else
                            {
                                batch_logs[out_labels[i]] = outs[i];
                            }
                        }

                        callbacks.OnBatchEnd(batch_index, batch_logs);
                        if (callback_model.stop_training)
                        {
                            break;
                        }
                        if (batch_index == batches.Length - 1)
                        {
                            // Last batch.
                            if (do_validation)
                            {
                                val_outs = TestLoop(model, val_function, val_inputs, batch_size: batch_size.Value, verbose: 0);
                                // Same labels assumed.
                                for (int i = 0; i < out_labels.Length; i++)
                                {
                                    var l = "val_" + out_labels[i];
                                    if (epoch_logs.ContainsKey(l))
                                    {
                                        epoch_logs.Add(l, val_outs[i]);
                                    }
                                    else
                                    {
                                        epoch_logs[l] = val_outs[i];
                                    }
                                }
                            }
                        }
                    }
                }
                callbacks.OnEpochEnd(epoch, epoch_logs);
                if (callback_model.stop_training)
                {
                    break;
                }
            }

            callbacks.OnTrainEnd();
            return model.history;
        }

        public static NDArrayList PredictLoop(Model model, Func<NDArrayList, NDArrayList> f, NDArrayList ins, int batch_size= 32, int verbose= 0, int? steps= null)
        {
            throw new NotImplementedException();
        }

        public static float[] TestLoop(Model model, Func<NDArrayList, float[]> f, NDArrayList ins, int batch_size = 32, int verbose = 0, int? steps = null)
        {
            throw new NotImplementedException();
        }
    }
}
