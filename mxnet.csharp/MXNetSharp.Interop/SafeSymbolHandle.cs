using Microsoft.FSharp.Core;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SafeSymbolHandle : SafeHandle
	{
		internal int init_004036;

		public unsafe override bool IsInvalid
		{
			get
			{
				if (init_004036 < 1)
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
				if (init_004036 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				if (!IsClosed)
				{
					return handle;
				}
				ObjectDisposedException ex = new ObjectDisposedException("SafeSymbolHandle", "Symbol handle has been closed");
				ObjectDisposedException ex2 = ex;
				throw ex2;
			}
		}

		public unsafe SafeSymbolHandle(bool owner)
			: base((IntPtr)(void*)0L, ownsHandle: true)
		{
			init_004036 = 1;
		}

		public SafeSymbolHandle()
			: this(owner: true)
		{
			init_004036 = 1;
		}

		public SafeSymbolHandle(IntPtr ptr, bool owner)
		{
			FSharpRef<SafeSymbolHandle> @this = new FSharpRef<SafeSymbolHandle>((SafeSymbolHandle)null);
			this._002Ector(owner);
			@this.set_contents(this);
			init_004036 = 1;
			IntrinsicFunctions.CheckThis<SafeSymbolHandle>(@this.get_contents()).SetHandle(ptr);
		}

		public override bool ReleaseHandle()
		{
			if (init_004036 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			return CApi.MXSymbolFree(handle) == 0;
		}
	}
}
