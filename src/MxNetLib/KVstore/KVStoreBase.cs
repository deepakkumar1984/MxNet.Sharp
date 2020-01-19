using System;
using System.Collections.Generic;
using System.Text;
using KVStoreHandle = System.IntPtr;

namespace MxNetLib.KVstore
{
    public abstract class KVStoreBase
    {
        public abstract int Rank { get; }

        public abstract string Type { get; }

        public abstract int NumWorkers { get; }

        private Dictionary<string, KVStoreBase> kv_registry = new Dictionary<string, KVStoreBase>();

        public abstract void Broadcast(string key, NDArray value, NDArray[] @out, int priority = 0);

        public abstract void PushPull(string key, NDArray value, NDArray[] @out, int priority = 0);

        public abstract void SetOptimizer(KVStoreBase optimizer);

        public abstract bool IsCapable(string capability);

        public abstract void SaveOptimizerStates(string fname, bool dump_optimizer= false);

        public abstract void LoadOptimizerStates(string fname);

        public static void Register(KVStoreBase klass)
        {
            throw new NotImplementedException();
        }
    }
}
