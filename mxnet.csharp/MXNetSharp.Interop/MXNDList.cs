using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class MXNDList
	{
		[Serializable]
		internal sealed class create_00401726_002D1 : FSharpFunc<int, uint>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal create_00401726_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override uint Invoke(int i)
			{
				return (uint)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(uint))), typeof(uint));
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public unsafe static uint[] create(string nd_file_bytes, int nd_file_size)
		{
			IntPtr @out = (IntPtr)(void*)0L;
			uint out_length = Helper.un<uint>();
			Helper.throwOnError("MXNDListCreate", CPredictApi.MXNDListCreate(nd_file_bytes, nd_file_size, out @out, out out_length));
			uint num = out_length;
			IntPtr ptr = @out;
			int num2 = (int)num;
			FSharpFunc<int, uint> val = new create_00401726_002D1(ptr);
			if (num2 < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num2
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			uint[] array = new uint[num2];
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
		public static void get(IntPtr handle, uint index)
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			string text = "not implemented";
			if (false)
			{
				_ = (Unit)(object)null;
				IntPtr out_key = Helper.un<IntPtr>();
				IntPtr out_data = Helper.un<IntPtr>();
				IntPtr out_shape = Helper.un<IntPtr>();
				uint out_ndim = Helper.un<uint>();
				Helper.throwOnError("MXNDListGet", CPredictApi.MXNDListGet(handle, index, out out_key, out out_data, out out_shape, out out_ndim));
				return;
			}
			throw Operators.Failure(text);
		}

		public static void free(IntPtr handle)
		{
			Helper.throwOnError("MXNDListFree", CPredictApi.MXNDListFree(handle));
		}
	}
}
