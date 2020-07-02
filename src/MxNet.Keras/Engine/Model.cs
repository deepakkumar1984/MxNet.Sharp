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

        internal Optimizer optimizer;

        internal Symbol _pred_mxnet_symbol;

        internal BucketingModule _module;

        public KerasSymbol[] _collected_trainable_weights;

        public List<string> _feed_input_names;

        public List<Shape> _feed_input_shapes;

        public List<KerasSymbol> _feed_inputs;

        public List<Func<KerasSymbol, KerasSymbol, KerasSymbol>> _feed_loss_fns;

        public List<string> _feed_output_names;

        public List<Shape> _feed_output_shapes;

        public List<KerasSymbol> _feed_outputs;

        public List<string> _feed_sample_weight_modes;

        public List<KerasSymbol> _feed_sample_weights;

        public List<KerasSymbol> _feed_targets;

        public FuncArgs _function_kwargs;

        public bool _is_compiled;

        public bool built;

        public List<string> input_names;

        public List<KerasSymbol> inputs;

        public string loss;

        public List<Func<KerasSymbol, KerasSymbol, KerasSymbol>> loss_functions;

        public float[] loss_weights;

        public List<string> metrics;

        public List<string> metrics_names;

        public List<KerasSymbol> metrics_tensors;

        public object metrics_updates;

        public List<string> output_names;

        public List<KerasSymbol> outputs;

        public object predict_function;

        public object sample_weight_mode;

        public List<object> sample_weight_modes;

        public List<KerasSymbol> sample_weights;

        public List<object> stateful_metric_functions;

        public List<string> stateful_metric_names;

        public List<KerasSymbol> targets;

        public object test_function;

        public KerasSymbol total_loss;

        public object train_function;

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

        private void BaseCompile(Optimizer optimizer, string loss = null, string[] metrics = null, float[] loss_weights = null, string sample_weight_mode = null)
        {

        }

        public void Compile(Optimizer optimizer, string loss= null, string[] metrics= null, float[] loss_weights= null, string sample_weight_mode= null, Context context = null)
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

            // self._args = {x: bind_values[x] for x in self._arg_names if x in bind_values}
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

        internal void AdjustModule(KerasSymbol[] inputs, string phase)
        {
            throw new NotImplementedException();
        }

        internal bool SyncWeights()
        {
            throw new NotImplementedException();
        }

        internal void SetWeights(NDArrayDict arg_params = null, NDArrayDict auxs_params = null)
        {
            throw new NotImplementedException();
        }

        internal void Update(KerasSymbol[] updates)
        {
            throw new NotImplementedException(); 
        }

        internal void MakeTrainFunction()
        {
            throw new NotImplementedException();
        }

        internal void MakeTestFunction()
        {
            throw new NotImplementedException();
        }

        internal void MakePredictFunction()
        {
            throw new NotImplementedException();
        }

        internal void CreatePredictFunction()
        {
            throw new NotImplementedException();
        }

        public void SetMxNetContext(Context context)
        {
            throw new NotImplementedException();
        }

        internal bool _uses_dynamic_learning_phase()
        {
            throw new NotImplementedException();
        }

        internal void _set_inputs(Symbol[] inputs, Symbol[]  outputs = null, bool? training= null)
        {
            throw new NotImplementedException();
        }

        internal void _standardize_user_data(NDArray x, NDArray y= null, NDArray sample_weight = null, Dictionary<int, float> class_weight = null, bool check_array_lengths= true, int? batch_size= null)
        {
            throw new NotImplementedException();
        }

        public void Fit(NDArray x, NDArray y, int? batch_size= null, int epochs= 1, int verbose= 1, Callback[] callbacks= null, float validation_split= 0, NDArrayList validation_data= null, bool shuffle= true, Dictionary<int, float> class_weight= null, NDArray sample_weight= null, int initial_epoch= 0, int? steps_per_epoch= null, int? validation_steps= null)
        {
            throw new NotImplementedException();
        }

        public void Evaluate(NDArray x, NDArray y, int? batch_size = null, int epochs = 1, int verbose = 1, NDArray sample_weight = null, int? steps = null)
        {
            throw new NotImplementedException();
        }

        public void Predict(NDArray x, int? batch_size = null, int verbose = 0, int? steps = null)
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
