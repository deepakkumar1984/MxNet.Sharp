using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Core.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class NNVM
	{
		[Serializable]
		internal sealed class listAllOpNames_00401772_002D1 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listAllOpNames_00401772_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class listUniqueOps_00401793 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listUniqueOps_00401793(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class getOpInfo_00401821 : GeneratedSequenceBase<ArgumentInfo>
		{
			public FSharpRef<uint> num_doc_args = num_doc_args;

			public FSharpRef<IntPtr> arg_names = arg_names;

			public FSharpRef<IntPtr> arg_type_infos = arg_type_infos;

			public FSharpRef<IntPtr> arg_descriptions = arg_descriptions;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<int> @enum = @enum;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int pc = pc;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public ArgumentInfo current = current;

			public getOpInfo_00401821(FSharpRef<uint> num_doc_args, FSharpRef<IntPtr> arg_names, FSharpRef<IntPtr> arg_type_infos, FSharpRef<IntPtr> arg_descriptions, IEnumerator<int> @enum, int pc, ArgumentInfo current)
			{
			}

			public override int GenerateNext(ref IEnumerable<ArgumentInfo> next)
			{
				switch (pc)
				{
				default:
					@enum = OperatorIntrinsics.RangeInt32(0, 1, (int)(num_doc_args.get_contents() - 1)).GetEnumerator();
					pc = 1;
					goto case 2;
				case 2:
					if (@enum.MoveNext())
					{
						int i = @enum.Current;
						pc = 2;
						current = new ArgumentInfo(Helper.readString(i, arg_names.get_contents()), Helper.readString(i, arg_descriptions.get_contents()), Helper.readString(i, arg_type_infos.get_contents()));
						return 1;
					}
					goto case 1;
				case 1:
					pc = 3;
					IntrinsicFunctions.Dispose<IEnumerator<int>>(@enum);
					@enum = null;
					pc = 3;
					break;
				case 3:
					break;
				}
				current = null;
				return 0;
			}

			public override void Close()
			{
				Exception ex = default(Exception);
				while (true)
				{
					switch (pc)
					{
					default:
						try
						{
							switch (pc)
							{
							default:
								pc = 3;
								IntrinsicFunctions.Dispose<IEnumerator<int>>(@enum);
								break;
							case 0:
							case 3:
								break;
							}
							pc = 3;
							current = null;
							Unit val = null;
						}
						catch (object obj)
						{
							Exception e = (Exception)obj;
							ex = e;
							Unit val = null;
						}
						break;
					case 3:
						if (ex == null)
						{
							return;
						}
						throw ex;
					}
				}
			}

			public override bool get_CheckClose()
			{
				switch (pc)
				{
				default:
					return true;
				case 1:
					return true;
				case 0:
				case 3:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override ArgumentInfo get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<ArgumentInfo> GetFreshEnumerator()
			{
				return (IEnumerator<ArgumentInfo>)(object)new getOpInfo_00401821(num_doc_args, arg_names, arg_type_infos, arg_descriptions, null, 0, null);
			}
		}

		public static void apiSetLastError(string msg)
		{
			CNNVMApi.NNAPISetLastError(msg);
		}

		public static string[] listAllOpNames()
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_array = Helper.un<IntPtr>();
			Helper.throwOnError("NNListAllOpNames", CNNVMApi.NNListAllOpNames(out out_size, out out_array));
			uint num = out_size;
			IntPtr ptr = out_array;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listAllOpNames_00401772_002D1(ptr);
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

		public static IntPtr getOpHandle(string op_name)
		{
			IntPtr op_out = Helper.un<IntPtr>();
			Helper.throwOnError("NNGetOpHandle", CNNVMApi.NNGetOpHandle(op_name, out op_out));
			return op_out;
		}

		public static IntPtr[] listUniqueOps()
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_array = Helper.un<IntPtr>();
			Helper.throwOnError("NNListUniqueOps", CNNVMApi.NNListUniqueOps(out out_size, out out_array));
			uint num = out_size;
			IntPtr ptr = out_array;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new listUniqueOps_00401793(ptr);
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

		public static AtomicSymbolInfo getOpInfo(IntPtr op)
		{
			IntPtr real_name = Helper.un<IntPtr>();
			IntPtr description = Helper.un<IntPtr>();
			FSharpRef<uint> num_doc_args = new FSharpRef<uint>(Helper.un<uint>());
			FSharpRef<IntPtr> arg_names = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			FSharpRef<IntPtr> arg_type_infos = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			FSharpRef<IntPtr> arg_descriptions = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			IntPtr return_type = Helper.un<IntPtr>();
			Helper.throwOnError("NNGetOpInfo", CNNVMApi.NNGetOpInfo(op, out real_name, out description, out num_doc_args.contents_0040, out arg_names.contents_0040, out arg_type_infos.contents_0040, out arg_descriptions.contents_0040, out return_type));
			return new AtomicSymbolInfo(Helper.str(real_name), Helper.str(description), SeqModule.ToArray<ArgumentInfo>((IEnumerable<ArgumentInfo>)(object)new getOpInfo_00401821(num_doc_args, arg_names, arg_type_infos, arg_descriptions, null, 0, null)), Helper.str(return_type), "");
		}
	}
}
