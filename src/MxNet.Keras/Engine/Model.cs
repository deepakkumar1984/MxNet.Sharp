using MxNet.Keras.Callbacks;
using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;
using MxNet.Keras.Utils;
using MxNet.Keras.Optimizers;
using MxNet.Modules;

namespace MxNet.Keras.Engine
{
    public class Model : Network
    {
        internal NDArrayDict _args;

        internal NDArrayDict _auxs;

        internal bool stop_training;

        internal Optimizer optimizer;

        internal Symbol _pred_mxnet_symbol;

        internal BucketingModule _module;

        public object _collected_trainable_weights;

        public List<string> _feed_input_names;

        public List<Shape> _feed_input_shapes;

        public List<object> _feed_inputs;

        public List<object> _feed_loss_fns;

        public List<object> _feed_output_names;

        public List<object> _feed_output_shapes;

        public List<object> _feed_outputs;

        public List<object> _feed_sample_weight_modes;

        public List<object> _feed_sample_weights;

        public List<object> _feed_targets;

        public object _function_kwargs;

        public bool _is_compiled;

        public bool built;

        public List<object> input_names;

        public List<object> inputs;

        public List<object> loss;

        public object loss_functions;

        public object loss_weights;

        public List<object> metrics;

        public List<string> metrics_names;

        public List<object> metrics_tensors;

        public object metrics_updates;

        public List<object> output_names;

        public object outputs;

        public object predict_function;

        public object sample_weight_mode;

        public List<object> sample_weight_modes;

        public List<object> sample_weights;

        public List<object> stateful_metric_functions;

        public List<object> stateful_metric_names;

        public List<object> targets;

        public object test_function;

        public object total_loss;

        public object train_function;

        public object weighted_metrics;

        public void Compile(Optimizer optimizer, string loss= null, string[] metrics= null, float[] loss_weights= null, string sample_weight_mode= null)
        {
            throw new NotImplementedException();
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
