using Microsoft.FSharp.Core;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class CPredictApi
	{
		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void PredMonitorCallback(string, IntPtr, IntPtr);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredCreate(string symbol_json_str, IntPtr param_bytes, int param_size, int dev_type, int dev_id, uint num_input_nodes, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredCreateEx(string symbol_json_str, IntPtr param_bytes, int param_size, int dev_type, int dev_id, uint num_input_nodes, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, uint num_provided_arg_dtypes, string[] provided_arg_dtype_names, int[] provided_arg_dtypes, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredCreatePartialOut(string symbol_json_str, IntPtr param_bytes, int param_size, int dev_type, int dev_id, uint num_input_nodes, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, uint num_output_nodes, string[] output_keys, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredCreateMultiThread(string symbol_json_str, IntPtr param_bytes, int param_size, int dev_type, int dev_id, uint num_input_nodes, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, int num_threads, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredReshape(uint num_input_nodes, string[] input_keys, uint[] input_shape_indptr, uint[] input_shape_data, IntPtr handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredGetOutputShape(IntPtr handle, uint index, out IntPtr shape_data, out uint shape_ndim);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredGetOutputType(IntPtr handle, uint out_index, out int out_dtype);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredSetInput(IntPtr handle, string key, float[] data, uint size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredForward(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredPartialForward(IntPtr handle, int step, out int step_left);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredGetOutput(IntPtr handle, uint index, IntPtr data, uint size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredFree(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXNDListCreate(string nd_file_bytes, int nd_file_size, out IntPtr @out, out uint out_length);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXNDListGet(IntPtr handle, uint index, out IntPtr out_key, out IntPtr out_data, out IntPtr out_shape, out uint out_ndim);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXPredSetMonitorCallback(IntPtr handle, PredMonitorCallback callback, out IntPtr callback_handle, bool monitor_all);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int MXNDListFree(IntPtr handle);
	}
}
