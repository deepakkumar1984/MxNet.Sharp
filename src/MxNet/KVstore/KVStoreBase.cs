using MxNet.Interop;
using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;
using KVStoreHandle = System.IntPtr;

namespace MxNet.KVstore
{
    public abstract class KVStoreBase
    {
        private static Dictionary<string, KVStoreBase> kv_registry = new Dictionary<string, KVStoreBase>();
        public const string OPTIMIZER = "optimizer";
        public abstract int Rank { get; }

        public abstract string Type { get; }

        public abstract int NumWorkers { get; }

        public abstract void Broadcast(string key, NDArray value, NDArrayList @out, int priority = 0);

        public abstract void PushPull(string key, NDArray value, NDArrayList @out, int priority = 0);

        public abstract void SetOptimizer(Optimizer optimizer);

        public abstract bool IsCapable(string capability);

        public abstract void SaveOptimizerStates(string fname, bool dump_optimizer= false);

        public abstract void LoadOptimizerStates(string fname);

        public static KVStoreBase Register(object klass)
        {
            if (klass.GetType().BaseType.Name != typeof(KVStoreBase).Name)
                throw new Exception("klass is not inheritedd from KVStoreBase");
            string name = klass.GetType().Name;
            if(kv_registry.ContainsKey(name))
            {
                Logger.Warning(string.Format("WARNING: New kvstore {0} is overriding existing one", name));
            }

            kv_registry[name] = (KVStoreBase)klass;
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
