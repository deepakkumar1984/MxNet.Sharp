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
        public override int Rank
        {
            get
            {
                NativeMethods.MXKVStoreGetRank(handle, out var ret);
                return ret;
            }
        }

        public override string Type
        {
            get
            {
                string name = "";
                NativeMethods.MXKVStoreGetType(handle, name);
                return name;
            }
        }

        public override int NumWorkers
        {
            get
            {
                NativeMethods.MXKVStoreGetGroupSize(handle, out var ret);
                return ret;
            }
        }

        internal KVStoreHandle handle;
        internal Updater _updater;
        internal IntPtr updater_func;
        internal IntPtr str_updater_func;
        internal delegate void UpdaterHandle(int key, IntPtr lhs_handle, IntPtr rhs_handle, IntPtr _);
        internal delegate void UpdaterHandleStr(string key, IntPtr lhs_handle, IntPtr rhs_handle, IntPtr _);


        public KVStore(KVStoreHandle handle)
        {
            this.handle = handle;
            _updater = null;
            updater_func = IntPtr.Zero;
            str_updater_func = IntPtr.Zero;
        }

        public override void Broadcast(string key, NDArray value, NDArrayList @out, int priority = 0)
        {
            Init(key, value);
            Pull(key, @out, priority);
        }

        public void Init(string key, NDArray value)
        {
            NativeMethods.MXKVStoreInitEx(handle, 1, new string[] { key }, new IntPtr[] { value.NativePtr });
        }

        public void Push(string key, NDArrayList value, int priority = 0)
        {
            NativeMethods.MXKVStorePushEx(handle, 1, new string[] { key }, MxUtil.GetNDArrayHandles(value), priority);
        }

        public void Pull(string key, NDArrayList @out, int priority = 0, bool ignore_sparse = true)
        {
            NativeMethods.MXKVStorePullWithSparseEx(handle, 1, new string[] { key }, MxUtil.GetNDArrayHandles(@out), priority, ignore_sparse);
        }

        public override void PushPull(string key, NDArray value, NDArrayList @out, int priority = 0)
        {
            NativeMethods.MXKVStorePushPullEx(handle, 1, new string[] { key }, @out.Length, new string[] { key }, new IntPtr[] { value.NativePtr }, MxUtil.GetNDArrayHandles(@out), priority);
        }

        public void RowSparsePull(string key, NDArrayList @out, int priority = 0, NDArrayList row_ids = null)
        {
            if (@out == null)
                throw new ArgumentNullException("@out");

            if (row_ids == null)
                throw new ArgumentNullException("row_ids");

            NDArrayList first_out = new NDArrayList();
            if (row_ids.Length == 1)
            {
                first_out.Add(@out[0]);
            }
            else
            {
                first_out = @out.ToList();
            }

            NativeMethods.MXKVStorePullRowSparseEx(handle, 1, new string[] { key }, MxUtil.GetNDArrayHandles(first_out.ToArray()), MxUtil.GetNDArrayHandles(row_ids), priority);
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

        private UpdaterHandle UpdaterWrapper(Updater updater)
        {
            UpdaterHandle func = (key, lhs_handle, rhs_handle, _) => 
            {
                updater.Call(key, new NDArray(lhs_handle), new NDArray(rhs_handle));
            };

            return func;
        }

        private UpdaterHandleStr UpdaterWrapperStr(Updater updater)
        {
            UpdaterHandleStr func = (key, lhs_handle, rhs_handle, _) =>
            {
                updater.Call(Convert.ToInt32(key), new NDArray(lhs_handle), new NDArray(rhs_handle));
            };

            return func;
        }

        public void SetUpdater(Updater updater)
        {
            _updater = updater;
            updater_func = UpdaterWrapper(updater).Method.MethodHandle.GetFunctionPointer();
            str_updater_func = UpdaterWrapperStr(updater).Method.MethodHandle.GetFunctionPointer();
            NativeMethods.MXKVStoreSetUpdaterEx(handle, updater_func, str_updater_func, IntPtr.Zero);
        }
    }
}
