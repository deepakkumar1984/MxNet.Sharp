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
using MxNet.Interop;
using MxNet.Optimizers;
using KVStoreHandle = System.IntPtr;

namespace MxNet.KVstore
{
    public abstract class KVStoreBase
    {
        public const string OPTIMIZER = "optimizer";
        private static readonly Dictionary<string, KVStoreBase> kv_registry = new Dictionary<string, KVStoreBase>();
        public abstract int Rank { get; }

        public abstract string Type { get; }

        public abstract int NumWorkers { get; }

        public abstract void Broadcast(string key, NDArray value, NDArrayList @out, int priority = 0);

        public abstract void PushPull(string key, NDArray value, NDArrayList @out, int priority = 0);

        public abstract void SetOptimizer(Optimizer optimizer);

        public abstract bool IsCapable(string capability);

        public abstract void SaveOptimizerStates(string fname, bool dump_optimizer = false);

        public abstract void LoadOptimizerStates(string fname);

        public static KVStoreBase Register(object klass)
        {
            if (klass.GetType().BaseType.Name != typeof(KVStoreBase).Name)
                throw new Exception("klass is not inheritedd from KVStoreBase");
            var name = klass.GetType().Name;
            if (kv_registry.ContainsKey(name))
                Logger.Warning(string.Format("WARNING: New kvstore {0} is overriding existing one", name));

            kv_registry[name] = (KVStoreBase) klass;
            return kv_registry[name];
        }

        public static KVStore Create(string name = "local")
        {
            NativeMethods.MXKVStoreCreate(name, out var handle);
            var kv = new KVStore(handle);
            Profiler.profiler_kvstore_handle = handle;
            return kv;
        }
    }
}