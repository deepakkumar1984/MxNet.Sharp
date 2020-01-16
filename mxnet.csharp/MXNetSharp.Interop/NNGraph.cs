using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class NNGraph
	{
		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void create(IntPtr symbol, IntPtr[] graph)
		{
			Helper.throwOnError("NNGraphCreate", CNNVMApi.NNGraphCreate(symbol, graph));
		}

		public static void free(IntPtr handle)
		{
			Helper.throwOnError("NNGraphFree", CNNVMApi.NNGraphFree(handle));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void getSymbol(IntPtr graph, IntPtr[] symbol)
		{
			Helper.throwOnError("NNGraphGetSymbol", CNNVMApi.NNGraphGetSymbol(graph, symbol));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void setJSONAttr(IntPtr handle, string key, string json_value)
		{
			Helper.throwOnError("NNGraphSetJSONAttr", CNNVMApi.NNGraphSetJSONAttr(handle, key, json_value));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public unsafe static FSharpOption<string> getJSONAttr(IntPtr handle, string key)
		{
			IntPtr json_out = Helper.un<IntPtr>();
			int success = Helper.un<int>();
			Helper.throwOnError("NNGraphGetJSONAttr", CNNVMApi.NNGraphGetJSONAttr(handle, key, out json_out, out success));
			if (success == 0 || (long)json_out <= (long)(IntPtr)(void*)0L)
			{
				return null;
			}
			return FSharpOption<string>.Some(Helper.str(json_out));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void setNodeEntryListAttr(IntPtr handle, string key, IntPtr list)
		{
			Helper.throwOnError("NNGraphSetNodeEntryListAttr", CNNVMApi.NNGraphSetNodeEntryListAttr_(handle, key, list));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static IntPtr applyPasses(IntPtr src, uint num_pass, string[] pass_names)
		{
			IntPtr dst = Helper.un<IntPtr>();
			Helper.throwOnError("NNGraphApplyPasses", CNNVMApi.NNGraphApplyPasses(src, num_pass, pass_names, out dst));
			return dst;
		}
	}
}
