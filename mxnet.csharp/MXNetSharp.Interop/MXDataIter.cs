#define DEBUG
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
	public static class MXDataIter
	{
		[Serializable]
		internal sealed class list_00402106 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal list_00402106(IntPtr ptr)
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
		internal sealed class getInfo_00402141 : GeneratedSequenceBase<ArgumentInfo>
		{
			public FSharpRef<uint> num_args = num_args;

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

			public getInfo_00402141(FSharpRef<uint> num_args, FSharpRef<IntPtr> arg_names, FSharpRef<IntPtr> arg_type_infos, FSharpRef<IntPtr> arg_descriptions, IEnumerator<int> @enum, int pc, ArgumentInfo current)
			{
			}

			public override int GenerateNext(ref IEnumerable<ArgumentInfo> next)
			{
				switch (pc)
				{
				default:
					@enum = OperatorIntrinsics.RangeInt32(0, 1, (int)(num_args.get_contents() - 1)).GetEnumerator();
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
				return (IEnumerator<ArgumentInfo>)(object)new getInfo_00402141(num_args, arg_names, arg_type_infos, arg_descriptions, null, 0, null);
			}
		}

		[Serializable]
		internal sealed class getIndex_00402187 : FSharpFunc<int, ulong>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal getIndex_00402187(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override ulong Invoke(int i)
			{
				return (ulong)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(ulong))), typeof(ulong));
			}
		}

		public static IntPtr[] list()
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_array = Helper.un<IntPtr>();
			Helper.throwOnError("MXListDataIters", CApi.MXListDataIters(out out_size, out out_array));
			uint num = out_size;
			IntPtr ptr = out_array;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new list_00402106(ptr);
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
			1,
			1
		})]
		public static IntPtr create(IntPtr handle, string[] keys, string[] vals)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Debug.Assert(Helper.length(keys) == Helper.length(vals));
			Helper.throwOnError("MXDataIterCreateIter", CApi.MXDataIterCreateIter(handle, Helper.ulength(keys), keys, vals, out @out));
			return @out;
		}

		public static DataIterInfo getInfo(IntPtr creator)
		{
			IntPtr name = Helper.un<IntPtr>();
			IntPtr description = Helper.un<IntPtr>();
			FSharpRef<uint> num_args = new FSharpRef<uint>(Helper.un<uint>());
			FSharpRef<IntPtr> arg_names = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			FSharpRef<IntPtr> arg_type_infos = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			FSharpRef<IntPtr> arg_descriptions = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			Helper.throwOnError("MXDataIterGetIterInfo", CApi.MXDataIterGetIterInfo(creator, out name, out description, out num_args.contents_0040, out arg_names.contents_0040, out arg_type_infos.contents_0040, out arg_descriptions.contents_0040));
			return new DataIterInfo(Helper.str(name), Helper.str(description), SeqModule.ToArray<ArgumentInfo>((IEnumerable<ArgumentInfo>)(object)new getInfo_00402141(num_args, arg_names, arg_type_infos, arg_descriptions, null, 0, null)));
		}

		public static void free(IntPtr handle)
		{
			Helper.throwOnError("MXDataIterFree", CApi.MXDataIterFree(handle));
		}

		public static int next(IntPtr handle)
		{
			int @out = Helper.un<int>();
			Helper.throwOnError("MXDataIterNext", CApi.MXDataIterNext(handle, out @out));
			return @out;
		}

		public static void beforeFirst(IntPtr handle)
		{
			Helper.throwOnError("MXDataIterBeforeFirst", CApi.MXDataIterBeforeFirst(handle));
		}

		public static IntPtr getData(IntPtr handle)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXDataIterGetData", CApi.MXDataIterGetData(handle, out @out));
			return @out;
		}

		public static ulong[] getIndex(IntPtr handle)
		{
			IntPtr out_index = Helper.un<IntPtr>();
			ulong out_size = Helper.un<ulong>();
			Helper.throwOnError("MXDataIterGetIndex", CApi.MXDataIterGetIndex(handle, out out_index, out out_size));
			ulong num = out_size;
			IntPtr ptr = out_index;
			int num2 = (int)num;
			FSharpFunc<int, ulong> val = new getIndex_00402187(ptr);
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
			ulong[] array = new ulong[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		public static a getPadNum<a>(IntPtr handle)
		{
			int pad = Helper.un<int>();
			Helper.throwOnError("MXDataIterGetPadNum", CApi.MXDataIterGetPadNum(handle, out pad));
			return Helper.un<a>();
		}

		public static IntPtr getLabel(IntPtr handle)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXDataIterGetLabel", CApi.MXDataIterGetLabel(handle, out @out));
			return @out;
		}
	}
}
