using MxNetLib.KVstore;
using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib
{
    

    public class Model
    {
        private static (KVStore, bool) CreateSparseKVStore(KVStore kvstore) => throw new NotImplementedException();

        private static (KVStore, bool) CreateKVStore(KVStore kvstore, int num_device, Dictionary<string, NDArray> arg_params) => throw new NotImplementedException();

        private static void InitializeKVStore(KVStore kvstore, NDArray[] param_arrays, Dictionary<string, NDArray>  arg_params, string[] param_names, bool update_on_kvstore) => throw new NotImplementedException();

        private static void UpdateParamsOnKVStoreNCCL(NDArray[]  param_arrays, NDArray[]  grad_arrays, KVStore kvstore, string[] param_names) => throw new NotImplementedException();

        private static void UpdateParamsOnKVStore(NDArray[] param_arrays, NDArray[] grad_arrays, KVStore kvstore, string[] param_names) => throw new NotImplementedException();

        private static void UpdateParams(NDArray[] param_arrays, NDArray[] grad_arrays, Func<int, NDArray, NDArray> updater, 
                                                int num_device, KVStore kvstore, string[] param_names) => throw new NotImplementedException();

        
    }
}
