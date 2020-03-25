/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using MxNet.Callbacks;
using MxNet.IO;
using MxNet.KVstore;
using MxNet.Metrics;
using MxNet.Optimizers;

namespace MxNet
{
    public class Model
    {
        internal static (KVStore, bool) CreateSparseKVStore(KVStore kvstore)
        {
            var update_on_kvstore = true;
            return (kvstore, update_on_kvstore);
        }

        internal static (KVStore, bool) CreateSparseKVStore(string kvstore)
        {
            return CreateSparseKVStore(KVStoreBase.Create(kvstore));
        }

        internal static (KVStore, bool) CreateKVStore(KVStore kvstore, int num_device, NDArrayDict arg_params)
        {
            var update_on_kvstore = true;
            if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("MXNET_UPDATE_ON_KVSTORE")))
                update_on_kvstore = Convert.ToBoolean(Environment.GetEnvironmentVariable("MXNET_UPDATE_ON_KVSTORE"));

            if (kvstore == null)
                update_on_kvstore = false;

            return (kvstore, update_on_kvstore);
        }

        internal static (KVStore, bool) CreateKVStore(string kvstore, int num_device, NDArrayDict arg_params)
        {
            KVStore kV = null;
            var update_on_kvstore = true;
            if (num_device == 1 && !kvstore.Contains("dist"))
            {
                kV = null;
            }
            else
            {
                kV = KVStoreBase.Create(kvstore);
                if (kvstore == "local")
                {
                    var max_size = arg_params.Values.Select(x => x.Shape.Size).ToList().Max();
                    if (max_size > 1024 * 1024 * 16)
                        update_on_kvstore = false;
                }
            }

            return (kV, update_on_kvstore);
        }

        internal static void InitializeKVStore(KVStore kvstore, List<NDArrayList> param_arrays, NDArrayDict arg_params,
            string[] param_names, bool update_on_kvstore)
        {
            for (int i = 0; i < param_arrays.Count; i++)
            {
                if (param_arrays[i].Length == 0)
                    continue;

                if (param_arrays[i][0] == null)
                    continue;

                var name = param_names[i];
                var param_on_devs = param_arrays[i];
                kvstore.Init(name, arg_params[name]);

                if (update_on_kvstore)
                    kvstore.Pull(name, param_on_devs, -i);
            }
        }

        internal static void UpdateParamsOnKVStoreNCCL(List<NDArrayList> param_arrays, List<NDArrayList> grad_arrays,
            KVStore kvstore, string[] param_names)
        {
            List<int> valid_indices = new List<int>();
            int i = 0;
            grad_arrays.ForEach((x) => {
                valid_indices.Add(i);
                i++;
            });

            var valid_grad_arrays = valid_indices.Select(x => (grad_arrays[x])).ToArray();
            var valid_param_arrays = valid_indices.Select(x => (param_arrays[x])).ToArray();
            var valid_param_names = valid_indices.Select(x => (param_names[x])).ToArray();

            int size = valid_grad_arrays.Length;
            int start = 0;
            int batch = 16;
            if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("MXNET_UPDATE_AGGREGATION_SIZE")))
                batch = Convert.ToInt32(Environment.GetEnvironmentVariable("MXNET_UPDATE_AGGREGATION_SIZE"));

            while(start < size)
            {
                int end = start + batch < size ? start + batch : size;
                var name_batch_list = valid_param_names.Skip(start).Take(end - start).ToArray();
                var grad_batch_list = valid_grad_arrays.Skip(start).Take(end - start).ToArray();
                var param_batch_list = valid_grad_arrays.Skip(start).Take(end - start).ToArray();

                for (int kvi = 0; kvi < name_batch_list.Length; kvi++)
                {
                    kvstore.Push(valid_param_names[kvi], valid_grad_arrays[kvi], -start);
                    kvstore.Pull(valid_param_names[kvi], param_batch_list[kvi], -start);
                }

                start = end;
            }
        }

        internal static void UpdateParamsOnKVStore(List<NDArrayList> param_arrays, List<NDArrayList> grad_arrays,
            KVStore kvstore, string[] param_names)
        {
            for (int index = 0; index < param_arrays.Count; index++)
            {
                var arg_list = param_arrays[index]; 
                var grad_list = grad_arrays[index];

                if (grad_list.Length == 0)
                    continue;

                if (grad_list[0] == null)
                    continue;

                string name = param_names[index];
                kvstore.Push(name, grad_list, -index);
                kvstore.Pull(name, arg_list, -index);
            }
        }

        internal static void UpdateParams(List<NDArrayList> param_arrays, List<NDArrayList> grad_arrays,
            Updater updater, int num_device, KVStore kvstore, string[] param_names)
        {
            Dictionary<int, List<(int, NDArray, NDArray)>> updates = new Dictionary<int, List<(int, NDArray, NDArray)>>();
            for (int i = 0; i < num_device; i++)
            {
                updates.Add(i, new List<(int, NDArray, NDArray)>());
            }

            for (int i = 0; i < param_arrays.Count; i++)
            {
                var arg_list = param_arrays[i];
                var grad_list = grad_arrays[i];

                if (grad_list.Length == 0)
                    continue;

                if (grad_list[0] == null)
                    continue;

                int index = i;
                if (kvstore != null)
                {
                    string name = param_names[index];
                    kvstore.Push(name, grad_list, -index);
                    kvstore.Pull(name, arg_list, -index);
                }

                for(int j = 0; j< arg_list.Length;j++)
                {
                    var w = arg_list[j];
                    var g = grad_list[j];
                    updates[i].Add((index * num_device + j, w, g));
                }

                foreach (var dev_updates in updates.Values)
                {
                    foreach (var item in dev_updates)
                    {
                        var (idx, w, g) = item;
                        updater.Call(idx, w, g);
                    }
                }
            }
        }

        internal static void MultipleCallbacks(object[] callbacks, params object[] args)
        {
            foreach (var callback in callbacks)
            {
                var invoke = callback.GetType().GetMethod("Invoke");
                invoke.Invoke(callback, args);
            }
        }

        internal static void MultipleCallbacks(object callback, params object[] args)
        {
            var invoke = callback.GetType().GetMethod("Invoke");
            invoke.Invoke(callback, args.ToArray());
        }

        internal static void TrainMultiDevice(Symbol symbol, Context[] ctx, string[] arg_names, string[] param_names, string[] aux_names, NDArrayDict arg_params, NDArrayDict           aux_params, int begin_epoch, int end_epoch, int? epoch_size, Optimizer optimizer, KVStore kvstore, bool update_on_kvstore, DataIter train_data, DataIter eval_data = null, EvalMetric eval_metric = null, IEpochEndCallback epoch_end_callback = null, IBatchEndCallback batch_end_callback = null, int[] work_load_list = null, Monitor monitor = null, IEvalEndCallback eval_end_callback = null, IEvalBatchEndCallback eval_batch_end_callback = null, Func<int, Symbol> sym_gen = null)
        {
            var executor_manager = new DataParallelExecutorManager(symbol: symbol,
                                                   ctx: ctx,
                                                   train_data: train_data,
                                                   arg_names: arg_names,
                                                   param_names: param_names,
                                                   aux_names: aux_names,
                                                   work_load_list: work_load_list,
                                                   sym_gen: sym_gen);

            if (monitor != null)
                executor_manager.InstallMonitor(monitor);

            executor_manager.SetParams(arg_params, aux_params);
            Updater updater = null;
            if (!update_on_kvstore)
                updater = Optimizer.GetUpdater(optimizer);
            else
                kvstore.SetOptimizer(optimizer);

            if(kvstore != null)
            {
                InitializeKVStore(kvstore: kvstore,
                            param_arrays: new List<NDArrayList>() { executor_manager.ParamArrays },
                            arg_params: arg_params,
                            param_names: executor_manager.param_names,
                            update_on_kvstore: update_on_kvstore);
            }

            train_data.Reset();
            for (int epoch = begin_epoch; epoch < end_epoch; epoch++)
            {
                var tic = DateTime.Now;
                eval_metric.Reset();
                int nbatch = 0;
                while(true)
                {
                    bool do_reset = true;
                    while(!train_data.End())
                    {
                        var data_batch = train_data.Next();
                        executor_manager.LoadDataBatch(data_batch);
                        if (monitor != null)
                            monitor.Tic();

                        executor_manager.Forward(true);
                        executor_manager.Backward();
                        if(update_on_kvstore)
                        {
                            if(kvstore.Type.Contains("nccl"))
                                UpdateParamsOnKVStoreNCCL(new List<NDArrayList>() { executor_manager.ParamArrays }, new List<NDArrayList>() { executor_manager.GradArrays }, kvstore, executor_manager.param_names);
                            else
                                UpdateParamsOnKVStore(new List<NDArrayList>() { executor_manager.ParamArrays }, new List<NDArrayList>() { executor_manager.GradArrays }, kvstore, executor_manager.param_names);
                        }
                        else
                            UpdateParams(new List<NDArrayList>() { executor_manager.ParamArrays }, new List<NDArrayList>() { executor_manager.GradArrays }, updater, ctx.Length, kvstore, executor_manager.param_names);

                        if (monitor != null)
                            monitor.TocPrint();

                        executor_manager.UpdateMetric(eval_metric, data_batch.Label);
                        nbatch++;
                        if (batch_end_callback != null)
                            MultipleCallbacks(batch_end_callback, epoch, nbatch, eval_metric);

                        if (epoch_size.HasValue && nbatch >= epoch_size.Value)
                        {
                            do_reset = false;
                            break;
                        }
                    }

                    if (do_reset)
                    {
                        Logger.Info($"Epoch[{epoch}] Resetting Data Iterator");
                        train_data.Reset();
                    }

                    if (epoch_size.HasValue)
                        if (nbatch >= epoch_size.Value)
                            break;
                    else
                        break;
                }

                var toc = DateTime.Now;
                Logger.Info($"Epoch[{epoch}] Time cost={(toc - tic).TotalSeconds}");

                if (epoch_end_callback != null || epoch + 1 == end_epoch)
                    executor_manager.CopyTo(arg_params, aux_params);

                MultipleCallbacks(epoch_end_callback, epoch, symbol, arg_params, aux_params);

                if (eval_data != null)
                {
                    eval_metric.Reset();
                    eval_data.Reset();
                    int total_num_batch = 0;
                    int i = 0;
                    while(!eval_data.End())
                    {
                        var eval_batch = eval_data.Next();
                        executor_manager.LoadDataBatch(eval_batch);
                        executor_manager.Forward();
                        executor_manager.UpdateMetric(eval_metric, eval_batch.Label);
                        if(eval_batch_end_callback!=null)
                        {
                            MultipleCallbacks(eval_batch_end_callback, epoch, i, eval_metric);
                        }

                        total_num_batch++;
                    }

                    if(eval_end_callback != null)
                    {
                        MultipleCallbacks(eval_end_callback, epoch, eval_metric);
                    }
                }
            }
        }

        public static void SaveCheckpoint(string prefix, int epoch, Symbol symbol, NDArrayDict arg_params,
            NDArrayDict aux_params, bool remove_amp_cast = true)
        {
            if (symbol != null)
                symbol.Save($"{prefix}-symbol.json", remove_amp_cast);

            NDArrayDict save_dict = new NDArrayDict();
            foreach (var item in arg_params)
            {
                save_dict.Add($"arg:{item.Key}", item.Value);
            }

            foreach (var item in aux_params)
            {
                save_dict.Add($"aux:{item.Key}", item.Value);
            }

            string param_name = $"{prefix}-{epoch.ToString("D4")}.params";
            NDArray.Save(param_name, save_dict);
            Logger.Info($"Saved checkpoint to \"{param_name}\"");
        }

        public static (Symbol, NDArrayDict, NDArrayDict) LoadCheckpoint(string prefix, int epoch)
        {
            Symbol sym = Symbol.Load($"{prefix}-symbol.json");
            string param_name = $"{prefix}-{epoch.ToString("D4")}.params";
            var save_dict = NDArray.Load(param_name);
            NDArrayDict arg_params = new NDArrayDict();
            NDArrayDict aux_params = new NDArrayDict();

            if (save_dict == null)
                Logger.Warning($"Params file '{param_name}' is empty");
            else
            {
                foreach (var item in save_dict)
                {
                    if (item.Key.StartsWith("arg:"))
                        arg_params.Add(item.Key.Replace("arg:", ""), item.Value);
                    else if (item.Key.StartsWith("aux:"))
                        aux_params.Add(item.Key.Replace("aux:", ""), item.Value);
                    else
                        Logger.Warning($"Params file '{param_name}' contains unknown param '{item.Key}'");
                }
            }

            return (sym, arg_params, aux_params);
        }
    }
}