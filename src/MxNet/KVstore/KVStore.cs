using System;
using System.Collections.Generic;
using System.Text;
using KVStoreHandle = System.IntPtr;

namespace MxNet.KVstore
{
    public class KVStore : KVStoreBase
    {
        public override int Rank => throw new NotImplementedException();

        public override string Type => throw new NotImplementedException();

        public override int NumWorkers => throw new NotImplementedException();

        public KVStore(KVStoreHandle handle)
        {

        }

        public override void Broadcast(string key, NDArray value, NDArray[] @out, int priority = 0)
        {
            throw new NotImplementedException();
        }

        public override bool IsCapable(string capability)
        {
            throw new NotImplementedException();
        }

        public override void LoadOptimizerStates(string fname)
        {
            throw new NotImplementedException();
        }

        public override void PushPull(string key, NDArray value, NDArray[] @out, int priority = 0)
        {
            throw new NotImplementedException();
        }

        public override void SaveOptimizerStates(string fname, bool dump_optimizer = false)
        {
            throw new NotImplementedException();
        }

        public override void SetOptimizer(KVStoreBase optimizer)
        {
            throw new NotImplementedException();
        }
    }
}
