using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class MXRtc
	{
		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static IntPtr cudaModuleCreate(string source, string[] options, string[] exports)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXRtcCudaModuleCreate", CApi.MXRtcCudaModuleCreate(source, Helper.length(options), options, Helper.length(exports), exports, out @out));
			return @out;
		}

		public static void cudaModuleFree(IntPtr handle)
		{
			Helper.throwOnError("MXRtcCudaModuleFree", CApi.MXRtcCudaModuleFree(handle));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1
		})]
		public static IntPtr cudaKernelCreate(IntPtr handle, string name, int[] is_ndarray, int[] is_const, int[] arg_types)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXRtcCudaKernelCreate", CApi.MXRtcCudaKernelCreate(handle, name, Helper.length(arg_types), is_ndarray, is_const, arg_types, out @out));
			return @out;
		}

		public static void cudaKernelFree(IntPtr handle)
		{
			Helper.throwOnError("MXRtcCudaKernelFree", CApi.MXRtcCudaKernelFree(handle));
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
		public static void cudaKernelCall(IntPtr handle, int dev_id, IntPtr[] args, uint grid_dim_x, uint grid_dim_y, uint grid_dim_z, uint block_dim_x, uint block_dim_y, uint block_dim_z, uint shared_mem)
		{
			Helper.throwOnError("MXRtcCudaKernelCall", CApi.MXRtcCudaKernelCall(handle, dev_id, args, grid_dim_x, grid_dim_y, grid_dim_z, block_dim_x, block_dim_y, block_dim_z, shared_mem));
		}
	}
}
