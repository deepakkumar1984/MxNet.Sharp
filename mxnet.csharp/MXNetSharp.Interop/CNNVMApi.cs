using Microsoft.FSharp.Core;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class CNNVMApi
	{
		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern void NNAPISetLastError(string msg);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNListAllOpNames(out uint out_size, out IntPtr out_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGetOpHandle(string op_name, out IntPtr op_out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNListUniqueOps(out uint out_size, out IntPtr out_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGetOpInfo(IntPtr op, out IntPtr real_name, out IntPtr description, out uint num_doc_args, out IntPtr arg_names, out IntPtr arg_type_infos, out IntPtr arg_descriptions, out IntPtr return_type);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolCreateAtomicSymbol(IntPtr op, uint num_param, string[] keys, string[] vals, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolCreateVariable(string name, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolCreateGroup(uint num_symbols, IntPtr[] symbols, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNAddControlDeps(IntPtr handle, IntPtr src_dep);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolFree(IntPtr symbol);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolCopy(IntPtr symbol, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolPrint(IntPtr symbol, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolGetAttr(IntPtr symbol, string key, out IntPtr @out, out int success);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolSetAttrs(IntPtr symbol, uint num_param, string[] keys, string[] values);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolListAttrs(IntPtr symbol, int recursive_option, out uint out_size, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolListInputVariables(IntPtr symbol, int option, out uint out_size, out IntPtr out_sym_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolListInputNames(IntPtr symbol, int option, out uint out_size, out IntPtr out_sym_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolListOutputNames(IntPtr symbol, out uint out_size, out IntPtr out_str_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolGetNumOutputs(IntPtr symbol, out uint output_count);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolGetInternals(IntPtr symbol, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolGetChildren(IntPtr symbol, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolGetOutput(IntPtr symbol, uint index, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNSymbolCompose(IntPtr sym, string name, uint num_args, string[] keys, IntPtr[] args);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGraphCreate(IntPtr symbol, IntPtr[] graph);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGraphFree(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGraphGetSymbol(IntPtr graph, IntPtr[] symbol);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGraphSetJSONAttr(IntPtr handle, string key, string json_value);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGraphGetJSONAttr(IntPtr handle, string key, out IntPtr json_out, out int success);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGraphSetNodeEntryListAttr_(IntPtr handle, string key, IntPtr list);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl)]
		public static extern int NNGraphApplyPasses(IntPtr src, uint num_pass, string[] pass_names, out IntPtr dst);
	}
}
