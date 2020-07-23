using MxNet.Keras.Callbacks;
using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;
using MxNet.Keras.Utils;
using MxNet.Keras.Optimizers;
using MxNet.Modules;
using System.Linq;
using K = MxNet.Keras.MxNetBackend;
using System.Diagnostics;
using MxNet.IO;

namespace MxNet.Keras.Engine
{
    public enum Phase
    {
        Train = 0,
        Test,
        Pred
    }

    public class Model : Network
    {
        internal NDArrayDict _args;

        internal NDArrayDict _auxs;

        internal bool stop_training;

        internal Symbol _pred_mxnet_symbol;

        internal BucketingModule _module;

        public KerasSymbol[] _collected_trainable_weights;

        public List<Func<KerasSymbol, KerasSymbol, KerasSymbol>> _feed_loss_fns;

        public List<string> _feed_output_names;

        public List<Shape> _feed_output_shapes;

        public List<KerasSymbol> _feed_outputs;

        public List<string> _feed_sample_weight_modes;

        public List<KerasSymbol> _feed_sample_weights;

        public List<KerasSymbol> _feed_targets;

        public FuncArgs _function_kwargs;

        public string loss;

        public List<Func<KerasSymbol, KerasSymbol, KerasSymbol>> loss_functions;

        public float[] loss_weights;

        public List<string> metrics;

        public List<string> metrics_names;

        public List<KerasSymbol> metrics_tensors;

        public object metrics_updates;

        public object predict_function;

        public object sample_weight_mode;

        public List<string> sample_weight_modes;

        public List<KerasSymbol> sample_weights;

        public List<Func<KerasSymbol, KerasSymbol, KerasSymbol>> stateful_metric_functions;

        public List<string> stateful_metric_names;

        public List<KerasSymbol> targets;

        public object test_function;

        public KerasSymbol total_loss;

        public Func<KerasSymbol[], float[]> train_function;

        public object weighted_metrics;

        internal Context[] _context;
        internal string _kvstore;
        internal string[] _data_names;
        internal string[] _label_names;
        internal int? _ntrain;
        internal Symbol _train_mxnet_symbol;
        internal Dictionary<string, string> _train_updates;
        internal int? _ntest;
        internal Symbol _test_mxnet_symbol;
        internal Dictionary<string, string> _test_updates;
        internal int? _npred;
        internal string[] _arg_names;
        internal string[] _aux_names;
        internal string[] _fixed_weights;
        internal bool? _weights_dirty;
        internal bool compiled;
        internal int? _num_data;
        internal int? _num_label;
        internal BucketingModule _predict_only_module;

        public Model(string name = "", Context context = null, string kvstore = "device")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var prefix = this.GetType().Name.ToLower();
                name = prefix + "_" + K.GetUid(prefix).ToString();
            }

            this.name = name;
            this._context = K.GetMxNetContexts(context);
            this._kvstore = kvstore;
            this._data_names = null;
            this._label_names = null;
            this._ntrain = null;
            this._train_mxnet_symbol = null;
            this._train_updates = null;
            this._ntest = null;
            this._test_mxnet_symbol = null;
            this._test_updates = null;
            this._npred = null;
            this._pred_mxnet_symbol = null;
            this._arg_names = null;
            this._aux_names = null;
            this._fixed_weights = null;
            this._args = null;
            this._auxs = null;
            this._weights_dirty = null;
            this._module = null;
            this.compiled = false;
            if (this.built)
            {
                this._num_data = this.inputs.Count;
                this._num_label = this.outputs.Count + this.output_names.Count;
                // Create Module for Inference
                this.CreatePredictFunction();
            }
            else
            {
                this._num_data = null;
                this._num_label = null;
            }
        }

        public Model(string name = "", int n_context = 1, string kvstore = "device")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var prefix = this.GetType().Name.ToLower();
                name = prefix + "_" + K.GetUid(prefix).ToString();
            }

            this.name = name;
            this._context = K.GetMxNetContexts(n_context);
            this._kvstore = kvstore;
            this._data_names = null;
            this._label_names = null;
            this._ntrain = null;
            this._train_mxnet_symbol = null;
            this._train_updates = null;
            this._ntest = null;
            this._test_mxnet_symbol = null;
            this._test_updates = null;
            this._npred = null;
            this._pred_mxnet_symbol = null;
            this._arg_names = null;
            this._aux_names = null;
            this._fixed_weights = null;
            this._args = null;
            this._auxs = null;
            this._weights_dirty = null;
            this._module = null;
            this.compiled = false;
            if (this.built)
            {
                this._num_data = this.inputs.Count;
                this._num_label = this.outputs.Count + this.output_names.Count;
                // Create Module for Inference
                this.CreatePredictFunction();
            }
            else
            {
                this._num_data = null;
                this._num_label = null;
            }
        }

        private void BaseCompile(Optimizer optimizer, string loss = null, string[] metrics = null, float[] loss_weights = null, string[] sample_weight_mode = null, string[] weighted_metrics = null, KerasSymbol[] target_tensors = null)
        {
            KerasSymbol weight;
            KerasSymbol target;
            string name;
            this.optimizer = optimizer;
            this.loss = loss;
            this.metrics = metrics != null ? metrics.ToList() : new List<string>();
            this.loss_weights = loss_weights;
            this.sample_weight_mode = sample_weight_mode;
            this.weighted_metrics = weighted_metrics;
            if (!this.built)
            {
                // Model is not compilable because
                // it does not know its number of inputs
                // and outputs, nor their shapes and names.
                // We will compile after the first
                // time the model gets called on training data.
                return;
            }
            this._is_compiled = true;
            // Prepare loss functions.
            var loss_function = Keras.Losses.Get(loss);
            this.loss_functions = (from _ in Enumerable.Range(0, this.outputs.Count)
                              select loss_function).ToList();
            var weighted_losses = (from fn in loss_functions
                                   select TrainingUtils.WeightedMaskedObjective(fn)).ToList();
            var skip_target_indices = new List<int>();
            var skip_target_weighing_indices = new List<int>();
            this._feed_outputs = new List<KerasSymbol>();
            this._feed_output_names = new List<string>();
            this._feed_output_shapes = new List<Shape>();
            this._feed_loss_fns = new List<Func<KerasSymbol, KerasSymbol, KerasSymbol>>();
            foreach (var i in Enumerable.Range(0, weighted_losses.Count))
            {
                if (weighted_losses[i] == null)
                {
                    skip_target_indices.Add(i);
                    skip_target_weighing_indices.Add(i);
                }
            }
            // Prepare output masks.
            var masks = this.ComputeMask(this.inputs.ToArray(), mask: null);
            if (masks == null)
            {
                masks = new KerasSymbol[this.outputs.Count];
            }

            // Prepare loss weights.
            List<float> loss_weights_list = null;
            if (loss_weights == null)
            {
                loss_weights_list = (from _ in Enumerable.Range(0, this.outputs.Count)
                                         select 1.0f).ToList();
            }
            else
            {
                if (loss_weights.Length != this.outputs.Count)
                {
                    throw new Exception("When passing a list as loss_weights, it should have one entry per model output. The model has " + this.outputs.Count.ToString() + " outputs, but you passed loss_weights=" + loss_weights.ToString());
                }

                loss_weights_list = loss_weights.ToList();
            }

            // Prepare targets of model.
            this.targets = new List<KerasSymbol>();
            this._feed_targets = new List<KerasSymbol>();
            if (target_tensors != null)
            {
                if (target_tensors.Length != this.outputs.Count)
                {
                    throw new Exception("When passing a list as `target_tensors`, it should have one entry per model output. The model has " + this.outputs.Count.ToString() + " outputs, but you passed target_tensors=" + target_tensors.ToString());
                }
            }

            foreach (var i in Enumerable.Range(0, this.outputs.Count))
            {
                if (skip_target_indices.Contains(i))
                {
                    this.targets.Add(null);
                }
                else
                {
                    var shape = this.outputs[i].Shape;
                    name = this.output_names[i];
                    if (target_tensors != null)
                    {
                        target = target_tensors[i];
                    }
                    else
                    {
                        target = null;
                    }
                    if (target == null || K.IsPlaceholder(target))
                    {
                        if (target == null)
                        {
                            target = K.Placeholder(ndim: shape.Dimension, name: name + "_target", sparse: K.IsSparse(this.outputs[i]), dtype: K.DataType(this.outputs[i]));
                        }
                        this._feed_targets.Add(target);
                        this._feed_outputs.Add(this.outputs[i]);
                        this._feed_output_names.Add(name);
                        this._feed_output_shapes.Add(shape);
                        this._feed_loss_fns.Add(this.loss_functions[i]);
                    }
                    else
                    {
                        skip_target_weighing_indices.Add(i);
                    }

                    this.targets.Add(target);
                }
            }
            // Prepare sample weights.
            var sample_weights = new List<KerasSymbol>();
            this.sample_weight_modes = new List<string>();
            if (sample_weight_mode != null)
            {
                if (sample_weight_mode.Length != this.outputs.Count)
                {
                    throw new Exception("When passing a list as sample_weight_mode, it should have one entry per model output. The model has " + this.outputs.Count.ToString() + " outputs, but you passed sample_weight_mode=" + sample_weight_mode.ToString());
                }

                foreach (var i in Enumerable.Range(0, this.output_names.Count))
                {
                    if (skip_target_weighing_indices.Contains(i))
                    {
                        weight = null;
                        sample_weight_modes.Add(null);
                    }
                    else
                    {
                        var mode = sample_weight_mode[i];
                        name = this.output_names[i];
                        if (mode == "temporal")
                        {
                            weight = K.Placeholder(ndim: 2, name: name + "_sample_weights");
                            sample_weight_modes.Add("temporal");
                        }
                        else
                        {
                            weight = K.Placeholder(ndim: 1, name: name + "_sample_weights");
                            sample_weight_modes.Append(null);
                        }
                    }

                    sample_weights.Add(weight);
                }

                this._feed_sample_weight_modes = new List<string>();
                foreach (var i in Enumerable.Range(0, this.outputs.Count))
                {
                    if (!skip_target_weighing_indices.Contains(i))
                    {
                        this._feed_sample_weight_modes.Add(this.sample_weight_modes[i]);
                    }
                }
            }

            // Prepare metrics.
            this.metrics_names = new List<string> {
                    "loss"
                };
            this.metrics_tensors = new List<KerasSymbol>();
            // Compute total loss.
            KerasSymbol total_loss = null;
            using (var ns = new NameScope("loss")) {
                foreach (var i in Enumerable.Range(0, this.outputs.Count))
                {
                    if (skip_target_indices.Contains(i))
                    {
                        continue;
                    }

                    var y_true = this.targets[i];
                    var y_pred = this.outputs[i];
                    var weighted_loss = weighted_losses[i];
                    var sample_weight = sample_weights.Count > 0 ? sample_weights[i] : null;
                    var mask = masks[i];
                    var loss_weight = loss_weights_list[i];
                    KerasSymbol output_loss = null;
                    using (var ns1 = new NameScope(this.output_names[i] + "_loss")) {
                        output_loss = weighted_loss(y_true, y_pred, sample_weight, mask);
                    }

                    if (this.outputs.Count > 1)
                    {
                        this.metrics_tensors.Add(output_loss);
                        this.metrics_names.Add(this.output_names[i] + "_loss");
                    }
                    if (total_loss == null)
                    {
                        total_loss = loss_weight * output_loss;
                    }
                    else
                    {
                        total_loss += loss_weight * output_loss;
                    }
                }

                if (total_loss == null)
                {
                    if (this.Losses == null)
                    {
                        throw new Exception("The model cannot be compiled because it has no loss to optimize.");
                    }
                    else
                    {
                        total_loss = null;
                    }
                }
                // Add regularization penalties
                // and other layer-specific losses.
                foreach (var loss_tensor in this.Losses)
                {
                    if (total_loss != null)
                        total_loss += loss_tensor;
                    else
                        total_loss = loss_tensor;
                }
            }

            // List of same size as output_names.
            // contains tuples (metrics for output, names of metrics).
            var nested_metrics = TrainingUtils.CollectMetrics(metrics, this.output_names.ToArray());
            var nested_weighted_metrics = TrainingUtils.CollectMetrics(weighted_metrics, this.output_names.ToArray());
            this.metrics_updates = new List<object>();
            this.stateful_metric_names = new List<string>();
            this.stateful_metric_functions = new List<Func<KerasSymbol, KerasSymbol, KerasSymbol>>();
            using (var metric_ns = new NameScope("metrics")) 
            {
                foreach (var i in Enumerable.Range(0, this.outputs.Count))
                {
                    if (skip_target_indices.Contains(i))
                    {
                        continue;
                    }

                    var y_true = this.targets[i];
                    var y_pred = this.outputs[i];
                    var weights = sample_weights.Count > 0 ? sample_weights[i] : null;
                    var output_metrics = nested_metrics[i];
                    var output_weighted_metrics = nested_weighted_metrics[i];
                    HandleMetrics(output_metrics.ToArray(), null, i, y_true, y_pred, masks[i]);
                    HandleMetrics(output_weighted_metrics.ToArray(), weights, i, y_true, y_pred, masks[i]);
                }
            }
            // Prepare gradient updates and state updates.
            this.total_loss = total_loss;
            this.sample_weights = sample_weights;
            this._feed_sample_weights = new List<KerasSymbol>();
            foreach (var i in Enumerable.Range(0, this.sample_weights.Count))
            {
                if (!skip_target_weighing_indices.Contains(i))
                {
                    this._feed_sample_weights.Add(sample_weights[i]);
                }
            }

            // Functions for train, test and predict will
            // be compiled lazily when required.
            // This saves time when the user is not using all functions.
            this.train_function = null;
            this.test_function = null;
            this.predict_function = null;
            // Collected trainable weights, sorted in topological order.
            var trainable_weights = this.TrainableWeights;
            this._collected_trainable_weights = trainable_weights;
        }

        private void HandleMetrics(string[] metrics, KerasSymbol weights, int i, KerasSymbol y_true, KerasSymbol y_pred, KerasSymbol mask)
        {
            string metric_name = "";
            Func<KerasSymbol, KerasSymbol, KerasSymbol, KerasSymbol, KerasSymbol> weighted_metric_fn = null;
            string suffix = "";
            Func<KerasSymbol, KerasSymbol, KerasSymbol> metric_fn = null;
            var metric_name_prefix = weights != null ? "weighted_" : "";
            foreach (var metric in metrics)
            {
                if (new string[] { "accuracy", "acc", "crossentropy", "ce" }.Contains(metric))
                {
                    // custom handling of accuracy/crossentropy
                    // (because of class mode duality)
                    var output_shape = this.outputs[i].Shape;
                    if (output_shape.Data.Last() == 1 || this.loss_functions[i].Method.Name == "BinaryCrossentropy")
                    {
                        // case: binary accuracy/crossentropy
                        if (new string[] { "accuracy", "acc" }.Contains(metric))
                        {
                            metric_fn = Metrics.BinaryAccuracy;
                        }
                        else if (new string[] { "crossentropy", "ce" }.Contains(metric))
                        {
                            metric_fn = Keras.Losses.BinaryCrossentropy; 
                        }
                    }
                    else if (this.loss_functions[i].Method.Name == "SparseCategoricalCrossentropy")
                    {
                        // case: categorical accuracy/crossentropy
                        // with sparse targets
                        if (new string[] { "accuracy", "acc" }.Contains(metric))
                        {
                            metric_fn = Metrics.SparseCategoricalAccuracy;
                        }
                        else if (new string[] { "crossentropy", "ce" }.Contains(metric))
                        {
                            metric_fn = Keras.Losses.SparseCategoricalCrossentropy;
                        }
                    }
                    else if (this.loss_functions[i].Method.Name == "MultiHotSparseCategoricalCrossentropy")
                    {
                        // case: multi hot sparse categorical accuracy/crossentropy
                        // with sparse list of integer targets
                        if (new string[] { "accuracy", "acc" }.Contains(metric))
                        {
                            metric_fn = Metrics.MultiHotSparseCategoricalAccuracy;
                        }
                        else if (new string[] { "crossentropy", "ce" }.Contains(metric))
                        {
                            metric_fn = Keras.Losses.MultiHotSparseCategoricalCrossentropy;
                        }
                    }
                    else
                    {
                        // case: categorical accuracy/crossentropy
                        if (new string[] { "accuracy", "acc" }.Contains(metric))
                        {
                            metric_fn = Metrics.CategoricalAccuracy;
                        }
                        else if (new string[] { "crossentropy", "ce" }.Contains(metric))
                        {
                            metric_fn = Keras.Losses.CategoricalCrossentropy;
                        }
                    }

                    if (new string[] { "accuracy", "acc" }.Contains(metric))
                    {
                        suffix = "acc";
                    }
                    else if (new string[] { "crossentropy", "ce" }.Contains(metric))
                    {
                        suffix = "ce";
                    }

                    weighted_metric_fn = TrainingUtils.WeightedMaskedObjective(metric_fn);
                    metric_name = metric_name_prefix + suffix;
                }
                else
                {
                    metric_fn = Metrics.Get(metric);
                    weighted_metric_fn = TrainingUtils.WeightedMaskedObjective(metric_fn);
                    // Get metric name as string
                    metric_name = metric_fn.Method.Name;
                    metric_name = metric_name_prefix + metric_name;
                }

                KerasSymbol metric_result = null;
                using (var ns = new NameScope(metric_name)) {
                    metric_result = weighted_metric_fn(y_true, y_pred, weights, mask);
                }
                // Append to this.metrics_names, this.metric_tensors,
                // this.stateful_metric_names
                if (this.output_names.Count > 1)
                {
                    metric_name = this.output_names[i] + "_" + metric_name;
                }
                // Dedupe name
                var j = 1;
                var base_metric_name = metric_name;
                while (this.metrics_names.Contains(metric_name))
                {
                    metric_name = base_metric_name + "_" + j.ToString();
                    j += 1;
                }
                this.metrics_names.Add(metric_name);
                this.metrics_tensors.Add(metric_result);
                //// Keep track of state updates created by
                //// stateful metrics (i.e. metrics layers).
                //if (metric_fn is Layer && metric_fn.stateful)
                //{
                //    this.stateful_metric_names.Add(metric_name);
                //    this.stateful_metric_functions.Add(metric_fn);
                //    this.metrics_updates += metric_fn.updates;
                //}
            }
        }

        public void Compile(Optimizer optimizer, string loss= null, string[] metrics= null, float[] loss_weights= null, string[] sample_weight_mode= null, Context context = null, NDArray[] target_tensors = null)
        {
            BaseCompile(optimizer, loss, metrics, loss_weights, sample_weight_mode);
            if (!this.built)
            {
                // Model is not compilable because
                // it does not know its number of inputs
                // and outputs, nor their shapes and names.
                // We will compile after the first
                // time the model gets called on training data.
                return;
            }
            // If context is passed in kwargs
            if (context != null)
            {
                this._context = K.GetMxNetContexts(context);
            }

            if (this.built)
            {
                this._num_data = this.inputs.Count;
                this._num_label = this.outputs.Count + this.output_names.Count;
            }
            // set the data and label
            this._data_names = this.inputs.Select(x => x.Name).ToArray();
            var label_list = new List<KerasSymbol>();
            label_list.AddRange(this.targets);
            label_list.AddRange(this.sample_weights);
            this._label_names = label_list.Select(x => x.Name).ToArray();
            // set for training
            var old = K.LearningPhase();
            K.SetLearningPhase(true);

            this._ntrain = this.metrics_tensors.Count + 1;
            var train_updates = (from x in this.Updates
                                 select K.StopGradient(x.Item2)).ToList();
            List<KerasSymbol> train_groups = new List<KerasSymbol>();
            train_groups.Add(K.MakeLoss(this.total_loss));
            train_groups.AddRange(metrics_tensors.Select(x => K.StopGradient(x)));
            train_groups.AddRange(train_updates);

            var train_keras_symbol = K.Group(train_groups.ToArray());
            var bind_values = K.DfsGetBindValues(train_keras_symbol);
            this._train_mxnet_symbol = train_keras_symbol.Symbol;
            var symbol_name_map = new Dictionary<string, string>();
            int i = 0;
            foreach (var item in Updates)
            {
                symbol_name_map.Add(item.Item2.Name, train_updates[i].Name);
                i++;
            }

            this._train_updates = new Dictionary<string, string>();
            foreach (var (dst, src) in Updates)
            {
                this._train_updates.Add(dst.Name, symbol_name_map[src.Name]);
            }

            // set for testing
            K.SetLearningPhase(false);
            this._ntest = this.metrics_tensors.Count + 1;
            var state_updates = (from x in this.StateUpdates
                                 select x.Item2).ToList();

            List<KerasSymbol> test_groups = new List<KerasSymbol>();
            test_groups.Add(this.total_loss);
            test_groups.AddRange(metrics_tensors.Select(x => K.StopGradient(x)));
            test_groups.AddRange(state_updates);
            var test_keras_symbol = K.Group(test_groups.ToArray());
            bind_values.Update(K.DfsGetBindValues(test_keras_symbol));
            this._test_mxnet_symbol = test_keras_symbol.Symbol;
            // set for prediction
            this._npred = this.outputs.Count;
            List<KerasSymbol> pred_groups = new List<KerasSymbol>();
            pred_groups.AddRange(this.outputs);
            pred_groups.AddRange((from symbol in state_updates
                                  where !this.outputs.Contains(symbol)
                                  select symbol).ToList());
            var pred_keras_symbol = K.Group(pred_groups.ToArray());
            bind_values.Update(K.DfsGetBindValues(pred_keras_symbol));
            this._pred_mxnet_symbol = pred_keras_symbol.Symbol;

            this._test_updates = new Dictionary<string, string>();
            foreach (var (dst, src) in StateUpdates)
            {
                this._test_updates.Add(src.Name, src.Name);
            }

            K.SetLearningPhase(old);
            // set the args and auxs
            var inputs_name_set = new List<string>();
            inputs_name_set.AddRange(this._data_names);
            inputs_name_set.AddRange(this._label_names);
            
            this._arg_names = (from x in this._train_mxnet_symbol.ListArguments()
                                                   where !inputs_name_set.Contains(x)
                                                   select x).ToArray();
            this._aux_names = this._train_mxnet_symbol.ListAuxiliaryStates().ToArray();
            var trainable_weights = (from x in this.TrainableWeights
                                                         select x.Name).ToList();
            this._fixed_weights = (from x in this._arg_names
                                   where !trainable_weights.Contains(x)
                                   select x).ToArray();

            // this._args = {x: bind_values[x] for x in this._arg_names if x in bind_values}
            this._args = new NDArrayDict();

            foreach (var x in this._arg_names)
            {
                if (bind_values.Contains(x))
                {
                    if (bind_values[x].SType == StorageStype.Csr)
                    {
                        this._args[x] = bind_values[x].ToSType(StorageStype.RowSparse);
                    }
                    else
                    {
                        this._args[x] = bind_values[x];
                    }
                }
            }

            this._auxs = new NDArrayDict();
            foreach (var x in this._aux_names)
            {
                this._auxs[x] = bind_values[x];
            }

            Func<int, (Symbol, string[], string[])> sym_gen = phase => {
                if (phase == (int)Phase.Train)
                {
                    return (this._train_mxnet_symbol, this._data_names, this._label_names);
                }
                else if (phase == (int)Phase.Test)
                {
                    return (this._test_mxnet_symbol, this._data_names, this._label_names);
                }
                else
                {
                    return (this._pred_mxnet_symbol, this._data_names, null);
                }
            };

            this._weights_dirty = false;
            if (this._context != null && this._context[0].GetDeviceType() ==  DeviceType.EIA)
            {
                // Only Prediction is Supported with EIA Context
                //this._module = new Module(this._pred_mxnet_symbol, data_names: this._data_names, label_names: this._label_names, context: this._context, fixed_param_names: this._fixed_weights);
            }
            else
            {
                // set the module
                this._module = new BucketingModule(sym_gen: sym_gen, default_bucket_key: (int)Phase.Pred, context: this._context, fixed_param_names: this._fixed_weights);
            }

            K.SetModel(this);
            this.compiled = true;
        }

        internal (NDArray[], NDArray[], Phase, DataDesc[], DataDesc[]) AdjustModule(KerasSymbol[] inputs, Phase phase)
        {
            DataDesc[] label_shapes;
            NDArray[] label;
            if (this._module == null)
            {
                throw new Exception("MXNet Backend: You must compile your model before using it.");
            }

            if (this._num_data + this._num_label == inputs.Length - 1)
            {
                inputs = inputs.Take(inputs.Length - 1).ToArray();
            }
            else if (this._num_data == inputs.Length - 1)
            {
                inputs = inputs.Take(inputs.Length - 1).ToArray();
            }

            Debug.Assert(this._num_data == inputs.Length || this._num_data + this._num_label == inputs.Length);
            var data = Enumerable.Zip(this.inputs, this.inputs.Take(this._num_data.Value).ToArray(), (s, x) => 
            {
                return x.Tensor.AsType(s.DType);
            }).ToArray();

            var data_shapes = Enumerable.Zip(this.inputs, data, (s, arr) =>
            {
                return new DataDesc(s.Name, arr.Shape, s.DType);
            }).ToArray();

            if (this._num_data < inputs.Length)
            {
                var labelList = new List<KerasSymbol>();
                labelList.AddRange(this.targets);
                labelList.AddRange(this.sample_weights);
                label = Enumerable.Zip(labelList, labelList.Take(this._num_data.Value).ToArray(), (s, x) =>
                {
                    return x.Tensor.AsType(s.DType);
                }).ToArray();

                label_shapes = Enumerable.Zip(labelList, data, (s, arr) =>
                {
                    return new DataDesc(s.Name, arr.Shape, s.DType);
                }).ToArray();
            }
            else
            {
                label = null;
                label_shapes = null;
            }

            if (!this._module.Binded)
            {
                // allow prediction without compiling the model using different binding
                if (phase ==  Phase.Pred && !this.compiled)
                {
                    this._module.Bind(data_shapes: data_shapes, label_shapes: null, for_training: false);
                    this.SetWeights();
                }
                else
                {
                    this._module.Bind(data_shapes: data_shapes, label_shapes: null, for_training: true);
                    this.SetWeights();
                    this._module.InitOptimizer(kvstore: this._kvstore, optimizer: this.optimizer);
                }
            }

            // If context is EIA, we will be directly using Module rather than Bucketing Module.
            // Hence, below specialization.
            if (this._module.GetType().Name == "BucketingModule")
            {
                this._module.SwitchBucket((int)phase, data_shapes, label_shapes);
                // adjust module data shape
                if (inputs[0].Shape[0] != this._module._curr_module._exec_group.BatchSize)
                {
                    this._module._curr_module.Reshape(data_shapes, label_shapes);
                    Debug.Assert(inputs[0].Shape[0] == this._module._curr_module._exec_group.BatchSize, "Reshape failed");
                }
            }
            else
            {
                // adjust module data shape
                //if (inputs[0].shape[0] != this._module._exec_group.batch_size)
                //{
                //    this._module.reshape(data_shapes, label_shapes);
                //    Debug.Assert(inputs[0].shape[0] == this._module._exec_group.batch_size);
                //    Debug.Assert("Reshape failed");
                //}
            }

            return (data, label, phase, data_shapes, label_shapes);
        }

        internal void SyncWeights()
        {
            if (this._weights_dirty != null)
            {
                var _tup_1 = this._module.GetParams();
                var args = _tup_1.Item1;
                var auxs = _tup_1.Item2;
                foreach (var name in this._arg_names)
                {
                    try
                    {
                        this._args[name] = args[name];
                    }
                    catch
                    {
                        // when name is not in this._args (key not found)
                        this._args[name] = args[name];
                    }
                }
                foreach (var name in this._aux_names)
                {
                    try
                    {
                        this._auxs[name] = auxs[name];
                    }
                    catch
                    {
                        // when name is not in this._auxs (key not found)
                        this._auxs[name] = auxs[name];
                    }
                }

                this._weights_dirty = false;
            }
        }

        internal void SetWeights(NDArrayDict arg_params = null, NDArrayDict auxs_params = null)
        {
            if (this._module.Binded)
            {
                this._module.SetParams(arg_params == null ? this._args : arg_params, auxs_params == null ? this._auxs : auxs_params, allow_missing: true);
                this._weights_dirty = arg_params != null || auxs_params != null;
            }
            else
            {
                if (arg_params != null)
                {
                    foreach (var k in arg_params)
                    {
                        this._args[k.Key] = k.Value;
                    }
                }
                if (auxs_params != null)
                {
                    foreach (var k in auxs_params)
                    {
                        this._auxs[k.Key] = k.Value;
                    }
                }
                this._weights_dirty = false;
            }
        }

        internal void Update(Dictionary<string, string> updates)
        {
            foreach (var exe in this._module._curr_module._exec_group.Execs)
            {
                var outs = exe.OutputDictionary();
                var args = exe.ArgmentDictionary();
                foreach (var u in updates)
                {
                    args[u.Key] = outs[u.Value + "_output"];
                }
            }
        }

        internal void MakeTrainFunction()
        {
            Func<KerasSymbol[], float[]> train_function = inputs => 
            {
                //Training._check_trainable_weights_consistency();
                var (data, label, _, data_shapes, label_shapes) = this.AdjustModule(inputs, Phase.Train);
                var batch = new DataBatch(data: data, label: label, bucket_key: (int)Phase.Train, provide_data: data_shapes, provide_label: label_shapes);
                this._module.ForwardBackward(batch);
                this._module.Update();
                this.Update(this._train_updates);
                this._weights_dirty = true;
                var outs = this._module.GetOutputs()[0].Take(this._ntrain.Value);
                return (from x in outs
                        select x.Mean()).ToArray();
            };

            this.train_function = train_function;
        }

        internal void MakeTestFunction()
        {
            Func<KerasSymbol[], float[]> test_function = inputs =>
            {
                //Training._check_trainable_weights_consistency();
                var (data, label, _, data_shapes, label_shapes) = this.AdjustModule(inputs, Phase.Test);
                var batch = new DataBatch(data: data, label: label, bucket_key: (int)Phase.Test, provide_data: data_shapes, provide_label: label_shapes);
                this._module.Forward(batch);
                if (this._test_updates != null)
                {
                    this.Update(this._test_updates);
                    this._weights_dirty = true;
                }

                var outs = this._module.GetOutputs()[0].Take(this._ntest.Value);
                return (from x in outs
                        select x.Mean()).ToArray();
            };

            this.test_function = test_function;
        }

        internal void MakePredictFunction()
        {
            Func<KerasSymbol[], float[]> pred_function = inputs =>
            {
                if (!this.compiled)
                {
                    if (this.built)
                    {
                        this._num_data = this.inputs.Count;
                        this._num_label = this.outputs.Count + this.output_names.Count;
                        // Create Module for Inference
                        this.CreatePredictFunction();
                    }

                    this._module = this._predict_only_module;
                    K.SetModel(this);
                }

                //Training._check_trainable_weights_consistency();
                var (data, label, _, data_shapes, label_shapes) = this.AdjustModule(inputs, Phase.Pred);
                var batch = new DataBatch(data: data, label: label, bucket_key: (int)Phase.Pred, provide_data: data_shapes, provide_label: label_shapes);
                this._module.Forward(batch, is_train: false);
                if (this._test_updates != null)
                {
                    this.Update(this._test_updates);
                    this._weights_dirty = true;
                }

                var outs = this._module.GetOutputs()[0].Take(this._npred.Value);
                return (from x in outs
                        select x.Mean()).ToArray();
            };

            this.predict_function = pred_function;
        }

        internal void CreatePredictFunction()
        {
            this._data_names = (from x in this.inputs
                                where x != null
                                select x.Name).ToArray();
            var state_updates = (from x in this.StateUpdates
                                 select x.Item2).ToList();
            // set for prediction
            this._npred = this.outputs.Count;
            List<KerasSymbol> predList = new List<KerasSymbol>();
            predList.AddRange(this.outputs);
            predList.AddRange((from symbol in state_updates
                               where !this.outputs.Contains(symbol)
                               select symbol).ToList());

            var pred_keras_symbol = K.Group(predList.ToArray());
            var bind_values = K.DfsGetBindValues(pred_keras_symbol);
            this._pred_mxnet_symbol = pred_keras_symbol.Symbol;
            // set the args and auxs
            var inputs_name_set = new HashSet<object>(this._data_names);
            this._arg_names = (from x in this._pred_mxnet_symbol.ListArguments()
                                                   where !inputs_name_set.Contains(x)
                                                   select x).ToArray();
            this._aux_names = this._pred_mxnet_symbol.ListAuxiliaryStates().ToArray();
            var trainable_weights = (from x in this.TrainableWeights
                                                         select x.Name).ToList();
            this._fixed_weights = (from x in this._arg_names
                                   where !trainable_weights.Contains(x)
                                   select x).ToArray();
            
            this._args = new NDArrayDict();
            foreach (var x in _arg_names)
            {
                _args.Add(x, bind_values[x]);
            }

            this._auxs = new NDArrayDict();
            foreach (var x in _aux_names)
            {
                _auxs.Add(x, bind_values[x]);
            }

            this._weights_dirty = false;
            // set module for prediction only
            if (this._context != null && this._context[0].GetDeviceType() ==  DeviceType.EIA)
            {
                // Only Prediction is Supported with EI Context
                //this._predict_only_module = mx.mod.Module(this._pred_mxnet_symbol, data_names: this._data_names, label_names: this._label_names, context: this._context[0], ////fixed_param_names: this._fixed_weights);
            }
            else
            {
                Func<int, (Symbol, string[], string[])> sym_gen = phase => {
                    return (this._pred_mxnet_symbol, this._data_names, null);
                };

                // separate module for using predict without compiling model
                this._predict_only_module = new BucketingModule(sym_gen: sym_gen, default_bucket_key: (int)Phase.Pred, context: this._context, fixed_param_names: this._fixed_weights);
            }
        }

        public void SetMxNetContext(Context context)
        {
            this._context = K.GetMxNetContexts(context);
        }

        public void SetMxNetContext(Context[] context)
        {
            this._context = context;
        }

        public void SetMxNetContext(int context)
        {
            this._context = K.GetMxNetContexts(context);
        }

        internal bool _uses_dynamic_learning_phase()
        {
            return this.UseLearningPhase && !(K.LearningPhase());
        }

        internal void SetInputs(NDArray[] inputs, KerasSymbol[]  outputs = null, bool? training= null)
        {
            if (this.GetType().Name == "Sequential")
            {
                // Note: we can't test whether the model
                // is `Sequential` via `isinstance`
                // since `Sequential` depends on `Model`.
                Debug.Assert(inputs.Length == 1);
                List<int> shape = new List<int>();
                shape.Add(-1);
                shape.AddRange(inputs[0].Shape.Data.Skip(1));
                this.Build(input_shape: new Shape(shape));
                return;
            }

            if (this.inputs != null)
            {
                throw new Exception("Model inputs are already set.");
            }

            // On-the-fly setting of symbolic model inputs
            // (either by using the tensor provided,
            // or by creating a placeholder if Numpy data was provided).
            this.inputs = new List<KerasSymbol>();
            this.input_names = new List<string>();
            this._feed_inputs = new List<KerasSymbol>();
            this._feed_input_names = new List<string>();
            this._feed_input_shapes = new List<Shape>();
            
            foreach (var (i, v) in inputs.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
            {
                var name = String.Format("input_" + i + 1);
                this.input_names.Add(name);
                
                List<int> shapeData = new List<int>();
                shapeData.Add(-1);
                shapeData.AddRange(v.Shape.Data.Skip(1));
                var shape = new Shape(shapeData);
                var placeholder = K.Placeholder(shape: shape, name: name);
                this.inputs.Add(placeholder);
                this._feed_inputs.Add(placeholder);
                this._feed_input_names.Add(name);
                this._feed_input_shapes.Add(shape);
            }

            if (outputs == null)
            {
                // Obtain symbolic outputs by calling the model.
                if (this._expects_training_arg)
                {
                    outputs = this.Invoke(this.inputs.ToArray(), new FuncArgs() { { "training", training } });
                }
                else
                {
                    outputs = this.Invoke(this.inputs.ToArray());
                }
            }

            this.outputs = outputs.ToList();
            this.output_names = (from i in Enumerable.Range(0, this.outputs.Count)
                                 select String.Format("output_{0}", i + 1)).ToList();
            this.built = true;
        }

        internal (NDArrayList, NDArrayList, NDArrayList) StandardizeUserData(NDArrayList x, NDArrayList y = null, NDArrayList sample_weight = null, NDArrayDict class_weight = null, bool check_array_lengths = true, int? batch_size = null)
        {
            NDArrayList sample_weights = new NDArrayList(); ;
            string[] feed_sample_weight_modes;
            Shape[] feed_output_shapes;
            string[] feed_output_names;
            Shape[] feed_input_shapes;
            string[] feed_input_names;
            var all_inputs = new NDArrayList();
            if (!this.built)
            {
                // We need to use `x` to set the model inputs.
                // We type-check that `x` and `y` are either single arrays
                // or lists of arrays.
                all_inputs.Add(x);
                if (this.inputs == null)
                {
                    this.SetInputs(x);
                }
            }
            if (y != null)
            {
                if (this.optimizer == null)
                {
                    throw new Exception("You must compile a model before training/testing. Use `model.compile(optimizer, loss)`.");
                }

                if (!this._is_compiled)
                {
                    // Typecheck that all inputs are *either* value *or* symbolic.
                    if (y != null)
                    {
                        all_inputs.Add(y);
                    }

                    this.Compile(optimizer: this.optimizer, loss: this.loss, metrics: this.metrics.ToArray(), loss_weights: this.loss_weights, target_tensors: all_inputs.ToArray());
                }
            }
            // If `x` and `y` were all symbolic,
            // then the model should not be fed any inputs and targets.
            // Note: in this case, `any` and `all` are equivalent since we disallow
            // mixed symbolic/value inputs.
            if ((from v in all_inputs
                 select K.IsTensor(v)).Any())
            {
                return (new NDArrayList(), new NDArrayList(), new NDArrayList());
            }
            // What follows is input validation and standardization to list format,
            // in the case where all inputs are value arrays.
            if (!this._is_graph_network)
            {
                // Case: symbolic-mode subclassed network.
                // Do not do shape validation.
                feed_input_names = this._feed_input_names.ToArray();
                feed_input_shapes = null;
            }
            else
            {
                // Case: symbolic-mode graph network.
                // In this case, we run extensive shape validation checks.
                feed_input_names = this._feed_input_names.ToArray();
                feed_input_shapes = this._feed_input_shapes.ToArray();
            }
            // Standardize the inputs.
            x = TrainingUtils.StandardizeInputData(x, feed_input_names, feed_input_shapes, check_batch_axis: false, exception_prefix: "input");
            if (y != null)
            {
                if (!this._is_graph_network)
                {
                    feed_output_names = this._feed_output_names.ToArray();
                    feed_output_shapes = null;
                    // Sample weighting not supported in this case.
                    // TODO: consider supporting it.
                    feed_sample_weight_modes = new string[this.outputs.Count];
                }
                else
                {
                    feed_output_names = this._feed_output_names.ToArray();
                    feed_sample_weight_modes = this._feed_sample_weight_modes.ToArray();
                    feed_output_shapes = Enumerable.Zip(this._feed_output_shapes, this._feed_loss_fns, (output_shape, loss_fn) =>
                    {
                        if (loss == "sparse_categorical_crossentropy")
                        {
                            if (K.ImageDataFormat() == "channels_first" && new List<int> {
                                    4,
                                    5
                                }.Contains(output_shape.Dimension))
                            {
                                var shapeData = new List<int>() { output_shape[0], 1 };
                                shapeData.AddRange(output_shape.Data.Skip(2));
                                return new Shape(shapeData);
                            }
                            else
                            {
                                var shapeData = new List<int>();
                                shapeData.AddRange(output_shape.Data.Take(output_shape.Dimension - 1));
                                shapeData.Add(1);

                                return new Shape(shapeData);
                            }
                        }
                        else
                        {
                            return output_shape;
                        }
                    }).ToArray();

                    var check_last_layer_shape = true;
                    foreach (var loss_fn in this.loss_functions)
                    {
                        if (loss == "multi_hot_sparse_categorical_crossentropy")
                        {
                            // does not check the last layer shape when multi_hot_sparse_categorical_crossentropy \
                            // is used, since we reduce the dimension of sparse labels.
                            check_last_layer_shape = false;
                        }
                    }

                    // Standardize the outputs.
                    y = TrainingUtils.StandardizeInputData(y, feed_output_names, feed_output_shapes, check_batch_axis: false, exception_prefix: "target", check_last_layer_shape: check_last_layer_shape);
                    // Generate sample-wise weight values given the `sample_weight` and
                    // `class_weight` arguments.
                    sample_weights = TrainingUtils.StandardizeSampleWeight(sample_weight, feed_output_names);
                    var class_weights = TrainingUtils.StandardizeClassWeight(class_weight, feed_output_names);
                    for (int i = 0; i < y.Length; i++)
                    {
                        var @ref = y[i];
                        var sw = sample_weights[i];
                        var cw = class_weights[i];
                        var mode = feed_sample_weight_modes[i];
                        sample_weights[i] = TrainingUtils.StandardizeWeights(@ref, sw, cw, mode);
                    }
                    // Check that all arrays have the same length.
                    TrainingUtils.CheckArrayLengthConsistency(x, y, sample_weights);
                    if (this._is_graph_network)
                    {
                        // Additional checks to avoid users mistakenly
                        // using improper loss fns.
                        TrainingUtils.CheckLossAndTargetCompatibility(y, this._feed_loss_fns.ToArray(), feed_output_shapes);
                    }
                }
            }
            else
            {
                y = new NDArrayList();
                sample_weights = new NDArrayList();
            }

            if (this.stateful && batch_size.HasValue)
            {
                // Check that for stateful networks, number of samples is a multiple
                // of the static batch size.
                if (x[0].Shape[0] % batch_size != 0)
                {
                    throw new Exception("In a stateful network, you should only pass inputs with a number of samples that can be divided by the batch size. Found: " + x[0].Shape[0] + " samples");
                }
            }

            return (x, y, sample_weights);
        }

        public void Fit(NDArray x, NDArray y, int? batch_size= null, int epochs= 1, int verbose= 1, Callback[] callbacks= null, float validation_split= 0, NDArrayList validation_data= null, bool shuffle= true, NDArrayDict class_weight= null, NDArray sample_weight= null, int initial_epoch= 0, int? steps_per_epoch= null, int? validation_steps= null)
        {
            List<string> callback_metrics = new List<string>();
            object val_function;
            NDArrayList fit_inputs = null;
            int split_at;
            NDArrayList val_inputs = null;
            NDArray val_sample_weights = null;
            NDArray val_sample_weight = null;
            NDArray val_y = null;
            NDArray val_x = null;
            // Backwards compatibility
            if (batch_size == null && steps_per_epoch == null)
            {
                batch_size = 32;
            }
           
            if (x == null && y == null && steps_per_epoch == null)
            {
                throw new Exception("If fitting from data tensors, you should specify the `steps_per_epoch` argument.");
            }
            // Validate user data.
            var _tup_1 = this.StandardizeUserData(x, y, sample_weight: sample_weight, class_weight: class_weight, batch_size: batch_size);
            x = _tup_1.Item1;
            y = _tup_1.Item2;
            NDArray sample_weights = _tup_1.Item3;
            // Prepare validation data.
            var do_validation = false;
            if (validation_data != null)
            {
                do_validation = true;
                if (validation_data.Length == 2)
                {
                    val_x = validation_data[0];
                    val_y = validation_data[1];
                    val_sample_weight = null;
                }
                else if (validation_data.Length == 3)
                {
                    val_x = validation_data[0];
                    val_y = validation_data[1];
                    val_sample_weight = validation_data[2];
                }
                else
                {
                    throw new Exception(String.Format("When passing validation_data, it must contain 2 (x_val, y_val) or 3 (x_val, y_val, val_sample_weights) items, however it contains {0} items", validation_data.Length));
                }

                var _tup_4 = this.StandardizeUserData(val_x, val_y, sample_weight: val_sample_weight, batch_size: batch_size);
                val_x = _tup_4.Item1;
                val_y = _tup_4.Item2;
                val_sample_weights = _tup_4.Item3;
                if (this._uses_dynamic_learning_phase())
                {
                    val_inputs = new NDArrayList(val_x, val_y, val_sample_weights, 0f);
                }
                else
                {
                    val_inputs = new NDArrayList(val_x, val_y, val_sample_weights);
                }
            }
            else if ((validation_split > 0) && (validation_split < 1))
            {
                do_validation = true;
                split_at = Convert.ToInt32(Convert.ToInt32(x.Shape[0]) * (1.0 - validation_split));

                var _tup_5 = (GenericUtils.SliceArrays(x, 0, split_at), GenericUtils.SliceArrays(x, split_at));
                x = _tup_5.Item1;
                val_x = _tup_5.Item2;
                var _tup_6 = (GenericUtils.SliceArrays(y, 0, split_at), GenericUtils.SliceArrays(y, split_at));
                y = _tup_6.Item1;
                val_y = _tup_6.Item2;
                var _tup_7 = (GenericUtils.SliceArrays(sample_weights, 0, split_at), GenericUtils.SliceArrays(sample_weights, split_at, null));
                sample_weights = _tup_7.Item1;
                val_sample_weights = _tup_7.Item2;
                if (this._uses_dynamic_learning_phase())
                {
                    val_inputs = new NDArrayList(val_x, val_y, val_sample_weights, 0f);
                }
                else
                {
                    val_inputs = new NDArrayList(val_x, val_y, val_sample_weights, 0f);
                }
            }
            else if (validation_steps.HasValue)
            {
                do_validation = true;
                if (this._uses_dynamic_learning_phase())
                {
                    val_inputs = new NDArrayList(0);
                }
            }
            // Prepare input arrays and training function.
            if (this._uses_dynamic_learning_phase())
            {
                fit_inputs = new NDArrayList(x, y, sample_weights, 0);
            }
            else
            {
                fit_inputs = x + y + sample_weights;
            }

            this.MakeTrainFunction();
            var fit_function = this.train_function;
            // Prepare display labels.
            var out_labels = this.metrics_names;
            if (do_validation)
            {
                this.MakeTestFunction();
                val_function = this.test_function;
                callback_metrics.AddRange(out_labels);
                callback_metrics.AddRange((from n in out_labels
                                           select ("val_" + n)));
            }
            else
            {
                callback_metrics.AddRange(out_labels);
                val_function = null;
                val_inputs = new NDArrayList();
            }

            // Delegate logic to `fit_loop`.
            return TrainingArrays.FitLoop(this, fit_function, fit_inputs, out_labels: out_labels, batch_size: batch_size, epochs: epochs, verbose: verbose, callbacks: callbacks, val_function: val_function, val_inputs: val_inputs, shuffle: shuffle, callback_metrics: callback_metrics, initial_epoch: initial_epoch, steps_per_epoch: steps_per_epoch, validation_steps: validation_steps);
        }

        public void Evaluate(NDArray x, NDArray y, int? batch_size = null, int epochs = 1, int verbose = 1, NDArray sample_weight = null, int? steps = null)
        {
            throw new NotImplementedException();
        }

        public NDArray Predict(NDArray x, int? batch_size = null, int verbose = 0, int? steps = null)
        {
            throw new NotImplementedException();
        }

        public void TrainOnBatch(NDArray x, NDArray y, NDArray sample_weight = null, Dictionary<int, float> class_weight = null)
        {
            throw new NotImplementedException();
        }

        public void TestOnBatch(NDArray x, NDArray y, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public void PredictOnBatch(NDArray x)
        {
            throw new NotImplementedException();
        }

        public void FitGenerator(Sequence<(NDArray, NDArray, NDArray)> x, int? steps_per_epoch = null, int epochs = 1, int verbose = 1, Callback[] callbacks = null, NDArrayList validation_data = null, int? validation_steps = null, Dictionary<int, float> class_weight = null, int max_queue_size= 10, int workers= 1, bool use_multiprocessing= false, bool shuffle = true, int initial_epoch = 0)
        {
            throw new NotImplementedException();
        }

        public void EvaluateGenerator(Sequence<(NDArray, NDArray, NDArray)> x, int? steps = null, int max_queue_size = 10, int workers = 1, bool use_multiprocessing = false, int verbose = 0)
        {
            throw new NotImplementedException();
        }

        public void PredictGenerator(Sequence<(NDArray, NDArray, NDArray)> x, int? steps = null, int max_queue_size = 10, int workers = 1, bool use_multiprocessing = false, int verbose = 0)
        {
            throw new NotImplementedException();
        }
    }
}
