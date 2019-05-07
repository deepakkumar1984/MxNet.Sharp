using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MxNetLib.Extensions;
using MxNetLib.Interop;
using NDArrayHandle = System.IntPtr;
using mx_uint = System.UInt32;
using mx_float = System.Single;
using size_t = System.UInt64;

// ReSharper disable once CheckNamespace
namespace MxNetLib
{
    public partial class NDArray : DisposableMXNetObject
    {
        #region Fields

        internal readonly NDBlob _Blob;

        public Context context = MXNet.Device;

        public Shape Shape
        {
            get
            {
                return new Shape(GetShape());
            }
        }

        #endregion

        #region Constructors

        public NDArray(Context ctx = null)
        {
            if (ctx != null)
                context = ctx;
            else
                context = MXNet.Device;

            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreateNone(out var @out), NativeMethods.OK);

            this.NativePtr = @out;
            this._Blob = new NDBlob(@out);
        }

        public NDArray(NDArrayHandle handle, Context ctx = null)
        {
            if (ctx != null)
                context = ctx;
            else
                context = MXNet.Device;

            if (handle == NDArrayHandle.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(handle));

            this.NativePtr = handle;
            this._Blob = new NDBlob(handle);
        }

        public NDArray(IList<mx_uint> shape, bool delayAlloc = true, Context ctx = null)
        {
            if (ctx != null)
                context = ctx;
            else
                context = MXNet.Device;

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
            else
                context = MXNet.Device;

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

        public NDArray(mx_float[] data, Shape shape, Context ctx = null)
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

            NativeMethods.MXNDArraySyncCopyFromCPU(@out, data, (uint)shape.Size);

            this.NativePtr = @out;
            this._Blob = new NDBlob(@out);
        }

        public NDArray(IList<mx_float> data, Shape shape, Context ctx = null)
            : this(data?.ToArray(), shape, ctx)
        {
        }

        public NDArray(IList<mx_float> data, Context ctx = null)
        {
            if (ctx != null)
                context = ctx;
            else
                context = MXNet.Device;

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            Logging.CHECK_EQ(NativeMethods.MXNDArrayCreateNone(out var @out), NativeMethods.OK);

            NativeMethods.MXNDArraySyncCopyFromCPU(@out, data.ToArray(), (uint)data.Count);

            this.NativePtr = @out;
            this._Blob = new NDBlob(@out);
        }

        #endregion

        #region Properties

        public size_t Size
        {
            get
            {
                size_t ret = 1;
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

        public static IDictionary<string, NDArray> LoadToMap(string fileName)
        {
            var arrayMap = new SortedDictionary<string, NDArray>();
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

        public static void Save(string fileName, IDictionary<string, NDArray> arrayMap)
        {
            var tmp = arrayMap.Keys.ToArray();

            var args = new NDArrayHandle[tmp.Length];
            var keys = new string[tmp.Length];
            for (var i = 0; i < tmp.Length; i++)
            {
                var kv = arrayMap[keys[i]];
                args[i] = kv.GetHandle();
                keys[i] = keys[i];
            }

            Logging.CHECK_EQ(NativeMethods.MXNDArraySave(fileName, (uint)args.Length, args, keys), NativeMethods.OK);
        }

        public static void Save(string fileName, IList<NDArray> arrayList)
        {
            var args = arrayList.Select(array => array.GetHandle()).ToArray();
            Logging.CHECK_EQ(NativeMethods.MXNDArraySave(fileName, (uint)args.Length, args, null), NativeMethods.OK);
        }

        public static void Load(string filename, out Dictionary<string, NDArray> data)
        {
            data = new Dictionary<string, NDArray>();
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

        public NDArray Slice(mx_uint begin, mx_uint end)
        {
            Logging.CHECK_EQ(NativeMethods.MXNDArraySlice(this.GetHandle(), begin, end, out var handle), NativeMethods.OK);
            return new NDArray(handle);
        }

        public void SyncCopyFromCPU(mx_float[] data, size_t size)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            NativeMethods.MXNDArraySyncCopyFromCPU(this._Blob.Handle, data, (uint)size);
        }

        public void SyncCopyFromCPU(mx_float[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            NativeMethods.MXNDArraySyncCopyFromCPU(this._Blob.Handle, data, (uint)data.Length);
        }

        public void SyncCopyToCPU(mx_float[] data)
        {
            SyncCopyToCPU(data, 0);
        }

        public void SyncCopyToCPU(mx_float[] data, int size = 0)
        {
            var resize = size > 0;
            size = resize ? size : this.GetShape().Count();
            data = new float[size];
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

        public Array AsArray()
        {
            ulong size = this.Size;
            var data = new float[size];
            var datagch = GCHandle.Alloc(data, GCHandleType.Pinned);
            NativeMethods.MXNDArraySyncCopyToCPU(_Blob.Handle, datagch.AddrOfPinnedObject(), size);
            datagch.Free();
            return data;
        }

        public float[] Values
        {
            get
            {
                return AsArray().Cast<float>().ToArray();
            }
        }

        public float Value
        {
            get
            {
                return AsArray().Cast<float>().ToList()[0];
            }
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

        #region Overrides

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

        public NDArray Reshape(Shape shape = null, bool reverse = false)
        {
            NDArrayHandle handle;
            var dims = shape.Data.Select(s => (int)s);
            NativeMethods.MXNDArrayReshape(this.GetHandle(), (int)shape.Dimension, dims.ToArray(), out handle);
            return new NDArray(handle);
        }

        #endregion

        public override string ToString()
        {
            var @out = new StringBuilder();
            @out.Append('[');
            var data = AsArray().Cast<float>().ToList();
            @out.Append(string.Join(", ", data.Select(f => f.ToString(CultureInfo.InvariantCulture))));
            @out.Append(']');

            return @out.ToString();
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
