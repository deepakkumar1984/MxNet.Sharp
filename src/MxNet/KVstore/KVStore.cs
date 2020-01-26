using MxNet.Interop;
using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;
using KVStoreHandle = System.IntPtr;
using System.Linq;

namespace MxNet.KVstore
{
    public enum KVStoreCommandType
    {
        kController = 0,
        kSetMultiPrecision,
        kStopServer,
        kSyncMode,
        kSetGradientCompression,
        kSetProfilerParams
    }

    public class KVStore : KVStoreBase, IDisposable
    {
        public override int Rank => throw new NotImplementedException();

        public override string Type => throw new NotImplementedException();

        public override int NumWorkers => throw new NotImplementedException();

        internal KVStoreHandle handle;
        internal Updater updater;
        internal IntPtr updater_func;
        internal IntPtr str_updater_func;

        public KVStore(KVStoreHandle handle)
        {
            this.handle = handle;
            updater = null;
            updater_func = IntPtr.Zero;
            str_updater_func = IntPtr.Zero;
        }

        public override void Broadcast(string key, NDArray value, NDArray[] @out, int priority = 0)
        {
            Init(key, value);
            Pull(key, @out, priority);
        }

        public void Init(string key, NDArray value)
        {
            NativeMethods.MXKVStoreInitEx(handle, 1, new string[] { key }, new IntPtr[] { value.NativePtr });
        }

        public void Push(string key, NDArray value, int priority = 0)
        {
            NativeMethods.MXKVStorePushEx(handle, 1, new string[] { key }, new IntPtr[] { value.NativePtr }, priority);
        }

        public void Pull(string key, NDArray[] @out, int priority = 0, bool ignore_sparse = true)
        {
            NativeMethods.MXKVStorePullWithSparseEx(handle, 1, new string[] { key }, Util.GetNDArrayHandles(@out), priority, ignore_sparse);
        }

        public override void PushPull(string key, NDArray value, NDArray[] @out, int priority = 0)
        {
            NativeMethods.MXKVStorePushPullEx(handle, 1, new string[] { key }, @out.Length, new string[] { key }, new IntPtr[] { value.NativePtr }, Util.GetNDArrayHandles(@out), priority);
        }

        public void RowSparsePull(string key, NDArray[] @out, int priority = 0, NDArray[] row_ids = null)
        {
            if (@out == null)
                throw new ArgumentNullException("@out");

            if (row_ids == null)
                throw new ArgumentNullException("row_ids");

            bool single_rowid = false;
            List<NDArray> first_out = new List<NDArray>();
            if (row_ids.Length == 1)
            {
                single_rowid = true;
                first_out.Add(@out[0]);
            }
            else
            {
                first_out = @out.ToList();
            }

            NativeMethods.MXKVStorePullRowSparseEx(handle, 1, new string[] { key }, Util.GetNDArrayHandles(first_out.ToArray()), Util.GetNDArrayHandles(row_ids), priority);
        }


        public override bool IsCapable(string capability)
        {
            if (OPTIMIZER == capability.ToLower())
                return true;
            else
                throw new MXNetException("Unknown capability: " + capability);
        }

        public void SetGradientCompression(Dictionary<string, object> compression_params)
        {
            string[] ckeys = compression_params.Keys.ToArray();
            string[] cvals = compression_params.Values.Select(x => (x.ToString())).ToArray();

            NativeMethods.MXKVStoreSetGradientCompression(handle, compression_params.Count, ckeys, cvals);
        }

        public override void LoadOptimizerStates(string fname)
        {
            throw new NotImplementedException();
        }

        public override void SaveOptimizerStates(string fname, bool dump_optimizer = false)
        {
            throw new NotImplementedException();
        }

        public override void SetOptimizer(Optimizer optimizer)
        {
            NativeMethods.MXKVStoreIsWorkerNode(out var is_worker);
            if(Type.Contains("dist") && is_worker > 0)
            {
                string optim_str = Newtonsoft.Json.JsonConvert.SerializeObject(optimizer);
                int cmd = (int)KVStoreCommandType.kController;
                NativeMethods.MXKVStoreSendCommmandToServers(handle, cmd, optim_str);
                if(optimizer.MultiPrecision)
                {
                    NativeMethods.MXKVStoreSendCommmandToServers(handle, (int)KVStoreCommandType.kSetMultiPrecision, "");
                }
            }
            else
            {
                SetUpdater(Optimizer.GetUpdater(optimizer));
            }
        }

        public void Dispose()
        {
            NativeMethods.MXKVStoreFree(handle);
        }

        private void SetUpdater(Updater updater)
        {
            throw new NotImplementedException();
        }
    }
}
