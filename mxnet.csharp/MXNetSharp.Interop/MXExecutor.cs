#define DEBUG
using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class MXExecutor
	{
		[Serializable]
		internal sealed class outputs_00401434 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal outputs_00401434(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		public static void free(IntPtr handle)
		{
			Helper.throwOnError("MXExecutorFree", CApi.MXExecutorFree(handle));
		}

		public unsafe static string print(IntPtr handle)
		{
			IntPtr out_str = (IntPtr)(void*)0L;
			Helper.throwOnError("MXExecutorPrint", CApi.MXExecutorPrint(handle, out out_str));
			return Helper.str(out_str);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void forward(IntPtr handle, int is_train)
		{
			Helper.throwOnError("MXExecutorForward", CApi.MXExecutorForward(handle, is_train));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void backward(IntPtr handle, IntPtr[] head_grads)
		{
			Helper.throwOnError("MXExecutorBackward", CApi.MXExecutorBackward(handle, Helper.ulength(head_grads), head_grads));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void backwardEx(IntPtr handle, IntPtr[] head_grads, int is_train)
		{
			Helper.throwOnError("MXExecutorBackwardEx", CApi.MXExecutorBackwardEx(handle, Helper.ulength(head_grads), head_grads, is_train));
		}

		public static IntPtr[] outputs(IntPtr handle)
		{
			uint out_size = Helper.un<uint>();
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXExecutorOutputs", CApi.MXExecutorOutputs(handle, out out_size, out @out));
			uint num = out_size;
			IntPtr ptr = @out;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new outputs_00401434(ptr);
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
			1,
			1,
			1
		})]
		public static IntPtr bind(IntPtr symbol_handle, int dev_type, int dev_id, IntPtr[] in_args, IntPtr[] arg_grad_store, uint[] grad_req_type, IntPtr[] aux_states)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Debug.Assert(Helper.length(in_args) == Helper.length(arg_grad_store));
			Debug.Assert(Helper.length(in_args) == Helper.length(grad_req_type));
			Helper.throwOnError("MXExecutorBind", CApi.MXExecutorBind(symbol_handle, dev_type, dev_id, Helper.ulength(in_args), in_args, arg_grad_store, grad_req_type, Helper.ulength(aux_states), aux_states, out @out));
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
		public static IntPtr bindX(IntPtr symbol_handle, int dev_type, int dev_id, string[] map_keys, int[] map_dev_types, int[] map_dev_ids, IntPtr[] in_args, IntPtr[] arg_grad_store, uint[] grad_req_type, IntPtr[] aux_states)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXExecutorBindX", CApi.MXExecutorBindX(symbol_handle, dev_type, dev_id, Helper.ulength(map_keys), map_keys, map_dev_types, map_dev_ids, Helper.ulength(in_args), in_args, arg_grad_store, grad_req_type, Helper.ulength(aux_states), aux_states, out @out));
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
			1,
			1
		})]
		public static IntPtr bindEX(IntPtr symbol_handle, int dev_type, int dev_id, string[] map_keys, int[] map_dev_types, int[] map_dev_ids, IntPtr[] in_args, IntPtr[] arg_grad_store, uint[] grad_req_type, IntPtr[] aux_states, IntPtr shared_exec)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXExecutorBindEX", CApi.MXExecutorBindEX(symbol_handle, dev_type, dev_id, Helper.ulength(map_keys), map_keys, map_dev_types, map_dev_ids, Helper.ulength(in_args), in_args, arg_grad_store, grad_req_type, Helper.ulength(aux_states), aux_states, shared_exec, out @out));
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
			1,
			1,
			1,
			1,
			1
		})]
		public static void reshapeEx(int partial_shaping, int allow_up_sizing, int dev_type, int dev_id, string[] map_keys, int[] map_dev_types, int[] map_dev_ids, string[] provided_arg_shape_names, int[] provided_arg_shape_data, uint[] provided_arg_shape_idx, IntPtr[] in_args, IntPtr[] arg_grads, IntPtr[] aux_states, IntPtr shared_exec)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXExecutorReshapeEx", CApi.MXExecutorReshapeEx(partial_shaping, allow_up_sizing, dev_type, dev_id, Helper.ulength(map_keys), map_keys, map_dev_types, map_dev_ids, Helper.ulength(provided_arg_shape_names), provided_arg_shape_names, provided_arg_shape_data, provided_arg_shape_idx, Helper.ulength(in_args), in_args, arg_grads, Helper.ulength(aux_states), aux_states, shared_exec, out @out));
		}

		public static IntPtr getOptimizedSymbol(IntPtr handle)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXExecutorGetOptimizedSymbol", CApi.MXExecutorGetOptimizedSymbol(handle, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public unsafe static IntPtr setMonitorCallback(IntPtr handle, CApi.ExecutorMonitorCallback callback)
		{
			IntPtr callback_handle = (IntPtr)(void*)0L;
			Helper.throwOnError("MXExecutorSetMonitorCallback", CApi.MXExecutorSetMonitorCallback(handle, callback, out callback_handle));
			return callback_handle;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public unsafe static IntPtr setMonitorCallbackEX(IntPtr handle, CApi.ExecutorMonitorCallback callback, bool monitor_all)
		{
			IntPtr callback_handle = (IntPtr)(void*)0L;
			Helper.throwOnError("MXExecutorSetMonitorCallbackEX", CApi.MXExecutorSetMonitorCallbackEX(handle, callback, out callback_handle, monitor_all));
			return callback_handle;
		}
	}
}
