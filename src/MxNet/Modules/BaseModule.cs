using System;
using System.Collections.Generic;
using System.Linq;
using MxNet.Callbacks;
using MxNet.Initializers;
using MxNet.IO;
using MxNet.Metrics;
using MxNet.Optimizers;

namespace MxNet.Modules
{
    public abstract class BaseModule
    {
        internal Symbol _symbol;
        internal int _total_exec_bytes;

        public BaseModule()
        {
            Binded = false;
            ForTraining = false;
            InputsNeedGrad = false;
            ParamsInitialized = false;
            OptimizerInitialized = false;
            _symbol = null;
            _total_exec_bytes = 0;
        }

        public bool Binded { get; set; }

        public bool ForTraining { get; set; }

        public bool InputsNeedGrad { get; set; }

        public bool ParamsInitialized { get; set; }

        public bool OptimizerInitialized { get; set; }

        public abstract string[] DataNames { get; }

        public abstract string[] OutputNames { get; }

        public abstract string[] LabelNames { get; }

        public abstract DataDesc[] DataShapes { get; }

        public abstract DataDesc[] LabelShapes { get; }

        public abstract DataDesc[] OutputShapes { get; }

        public virtual Symbol Symbol => _symbol;

        public void ForwardBackward(DataBatch data_batch)
        {
            Forward(data_batch);
            Backward();
        }

        public Dictionary<string, float> Score(DataIter eval_data, EvalMetric eval_metric, int? num_batch = null,
            IBatchEndCallback[] batch_end_callback = null,
            IScoreEndCallback[] score_end_callback = null, bool reset = true, int epoch = 0,
            Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            if (!Binded && !ParamsInitialized) throw new Exception("Module not binded and param initialized");

            eval_metric.Reset();
            var actual_num_batch = 0;
            while (eval_data.End())
            {
                if (num_batch.HasValue && eval_data.Cursor == num_batch.Value)
                    break;

                var eval_batch = eval_data.Next();
                Prepare(eval_batch, sparse_row_id_fn);
                Forward(eval_batch, false);
                UpdateMetric(eval_metric, eval_batch.Label, true);
                if (batch_end_callback != null)
                    foreach (var callback in batch_end_callback)
                        callback.Invoke(epoch, eval_data.Cursor, eval_metric);

                actual_num_batch++;
            }

            if (score_end_callback != null)
                foreach (var callback in score_end_callback)
                    callback.Invoke(epoch, actual_num_batch, eval_metric, new FuncArgs());

            return eval_metric.GetNameValue();
        }

        public IEnumerable<(NDArrayList, int, DataBatch)> IterPredict(DataIter eval_data, int? num_batch = null,
            bool reset = true, int epoch = 0, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            if (!Binded && !ParamsInitialized) throw new Exception("Module not binded and param initialized");

            if (reset)
                eval_data.Reset();

            while (eval_data.End())
            {
                if (num_batch.HasValue && eval_data.Cursor == num_batch.Value)
                    break;

                var eval_batch = eval_data.Next();
                Prepare(eval_batch, sparse_row_id_fn);
                Forward(eval_batch, false);
                var pad = eval_batch.Pad.Value;
                var outputs = new NDArrayList();
                foreach (var list in GetOutputs())
                foreach (var @out in list)
                    outputs.Add(@out[$"0:{@out.Shape[0] - pad}"]);

                yield return (outputs.ToArray(), eval_data.Cursor, eval_batch);
            }
        }

        public List<NDArrayList> Predict(DataIter eval_data, int? num_batch = null, bool merge_batches = true,
            bool reset = true, bool always_output_list = true, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            if (!Binded && !ParamsInitialized) throw new Exception("Module not binded and param initialized");

            if (reset)
                eval_data.Reset();

            var output_list = new List<NDArrayList>();
            var output_list2 = new NDArrayList();
            while (eval_data.End())
            {
                if (num_batch.HasValue && eval_data.Cursor == num_batch.Value)
                    break;

                var eval_batch = eval_data.Next();
                Prepare(eval_batch, sparse_row_id_fn);
                Forward(eval_batch, false);
                var pad = eval_batch.Pad.Value;
                var outputs = new NDArrayList();
                foreach (var list in GetOutputs())
                foreach (var @out in list)
                    outputs.Add(@out[$"0:{@out.Shape[0] - pad}"].Copy());

                output_list.Add(outputs.ToArray());
            }

            if (output_list.Count == 0)
                return output_list;

            if (merge_batches)
            {
                var num_outputs = output_list[0].Length;
                foreach (var @out in output_list)
                {
                    if (@out.Length != num_outputs)
                        throw new Exception("Cannot merge batches, as num of outputs is not the same " +
                                            "in mini-batches. Maybe bucketing is used?");

                    output_list2.Add(nd.Concat(@out));
                }

                return new List<NDArrayList> {output_list2.ToArray()};
            }

            return output_list;
        }

        public void Fit(DataIter train_data, DataIter eval_data = null, string eval_metric = "acc",
            IEpochEndCallback[] epoch_end_callback = null, IBatchEndCallback[] batch_end_callback = null,
            string kvstore = "local",
            string optimizer = "sgd", Dictionary<string, object> optimizer_params = null,
            IBatchEndCallback[] eval_end_callback = null,
            IBatchEndCallback[] eval_batch_end_callback = null, Initializer initializer = null,
            NDArrayDict arg_params = null,
            NDArrayDict aux_params = null, bool allow_missing = false, bool force_rebind = false,
            bool force_init = false, int begin_epoch = 0, int? num_epoch = null, EvalMetric validation_metric = null,
            Monitor monitor = null, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            throw new NotImplementedException();
        }

        public abstract (NDArrayDict, NDArrayDict) GetParams();

        public abstract void InitParams(Initializer initializer = null, NDArrayDict arg_params = null,
            NDArrayDict aux_params = null,
            bool allow_missing = false, bool force_init = false, bool allow_extra = false);

        public virtual void SetParams(NDArrayDict arg_params = null, NDArrayDict aux_params = null,
            bool allow_missing = false, bool force_init = false, bool allow_extra = false)
        {
            InitParams(null, arg_params, aux_params, allow_missing, force_init, allow_extra);
        }

        public virtual void SaveParams(string fname)
        {
            var (arg_params, aux_params) = GetParams();
            var save_dict = new NDArrayDict();
            foreach (var item in arg_params) save_dict["arg:" + item.Key] = item.Value.AsInContext(Context.Cpu());

            foreach (var item in aux_params) save_dict["aux:" + item.Key] = item.Value.AsInContext(Context.Cpu());

            NDArray.Save(fname, save_dict);
        }

        public virtual void LoadParams(string fname)
        {
            var save_dict = NDArray.Load(fname);
            var arg_params = new NDArrayDict();
            var aux_params = new NDArrayDict();
            foreach (var item in save_dict)
            {
                var arg_type = item.Key.Split(':')[0];
                var name = item.Key.Split(':')[1];
                if (arg_type == "arg")
                    arg_params[name] = item.Value;
                else if (arg_type == "aux")
                    aux_params[name] = item.Value;
                else
                    throw new Exception("Invalid param file: " + fname);
            }

            SetParams(arg_params, aux_params);
        }

        public virtual List<NDArrayList> GetStates(bool merge_multi_context = true)
        {
            if (!Binded && !ParamsInitialized) throw new Exception("Module not binded and param initialized");

            if (!merge_multi_context) throw new Exception("Invalid value merge_multi_context");

            return new List<NDArrayList>();
        }

        public virtual void SetStates(List<NDArrayList> states, int value)
        {
            if (!Binded && !ParamsInitialized) throw new Exception("Module not binded and param initialized");

            if (states == null) throw new Exception("States is passed null");
        }

        public abstract void InstallMonitor(Monitor mon);

        public virtual void Prepare(DataBatch data_batch, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            if (sparse_row_id_fn != null)
                Logger.Warning("sparse_row_id_fn is not invoked for BaseModule.");
        }

        public abstract void Forward(DataBatch data_batch, bool is_train = true);

        public abstract void Backward(NDArrayList out_grads = null);

        public abstract List<NDArrayList> GetOutputs(bool merge_multi_context = true);

        public abstract List<NDArrayList> GetInputGrads(bool merge_multi_context = true);

        public abstract void Update();

        public abstract void UpdateMetric(EvalMetric eval_metric, NDArrayList labels, bool pre_sliced = false);

        public abstract void Bind(DataDesc[] data_shapes, DataDesc[] label_shapes = null, bool for_training = true,
            bool inputs_need_grad = false, bool force_rebind = false, Module shared_module = null,
            OpGradReq grad_req = OpGradReq.Write);

        public abstract void InitOptimizer(string kvstore = "local", Optimizer optimizer = null,
            Dictionary<string, object> optimizer_params = null, bool force_init = false);

        internal static void CheckInputNames(Symbol symbol, string[] names, string typename, bool @throw)
        {
            var args = symbol.ListArguments();
            foreach (var name in names)
            {
                if (args.Contains(name))
                    continue;

                var candidates = args.Where(x =>
                        !x.EndsWith("_weight") && !x.EndsWith("_bias") && !x.EndsWith("_gamma") && !x.EndsWith("_beta"))
                    .ToList();
                var msg =
                    $"\033[91mYou created Module with Module(..., {typename}_names ={string.Join(", ", names)}) but " +
                    $"input with name '{string.Join("\n\t", candidates)}' is not found in symbol.list_arguments(). " +
                    "Did you mean one of:\n\t%s\033[0m";

                if (@throw)
                    throw new Exception(msg);
                Logger.Warning(msg);
            }
        }

        internal static void CheckNamesMatch(string[] data_names, DataDesc[] data_shapes, string name, bool @throw)
        {
            var actual = (from x in data_shapes select x.Name).ToList();
            actual.Sort();
            var actual_str = string.Join(", ", actual);
            var names = data_names.ToList();
            names.Sort();
            var data_names_str = string.Join(", ", names);
            if (data_names.Length != data_shapes.Length)
            {
                var msg = $"Data provided by {name}_shapes don't match names specified by {name}_names";
                if (@throw)
                    throw new Exception(msg);
                Logger.Warning(msg);
            }
        }

        internal static (DataDesc[], DataDesc[]) ParseDataDesc(string[] data_names, string[] label_names,
            DataDesc[] data_shapes, DataDesc[] label_shapes)
        {
            CheckNamesMatch(data_names, data_shapes, "data", true);
            if (label_shapes != null)
                CheckNamesMatch(label_names, label_shapes, "label", false);
            else
                CheckNamesMatch(label_names, new DataDesc[0], "label", false);

            return (data_shapes, label_shapes);
        }
    }
}