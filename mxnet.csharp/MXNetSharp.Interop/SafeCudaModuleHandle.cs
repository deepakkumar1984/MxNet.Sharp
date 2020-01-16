using Microsoft.FSharp.Core;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SafeCudaModuleHandle : SafeHandle
	{
		internal int init_004060_002D2;

		public unsafe override bool IsInvalid
		{
			get
			{
				if (init_004060_002D2 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return (long)handle <= (long)(IntPtr)(void*)0L;
			}
		}

		internal IntPtr UnsafeHandle
		{
			get
			{
				if (init_004060_002D2 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				if (!IsClosed)
				{
					return handle;
				}
				ObjectDisposedException ex = new ObjectDisposedException("SafeCudaModuleHandle", "NDArray handle has been closed");
				ObjectDisposedException ex2 = ex;
				throw ex2;
			}
		}

		public unsafe SafeCudaModuleHandle(bool owner)
			: base((IntPtr)(void*)0L, ownsHandle: true)
		{
			init_004060_002D2 = 1;
		}

		public SafeCudaModuleHandle()
			: this(owner: true)
		{
			init_004060_002D2 = 1;
		}

		public SafeCudaModuleHandle(IntPtr ptr, bool owner)
		{
			FSharpRef<SafeCudaModuleHandle> @this = new FSharpRef<SafeCudaModuleHandle>((SafeCudaModuleHandle)null);
			this._002Ector(owner);
			@this.set_contents(this);
			init_004060_002D2 = 1;
			IntrinsicFunctions.CheckThis<SafeCudaModuleHandle>(@this.get_contents()).SetHandle(ptr);
		}

		public override bool ReleaseHandle()
		{
			if (init_004060_002D2 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			return CApi.MXRtcCudaModuleFree(handle) == 0;
		}
	}
}
