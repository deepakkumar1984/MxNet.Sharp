using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class NNSymbol
	{
		[Serializable]
		internal sealed class listAttrs_00401934 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listAttrs_00401934(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class listInputVariables_00401949 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listInputVariables_00401949(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class listInputNames_00401964 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listInputNames_00401964(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class listOutputNames_00401975 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listOutputNames_00401975(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static IntPtr createAtomicSymbol(IntPtr op, string[] keys, string[] vals)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolCreateAtomicSymbol", CNNVMApi.NNSymbolCreateAtomicSymbol(op, Helper.ulength(keys), keys, vals, out @out));
			return @out;
		}

		public static IntPtr createVariable(string name)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolCreateVariable", CNNVMApi.NNSymbolCreateVariable(name, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr createGroup(uint num_symbols, IntPtr[] symbols)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolCreateGroup", CNNVMApi.NNSymbolCreateGroup(num_symbols, symbols, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void addControlDeps(IntPtr handle, IntPtr src_dep)
		{
			Helper.throwOnError("NNAddControlDeps", CNNVMApi.NNAddControlDeps(handle, src_dep));
		}

		public static void free(IntPtr symbol)
		{
			Helper.throwOnError("NNSymbolFree", CNNVMApi.NNSymbolFree(symbol));
		}

		public static void copy(IntPtr symbol)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolCopy", CNNVMApi.NNSymbolCopy(symbol, out @out));
		}

		public static void print(IntPtr symbol)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolPrint", CNNVMApi.NNSymbolPrint(symbol, out @out));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public unsafe static FSharpOption<string> getAttr(IntPtr symbol, string key)
		{
			IntPtr @out = Helper.un<IntPtr>();
			int success = Helper.un<int>();
			Helper.throwOnError("NNSymbolGetAttr", CNNVMApi.NNSymbolGetAttr(symbol, key, out @out, out success));
			if (success == 0 || (long)@out <= (long)(IntPtr)(void*)0L)
			{
				return null;
			}
			return FSharpOption<string>.Some(Helper.str(@out));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void setAttrs(IntPtr symbol, uint num_param, string[] keys, string[] values)
		{
			Helper.throwOnError("NNSymbolSetAttrs", CNNVMApi.NNSymbolSetAttrs(symbol, num_param, keys, values));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static string[] listAttrs(IntPtr symbol, int recursive_option)
		{
			uint out_size = Helper.un<uint>();
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolListAttrs", CNNVMApi.NNSymbolListAttrs(symbol, recursive_option, out out_size, out @out));
			uint num = out_size;
			IntPtr ptr = @out;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listAttrs_00401934(ptr);
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
			string[] array = new string[num2];
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
		public static IntPtr[] listInputVariables(IntPtr symbol, int option)
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_sym_array = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolListInputVariables", CNNVMApi.NNSymbolListInputVariables(symbol, option, out out_size, out out_sym_array));
			uint num = out_size;
			IntPtr ptr = out_sym_array;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new listInputVariables_00401949(ptr);
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
			IntPtr[] array = new IntPtr[num2];
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
		public static string[] listInputNames(IntPtr symbol, int option)
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_sym_array = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolListInputNames", CNNVMApi.NNSymbolListInputNames(symbol, option, out out_size, out out_sym_array));
			uint num = out_size;
			IntPtr ptr = out_sym_array;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listInputNames_00401964(ptr);
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
			string[] array = new string[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		public static string[] listOutputNames(IntPtr symbol)
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_str_array = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolListOutputNames", CNNVMApi.NNSymbolListOutputNames(symbol, out out_size, out out_str_array));
			uint num = out_size;
			IntPtr ptr = out_str_array;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listOutputNames_00401975(ptr);
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
			string[] array = new string[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		public static uint getNumOutputs(IntPtr symbol)
		{
			uint output_count = Helper.un<uint>();
			Helper.throwOnError("NNSymbolGetNumOutputs", CNNVMApi.NNSymbolGetNumOutputs(symbol, out output_count));
			return output_count;
		}

		public static IntPtr getInternals(IntPtr symbol)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolGetInternals", CNNVMApi.NNSymbolGetInternals(symbol, out @out));
			return @out;
		}

		public static IntPtr getChildren(IntPtr symbol)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolGetChildren", CNNVMApi.NNSymbolGetChildren(symbol, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr getOutput(IntPtr symbol, uint index)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("NNSymbolGetOutput", CNNVMApi.NNSymbolGetOutput(symbol, index, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void compose(IntPtr sym, string name, string[] keys, IntPtr[] args)
		{
			Helper.throwOnError("NNSymbolCompose", CNNVMApi.NNSymbolCompose(sym, name, Helper.ulength(args), keys, args));
		}
	}
}
