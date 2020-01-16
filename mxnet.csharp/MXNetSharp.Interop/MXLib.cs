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
	public static class MXLib
	{
		[Serializable]
		internal sealed class infoFeatures_0040208 : FSharpFunc<int, LibFeature>
		{
			public FSharpRef<IntPtr> a;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal infoFeatures_0040208(FSharpRef<IntPtr> a)
			{
				this.a = a;
			}

			public unsafe override LibFeature Invoke(int i)
			{
				return (LibFeature)Marshal.PtrToStructure((IntPtr)(void*)((long)a.get_contents() + (long)new IntPtr(i * sizeof(LibFeature))), typeof(LibFeature));
			}
		}

		[Serializable]
		internal sealed class listFunctions_0040246 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listFunctions_0040246(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override IntPtr Invoke(int i)
			{
				return Helper.readIntPtr(i, ptr);
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class funcGetInfo_0040264 : GeneratedSequenceBase<ArgumentInfo>
		{
			public FSharpRef<uint> numArgs = numArgs;

			public FSharpRef<IntPtr> argNames = argNames;

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

			public funcGetInfo_0040264(FSharpRef<uint> numArgs, FSharpRef<IntPtr> argNames, FSharpRef<IntPtr> arg_type_infos, FSharpRef<IntPtr> arg_descriptions, IEnumerator<int> @enum, int pc, ArgumentInfo current)
			{
			}

			public override int GenerateNext(ref IEnumerable<ArgumentInfo> next)
			{
				switch (pc)
				{
				default:
					@enum = OperatorIntrinsics.RangeInt32(0, 1, (int)(numArgs.get_contents() - 1)).GetEnumerator();
					pc = 1;
					goto case 2;
				case 2:
					if (@enum.MoveNext())
					{
						int i = @enum.Current;
						pc = 2;
						current = new ArgumentInfo(Helper.readString(i, argNames.get_contents()), Helper.readString(i, arg_descriptions.get_contents()), Helper.readString(i, arg_type_infos.get_contents()));
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
				return (IEnumerator<ArgumentInfo>)(object)new funcGetInfo_0040264(numArgs, argNames, arg_type_infos, arg_descriptions, null, 0, null);
			}
		}

		[Serializable]
		internal sealed class listAllOpNames_0040279 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listAllOpNames_0040279(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		public static string getLastError()
		{
			return Helper.str(CApi.MXGetLastError());
		}

		public static void loadLib(string path)
		{
			Helper.throwOnError("MXLoadLib", CApi.MXLoadLib(path));
		}

		public static LibFeature[] infoFeatures()
		{
			FSharpRef<IntPtr> a = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			int sz = Helper.un<int>();
			Helper.throwOnError("MXLibInfoFeatures", CApi.MXLibInfoFeatures(out a.contents_0040, out sz));
			int num = sz;
			FSharpFunc<int, LibFeature> val = new infoFeatures_0040208(a);
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
			LibFeature[] array = new LibFeature[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			return array;
		}

		public static void randomSeed(int seed)
		{
			Helper.throwOnError("MXRandomSeed", CApi.MXRandomSeed(seed));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void randomSeedContext(int seed, int dev_type, int dev_id)
		{
			Helper.throwOnError("MXRandomSeedContext", CApi.MXRandomSeedContext(seed, dev_type, dev_id));
		}

		public static void notifyShutdown()
		{
			Helper.throwOnError("MXNotifyShutdown", CApi.MXNotifyShutdown());
		}

		public static int getGpuCount()
		{
			int @out = Helper.un<int>();
			Helper.throwOnError("MXGetGPUCount", CApi.MXGetGPUCount(out @out));
			return @out;
		}

		public static int getVersion()
		{
			int @out = Helper.un<int>();
			Helper.throwOnError("MXGetVersion", CApi.MXGetVersion(out @out));
			return @out;
		}

		public static IntPtr[] listFunctions()
		{
			uint outSize = Helper.un<uint>();
			IntPtr outArray = Helper.un<IntPtr>();
			Helper.throwOnError("MXListFunctions", CApi.MXListFunctions(out outSize, out outArray));
			uint num = outSize;
			IntPtr ptr = outArray;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new listFunctions_0040246(ptr);
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

		public static FunctionInfo funcGetInfo(IntPtr functionHandle)
		{
			IntPtr name = Helper.un<IntPtr>();
			IntPtr description = Helper.un<IntPtr>();
			FSharpRef<uint> numArgs = new FSharpRef<uint>(Helper.un<uint>());
			FSharpRef<IntPtr> argNames = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			FSharpRef<IntPtr> arg_type_infos = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			FSharpRef<IntPtr> arg_descriptions = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			IntPtr return_type = Helper.un<IntPtr>();
			Helper.throwOnError("MXFuncGetInfo", CApi.MXFuncGetInfo(functionHandle, out name, out description, out numArgs.contents_0040, out argNames.contents_0040, out arg_type_infos.contents_0040, out arg_descriptions.contents_0040, out return_type));
			return new FunctionInfo(Helper.str(name), Helper.str(description), SeqModule.ToArray<ArgumentInfo>((IEnumerable<ArgumentInfo>)(object)new funcGetInfo_0040264(numArgs, argNames, arg_type_infos, arg_descriptions, null, 0, null)), Helper.str(return_type));
		}

		public static string[] listAllOpNames()
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_array = Helper.un<IntPtr>();
			Helper.throwOnError("MXListAllOpNames", CApi.MXListAllOpNames(ref out_size, ref out_array));
			uint num = out_size;
			IntPtr ptr = out_array;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listAllOpNames_0040279(ptr);
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
		public static void customOpRegister(string opType, CApi.CustomOpPropCreator creator)
		{
			Helper.throwOnError("MXCustomOpRegister", CApi.MXCustomOpRegister(opType, creator));
		}

		public static bool isNumpyShape()
		{
			bool curr = Helper.un<bool>();
			Helper.throwOnError("MXIsNumpyShape", CApi.MXIsNumpyShape(out curr));
			return curr;
		}

		public static bool setIsNumpyShape(bool is_np_shape)
		{
			int prev = Helper.un<int>();
			Helper.throwOnError("MXSetIsNumpyShape", CApi.MXSetIsNumpyShape(is_np_shape ? 1 : 0, out prev));
			return prev != 0;
		}
	}
}
