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
	public static class MXSymbol
	{
		[Serializable]
		internal sealed class listAtomicSymbolCreators_0040323 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listAtomicSymbolCreators_0040323(IntPtr ptr)
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
		internal sealed class getAtomicSymbolInfo_0040350 : GeneratedSequenceBase<ArgumentInfo>
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

			public getAtomicSymbolInfo_0040350(FSharpRef<uint> numArgs, FSharpRef<IntPtr> argNames, FSharpRef<IntPtr> arg_type_infos, FSharpRef<IntPtr> arg_descriptions, IEnumerator<int> @enum, int pc, ArgumentInfo current)
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
				return (IEnumerator<ArgumentInfo>)(object)new getAtomicSymbolInfo_0040350(numArgs, argNames, arg_type_infos, arg_descriptions, null, 0, null);
			}
		}

		[Serializable]
		internal sealed class getInputSymbols_0040419 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal getInputSymbols_0040419(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class cutSubgraph_0040431 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal cutSubgraph_0040431(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class listAttr_0040535 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listAttr_0040535(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class listAttrShallow_0040544 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listAttrShallow_0040544(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class listAttrShallow_0040546_002D1 : FSharpFunc<string[], Tuple<string, string>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listAttrShallow_0040546_002D1()
			{
			}

			public override Tuple<string, string> Invoke(string[] a)
			{
				return new Tuple<string, string>(a[0], a[1]);
			}
		}

		[Serializable]
		internal sealed class listArguments_0040554 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listArguments_0040554(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class listOutputs_0040562 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listOutputs_0040562(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class listAuxiliaryStates_0040603 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal listAuxiliaryStates_0040603(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class keys_0040620<a> : FSharpFunc<Tuple<string, a[]>, string>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal keys_0040620()
			{
			}

			public override string Invoke(Tuple<string, a[]> tupledArg)
			{
				return tupledArg.Item1;
			}
		}

		[Serializable]
		internal sealed class dims_0040651 : FSharpFunc<int, uint>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dims_0040651(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override uint Invoke(int i)
			{
				return (uint)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(uint))), typeof(uint));
			}
		}

		[Serializable]
		internal sealed class shapes_0040653_002D2 : FSharpFunc<int, uint>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040653_002D2(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override uint Invoke(int i)
			{
				return (uint)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(uint))), typeof(uint));
			}
		}

		[Serializable]
		internal sealed class shapes_0040653_002D1 : FSharpFunc<int, IntPtr, uint[]>
		{
			public uint[] dims;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040653_002D1(uint[] dims)
			{
				this.dims = dims;
			}

			public override uint[] Invoke(int i, IntPtr ptr)
			{
				uint num = dims[i];
				int num2 = (int)num;
				FSharpFunc<int, uint> val = new shapes_0040653_002D2(ptr);
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
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				return array;
			}
		}

		[Serializable]
		internal sealed class shapes_0040652_002D3 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040652_002D3(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override IntPtr Invoke(int i)
			{
				return Helper.readIntPtr(i, ptr);
			}
		}

		[Serializable]
		internal sealed class shapes_0040651 : FSharpFunc<uint, IntPtr, IntPtr, uint[][]>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040651()
			{
			}

			public override uint[][] Invoke(uint sz, IntPtr ndim, IntPtr data)
			{
				FSharpFunc<int, uint> val = new dims_0040651(ndim);
				if ((int)sz < 0)
				{
					object[] args = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						(int)sz
					};
					string message = string.Format("{0}\n{1} = {2}", args);
					throw new ArgumentException(message, "count");
				}
				uint[] array = new uint[sz];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				uint[] dims = array;
				shapes_0040653_002D1 shapes_0040653_002D = new shapes_0040653_002D1(dims);
				FSharpFunc<int, IntPtr> val2 = new shapes_0040652_002D3(data);
				if ((int)sz < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						(int)sz
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				IntPtr[] array2 = new IntPtr[sz];
				FSharpFunc<int, FSharpFunc<IntPtr, uint[]>> val3 = (FSharpFunc<int, FSharpFunc<IntPtr, uint[]>>)(object)shapes_0040653_002D;
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = val2.Invoke(j);
				}
				return ArrayModule.MapIndexed<IntPtr, uint[]>(val3, array2);
			}
		}

		[Serializable]
		internal sealed class dims_0040682_002D1 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dims_0040682_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class shapes_0040684_002D6 : FSharpFunc<int, long>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040684_002D6(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override long Invoke(int i)
			{
				return (long)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(long))), typeof(long));
			}
		}

		[Serializable]
		internal sealed class shapes_0040684_002D5 : FSharpFunc<int, IntPtr, long[]>
		{
			public int[] dims;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040684_002D5(int[] dims)
			{
				this.dims = dims;
			}

			public override long[] Invoke(int i, IntPtr ptr)
			{
				int num = dims[i];
				int num2 = num;
				FSharpFunc<int, long> val = new shapes_0040684_002D6(ptr);
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
				long[] array = new long[num2];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				return array;
			}
		}

		[Serializable]
		internal sealed class shapes_0040683_002D7 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040683_002D7(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override IntPtr Invoke(int i)
			{
				return Helper.readIntPtr(i, ptr);
			}
		}

		[Serializable]
		internal sealed class shapes_0040682_002D4 : FSharpFunc<long, IntPtr, IntPtr, long[][]>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040682_002D4()
			{
			}

			public override long[][] Invoke(long sz, IntPtr ndim, IntPtr data)
			{
				int num = (int)sz;
				FSharpFunc<int, int> val = new dims_0040682_002D1(ndim);
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
				int[] array = new int[num];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				int[] dims = array;
				shapes_0040684_002D5 shapes_0040684_002D = new shapes_0040684_002D5(dims);
				int num2 = (int)sz;
				FSharpFunc<int, IntPtr> val2 = new shapes_0040683_002D7(data);
				if (num2 < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num2
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				IntPtr[] array2 = new IntPtr[num2];
				FSharpFunc<int, FSharpFunc<IntPtr, long[]>> val3 = (FSharpFunc<int, FSharpFunc<IntPtr, long[]>>)(object)shapes_0040684_002D;
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = val2.Invoke(j);
				}
				return ArrayModule.MapIndexed<IntPtr, long[]>(val3, array2);
			}
		}

		[Serializable]
		internal sealed class dims_0040714_002D2 : FSharpFunc<int, uint>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dims_0040714_002D2(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override uint Invoke(int i)
			{
				return (uint)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(uint))), typeof(uint));
			}
		}

		[Serializable]
		internal sealed class shapes_0040716_002D10 : FSharpFunc<int, uint>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040716_002D10(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override uint Invoke(int i)
			{
				return (uint)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(uint))), typeof(uint));
			}
		}

		[Serializable]
		internal sealed class shapes_0040716_002D9 : FSharpFunc<int, IntPtr, uint[]>
		{
			public uint[] dims;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040716_002D9(uint[] dims)
			{
				this.dims = dims;
			}

			public override uint[] Invoke(int i, IntPtr ptr)
			{
				uint num = dims[i];
				int num2 = (int)num;
				FSharpFunc<int, uint> val = new shapes_0040716_002D10(ptr);
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
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				return array;
			}
		}

		[Serializable]
		internal sealed class shapes_0040715_002D11 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040715_002D11(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override IntPtr Invoke(int i)
			{
				return Helper.readIntPtr(i, ptr);
			}
		}

		[Serializable]
		internal sealed class shapes_0040714_002D8 : FSharpFunc<uint, IntPtr, IntPtr, uint[][]>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040714_002D8()
			{
			}

			public override uint[][] Invoke(uint sz, IntPtr ndim, IntPtr data)
			{
				FSharpFunc<int, uint> val = new dims_0040714_002D2(ndim);
				if ((int)sz < 0)
				{
					object[] args = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						(int)sz
					};
					string message = string.Format("{0}\n{1} = {2}", args);
					throw new ArgumentException(message, "count");
				}
				uint[] array = new uint[sz];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				uint[] dims = array;
				shapes_0040716_002D9 shapes_0040716_002D = new shapes_0040716_002D9(dims);
				FSharpFunc<int, IntPtr> val2 = new shapes_0040715_002D11(data);
				if ((int)sz < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						(int)sz
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				IntPtr[] array2 = new IntPtr[sz];
				FSharpFunc<int, FSharpFunc<IntPtr, uint[]>> val3 = (FSharpFunc<int, FSharpFunc<IntPtr, uint[]>>)(object)shapes_0040716_002D;
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = val2.Invoke(j);
				}
				return ArrayModule.MapIndexed<IntPtr, uint[]>(val3, array2);
			}
		}

		[Serializable]
		internal sealed class dims_0040746_002D3 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dims_0040746_002D3(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class shapes_0040748_002D14 : FSharpFunc<int, long>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040748_002D14(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override long Invoke(int i)
			{
				return (long)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(long))), typeof(long));
			}
		}

		[Serializable]
		internal sealed class shapes_0040748_002D13 : FSharpFunc<int, IntPtr, long[]>
		{
			public int[] dims;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040748_002D13(int[] dims)
			{
				this.dims = dims;
			}

			public override long[] Invoke(int i, IntPtr ptr)
			{
				int num = dims[i];
				int num2 = num;
				FSharpFunc<int, long> val = new shapes_0040748_002D14(ptr);
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
				long[] array = new long[num2];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				return array;
			}
		}

		[Serializable]
		internal sealed class shapes_0040747_002D15 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040747_002D15(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override IntPtr Invoke(int i)
			{
				return Helper.readIntPtr(i, ptr);
			}
		}

		[Serializable]
		internal sealed class shapes_0040746_002D12 : FSharpFunc<long, IntPtr, IntPtr, long[][]>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040746_002D12()
			{
			}

			public override long[][] Invoke(long sz, IntPtr ndim, IntPtr data)
			{
				int num = (int)sz;
				FSharpFunc<int, int> val = new dims_0040746_002D3(ndim);
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
				int[] array = new int[num];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				int[] dims = array;
				shapes_0040748_002D13 shapes_0040748_002D = new shapes_0040748_002D13(dims);
				int num2 = (int)sz;
				FSharpFunc<int, IntPtr> val2 = new shapes_0040747_002D15(data);
				if (num2 < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num2
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				IntPtr[] array2 = new IntPtr[num2];
				FSharpFunc<int, FSharpFunc<IntPtr, long[]>> val3 = (FSharpFunc<int, FSharpFunc<IntPtr, long[]>>)(object)shapes_0040748_002D;
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = val2.Invoke(j);
				}
				return ArrayModule.MapIndexed<IntPtr, long[]>(val3, array2);
			}
		}

		[Serializable]
		internal sealed class inferType_0040781 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal inferType_0040781(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class inferType_0040782_002D1 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal inferType_0040782_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class inferType_0040783_002D2 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal inferType_0040783_002D2(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class inferTypePartial_0040813 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal inferTypePartial_0040813(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class inferTypePartial_0040814_002D1 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal inferTypePartial_0040814_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class inferTypePartial_0040815_002D2 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal inferTypePartial_0040815_002D2(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		public static IntPtr[] listAtomicSymbolCreators()
		{
			uint outSize = Helper.un<uint>();
			IntPtr outArray = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolListAtomicSymbolCreators", CApi.MXSymbolListAtomicSymbolCreators(out outSize, out outArray));
			uint num = outSize;
			IntPtr ptr = outArray;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new listAtomicSymbolCreators_0040323(ptr);
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

		public static string getAtomicSymbolName(IntPtr creator)
		{
			IntPtr name = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolGetAtomicSymbolName", CApi.MXSymbolGetAtomicSymbolName(creator, out name));
			return Helper.str(name);
		}

		public static AtomicSymbolInfo getAtomicSymbolInfo(IntPtr creator)
		{
			IntPtr name = Helper.un<IntPtr>();
			IntPtr description = Helper.un<IntPtr>();
			FSharpRef<uint> numArgs = new FSharpRef<uint>(Helper.un<uint>());
			FSharpRef<IntPtr> argNames = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			FSharpRef<IntPtr> arg_type_infos = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			FSharpRef<IntPtr> arg_descriptions = new FSharpRef<IntPtr>(Helper.un<IntPtr>());
			IntPtr key_var_num_args = Helper.un<IntPtr>();
			IntPtr return_type = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolGetAtomicSymbolInfo", CApi.MXSymbolGetAtomicSymbolInfo(creator, out name, out description, out numArgs.contents_0040, out argNames.contents_0040, out arg_type_infos.contents_0040, out arg_descriptions.contents_0040, out key_var_num_args, out return_type));
			return new AtomicSymbolInfo(Helper.str(name), Helper.str(description), SeqModule.ToArray<ArgumentInfo>((IEnumerable<ArgumentInfo>)(object)new getAtomicSymbolInfo_0040350(numArgs, argNames, arg_type_infos, arg_descriptions, null, 0, null)), Helper.str(return_type), Helper.str(key_var_num_args));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static IntPtr createAtomicSymbol(IntPtr creator, string[] keys, string[] vals)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Debug.Assert(ArrayModule.Length<string>(keys) == ArrayModule.Length<string>(vals));
			Helper.throwOnError("MXSymbolCreateAtomicSymbol", CApi.MXSymbolCreateAtomicSymbol(creator, (uint)ArrayModule.Length<string>(keys), keys, vals, out @out));
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
			Debug.Assert(((keys == null) ? true : false) || Helper.ulength(keys) == Helper.ulength(args));
			int returnCode = CApi.MXSymbolCompose(sym, name, Helper.ulength(args), keys, args);
			Helper.throwOnError(ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("MXSymbolCompose(%s)")).Invoke(name), returnCode);
		}

		public static string saveToJSON(IntPtr symbol)
		{
			IntPtr out_json = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolSaveToJSON", CApi.MXSymbolSaveToJSON(symbol, out out_json));
			return Helper.str(out_json);
		}

		public static IntPtr createVariable(string name)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolCreateVariable", CApi.MXSymbolCreateVariable(name, out @out));
			return @out;
		}

		public static void free(IntPtr symbol)
		{
			Helper.throwOnError("MXSymbolFree", CApi.MXSymbolFree(symbol));
		}

		public static IntPtr genAtomicSymbolFromSymbol(IntPtr sym_handle)
		{
			IntPtr ret_sym_handle = Helper.un<IntPtr>();
			Helper.throwOnError("MXGenAtomicSymbolFromSymbol", CApi.MXGenAtomicSymbolFromSymbol(sym_handle, out ret_sym_handle));
			return ret_sym_handle;
		}

		public unsafe static IntPtr[] getInputSymbols(IntPtr sym)
		{
			int input_size = Helper.un<int>();
			IntPtr inputs = (IntPtr)(void*)0L;
			Helper.throwOnError("MXSymbolGetInputSymbols", CApi.MXSymbolGetInputSymbols(sym, out inputs, out input_size));
			int num = input_size;
			IntPtr ptr = inputs;
			int num2 = num;
			FSharpFunc<int, IntPtr> val = new getInputSymbols_0040419(ptr);
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

		public unsafe static IntPtr[] cutSubgraph(IntPtr sym)
		{
			int input_size = Helper.un<int>();
			IntPtr inputs = (IntPtr)(void*)0L;
			Helper.throwOnError("MXSymbolCutSubgraph", CApi.MXSymbolCutSubgraph(sym, out inputs, out input_size));
			int num = input_size;
			IntPtr ptr = inputs;
			int num2 = num;
			FSharpFunc<int, IntPtr> val = new cutSubgraph_0040431(ptr);
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

		public static IntPtr createGroup(IntPtr[] symbols)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolCreateGroup", CApi.MXSymbolCreateGroup(Helper.ulength(symbols), symbols, out @out));
			return @out;
		}

		public static IntPtr createFromFile(string fname)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolCreateFromFile", CApi.MXSymbolCreateFromFile(fname, out @out));
			return @out;
		}

		public static IntPtr createFromJSON(string json)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolCreateFromJSON", CApi.MXSymbolCreateFromJSON(json, out @out));
			return @out;
		}

		public unsafe static IntPtr removeAmpCast(IntPtr sym_handle)
		{
			IntPtr ret_sym_handle = (IntPtr)(void*)0L;
			Helper.throwOnError("MXSymbolRemoveAmpCast", CApi.MXSymbolRemoveAmpCast(sym_handle, out ret_sym_handle));
			return ret_sym_handle;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void saveToFile(IntPtr symbol, string fname)
		{
			Helper.throwOnError("MXSymbolSaveToFile", CApi.MXSymbolSaveToFile(symbol, fname));
		}

		public static IntPtr copy(IntPtr symbol)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolCopy", CApi.MXSymbolCopy(symbol, out @out));
			return @out;
		}

		public static string print(IntPtr symbol)
		{
			IntPtr out_str = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolPrint", CApi.MXSymbolPrint(symbol, out out_str));
			return Helper.str(out_str);
		}

		public static FSharpOption<string> getName(IntPtr symbol)
		{
			IntPtr @out = Helper.un<IntPtr>();
			int success = Helper.un<int>();
			Helper.throwOnError("MXSymbolGetName", CApi.MXSymbolGetName(symbol, out @out, out success));
			if (success == 0)
			{
				return null;
			}
			return FSharpOption<string>.Some(Helper.str(@out));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static FSharpOption<string> getAttr(IntPtr symbol, string key)
		{
			IntPtr @out = Helper.un<IntPtr>();
			int success = Helper.un<int>();
			Helper.throwOnError("MXSymbolGetAttr", CApi.MXSymbolGetAttr(symbol, key, out @out, out success));
			if (success == 0)
			{
				return null;
			}
			return FSharpOption<string>.Some(Helper.str(@out));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void setAttr(IntPtr symbol, string key, string value)
		{
			Helper.throwOnError("MXSymbolSetAttr", CApi.MXSymbolSetAttr(symbol, key, value));
		}

		public static string[] listAttr(IntPtr symbol)
		{
			uint out_size = Helper.un<uint>();
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolListAttr", CApi.MXSymbolListAttr(symbol, out out_size, out @out));
			uint num = out_size;
			IntPtr ptr = @out;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listAttr_0040535(ptr);
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

		public static Tuple<string, string>[] listAttrShallow(IntPtr symbol)
		{
			uint out_size = Helper.un<uint>();
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolListAttrShallow", CApi.MXSymbolListAttrShallow(symbol, out out_size, out @out));
			int num = (int)(2 * out_size);
			IntPtr ptr = @out;
			int num2 = num;
			FSharpFunc<int, string> val = new listAttrShallow_0040544(ptr);
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
			int num3 = 2;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			string[][] array2 = ArrayModule.ChunkBySize<string>(num3, array);
			FSharpFunc<string[], Tuple<string, string>> val2 = new listAttrShallow_0040546_002D1();
			string[][] array3 = array2;
			if (array3 == null)
			{
				throw new ArgumentNullException("array");
			}
			Tuple<string, string>[] array4 = new Tuple<string, string>[array3.Length];
			for (int j = 0; j < array4.Length; j++)
			{
				array4[j] = val2.Invoke(array3[j]);
			}
			return array4;
		}

		public static string[] listArguments(IntPtr symbol)
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_str_array = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolListArguments", CApi.MXSymbolListArguments(symbol, out out_size, out out_str_array));
			uint num = out_size;
			IntPtr ptr = out_str_array;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listArguments_0040554(ptr);
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

		public static string[] listOutputs(IntPtr symbol)
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_str_array = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolListOutputs", CApi.MXSymbolListOutputs(symbol, out out_size, out out_str_array));
			uint num = out_size;
			IntPtr ptr = out_str_array;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listOutputs_0040562(ptr);
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
			Helper.throwOnError("MXSymbolGetNumOutputs", CApi.MXSymbolGetNumOutputs(symbol, out output_count));
			return output_count;
		}

		public static IntPtr getInternals(IntPtr symbol)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolGetInternals", CApi.MXSymbolGetInternals(symbol, out @out));
			return @out;
		}

		public static IntPtr getChildren(IntPtr symbol)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolGetChildren", CApi.MXSymbolGetChildren(symbol, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr getOutput(IntPtr symbol, int index)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolGetOutput", CApi.MXSymbolGetOutput(symbol, (uint)index, out @out));
			return @out;
		}

		public static string[] listAuxiliaryStates(IntPtr symbol)
		{
			uint out_size = Helper.un<uint>();
			IntPtr out_str_array = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolListAuxiliaryStates", CApi.MXSymbolListAuxiliaryStates(symbol, out out_size, out out_str_array));
			uint num = out_size;
			IntPtr ptr = out_str_array;
			int num2 = (int)num;
			FSharpFunc<int, string> val = new listAuxiliaryStates_0040603(ptr);
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
		public static IntPtr grad(IntPtr sym, string[] wrt)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolGrad", CApi.MXSymbolGrad(sym, Helper.ulength(wrt), wrt, out @out));
			return @out;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Tuple<string[], b[], a[]> keyShapeToCsrForm<a, b, a>(FSharpFunc<int, a> lengthType, Tuple<string, a[]>[] argShapes)
		{
			b[] argIndPtr = ArrayModule.ZeroCreate<b>(ArrayModule.Length<Tuple<string, a[]>>(argShapes) + 1);
			for (int j = 1; j < argIndPtr.Length; j++)
			{
				int num = j;
				b val = argIndPtr[j - 1];
				a val2 = lengthType.Invoke(ArrayModule.Length<a>(argShapes[j - 1].Item2));
				argIndPtr[num] = LanguagePrimitives.AdditionDynamic<b, a, b>(val, val2);
			}
			b val3 = argIndPtr[argIndPtr.Length - 1];
			b val4 = val3;
			if (0 == 0)
			{
				throw new NotSupportedException("Dynamic invocation of op_Explicit is not supported");
			}
			a[] argShapeData = ArrayModule.ZeroCreate<a>((int)(object)null);
			FSharpFunc<Tuple<string, a[]>, string> val5 = new keys_0040620<a>();
			if (argShapes == null)
			{
				throw new ArgumentNullException("array");
			}
			string[] array = new string[argShapes.Length];
			for (int m = 0; m < array.Length; m++)
			{
				array[m] = val5.Invoke(argShapes[m]);
			}
			string[] keys = array;
			int k = 0;
			for (int i = 0; i < argShapes.Length; i++)
			{
				a[] shapes = argShapes[i].Item2;
				for (int l = 0; l < shapes.Length; l++)
				{
					argShapeData[k] = shapes[l];
					k++;
				}
			}
			return new Tuple<string[], b[], a[]>(keys, argIndPtr, argShapeData);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static InferShapeResult<uint> inferShape(IntPtr sym, string[] keys, uint[] arg_ind_ptr, int[] arg_shape_data)
		{
			uint in_shape_size = Helper.un<uint>();
			IntPtr in_shape_ndim = Helper.un<IntPtr>();
			IntPtr in_shape_data = Helper.un<IntPtr>();
			uint aux_shape_size = Helper.un<uint>();
			IntPtr aux_shape_ndim = Helper.un<IntPtr>();
			IntPtr aux_shape_data = Helper.un<IntPtr>();
			uint out_shape_size = Helper.un<uint>();
			IntPtr out_shape_ndim = Helper.un<IntPtr>();
			IntPtr out_shape_data = Helper.un<IntPtr>();
			int complete = Helper.un<int>();
			Helper.throwOnError("MXSymbolInferShapeEx", CApi.MXSymbolInferShapeEx(sym, Helper.ulength(keys), keys, arg_ind_ptr, arg_shape_data, out in_shape_size, out in_shape_ndim, out in_shape_data, out out_shape_size, out out_shape_ndim, out out_shape_data, out aux_shape_size, out aux_shape_ndim, out aux_shape_data, out complete));
			FSharpFunc<uint, FSharpFunc<IntPtr, FSharpFunc<IntPtr, uint[][]>>> shapes = (FSharpFunc<uint, FSharpFunc<IntPtr, FSharpFunc<IntPtr, uint[][]>>>)(object)new shapes_0040651();
			return new InferShapeResult<uint>(complete != 0, FSharpFunc<uint, IntPtr>.InvokeFast<IntPtr, uint[][]>(shapes, aux_shape_size, aux_shape_ndim, aux_shape_data), FSharpFunc<uint, IntPtr>.InvokeFast<IntPtr, uint[][]>(shapes, in_shape_size, in_shape_ndim, in_shape_data), FSharpFunc<uint, IntPtr>.InvokeFast<IntPtr, uint[][]>(shapes, out_shape_size, out_shape_ndim, out_shape_data));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static InferShapeResult<long> inferShape64(IntPtr sym, string[] keys, long[] arg_ind_ptr, long[] arg_shape_data)
		{
			long in_shape_size = Helper.un<long>();
			IntPtr in_shape_ndim = Helper.un<IntPtr>();
			IntPtr in_shape_data = Helper.un<IntPtr>();
			long aux_shape_size = Helper.un<long>();
			IntPtr aux_shape_ndim = Helper.un<IntPtr>();
			IntPtr aux_shape_data = Helper.un<IntPtr>();
			long out_shape_size = Helper.un<long>();
			IntPtr out_shape_ndim = Helper.un<IntPtr>();
			IntPtr out_shape_data = Helper.un<IntPtr>();
			int complete = Helper.un<int>();
			Helper.throwOnError("MXSymbolInferShapeEx64", CApi.MXSymbolInferShapeEx64(sym, Helper.ulength(keys), keys, arg_ind_ptr, arg_shape_data, out in_shape_size, out in_shape_ndim, out in_shape_data, out out_shape_size, out out_shape_ndim, out out_shape_data, out aux_shape_size, out aux_shape_ndim, out aux_shape_data, out complete));
			FSharpFunc<long, FSharpFunc<IntPtr, FSharpFunc<IntPtr, long[][]>>> shapes = (FSharpFunc<long, FSharpFunc<IntPtr, FSharpFunc<IntPtr, long[][]>>>)(object)new shapes_0040682_002D4();
			return new InferShapeResult<long>(complete != 0, FSharpFunc<long, IntPtr>.InvokeFast<IntPtr, long[][]>(shapes, aux_shape_size, aux_shape_ndim, aux_shape_data), FSharpFunc<long, IntPtr>.InvokeFast<IntPtr, long[][]>(shapes, in_shape_size, in_shape_ndim, in_shape_data), FSharpFunc<long, IntPtr>.InvokeFast<IntPtr, long[][]>(shapes, out_shape_size, out_shape_ndim, out_shape_data));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static InferShapeResult<uint> inferShapePartial(IntPtr sym, string[] keys, uint[] arg_ind_ptr, int[] arg_shape_data)
		{
			uint in_shape_size = Helper.un<uint>();
			IntPtr in_shape_ndim = Helper.un<IntPtr>();
			IntPtr in_shape_data = Helper.un<IntPtr>();
			uint aux_shape_size = Helper.un<uint>();
			IntPtr aux_shape_ndim = Helper.un<IntPtr>();
			IntPtr aux_shape_data = Helper.un<IntPtr>();
			uint out_shape_size = Helper.un<uint>();
			IntPtr out_shape_ndim = Helper.un<IntPtr>();
			IntPtr out_shape_data = Helper.un<IntPtr>();
			int complete = Helper.un<int>();
			Helper.throwOnError("MXSymbolInferShapePartialEx", CApi.MXSymbolInferShapePartialEx(sym, Helper.ulength(keys), keys, arg_ind_ptr, arg_shape_data, out in_shape_size, out in_shape_ndim, out in_shape_data, out out_shape_size, out out_shape_ndim, out out_shape_data, out aux_shape_size, out aux_shape_ndim, out aux_shape_data, out complete));
			FSharpFunc<uint, FSharpFunc<IntPtr, FSharpFunc<IntPtr, uint[][]>>> shapes = (FSharpFunc<uint, FSharpFunc<IntPtr, FSharpFunc<IntPtr, uint[][]>>>)(object)new shapes_0040714_002D8();
			return new InferShapeResult<uint>(complete != 0, FSharpFunc<uint, IntPtr>.InvokeFast<IntPtr, uint[][]>(shapes, aux_shape_size, aux_shape_ndim, aux_shape_data), FSharpFunc<uint, IntPtr>.InvokeFast<IntPtr, uint[][]>(shapes, in_shape_size, in_shape_ndim, in_shape_data), FSharpFunc<uint, IntPtr>.InvokeFast<IntPtr, uint[][]>(shapes, out_shape_size, out_shape_ndim, out_shape_data));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static InferShapeResult<long> inferShapePartial64(IntPtr sym, string[] keys, long[] arg_ind_ptr, long[] arg_shape_data)
		{
			long in_shape_size = Helper.un<long>();
			IntPtr in_shape_ndim = Helper.un<IntPtr>();
			IntPtr in_shape_data = Helper.un<IntPtr>();
			long aux_shape_size = Helper.un<long>();
			IntPtr aux_shape_ndim = Helper.un<IntPtr>();
			IntPtr aux_shape_data = Helper.un<IntPtr>();
			long out_shape_size = Helper.un<long>();
			IntPtr out_shape_ndim = Helper.un<IntPtr>();
			IntPtr out_shape_data = Helper.un<IntPtr>();
			int complete = Helper.un<int>();
			Helper.throwOnError("MXSymbolInferShapePartialEx64", CApi.MXSymbolInferShapePartialEx64(sym, Helper.ulength(keys), keys, arg_ind_ptr, arg_shape_data, out in_shape_size, out in_shape_ndim, out in_shape_data, out out_shape_size, out out_shape_ndim, out out_shape_data, out aux_shape_size, out aux_shape_ndim, out aux_shape_data, out complete));
			FSharpFunc<long, FSharpFunc<IntPtr, FSharpFunc<IntPtr, long[][]>>> shapes = (FSharpFunc<long, FSharpFunc<IntPtr, FSharpFunc<IntPtr, long[][]>>>)(object)new shapes_0040746_002D12();
			return new InferShapeResult<long>(complete != 0, FSharpFunc<long, IntPtr>.InvokeFast<IntPtr, long[][]>(shapes, aux_shape_size, aux_shape_ndim, aux_shape_data), FSharpFunc<long, IntPtr>.InvokeFast<IntPtr, long[][]>(shapes, in_shape_size, in_shape_ndim, in_shape_data), FSharpFunc<long, IntPtr>.InvokeFast<IntPtr, long[][]>(shapes, out_shape_size, out_shape_ndim, out_shape_data));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static InferTypeResult inferType(IntPtr sym, string[] keys, int[] arg_type_data)
		{
			uint in_type_size = Helper.un<uint>();
			IntPtr in_type_data = Helper.un<IntPtr>();
			uint aux_type_size = Helper.un<uint>();
			IntPtr aux_type_data = Helper.un<IntPtr>();
			int complete = Helper.un<int>();
			uint out_type_size = Helper.un<uint>();
			IntPtr out_type_data = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolInferType", CApi.MXSymbolInferType(sym, Helper.ulength(keys), keys, arg_type_data, out in_type_size, out in_type_data, out out_type_size, out out_type_data, out aux_type_size, out aux_type_data, out complete));
			bool num = complete != 0;
			uint num2 = aux_type_size;
			IntPtr ptr = aux_type_data;
			int num3 = (int)num2;
			FSharpFunc<int, int> val = new inferType_0040781(ptr);
			if (num3 < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num3
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			int[] array = new int[num3];
			bool flag = num;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			uint num4 = in_type_size;
			IntPtr ptr2 = in_type_data;
			int num5 = (int)num4;
			FSharpFunc<int, int> val2 = new inferType_0040782_002D1(ptr2);
			if (num5 < 0)
			{
				object[] args2 = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num5
				};
				string message2 = string.Format("{0}\n{1} = {2}", args2);
				throw new ArgumentException(message2, "count");
			}
			int[] array2 = new int[num5];
			int[] array3 = array;
			bool flag2 = flag;
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = val2.Invoke(j);
			}
			uint num6 = out_type_size;
			IntPtr ptr3 = out_type_data;
			int num7 = (int)num6;
			FSharpFunc<int, int> val3 = new inferType_0040783_002D2(ptr3);
			if (num7 < 0)
			{
				object[] args3 = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num7
				};
				string message3 = string.Format("{0}\n{1} = {2}", args3);
				throw new ArgumentException(message3, "count");
			}
			int[] array4 = new int[num7];
			int[] inputTypes = array2;
			int[] auxTypes = array3;
			bool complete2 = flag2;
			for (int k = 0; k < array4.Length; k++)
			{
				array4[k] = val3.Invoke(k);
			}
			return new InferTypeResult(complete2, auxTypes, inputTypes, array4);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static InferTypeResult inferTypePartial(IntPtr sym, string[] keys, int[] arg_type_data)
		{
			uint in_type_size = Helper.un<uint>();
			IntPtr in_type_data = Helper.un<IntPtr>();
			uint aux_type_size = Helper.un<uint>();
			IntPtr aux_type_data = Helper.un<IntPtr>();
			int complete = Helper.un<int>();
			uint out_type_size = Helper.un<uint>();
			IntPtr out_type_data = Helper.un<IntPtr>();
			Helper.throwOnError("MXSymbolInferTypePartial", CApi.MXSymbolInferTypePartial(sym, Helper.ulength(keys), keys, arg_type_data, out in_type_size, out in_type_data, out out_type_size, out out_type_data, out aux_type_size, out aux_type_data, out complete));
			bool num = complete != 0;
			uint num2 = aux_type_size;
			IntPtr ptr = aux_type_data;
			int num3 = (int)num2;
			FSharpFunc<int, int> val = new inferTypePartial_0040813(ptr);
			if (num3 < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num3
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			int[] array = new int[num3];
			bool flag = num;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			uint num4 = in_type_size;
			IntPtr ptr2 = in_type_data;
			int num5 = (int)num4;
			FSharpFunc<int, int> val2 = new inferTypePartial_0040814_002D1(ptr2);
			if (num5 < 0)
			{
				object[] args2 = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num5
				};
				string message2 = string.Format("{0}\n{1} = {2}", args2);
				throw new ArgumentException(message2, "count");
			}
			int[] array2 = new int[num5];
			int[] array3 = array;
			bool flag2 = flag;
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = val2.Invoke(j);
			}
			uint num6 = out_type_size;
			IntPtr ptr3 = out_type_data;
			int num7 = (int)num6;
			FSharpFunc<int, int> val3 = new inferTypePartial_0040815_002D2(ptr3);
			if (num7 < 0)
			{
				object[] args3 = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					num7
				};
				string message3 = string.Format("{0}\n{1} = {2}", args3);
				throw new ArgumentException(message3, "count");
			}
			int[] array4 = new int[num7];
			int[] inputTypes = array2;
			int[] auxTypes = array3;
			bool complete2 = flag2;
			for (int k = 0; k < array4.Length; k++)
			{
				array4[k] = val3.Invoke(k);
			}
			return new InferTypeResult(complete2, auxTypes, inputTypes, array4);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1,
			1
		})]
		public static void quantize(IntPtr sym_handle, string[] excluded_sym_names, string[] excluded_op_names, string[] offline_params, string quantized_dtype, string quantize_mode)
		{
			int dev_type = Helper.un<int>();
			IntPtr ret_sym_handle = Helper.un<IntPtr>();
			uint out_num_calib_names = Helper.un<uint>();
			IntPtr out_calib_names = Helper.un<IntPtr>();
			Helper.throwOnError("MXQuantizeSymbol", CApi.MXQuantizeSymbol(sym_handle, out ret_sym_handle, out dev_type, Helper.ulength(excluded_sym_names), excluded_sym_names, Helper.ulength(excluded_op_names), excluded_op_names, Helper.ulength(offline_params), offline_params, quantized_dtype, calib_quantize: true, quantize_mode, out out_num_calib_names, out out_calib_names));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		})]
		public static void reducePrecision(IntPtr sym_handle, int[] arg_type_data, int[] ind_ptr, int[] target_dtype, int cast_optional_params, uint num_target_dtype_op_names, uint num_fp32_op_names, uint num_widest_dtype_op_names, uint num_conditional_fp32_op_names, uint num_excluded_symbols, uint num_model_params, string[] target_dtype_op_names, string[] fp32_op_names, string[] widest_dtype_op_names, string[] conditional_fp32_op_names, string[] excluded_symbols, string[] conditional_param_names, string[] conditional_param_vals, string[] model_param_names, string[] arg_names)
		{
			IntPtr ret_sym_handle = Helper.un<IntPtr>();
			Helper.throwOnError("MXReducePrecisionSymbol", CApi.MXReducePrecisionSymbol(sym_handle, out ret_sym_handle, Helper.ulength(arg_type_data), arg_type_data, Helper.ulength(ind_ptr), ind_ptr, target_dtype, cast_optional_params, num_target_dtype_op_names, num_fp32_op_names, num_widest_dtype_op_names, num_conditional_fp32_op_names, num_excluded_symbols, num_model_params, target_dtype_op_names, fp32_op_names, widest_dtype_op_names, conditional_fp32_op_names, excluded_symbols, conditional_param_names, conditional_param_vals, model_param_names, arg_names));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static IntPtr setCalibTableToQuantizedSymbol(IntPtr qsym_handle, string[] layer_names, float[] low_quantiles, float[] high_quantiles)
		{
			IntPtr ret_sym_handle = Helper.un<IntPtr>();
			Helper.throwOnError("MXSetCalibTableToQuantizedSymbol", CApi.MXSetCalibTableToQuantizedSymbol(qsym_handle, Helper.ulength(layer_names), layer_names, low_quantiles, high_quantiles, out ret_sym_handle));
			return ret_sym_handle;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static IntPtr genBackendSubgraph(IntPtr sym_handle, string backend)
		{
			IntPtr ret_sym_handle = Helper.un<IntPtr>();
			Helper.throwOnError("MXGenBackendSubgraph", CApi.MXGenBackendSubgraph(sym_handle, backend, out ret_sym_handle));
			return ret_sym_handle;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		})]
		public static void optimizeForBackend(IntPtr sym_handle, string backend_name, int dev_type, IntPtr[] ret_sym_handle, uint len, IntPtr[] in_args_handle, uint num_options, string[] keys, string[] vals)
		{
			Helper.throwOnError("MXOptimizeForBackend", CApi.MXOptimizeForBackend(sym_handle, backend_name, dev_type, ret_sym_handle, len, in_args_handle, num_options, keys, vals));
		}
	}
}
