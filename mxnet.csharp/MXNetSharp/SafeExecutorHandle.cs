using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SafeExecutorHandle : SafeHandle
	{
		internal int init_0040420_002D19;

		public unsafe override bool IsInvalid
		{
			get
			{
				if (init_0040420_002D19 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return (long)handle <= (long)(IntPtr)(void*)0L;
			}
		}

		public IntPtr UnsafeHandle
		{
			get
			{
				if (init_0040420_002D19 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				if (!IsClosed)
				{
					return handle;
				}
				ObjectDisposedException ex = new ObjectDisposedException("SafeExecutorHandle", "Executor handle has been closed");
				ObjectDisposedException ex2 = ex;
				throw ex2;
			}
		}

		public unsafe SafeExecutorHandle(bool owner)
			: base((IntPtr)(void*)0L, ownsHandle: true)
		{
			init_0040420_002D19 = 1;
		}

		public SafeExecutorHandle()
			: this(owner: true)
		{
			init_0040420_002D19 = 1;
		}

		public SafeExecutorHandle(IntPtr ptr, bool owner)
		{
			FSharpRef<SafeExecutorHandle> @this = new FSharpRef<SafeExecutorHandle>((SafeExecutorHandle)null);
			this._002Ector(owner);
			@this.set_contents(this);
			init_0040420_002D19 = 1;
			IntrinsicFunctions.CheckThis<SafeExecutorHandle>(@this.get_contents()).SetHandle(ptr);
		}

		public override bool ReleaseHandle()
		{
			if (init_0040420_002D19 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			return CApi.MXExecutorFree(handle) == 0;
		}
	}
}
