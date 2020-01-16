using Microsoft.FSharp.Core;
using System;
using System.Runtime.InteropServices;

namespace MXNetSharp.Operator
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SafeHGlobal : SafeHandle
	{
		internal int init_0040111_002D12;

		public unsafe override bool IsInvalid
		{
			get
			{
				if (init_0040111_002D12 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return (long)handle <= (long)(IntPtr)(void*)0L;
			}
		}

		internal IntPtr Pointer
		{
			get
			{
				if (init_0040111_002D12 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				if (!IsClosed)
				{
					return handle;
				}
				ObjectDisposedException ex = new ObjectDisposedException("SafeHGlobal", "HGlobal ptr has been freed");
				ObjectDisposedException ex2 = ex;
				throw ex2;
			}
		}

		internal unsafe SafeHGlobal()
			: base((IntPtr)(void*)0L, ownsHandle: true)
		{
			init_0040111_002D12 = 1;
		}

		public SafeHGlobal(int sz)
		{
			FSharpRef<SafeHGlobal> @this = new FSharpRef<SafeHGlobal>((SafeHGlobal)null);
			this._002Ector();
			@this.set_contents(this);
			init_0040111_002D12 = 1;
			IntrinsicFunctions.CheckThis<SafeHGlobal>(@this.get_contents()).SetHandle(Marshal.AllocHGlobal(sz));
		}

		public static SafeHGlobal AnsiString(string str)
		{
			SafeHGlobal s = new SafeHGlobal();
			s.SetHandle(Marshal.StringToHGlobalAnsi(str));
			return s;
		}

		public override bool ReleaseHandle()
		{
			if (init_0040111_002D12 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			Marshal.FreeHGlobal(handle);
			return true;
		}
	}
}
