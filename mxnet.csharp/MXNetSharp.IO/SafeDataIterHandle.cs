using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp.IO
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SafeDataIterHandle : SafeHandle
	{
		internal int init_004042_002D15;

		public unsafe override bool IsInvalid
		{
			get
			{
				if (init_004042_002D15 < 1)
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
				if (init_004042_002D15 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				if (!IsClosed)
				{
					return handle;
				}
				ObjectDisposedException ex = new ObjectDisposedException("SafeDataIterHandle", "DataIter handle has been closed");
				ObjectDisposedException ex2 = ex;
				throw ex2;
			}
		}

		public unsafe SafeDataIterHandle(bool owner)
			: base((IntPtr)(void*)0L, ownsHandle: true)
		{
			init_004042_002D15 = 1;
		}

		public SafeDataIterHandle()
			: this(owner: true)
		{
			init_004042_002D15 = 1;
		}

		public SafeDataIterHandle(IntPtr ptr, bool owner)
		{
			FSharpRef<SafeDataIterHandle> @this = new FSharpRef<SafeDataIterHandle>((SafeDataIterHandle)null);
			this._002Ector(owner);
			@this.set_contents(this);
			init_004042_002D15 = 1;
			IntrinsicFunctions.CheckThis<SafeDataIterHandle>(@this.get_contents()).SetHandle(ptr);
		}

		public override bool ReleaseHandle()
		{
			if (init_004042_002D15 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			return CApi.MXNDArrayFree(handle) == 0;
		}
	}
}
