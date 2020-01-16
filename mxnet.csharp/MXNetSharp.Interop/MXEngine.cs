using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class MXEngine
	{
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
		public static void pushAsyncND(CApi.EngineAsyncFunc async_func, IntPtr func_param, CApi.EngineFuncParamDeleter deleter, IntPtr ctx_handle, IntPtr[] _nds_handle, IntPtr[] mutable_nds_handle, IntPtr prop_handle, int priority, string opr_name, bool wait)
		{
			Helper.throwOnError("MXEnginePushAsyncND", CApi.MXEnginePushAsyncND(async_func, func_param, deleter, ctx_handle, _nds_handle, Helper.length(_nds_handle), mutable_nds_handle, Helper.length(mutable_nds_handle), prop_handle, priority, opr_name, wait));
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
		public static void pushSyncND(CApi.EngineSyncFunc sync_func, IntPtr func_param, CApi.EngineFuncParamDeleter deleter, IntPtr ctx_handle, IntPtr[] _nds_handle, IntPtr[] mutable_nds_handle, IntPtr prop_handle, int priority, string opr_name)
		{
			Helper.throwOnError("MXEnginePushSyncND", CApi.MXEnginePushSyncND(sync_func, func_param, deleter, ctx_handle, _nds_handle, Helper.length(_nds_handle), mutable_nds_handle, Helper.length(mutable_nds_handle), prop_handle, priority, opr_name));
		}
	}
}
