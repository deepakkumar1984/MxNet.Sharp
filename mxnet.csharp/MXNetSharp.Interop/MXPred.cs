using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class MXPred
	{
		[Serializable]
		internal sealed class getOutputShape_00401651 : FSharpFunc<int, uint>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal getOutputShape_00401651(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override uint Invoke(int i)
			{
				return (uint)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(uint))), typeof(uint));
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
		public static IntPtr create(string symbol_json_str, IntPtr param_bytes, int param_size, int dev_type, int dev_id, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXPredCreate", CPredictApi.MXPredCreate(symbol_json_str, param_bytes, param_size, dev_type, dev_id, (uint)ArrayModule.Length<string>(input_keys), input_keys, input_shape_indptr, input_shape_data, out @out));
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
			1,
			1
		})]
		public static IntPtr createEx(string symbol_json_str, IntPtr param_bytes, int param_size, int dev_type, int dev_id, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, string[] provided_arg_dtype_names, int[] provided_arg_dtypes)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXPredCreateEx", CPredictApi.MXPredCreateEx(symbol_json_str, param_bytes, param_size, dev_type, dev_id, (uint)ArrayModule.Length<string>(input_keys), input_keys, input_shape_indptr, input_shape_data, (uint)ArrayModule.Length<string>(provided_arg_dtype_names), provided_arg_dtype_names, provided_arg_dtypes, out @out));
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
		public static IntPtr createPartialOut(string symbol_json_str, IntPtr param_bytes, int param_size, int dev_type, int dev_id, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, string[] output_keys)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXPredCreatePartialOut", CPredictApi.MXPredCreatePartialOut(symbol_json_str, param_bytes, param_size, dev_type, dev_id, (uint)ArrayModule.Length<string>(input_keys), input_keys, input_shape_indptr, input_shape_data, (uint)ArrayModule.Length<string>(output_keys), output_keys, out @out));
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
		public static IntPtr createMultiThread(string symbol_json_str, IntPtr param_bytes, int param_size, int dev_type, int dev_id, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, int num_threads)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXPredCreateMultiThread", CPredictApi.MXPredCreateMultiThread(symbol_json_str, param_bytes, param_size, dev_type, dev_id, (uint)ArrayModule.Length<string>(input_keys), input_keys, input_shape_indptr, input_shape_data, num_threads, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static IntPtr reshape(string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, IntPtr handle)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXPredReshape", CPredictApi.MXPredReshape((uint)ArrayModule.Length<string>(input_keys), input_keys, input_shape_indptr, input_shape_data, handle, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public unsafe static uint[] getOutputShape(IntPtr handle, uint index)
		{
			IntPtr shape_data = (IntPtr)(void*)0L;
			uint shape_ndim = Helper.un<uint>();
			Helper.throwOnError("MXPredGetOutputShape", CPredictApi.MXPredGetOutputShape(handle, index, out shape_data, out shape_ndim));
			uint num = shape_ndim;
			IntPtr ptr = shape_data;
			int num2 = (int)num;
			FSharpFunc<int, uint> val = new getOutputShape_00401651(ptr);
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
			uint[] array = new uint[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static int getOutputType(IntPtr handle, int index)
		{
			int out_dtype = Helper.un<int>();
			Helper.throwOnError("MXPredGetOutputType", CPredictApi.MXPredGetOutputType(handle, (uint)index, out out_dtype));
			return out_dtype;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void setInput(IntPtr handle, string key, float[] data, uint size)
		{
			Helper.throwOnError("MXPredSetInput", CPredictApi.MXPredSetInput(handle, key, data, size));
		}

		public static void forward(IntPtr handle)
		{
			Helper.throwOnError("MXPredForward", CPredictApi.MXPredForward(handle));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void partialForward(IntPtr handle, int step)
		{
			int step_left = Helper.un<int>();
			Helper.throwOnError("MXPredPartialForward", CPredictApi.MXPredPartialForward(handle, step, out step_left));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void getOutput(IntPtr handle, uint index, IntPtr data, uint size)
		{
			Helper.throwOnError("MXPredGetOutput", CPredictApi.MXPredGetOutput(handle, index, data, size));
		}

		public static void free(IntPtr handle)
		{
			Helper.throwOnError("MXPredFree", CPredictApi.MXPredFree(handle));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static IntPtr setMonitorCallback(IntPtr handle, CPredictApi.PredMonitorCallback callback, bool monitor_all)
		{
			IntPtr callback_handle = Helper.un<IntPtr>();
			Helper.throwOnError("MXPredSetMonitorCallback", CPredictApi.MXPredSetMonitorCallback(handle, callback, out callback_handle, monitor_all));
			return callback_handle;
		}
	}
}
