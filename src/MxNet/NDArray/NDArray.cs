using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MxNet.Extensions;
using MxNet.Interop;
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

        internal readonly NDBlob _Blob;

        public Context context = mx.Device;

        public Shape Shape
        {
            get
            {
                return new Shape(GetShape());
            }
        }

        public DType DataType
        {
            get
            {
                return DType.GetType(GetDType());
            }
        }

        public StorageStype SType
        {
            get
            {
                return (StorageStype)StorageType();
            }
        }
        #endregion

        #region Constructors

        public NDArray(Context ctx = null)
        {
            if (ctx != null)
                context = ctx;

            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreateNone(out var @out), NativeMethods.OK);

            this.NativePtr = @out;
            this._Blob = new NDBlob(@out);
        }

        internal NDArray(NDArrayHandle handle, Context ctx = null)
        {
            if (ctx != null)
                context = ctx;

            if (handle == NDArrayHandle.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(handle));

            this.NativePtr = handle;
            this._Blob = new NDBlob(handle);
        }

        internal NDArray(IList<mx_uint> shape, bool delayAlloc = true, Context ctx = null)
        {
            if (ctx != null)
                context = ctx;

            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            var floats = shape as mx_uint[];
            var arg = floats ?? shape.ToArray();

            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreate(arg,
                                                           (uint)arg.Length,
                                                           context.GetDeviceType(),
                                                           context.GetDeviceId(),
                                                           delayAlloc.ToInt32(),
                                                           out var @out), NativeMethods.OK);
            this.NativePtr = @out;
            this._Blob = new NDBlob(@out);
        }

        public NDArray(Shape shape, bool delayAlloc = true, Context ctx = null)
        {
            if (ctx != null)
                context = ctx;

            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreate(shape.Data,
                                                           shape.Dimension,
                                                           context.GetDeviceType(),
                                                           context.GetDeviceId(),
                                                           delayAlloc.ToInt32(),
                                                           out var @out), NativeMethods.OK);
            this.NativePtr = @out;
            this._Blob = new NDBlob(@out);
        }

        public NDArray(Array data, Shape shape, Context ctx = null)
        {
            if (ctx != null)
                context = ctx;

            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreate(shape.Data,
                                                           (uint)shape.Dimension,
                                                           context.GetDeviceType(),
                                                           context.GetDeviceId(),
                                                           false.ToInt32(),
                                                           out var @out), NativeMethods.OK);
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyFromCPU(@out, datagch.AddrOfPinnedObject(), (uint)shape.Size);

            this.NativePtr = @out;
            this._Blob = new NDBlob(@out);
        }

        public NDArray(Array data, Context ctx = null)
            : this(data, new Shape((uint)data.GetLength(0)), ctx)
        {
            
        }

        #endregion

        #region Properties

        public virtual uint Size
        {
            get
            {
                uint ret = 1;
                var shape = this.GetShape();
                for (var i = 0; i < shape.Count; i++)
                    ret *= shape[i];

                return ret;
            }
        }

        public uint Dimension
        {
            get
            {
                return Shape.Dimension;
            }
        }

        #endregion

        #region Methods

        public NDArray Copy()
        {
            var ret = new NDArray(this.GetShape());
            using (var op = new Operator("_copyto"))
                op.Set(this).Invoke(ret);

            return ret;
        }

        public NDArray CopyTo(NDArray other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            using (var op = new Operator("_copyto"))
                op.Set(this).Invoke(other);
            return other;
        }

        public NDArray ChangeContext(Context ctx)
        {
            NDArray result = new NDArray(Shape, true, ctx);
            CopyTo(result);
            return result;
        }

        public Context GetContext()
        {
            NativeMethods.MXNDArrayGetContext(this._Blob.Handle, out var out_dev_type, out var out_dev_id);
            return new Context((DeviceType)out_dev_type, out_dev_id);
        }

        public NDArrayHandle GetData()
        {
            NativeMethods.MXNDArrayGetData(this._Blob.Handle, out var ret);
            if (this.GetDType() != 0)
                return IntPtr.Zero;

            return ret;
        }

        public int GetDType()
        {
            NativeMethods.MXNDArrayGetDType(this._Blob.Handle, out var ret);
            return ret;
        }

        public NDArrayHandle GetHandle()
        {
            this.ThrowIfDisposed();
            return this.NativePtr;
        }

        public IList<mx_uint> GetShape()
        {
            NativeMethods.MXNDArrayGetShape(this.NativePtr, out var outDim, out var outData);
            return InteropHelper.ToUInt32Array(outData, outDim);
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
                for (mx_uint i = 0; i < outSize; ++i)
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

            int i = 0;
            foreach (var item in arrayMap)
            {
                args[i] = item.Value.GetHandle();
                keys[i] = item.Key;
                i++; ;
            }

            //for (var i = 0; i < tmp.Length; i++)
            //{
            //    var kv = arrayMap[keys[i]];
            //    args[i] = kv.GetHandle();
            //    keys[i] = keys[i];
            //}

            Logging.CHECK_EQ(NativeMethods.MXNDArraySave(fileName, (uint)args.Length, args, keys), NativeMethods.OK);
        }

        public static void Save(string fileName, IList<NDArray> arrayList)
        {
            var args = arrayList.Select(array => array.GetHandle()).ToArray();
            Logging.CHECK_EQ(NativeMethods.MXNDArraySave(fileName, (uint)args.Length, args, null), NativeMethods.OK);
        }

        public static void Load(string filename, out NDArrayDict data)
        {
            data = new NDArrayDict();
            uint outSize;
            IntPtr outArrPtr;
            uint outNameSize;
            IntPtr outNamesPtr;

            NativeMethods.MXNDArrayLoad(filename, out outSize, out outArrPtr, out outNameSize, out outNamesPtr);
            NDArrayHandle[] outArr = new NDArrayHandle[outSize];
            Marshal.Copy(outArrPtr, outArr, 0, (int)outSize);


            if (outNameSize == 0)
            {
                for (int i = 0; i < outArr.Length; i++)
                {
                    data.Add(i.ToString(), new NDArray(outArr[i]));
                }

            }
            else
            {
                IntPtr[] outNames = new IntPtr[outNameSize];
                Marshal.Copy(outNamesPtr, outNames, 0, (int)outNameSize);

                for (int i = 0; i < outArr.Length; i++)
                {
                    var key = Marshal.PtrToStringAnsi(outNames[i]);
                    if (!string.IsNullOrEmpty(key))
                    {
                        data.Add(key, new NDArray(outArr[i]));
                    }
                }
            }
        }

        public void Constant(mx_float scalar)
        {
            using (var op = new Operator("_set_value"))
                op.Set(scalar).Invoke(this);
        }

        public NDArray SliceAxis(int axis, int begin, int? end)
        {
            NDArray @out = new NDArray();
            new Operator("slice_axis")
            .SetParam("axis", axis)
            .SetParam("begin", begin)
            .SetParam("end", end)
            .SetInput("data", this)
            .Invoke(@out);

            return @out;
        }

        public virtual NDArray Slice(mx_uint begin, mx_uint end)
        {
            Logging.CHECK_EQ(NativeMethods.MXNDArraySlice(this.GetHandle(), begin, end, out var handle), NativeMethods.OK);
            return new NDArray(handle);
        }

        public void SyncCopyFromCPU(Array data, size_t size)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var resize = size > 0;
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);

            NativeMethods.MXNDArraySyncCopyFromCPU(this._Blob.Handle, datagch.AddrOfPinnedObject(), (uint)size);
        }

        public virtual void SyncCopyFromCPU(Array data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyFromCPU(this._Blob.Handle, datagch.AddrOfPinnedObject(), (uint)data.Length);
        }

        public void SyncCopyToCPU(Array data)
        {
            SyncCopyToCPU(data, 0);
        }

        public void SyncCopyToCPU(Array data, int size = 0)
        {
            var resize = size > 0;
            size = resize ? size : this.GetShape().Count();
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyToCPU(this._Blob.Handle, datagch.AddrOfPinnedObject(), (ulong)size);

            datagch.Free();
        }

        public void SampleGaussian(float mu = 0, float sigma = 1)
        {
            using (var op = new Operator("_random_normal"))
                op.Set(mu, sigma).Invoke(this);
        }

        public void SampleUniform(float low = 0f, float high = 1f)
        {
            using (var op = new Operator("_random_uniform"))
                op.Set(low, high).Invoke(this);
        }

        public Array AsArray<T>()
        {
            ulong size = this.Size;
            var data = new T[size];
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyToCPU(_Blob.Handle, datagch.AddrOfPinnedObject(), size);
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
            Logging.CHECK_EQ(NativeMethods.MXNDArrayWaitToRead(this._Blob.Handle), NativeMethods.OK);
        }

        public void WaitToWrite()
        {
            Logging.CHECK_EQ(NativeMethods.MXNDArrayWaitToWrite(this._Blob.Handle), NativeMethods.OK);
        }

        public virtual NDArray AsType(DType dtype)
        {
            return nd.Cast(this, dtype);
        }

        public NDArray AsInContext(Context context)
        {
            if (this.context == context)
                return this;

            return this.ChangeContext(context);
        }

        private int StorageType()
        {
            NativeMethods.MXNDArrayGetStorageType(GetHandle(), out var out_storage_type);
            return out_storage_type;
        }

        public virtual NumSharp.NDArray AsNumpy()
        {
            NumSharp.NDArray x = null;

            switch (DataType.Name)
            {
                case "float16":
                    x = NumSharp.np.array(AsArray<float>());
                    break;
                case "float32":
                    x = NumSharp.np.array(AsArray<float>());
                    break;
                case "float64":
                    x = NumSharp.np.array(AsArray<double>());
                    break;
                case "int8":
                    x = NumSharp.np.array(AsArray<byte>());
                    break;
                case "uint8":
                    x = NumSharp.np.array(AsArray<sbyte>());
                    break;
                case "int32":
                    x = NumSharp.np.array(AsArray<int>());
                    break;
                case "int64":
                    x = NumSharp.np.array(AsArray<long>());
                    break;
                default:
                    break;
            }

            List<int> npShape = new List<int>();
            foreach (var item in Shape.Data)
            {
                if (item == 0)
                    continue;

                npShape.Add((int)item);
            }

            return x.reshape(new NumSharp.Shape(npShape.ToArray()));
        }

        #region Operators

        public static NDArray operator +(NDArray lhs, NDArray rhs)
        {
            return nd.ElemwiseAdd(lhs, rhs);
        }

        public static NDArray operator +(NDArray lhs, mx_float scalar)
        {
            return nd.PlusScalar(lhs, scalar);
        }

        public static NDArray operator +(mx_float scalar, NDArray rhs)
        {
            return nd.PlusScalar(rhs, scalar);
        }

        public static NDArray operator -(NDArray lhs, NDArray rhs)
        {
            return nd.ElemwiseSub(lhs, rhs);
        }

        public static NDArray operator -(NDArray lhs, mx_float scalar)
        {
            return nd.MinusScalar(lhs, scalar);
        }

        public static NDArray operator -(mx_float scalar, NDArray rhs)
        {
            return nd.RminusScalar(rhs, scalar);
        }

        public static NDArray operator *(NDArray lhs, NDArray rhs)
        {
            return nd.ElemwiseMul(lhs, rhs);
        }

        public static NDArray operator *(NDArray lhs, mx_float scalar)
        {
            return nd.MulScalar(lhs, scalar);
        }

        public static NDArray operator *(mx_float scalar, NDArray rhs)
        {
            return nd.MulScalar(rhs, scalar);
        }

        public static NDArray operator /(NDArray lhs, NDArray rhs)
        {
            return nd.ElemwiseDiv(lhs, rhs);
        }

        public static NDArray operator /(NDArray lhs, mx_float scalar)
        {
            return nd.DivScalar(lhs, scalar);
        }

        public static NDArray operator /(mx_float scalar, NDArray rhs)
        {
            return nd.RdivScalar(rhs, scalar);
        }

        public static NDArray operator %(NDArray lhs, mx_float scalar)
        {
            var ret = new NDArray();
            using (var op = new Operator("_mod_scalar"))
                op.Set(lhs, scalar).Invoke(ret);
            return ret;
        }

        public static NDArray operator %(NDArray lhs, NDArray rhs)
        {
            var ret = new NDArray();
            using (var op = new Operator("_mod"))
                op.Set(lhs, rhs).Invoke(ret);
            return ret;
        }

        public virtual NDArray Reshape(Shape shape, bool reverse = false)
        {
            NDArrayHandle handle;
            var dims = shape.Data.Select(s => (int)s);
            NativeMethods.MXNDArrayReshape(this.GetHandle(), (int)shape.Dimension, dims.ToArray(), out handle);
            return new NDArray(handle);
        }

        public virtual NDArray Reshape(params int[] shape)
        {
            uint[] targetShape = new mx_uint[shape.Length];
            long prod = -1 * shape.Aggregate(1L, (a, b) => a * b);
            for (int i=0;  i<targetShape.Length;i++)
            {
                if (shape[i] > 0)
                {
                    targetShape[i] = (uint)shape[i];
                }
                else
                {
                    targetShape[i] = Size / (uint)prod;
                }
            }

            return Reshape(new Shape(targetShape));
        }

        public virtual NDArray Reshape(params uint[] shape)
        {
            uint[] targetShape = new mx_uint[shape.Length];
            long prod = -1 * shape.Aggregate(1L, (a, b) => a * b);
            for (int i = 0; i < targetShape.Length; i++)
            {
                if (shape[i] > 0)
                {
                    targetShape[i] = (uint)shape[i];
                }
                else
                {
                    targetShape[i] = Size / (uint)prod;
                }
            }

            return Reshape(new Shape(targetShape));
        }

        public NDArray Ravel()
        {
            uint n = Shape[0];
            uint m = Size / n;
            return Reshape(new Shape(n, m));
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return DataType.Name + ": " + Shape.ToString();
        }

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            this._Blob.Dispose();
        }

        #endregion

        #endregion

    }

}
