#define DEBUG
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class MXNDArray
	{
		[Serializable]
		internal sealed class create_0040921<a> : FSharpFunc<a, uint>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal create_0040921()
			{
			}

			public override uint Invoke(a value)
			{
				throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
			}
		}

		[Serializable]
		internal sealed class createEx_0040933<a> : FSharpFunc<a, uint>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal createEx_0040933()
			{
			}

			public override uint Invoke(a value)
			{
				throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
			}
		}

		[Serializable]
		internal sealed class createEx64_0040945<a> : FSharpFunc<a, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal createEx64_0040945()
			{
			}

			public override long Invoke(a value)
			{
				throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
			}
		}

		[Serializable]
		internal sealed class arrs_0040981 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal arrs_0040981(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override IntPtr Invoke(int i)
			{
				return Helper.readIntPtr(i, ptr);
			}
		}

		[Serializable]
		internal sealed class names_0040982 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal names_0040982(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class getShape_00401059 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal getShape_00401059(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class getShape64_00401070 : FSharpFunc<int, long>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal getShape64_00401070(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override long Invoke(int i)
			{
				return (long)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(long))), typeof(long));
			}
		}

		[Serializable]
		internal sealed class imperativeInvoke_00401137 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal imperativeInvoke_00401137(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class aux_ndims_00401207 : FSharpFunc<uint[], uint>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal aux_ndims_00401207()
			{
			}

			public override uint Invoke(uint[] a)
			{
				return Helper.ulength(a);
			}
		}

		[Serializable]
		internal sealed class aux_ndims_00401229_002D1 : FSharpFunc<long[], int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal aux_ndims_00401229_002D1()
			{
			}

			public override int Invoke(long[] a)
			{
				return Helper.length(a);
			}
		}

		[Serializable]
		internal sealed class names_00401251_002D1 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal names_00401251_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class handles_00401252 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal handles_00401252(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		public static IntPtr createNone()
		{
			IntPtr @out = IntPtr.Zero;
			Helper.throwOnError("MXNDArrayCreateNone", CApi.MXNDArrayCreateNone(out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static IntPtr create<a>(a[] shape, DeviceTypeEnum dev_type, int dev_id, bool delay_alloc)
		{
			IntPtr @out = IntPtr.Zero;
			FSharpFunc<a, uint> val = new create_0040921<a>();
			if (shape == null)
			{
				throw new ArgumentNullException("array");
			}
			uint[] array = new uint[shape.Length];
			string call = "MXNDArrayCreate";
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(shape[i]);
			}
			Helper.throwOnError(call, CApi.MXNDArrayCreate(array, (uint)shape.Length, (int)dev_type, dev_id, Helper.boolToInt(delay_alloc), out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1
		})]
		public static IntPtr createEx<a>(a[] shape, DeviceTypeEnum dev_type, int dev_id, bool delay_alloc, TypeFlag dtype)
		{
			IntPtr @out = IntPtr.Zero;
			FSharpFunc<a, uint> val = new createEx_0040933<a>();
			if (shape == null)
			{
				throw new ArgumentNullException("array");
			}
			uint[] array = new uint[shape.Length];
			string call = "MXNDArrayCreateEx";
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(shape[i]);
			}
			Helper.throwOnError(call, CApi.MXNDArrayCreateEx(array, (uint)shape.Length, (int)dev_type, dev_id, Helper.boolToInt(delay_alloc), (int)dtype, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1
		})]
		public static IntPtr createEx64<a>(a[] shape, int dev_type, int dev_id, int delay_alloc, int dtype)
		{
			IntPtr @out = IntPtr.Zero;
			FSharpFunc<a, long> val = new createEx64_0040945<a>();
			if (shape == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array = new long[shape.Length];
			string call = "MXNDArrayCreateEx64";
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(shape[i]);
			}
			Helper.throwOnError(call, CApi.MXNDArrayCreateEx64(array, shape.Length, dev_type, dev_id, delay_alloc, dtype, out @out));
			return @out;
		}

		public static IntPtr loadFromRawBytes(byte[] buf)
		{
			IntPtr @out = IntPtr.Zero;
			Helper.throwOnError("MXNDArrayLoadFromRawBytes", CApi.MXNDArrayLoadFromRawBytes(buf, buf.Length, out @out));
			return @out;
		}

		public static byte[] saveRawBytes(IntPtr handle)
		{
			long out_size = Helper.un<long>();
			IntPtr out_buf = IntPtr.Zero;
			Helper.throwOnError("MXNDArraySaveRawBytes", CApi.MXNDArraySaveRawBytes(handle, out out_size, out out_buf));
			return Helper.readByteArray((int)out_size, out_buf);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void save(string fname, IntPtr[] args, string[] keys)
		{
			Helper.throwOnError("MXNDArraySave", CApi.MXNDArraySave(fname, (uint)args.Length, args, keys));
		}

		public static Tuple<string[], IntPtr[]> load(string fname)
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_arr = IntPtr.Zero;
			uint out_name_size = Helper.un<uint>();
			IntPtr out_names = IntPtr.Zero;
			Helper.throwOnError("MXNDArrayLoad", CApi.MXNDArrayLoad(fname, out out_size, out out_arr, out out_name_size, out out_names));
			uint num = out_size;
			IntPtr ptr = out_arr;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new arrs_0040981(ptr);
			if (num2 < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num2
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			IntPtr[] array = new IntPtr[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			IntPtr[] arrs = array;
			uint num3 = out_name_size;
			IntPtr ptr2 = out_names;
			int num4 = (int)num3;
			FSharpFunc<int, string> val2 = new names_0040982(ptr2);
			if (num4 < 0)
			{
				object[] args2 = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num4
				};
				string message2 = string.Format("{0}\n{1} = {2}", args2);
				throw new ArgumentException(message2, "count");
			}
			string[] array2 = new string[num4];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = val2.Invoke(j);
			}
			string[] names = array2;
			return new Tuple<string[], IntPtr[]>(names, arrs);
		}

		public static void free(IntPtr handle)
		{
			Helper.throwOnError("MXNDArrayFree", CApi.MXNDArrayFree(handle));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static IntPtr slice<a, b>(IntPtr handle, a slice_begin, b slice_end)
		{
			IntPtr @out = IntPtr.Zero;
			if (false)
			{
				uint slice_begin2 = (uint)(object)null;
				if (0 == 0)
				{
					throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
				}
				Helper.throwOnError("MXNDArraySlice", CApi.MXNDArraySlice(handle, slice_begin2, (uint)(object)null, out @out));
				return @out;
			}
			throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static IntPtr slice64(IntPtr handle, long slice_begin, long slice_end)
		{
			IntPtr @out = IntPtr.Zero;
			Helper.throwOnError("MXNDArraySlice64", CApi.MXNDArraySlice64(handle, slice_begin, slice_end, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr at<a>(IntPtr handle, a index)
		{
			IntPtr @out = IntPtr.Zero;
			if (0 == 0)
			{
				throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
			}
			Helper.throwOnError("MXNDArrayAt", CApi.MXNDArrayAt(handle, (uint)(object)null, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr at64(IntPtr handle, long index)
		{
			IntPtr @out = IntPtr.Zero;
			Helper.throwOnError("MXNDArrayAt64", CApi.MXNDArrayAt64(handle, index, out @out));
			return @out;
		}

		public static int getStorageType(IntPtr handle)
		{
			int @out = Helper.un<int>();
			Helper.throwOnError("MXNDArrayGetStorageType", CApi.MXNDArrayGetStorageType(handle, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr reshape(IntPtr handle, int[] dims)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayReshape", CApi.MXNDArrayReshape(handle, dims.Length, dims, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static IntPtr reshape64(IntPtr handle, long[] dims, bool reverse)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayReshape64", CApi.MXNDArrayReshape64(handle, dims.Length, dims, reverse, out @out));
			return @out;
		}

		public static int[] getShape(IntPtr handle)
		{
			int out_dim = Helper.un<int>();
			IntPtr out_pdata = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayGetShapeEx", CApi.MXNDArrayGetShapeEx(handle, out out_dim, out out_pdata));
			if (out_dim > 0)
			{
				int num = out_dim;
				IntPtr ptr = out_pdata;
				int num2 = num;
				FSharpFunc<int, int> val = new getShape_00401059(ptr);
				if (num2 < 0)
				{
					object[] args = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num2
					};
					string message = string.Format("{0}\n{1} = {2}", args);
					throw new ArgumentException(message, "count");
				}
				int[] array = new int[num2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				return array;
			}
			return ArrayModule.Empty<int>();
		}

		public static long[] getShape64(IntPtr handle)
		{
			int out_dim = Helper.un<int>();
			IntPtr out_pdata = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayGetShapeEx64", CApi.MXNDArrayGetShapeEx64(handle, out out_dim, out out_pdata));
			if (out_dim > 0)
			{
				int num = out_dim;
				IntPtr ptr = out_pdata;
				int num2 = num;
				FSharpFunc<int, long> val = new getShape64_00401070(ptr);
				if (num2 < 0)
				{
					object[] args = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num2
					};
					string message = string.Format("{0}\n{1} = {2}", args);
					throw new ArgumentException(message, "count");
				}
				long[] array = new long[num2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				return array;
			}
			return ArrayModule.Empty<long>();
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void syncCopyFromCPUArray(IntPtr handle, Array data)
		{
			GCHandle h = GCHandle.Alloc(data);
			try
			{
				IntPtr iptr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
				long sz = data.Length;
				Helper.throwOnError("MXNDArraySyncCopyFromCPU", CApi.MXNDArraySyncCopyFromCPU(handle, iptr, sz));
				Unit val = null;
			}
			finally
			{
				h.Free();
				_ = null;
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public unsafe static void syncCopyFromCPU<a>(IntPtr handle, a[] data)
		{
			IntPtr intPtr;
			if (data != null)
			{
				if (ArrayModule.Length<a>(data) != 0)
				{
					reference = ref data[0];
					intPtr = (IntPtr)(&reference);
				}
				else
				{
					intPtr = (IntPtr)0;
				}
			}
			else
			{
				intPtr = (IntPtr)0;
			}
			IntPtr ptr = intPtr;
			IntPtr iptr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
			long sz = data.Length;
			Helper.throwOnError("MXNDArraySyncCopyFromCPU", CApi.MXNDArraySyncCopyFromCPU(handle, iptr, sz));
		}

		public static (DeviceTypeEnum, int) getContext(IntPtr handle)
		{
			int out_dev_type = Helper.un<int>();
			int out_dev_id = Helper.un<int>();
			Helper.throwOnError("MXNDArrayGetContext", CApi.MXNDArrayGetContext(handle, out out_dev_type, out out_dev_id));
			return ((DeviceTypeEnum)out_dev_type, out_dev_id);
		}

		public static TypeFlag getDType(IntPtr handle)
		{
			int out_dtype = Helper.un<int>();
			Helper.throwOnError("MXNDArrayGetDType", CApi.MXNDArrayGetDType(handle, out out_dtype));
			return (TypeFlag)out_dtype;
		}

		public static IntPtr getData(IntPtr handle)
		{
			IntPtr out_pdata = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayGetDType", CApi.MXNDArrayGetData(handle, out out_pdata));
			return out_pdata;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static IntPtr[] imperativeInvoke(IntPtr creator, IntPtr[] inputs, string[] parameterKeys, string[] parameterValues)
		{
			int num_outputs = Helper.un<int>();
			IntPtr outputs = Helper.un<IntPtr>();
			Debug.Assert(Helper.length(parameterKeys) == Helper.length(parameterValues));
			Helper.throwOnError("MXImperativeInvoke", CApi.MXImperativeInvoke(creator, Helper.length(inputs), inputs, ref num_outputs, ref outputs, ArrayModule.Length<string>(parameterKeys), parameterKeys, parameterValues));
			int num = num_outputs;
			IntPtr ptr = outputs;
			int num2 = num;
			FSharpFunc<int, IntPtr> val = new imperativeInvoke_00401137(ptr);
			if (num2 < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num2
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			IntPtr[] array = new IntPtr[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1
		})]
		public unsafe static int imperativeInvokeInto(IntPtr creator, IntPtr[] inputs, IntPtr[] outputs, string[] parameterKeys, string[] parameterValues)
		{
			int num_outputs = outputs.Length;
			Debug.Assert(Helper.length(parameterKeys) == Helper.length(parameterValues));
			IntPtr intPtr;
			if (outputs != null)
			{
				if (ArrayModule.Length<IntPtr>(outputs) != 0)
				{
					reference = ref outputs[0];
					intPtr = (IntPtr)(&reference);
				}
				else
				{
					intPtr = (IntPtr)0;
				}
			}
			else
			{
				intPtr = (IntPtr)0;
			}
			IntPtr outputsptr = intPtr;
			IntPtr ptr = outputsptr;
			Helper.throwOnError("imperativeInvokeInto", CApi.MXImperativeInvoke(creator, Helper.length(inputs), inputs, ref num_outputs, ref ptr, Helper.length(parameterKeys), parameterKeys, parameterValues));
			Debug.Assert(ptr == outputsptr);
			return num_outputs;
		}

		public static void waitAll()
		{
			Helper.throwOnError("MXNDArrayWaitAll", CApi.MXNDArrayWaitAll());
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public unsafe static void syncCopyToCPU<a>(IntPtr handle, a[] a)
		{
			IntPtr intPtr;
			if (a != null)
			{
				if (ArrayModule.Length<a>(a) != 0)
				{
					reference = ref a[0];
					intPtr = (IntPtr)(&reference);
				}
				else
				{
					intPtr = (IntPtr)0;
				}
			}
			else
			{
				intPtr = (IntPtr)0;
			}
			IntPtr ptr = intPtr;
			long size = a.Length;
			IntPtr data = ptr;
			Helper.throwOnError("MXNDArraySyncCopyToCPU", CApi.MXNDArraySyncCopyToCPU(handle, data, size));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void syncCopyToCPUArray(IntPtr handle, Array data)
		{
			GCHandle h = GCHandle.Alloc(data);
			try
			{
				IntPtr iptr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
				long sz = data.Length;
				Helper.throwOnError("MXNDArraySyncCopyToCPU", CApi.MXNDArraySyncCopyToCPU(handle, iptr, sz));
				Unit val = null;
			}
			finally
			{
				h.Free();
				_ = null;
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		})]
		public static IntPtr createSparseEx(int storage_type, uint[] shape, int dev_type, int dev_id, int delay_alloc, int dtype, int[] aux_type, uint[][] aux_shape)
		{
			IntPtr @out = Helper.un<IntPtr>();
			FSharpFunc<uint[], uint> val = new aux_ndims_00401207();
			if (aux_shape == null)
			{
				throw new ArgumentNullException("array");
			}
			uint[] array = new uint[aux_shape.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(aux_shape[i]);
			}
			uint[] aux_ndims = array;
			uint[] aux_shape2 = ArrayModule.Concat<uint>((IEnumerable<uint[]>)aux_shape);
			Helper.throwOnError("MXNDArrayCreateSparseEx", CApi.MXNDArrayCreateSparseEx(storage_type, shape, Helper.ulength(shape), dev_type, dev_id, delay_alloc, dtype, Helper.ulength(aux_type), aux_type, aux_ndims, aux_shape2, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		})]
		public static void createSparseEx64(int storage_type, long[] shape, int dev_type, int dev_id, int delay_alloc, int dtype, uint num_aux, int[] aux_type, long[][] aux_shape)
		{
			IntPtr @out = Helper.un<IntPtr>();
			FSharpFunc<long[], int> val = new aux_ndims_00401229_002D1();
			if (aux_shape == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array = new int[aux_shape.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(aux_shape[i]);
			}
			int[] aux_ndims = array;
			long[] aux_shape2 = ArrayModule.Concat<long>((IEnumerable<long[]>)aux_shape);
			Helper.throwOnError("MXNDArrayCreateSparseEx64", CApi.MXNDArrayCreateSparseEx64(storage_type, shape, Helper.length(shape), dev_type, dev_id, delay_alloc, dtype, num_aux, aux_type, aux_ndims, aux_shape2, out @out));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Tuple<string[], IntPtr[]> loadFromBuffer(IntPtr ndarray_buffer, long size)
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_arr = Helper.un<IntPtr>();
			uint out_name_size = Helper.un<uint>();
			IntPtr out_names = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayLoadFromBuffer", CApi.MXNDArrayLoadFromBuffer(ndarray_buffer, size, out out_size, out out_arr, out out_name_size, out out_names));
			uint num = out_name_size;
			IntPtr ptr = out_names;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new names_00401251_002D1(ptr);
			if (num2 < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num2
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			string[] array = new string[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			string[] names = array;
			uint num3 = out_size;
			IntPtr ptr2 = out_arr;
			int num4 = (int)num3;
			FSharpFunc<int, IntPtr> val2 = new handles_00401252(ptr2);
			if (num4 < 0)
			{
				object[] args2 = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num4
				};
				string message2 = string.Format("{0}\n{1} = {2}", args2);
				throw new ArgumentException(message2, "count");
			}
			IntPtr[] array2 = new IntPtr[num4];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = val2.Invoke(j);
			}
			IntPtr[] handles = array2;
			return new Tuple<string[], IntPtr[]>(names, handles);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void syncCopyFromNDArray(IntPtr handle_dst, IntPtr handle_src, int i)
		{
			Helper.throwOnError("MXNDArraySyncCopyFromNDArray", CApi.MXNDArraySyncCopyFromNDArray(handle_dst, handle_src, i));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void syncCheckFormat(IntPtr handle, bool full_check)
		{
			Helper.throwOnError("MXNDArraySyncCheckFormat", CApi.MXNDArraySyncCheckFormat(handle, full_check));
		}

		public static void waitToRead(IntPtr handle)
		{
			Helper.throwOnError("MXNDArrayWaitToRead", CApi.MXNDArrayWaitToRead(handle));
		}

		public static void waitToWrite(IntPtr handle)
		{
			Helper.throwOnError("MXNDArrayWaitToWrite", CApi.MXNDArrayWaitToWrite(handle));
		}

		public static IntPtr toDLPack(IntPtr handle)
		{
			IntPtr out_dlpack = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayToDLPack", CApi.MXNDArrayToDLPack(handle, out out_dlpack));
			return out_dlpack;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr fromDLPackEx(IntPtr dlpack, bool transient_handle)
		{
			IntPtr out_handle = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayFromDLPackEx", CApi.MXNDArrayFromDLPackEx(dlpack, transient_handle, out out_handle));
			return out_handle;
		}

		public static void callDLPackDeleter(IntPtr dlpack)
		{
			Helper.throwOnError("MXNDArrayCallDLPackDeleter", CApi.MXNDArrayCallDLPackDeleter(dlpack));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static TypeFlag getAuxType(IntPtr handle, uint i)
		{
			int out_type = Helper.un<int>();
			Helper.throwOnError("MXNDArrayGetAuxType", CApi.MXNDArrayGetAuxType(handle, i, out out_type));
			return (TypeFlag)out_type;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static TypeFlag getAuxType64(IntPtr handle, long i)
		{
			int out_type = Helper.un<int>();
			Helper.throwOnError("MXNDArrayGetAuxType64", CApi.MXNDArrayGetAuxType64(handle, i, out out_type));
			return (TypeFlag)out_type;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr getAuxNDArray(IntPtr handle, uint i)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayGetAuxNDArray", CApi.MXNDArrayGetAuxNDArray(handle, i, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr getAuxNDArray64(IntPtr handle, long i)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayGetAuxNDArray64", CApi.MXNDArrayGetAuxNDArray64(handle, i, out @out));
			return @out;
		}

		public static IntPtr getDataNDArray(IntPtr handle)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayGetDataNDArray", CApi.MXNDArrayGetDataNDArray(handle, out @out));
			return @out;
		}

		public static IntPtr getGrad(IntPtr handle)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayGetGrad", CApi.MXNDArrayGetGrad(handle, out @out));
			return @out;
		}

		public static IntPtr detach(IntPtr handle)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXNDArrayDetach", CApi.MXNDArrayDetach(handle, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void setGradState(IntPtr handle, int state)
		{
			Helper.throwOnError("MXNDArraySetGradState", CApi.MXNDArraySetGradState(handle, state));
		}

		public static int getGradState(IntPtr handle)
		{
			int @out = Helper.un<int>();
			Helper.throwOnError("MXNDArrayGetGradState", CApi.MXNDArrayGetGradState(handle, out @out));
			return @out;
		}
	}
}
