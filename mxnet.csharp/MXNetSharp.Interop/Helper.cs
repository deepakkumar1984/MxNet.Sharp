using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class Helper
	{
		[Serializable]
		internal sealed class readStringArray_0040175 : FSharpFunc<int, string>
		{
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readStringArray_0040175(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class readPtrArray_0040176 : FSharpFunc<int, IntPtr>
		{
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readPtrArray_0040176(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override IntPtr Invoke(int i)
			{
				return readIntPtr(i, ptr);
			}
		}

		[Serializable]
		internal sealed class readStructArray_0040177<a> : FSharpFunc<int, a>
		{
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readStructArray_0040177(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override a Invoke(int i)
			{
				return IntrinsicFunctions.UnboxGeneric<a>(Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(a))), typeof(a)));
			}
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static int intPtrSz => _0024Interop.intPtrSz_0040162;

		public static int length<a>(a[] a)
		{
			if (a == null)
			{
				return 0;
			}
			return a.Length;
		}

		public static uint ulength<a>(a[] a)
		{
			return (uint)length(a);
		}

		public static int boolToInt(bool b)
		{
			if (b)
			{
				return 1;
			}
			return 0;
		}

		public static a un<a>()
		{
			a result = default(a);
			return result;
		}

		public static string str(IntPtr x)
		{
			if (x == IntPtr.Zero)
			{
				return "";
			}
			return Marshal.PtrToStringAnsi(x);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr readIntPtr(int index, IntPtr ptr)
		{
			return Marshal.ReadIntPtr(ptr, index * intPtrSz);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static string readString(int index, IntPtr ptr)
		{
			return Marshal.PtrToStringAnsi(readIntPtr(index, ptr));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static byte[] readByteArray(int size, IntPtr ptr)
		{
			byte[] b = ArrayModule.ZeroCreate<byte>(size);
			Marshal.Copy(ptr, b, 0, size);
			return b;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static string[] readStringArray<a>(a size, IntPtr ptr)
		{
			if (0 == 0)
			{
				throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
			}
			int num = (int)(object)null;
			FSharpFunc<int, string> val = new readStringArray_0040175(ptr);
			if (num < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			string[] array = new string[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr[] readPtrArray<a>(a size, IntPtr ptr)
		{
			if (0 == 0)
			{
				throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
			}
			int num = (int)(object)null;
			FSharpFunc<int, IntPtr> val = new readPtrArray_0040176(ptr);
			if (num < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			IntPtr[] array = new IntPtr[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static a[] readStructArray<a, a>(a size, IntPtr ptr)
		{
			if (0 == 0)
			{
				throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
			}
			int num = (int)(object)null;
			FSharpFunc<int, a> val = new readStructArray_0040177<a>(ptr);
			if (num < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			a[] array = new a[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void throwOnError(string call, int returnCode)
		{
			if (returnCode == 0)
			{
				return;
			}
			IntPtr ptr = CApi.MXGetLastError();
			string errorMesseage = str(ptr);
			throw new MXNetException(call, errorMesseage);
		}
	}
}
