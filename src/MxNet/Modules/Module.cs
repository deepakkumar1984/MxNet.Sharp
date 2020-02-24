using MxNet.Initializers;
using MxNet.IO;
using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MxNet.Optimizers;
using MxNet.KVstore;
using System.IO;

namespace MxNet.Modules
{
    public class Module : BaseModule
    {
        private Context[] _context;
        private int[] _work_load_list;
        private Dictionary<string, Context> _group2ctxs;
        private string[] _param_names = null;
        private string[] _fixed_param_names = null;
        private string[] _aux_names = null;
        private string[] _data_names = null;
        private string[] _label_names = null;
        private string[] _state_names = null;
        private string[] _output_names = null;
        private NDArrayDict _arg_params = null;
        private NDArrayDict _aux_params = null;
        private bool _params_dirty;
        private Dictionary<string, object> _compression_params;
        private Optimizer _optimizer;
        private KVStore _kvstore;
        private bool? _update_on_kvstore;
        private Updater _updater;
        private string _preload_opt_states;
        private OpGradReq _grad_req;
        private DataParallelExecutorGroup _exec_group;
        private DataDesc[] _data_shapes;
        private DataDesc[] _label_shapes;

        public override string[] DataNames => _data_names;

        public override string[] OutputNames => _output_names;

        public override string[] LabelNames => _label_names;

        public override DataDesc[] DataShapes => _data_shapes;

        public override DataDesc[] LabelShapes => _label_shapes;

        public override Shape[] OutputShapes
        {
            get
            {
                if (Binded)
                    return _exec_group.GetOutputShapes();

                return null;
            }
        }

        public Module(Symbol symbol, string[] data_names = null, string[] label_names = null, Logger logging = null,
                            Context[] context = null, int[] work_load_list = null, string[] fixed_param_names = null, string[] state_names = null,
                            Dictionary<string, Context> group2ctxs = null, Dictionary<string, object> compression_params = null)
        {
            if (context == null)
                context = new Context[] { Context.Cpu() };

            if(work_load_list == null)
            {
                work_load_list = new int[context.Length];
                for (int i = 0;i< work_load_list.Length;i++)
                {
                    work_load_list[i] = 1;
                }
            }

            if (context.Length != work_load_list.Length)
                throw new Exception("Context and WorkLoadList length are not equal");

            _group2ctxs = group2ctxs;
            _symbol = symbol;
            _data_names = data_names != null ? data_names : new string[0];
            _label_names = label_names != null ? label_names : new string[0];
            _state_names = state_names != null ? state_names : new string[0];
            _fixed_param_names = fixed_param_names != null ? fixed_param_names : new string[0];
            CheckInputNames(symbol, _data_names, "data", true);
            CheckInputNames(symbol, _label_names, "label", false);
            CheckInputNames(symbol, _state_names, "state", true);
            CheckInputNames(symbol, _fixed_param_names, "fixed_param", true);

            var arg_names = symbol.ListArguments();
            List<string> input_names = new List<string>();
            input_names.AddRange(_data_names);
            input_names.AddRange(_label_names);
            input_names.AddRange(_state_names);

            _param_names = arg_names.Where(x => (arg_names.Contains(x))).ToArray();
            _aux_names = symbol.ListAuxiliaryStates().ToArray();
            _output_names = symbol.ListOutputs().ToArray();
            _arg_params = null;
            _aux_params = null;
            _params_dirty = false;

            _compression_params = compression_params;
            _optimizer = null;
            _kvstore = null;
            _update_on_kvstore = null;
            _updater = null;
            _preload_opt_states = null;
            _grad_req = OpGradReq.Null;

            _exec_group = null;
            _data_shapes = null;
            _label_shapes = null;
        }

        public void SaveCheckpoint(string prefix, int epoch, bool save_optimizer_states = false, bool remove_amp_cast = false)
        {
            Symbol.Save($"{prefix}-symbol.json", remove_amp_cast: remove_amp_cast);
            string param_name = $"{prefix}-{epoch.ToString("D4")}.params";
            SaveParams(param_name);
            Logger.Info($"Saved checkpoint to {param_name}");
            if(save_optimizer_states)
            {
                string state_name = $"{prefix}-{epoch.ToString("D4")}.params";
                SaveOptimizerStates(state_name);
                Logger.Info($"Saved optimizer state to {state_name}");
            }
        }

        public static Module Load(string prefix, int epoch, bool load_optimizer_states = false, string[] data_names = null, string[] label_names = null, Logger logging = null,
                            Context context = null, int[] work_load_list = null, string[] fixed_param_names = null)
        {
            var (sym, args, auxs) = Model.LoadCheckpoint(prefix, epoch);
            var mod = new Module(sym);
            mod._arg_params = args;
            mod._aux_params = auxs;
            mod.ParamsInitialized = true;
            if (load_optimizer_states)
                mod._preload_opt_states = $"{prefix}-{epoch.ToString("D4")}.states";

            return mod;
        }

        private void ResetBind()
        {
            Binded = false;
            _exec_group = null;
            _data_shapes = null;
            _label_shapes = null;
        }

        public override void Backward(NDArray[] out_grads = null)
        {
            if (!Binded && !ParamsInitialized)
            {
                throw new Exception("Module not binded and param initialized");
            }

            _exec_group.Backward(out_grads);
        }

        public override void Bind(DataDesc[] data_shapes, DataDesc[] label_shapes = null, bool for_training = true, bool inputs_need_grad = false, bool force_rebind = false, Module shared_module = null, OpGradReq grad_req = OpGradReq.Write)
        {
            if (force_rebind)
                ResetBind();

            if(Binded)
            {
                Logger.Warning("Already bound, ignoring bind()");
                return;
            }

            ForTraining = for_training;
            InputsNeedGrad = inputs_need_grad;
            _grad_req = grad_req;

            if (!ForTraining)
                if (InputsNeedGrad)
                    throw new Exception("inputs_need_grad should be false if for_training=false");

            (_data_shapes, _label_shapes) = ParseDataDesc(DataNames, LabelNames, data_shapes, label_shapes);

            DataParallelExecutorGroup shared_group = null;
            if(shared_module != null)
            {
                if (!shared_module.Binded && !shared_module.ParamsInitialized)
                    throw new Exception("shared_module not bounded or initialized");

                shared_group = shared_module._exec_group;
                if (shared_group.Execs.Length < _context.Length)
                    throw new Exception("shared_group execs length is less than context length");
            }

            _exec_group = new DataParallelExecutorGroup(_symbol, _context, _work_load_list, _data_shapes, _label_shapes, _param_names,
                                                        ForTraining, InputsNeedGrad, shared_group, _fixed_param_names, grad_req,
                                                        _state_names, _group2ctxs);
            _total_exec_bytes = this._exec_group._total_exec_bytes;
            if(shared_group != null)
            {
                ParamsInitialized = true;
                _arg_params = shared_group._arg_params;
                _aux_params = shared_group._aux_params;
            }
            else if(ParamsInitialized)
            {
                _exec_group.SetParams(_arg_params, _aux_params);
            }
            else
            {
                if (_arg_params != null && _aux_params != null)
                    throw new Exception("arg and aux params should be null");
                _arg_params = new NDArrayDict();
                _aux_params = new NDArrayDict();

                var param_arrays = _exec_group.ParamArrays.Select(x => (nd.ZerosLike(x[0]))).ToArray();
                for(int i = 0;i< _param_names.Length;i++)
                {
                    _arg_params[_param_names[i]] = param_arrays[i];
                }

                var aux_arrays = _exec_group.AuxArrays.Select(x => (nd.ZerosLike(x[0]))).ToArray();
                for (int i = 0; i < _aux_names.Length; i++)
                {
                    _aux_params[_aux_names[i]] = aux_arrays[i];
                }
            }

            if (shared_module != null && shared_module.ParamsInitialized)
                BorrowOptimizer(shared_module);

            Binded = true;
        }

        public override void Forward(DataBatch data_batch, bool is_train = true)
        {
            if (!Binded && !ParamsInitialized)
            {
                throw new Exception("Module not binded and param initialized");
            }

            var curr_data_shapes = _data_shapes.Select(x => x.Shape).ToArray();
            var new_data_shapes = data_batch.Data.Select(x => (x.Shape)).ToArray();
            if(curr_data_shapes.Length != new_data_shapes.Length)
            {
                DataDesc[] new_dshape;
                DataDesc[] new_lshape;

                if (data_batch.ProvideData != null)
                    new_dshape = data_batch.ProvideData;
                else
                {
                    new_dshape = Enumerable.Zip(_data_shapes, new_data_shapes, (i, shape)=>
                    {
                        return new DataDesc(i.Name, shape, i.DataType, i.Layout);
                    }).ToArray();
                }

                if (data_batch.ProvideLabel != null)
                    new_lshape = data_batch.ProvideData;
                else if (data_batch.Label != null)
                {
                    new_lshape = Enumerable.Zip(_label_shapes, data_batch.Label, (i, j) =>
                    {
                        return new DataDesc(i.Name, j.Shape, i.DataType, i.Layout);
                    }).ToArray();
                }
                else
                    new_lshape = null;

                Reshape(new_dshape, new_lshape);
            }

            _exec_group.Forward(data_batch, is_train);
        }

        public override List<NDArray[]> GetInputGrads(bool merge_multi_context = true)
        {
            if (!Binded && !ParamsInitialized)
            {
                throw new Exception("Module not binded and param initialized");
            }

            return _exec_group.GetInputGrads(merge_multi_context);
        }

        public override List<NDArray[]> GetOutputs(bool merge_multi_context = true)
        {
            if (!Binded && !ParamsInitialized)
            {
                throw new Exception("Module not binded and param initialized");
            }

            return _exec_group.GetOutputs(merge_multi_context);
        }

        public override List<NDArray[]> GetStates(bool merge_multi_context = true)
        {
            if (!Binded && !ParamsInitialized)
            {
                throw new Exception("Module not binded and param initialized");
            }

            return _exec_group.GetStates(merge_multi_context);
        }

        public override void SetStates(List<NDArray[]> states, int value)
        {
            if (!Binded && !ParamsInitialized)
            {
                throw new Exception("Module not binded and param initialized");
            }

            _exec_group.SetStates(states, value);
        }

        public override (NDArrayDict, NDArrayDict) GetParams()
        {
            if (!Binded && !ParamsInitialized)
            {
                throw new Exception("Module not binded and param initialized");
            }

            if (_params_dirty)
                SyncParamsFromDevices();

            return (_arg_params, _aux_params);
        }

        public override void InitOptimizer(string kv = "local", Optimizer optimizer = null, Dictionary<string, object> optimizer_params = null, bool force_init = false)
        {
            if (!Binded && !ParamsInitialized)
            {
                throw new Exception("Module not binded and param initialized");
            }

            if(OptimizerInitialized && !force_init)
            {
                Logger.Warning("optimizer already initialized, ignoring...");
                return;
            }

            if (optimizer == null)
                optimizer = new SGD(); 

            if (_params_dirty)
                SyncParamsFromDevices();

            var (kvstore, update_on_kvstore) = Model.CreateKVStore(kv, _context.Length, _arg_params);
            int batch_size = _exec_group.BatchSize;
            if (kvstore != null && kvstore.Type.Contains("dist") && kvstore.Type.Contains("_sync"))
                batch_size *= kvstore.NumWorkers;

            var rescale_grad = 1.0 / batch_size;
            Dictionary<int, string> idx2name = new Dictionary<int, string>();
            if(update_on_kvstore)
            {
                int i = 0;
                foreach (var name in _exec_group.ParamNames)
                {
                    idx2name.Add(i, name);
                    i++;
                }
            }
            else
            {
                for(int k = 0;k<_context.Length;k++)
                {
                    int i = 0;
                    foreach (var name in _exec_group.ParamNames)
                    {
                        idx2name.Add(i * _context.Length + k, name);
                        i++;
                    }
                }
            }

            if(optimizer.RescaleGrad != rescale_grad)
                Logger.Warning("Optimizer created manually outside Module but rescale_grad " +
                                $"is not normalized to 1.0/batch_size/num_workers ({optimizer.RescaleGrad} vs. {rescale_grad}). Is this intended?");

            if (optimizer.Idx2Name == null)
            {
                optimizer.Idx2Name = idx2name;
            }

            _optimizer = optimizer;
            _kvstore = kvstore;
            _update_on_kvstore = update_on_kvstore;
            _updater = null;
            if(kvstore != null)
            {
                if (_compression_params != null)
                    kvstore.SetGradientCompression(_compression_params);

                if (update_on_kvstore)
                    kvstore.SetOptimizer(_optimizer);

                Model.InitializeKVStore(kvstore, _exec_group.ParamArrays, _arg_params, _param_names, update_on_kvstore);
            }

            if (!update_on_kvstore)
                _updater = optimizer.GetUpdater();

            OptimizerInitialized = true;
            if(!string.IsNullOrWhiteSpace(_preload_opt_states))
            {
                LoadOptimizerStates(_preload_opt_states);
                _preload_opt_states = "";
            }
        }

        public override void InitParams(Initializer initializer = null, NDArrayDict arg_params = null, NDArrayDict aux_params = null, bool allow_missing = false, bool force_init = false, bool allow_extra = false)
        {
            if (ParamsInitialized && !force_init)
            {
                Logger.Warning("Parameters already initialized and force_init=False. init_params call ignored.");
                return;
            }

            if (!Binded)
                throw new Exception("call bind before initializing the parameters");

            void impl(InitDesc name, ref NDArray arr, NDArrayDict cache)
            {
                if(cache!=null)
                {
                    NDArray cache_arr = null;
                    if (cache.Contains(name.Name))
                    {
                        cache_arr = cache[name.Name];

                        if (cache_arr != arr)
                            cache_arr.CopyTo(arr);
                    }
                    else
                    {
                        if(!allow_missing)
                            throw new Exception($"{name.Name} is not presented");

                        if (initializer != null)
                            initializer.InitWeight(name.Name, ref arr);
                    }
                }
            }

            var attr = Symbol.AttrDict();
            foreach (var name in _arg_params.Keys)
            {
                var arr = _arg_params[name];
                var desc = new InitDesc(name, attr.ContainsKey(name) ? attr[name] : null);
                impl(desc, ref arr, arg_params);
            }

            foreach (var name in _aux_params.Keys)
            {
                var arr = _aux_params[name];
                var desc = new InitDesc(name, attr.ContainsKey(name) ? attr[name] : null);
                impl(desc, ref arr, aux_params);
            }

            ParamsInitialized = true;
            _params_dirty = false;
            _exec_group.SetParams(_arg_params, _aux_params, allow_extra: allow_extra);
        }

        public override void SetParams(NDArrayDict arg_params = null, NDArrayDict aux_params = null, bool allow_missing = false, bool force_init = false, bool allow_extra = false)
        {
            if (!allow_missing)
            {
                InitParams(null, arg_params, aux_params, allow_missing, force_init, allow_extra);
                return;
            }

            if (ParamsInitialized && !force_init)
            {
                Logger.Warning("Parameters already initialized and force_init=False. init_params call ignored.");
                return;
            }

            _exec_group.SetParams(_arg_params, _aux_params, allow_extra: allow_extra);
            ParamsInitialized = true;
            _params_dirty = false;
        }

        public override void InstallMonitor(Monitor mon)
        {
            if (!Binded)
                throw new Exception("Module not yet binded");
            _exec_group.InstallMonitor(mon);
        }

        public override void Update()
        {
            if (!Binded && !ParamsInitialized && !OptimizerInitialized)
            {
                throw new Exception("Module not binded or param initialized or optimizer initialized");
            }

            _params_dirty = true;
            if(_update_on_kvstore.HasValue && _update_on_kvstore.Value)
            {
                Model.UpdateParamsOnKVStore(_exec_group.ParamArrays, _exec_group.GradArrays, _kvstore, _exec_group.ParamNames);
            }
            else
            {
                Model.UpdateParams(_exec_group.ParamArrays, _exec_group.GradArrays, _updater, _context.Length, _kvstore, _exec_group.ParamNames);
            }
        }

        public override void UpdateMetric(EvalMetric eval_metric, NDArray[] labels, bool pre_sliced = false)
        {
            _exec_group.UpdateMetric(eval_metric, labels, pre_sliced);
        }

        public void Reshape(DataDesc[] data_shapes, DataDesc[] label_shapes = null)
        {
            if (!Binded)
                throw new Exception("Module not yet binded");

            (_data_shapes, _label_shapes) = ParseDataDesc(DataNames, LabelNames, data_shapes, label_shapes);
            _exec_group.Reshape(_data_shapes, _label_shapes);
        }

        public void BorrowOptimizer(Module shared_module)
        {
            if (!shared_module.OptimizerInitialized)
                throw new Exception("Shared moidule optimizer not initialized");

            _optimizer = shared_module._optimizer;
            _kvstore = shared_module._kvstore;
            _update_on_kvstore = shared_module._update_on_kvstore;
            _updater = shared_module._updater;
            OptimizerInitialized = true;
        }

        private void SyncParamsFromDevices()
        {
            _exec_group.GetParams(ref _arg_params, ref _aux_params);
            if(_kvstore != null && _update_on_kvstore.HasValue && _update_on_kvstore.Value)
            {
                foreach (var p in _arg_params)
                {
                    if (p.Value.SType == StorageStype.RowSparse)
                    {
                        var row_ids = nd.Arange(0, p.Value.Shape[0], dtype: DType.Int64);
                        _kvstore.RowSparsePull(p.Key, new NDArray[] { p.Value }, row_ids: new NDArray[] { row_ids });
                    }
                }
            }

            _params_dirty = false;
        }

        public void SaveOptimizerStates(string fname)
        {
            if (!OptimizerInitialized)
                throw new Exception("Optimizer not initialized");

            if (_update_on_kvstore.HasValue && _update_on_kvstore.Value)
                _kvstore.SaveOptimizerStates(fname);
            else
                File.WriteAllText(fname, _updater.GetStates());
        }

        public void LoadOptimizerStates(string fname)
        {
            if (!OptimizerInitialized)
                throw new Exception("Optimizer not initialized");

            if (_update_on_kvstore.HasValue && _update_on_kvstore.Value)
                _kvstore.LoadOptimizerStates(fname);
            else
                _updater.SetStates(File.ReadAllText(fname));
        }

        public override void Prepare(DataBatch data_batch, Func<DataBatch, NDArrayDict> sparse_row_id_fn = null)
        {
            if (!Binded)
                throw new Exception("Module not yet binded");

            if(sparse_row_id_fn!=null)
            {
                if (_kvstore != null && !_update_on_kvstore.Value)
                    Logger.Warning("Parameters are not updated in the KVStore. " +
                                          "No need to call sparse_row_id_fn.");
                else
                {
                    var row_ids = sparse_row_id_fn(data_batch);
                    foreach (var p in row_ids)
                    {
                        var param_name = p.Key;
                        var row_id = p.Value;
                        var param_idx = _exec_group.ParamNames.ToList().IndexOf(param_name);
                        var param_val = _exec_group.ParamArrays[param_idx];
                        if (param_val[0].SType != StorageStype.RowSparse)
                            Logger.Warning($"{param_name}.stype is not 'row_sparse'. No need to " +
                                                  "perform row_sparse_pull.");
                        else
                            _kvstore.RowSparsePull(param_name, param_val, row_ids: new NDArray[] { row_id }, priority: param_idx);
                    }
                }
            }
        }
    }
}

