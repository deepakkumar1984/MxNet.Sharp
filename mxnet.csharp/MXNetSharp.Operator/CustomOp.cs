#define DEBUG
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Core.CompilerServices;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Operator
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class CustomOp
	{
		[Serializable]
		internal sealed class keys_0040254_002D1 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal keys_0040254_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return MXNetSharp.Interop.Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class values_0040255 : FSharpFunc<int, string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal values_0040255(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public override string Invoke(int i)
			{
				return MXNetSharp.Interop.Helper.readString(i, ptr);
			}
		}

		[Serializable]
		internal sealed class tensorDims_0040261 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tensorDims_0040261(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class shapePtrs_0040266 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapePtrs_0040266(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class shapes_0040271_002D17 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040271_002D17(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class shapes_0040269_002D16 : GeneratedSequenceBase<int[]>
		{
			public int[] tensorDims = tensorDims;

			public int inCount = inCount;

			public IntPtr[] shapePtrs = shapePtrs;

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
			public int[] current = current;

			public shapes_0040269_002D16(int[] tensorDims, int inCount, IntPtr[] shapePtrs, IEnumerator<int> @enum, int pc, int[] current)
			{
			}

			public override int GenerateNext(ref IEnumerable<int[]> next)
			{
				switch (pc)
				{
				default:
					@enum = OperatorIntrinsics.RangeInt32(0, 1, inCount - 1).GetEnumerator();
					pc = 1;
					goto case 2;
				case 2:
				case 3:
					if (@enum.MoveNext())
					{
						int i = @enum.Current;
						if (tensorDims[i] > 0)
						{
							pc = 2;
							int num = tensorDims[i];
							IntPtr ptr = shapePtrs[i];
							int num2 = num;
							FSharpFunc<int, int> val = new shapes_0040271_002D17(ptr);
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
							int[] array = new int[num2];
							for (int j = 0; j < array.Length; j++)
							{
								array[j] = val.Invoke(j);
							}
							current = array;
							return 1;
						}
						pc = 3;
						current = ArrayModule.Empty<int>();
						return 1;
					}
					goto case 1;
				case 1:
					pc = 4;
					IntrinsicFunctions.Dispose<IEnumerator<int>>(@enum);
					@enum = null;
					pc = 4;
					break;
				case 4:
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
								pc = 4;
								IntrinsicFunctions.Dispose<IEnumerator<int>>(@enum);
								break;
							case 0:
							case 4:
								break;
							}
							pc = 4;
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
					case 4:
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
				case 3:
					return true;
				case 1:
					return true;
				case 0:
				case 4:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override int[] get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<int[]> GetFreshEnumerator()
			{
				return (IEnumerator<int[]>)(object)new shapes_0040269_002D16(tensorDims, inCount, shapePtrs, null, 0, null);
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class returnShapes_0040281 : GeneratedSequenceBase<int[]>
		{
			public int[][] outputShapes = outputShapes;

			public int[][] inputShapes = inputShapes;

			public int[][] auxShapes = auxShapes;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<int[]> @enum = @enum;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<int[]> enum0 = enum0;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int pc = pc;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int[] current = current;

			public returnShapes_0040281(int[][] outputShapes, int[][] inputShapes, int[][] auxShapes, IEnumerator<int[]> @enum, IEnumerator<int[]> enum0, int pc, int[] current)
			{
			}

			public override int GenerateNext(ref IEnumerable<int[]> next)
			{
				switch (pc)
				{
				default:
					@enum = ((IEnumerable<int[]>)inputShapes).GetEnumerator();
					pc = 1;
					goto case 2;
				case 2:
					if (@enum.MoveNext())
					{
						int[] array = @enum.Current;
						pc = 2;
						current = array;
						return 1;
					}
					goto case 1;
				case 1:
					pc = 6;
					IntrinsicFunctions.Dispose<IEnumerator<int[]>>(@enum);
					@enum = null;
					enum0 = ((IEnumerable<int[]>)outputShapes).GetEnumerator();
					pc = 3;
					goto case 4;
				case 4:
					if (enum0.MoveNext())
					{
						int[] array2 = enum0.Current;
						pc = 4;
						current = array2;
						return 1;
					}
					goto case 3;
				case 3:
					pc = 6;
					IntrinsicFunctions.Dispose<IEnumerator<int[]>>(enum0);
					enum0 = null;
					pc = 5;
					next = auxShapes;
					return 2;
				case 5:
					pc = 6;
					break;
				case 6:
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
							case 3:
							case 4:
								pc = 6;
								IntrinsicFunctions.Dispose<IEnumerator<int[]>>(enum0);
								break;
							case 1:
							case 2:
								pc = 6;
								IntrinsicFunctions.Dispose<IEnumerator<int[]>>(@enum);
								break;
							}
							pc = 6;
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
					case 6:
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
					return false;
				case 4:
					return true;
				case 3:
					return true;
				case 2:
					return true;
				case 1:
					return true;
				case 0:
				case 6:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override int[] get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<int[]> GetFreshEnumerator()
			{
				return (IEnumerator<int[]>)(object)new returnShapes_0040281(outputShapes, inputShapes, auxShapes, null, null, 0, null);
			}
		}

		[Serializable]
		internal sealed class dims_0040285_002D4 : FSharpFunc<int[], int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dims_0040285_002D4()
			{
			}

			public override int Invoke(int[] array)
			{
				return ArrayModule.Length<int>(array);
			}
		}

		[Serializable]
		internal sealed class returnShapesPtrs_0040290 : FSharpFunc<int[], IntPtr>
		{
			public ResourceTracker rt;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal returnShapesPtrs_0040290(ResourceTracker rt)
			{
				this.rt = rt;
			}

			public unsafe override IntPtr Invoke(int[] a)
			{
				IntPtr mem = rt.Alloc(a.Length * sizeof(int));
				Marshal.Copy(a, 0, mem, a.Length);
				return mem;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class inferShape_0040260
		{
			public ResourceTracker rt = rt;

			public ICustomOperationProperties opProp = opProp;

			public inferShape_0040260(ResourceTracker rt, ICustomOperationProperties opProp)
			{
			}

			internal bool Invoke(int numTensor, IntPtr tensorDimsPtr, IntPtr tensorShapes, IntPtr state)
			{
				FSharpFunc<int, int> val = new tensorDims_0040261(tensorDimsPtr);
				if (numTensor < 0)
				{
					object[] args = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						numTensor
					};
					string message = string.Format("{0}\n{1} = {2}", args);
					throw new ArgumentException(message, "count");
				}
				int[] array = new int[numTensor];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				int[] tensorDims = array;
				int inCount = opProp.ListArguments().Length;
				int outCount = opProp.ListOutputs().Length;
				int auxCount = opProp.ListAuxiliaryStates().Length;
				Debug.Assert(numTensor == inCount + outCount + auxCount);
				FSharpFunc<int, IntPtr> val2 = new shapePtrs_0040266(tensorShapes);
				if (numTensor < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						numTensor
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				IntPtr[] array2 = new IntPtr[numTensor];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = val2.Invoke(j);
				}
				IntPtr[] shapePtrs = array2;
				int[][] shapes = SeqModule.ToArray<int[]>((IEnumerable<int[]>)(object)new shapes_0040269_002D16(tensorDims, inCount, shapePtrs, null, 0, null));
				Tuple<int[][], int[][], int[][]> tuple = opProp.InferShape(shapes);
				int[][] outputShapes = tuple.Item2;
				int[][] inputShapes = tuple.Item1;
				int[][] auxShapes = tuple.Item3;
				Debug.Assert(inputShapes.Length == inCount);
				Debug.Assert(outputShapes.Length == outCount);
				Debug.Assert(auxShapes.Length == auxCount);
				int[][] returnShapes = SeqModule.ToArray<int[]>((IEnumerable<int[]>)(object)new returnShapes_0040281(outputShapes, inputShapes, auxShapes, null, null, 0, null));
				int[][] array3 = returnShapes;
				FSharpFunc<int[], int> val3 = new dims_0040285_002D4();
				int[][] array4 = array3;
				if (array4 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array5 = new int[array4.Length];
				for (int k = 0; k < array5.Length; k++)
				{
					array5[k] = val3.Invoke(array4[k]);
				}
				int[] dims = array5;
				Marshal.Copy(dims, 0, tensorDimsPtr, dims.Length);
				int[][] array6 = returnShapes;
				FSharpFunc<int[], IntPtr> val4 = new returnShapesPtrs_0040290(rt);
				int[][] array7 = array6;
				if (array7 == null)
				{
					throw new ArgumentNullException("array");
				}
				IntPtr[] array8 = new IntPtr[array7.Length];
				for (int l = 0; l < array8.Length; l++)
				{
					array8[l] = val4.Invoke(array7[l]);
				}
				IntPtr[] returnShapesPtrs = array8;
				Marshal.Copy(returnShapesPtrs, 0, tensorShapes, returnShapesPtrs.Length);
				return true;
			}
		}

		[Serializable]
		internal sealed class tensorTypes_0040299 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tensorTypes_0040299(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class tensorTypes_0040299_002D1 : FSharpFunc<int, StorageType>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tensorTypes_0040299_002D1()
			{
			}

			public override StorageType Invoke(int arg00)
			{
				return StorageType.FromInt(arg00);
			}
		}

		[Serializable]
		internal sealed class tags_0040300 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tags_0040300(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class tensors_0040301 : FSharpFunc<int, List<StorageType>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tensors_0040301()
			{
			}

			public override List<StorageType> Invoke(int _arg6)
			{
				return new List<StorageType>();
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class retStorageTypes_0040317 : GeneratedSequenceBase<StorageType>
		{
			public BackwardStorageTypes tensors = tensors;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<StorageType> @enum = @enum;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<StorageType> enum0 = enum0;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<StorageType> enum1 = enum1;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<StorageType> enum2 = enum2;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int pc = pc;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public StorageType current = current;

			public retStorageTypes_0040317(BackwardStorageTypes tensors, IEnumerator<StorageType> @enum, IEnumerator<StorageType> enum0, IEnumerator<StorageType> enum1, IEnumerator<StorageType> enum2, int pc, StorageType current)
			{
			}

			public override int GenerateNext(ref IEnumerable<StorageType> next)
			{
				switch (pc)
				{
				default:
					@enum = ((IEnumerable<StorageType>)tensors.OutputGrad_0040).GetEnumerator();
					pc = 1;
					goto case 2;
				case 2:
					if (@enum.MoveNext())
					{
						StorageType storageType = @enum.Current;
						pc = 2;
						current = storageType;
						return 1;
					}
					goto case 1;
				case 1:
					pc = 10;
					IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(@enum);
					@enum = null;
					enum0 = ((IEnumerable<StorageType>)tensors.Input_0040).GetEnumerator();
					pc = 3;
					goto case 4;
				case 4:
					if (enum0.MoveNext())
					{
						StorageType storageType2 = enum0.Current;
						pc = 4;
						current = storageType2;
						return 1;
					}
					goto case 3;
				case 3:
					pc = 10;
					IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(enum0);
					enum0 = null;
					enum1 = ((IEnumerable<StorageType>)tensors.Output_0040).GetEnumerator();
					pc = 5;
					goto case 6;
				case 6:
					if (enum1.MoveNext())
					{
						StorageType storageType4 = enum1.Current;
						pc = 6;
						current = storageType4;
						return 1;
					}
					goto case 5;
				case 5:
					pc = 10;
					IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(enum1);
					enum1 = null;
					enum2 = ((IEnumerable<StorageType>)tensors.InputGrad_0040).GetEnumerator();
					pc = 7;
					goto case 8;
				case 8:
					if (enum2.MoveNext())
					{
						StorageType storageType3 = enum2.Current;
						pc = 8;
						current = storageType3;
						return 1;
					}
					goto case 7;
				case 7:
					pc = 10;
					IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(enum2);
					enum2 = null;
					pc = 9;
					next = tensors.Auxiliary_0040;
					return 2;
				case 9:
					pc = 10;
					break;
				case 10:
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
							case 7:
							case 8:
								pc = 10;
								IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(enum2);
								break;
							case 5:
							case 6:
								pc = 10;
								IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(enum1);
								break;
							case 3:
							case 4:
								pc = 10;
								IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(enum0);
								break;
							case 1:
							case 2:
								pc = 10;
								IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(@enum);
								break;
							}
							pc = 10;
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
					case 10:
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
					return false;
				case 8:
					return true;
				case 7:
					return true;
				case 6:
					return true;
				case 5:
					return true;
				case 4:
					return true;
				case 3:
					return true;
				case 2:
					return true;
				case 1:
					return true;
				case 0:
				case 10:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override StorageType get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<StorageType> GetFreshEnumerator()
			{
				return (IEnumerator<StorageType>)(object)new retStorageTypes_0040317(tensors, null, null, null, null, 0, null);
			}
		}

		[Serializable]
		internal sealed class retStorageTypes_0040323_002D1 : FSharpFunc<StorageType, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal retStorageTypes_0040323_002D1()
			{
			}

			public override int Invoke(StorageType x)
			{
				return x.ToInt();
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class inferBackwardStorageType_0040298
		{
			public ICustomOperationProperties opProp = opProp;

			public inferBackwardStorageType_0040298(ICustomOperationProperties opProp)
			{
			}

			internal bool Invoke(IntPtr numTensor, IntPtr tensorTypesPtr, IntPtr tags, IntPtr state)
			{
				int num = (int)(long)numTensor;
				FSharpFunc<int, int> val = new tensorTypes_0040299(tensorTypesPtr);
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
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				int[] array2 = array;
				FSharpFunc<int, StorageType> val2 = new tensorTypes_0040299_002D1();
				int[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				StorageType[] array4 = new StorageType[array3.Length];
				for (int k = 0; k < array4.Length; k++)
				{
					array4[k] = val2.Invoke(array3[k]);
				}
				StorageType[] tensorTypes = array4;
				int num2 = (int)(long)numTensor;
				FSharpFunc<int, int> val3 = new tags_0040300(tags);
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
				int[] array5 = new int[num2];
				for (int l = 0; l < array5.Length; l++)
				{
					array5[l] = val3.Invoke(l);
				}
				int[] tags2 = array5;
				int num3 = 5;
				FSharpFunc<int, List<StorageType>> val4 = new tensors_0040301();
				if (num3 < 0)
				{
					object[] args3 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num3
					};
					string message3 = string.Format("{0}\n{1} = {2}", args3);
					throw new ArgumentException(message3, "count");
				}
				List<StorageType>[] array6 = new List<StorageType>[num3];
				for (int m = 0; m < array6.Length; m++)
				{
					array6[m] = val4.Invoke(m);
				}
				List<StorageType>[] tensors2 = array6;
				int i = 0;
				int num4 = (int)(long)numTensor - 1;
				if (num4 >= i)
				{
					do
					{
						tensors2[tags2[i]].Add(tensorTypes[i]);
						i++;
					}
					while (i != num4 + 1);
				}
				StorageType[] outputGrad = tensors2[3].ToArray();
				StorageType[] input = tensors2[0].ToArray();
				StorageType[] output = tensors2[1].ToArray();
				BackwardStorageTypes tensors = new BackwardStorageTypes(tensors2[2].ToArray(), outputGrad, input, output, tensors2[4].ToArray());
				opProp.InferBackwardStorageType(tensors);
				StorageType[] array7 = SeqModule.ToArray<StorageType>((IEnumerable<StorageType>)(object)new retStorageTypes_0040317(tensors, null, null, null, null, 0, null));
				FSharpFunc<StorageType, int> val5 = new retStorageTypes_0040323_002D1();
				StorageType[] array8 = array7;
				if (array8 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array9 = new int[array8.Length];
				for (int n = 0; n < array9.Length; n++)
				{
					array9[n] = val5.Invoke(array8[n]);
				}
				int[] retStorageTypes = array9;
				Marshal.Copy(retStorageTypes, 0, tensorTypesPtr, retStorageTypes.Length);
				_ = null;
				return true;
			}
		}

		[Serializable]
		internal sealed class tensorTypes_0040332_002D2 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tensorTypes_0040332_002D2(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class tensorTypes_0040332_002D3 : FSharpFunc<int, StorageType>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tensorTypes_0040332_002D3()
			{
			}

			public override StorageType Invoke(int arg00)
			{
				return StorageType.FromInt(arg00);
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class retStorageTypes_0040339_002D2 : GeneratedSequenceBase<StorageType>
		{
			public StorageType[] outStore = outStore;

			public StorageType[] inStore = inStore;

			public StorageType[] auxStore = auxStore;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<StorageType> @enum = @enum;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<StorageType> enum0 = enum0;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int pc = pc;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public StorageType current = current;

			public retStorageTypes_0040339_002D2(StorageType[] outStore, StorageType[] inStore, StorageType[] auxStore, IEnumerator<StorageType> @enum, IEnumerator<StorageType> enum0, int pc, StorageType current)
			{
			}

			public override int GenerateNext(ref IEnumerable<StorageType> next)
			{
				switch (pc)
				{
				default:
					@enum = ((IEnumerable<StorageType>)inStore).GetEnumerator();
					pc = 1;
					goto case 2;
				case 2:
					if (@enum.MoveNext())
					{
						StorageType storageType = @enum.Current;
						pc = 2;
						current = storageType;
						return 1;
					}
					goto case 1;
				case 1:
					pc = 6;
					IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(@enum);
					@enum = null;
					enum0 = ((IEnumerable<StorageType>)outStore).GetEnumerator();
					pc = 3;
					goto case 4;
				case 4:
					if (enum0.MoveNext())
					{
						StorageType storageType2 = enum0.Current;
						pc = 4;
						current = storageType2;
						return 1;
					}
					goto case 3;
				case 3:
					pc = 6;
					IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(enum0);
					enum0 = null;
					pc = 5;
					next = auxStore;
					return 2;
				case 5:
					pc = 6;
					break;
				case 6:
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
							case 3:
							case 4:
								pc = 6;
								IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(enum0);
								break;
							case 1:
							case 2:
								pc = 6;
								IntrinsicFunctions.Dispose<IEnumerator<StorageType>>(@enum);
								break;
							}
							pc = 6;
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
					case 6:
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
					return false;
				case 4:
					return true;
				case 3:
					return true;
				case 2:
					return true;
				case 1:
					return true;
				case 0:
				case 6:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override StorageType get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<StorageType> GetFreshEnumerator()
			{
				return (IEnumerator<StorageType>)(object)new retStorageTypes_0040339_002D2(outStore, inStore, auxStore, null, null, 0, null);
			}
		}

		[Serializable]
		internal sealed class retStorageTypes_0040343_002D3 : FSharpFunc<StorageType, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal retStorageTypes_0040343_002D3()
			{
			}

			public override int Invoke(StorageType x)
			{
				return x.ToInt();
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class inferStorageType_0040328
		{
			public ICustomOperationProperties opProp = opProp;

			public inferStorageType_0040328(ICustomOperationProperties opProp)
			{
			}

			internal bool Invoke(int numTensor, IntPtr stypesPtr, IntPtr state)
			{
				int inCount = opProp.ListArguments().Length;
				int outCount = opProp.ListOutputs().Length;
				int auxCount = opProp.ListAuxiliaryStates().Length;
				int num = inCount;
				int num2 = num;
				FSharpFunc<int, int> val = new tensorTypes_0040332_002D2(stypesPtr);
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
				int[] array = new int[num2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				int[] array2 = array;
				FSharpFunc<int, StorageType> val2 = new tensorTypes_0040332_002D3();
				int[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				StorageType[] array4 = new StorageType[array3.Length];
				for (int j = 0; j < array4.Length; j++)
				{
					array4[j] = val2.Invoke(array3[j]);
				}
				StorageType[] tensorTypes = array4;
				Tuple<StorageType[], StorageType[], StorageType[]> tuple = opProp.InferStorageType(tensorTypes);
				StorageType[] outStore = tuple.Item2;
				StorageType[] inStore = tuple.Item1;
				StorageType[] auxStore = tuple.Item3;
				Debug.Assert(inStore.Length == inCount);
				Debug.Assert(outStore.Length == outCount);
				Debug.Assert(auxStore.Length == auxCount);
				StorageType[] array5 = SeqModule.ToArray<StorageType>((IEnumerable<StorageType>)(object)new retStorageTypes_0040339_002D2(outStore, inStore, auxStore, null, null, 0, null));
				FSharpFunc<StorageType, int> val3 = new retStorageTypes_0040343_002D3();
				StorageType[] array6 = array5;
				if (array6 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array7 = new int[array6.Length];
				for (int k = 0; k < array7.Length; k++)
				{
					array7[k] = val3.Invoke(array6[k]);
				}
				int[] retStorageTypes = array7;
				Marshal.Copy(retStorageTypes, 0, stypesPtr, retStorageTypes.Length);
				_ = null;
				return true;
			}
		}

		[Serializable]
		internal sealed class dtypes_0040352 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dtypes_0040352(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class dtypes_0040352_002D1 : FSharpFunc<int, TypeFlag>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dtypes_0040352_002D1()
			{
			}

			public override TypeFlag Invoke(int value)
			{
				return (TypeFlag)value;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class ret_0040360 : GeneratedSequenceBase<TypeFlag>
		{
			public TypeFlag[] outputTypes = outputTypes;

			public TypeFlag[] inputTypes = inputTypes;

			public TypeFlag[] auxTypes = auxTypes;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<TypeFlag> @enum = @enum;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<TypeFlag> enum0 = enum0;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int pc = pc;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public TypeFlag current = current;

			public ret_0040360(TypeFlag[] outputTypes, TypeFlag[] inputTypes, TypeFlag[] auxTypes, IEnumerator<TypeFlag> @enum, IEnumerator<TypeFlag> enum0, int pc, TypeFlag current)
			{
			}

			public override int GenerateNext(ref IEnumerable<TypeFlag> next)
			{
				switch (pc)
				{
				default:
					@enum = ((IEnumerable<TypeFlag>)inputTypes).GetEnumerator();
					pc = 1;
					goto case 2;
				case 2:
					if (@enum.MoveNext())
					{
						TypeFlag typeFlag = @enum.Current;
						pc = 2;
						current = typeFlag;
						return 1;
					}
					goto case 1;
				case 1:
					pc = 6;
					IntrinsicFunctions.Dispose<IEnumerator<TypeFlag>>(@enum);
					@enum = null;
					enum0 = ((IEnumerable<TypeFlag>)outputTypes).GetEnumerator();
					pc = 3;
					goto case 4;
				case 4:
					if (enum0.MoveNext())
					{
						TypeFlag typeFlag2 = enum0.Current;
						pc = 4;
						current = typeFlag2;
						return 1;
					}
					goto case 3;
				case 3:
					pc = 6;
					IntrinsicFunctions.Dispose<IEnumerator<TypeFlag>>(enum0);
					enum0 = null;
					pc = 5;
					next = auxTypes;
					return 2;
				case 5:
					pc = 6;
					break;
				case 6:
					break;
				}
				TypeFlag typeFlag3 = default(TypeFlag);
				current = typeFlag3;
				return 0;
			}

			public override void Close()
			{
				TypeFlag typeFlag = default(TypeFlag);
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
							case 3:
							case 4:
								pc = 6;
								IntrinsicFunctions.Dispose<IEnumerator<TypeFlag>>(enum0);
								break;
							case 1:
							case 2:
								pc = 6;
								IntrinsicFunctions.Dispose<IEnumerator<TypeFlag>>(@enum);
								break;
							}
							pc = 6;
							current = typeFlag;
							Unit val = null;
						}
						catch (object obj)
						{
							Exception e = (Exception)obj;
							ex = e;
							Unit val = null;
						}
						break;
					case 6:
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
					return false;
				case 4:
					return true;
				case 3:
					return true;
				case 2:
					return true;
				case 1:
					return true;
				case 0:
				case 6:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override TypeFlag get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<TypeFlag> GetFreshEnumerator()
			{
				TypeFlag typeFlag = default(TypeFlag);
				return (IEnumerator<TypeFlag>)(object)new ret_0040360(outputTypes, inputTypes, auxTypes, null, null, 0, typeFlag);
			}
		}

		[Serializable]
		internal sealed class ret_0040364_002D1 : FSharpFunc<TypeFlag, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ret_0040364_002D1()
			{
			}

			public override int Invoke(TypeFlag value)
			{
				return (int)value;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class inferType_0040348_002D3
		{
			public ICustomOperationProperties opProp = opProp;

			public inferType_0040348_002D3(ICustomOperationProperties opProp)
			{
			}

			internal bool Invoke(int numTensor, IntPtr typesPtr, IntPtr state)
			{
				int inCount = opProp.ListArguments().Length;
				int outCount = opProp.ListOutputs().Length;
				int auxCount = opProp.ListAuxiliaryStates().Length;
				int num = inCount;
				int num2 = num;
				FSharpFunc<int, int> val = new dtypes_0040352(typesPtr);
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
				int[] array = new int[num2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				int[] array2 = array;
				FSharpFunc<int, TypeFlag> val2 = new dtypes_0040352_002D1();
				int[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				TypeFlag[] array4 = new TypeFlag[array3.Length];
				for (int j = 0; j < array4.Length; j++)
				{
					array4[j] = val2.Invoke(array3[j]);
				}
				TypeFlag[] dtypes = array4;
				Debug.Assert(numTensor == inCount + outCount + auxCount);
				Tuple<TypeFlag[], TypeFlag[], TypeFlag[]> tuple = opProp.InferType(dtypes);
				TypeFlag[] outputTypes = tuple.Item2;
				TypeFlag[] inputTypes = tuple.Item1;
				TypeFlag[] auxTypes = tuple.Item3;
				Debug.Assert(inputTypes.Length == inCount);
				Debug.Assert(outputTypes.Length == outCount);
				Debug.Assert(auxTypes.Length == auxCount);
				TypeFlag current = default(TypeFlag);
				TypeFlag[] array5 = SeqModule.ToArray<TypeFlag>((IEnumerable<TypeFlag>)(object)new ret_0040360(outputTypes, inputTypes, auxTypes, null, null, 0, current));
				FSharpFunc<TypeFlag, int> val3 = new ret_0040364_002D1();
				TypeFlag[] array6 = array5;
				if (array6 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array7 = new int[array6.Length];
				for (int k = 0; k < array7.Length; k++)
				{
					array7[k] = val3.Invoke(array6[k]);
				}
				int[] ret = array7;
				Debug.Assert(ret.Length == numTensor);
				Marshal.Copy(ret, 0, typesPtr, numTensor);
				return true;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class listOutputs_0040369_002D1
		{
			public ResourceTracker rt = rt;

			public ICustomOperationProperties opProp = opProp;

			public listOutputs_0040369_002D1(ResourceTracker rt, ICustomOperationProperties opProp)
			{
			}

			internal bool Invoke(ref IntPtr @out, IntPtr _arg7)
			{
				string[] i = opProp.ListOutputs();
				@out = rt.CachedStringArray(i);
				return true;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class listArgs_0040374
		{
			public ResourceTracker rt = rt;

			public ICustomOperationProperties opProp = opProp;

			public listArgs_0040374(ResourceTracker rt, ICustomOperationProperties opProp)
			{
			}

			internal bool Invoke(ref IntPtr @out, IntPtr _arg8)
			{
				string[] i = opProp.ListArguments();
				@out = rt.CachedStringArray(i);
				return true;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class listAuxStates_0040379
		{
			public ResourceTracker rt = rt;

			public ICustomOperationProperties opProp = opProp;

			public listAuxStates_0040379(ResourceTracker rt, ICustomOperationProperties opProp)
			{
			}

			internal bool Invoke(ref IntPtr @out, IntPtr _arg9)
			{
				string[] i = opProp.ListAuxiliaryStates();
				@out = rt.CachedStringArray(i);
				return true;
			}
		}

		[Serializable]
		internal sealed class outGrad_0040387 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal outGrad_0040387(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class inData_0040388 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal inData_0040388(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class outData_0040389 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal outData_0040389(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class rdeps_0040390 : FSharpFunc<int, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal rdeps_0040390()
			{
			}

			public override int Invoke(int value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class rdeps_0040390_002D1 : FSharpFunc<int, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal rdeps_0040390_002D1()
			{
			}

			public override int Invoke(int value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class rdeps_0040390_002D2 : FSharpFunc<int, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal rdeps_0040390_002D2()
			{
			}

			public override int Invoke(int value)
			{
				return value;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class declareBackwardDep_0040384
		{
			public ResourceTracker rt = rt;

			public ICustomOperationProperties opProp = opProp;

			public declareBackwardDep_0040384(ResourceTracker rt, ICustomOperationProperties opProp)
			{
			}

			internal unsafe bool Invoke(IntPtr outGrad, IntPtr inData, IntPtr outData, ref int numDep, ref IntPtr deps, IntPtr state)
			{
				int inCount = opProp.ListArguments().Length;
				int outCount = opProp.ListOutputs().Length;
				int num = outCount;
				int num2 = num;
				FSharpFunc<int, int> val = new outGrad_0040387(outGrad);
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
				int[] array = new int[num2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				int[] outGrad2 = array;
				int num3 = inCount;
				int num4 = num3;
				FSharpFunc<int, int> val2 = new inData_0040388(inData);
				if (num4 < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num4
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				int[] array2 = new int[num4];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = val2.Invoke(j);
				}
				int[] inData2 = array2;
				int num5 = outCount;
				int num6 = num5;
				FSharpFunc<int, int> val3 = new outData_0040389(outData);
				if (num6 < 0)
				{
					object[] args3 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num6
					};
					string message3 = string.Format("{0}\n{1} = {2}", args3);
					throw new ArgumentException(message3, "count");
				}
				int[] array3 = new int[num6];
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k] = val3.Invoke(k);
				}
				int[] outData2 = array3;
				ICustomOperationProperties customOperationProperties = opProp;
				int[] array4 = outGrad2;
				FSharpFunc<int, int> val4 = new rdeps_0040390();
				int[] array5 = array4;
				if (array5 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array6 = new int[array5.Length];
				ICustomOperationProperties customOperationProperties2 = customOperationProperties;
				for (int l = 0; l < array6.Length; l++)
				{
					array6[l] = val4.Invoke(array5[l]);
				}
				int[] array7 = inData2;
				FSharpFunc<int, int> val5 = new rdeps_0040390_002D1();
				int[] array8 = array7;
				if (array8 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array9 = new int[array8.Length];
				int[] array10 = array6;
				ICustomOperationProperties customOperationProperties3 = customOperationProperties2;
				for (int m = 0; m < array9.Length; m++)
				{
					array9[m] = val5.Invoke(array8[m]);
				}
				int[] array11 = outData2;
				FSharpFunc<int, int> val6 = new rdeps_0040390_002D2();
				int[] array12 = array11;
				if (array12 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array13 = new int[array12.Length];
				int[] inData3 = array9;
				int[] outGrad3 = array10;
				ICustomOperationProperties customOperationProperties4 = customOperationProperties3;
				for (int n = 0; n < array13.Length; n++)
				{
					array13[n] = val6.Invoke(array12[n]);
				}
				int[] rdeps = customOperationProperties4.DeclareBackwardDependency(outGrad3, inData3, array13);
				numDep = rdeps.Length;
				IntPtr dptr = rt.Alloc(rdeps.Length * sizeof(int));
				Marshal.Copy(rdeps, 0, dptr, rdeps.Length);
				deps = dptr;
				return true;
			}
		}

		[Serializable]
		internal sealed class ndims_0040404 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ndims_0040404(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class dtypes_0040405_002D2 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dtypes_0040405_002D2(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class dtypes_0040405_002D3 : FSharpFunc<int, TypeFlag>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal dtypes_0040405_002D3()
			{
			}

			public override TypeFlag Invoke(int value)
			{
				return (TypeFlag)value;
			}
		}

		[Serializable]
		internal sealed class shapePtrs_0040407_002D1 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapePtrs_0040407_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class shapes_0040411_002D19 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040411_002D19(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class shapes_0040410_002D18 : FSharpFunc<int, int, int[]>
		{
			public IntPtr[] shapePtrs;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal shapes_0040410_002D18(IntPtr[] shapePtrs)
			{
				this.shapePtrs = shapePtrs;
			}

			public override int[] Invoke(int i, int d)
			{
				IntPtr ptr = shapePtrs[i];
				FSharpFunc<int, int> val = new shapes_0040411_002D19(ptr);
				if (d < 0)
				{
					object[] args = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						d
					};
					string message = string.Format("{0}\n{1} = {2}", args);
					throw new ArgumentException(message, "count");
				}
				int[] array = new int[d];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				return array;
			}
		}

		[Serializable]
		internal sealed class tensors_0040415_002D1 : FSharpFunc<int, List<NDArray>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tensors_0040415_002D1()
			{
			}

			public override List<NDArray> Invoke(int _arg10)
			{
				return new List<NDArray>();
			}
		}

		[Serializable]
		internal sealed class tags_0040416_002D1 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tags_0040416_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class ndarrs_0040417 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ndarrs_0040417(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class reqs_0040421 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal reqs_0040421(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class forward_0040422_002D1 : FSharpFunc<int, OpReqType>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal forward_0040422_002D1()
			{
			}

			public override OpReqType Invoke(int arg00)
			{
				return OpReqType.FromInt(arg00);
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class forward_0040414
		{
			public ICustomOperation cop = cop;

			public forward_0040414(ICustomOperation cop)
			{
			}

			internal bool Invoke(int size, IntPtr ptrs, IntPtr tags, IntPtr reqs, bool isTrain, IntPtr state)
			{
				int num = 5;
				FSharpFunc<int, List<NDArray>> val = new tensors_0040415_002D1();
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
				List<NDArray>[] array = new List<NDArray>[num];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				List<NDArray>[] tensors = array;
				FSharpFunc<int, int> val2 = new tags_0040416_002D1(tags);
				if (size < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						size
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				int[] array2 = new int[size];
				for (int k = 0; k < array2.Length; k++)
				{
					array2[k] = val2.Invoke(k);
				}
				int[] tags2 = array2;
				FSharpFunc<int, IntPtr> val3 = new ndarrs_0040417(ptrs);
				if (size < 0)
				{
					object[] args3 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						size
					};
					string message3 = string.Format("{0}\n{1} = {2}", args3);
					throw new ArgumentException(message3, "count");
				}
				IntPtr[] array3 = new IntPtr[size];
				for (int l = 0; l < array3.Length; l++)
				{
					array3[l] = val3.Invoke(l);
				}
				IntPtr[] ndarrs = array3;
				int i = 0;
				int num2 = size - 1;
				if (num2 >= i)
				{
					do
					{
						tensors[tags2[i]].Add(new NDArray(new SafeNDArrayHandle(ndarrs[i], owner: true)));
						i++;
					}
					while (i != num2 + 1);
				}
				int count = tensors[1].Count;
				int num3 = count;
				FSharpFunc<int, int> val4 = new reqs_0040421(reqs);
				if (num3 < 0)
				{
					object[] args4 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num3
					};
					string message4 = string.Format("{0}\n{1} = {2}", args4);
					throw new ArgumentException(message4, "count");
				}
				int[] array4 = new int[num3];
				for (int m = 0; m < array4.Length; m++)
				{
					array4[m] = val4.Invoke(m);
				}
				int[] reqs2 = array4;
				ICustomOperation customOperation = cop;
				int[] array5 = reqs2;
				FSharpFunc<int, OpReqType> val5 = new forward_0040422_002D1();
				int[] array6 = array5;
				if (array6 == null)
				{
					throw new ArgumentNullException("array");
				}
				OpReqType[] array7 = new OpReqType[array6.Length];
				bool isTrain2 = isTrain;
				ICustomOperation customOperation2 = customOperation;
				for (int n = 0; n < array7.Length; n++)
				{
					array7[n] = val5.Invoke(array6[n]);
				}
				customOperation2.Forward(isTrain2, array7, tensors[0].ToArray(), tensors[1].ToArray(), tensors[4].ToArray());
				return true;
			}
		}

		[Serializable]
		internal sealed class tensors_0040426_002D2 : FSharpFunc<int, List<NDArray>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tensors_0040426_002D2()
			{
			}

			public override List<NDArray> Invoke(int _arg11)
			{
				return new List<NDArray>();
			}
		}

		[Serializable]
		internal sealed class tags_0040427_002D2 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal tags_0040427_002D2(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class ndarrs_0040428_002D1 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ndarrs_0040428_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class reqs_0040433_002D1 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal reqs_0040433_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		[Serializable]
		internal sealed class backward_0040434_002D1 : FSharpFunc<int, OpReqType>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal backward_0040434_002D1()
			{
			}

			public override OpReqType Invoke(int arg00)
			{
				return OpReqType.FromInt(arg00);
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class backward_0040425
		{
			public ICustomOperation cop = cop;

			public backward_0040425(ICustomOperation cop)
			{
			}

			internal bool Invoke(int size, IntPtr ptrs, IntPtr tags, IntPtr reqs, bool isTrain, IntPtr state)
			{
				int num = 5;
				FSharpFunc<int, List<NDArray>> val = new tensors_0040426_002D2();
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
				List<NDArray>[] array = new List<NDArray>[num];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				List<NDArray>[] tensors = array;
				FSharpFunc<int, int> val2 = new tags_0040427_002D2(tags);
				if (size < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						size
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				int[] array2 = new int[size];
				for (int k = 0; k < array2.Length; k++)
				{
					array2[k] = val2.Invoke(k);
				}
				int[] tags2 = array2;
				FSharpFunc<int, IntPtr> val3 = new ndarrs_0040428_002D1(ptrs);
				if (size < 0)
				{
					object[] args3 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						size
					};
					string message3 = string.Format("{0}\n{1} = {2}", args3);
					throw new ArgumentException(message3, "count");
				}
				IntPtr[] array3 = new IntPtr[size];
				for (int l = 0; l < array3.Length; l++)
				{
					array3[l] = val3.Invoke(l);
				}
				IntPtr[] ndarrs = array3;
				int i = 0;
				int num2 = size - 1;
				if (num2 >= i)
				{
					do
					{
						tensors[tags2[i]].Add(new NDArray(new SafeNDArrayHandle(ndarrs[i], owner: true)));
						i++;
					}
					while (i != num2 + 1);
				}
				int count = tensors[1].Count;
				int num3 = count;
				FSharpFunc<int, int> val4 = new reqs_0040433_002D1(reqs);
				if (num3 < 0)
				{
					object[] args4 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num3
					};
					string message4 = string.Format("{0}\n{1} = {2}", args4);
					throw new ArgumentException(message4, "count");
				}
				int[] array4 = new int[num3];
				for (int m = 0; m < array4.Length; m++)
				{
					array4[m] = val4.Invoke(m);
				}
				int[] reqs2 = array4;
				ICustomOperation customOperation = cop;
				int[] array5 = reqs2;
				FSharpFunc<int, OpReqType> val5 = new backward_0040434_002D1();
				int[] array6 = array5;
				if (array6 == null)
				{
					throw new ArgumentNullException("array");
				}
				OpReqType[] array7 = new OpReqType[array6.Length];
				ICustomOperation customOperation2 = customOperation;
				for (int n = 0; n < array7.Length; n++)
				{
					array7[n] = val5.Invoke(array6[n]);
				}
				customOperation2.Backward(array7, tensors[0].ToArray(), tensors[1].ToArray(), tensors[2].ToArray(), tensors[3].ToArray(), tensors[4].ToArray());
				return true;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class createOp_0040398
		{
			public string opType = opType;

			public ICustomOperationProperties opProp = opProp;

			public createOp_0040398(string opType, ICustomOperationProperties opProp)
			{
			}

			internal unsafe bool Invoke(string ctx, int numInputs, IntPtr shapes, IntPtr ndims, IntPtr dtypes, ref CApi.MXCallbackList ret, IntPtr state)
			{
				ResourceTracker rt = ResourceTracker.CreateStored(opType + "_createop");
				FSharpOption<Context> val = Context.TryParse(ctx);
				Context context2;
				if (val != null)
				{
					FSharpOption<Context> val2 = val;
					Context c = val2.get_Value();
					context2 = c;
				}
				else
				{
					FSharpFunc<string, Context> val3 = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, Context>, Context>((PrintfFormat<FSharpFunc<string, Context>, Unit, string, Context>)(object)new PrintfFormat<FSharpFunc<string, Context>, Unit, string, Context, string>("Could not parse context '%s'"));
					context2 = val3.Invoke(ctx);
				}
				Context context = context2;
				FSharpFunc<int, int> val4 = new ndims_0040404(ndims);
				if (numInputs < 0)
				{
					object[] args = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						numInputs
					};
					string message = string.Format("{0}\n{1} = {2}", args);
					throw new ArgumentException(message, "count");
				}
				int[] array = new int[numInputs];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val4.Invoke(i);
				}
				int[] ndims2 = array;
				FSharpFunc<int, int> val5 = new dtypes_0040405_002D2(dtypes);
				if (numInputs < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						numInputs
					};
					string message2 = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message2, "count");
				}
				int[] array2 = new int[numInputs];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = val5.Invoke(j);
				}
				int[] array3 = array2;
				FSharpFunc<int, TypeFlag> val6 = new dtypes_0040405_002D3();
				int[] array4 = array3;
				if (array4 == null)
				{
					throw new ArgumentNullException("array");
				}
				TypeFlag[] array5 = new TypeFlag[array4.Length];
				for (int k = 0; k < array5.Length; k++)
				{
					array5[k] = val6.Invoke(array4[k]);
				}
				TypeFlag[] dtypes2 = array5;
				FSharpFunc<int, IntPtr> val7 = new shapePtrs_0040407_002D1(shapes);
				if (numInputs < 0)
				{
					object[] args3 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						numInputs
					};
					string message3 = string.Format("{0}\n{1} = {2}", args3);
					throw new ArgumentException(message3, "count");
				}
				IntPtr[] array6 = new IntPtr[numInputs];
				for (int l = 0; l < array6.Length; l++)
				{
					array6[l] = val7.Invoke(l);
				}
				IntPtr[] shapePtrs = array6;
				int[][] shapes2 = ArrayModule.MapIndexed<int, int[]>((FSharpFunc<int, FSharpFunc<int, int[]>>)(object)new shapes_0040410_002D18(shapePtrs), ndims2);
				ICustomOperation cop = opProp.CreateOperator(context, shapes2, dtypes2);
				CApi.CustomOpFBFunc forward = new forward_0040414(cop).Invoke;
				CApi.CustomOpFBFunc backward = new backward_0040425(cop).Invoke;
				rt.WriteMxCallbackList(ref ret, new Tuple<Delegate, IntPtr>[2]
				{
					new Tuple<Delegate, IntPtr>(forward, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(backward, (IntPtr)(void*)0L)
				});
				return true;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class creator_0040251
		{
			public string name = name;

			public FSharpFunc<IDictionary<string, string>, ICustomOperationProperties> makeOpProps = makeOpProps;

			public ResourceTracker rt = rt;

			public creator_0040251(string name, FSharpFunc<IDictionary<string, string>, ICustomOperationProperties> makeOpProps, ResourceTracker rt)
			{
			}

			internal unsafe bool Invoke(string opType, int argCount, IntPtr keys, IntPtr values, ref CApi.MXCallbackList cbList)
			{
				Debug.Assert(string.Equals(opType, name));
				FSharpFunc<int, string> val = new keys_0040254_002D1(keys);
				if (argCount < 0)
				{
					object[] args2 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						argCount
					};
					string message = string.Format("{0}\n{1} = {2}", args2);
					throw new ArgumentException(message, "count");
				}
				string[] array = new string[argCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = val.Invoke(i);
				}
				string[] keys2 = array;
				FSharpFunc<int, string> val2 = new values_0040255(values);
				if (argCount < 0)
				{
					object[] args3 = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						argCount
					};
					string message2 = string.Format("{0}\n{1} = {2}", args3);
					throw new ArgumentException(message2, "count");
				}
				string[] array2 = new string[argCount];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = val2.Invoke(j);
				}
				string[] values2 = array2;
				Tuple<string, string>[] array3 = ArrayModule.Zip<string, string>(keys2, values2);
				Tuple<string, string>[] array4 = array3;
				IDictionary<string, string> args = ExtraTopLevelOperators.CreateDictionary<string, string>((IEnumerable<Tuple<string, string>>)array4);
				ICustomOperationProperties opProp = makeOpProps.Invoke(args);
				CApi.CustomOpInferShapeFunc inferShape = new inferShape_0040260(rt, opProp).Invoke;
				CApi.CustomOpBackwardInferStorageTypeFunc inferBackwardStorageType = new inferBackwardStorageType_0040298(opProp).Invoke;
				CApi.CustomOpInferStorageTypeFunc inferStorageType = new inferStorageType_0040328(opProp).Invoke;
				CApi.CustomOpInferStorageTypeFunc inferType = new inferType_0040348_002D3(opProp).Invoke;
				CApi.CustomOpListFunc listOutputs = new listOutputs_0040369_002D1(rt, opProp).Invoke;
				CApi.CustomOpListFunc listArgs = new listArgs_0040374(rt, opProp).Invoke;
				CApi.CustomOpListFunc listAuxStates = new listAuxStates_0040379(rt, opProp).Invoke;
				CApi.CustomOpBwdDepFunc declareBackwardDep = new declareBackwardDep_0040384(rt, opProp).Invoke;
				CApi.CustomOpCreateFunc createOp = new createOp_0040398(opType, opProp).Invoke;
				rt.WriteMxCallbackList(ref cbList, new Tuple<Delegate, IntPtr>[9]
				{
					new Tuple<Delegate, IntPtr>(listArgs, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(listOutputs, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(listAuxStates, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(inferShape, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(declareBackwardDep, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(createOp, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(inferType, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(inferStorageType, (IntPtr)(void*)0L),
					new Tuple<Delegate, IntPtr>(inferBackwardStorageType, (IntPtr)(void*)0L)
				});
				return true;
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static void register(string name, FSharpFunc<IDictionary<string, string>, ICustomOperationProperties> makeOpProps)
		{
			ResourceTracker rt = ResourceTracker.CreateStored(name);
			CApi.CustomOpPropCreator creator = new creator_0040251(name, makeOpProps, rt).Invoke;
			IntPtr intPtr = rt.DelgatePointer(creator);
			IntPtr intPtr2 = intPtr;
			MXLib.customOpRegister(name, creator);
		}
	}
}
