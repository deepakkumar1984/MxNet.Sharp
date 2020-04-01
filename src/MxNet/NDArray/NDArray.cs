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
using System.Runtime.InteropServices;
using MxNet.Interop;
using NumpyDotNet;
using NDArrayHandle = System.IntPtr;
using mx_uint = System.UInt32;
using mx_float = System.Single;
using size_t = System.UInt64;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public partial class NDArray : DisposableMXNetObject
    {
        #region Fields

        internal NDBlob _Blob;

        public Context Context
        {
            get
            {
                return GetContext();
            }
        }

        public Shape Shape => new Shape(GetShape());

        public DType DataType => DType.GetType(GetDType());

        public StorageStype SType => (StorageStype) StorageType();

        #endregion

        #region Constructors

        public NDArray()
        {
            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreateNone(out var @out), NativeMethods.OK);

            NativePtr = @out;
            _Blob = new NDBlob(@out);
        }

        internal NDArray(NDArrayHandle handle)
        {
            if (handle == NDArrayHandle.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(handle));

            NativePtr = handle;
            _Blob = new NDBlob(handle);
        }

        public NDArray(Shape shape, bool delayAlloc = true, Context ctx = null, DType dtype = null)
        {
            if (ctx == null)
                ctx = Context.CurrentContext;

            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            if (dtype == null)
                dtype = DType.Float32;

            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreateEx(shape.Data,
                shape.Dimension,
                ctx.GetDeviceType(),
                ctx.GetDeviceId(),
                delayAlloc.ToInt32(),
                dtype.Index,
                out var @out), NativeMethods.OK);
            NativePtr = @out;
            _Blob = new NDBlob(@out);
        }

        public NDArray(Array data, Shape shape, Context ctx = null, DType dtype = null)
        {
            if (ctx == null)
                ctx = Context.CurrentContext;

            if (dtype == null)
                dtype = DType.Float32;

            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            
            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreateEx(shape.Data,
                shape.Dimension,
                ctx.GetDeviceType(),
                ctx.GetDeviceId(),
                false.ToInt32(),
                dtype.Index,
                out var @out), NativeMethods.OK);
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyFromCPU(@out, datagch.AddrOfPinnedObject(), (uint) shape.Size);

            NativePtr = @out;
            _Blob = new NDBlob(@out);
        }

        public NDArray(Array data, Context ctx = null)
            : this(data, new Shape(data.GetLength(0)), ctx)
        {
        }

        #endregion

        #region Properties

        public virtual int Size
        {
            get
            {
                var ret = 1;
                var shape = GetShape();
                for (var i = 0; i < shape.Count; i++)
                    ret *= shape[i];

                return ret;
            }
        }

        public int Dimension => Shape.Dimension;

        public bool FreshGrad
        {
            get
            {
                NativeMethods.MXNDArrayGetGradState(NativePtr, out var freshGrad);
                return freshGrad;
            }
            set => NativeMethods.MXNDArraySetGradState(NativePtr, value);
        }

        public Array ArrayData => AsArray<float>();

        #endregion

        #region Methods

        public NDArray Copy()
        {
            var ret = new NDArray(Shape);
            using (var op = new Operator("_copyto"))
            {
                op.Set(this).Invoke(ret);
            }

            return ret;
        }

        public NDArray CopyTo(NDArray other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            using (var op = new Operator("_copyto"))
            {
                op.Set(this).Invoke(other);
            }

            return other;
        }

        public NDArray ChangeContext(Context ctx)
        {
            var result = new NDArray(Shape, true, ctx, DataType);
            CopyTo(result);
            return result;
        }

        public Context GetContext()
        {
            NativeMethods.MXNDArrayGetContext(NativePtr, out var out_dev_type, out var out_dev_id);
            return new Context((DeviceType) out_dev_type, out_dev_id);
        }

        public NDArrayHandle GetData()
        {
            NativeMethods.MXNDArrayGetData(NativePtr, out var ret);
            if (GetDType() != 0)
                return IntPtr.Zero;

            return ret;
        }

        public int GetDType()
        {
            NativeMethods.MXNDArrayGetDType(NativePtr, out var ret);
            return ret;
        }

        public NDArrayHandle GetHandle()
        {
            ThrowIfDisposed();
            return NativePtr;
        }

        public IList<int> GetShape()
        {
            NativeMethods.MXNDArrayGetShape(NativePtr, out var outDim, out var outData);
            return InteropHelper.ToInt32Array(outData, outDim);
        }

        public static NDArrayDict LoadToMap(string fileName)
        {
            var arrayMap = new NDArrayDict();
            Logging.CHECK_EQ(NativeMethods.MXNDArrayLoad(fileName,
                out var outSize,
                out var outArr,
                out var outNameSize,
                out var outNames), NativeMethods.OK);
            if (outNameSize > 0)
            {
                var array = InteropHelper.ToPointerArray(outArr, outSize);
                var namearray = InteropHelper.ToPointerArray(outNames, outNameSize);

                Logging.CHECK_EQ(outNameSize, outSize);
                for (uint i = 0; i < outSize; ++i)
                {
                    var name = Marshal.PtrToStringAnsi(namearray[i]);
                    arrayMap[name] = new NDArray(array[i]);
                }
            }

            return arrayMap;
        }

        public static void Save(string fileName, NDArrayDict arrayMap)
        {
            var tmp = arrayMap.Keys.ToArray();

            var args = new NDArrayHandle[tmp.Length];
            var keys = new string[tmp.Length];

            var i = 0;
            foreach (var item in arrayMap)
            {
                args[i] = item.Value.GetHandle();
                keys[i] = item.Key;
                i++;
                ;
            }

            //for (var i = 0; i < tmp.Length; i++)
            //{
            //    var kv = arrayMap[keys[i]];
            //    args[i] = kv.GetHandle();
            //    keys[i] = keys[i];
            //}

            Logging.CHECK_EQ(NativeMethods.MXNDArraySave(fileName, (uint) args.Length, args, keys), NativeMethods.OK);
        }

        public static void Save(string fileName, NDArrayList arrayList)
        {
            var args = arrayList.Select(array => array.GetHandle()).ToArray();
            Logging.CHECK_EQ(NativeMethods.MXNDArraySave(fileName, (uint) args.Length, args, null), NativeMethods.OK);
        }

        public byte[] GetBuffer()
        {
            NativeMethods.MXNDArraySaveRawBytes(NativePtr, out var out_size, out var buffPtr);
            var buff = new byte[out_size];
            Marshal.Copy(buffPtr, buff, 0, out_size);
            return buff;
        }

        public static void Load(string filename, out NDArrayDict data)
        {
            data = new NDArrayDict();
            uint outSize;
            IntPtr outArrPtr;
            uint outNameSize;
            IntPtr outNamesPtr;

            NativeMethods.MXNDArrayLoad(filename, out outSize, out outArrPtr, out outNameSize, out outNamesPtr);
            var outArr = new NDArrayHandle[outSize];
            Marshal.Copy(outArrPtr, outArr, 0, (int) outSize);


            if (outNameSize == 0)
            {
                for (var i = 0; i < outArr.Length; i++) data.Add(i.ToString(), new NDArray(outArr[i]));
            }
            else
            {
                var outNames = new IntPtr[outNameSize];
                Marshal.Copy(outNamesPtr, outNames, 0, (int) outNameSize);

                for (var i = 0; i < outArr.Length; i++)
                {
                    var key = Marshal.PtrToStringAnsi(outNames[i]);
                    if (!string.IsNullOrEmpty(key)) data.Add(key, new NDArray(outArr[i]));
                }
            }
        }

        public static NDArrayDict Load(string filename)
        {
            Load(filename, out var r);
            return r;
        }

        public static NDArray LoadFromBuffer(byte[] buffer)
        {
            NativeMethods.MXNDArrayLoadFromRawBytes(buffer, buffer.Length, out var handle);
            return new NDArray(handle);
        }

        public static NDArray LoadCV2Mat(OpenCvSharp.Mat img, Context context = null)
        {
            if (context == null)
                context = mx.Cpu();

            Shape s = new Shape(img.Height, img.Width, img.Channels());
            byte[] bytes = new byte[s.Size];
            Marshal.Copy(img.Data, bytes, 0, s.Size);
            var ret = new NDArray(bytes, s, context, dtype: DType.Uint8);
            return ret;
        }

        public static NDArray NewFromSharedMem(int shared_pid, int shared_id, Shape shape, DType dtype)
        {
            NativeMethods.MXNDArrayCreateFromSharedMemEx(shared_pid, shared_id, shape.Data, shape.Dimension,
                dtype.Index, out var handle);
            return new NDArray(handle);
        }

        public (int, int, Shape, DType) ToSharedMem()
        {
            NativeMethods.MXNDArrayGetSharedMemHandle(NativePtr, out var shared_pid, out var shared_id);
            return (shared_pid, shared_id, Shape, DataType);
        }

        public void Constant(float scalar)
        {
            using (var op = new Operator("_set_value"))
            {
                op.Set(scalar).Invoke(this);
            }
        }

        public NDArray SliceAxis(int axis, int begin, int? end)
        {
            var @out = new NDArray();
            new Operator("slice_axis")
                .SetParam("axis", axis)
                .SetParam("begin", begin)
                .SetParam("end", end)
                .SetInput("data", this)
                .Invoke(@out);

            return @out;
        }

        public virtual NDArray Slice(int begin, int? end)
        {
            Logging.CHECK_EQ(NativeMethods.MXNDArraySlice(GetHandle(), begin, end.Value, out var handle),
                NativeMethods.OK);
            return new NDArray(handle);
        }

        public void SyncCopyFromCPU(Array data, ulong size)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var resize = size > 0;
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);

            NativeMethods.MXNDArraySyncCopyFromCPU(NativePtr, datagch.AddrOfPinnedObject(), (uint) size);
        }

        public virtual void SyncCopyFromCPU(Array data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyFromCPU(NativePtr, datagch.AddrOfPinnedObject(), (uint) data.Length);
        }

        public void SyncCopyToCPU(Array data)
        {
            SyncCopyToCPU(data, 0);
        }

        public void SyncCopyToCPU(Array data, int size = 0)
        {
            var resize = size > 0;
            size = resize ? size : GetShape().Count();
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyToCPU(NativePtr, datagch.AddrOfPinnedObject(), (ulong) size);

            datagch.Free();
        }

        public void SampleGaussian(float mu = 0, float sigma = 1)
        {
            using (var op = new Operator("_random_normal"))
            {
                op.Set(mu, sigma).Invoke(this);
            }
        }

        public void SampleUniform(float low = 0f, float high = 1f)
        {
            using (var op = new Operator("_random_uniform"))
            {
                op.Set(low, high).Invoke(this);
            }
        }

        public Array AsArray<T>()
        {
            var size = Size;
            var data = new T[size];
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyToCPU(NativePtr, datagch.AddrOfPinnedObject(), (ulong) size);
            datagch.Free();
            return data;
        }

        public T[] GetValues<T>()
        {
            return AsArray<T>().Cast<T>().ToArray();
        }

        public T AsScalar<T>()
        {
            return AsArray<T>().Cast<T>().ToList()[0];
        }

        public static void WaitAll()
        {
            Logging.CHECK_EQ(NativeMethods.MXNDArrayWaitAll(), NativeMethods.OK);
        }

        public void WaitToRead()
        {
            Logging.CHECK_EQ(NativeMethods.MXNDArrayWaitToRead(NativePtr), NativeMethods.OK);
        }

        public void WaitToWrite()
        {
            Logging.CHECK_EQ(NativeMethods.MXNDArrayWaitToWrite(NativePtr), NativeMethods.OK);
        }

        public virtual NDArray AsType(DType dtype)
        {
            return nd.Cast(this, dtype);
        }

        public NDArray AsInContext(Context context)
        {
            if (this.Context == context)
                return this;

            return ChangeContext(context);
        }

        private int StorageType()
        {
            NativeMethods.MXNDArrayGetStorageType(GetHandle(), out var out_storage_type);
            return out_storage_type;
        }

        public virtual ndarray AsNumpy()
        {
            ndarray x = null;

            switch (DataType.Name)
            {
                case "float16":
                    x = np.array(AsArray<float>());
                    break;
                case "float32":
                    x = np.array(AsArray<float>());
                    break;
                case "float64":
                    x = np.array(AsArray<double>());
                    break;
                case "int8":
                    x = np.array(AsArray<byte>());
                    break;
                case "uint8":
                    x = np.array(AsArray<sbyte>());
                    break;
                case "int32":
                    x = np.array(AsArray<int>());
                    break;
                case "int64":
                    x = np.array(AsArray<long>());
                    break;
            }

            var npShape = new List<int>();
            foreach (var item in Shape.Data)
            {
                if (item == 0)
                    continue;

                npShape.Add(item);
            }

            return x.reshape(new shape(npShape.ToArray()));
        }

        public NDArray this[string slice]
        {
            get
            {
                if (string.IsNullOrEmpty(slice))
                    return this;

                var (rowBegin, rowEnd, colBegin, colEnd) = MxUtil.GetSliceNotation(slice, Shape);

                if (colBegin == 0 && colEnd == 0)
                    return Slice(rowBegin, rowEnd);

                return Slice(new Shape(rowBegin, colBegin), new Shape(rowEnd, colEnd));
            }
            set
            {
                if (string.IsNullOrEmpty(slice))
                    value.CopyTo(this);

                var (rowBegin, rowEnd, colBegin, colEnd) = MxUtil.GetSliceNotation(slice, Shape);
                var output = nd.SliceAssign(this, value, new Shape(rowBegin, colBegin), new Shape(rowEnd, colEnd));
                output.CopyTo(this);
            }
        }

        public NDArray this[NDArray slice] => nd.SliceLike(this, slice);

        public NDArray Detach()
        {
            NativeMethods.MXNDArrayDetach(GetHandle(), out var hdl);
            return new NDArray(hdl);
        }

        public void Backward(NDArray out_grad = null, bool retain_graph = false, bool train_mode = true)
        {
            var ograd_handles = new List<NDArrayHandle>();
            var var_handles = new List<NDArrayHandle>();
            //var grad_handles = new List<NDArrayHandle>();
            if (out_grad != null)
                ograd_handles.Add(out_grad.GetHandle());
            else
                ograd_handles.Add(new NDArrayHandle());

            NativeMethods.MXAutogradBackwardEx(1, new NDArrayHandle[1] {NativePtr}, ograd_handles.ToArray(),
                0, var_handles.ToArray(), retain_graph ? 1 : 0,
                0, train_mode ? 1 : 0, out var grad_handles, out var grad_count);
        }

        #region Operators

        public static NDArray operator +(NDArray lhs, NDArray rhs)
        {
            return nd.BroadcastAdd(lhs, rhs);
        }

        public static NDArray operator +(NDArray lhs, float scalar)
        {
            return nd.PlusScalar(lhs, scalar);
        }

        public static NDArray operator +(float scalar, NDArray rhs)
        {
            return nd.PlusScalar(rhs, scalar);
        }

        public static NDArray operator -(NDArray lhs, NDArray rhs)
        {
            return nd.BroadcastSub(lhs, rhs);
        }

        public static NDArray operator -(NDArray lhs, float scalar)
        {
            return nd.MinusScalar(lhs, scalar);
        }

        public static NDArray operator -(float scalar, NDArray rhs)
        {
            return nd.RminusScalar(rhs, scalar);
        }

        public static NDArray operator *(NDArray lhs, NDArray rhs)
        {
            return nd.BroadcastMul(lhs, rhs);
        }

        public static NDArray operator *(NDArray lhs, float scalar)
        {
            return nd.MulScalar(lhs, scalar);
        }

        public static NDArray operator *(float scalar, NDArray rhs)
        {
            return nd.MulScalar(rhs, scalar);
        }

        public static NDArray operator /(NDArray lhs, NDArray rhs)
        {
            return nd.BroadcastDiv(lhs, rhs);
        }

        public static NDArray operator /(NDArray lhs, float scalar)
        {
            return nd.DivScalar(lhs, scalar);
        }

        public static NDArray operator /(float scalar, NDArray rhs)
        {
            return nd.RdivScalar(rhs, scalar);
        }

        public static NDArray operator %(NDArray lhs, float scalar)
        {
            var ret = new NDArray();
            using (var op = new Operator("_mod_scalar"))
            {
                op.Set(lhs, scalar).Invoke(ret);
            }

            return ret;
        }

        public static NDArray operator %(NDArray lhs, NDArray rhs)
        {
            var ret = new NDArray();
            using (var op = new Operator("_mod"))
            {
                op.Set(lhs, rhs).Invoke(ret);
            }

            return ret;
        }

        public static NDArray operator >(NDArray lhs, NDArray rhs)
        {
            return nd.BroadcastGreater(lhs, rhs);
        }

        public static NDArray operator >=(NDArray lhs, NDArray rhs)
        {
            return nd.BroadcastGreaterEqual(lhs, rhs);
        }

        public static NDArray operator >(NDArray lhs, float rhs)
        {
            return nd.GreaterScalar(lhs, rhs);
        }

        public static NDArray operator >=(NDArray lhs, float rhs)
        {
            return nd.GreaterEqualScalar(lhs, rhs);
        }

        public static NDArray operator >(float lhs, NDArray rhs)
        {
            return nd.GreaterScalar(rhs, lhs);
        }

        public static NDArray operator >=(float lhs, NDArray rhs)
        {
            return nd.GreaterEqualScalar(rhs, lhs);
        }

        public static NDArray operator <(NDArray lhs, NDArray rhs)
        {
            return nd.BroadcastLesser(lhs, rhs);
        }

        public static NDArray operator <=(NDArray lhs, NDArray rhs)
        {
            return nd.BroadcastLesserEqual(lhs, rhs);
        }

        public static NDArray operator <(NDArray lhs, float rhs)
        {
            return nd.LesserScalar(lhs, rhs);
        }

        public static NDArray operator <=(NDArray lhs, float rhs)
        {
            return nd.LesserEqualScalar(lhs, rhs);
        }

        public static NDArray operator <(float lhs, NDArray rhs)
        {
            return nd.LesserScalar(rhs, lhs);
        }

        public static NDArray operator <=(float lhs, NDArray rhs)
        {
            return nd.LesserEqualScalar(rhs, lhs);
        }

        public virtual NDArray Reshape(Shape shape, bool reverse = false)
        {
            NDArrayHandle handle;
            var dims = shape.Data.Select(s => s);
            NativeMethods.MXNDArrayReshape(GetHandle(), shape.Dimension, dims.ToArray(), out handle);
            return new NDArray(handle);
        }

        public virtual NDArray Reshape(params int[] shape)
        {
            var targetShape = new int[shape.Length];
            var prod = -1 * shape.Aggregate(1, (a, b) => a * b);
            for (var i = 0; i < targetShape.Length; i++)
                if (shape[i] != -1)
                    targetShape[i] = shape[i];
                else
                    targetShape[i] = Size / (int)prod;

            return Reshape(new Shape(targetShape));

            //return Reshape(new Shape(shape));
        }

        public NDArray Ravel()
        {
            var n = Shape[0];
            var m = Size / n;
            return Reshape(new Shape(n, m));
        }

        public NDArray Squeeze(int axis)
        {
            return nd.Squeeze(this, new Shape(axis));
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return DataType.Name + ": " + Shape;
        }

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            _Blob.Dispose();
        }

        #endregion

        #endregion
    }
}