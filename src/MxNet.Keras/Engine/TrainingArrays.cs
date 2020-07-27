using MxNet.Keras.Callbacks;
using System;   
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class TrainingArrays
    {
        public static History FitLoop(Model model, Func<NDArrayList, float[]> fit_function, NDArrayList fit_inputs, string[] out_labels= null, int? batch_size= null, int epochs= 100,
                                int verbose= 1, Callback[] callbacks= null, Func<NDArrayList, float[]> val_function = null, NDArrayList val_inputs= null, bool shuffle= true,
                                string[] callback_metrics= null, int initial_epoch= 0, int? steps_per_epoch= null, int? validation_steps= null)
        {
            object ins_batch;
            object val_outs;
            object o;
            object l;
            object outs;
            object batch_logs;
            object callback_model;
            string count_mode;
            object index_array;
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
                _callbacks.Add(new ProgbarLogger(count_mode, stateful_metrics: model.stateful_metric_names));
            }

            _callbacks += (callbacks || new List<object>()) + new List<object> {
                model.history
            };

            callbacks = new CallbackList(_callbacks.ToArray());
            out_labels = out_labels || new List<object>();
            // it's possible to callback a different model than itself
            // (used by Sequential models)
            if (hasattr(model, "callback_model") && model.callback_model)
            {
                callback_model = model.callback_model;
            }
            else
            {
                callback_model = model;
            }
            callbacks.set_model(callback_model);
            callbacks.set_params(new Dictionary<object, object> {
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
                    callback_metrics || new List<object>()}});
            callbacks.on_train_begin();
            callback_model.stop_training = false;
            foreach (var cbk in callbacks)
            {
                cbk.validation_data = val_inputs;
            }
            // To prevent a slowdown,
            // we find beforehand the arrays that need conversion.
            var feed = model._feed_inputs + model._feed_targets + model._feed_sample_weights;
            var indices_for_conversion_to_dense = new List<object>();
            foreach (var i in Enumerable.Range(0, feed.Count))
            {
                if (issparse(fit_inputs[i]) && !K.is_sparse(feed[i]))
                {
                    indices_for_conversion_to_dense.append(i);
                }
            }
            foreach (var epoch in Enumerable.Range(initial_epoch, epochs - initial_epoch))
            {
                // Reset stateful metrics
                foreach (var m in model.stateful_metric_functions)
                {
                    m.reset_states();
                }
                callbacks.on_epoch_begin(epoch);
                var epoch_logs = new Dictionary<object, object>
                {
                };
                if (steps_per_epoch != null)
                {
                    foreach (var step_index in Enumerable.Range(0, steps_per_epoch))
                    {
                        batch_logs = new Dictionary<object, object>
                        {
                        };
                        batch_logs["batch"] = step_index;
                        batch_logs["size"] = 1;
                        callbacks.on_batch_begin(step_index, batch_logs);
                        outs = fit_function(fit_inputs);
                        outs = to_list(outs);
                        foreach (var _tup_1 in zip(out_labels, outs))
                        {
                            l = _tup_1.Item1;
                            o = _tup_1.Item2;
                            batch_logs[l] = o;
                        }
                        callbacks.on_batch_end(step_index, batch_logs);
                        if (callback_model.stop_training)
                        {
                            break;
                        }
                    }
                    if (do_validation)
                    {
                        val_outs = test_loop(model, val_function, val_inputs, steps: validation_steps, verbose: 0);
                        val_outs = to_list(val_outs);
                        // Same labels assumed.
                        foreach (var _tup_2 in zip(out_labels, val_outs))
                        {
                            l = _tup_2.Item1;
                            o = _tup_2.Item2;
                            epoch_logs["val_" + l] = o;
                        }
                    }
                }
                else
                {
                    if (shuffle == "batch")
                    {
                        index_array = batch_shuffle(index_array, batch_size);
                    }
                    else if (shuffle)
                    {
                        np.random.shuffle(index_array);
                    }
                    var batches = make_batches(num_train_samples, batch_size);
                    foreach (var _tup_3 in batches.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
                    {
                        var batch_index = _tup_3.Item1;
                        (batch_start, batch_end) = _tup_3.Item2;
                        var batch_ids = index_array[batch_start::batch_end];
                        try
                        {
                            if (fit_inputs[-1] is float)
                            {
                                // Do not slice the training phase flag.
                                ins_batch = slice_arrays(fit_inputs[:: - 1], batch_ids) + new List<object> {
                                    fit_inputs[-1]
                                };
                            }
                            else
                            {
                                ins_batch = slice_arrays(fit_inputs, batch_ids);
                            }
                        }
                        catch (TypeError)
                        {
                            throw new TypeError("TypeError while preparing batch. If using HDF5 input data, pass shuffle=\"batch\".");
                        }
                        batch_logs = new Dictionary<object, object>
                        {
                        };
                        batch_logs["batch"] = batch_index;
                        batch_logs["size"] = batch_ids.Count;
                        callbacks.on_batch_begin(batch_index, batch_logs);
                        foreach (var i in indices_for_conversion_to_dense)
                        {
                            ins_batch[i] = ins_batch[i].toarray();
                        }
                        outs = fit_function(ins_batch);
                        outs = to_list(outs);
                        foreach (var _tup_4 in zip(out_labels, outs))
                        {
                            l = _tup_4.Item1;
                            o = _tup_4.Item2;
                            batch_logs[l] = o;
                        }
                        callbacks.on_batch_end(batch_index, batch_logs);
                        if (callback_model.stop_training)
                        {
                            break;
                        }
                        if (batch_index == batches.Count - 1)
                        {
                            // Last batch.
                            if (do_validation)
                            {
                                val_outs = test_loop(model, val_function, val_inputs, batch_size: batch_size, verbose: 0);
                                val_outs = to_list(val_outs);
                                // Same labels assumed.
                                foreach (var _tup_5 in zip(out_labels, val_outs))
                                {
                                    l = _tup_5.Item1;
                                    o = _tup_5.Item2;
                                    epoch_logs["val_" + l] = o;
                                }
                            }
                        }
                    }
                }
                callbacks.on_epoch_end(epoch, epoch_logs);
                if (callback_model.stop_training)
                {
                    break;
                }
            }
            callbacks.on_train_end();
            return model.history;
        }

        public static NDArrayList PredictLoop(Model model, Func<NDArrayList, NDArrayList> f, NDArrayList ins, int batch_size= 32, int verbose= 0, int? steps= null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList TestLoop(Model model, Func<NDArrayList, float[]> f, NDArrayList ins, int batch_size = 32, int verbose = 0, int? steps = null)
        {
            throw new NotImplementedException();
        }
    }
}
