using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using MxNet.Interop;
using mx_float = System.Single;
using DataIterHandle = System.IntPtr;

// ReSharper disable once CheckNamespace
namespace MxNet.IO
{

    public sealed class MXDataIter : DataIter
    {
        private DataIterHandle handle;
        private bool _debug_skip_load = false;
        private bool _debug_at_begin = true;
        private DataBatch first_batch = null;
        private NDArray data;
        private NDArray label;
        private int? next_res;
        private MXDataIterMap DataIterMap = new MXDataIterMap();
        private Operator op;
        public MXDataIter(string mxdataiterType, string data_name = "data", string label_name = "softmax_label")
        {
            this.handle = DataIterMap.GetMXDataIterCreator(mxdataiterType);
            _debug_skip_load = false;
            first_batch = Next();
            data = first_batch.Data[0];
            label = first_batch.Label[0];

            ProvideData = new DataDesc[] { new DataDesc(data_name, data.Shape, data.DataType) };
            ProvideLabel = new DataDesc[] { new DataDesc(label_name, label.Shape, label.DataType) };
            BatchSize = data.Shape[0];
            op = new Operator(handle);
        }

        public MXDataIter(DataIterHandle handle, string data_name= "data", string label_name= "softmax_label")
        {
            this.handle = handle;
            _debug_skip_load = false;
            first_batch = Next();
            data = first_batch.Data[0];
            label = first_batch.Label[0];

            ProvideData = new DataDesc[] { new DataDesc(data_name, data.Shape, data.DataType) };
            ProvideLabel = new DataDesc[] { new DataDesc(label_name, label.Shape, label.DataType) };
            BatchSize = data.Shape[0];
            op = new Operator(handle);
        }

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            if (this.handle != IntPtr.Zero)
                NativeMethods.MXDataIterFree(handle);
        }

        public void DebugSkipLoad()
        {
            _debug_skip_load = true;
            Console.WriteLine("Set debug_skip_load to be true, will simply return first batch");
        }

        public override NDArray[] GetData()
        {
            NativeMethods.MXDataIterGetData(handle, out var hdl);
            return new NDArray[] { new NDArray(hdl) };
        }

        public override int[] GetIndex()
        {
            var r = NativeMethods.MXDataIterGetIndex(handle, out var outIndex, out var outSize);
            Logging.CHECK_EQ(r, 0);

            var outIndexArray = InteropHelper.ToUInt64Array(outIndex, (uint)outSize);
            var ret = new int[outSize];
            for (var i = 0ul; i < outSize; ++i)
                ret[i] = (int)outIndexArray[i];

            return ret;
        }

        public override NDArray[] GetLabel()
        {
            NativeMethods.MXDataIterGetLabel(handle, out var hdl);
            return new NDArray[] { new NDArray(hdl) };
        }

        public override int GetPad()
        {
            var r = NativeMethods.MXDataIterGetPadNum(handle, out var @out);
            return @out;
        }

        public override bool IterNext()
        {
            if (first_batch != null)
                return true;

            next_res = 0;
            NativeMethods.MXDataIterNext(handle, out next_res);
            return Convert.ToBoolean(next_res.Value);
        }

        public override void Reset()
        {
            _debug_at_begin = true;
            first_batch = null;
            NativeMethods.MXDataIterBeforeFirst(handle);
        }

        public override DataBatch Next()
        {
            if(_debug_skip_load && !_debug_at_begin)
            {
                return new DataBatch(GetData(), GetLabel(), GetPad(), GetIndex());
            }

            if(first_batch != null)
            {
                var batch = first_batch;
                first_batch = null;
                return batch;
            }

            _debug_at_begin = false;
            next_res = 0;
            NativeMethods.MXDataIterNext(handle, out next_res);
            if(next_res.HasValue)
            {
                return new DataBatch(GetData(), GetLabel(), GetPad(), GetIndex());
            }
            else
            {
                throw new MXNetException("Stop Iteration");
            }
        }

        public void SetParam(string key, string value)
        {
            op.SetParam(key, value);
        }

        public void SetParam(string key, NDArray value)
        {
            op.SetParam(key, value);
        }

        public void SetParam(string key, Symbol value)
        {
            op.SetParam(key, value);
        }

        public void SetParam(string key, object value)
        {
            op.SetParam(key, value);
        }
    }

}
