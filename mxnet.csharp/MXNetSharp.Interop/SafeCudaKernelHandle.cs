using Microsoft.FSharp.Core;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SafeCudaKernelHandle : SafeHandle
	{
		internal int init_004072_002D3;

		public unsafe override bool IsInvalid
		{
			get
			{
				if (init_004072_002D3 < 1)
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
				if (init_004072_002D3 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				if (!IsClosed)
				{
					return handle;
				}
				ObjectDisposedException ex = new ObjectDisposedException("SafeCudaKernelHandle", "NDArray handle has been closed");
				ObjectDisposedException ex2 = ex;
				throw ex2;
			}
		}

		public unsafe SafeCudaKernelHandle(bool owner)
			: base((IntPtr)(void*)0L, ownsHandle: true)
		{
			init_004072_002D3 = 1;
		}

		public SafeCudaKernelHandle()
			: this(owner: true)
		{
			init_004072_002D3 = 1;
		}

		public SafeCudaKernelHandle(IntPtr ptr, bool owner)
		{
			FSharpRef<SafeCudaKernelHandle> @this = new FSharpRef<SafeCudaKernelHandle>((SafeCudaKernelHandle)null);
			this._002Ector(owner);
			@this.set_contents(this);
			init_004072_002D3 = 1;
			IntrinsicFunctions.CheckThis<SafeCudaKernelHandle>(@this.get_contents()).SetHandle(ptr);
		}

		public override bool ReleaseHandle()
		{
			if (init_004072_002D3 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			return CApi.MXRtcCudaKernelFree(handle) == 0;
		}
	}
}
