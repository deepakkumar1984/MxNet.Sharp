using MxNet.Callbacks;
using MxNet.IO;
using MxNet.KVstore;
using MxNet.Metrics;
using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet
{
    public class Model
    {
        internal static (KVStore, bool) CreateSparseKVStore(KVStore kvstore)
        {
            bool update_on_kvstore = true;
            return (kvstore, update_on_kvstore);
        }

        internal static (KVStore, bool) CreateSparseKVStore(string kvstore)
        {
            return CreateSparseKVStore(KVStore.Create(kvstore));
        }

        internal static (KVStore, bool) CreateKVStore(KVStore kvstore, int num_device, NDArrayDict arg_params)
        {
            bool update_on_kvstore = true;
            if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("MXNET_UPDATE_ON_KVSTORE")))
                update_on_kvstore = Convert.ToBoolean(Environment.GetEnvironmentVariable("MXNET_UPDATE_ON_KVSTORE"));

            if (kvstore == null)
                update_on_kvstore = false;

            return (kvstore, update_on_kvstore);
        }

        internal static (KVStore, bool) CreateKVStore(string kvstore, int num_device, NDArrayDict arg_params)
        {
            KVStore kV = null;
            bool update_on_kvstore = true;
            if (num_device == 1 && !kvstore.Contains("dist"))
                kV = null;
            else
            {
                kV = KVStore.Create(kvstore);
                if(kvstore == "local")
                {
                    int max_size = arg_params.Values.Select(x => (x.Shape.Size)).ToList().Max();
                    if (max_size > 1024 * 1024 * 16)
                        update_on_kvstore = false;
                }
            }

            return (kV, update_on_kvstore);
        }

        internal static void InitializeKVStore(KVStore kvstore, NDArray[] param_arrays, NDArrayDict  arg_params, string[] param_names, bool update_on_kvstore) => throw new NotImplementedException();

        internal static void UpdateParamsOnKVStoreNCCL(NDArray[]  param_arrays, NDArray[]  grad_arrays, KVStore kvstore, string[] param_names) => throw new NotImplementedException();

        internal static void UpdateParamsOnKVStore(NDArray[] param_arrays, NDArray[] grad_arrays, KVStore kvstore, string[] param_names) => throw new NotImplementedException();

        internal static void UpdateParams(NDArray[] param_arrays, NDArray[] grad_arrays, Func<int, NDArray, NDArray> updater, 
                                                int num_device, KVStore kvstore, string[] param_names) => throw new NotImplementedException();

        internal static void MultipleCallbacks(params object[] callbacks)
        {
            foreach (var callback in callbacks)
            {
                
            }
        }

        internal static void TrainMultiDevice(Symbol symbol, Context ctx, string[] arg_names, string[] param_names, string[] aux_names,
                                            NDArrayDict arg_params, NDArrayDict  aux_params,
                                            int begin_epoch, int end_epoch, int epoch_size, Optimizer optimizer, KVStore kvstore, 
                                            bool update_on_kvstore, DataIter train_data, DataIter eval_data= null, EvalMetric eval_metric= null,
                                            IEpochEndCallback epoch_end_callback= null, IBatchEndCallback batch_end_callback= null,
                                            Logger logger= null, int[] work_load_list= null, Monitor monitor= null,
                                            IEvalEndCallback eval_end_callback= null, IEvalBatchEndCallback eval_batch_end_callback = null, 
                                            Func<string, Symbol>  sym_gen = null) => throw new NotImplementedException();

        public static void SaveCheckpoint(string prefix, int epoch, Symbol symbol, NDArrayDict arg_params,
                                        NDArrayDict aux_params, bool remove_amp_cast = true) => throw new NotImplementedException();

        public static (NDArrayDict, NDArrayDict) LoadParams(string prefix, int epoch) => throw new NotImplementedException();

        public static (Symbol, NDArrayDict, NDArrayDict) LoadCheckpoint(string prefix, int epoch) => throw new NotImplementedException();
    }
}
