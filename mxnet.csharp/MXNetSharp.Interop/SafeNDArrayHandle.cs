using Microsoft.FSharp.Core;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SafeNDArrayHandle : SafeHandle
	{
		internal int init_004048_002D1;

		public unsafe override bool IsInvalid
		{
			get
			{
				if (init_004048_002D1 < 1)
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
				if (init_004048_002D1 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				if (!IsClosed)
				{
					return handle;
				}
				ObjectDisposedException ex = new ObjectDisposedException("SafeNDArrayHandle", "NDArray handle has been closed");
				ObjectDisposedException ex2 = ex;
				throw ex2;
			}
		}

		public unsafe SafeNDArrayHandle(bool owner)
			: base((IntPtr)(void*)0L, ownsHandle: true)
		{
			init_004048_002D1 = 1;
		}

		public SafeNDArrayHandle()
			: this(owner: true)
		{
			init_004048_002D1 = 1;
		}

		public SafeNDArrayHandle(IntPtr ptr, bool owner)
		{
			FSharpRef<SafeNDArrayHandle> @this = new FSharpRef<SafeNDArrayHandle>((SafeNDArrayHandle)null);
			this._002Ector(owner);
			@this.set_contents(this);
			init_004048_002D1 = 1;
			IntrinsicFunctions.CheckThis<SafeNDArrayHandle>(@this.get_contents()).SetHandle(ptr);
		}

		public override bool ReleaseHandle()
		{
			if (init_004048_002D1 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			return CApi.MXNDArrayFree(handle) == 0;
		}
	}
}
