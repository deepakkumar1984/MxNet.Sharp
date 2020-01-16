#define DEBUG
using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class NDArray : IDisposable
	{
		internal SafeNDArrayHandle handle;

		internal bool disposed;

		internal static NDArray noarg;

		internal static int init_004013_002D11;

		public static NDArray NoArg
		{
			get
			{
				if (init_004013_002D11 < 2)
				{
					IntrinsicFunctions.FailStaticInit();
				}
				return noarg;
			}
		}

		public SafeNDArrayHandle NDArrayHandle => handle;

		public IntPtr UnsafeHandle => NDArrayHandle.UnsafeHandle;

		public unsafe FSharpOption<NDArray> Grad
		{
			get
			{
				IntPtr handle = MXNDArray.getGrad(this.handle.UnsafeHandle);
				if ((long)handle > (long)(IntPtr)(void*)0L)
				{
					return FSharpOption<NDArray>.Some(new NDArray(new SafeNDArrayHandle(handle, owner: true)));
				}
				return null;
			}
		}

		public FSharpOption<DataType> DataType
		{
			get
			{
				TypeFlag dType = MXNDArray.getDType(handle.UnsafeHandle);
				TypeFlag typeflag = dType;
				return MXNetSharp.DataType.FromTypeFlag(typeflag);
			}
		}

		public TypeFlag DataTypeFlag => MXNDArray.getDType(handle.UnsafeHandle);

		public StorageType StorageType
		{
			get
			{
				int storageType = MXNDArray.getStorageType(handle.UnsafeHandle);
				int n = storageType;
				return StorageType.FromInt(n);
			}
		}

		public int[] Shape => MXNDArray.getShape(handle.UnsafeHandle);

		public int Size => ArrayModule.Reduce<int>((FSharpFunc<int, FSharpFunc<int, int>>)(object)new _0024Ndarray.get_Size_0040139(), Shape);

		public Context Context
		{
			get
			{
				(DeviceTypeEnum, int) context = MXNDArray.getContext(handle.UnsafeHandle);
				int id = context.Item2;
				DeviceTypeEnum dt = context.Item1;
				return Context.FromDeviceTypeAndId(dt, id);
			}
		}

		public NDArray this[params int[] a]
		{
			get
			{
				return ArrayModule.Fold<int, NDArray>((FSharpFunc<NDArray, FSharpFunc<int, NDArray>>)(object)new _0024Ndarray.get_Item_0040422(), this, a);
			}
			set
			{
				SetItemAtIntex(a, value);
			}
		}

		public NDArray this[params object[] a] => GetSlice(a);

		public NDArray(SafeNDArrayHandle handle)
		{
			this.handle = handle;
			disposed = false;
		}

		internal NDArray(IntPtr h)
			: this(new SafeNDArrayHandle(h, owner: true))
		{
		}

		public NDArray()
			: this(MXNDArray.createNone())
		{
		}

		public NDArray(IEnumerable<int> shape, Context context, [OptionalArgument] FSharpOption<DataType> dtype, [OptionalArgument] FSharpOption<bool> delayAlloc)
		{
			DataType dtype2 = Operators.DefaultArg<DataType>(dtype, MXNetSharp.DataType.Float32);
			bool delayAlloc2 = Operators.DefaultArg<bool>(delayAlloc, true);
			int[] shape2 = SeqModule.ToArray<int>(shape);
			int[] array = shape2;
			DeviceTypeEnum deviceType = context.DeviceType;
			int deviceId = context.DeviceId;
			bool b = delayAlloc2;
			TypeFlag typeFlag = dtype2.TypeFlag;
			IntPtr @out = IntPtr.Zero;
			int[] array2 = array;
			FSharpFunc<int, uint> val = new _0024Ndarray._002Dctor_004038_002D5();
			int[] array3 = array2;
			if (array3 == null)
			{
				throw new ArgumentNullException("array");
			}
			uint[] array4 = new uint[array3.Length];
			string call = "MXNDArrayCreateEx";
			for (int i = 0; i < array4.Length; i++)
			{
				array4[i] = val.Invoke(array3[i]);
			}
			MXNetSharp.Interop.Helper.throwOnError(call, CApi.MXNDArrayCreateEx(array4, (uint)array.Length, (int)deviceType, deviceId, MXNetSharp.Interop.Helper.boolToInt(b), (int)typeFlag, out @out));
			this._002Ector(@out);
		}

		public static NDArray ConvertCopyFrom<aa>(aa[] data, IEnumerable<int> shape, Context ctx, [OptionalArgument] FSharpOption<DataType> dtype)
		{
			int[] shape3 = SeqModule.ToArray<int>(shape);
			int idx = -1;
			int sz = 1;
			for (int i = 0; i < shape3.Length; i++)
			{
				if (shape3[i] == -1)
				{
					if (idx >= 0)
					{
						string paramName = "shape";
						string message = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int[], string>>((PrintfFormat<FSharpFunc<int[], string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int[], string>, Unit, string, string, int[]>("Invalid shape %A. At most one dimension of shape can be -1")).Invoke(shape3);
						throw new ArgumentException(message, paramName);
					}
					idx = i;
				}
				else
				{
					sz *= shape3[i];
				}
			}
			int[] array;
			if (idx >= 0)
			{
				int result = 0;
				Tuple<int, int> tuple = new Tuple<int, int>(Math.DivRem(data.Length, sz, out result), result);
				int r = tuple.Item2;
				int j = tuple.Item1;
				if (r != 0)
				{
					string paramName2 = "shape";
					string message2 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int[], string>>((PrintfFormat<FSharpFunc<int[], string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int[], string>, Unit, string, string, int[]>("Invalid shape %A. Could not infer -1 dimension.")).Invoke(shape3);
					throw new ArgumentException(message2, paramName2);
				}
				shape3[idx] = j;
				array = shape3;
			}
			else
			{
				if (sz != data.Length)
				{
					string paramName3 = "shape";
					FSharpFunc<int[], FSharpFunc<int, FSharpFunc<int, string>>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int[], FSharpFunc<int, FSharpFunc<int, string>>>>((PrintfFormat<FSharpFunc<int[], FSharpFunc<int, FSharpFunc<int, string>>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int[], FSharpFunc<int, FSharpFunc<int, string>>>, Unit, string, string, Tuple<int[], int, int>>("shape %A with length %d does not match array length %d"));
					string message3 = FSharpFunc<int[], int>.InvokeFast<int, string>((FSharpFunc<int[], FSharpFunc<int, FSharpFunc<int, string>>>)new _0024Ndarray.shape_004059(clo), shape3, sz, data.Length);
					throw new ArgumentException(message3, paramName3);
				}
				array = shape3;
			}
			int[] shape2 = array;
			DataType dtype2 = Operators.DefaultArg<DataType>(dtype, MXNetSharp.DataType.Float32);
			NDArray a = new NDArray(shape2, ctx, FSharpOption<MXNetSharp.DataType>.Some(dtype2), FSharpOption<bool>.Some(false));
			a.CopyFrom(data);
			return a;
		}

		public FSharpOption<DataType> GetAuxType(long index)
		{
			TypeFlag auxType = MXNDArray.getAuxType64(handle.UnsafeHandle, index);
			TypeFlag typeflag = auxType;
			return MXNetSharp.DataType.FromTypeFlag(typeflag);
		}

		public FSharpOption<DataType> GetAuxType(int index)
		{
			return GetAuxType((long)index);
		}

		public NDArray GetAuxCopy(long index)
		{
			IntPtr handle = MXNDArray.getAuxNDArray64(this.handle.UnsafeHandle, index);
			return new NDArray(new SafeNDArrayHandle(handle, owner: true));
		}

		public NDArray GetAuxCopy(int index)
		{
			return GetAuxCopy((long)index);
		}

		public void AttachGradient([Optional] [OptionalArgument] FSharpOption<OpReqType> gradReq, [Optional] [OptionalArgument] FSharpOption<StorageType> storageType)
		{
			OpReqType gradReq2 = Operators.DefaultArg<OpReqType>(gradReq, OpReqType.WriteTo);
			NDArray nDArray;
			if (storageType != null)
			{
				FSharpOption<StorageType> val = storageType;
				switch (val.get_Value().Tag)
				{
				case 0:
				case 1:
				{
					FSharpOption<DataType> dataType = DataType;
					if (dataType != null)
					{
						FSharpOption<DataType> val3 = dataType;
						DataType dtype = val3.get_Value();
						NDArray[] inputs = ArrayModule.Empty<NDArray>();
						Tuple<string, string>[] array3 = new Tuple<string, string>[3];
						string item = "shape";
						int[] shape2 = Shape;
						int[] array4 = shape2;
						ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
						int[] x = array4;
						ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
						array3[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)x));
						string item2 = "ctx";
						Context context = Context;
						Context context2 = context;
						ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
						Context x2 = context2;
						ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
						array3[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(x2));
						string item3 = "dtype";
						DataType dataType2 = dtype;
						DataType dataType3 = dataType2;
						ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
						DataType x3 = dataType3;
						ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
						array3[2] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x3));
						nDArray = invoke1("_zeros", inputs, array3);
					}
					else
					{
						NDArray[] inputs2 = ArrayModule.Empty<NDArray>();
						Tuple<string, string>[] array5 = new Tuple<string, string>[2];
						string item4 = "shape";
						int[] shape3 = Shape;
						int[] array6 = shape3;
						ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
						int[] x4 = array6;
						ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
						array5[0] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString((object)x4));
						string item5 = "ctx";
						Context context3 = Context;
						Context context4 = context3;
						ValueStringExtensions valueStringExtensions9 = ValueStringExtensions.ValueStringExtensions;
						Context x5 = context4;
						ValueStringExtensions valueStringExtensions10 = valueStringExtensions9;
						array5[1] = new Tuple<string, string>(item5, ValueStringExtensions.ValueString(x5));
						nDArray = invoke1("_zeros", inputs2, array5);
					}
					break;
				}
				default:
				{
					StorageType stype = val.get_Value();
					Tuple<int[], uint[][]> tuple;
					switch (stype.Tag)
					{
					default:
						tuple = new Tuple<int[], uint[][]>(new int[2]
						{
							6,
							6
						}, new uint[2][]
						{
							new uint[1]
							{
								0u
							},
							new uint[1]
							{
								0u
							}
						});
						break;
					case 2:
						tuple = new Tuple<int[], uint[][]>(new int[1]
						{
							6
						}, new uint[1][]
						{
							new uint[1]
							{
								0u
							}
						});
						break;
					case 0:
					case 1:
					{
						string text = "Unreachable. Default/Undefined case matched";
						throw Operators.Failure(text);
					}
					}
					Tuple<int[], uint[][]> tuple2 = tuple;
					int[] types = tuple2.Item1;
					uint[][] shapes = tuple2.Item2;
					TypeFlag dtype2 = DataTypeFlag;
					Context ctx = Context;
					int num = (int)stype;
					int[] shape = Shape;
					FSharpFunc<int, uint> val2 = new _0024Ndarray.handle_0040107();
					int[] array = shape;
					if (array == null)
					{
						throw new ArgumentNullException("array");
					}
					uint[] array2 = new uint[array.Length];
					int storage_type = num;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i] = val2.Invoke(array[i]);
					}
					IntPtr handle = MXNDArray.createSparseEx(storage_type, array2, (int)ctx.DeviceType, ctx.DeviceId, 1, (int)dtype2, types, shapes);
					NDArray a = new NDArray(new SafeNDArrayHandle(handle, owner: true));
					nDArray = mutInvoke(a, "_zeros", new NDArray[1]
					{
						a
					}, ArrayModule.Empty<Tuple<string, string>>());
					break;
				}
				}
			}
			else
			{
				nDArray = invoke1("zeros_like", new NDArray[1]
				{
					this
				}, ArrayModule.Empty<Tuple<string, string>>());
			}
			NDArray grad = nDArray;
			MXAutograd.markVariables(new IntPtr[1]
			{
				UnsafeHandle
			}, new uint[1]
			{
				(uint)gradReq2
			}, new IntPtr[1]
			{
				grad.UnsafeHandle
			});
		}

		public unsafe void Backward([OptionalArgument] FSharpOption<NDArray> outGrad, [OptionalArgument] FSharpOption<bool> retainGraph, [OptionalArgument] FSharpOption<bool> train, [OptionalArgument] FSharpOption<bool> createGraph)
		{
			bool retainGraph2 = Operators.DefaultArg<bool>(retainGraph, false);
			bool train2 = Operators.DefaultArg<bool>(train, true);
			bool createGraph2 = Operators.DefaultArg<bool>(createGraph, false);
			object obj;
			if (outGrad != null)
			{
				FSharpOption<NDArray> val = outGrad;
				NDArray a = val.get_Value();
				obj = new IntPtr[1]
				{
					a.UnsafeHandle
				};
			}
			else
			{
				obj = new IntPtr[1]
				{
					(IntPtr)(void*)0L
				};
			}
			IntPtr[] ograd = (IntPtr[])obj;
			Tuple<IntPtr[], int[]> tuple = MXAutograd.backwardEx(new IntPtr[1]
			{
				UnsafeHandle
			}, ograd, ArrayModule.Empty<IntPtr>(), retainGraph2, createGraph2, train2);
			int[] st = tuple.Item2;
			IntPtr[] h = tuple.Item1;
		}

		public void CopyTo(NDArray destination)
		{
			NDArray nDArray = mutInvoke(destination, "_copyto", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>());
			NDArray nDArray2 = nDArray;
		}

		public NDArray CopyTo(Context deviceContext)
		{
			NDArray destination = new NDArray(Shape, deviceContext, null, FSharpOption<bool>.Some(true));
			CopyTo(destination);
			return destination;
		}

		public void SyncCopyFromCPUUnchecked(Array data)
		{
			MXNDArray.syncCopyFromCPUArray(handle.UnsafeHandle, data);
		}

		public void SyncCopyFromCPU(Array data)
		{
			if (HashCompare.GenericEqualityIntrinsic<FSharpOption<DataType>>(DataType, MXNetSharp.DataType.TryFromNetType(data.GetType().GetElementType())))
			{
				MXNDArray.syncCopyFromCPUArray(handle.UnsafeHandle, data);
				return;
			}
			FSharpFunc<string, FSharpFunc<TypeFlag, string>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<TypeFlag, string>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<TypeFlag, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<TypeFlag, string>>, Unit, string, string, Tuple<string, TypeFlag>>("Source type of %s does not match NDArray type of %O"));
			throw new InvalidOperationException(FSharpFunc<string, TypeFlag>.InvokeFast<string>((FSharpFunc<string, FSharpFunc<TypeFlag, string>>)new _0024Ndarray.SyncCopyFromCPU_0040156(clo), data.GetType().FullName, DataTypeFlag));
		}

		public void SyncCopyFromCPUUnchecked<a>(a[] data)
		{
			MXNDArray.syncCopyFromCPU(handle.UnsafeHandle, data);
		}

		public void SyncCopyFromCPU<a>(a[] data)
		{
			if (HashCompare.GenericEqualityIntrinsic<FSharpOption<DataType>>(DataType, MXNetSharp.DataType.TryFromNetType<a>()))
			{
				MXNDArray.syncCopyFromCPU(handle.UnsafeHandle, data);
				return;
			}
			FSharpFunc<string, FSharpFunc<TypeFlag, string>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<TypeFlag, string>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<TypeFlag, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<TypeFlag, string>>, Unit, string, string, Tuple<string, TypeFlag>>("Source type of %s does not match NDArray type of %O"));
			throw new InvalidOperationException(FSharpFunc<string, TypeFlag>.InvokeFast<string>((FSharpFunc<string, FSharpFunc<TypeFlag, string>>)new _0024Ndarray.SyncCopyFromCPU_0040163_002D2(clo), typeof(a).FullName, DataTypeFlag));
		}

		public void CopyFrom(NDArray data)
		{
			data.CopyTo(this);
		}

		public void CopyFrom(Array data)
		{
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			Type etype = data.GetType().GetElementType();
			DataType dtype = MXNetSharp.DataType.FromNetType(etype);
			FSharpOption<DataType> dataType = DataType;
			if (dataType != null)
			{
				FSharpOption<DataType> val = dataType;
				DataType t2 = val.get_Value();
				DataType dataType2 = t2;
				DataType obj = dtype;
				if (dataType2.Equals(obj, LanguagePrimitives.get_GenericEqualityComparer()))
				{
					DataType t = val.get_Value();
					SyncCopyFromCPUUnchecked(data);
					return;
				}
				if (dataType != null)
				{
					FSharpOption<DataType> val2 = dataType;
					NDArray nd = CopyFrom(data, Context);
					try
					{
						nd.CopyTo(this);
						_ = null;
						Unit val3 = null;
					}
					finally
					{
						IDisposable disposable = nd as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
							_ = null;
						}
						else
						{
							_ = null;
						}
					}
					return;
				}
				throw new MatchFailureException("C:\\git\\MXNetSharp\\MXNetSharp\\ndarray.fs", 170, 14);
			}
			string text = "NDArray has no data type";
			throw Operators.Failure(text);
		}

		public void CopyFrom<aa>(aa[] data)
		{
			FSharpOption<DataType> dataType = DataType;
			if (dataType == null)
			{
				string text = "NDArray has no data type";
				throw Operators.Failure(text);
			}
			FSharpOption<DataType> val = dataType;
			DataType t = val.get_Value();
			switch (t.Tag)
			{
			default:
			{
				NDArray nd = CopyFrom(data, Context);
				try
				{
					nd.CopyTo(this);
					_ = null;
					Unit val10 = null;
				}
				finally
				{
					IDisposable disposable = nd as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
						_ = null;
					}
					else
					{
						_ = null;
					}
				}
				break;
			}
			case 1:
			{
				aa[] array100 = data;
				object obj4;
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(float)))
				{
					obj4 = (float[])(object)array100;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(double)))
				{
					double[] array101 = (double[])(object)array100;
					double[] array102 = array101;
					FSharpFunc<double, float> val27 = new _0024Ndarray.CopyFrom_0040187();
					double[] array103 = array102;
					if (array103 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array104 = new float[array103.Length];
					for (int num19 = 0; num19 < array104.Length; num19++)
					{
						array104[num19] = val27.Invoke(array103[num19]);
					}
					obj4 = array104;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(int)))
				{
					int[] array105 = (int[])(object)array100;
					int[] array106 = array105;
					FSharpFunc<int, float> val28 = new _0024Ndarray.CopyFrom_0040187_002D1();
					int[] array107 = array106;
					if (array107 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array108 = new float[array107.Length];
					for (int num20 = 0; num20 < array108.Length; num20++)
					{
						array108[num20] = val28.Invoke(array107[num20]);
					}
					obj4 = array108;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(long)))
				{
					long[] array109 = (long[])(object)array100;
					long[] array110 = array109;
					FSharpFunc<long, float> val29 = new _0024Ndarray.CopyFrom_0040187_002D2();
					long[] array111 = array110;
					if (array111 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array112 = new float[array111.Length];
					for (int num21 = 0; num21 < array112.Length; num21++)
					{
						array112[num21] = val29.Invoke(array111[num21]);
					}
					obj4 = array112;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(decimal)))
				{
					decimal[] array113 = (decimal[])(object)array100;
					decimal[] array114 = array113;
					FSharpFunc<decimal, float> val30 = new _0024Ndarray.CopyFrom_0040187_002D3();
					decimal[] array115 = array114;
					if (array115 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array116 = new float[array115.Length];
					for (int num22 = 0; num22 < array116.Length; num22++)
					{
						array116[num22] = val30.Invoke(array115[num22]);
					}
					obj4 = array116;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(sbyte)))
				{
					sbyte[] array117 = (sbyte[])(object)array100;
					sbyte[] array118 = array117;
					FSharpFunc<sbyte, float> val31 = new _0024Ndarray.CopyFrom_0040187_002D4();
					sbyte[] array119 = array118;
					if (array119 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array120 = new float[array119.Length];
					for (int num23 = 0; num23 < array120.Length; num23++)
					{
						array120[num23] = val31.Invoke(array119[num23]);
					}
					obj4 = array120;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(byte)))
				{
					byte[] array121 = (byte[])(object)array100;
					byte[] array122 = array121;
					FSharpFunc<byte, float> val32 = new _0024Ndarray.CopyFrom_0040187_002D5();
					byte[] array123 = array122;
					if (array123 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array124 = new float[array123.Length];
					for (int num24 = 0; num24 < array124.Length; num24++)
					{
						array124[num24] = val32.Invoke(array123[num24]);
					}
					obj4 = array124;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(bool)))
				{
					bool[] array125 = (bool[])(object)array100;
					bool[] array126 = array125;
					FSharpFunc<bool, float> val33 = new _0024Ndarray.CopyFrom_0040187_002D6();
					bool[] array127 = array126;
					if (array127 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array128 = new float[array127.Length];
					for (int num25 = 0; num25 < array128.Length; num25++)
					{
						array128[num25] = val33.Invoke(array127[num25]);
					}
					obj4 = array128;
				}
				else
				{
					aa[] array129 = array100;
					FSharpFunc<aa, float> val34 = new _0024Ndarray.CopyFrom_0040187_002D7<aa>();
					aa[] array130 = array129;
					if (array130 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array131 = new float[array130.Length];
					for (int num26 = 0; num26 < array131.Length; num26++)
					{
						array131[num26] = val34.Invoke(array130[num26]);
					}
					obj4 = array131;
				}
				float[] array132 = (float[])obj4;
				float[] data5 = array132;
				SyncCopyFromCPUUnchecked(data5);
				break;
			}
			case 2:
			{
				aa[] array199 = data;
				object obj7;
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(float)))
				{
					float[] array200 = (float[])(object)array199;
					float[] array201 = array200;
					FSharpFunc<float, double> val51 = new _0024Ndarray.CopyFrom_0040188_002D8();
					float[] array202 = array201;
					if (array202 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array203 = new double[array202.Length];
					for (int num43 = 0; num43 < array203.Length; num43++)
					{
						array203[num43] = val51.Invoke(array202[num43]);
					}
					obj7 = array203;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(double)))
				{
					obj7 = (double[])(object)array199;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(int)))
				{
					int[] array204 = (int[])(object)array199;
					int[] array205 = array204;
					FSharpFunc<int, double> val52 = new _0024Ndarray.CopyFrom_0040188_002D9();
					int[] array206 = array205;
					if (array206 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array207 = new double[array206.Length];
					for (int num44 = 0; num44 < array207.Length; num44++)
					{
						array207[num44] = val52.Invoke(array206[num44]);
					}
					obj7 = array207;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(long)))
				{
					long[] array208 = (long[])(object)array199;
					long[] array209 = array208;
					FSharpFunc<long, double> val53 = new _0024Ndarray.CopyFrom_0040188_002D10();
					long[] array210 = array209;
					if (array210 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array211 = new double[array210.Length];
					for (int num45 = 0; num45 < array211.Length; num45++)
					{
						array211[num45] = val53.Invoke(array210[num45]);
					}
					obj7 = array211;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(decimal)))
				{
					decimal[] array212 = (decimal[])(object)array199;
					decimal[] array213 = array212;
					FSharpFunc<decimal, double> val54 = new _0024Ndarray.CopyFrom_0040188_002D11();
					decimal[] array214 = array213;
					if (array214 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array215 = new double[array214.Length];
					for (int num46 = 0; num46 < array215.Length; num46++)
					{
						array215[num46] = val54.Invoke(array214[num46]);
					}
					obj7 = array215;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(sbyte)))
				{
					sbyte[] array216 = (sbyte[])(object)array199;
					sbyte[] array217 = array216;
					FSharpFunc<sbyte, double> val55 = new _0024Ndarray.CopyFrom_0040188_002D12();
					sbyte[] array218 = array217;
					if (array218 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array219 = new double[array218.Length];
					for (int num47 = 0; num47 < array219.Length; num47++)
					{
						array219[num47] = val55.Invoke(array218[num47]);
					}
					obj7 = array219;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(byte)))
				{
					byte[] array220 = (byte[])(object)array199;
					byte[] array221 = array220;
					FSharpFunc<byte, double> val56 = new _0024Ndarray.CopyFrom_0040188_002D13();
					byte[] array222 = array221;
					if (array222 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array223 = new double[array222.Length];
					for (int num48 = 0; num48 < array223.Length; num48++)
					{
						array223[num48] = val56.Invoke(array222[num48]);
					}
					obj7 = array223;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(bool)))
				{
					bool[] array224 = (bool[])(object)array199;
					bool[] array225 = array224;
					FSharpFunc<bool, double> val57 = new _0024Ndarray.CopyFrom_0040188_002D14();
					bool[] array226 = array225;
					if (array226 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array227 = new double[array226.Length];
					for (int num49 = 0; num49 < array227.Length; num49++)
					{
						array227[num49] = val57.Invoke(array226[num49]);
					}
					obj7 = array227;
				}
				else
				{
					aa[] array228 = array199;
					FSharpFunc<aa, double> val58 = new _0024Ndarray.CopyFrom_0040188_002D15<aa>();
					aa[] array229 = array228;
					if (array229 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array230 = new double[array229.Length];
					for (int num50 = 0; num50 < array230.Length; num50++)
					{
						array230[num50] = val58.Invoke(array229[num50]);
					}
					obj7 = array230;
				}
				double[] array231 = (double[])obj7;
				double[] data8 = array231;
				SyncCopyFromCPUUnchecked(data8);
				break;
			}
			case 3:
			{
				aa[] array67 = data;
				object obj3;
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(float)))
				{
					float[] array68 = (float[])(object)array67;
					float[] array69 = array68;
					FSharpFunc<float, int> val19 = new _0024Ndarray.CopyFrom_0040189_002D16();
					float[] array70 = array69;
					if (array70 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array71 = new int[array70.Length];
					for (int num11 = 0; num11 < array71.Length; num11++)
					{
						array71[num11] = val19.Invoke(array70[num11]);
					}
					obj3 = array71;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(double)))
				{
					double[] array72 = (double[])(object)array67;
					double[] array73 = array72;
					FSharpFunc<double, int> val20 = new _0024Ndarray.CopyFrom_0040189_002D17();
					double[] array74 = array73;
					if (array74 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array75 = new int[array74.Length];
					for (int num12 = 0; num12 < array75.Length; num12++)
					{
						array75[num12] = val20.Invoke(array74[num12]);
					}
					obj3 = array75;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(int)))
				{
					obj3 = (int[])(object)array67;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(long)))
				{
					long[] array76 = (long[])(object)array67;
					long[] array77 = array76;
					FSharpFunc<long, int> val21 = new _0024Ndarray.CopyFrom_0040189_002D18();
					long[] array78 = array77;
					if (array78 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array79 = new int[array78.Length];
					for (int num13 = 0; num13 < array79.Length; num13++)
					{
						array79[num13] = val21.Invoke(array78[num13]);
					}
					obj3 = array79;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(decimal)))
				{
					decimal[] array80 = (decimal[])(object)array67;
					decimal[] array81 = array80;
					FSharpFunc<decimal, int> val22 = new _0024Ndarray.CopyFrom_0040189_002D19();
					decimal[] array82 = array81;
					if (array82 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array83 = new int[array82.Length];
					for (int num14 = 0; num14 < array83.Length; num14++)
					{
						array83[num14] = val22.Invoke(array82[num14]);
					}
					obj3 = array83;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(sbyte)))
				{
					sbyte[] array84 = (sbyte[])(object)array67;
					sbyte[] array85 = array84;
					FSharpFunc<sbyte, int> val23 = new _0024Ndarray.CopyFrom_0040189_002D20();
					sbyte[] array86 = array85;
					if (array86 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array87 = new int[array86.Length];
					for (int num15 = 0; num15 < array87.Length; num15++)
					{
						array87[num15] = val23.Invoke(array86[num15]);
					}
					obj3 = array87;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(byte)))
				{
					byte[] array88 = (byte[])(object)array67;
					byte[] array89 = array88;
					FSharpFunc<byte, int> val24 = new _0024Ndarray.CopyFrom_0040189_002D21();
					byte[] array90 = array89;
					if (array90 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array91 = new int[array90.Length];
					for (int num16 = 0; num16 < array91.Length; num16++)
					{
						array91[num16] = val24.Invoke(array90[num16]);
					}
					obj3 = array91;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(bool)))
				{
					bool[] array92 = (bool[])(object)array67;
					bool[] array93 = array92;
					FSharpFunc<bool, int> val25 = new _0024Ndarray.CopyFrom_0040189_002D22();
					bool[] array94 = array93;
					if (array94 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array95 = new int[array94.Length];
					for (int num17 = 0; num17 < array95.Length; num17++)
					{
						array95[num17] = val25.Invoke(array94[num17]);
					}
					obj3 = array95;
				}
				else
				{
					aa[] array96 = array67;
					FSharpFunc<aa, int> val26 = new _0024Ndarray.CopyFrom_0040189_002D23<aa>();
					aa[] array97 = array96;
					if (array97 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array98 = new int[array97.Length];
					for (int num18 = 0; num18 < array98.Length; num18++)
					{
						array98[num18] = val26.Invoke(array97[num18]);
					}
					obj3 = array98;
				}
				int[] array99 = (int[])obj3;
				int[] data4 = array99;
				SyncCopyFromCPUUnchecked(data4);
				break;
			}
			case 4:
			{
				aa[] array34 = data;
				object obj2;
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(float)))
				{
					float[] array35 = (float[])(object)array34;
					float[] array36 = array35;
					FSharpFunc<float, long> val11 = new _0024Ndarray.CopyFrom_0040190_002D24();
					float[] array37 = array36;
					if (array37 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array38 = new long[array37.Length];
					for (int num3 = 0; num3 < array38.Length; num3++)
					{
						array38[num3] = val11.Invoke(array37[num3]);
					}
					obj2 = array38;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(double)))
				{
					double[] array39 = (double[])(object)array34;
					double[] array40 = array39;
					FSharpFunc<double, long> val12 = new _0024Ndarray.CopyFrom_0040190_002D25();
					double[] array41 = array40;
					if (array41 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array42 = new long[array41.Length];
					for (int num4 = 0; num4 < array42.Length; num4++)
					{
						array42[num4] = val12.Invoke(array41[num4]);
					}
					obj2 = array42;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(int)))
				{
					int[] array43 = (int[])(object)array34;
					int[] array44 = array43;
					FSharpFunc<int, long> val13 = new _0024Ndarray.CopyFrom_0040190_002D26();
					int[] array45 = array44;
					if (array45 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array46 = new long[array45.Length];
					for (int num5 = 0; num5 < array46.Length; num5++)
					{
						array46[num5] = val13.Invoke(array45[num5]);
					}
					obj2 = array46;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(long)))
				{
					obj2 = (long[])(object)array34;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(decimal)))
				{
					decimal[] array47 = (decimal[])(object)array34;
					decimal[] array48 = array47;
					FSharpFunc<decimal, long> val14 = new _0024Ndarray.CopyFrom_0040190_002D27();
					decimal[] array49 = array48;
					if (array49 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array50 = new long[array49.Length];
					for (int num6 = 0; num6 < array50.Length; num6++)
					{
						array50[num6] = val14.Invoke(array49[num6]);
					}
					obj2 = array50;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(sbyte)))
				{
					sbyte[] array51 = (sbyte[])(object)array34;
					sbyte[] array52 = array51;
					FSharpFunc<sbyte, long> val15 = new _0024Ndarray.CopyFrom_0040190_002D28();
					sbyte[] array53 = array52;
					if (array53 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array54 = new long[array53.Length];
					for (int num7 = 0; num7 < array54.Length; num7++)
					{
						array54[num7] = val15.Invoke(array53[num7]);
					}
					obj2 = array54;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(byte)))
				{
					byte[] array55 = (byte[])(object)array34;
					byte[] array56 = array55;
					FSharpFunc<byte, long> val16 = new _0024Ndarray.CopyFrom_0040190_002D29();
					byte[] array57 = array56;
					if (array57 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array58 = new long[array57.Length];
					for (int num8 = 0; num8 < array58.Length; num8++)
					{
						array58[num8] = val16.Invoke(array57[num8]);
					}
					obj2 = array58;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(bool)))
				{
					bool[] array59 = (bool[])(object)array34;
					bool[] array60 = array59;
					FSharpFunc<bool, long> val17 = new _0024Ndarray.CopyFrom_0040190_002D30();
					bool[] array61 = array60;
					if (array61 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array62 = new long[array61.Length];
					for (int num9 = 0; num9 < array62.Length; num9++)
					{
						array62[num9] = val17.Invoke(array61[num9]);
					}
					obj2 = array62;
				}
				else
				{
					aa[] array63 = array34;
					FSharpFunc<aa, long> val18 = new _0024Ndarray.CopyFrom_0040190_002D31<aa>();
					aa[] array64 = array63;
					if (array64 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array65 = new long[array64.Length];
					for (int num10 = 0; num10 < array65.Length; num10++)
					{
						array65[num10] = val18.Invoke(array64[num10]);
					}
					obj2 = array65;
				}
				long[] array66 = (long[])obj2;
				long[] data3 = array66;
				SyncCopyFromCPUUnchecked(data3);
				break;
			}
			case 5:
			{
				aa[] array133 = data;
				object obj5;
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(float)))
				{
					float[] array134 = (float[])(object)array133;
					float[] array135 = array134;
					FSharpFunc<float, sbyte> val35 = new _0024Ndarray.CopyFrom_0040191_002D32();
					float[] array136 = array135;
					if (array136 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array137 = new sbyte[array136.Length];
					for (int num27 = 0; num27 < array137.Length; num27++)
					{
						array137[num27] = val35.Invoke(array136[num27]);
					}
					obj5 = array137;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(double)))
				{
					double[] array138 = (double[])(object)array133;
					double[] array139 = array138;
					FSharpFunc<double, sbyte> val36 = new _0024Ndarray.CopyFrom_0040191_002D33();
					double[] array140 = array139;
					if (array140 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array141 = new sbyte[array140.Length];
					for (int num28 = 0; num28 < array141.Length; num28++)
					{
						array141[num28] = val36.Invoke(array140[num28]);
					}
					obj5 = array141;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(int)))
				{
					int[] array142 = (int[])(object)array133;
					int[] array143 = array142;
					FSharpFunc<int, sbyte> val37 = new _0024Ndarray.CopyFrom_0040191_002D34();
					int[] array144 = array143;
					if (array144 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array145 = new sbyte[array144.Length];
					for (int num29 = 0; num29 < array145.Length; num29++)
					{
						array145[num29] = val37.Invoke(array144[num29]);
					}
					obj5 = array145;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(long)))
				{
					long[] array146 = (long[])(object)array133;
					long[] array147 = array146;
					FSharpFunc<long, sbyte> val38 = new _0024Ndarray.CopyFrom_0040191_002D35();
					long[] array148 = array147;
					if (array148 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array149 = new sbyte[array148.Length];
					for (int num30 = 0; num30 < array149.Length; num30++)
					{
						array149[num30] = val38.Invoke(array148[num30]);
					}
					obj5 = array149;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(decimal)))
				{
					decimal[] array150 = (decimal[])(object)array133;
					decimal[] array151 = array150;
					FSharpFunc<decimal, sbyte> val39 = new _0024Ndarray.CopyFrom_0040191_002D36();
					decimal[] array152 = array151;
					if (array152 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array153 = new sbyte[array152.Length];
					for (int num31 = 0; num31 < array153.Length; num31++)
					{
						array153[num31] = val39.Invoke(array152[num31]);
					}
					obj5 = array153;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(sbyte)))
				{
					obj5 = (sbyte[])(object)array133;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(byte)))
				{
					byte[] array154 = (byte[])(object)array133;
					byte[] array155 = array154;
					FSharpFunc<byte, sbyte> val40 = new _0024Ndarray.CopyFrom_0040191_002D37();
					byte[] array156 = array155;
					if (array156 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array157 = new sbyte[array156.Length];
					for (int num32 = 0; num32 < array157.Length; num32++)
					{
						array157[num32] = val40.Invoke(array156[num32]);
					}
					obj5 = array157;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(bool)))
				{
					bool[] array158 = (bool[])(object)array133;
					bool[] array159 = array158;
					FSharpFunc<bool, sbyte> val41 = new _0024Ndarray.CopyFrom_0040191_002D38();
					bool[] array160 = array159;
					if (array160 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array161 = new sbyte[array160.Length];
					for (int num33 = 0; num33 < array161.Length; num33++)
					{
						array161[num33] = val41.Invoke(array160[num33]);
					}
					obj5 = array161;
				}
				else
				{
					aa[] array162 = array133;
					FSharpFunc<aa, sbyte> val42 = new _0024Ndarray.CopyFrom_0040191_002D39<aa>();
					aa[] array163 = array162;
					if (array163 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array164 = new sbyte[array163.Length];
					for (int num34 = 0; num34 < array164.Length; num34++)
					{
						array164[num34] = val42.Invoke(array163[num34]);
					}
					obj5 = array164;
				}
				sbyte[] array165 = (sbyte[])obj5;
				sbyte[] data6 = array165;
				SyncCopyFromCPUUnchecked(data6);
				break;
			}
			case 6:
			{
				aa[] array166 = data;
				object obj6;
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(float)))
				{
					float[] array167 = (float[])(object)array166;
					float[] array168 = array167;
					FSharpFunc<float, byte> val43 = new _0024Ndarray.CopyFrom_0040192_002D40();
					float[] array169 = array168;
					if (array169 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array170 = new byte[array169.Length];
					for (int num35 = 0; num35 < array170.Length; num35++)
					{
						array170[num35] = val43.Invoke(array169[num35]);
					}
					obj6 = array170;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(double)))
				{
					double[] array171 = (double[])(object)array166;
					double[] array172 = array171;
					FSharpFunc<double, byte> val44 = new _0024Ndarray.CopyFrom_0040192_002D41();
					double[] array173 = array172;
					if (array173 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array174 = new byte[array173.Length];
					for (int num36 = 0; num36 < array174.Length; num36++)
					{
						array174[num36] = val44.Invoke(array173[num36]);
					}
					obj6 = array174;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(int)))
				{
					int[] array175 = (int[])(object)array166;
					int[] array176 = array175;
					FSharpFunc<int, byte> val45 = new _0024Ndarray.CopyFrom_0040192_002D42();
					int[] array177 = array176;
					if (array177 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array178 = new byte[array177.Length];
					for (int num37 = 0; num37 < array178.Length; num37++)
					{
						array178[num37] = val45.Invoke(array177[num37]);
					}
					obj6 = array178;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(long)))
				{
					long[] array179 = (long[])(object)array166;
					long[] array180 = array179;
					FSharpFunc<long, byte> val46 = new _0024Ndarray.CopyFrom_0040192_002D43();
					long[] array181 = array180;
					if (array181 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array182 = new byte[array181.Length];
					for (int num38 = 0; num38 < array182.Length; num38++)
					{
						array182[num38] = val46.Invoke(array181[num38]);
					}
					obj6 = array182;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(decimal)))
				{
					decimal[] array183 = (decimal[])(object)array166;
					decimal[] array184 = array183;
					FSharpFunc<decimal, byte> val47 = new _0024Ndarray.CopyFrom_0040192_002D44();
					decimal[] array185 = array184;
					if (array185 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array186 = new byte[array185.Length];
					for (int num39 = 0; num39 < array186.Length; num39++)
					{
						array186[num39] = val47.Invoke(array185[num39]);
					}
					obj6 = array186;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(sbyte)))
				{
					sbyte[] array187 = (sbyte[])(object)array166;
					sbyte[] array188 = array187;
					FSharpFunc<sbyte, byte> val48 = new _0024Ndarray.CopyFrom_0040192_002D45();
					sbyte[] array189 = array188;
					if (array189 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array190 = new byte[array189.Length];
					for (int num40 = 0; num40 < array190.Length; num40++)
					{
						array190[num40] = val48.Invoke(array189[num40]);
					}
					obj6 = array190;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(byte)))
				{
					obj6 = (byte[])(object)array166;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(bool)))
				{
					bool[] array191 = (bool[])(object)array166;
					bool[] array192 = array191;
					FSharpFunc<bool, byte> val49 = new _0024Ndarray.CopyFrom_0040192_002D46();
					bool[] array193 = array192;
					if (array193 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array194 = new byte[array193.Length];
					for (int num41 = 0; num41 < array194.Length; num41++)
					{
						array194[num41] = val49.Invoke(array193[num41]);
					}
					obj6 = array194;
				}
				else
				{
					aa[] array195 = array166;
					FSharpFunc<aa, byte> val50 = new _0024Ndarray.CopyFrom_0040192_002D47<aa>();
					aa[] array196 = array195;
					if (array196 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array197 = new byte[array196.Length];
					for (int num42 = 0; num42 < array197.Length; num42++)
					{
						array197[num42] = val50.Invoke(array196[num42]);
					}
					obj6 = array197;
				}
				byte[] array198 = (byte[])obj6;
				byte[] data7 = array198;
				SyncCopyFromCPUUnchecked(data7);
				break;
			}
			case 7:
			{
				aa[] array = data;
				object obj;
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(float)))
				{
					float[] array2 = (float[])(object)array;
					float[] array3 = array2;
					FSharpFunc<float, bool> val2 = new _0024Ndarray.CopyFrom_0040193_002D48();
					float[] array4 = array3;
					if (array4 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array5 = new bool[array4.Length];
					for (int i = 0; i < array5.Length; i++)
					{
						array5[i] = val2.Invoke(array4[i]);
					}
					obj = array5;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(double)))
				{
					double[] array6 = (double[])(object)array;
					double[] array7 = array6;
					FSharpFunc<double, bool> val3 = new _0024Ndarray.CopyFrom_0040193_002D49();
					double[] array8 = array7;
					if (array8 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array9 = new bool[array8.Length];
					for (int j = 0; j < array9.Length; j++)
					{
						array9[j] = val3.Invoke(array8[j]);
					}
					obj = array9;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(int)))
				{
					int[] array10 = (int[])(object)array;
					int[] array11 = array10;
					FSharpFunc<int, bool> val4 = new _0024Ndarray.CopyFrom_0040193_002D50();
					int[] array12 = array11;
					if (array12 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array13 = new bool[array12.Length];
					for (int k = 0; k < array13.Length; k++)
					{
						array13[k] = val4.Invoke(array12[k]);
					}
					obj = array13;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(long)))
				{
					long[] array14 = (long[])(object)array;
					long[] array15 = array14;
					FSharpFunc<long, bool> val5 = new _0024Ndarray.CopyFrom_0040193_002D51();
					long[] array16 = array15;
					if (array16 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array17 = new bool[array16.Length];
					for (int l = 0; l < array17.Length; l++)
					{
						array17[l] = val5.Invoke(array16[l]);
					}
					obj = array17;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(decimal)))
				{
					decimal[] array18 = (decimal[])(object)array;
					decimal[] array19 = array18;
					FSharpFunc<decimal, bool> val6 = new _0024Ndarray.CopyFrom_0040193_002D52();
					decimal[] array20 = array19;
					if (array20 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array21 = new bool[array20.Length];
					for (int m = 0; m < array21.Length; m++)
					{
						array21[m] = val6.Invoke(array20[m]);
					}
					obj = array21;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(sbyte)))
				{
					sbyte[] array22 = (sbyte[])(object)array;
					sbyte[] array23 = array22;
					FSharpFunc<sbyte, bool> val7 = new _0024Ndarray.CopyFrom_0040193_002D53();
					sbyte[] array24 = array23;
					if (array24 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array25 = new bool[array24.Length];
					for (int n = 0; n < array25.Length; n++)
					{
						array25[n] = val7.Invoke(array24[n]);
					}
					obj = array25;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(byte)))
				{
					byte[] array26 = (byte[])(object)array;
					byte[] array27 = array26;
					FSharpFunc<byte, bool> val8 = new _0024Ndarray.CopyFrom_0040193_002D54();
					byte[] array28 = array27;
					if (array28 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array29 = new bool[array28.Length];
					for (int num = 0; num < array29.Length; num++)
					{
						array29[num] = val8.Invoke(array28[num]);
					}
					obj = array29;
				}
				else if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(aa), typeof(bool)))
				{
					obj = (bool[])(object)array;
				}
				else
				{
					aa[] array30 = array;
					FSharpFunc<aa, bool> val9 = new _0024Ndarray.CopyFrom_0040193_002D55<aa>();
					aa[] array31 = array30;
					if (array31 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array32 = new bool[array31.Length];
					for (int num2 = 0; num2 < array32.Length; num2++)
					{
						array32[num2] = val9.Invoke(array31[num2]);
					}
					obj = array32;
				}
				bool[] array33 = (bool[])obj;
				bool[] data2 = array33;
				SyncCopyFromCPUUnchecked(data2);
				break;
			}
			}
		}

		public static NDArray CopyFrom(Array data, Context ctx)
		{
			Type etype = data.GetType().GetElementType();
			DataType dtype = MXNetSharp.DataType.FromNetType(etype);
			int rank = data.Rank;
			FSharpFunc<int, int> val = new _0024Ndarray.shape_0040200_002D3(data);
			if (rank < 0)
			{
				object[] args = new object[3]
				{
					ErrorStrings.get_InputMustBeNonNegativeString(),
					"count",
					rank
				};
				string message = string.Format("{0}\n{1} = {2}", args);
				throw new ArgumentException(message, "count");
			}
			int[] array = new int[rank];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(i);
			}
			int[] shape = array;
			NDArray a = new NDArray(shape, ctx, FSharpOption<MXNetSharp.DataType>.Some(dtype), FSharpOption<bool>.Some(false));
			a.CopyFrom(data);
			return a;
		}

		public static NDArray CopyFrom(NDArray data, Context ctx)
		{
			return data.CopyTo(ctx);
		}

		public static NDArray CopyFrom(NDArray data)
		{
			return CopyFrom(data, data.Context);
		}

		public static NDArray CopyFrom(float[] data, IEnumerable<int> shape, Context ctx)
		{
			return ConvertCopyFrom(data, shape, ctx, FSharpOption<MXNetSharp.DataType>.Some(MXNetSharp.DataType.Float32));
		}

		public static NDArray CopyFrom(double[] data, IEnumerable<int> shape, Context ctx)
		{
			return ConvertCopyFrom(data, shape, ctx, FSharpOption<MXNetSharp.DataType>.Some(MXNetSharp.DataType.Float64));
		}

		public static NDArray CopyFrom(int[] data, IEnumerable<int> shape, Context ctx)
		{
			return ConvertCopyFrom(data, shape, ctx, FSharpOption<MXNetSharp.DataType>.Some(MXNetSharp.DataType.Int32));
		}

		public static NDArray CopyFrom(long[] data, IEnumerable<int> shape, Context ctx)
		{
			return ConvertCopyFrom(data, shape, ctx, FSharpOption<MXNetSharp.DataType>.Some(MXNetSharp.DataType.Int64));
		}

		public static NDArray CopyFrom(sbyte[] data, IEnumerable<int> shape, Context ctx)
		{
			return ConvertCopyFrom(data, shape, ctx, FSharpOption<MXNetSharp.DataType>.Some(MXNetSharp.DataType.Int8));
		}

		public static NDArray CopyFrom(byte[] data, IEnumerable<int> shape, Context ctx)
		{
			return ConvertCopyFrom(data, shape, ctx, FSharpOption<MXNetSharp.DataType>.Some(MXNetSharp.DataType.UInt8));
		}

		public void SyncCopyFromCPU(int[] data)
		{
			MXNDArray.syncCopyFromCPU(handle.UnsafeHandle, data);
		}

		public void Set(float value)
		{
			AtomicSymbolCreator setValue = AtomicSymbolCreator.FromName("_set_value");
			int num = MXNDArray.imperativeInvokeInto(setValue.AtomicSymbolCreatorHandle, null, new IntPtr[1]
			{
				handle.UnsafeHandle
			}, new string[1]
			{
				"src"
			}, new string[1]
			{
				value.ToString()
			});
			int num2 = num;
		}

		public static IDictionary<string, NDArray> Load(string file)
		{
			Tuple<string[], IntPtr[]> tuple = MXNDArray.load(file);
			string[] names = tuple.Item1;
			IntPtr[] handles = tuple.Item2;
			IntPtr[] array = handles;
			FSharpFunc<IntPtr, NDArray> val = new _0024Ndarray.arrs_0040228_002D1();
			IntPtr[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			NDArray[] array3 = new NDArray[array2.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = val.Invoke(array2[i]);
			}
			NDArray[] arrs = array3;
			Tuple<string, NDArray>[] array4 = ArrayModule.Zip<string, NDArray>(names, arrs);
			Tuple<string, NDArray>[] array5 = array4;
			return ExtraTopLevelOperators.CreateDictionary<string, NDArray>((IEnumerable<Tuple<string, NDArray>>)array5);
		}

		public static void WaitAll()
		{
			MXNDArray.waitAll();
		}

		public static NDArray operator +(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_plus_scalar", inputs, array);
		}

		public static NDArray operator +(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_plus_scalar", inputs, array);
		}

		public static NDArray operator +(NDArray x, NDArray y)
		{
			return invoke1("elemwise_add", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public static NDArray op_DotPlus(NDArray x, NDArray y)
		{
			return invoke1("broadcast_plus", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutPlus(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_plus_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutPlus(NDArray y)
		{
			string opName = "elemwise_add";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutPlus_0040238(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutPlusBroadcast(NDArray y)
		{
			string opName = "broadcast_add";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutPlusBroadcast_0040239(this, opName, inputs);
		}

		public static NDArray operator -(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_minus_scalar", inputs, array);
		}

		public static NDArray operator -(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_rminus_scalar", inputs, array);
		}

		public static NDArray operator -(NDArray x, NDArray y)
		{
			return invoke1("elemwise_sub", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public static NDArray op_DotMinus(NDArray x, NDArray y)
		{
			return invoke1("broadcast_sub", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutSubstract(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_sub_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutSubstract(NDArray y)
		{
			string opName = "elemwise_sub";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutSubstract_0040247(this, opName, inputs);
		}

		public NDArray MutSubstractFrom(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_rminus_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutSubstractFrom(NDArray y)
		{
			string opName = "elemwise_sub";
			NDArray[] inputs = new NDArray[2]
			{
				y,
				this
			};
			return new _0024Ndarray.MutSubstractFrom_0040249(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutSubstractBroadcast(NDArray y)
		{
			string opName = "broadcast_sub";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutSubstractBroadcast_0040250(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutSubstractBroadcastFrom(NDArray y)
		{
			string opName = "broadcast_sub";
			NDArray[] inputs = new NDArray[2]
			{
				y,
				this
			};
			return new _0024Ndarray.MutSubstractBroadcastFrom_0040251(this, opName, inputs);
		}

		public static NDArray operator /(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_div_scalar", inputs, array);
		}

		public static NDArray operator /(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_rdiv_scalar", inputs, array);
		}

		public static NDArray operator /(NDArray x, NDArray y)
		{
			return invoke1("elemwise_div", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public static NDArray op_DotDivide(NDArray x, NDArray y)
		{
			return invoke1("broadcast_div", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutDividedBy(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_div_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutDividedBy(NDArray y)
		{
			string opName = "elemwise_div";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutDividedBy_0040259(this, opName, inputs);
		}

		public NDArray MutDividedInto(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_rdiv_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutDividedInto(NDArray y)
		{
			string opName = "elemwise_div";
			NDArray[] inputs = new NDArray[2]
			{
				y,
				this
			};
			return new _0024Ndarray.MutDividedInto_0040261(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutDividedBroadcastBy(NDArray y)
		{
			string opName = "broadcast_div";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutDividedBroadcastBy_0040262(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutDividedBroadcastInto(NDArray y)
		{
			string opName = "broadcast_div";
			NDArray[] inputs = new NDArray[2]
			{
				y,
				this
			};
			return new _0024Ndarray.MutDividedBroadcastInto_0040263(this, opName, inputs);
		}

		public static NDArray operator *(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_mul_scalar", inputs, array);
		}

		public static NDArray operator *(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_mul_scalar", inputs, array);
		}

		public static NDArray operator *(NDArray x, NDArray y)
		{
			return invoke1("elemwise_mul", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public static NDArray op_DotMultiply(NDArray x, NDArray y)
		{
			return invoke1("broadcast_mul", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutMultiply(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_mul_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutMultiply(NDArray y)
		{
			string opName = "elemwise_mul";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutMultiply_0040271(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutMultiplyBroadcast(NDArray y)
		{
			string opName = "broadcast_mul";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutMultiplyBroadcast_0040272(this, opName, inputs);
		}

		public static NDArray Pow(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_power_scalar", inputs, array);
		}

		public static NDArray Pow(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_rpower_scalar", inputs, array);
		}

		public static NDArray Pow(NDArray x, NDArray y)
		{
			return invoke1("_power", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public static NDArray ApplyPow(double x, NDArray y)
		{
			return Pow(x, y);
		}

		public static NDArray op_DotMultiplyMultiply(NDArray x, NDArray y)
		{
			return invoke1("broadcast_power", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutPower(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_power_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutPower(NDArray y)
		{
			string opName = "_power";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutPower_0040285(this, opName, inputs);
		}

		public NDArray MutPowerBaseOf(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_rpower_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutPowerBaseOf(NDArray y)
		{
			string opName = "_power";
			NDArray[] inputs = new NDArray[2]
			{
				y,
				this
			};
			return new _0024Ndarray.MutPowerBaseOf_0040287(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutPowerBroadcast(NDArray y)
		{
			string opName = "broadcast_power";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutPowerBroadcast_0040288(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutPowerBaseOfBroadcast(NDArray y)
		{
			string opName = "broadcast_power";
			NDArray[] inputs = new NDArray[2]
			{
				y,
				this
			};
			return new _0024Ndarray.MutPowerBaseOfBroadcast_0040289(this, opName, inputs);
		}

		public NDArray Negate()
		{
			double y = -1.0;
			return y * this;
		}

		public static NDArray operator -(NDArray x)
		{
			return x.Negate();
		}

		public NDArray MutNegate()
		{
			return MutMultiply(-1.0);
		}

		public static NDArray operator %(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_mod_scalar", inputs, array);
		}

		public static NDArray operator %(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_rmod_scalar", inputs, array);
		}

		public static NDArray operator %(NDArray x, NDArray y)
		{
			return invoke1("broadcast_mod", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutMod(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_mod_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutMod(NDArray y)
		{
			string opName = "broadcast_mod";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutMod_0040300(this, opName, inputs);
		}

		public NDArray MutModOf(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_rmod_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutModOf(NDArray y)
		{
			string opName = "broadcast_mod";
			NDArray[] inputs = new NDArray[2]
			{
				y,
				this
			};
			return new _0024Ndarray.MutModOf_0040302(this, opName, inputs);
		}

		public static NDArray op_DotEquals(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_equal_scalar", inputs, array);
		}

		public static NDArray op_DotEquals(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_equal_scalar", inputs, array);
		}

		public static NDArray op_DotEquals(NDArray x, NDArray y)
		{
			return invoke1("broadcast_equal", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutEqual(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_mod_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutEqual(NDArray y)
		{
			string opName = "broadcast_mod";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutEqual_0040308(this, opName, inputs);
		}

		public static NDArray op_DotLessGreater(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_not_equal_scalar", inputs, array);
		}

		public static NDArray op_DotLessGreater(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_not_equal_scalar", inputs, array);
		}

		public static NDArray op_DotLessGreater(NDArray x, NDArray y)
		{
			return invoke1("broadcast_not_equal", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutNotEqual(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_not_equal_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutNotEqual(NDArray y)
		{
			string opName = "broadcast_not_equal";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutNotEqual_0040314(this, opName, inputs);
		}

		public static NDArray op_DotGreater(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_greater_scalar", inputs, array);
		}

		public static NDArray op_DotGreater(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_lesser_scalar", inputs, array);
		}

		public static NDArray op_DotGreater(NDArray x, NDArray y)
		{
			return invoke1("broadcast_greater", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutGreater(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_greater_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutGreater(NDArray y)
		{
			string opName = "broadcast_greater";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutGreater_0040320(this, opName, inputs);
		}

		public static NDArray op_DotLess(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_lesser_scalar", inputs, array);
		}

		public static NDArray op_DotLess(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_greater_scalar", inputs, array);
		}

		public static NDArray op_DotLess(NDArray x, NDArray y)
		{
			return invoke1("broadcast_lesser", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutLesser(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_lesser_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutLesser(NDArray y)
		{
			string opName = "broadcast_lesser";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutLesser_0040326(this, opName, inputs);
		}

		public static NDArray op_DotGreaterEquals(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_greater_equal_scalar", inputs, array);
		}

		public static NDArray op_DotGreaterEquals(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_lesser_equal_scalar", inputs, array);
		}

		public static NDArray op_DotGreaterEquals(NDArray x, NDArray y)
		{
			return invoke1("broadcast_greater_equal", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutGreaterOrEqual(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_greater_equal_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutGreaterOrEqual(NDArray y)
		{
			string opName = "broadcast_greater_equal";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutGreaterOrEqual_0040332(this, opName, inputs);
		}

		public static NDArray op_DotLessEquals(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_lesser_equal_scalar", inputs, array);
		}

		public static NDArray op_DotLessEquals(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_greater_equal_scalar", inputs, array);
		}

		public static NDArray op_DotLessEquals(NDArray x, NDArray y)
		{
			return invoke1("broadcast_lesser_equal", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutLesserOrEqual(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_lesser_equal_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutLesserOrEqual(NDArray y)
		{
			string opName = "broadcast_lesser_equal";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutLesserOrEqual_0040338(this, opName, inputs);
		}

		public static NDArray op_DotAmpAmp(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_logical_and_scalar", inputs, array);
		}

		public static NDArray op_DotAmpAmp(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_logical_and_scalar", inputs, array);
		}

		public static NDArray op_DotAmpAmp(NDArray x, NDArray y)
		{
			return invoke1("_logical_and", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public static NDArray op_DotDotAmpAmp(NDArray x, NDArray y)
		{
			return invoke1("broadcast_logical_and", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutLogicalAnd(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_logical_and_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutLogicalAnd(NDArray y)
		{
			string opName = "_logical_and";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutLogicalAnd_0040346(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutLogicalAndBroadcast(NDArray y)
		{
			string opName = "broadcast_logical_and";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutLogicalAndBroadcast_0040347(this, opName, inputs);
		}

		public static NDArray op_DotBarBar(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_logical_or_scalar", inputs, array);
		}

		public static NDArray op_DotBarBar(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_logical_or_scalar", inputs, array);
		}

		public static NDArray op_DotBarBar(NDArray x, NDArray y)
		{
			return invoke1("_logical_or", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public static NDArray op_DotDotBarBar(NDArray x, NDArray y)
		{
			return invoke1("broadcast_logical_or", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutLogicalOr(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_logical_or_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutLogicalOr(NDArray y)
		{
			string opName = "_logical_or";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutLogicalOr_0040355(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutLogicalOrBroadcast(NDArray y)
		{
			string opName = "broadcast_logical_or";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutLogicalOrBroadcast_0040356(this, opName, inputs);
		}

		public static NDArray op_DotHatHat(NDArray x, double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_logical_xor_scalar", inputs, array);
		}

		public static NDArray op_DotHatHat(double y, NDArray x)
		{
			NDArray[] inputs = new NDArray[1]
			{
				x
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return invoke1("_logical_xor_scalar", inputs, array);
		}

		public static NDArray op_DotHatHat(NDArray x, NDArray y)
		{
			return invoke1("_logical_xor", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public static NDArray op_DotDotHatHat(NDArray x, NDArray y)
		{
			return invoke1("broadcast_logical_xor", new NDArray[2]
			{
				x,
				y
			}, ArrayModule.Empty<Tuple<string, string>>());
		}

		public NDArray MutLogicalXor(double y)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "scalar";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(y));
			return mutInvoke(this, "_logical_xor_scalar", inputs, array);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutLogicalXor(NDArray y)
		{
			string opName = "_logical_xor";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutLogicalXor_0040363(this, opName, inputs);
		}

		public FSharpFunc<Tuple<string, string>[], NDArray> MutLogicalXorBroadcast(NDArray y)
		{
			string opName = "broadcast_logical_xor";
			NDArray[] inputs = new NDArray[2]
			{
				this,
				y
			};
			return new _0024Ndarray.MutLogicalXorBroadcast_0040364(this, opName, inputs);
		}

		public NDArray Exp()
		{
			return ArrayModule.Head<NDArray>(invoke("exp", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Exp(NDArray x)
		{
			return x.Exp();
		}

		public NDArray Log()
		{
			return ArrayModule.Head<NDArray>(invoke("log", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Log(NDArray x)
		{
			return x.Log();
		}

		public NDArray Abs()
		{
			return ArrayModule.Head<NDArray>(invoke("abs", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Abs(NDArray x)
		{
			return x.Abs();
		}

		public NDArray Acos()
		{
			return ArrayModule.Head<NDArray>(invoke("arccos", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Acos(NDArray x)
		{
			return x.Acos();
		}

		public NDArray Asin()
		{
			return ArrayModule.Head<NDArray>(invoke("arcsin", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Asin(NDArray x)
		{
			return x.Asin();
		}

		public NDArray Atan()
		{
			return ArrayModule.Head<NDArray>(invoke("arctan", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Atan(NDArray x)
		{
			return x.Atan();
		}

		public NDArray Ceiling()
		{
			return ArrayModule.Head<NDArray>(invoke("ceil", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Ceiling(NDArray x)
		{
			return x.Ceiling();
		}

		public NDArray Floor()
		{
			return ArrayModule.Head<NDArray>(invoke("floor", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Floor(NDArray x)
		{
			return x.Floor();
		}

		public NDArray Truncate()
		{
			return ArrayModule.Head<NDArray>(invoke("trunc", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Truncate(NDArray x)
		{
			return x.Truncate();
		}

		public NDArray Round()
		{
			return ArrayModule.Head<NDArray>(invoke("round", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Round(NDArray x)
		{
			return x.Round();
		}

		public NDArray Log10()
		{
			return ArrayModule.Head<NDArray>(invoke("log10", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Log10(NDArray x)
		{
			return x.Log10();
		}

		public NDArray Sqrt()
		{
			return ArrayModule.Head<NDArray>(invoke("sqrt", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Sqrt(NDArray x)
		{
			return x.Sqrt();
		}

		public NDArray Cos()
		{
			return ArrayModule.Head<NDArray>(invoke("cos", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Cos(NDArray x)
		{
			return x.Cos();
		}

		public NDArray Cosh()
		{
			return ArrayModule.Head<NDArray>(invoke("cosh", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Cosh(NDArray x)
		{
			return x.Cosh();
		}

		public NDArray Sin()
		{
			return ArrayModule.Head<NDArray>(invoke("sin", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Sin(NDArray x)
		{
			return x.Sin();
		}

		public NDArray Sinh()
		{
			return ArrayModule.Head<NDArray>(invoke("sinh", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Sinh(NDArray x)
		{
			return x.Sinh();
		}

		public NDArray Tan()
		{
			return ArrayModule.Head<NDArray>(invoke("tan", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Tan(NDArray x)
		{
			return x.Tan();
		}

		public NDArray Tanh()
		{
			return ArrayModule.Head<NDArray>(invoke("tanh", new NDArray[1]
			{
				this
			}, ArrayModule.Empty<Tuple<string, string>>()));
		}

		public static NDArray Tanh(NDArray x)
		{
			return x.Tanh();
		}

		public NDArray Slice(IEnumerable<string> startIndices, IEnumerable<string> endIndices, IEnumerable<string> stepIndices)
		{
			string text = StringModule.Concat(",", startIndices);
			FSharpFunc<string, string> val = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("(%s)"));
			string text2 = text;
			string b = val.Invoke(text2);
			string text3 = StringModule.Concat(",", endIndices);
			FSharpFunc<string, string> val2 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("(%s)"));
			string text4 = text3;
			string e = val2.Invoke(text4);
			string text5 = StringModule.Concat(",", stepIndices);
			FSharpFunc<string, string> val3 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("(%s)"));
			string text6 = text5;
			string s = val3.Invoke(text6);
			return ArrayModule.Head<NDArray>(invoke("slice", new NDArray[1]
			{
				this
			}, new Tuple<string, string>[3]
			{
				new Tuple<string, string>("begin", b),
				new Tuple<string, string>("end", e),
				new Tuple<string, string>("step", s)
			}));
		}

		public NDArray At(int index)
		{
			IntPtr unsafeHandle = UnsafeHandle;
			IntPtr @out = IntPtr.Zero;
			MXNetSharp.Interop.Helper.throwOnError("MXNDArrayAt", CApi.MXNDArrayAt(unsafeHandle, (uint)index, out @out));
			return new NDArray(@out);
		}

		internal void SetItemAtIntex(int[] a, object v)
		{
			object[] b = ArrayModule.ZeroCreate<object>(a.Length + 1);
			for (int i = 0; i < a.Length; i++)
			{
				b[i] = a[i];
			}
			b[b.Length - 1] = v;
			SetSlice(b);
		}

		public void set_Item(params int[] a, decimal v)
		{
			SetItemAtIntex(a, v);
		}

		public void set_Item(params int[] a, float v)
		{
			SetItemAtIntex(a, v);
		}

		public void set_Item(params int[] a, int v)
		{
			SetItemAtIntex(a, v);
		}

		public NDArray GetSlice(params object[] a)
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			FSharpTypeFunc str = (FSharpTypeFunc)(object)new _0024Ndarray.str_0040432();
			if (a.Length == 0)
			{
				return this;
			}
			int[] shape = Shape;
			int ndim = shape.Length;
			List<FSharpValueOption<long>> b2 = new List<FSharpValueOption<long>>();
			List<FSharpValueOption<long>> e2 = new List<FSharpValueOption<long>>();
			List<FSharpValueOption<long>> s4 = new List<FSharpValueOption<long>>();
			List<int> sliceAxis = new List<int>();
			List<int> newAxis = new List<int>();
			int i = 0;
			int sliceAx = 0;
			for (; i < a.Length; i++)
			{
				object obj = a[i];
				if (!IntrinsicFunctions.TypeTestGeneric<int>(obj))
				{
					if (!IntrinsicFunctions.TypeTestGeneric<FSharpOption<int>>(obj))
					{
						SliceRange sliceRange = obj as SliceRange;
						if (sliceRange == null)
						{
							NewAxis newAxis2 = obj as NewAxis;
							if (newAxis2 != null)
							{
								newAxis.Add(sliceAx);
								continue;
							}
							FSharpFunc<object, Unit> val = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<object, Unit>, Unit>((PrintfFormat<FSharpFunc<object, Unit>, Unit, string, Unit>)(object)new PrintfFormat<FSharpFunc<object, Unit>, Unit, string, Unit, object>("invalid argument to get slice %A"));
							object obj2 = a[i];
							val.Invoke(obj2);
							continue;
						}
						SliceRange r = sliceRange;
						FSharpOption<long> start4 = r.Start;
						if (start4 != null)
						{
							FSharpOption<long> val2 = start4;
							long v3 = val2.get_Value();
							b2.Add(FSharpValueOption<long>.NewValueSome(v3));
						}
						else
						{
							b2.Add(FSharpValueOption<long>.get_ValueNone());
						}
						FSharpOption<long> stop4 = r.Stop;
						if (stop4 != null)
						{
							FSharpOption<long> val3 = stop4;
							long v2 = val3.get_Value();
							e2.Add(FSharpValueOption<long>.NewValueSome((v2 < 0) ? v2 : (v2 + 1)));
						}
						else
						{
							e2.Add(FSharpValueOption<long>.get_ValueNone());
						}
						FSharpOption<long> step4 = r.Step;
						if (step4 != null)
						{
							FSharpOption<long> val4 = step4;
							long v = val4.get_Value();
							s4.Add(FSharpValueOption<long>.NewValueSome(v));
						}
						else
						{
							s4.Add(FSharpValueOption<long>.get_ValueNone());
						}
						sliceAxis.Add(sliceAx);
						sliceAx++;
					}
					else
					{
						FSharpOption<int> o3 = (FSharpOption<int>)obj;
						FSharpOption<int> o4 = OptionModule.Map<int, int>((FSharpFunc<int, int>)new _0024Ndarray.o2_0040456_002D1(), (FSharpOption<int>)a[i + 1]);
						FSharpOption<int> val5 = o3;
						FSharpValueOption<long> item;
						if (val5 != null)
						{
							FSharpOption<int> val6 = val5;
							int o2 = val6.get_Value();
							item = FSharpValueOption<long>.NewValueSome((long)o2);
						}
						else
						{
							item = FSharpValueOption<long>.get_ValueNone();
						}
						b2.Add(item);
						FSharpOption<int> val7 = o4;
						FSharpValueOption<long> item2;
						if (val7 != null)
						{
							FSharpOption<int> val8 = val7;
							int o = val8.get_Value();
							item2 = FSharpValueOption<long>.NewValueSome((long)o);
						}
						else
						{
							item2 = FSharpValueOption<long>.get_ValueNone();
						}
						e2.Add(item2);
						s4.Add(FSharpValueOption<long>.get_ValueNone());
						sliceAxis.Add(sliceAx);
						sliceAx++;
						i++;
					}
				}
				else
				{
					int idx = (int)obj;
					b2.Add(FSharpValueOption<long>.NewValueSome((long)idx));
					e2.Add(FSharpValueOption<long>.NewValueSome((idx < 0) ? idx : ((long)idx + 1L)));
					s4.Add(FSharpValueOption<long>.get_ValueNone());
					if (sliceAx < ndim && (-shape[sliceAx] > idx || shape[sliceAx] < idx))
					{
						FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>> clo = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>>, Unit>((PrintfFormat<FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>>, Unit, string, Unit>)(object)new PrintfFormat<FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>>, Unit, string, Unit, Tuple<int, int, int>>("Index %d is out of bounds for axis %d with size %d"));
						FSharpFunc<int, int>.InvokeFast<int, Unit>((FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>>)new _0024Ndarray.GetSlice_0040452(clo), idx, sliceAx, shape[sliceAx]);
					}
					sliceAxis.Add(sliceAx);
					sliceAx++;
				}
			}
			FSharpFunc<int, Tuple<long, long, long>> indices = new _0024Ndarray.indices_0040481(shape, b2, e2, s4, sliceAxis);
			bool subset = false;
			int n = b2.Count - 1;
			bool continuous = true;
			while (continuous && n >= 0)
			{
				Tuple<long, long, long> tuple = indices.Invoke(n);
				long stop3 = tuple.Item2;
				long step3 = tuple.Item3;
				long start3 = tuple.Item1;
				int num8;
				if (step3 > 0)
				{
					long num4 = stop3 - start3;
					long num5 = 0L;
					double num6 = (double)((num4 >= num5) ? num4 : num5) / (double)step3;
					double num7 = num6;
					num8 = (int)num7;
				}
				else
				{
					long num9 = stop3 - start3;
					long num10 = 0L;
					double num11 = (double)((num9 >= num10) ? num10 : num9) / (double)step3;
					double num12 = num11;
					num8 = (int)num12;
				}
				int num3 = num8;
				if (num3 != 1 && (subset || step3 != 1))
				{
					continuous = false;
				}
				else if (num3 != shape[n])
				{
					subset = true;
				}
				n--;
			}
			NDArray nDArray2;
			if (continuous)
			{
				long flatBegin = 0L;
				long flatEnd3 = 0L;
				for (int m = 0; m < shape.Length; m++)
				{
					flatBegin *= shape[m];
					flatEnd3 *= shape[m];
					if (m < b2.Count)
					{
						Tuple<long, long, long> tuple2 = indices.Invoke(m);
						long s2 = tuple2.Item3;
						long e = tuple2.Item2;
						long b = tuple2.Item1;
						if (s2 < 0)
						{
							flatBegin = flatBegin + e - 1;
							flatEnd3 += b;
						}
						else
						{
							flatBegin += b;
							flatEnd3 = flatEnd3 + e - 1;
						}
					}
					else
					{
						flatEnd3 = flatEnd3 + shape[m] - 1;
					}
				}
				flatEnd3++;
				NDArray flat = Reshape(-1);
				NDArray nDArray;
				if (LibFeature.INT64_TENSOR_SIZE)
				{
					nDArray = new NDArray(MXNDArray.slice64(flat.UnsafeHandle, flatBegin, flatEnd3));
				}
				else
				{
					IntPtr unsafeHandle = flat.UnsafeHandle;
					long num13 = flatBegin;
					long num14 = flatEnd3;
					IntPtr @out = IntPtr.Zero;
					MXNetSharp.Interop.Helper.throwOnError("MXNDArraySlice", CApi.MXNDArraySlice(unsafeHandle, (uint)num13, (uint)num14, out @out));
					nDArray = new NDArray(@out);
				}
				NDArray slicedFlat = nDArray;
				int[] s3 = ArrayModule.ZeroCreate<int>(shape.Length);
				for (int l = shape.Length - 1; l >= 0; l--)
				{
					Tuple<long, long, long> tuple3 = (l < b2.Count) ? indices.Invoke(l) : new Tuple<long, long, long>(0L, shape[l], 1L);
					long stop2 = tuple3.Item2;
					long step2 = tuple3.Item3;
					long start2 = tuple3.Item1;
					int num19;
					if (step2 > 0)
					{
						long num15 = stop2 - start2;
						long num16 = 0L;
						double num17 = (double)((num15 >= num16) ? num15 : num16) / (double)step2;
						double num18 = num17;
						num19 = (int)num18;
					}
					else
					{
						long num20 = stop2 - start2;
						long num21 = 0L;
						double num22 = (double)((num20 >= num21) ? num21 : num20) / (double)step2;
						double num23 = num22;
						num19 = (int)num23;
					}
					int num2 = s3[l] = num19;
				}
				int[] slicedShape = s3;
				nDArray2 = slicedFlat.Reshape(slicedShape);
			}
			else
			{
				List<FSharpValueOption<long>> list = b2;
				FSharpFunc<FSharpValueOption<long>, string> val9 = new _0024Ndarray.sliced_0040547();
				List<FSharpValueOption<long>> list2 = list;
				IEnumerable<string> startIndices = SeqModule.Map<FSharpValueOption<long>, string>(val9, (IEnumerable<FSharpValueOption<long>>)list2);
				List<FSharpValueOption<long>> list3 = e2;
				FSharpFunc<FSharpValueOption<long>, string> val10 = new _0024Ndarray.sliced_0040547_002D1();
				List<FSharpValueOption<long>> list4 = list3;
				IEnumerable<string> endIndices = SeqModule.Map<FSharpValueOption<long>, string>(val10, (IEnumerable<FSharpValueOption<long>>)list4);
				List<FSharpValueOption<long>> list5 = s4;
				FSharpFunc<FSharpValueOption<long>, string> val11 = new _0024Ndarray.sliced_0040547_002D2();
				List<FSharpValueOption<long>> list6 = list5;
				nDArray2 = Slice(startIndices, endIndices, SeqModule.Map<FSharpValueOption<long>, string>(val11, (IEnumerable<FSharpValueOption<long>>)list6));
			}
			NDArray sliced = nDArray2;
			if (newAxis.Count == 0)
			{
				return sliced;
			}
			List<int> s = new List<int>();
			int j = 0;
			for (int k = 0; k < shape.Length; k++)
			{
				for (; j < newAxis.Count && newAxis[j] == k; j++)
				{
					s.Add(1);
				}
				Tuple<long, long, long> tuple4 = (k < b2.Count) ? indices.Invoke(k) : new Tuple<long, long, long>(0L, shape[k], 1L);
				long stop = tuple4.Item2;
				long step = tuple4.Item3;
				long start = tuple4.Item1;
				int num28;
				if (step > 0)
				{
					long num24 = stop - start;
					long num25 = 0L;
					double num26 = (double)((num24 >= num25) ? num24 : num25) / (double)step;
					double num27 = num26;
					num28 = (int)num27;
				}
				else
				{
					long num29 = stop - start;
					long num30 = 0L;
					double num31 = (double)((num29 >= num30) ? num30 : num29) / (double)step;
					double num32 = num31;
					num28 = (int)num32;
				}
				int num = num28;
				s.Add(num);
			}
			for (; j < newAxis.Count && newAxis[j] == shape.Length; j++)
			{
				s.Add(1);
			}
			int[] newShape = s.ToArray();
			return sliced.Reshape(newShape);
		}

		public void SetSlice(params object[] a)
		{
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			FSharpTypeFunc str = (FSharpTypeFunc)(object)new _0024Ndarray.str_0040577_002D1();
			if (a.Length == 0)
			{
				return;
			}
			int[] shape = Shape;
			int ndim = shape.Length;
			List<FSharpValueOption<long>> b2 = new List<FSharpValueOption<long>>();
			List<FSharpValueOption<long>> e2 = new List<FSharpValueOption<long>>();
			List<FSharpValueOption<long>> s2 = new List<FSharpValueOption<long>>();
			List<int> sliceAxis = new List<int>();
			List<int> newAxis = new List<int>();
			int i = 0;
			int sliceAx = 0;
			for (; i < a.Length - 1; i++)
			{
				object obj = a[i];
				if (!IntrinsicFunctions.TypeTestGeneric<int>(obj))
				{
					if (!IntrinsicFunctions.TypeTestGeneric<FSharpOption<int>>(obj))
					{
						SliceRange sliceRange = obj as SliceRange;
						if (sliceRange == null)
						{
							NewAxis newAxis2 = obj as NewAxis;
							if (newAxis2 != null)
							{
								newAxis.Add(sliceAx);
								continue;
							}
							FSharpFunc<object, Unit> val = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<object, Unit>, Unit>((PrintfFormat<FSharpFunc<object, Unit>, Unit, string, Unit>)(object)new PrintfFormat<FSharpFunc<object, Unit>, Unit, string, Unit, object>("invalid argument to get slice %A"));
							object obj2 = a[i];
							val.Invoke(obj2);
							continue;
						}
						SliceRange r = sliceRange;
						FSharpOption<long> start = r.Start;
						if (start != null)
						{
							FSharpOption<long> val2 = start;
							long v25 = val2.get_Value();
							b2.Add(FSharpValueOption<long>.NewValueSome(v25));
						}
						else
						{
							b2.Add(FSharpValueOption<long>.get_ValueNone());
						}
						FSharpOption<long> stop = r.Stop;
						if (stop != null)
						{
							FSharpOption<long> val3 = stop;
							long v24 = val3.get_Value();
							e2.Add(FSharpValueOption<long>.NewValueSome((v24 < 0) ? v24 : (v24 + 1)));
						}
						else
						{
							e2.Add(FSharpValueOption<long>.get_ValueNone());
						}
						FSharpOption<long> step = r.Step;
						if (step != null)
						{
							FSharpOption<long> val4 = step;
							long v23 = val4.get_Value();
							s2.Add(FSharpValueOption<long>.NewValueSome(v23));
						}
						else
						{
							s2.Add(FSharpValueOption<long>.get_ValueNone());
						}
						sliceAxis.Add(sliceAx);
						sliceAx++;
					}
					else
					{
						FSharpOption<int> o3 = (FSharpOption<int>)obj;
						FSharpOption<int> o4 = OptionModule.Map<int, int>((FSharpFunc<int, int>)new _0024Ndarray.o2_0040601_002D2(), (FSharpOption<int>)a[i + 1]);
						FSharpOption<int> val5 = o3;
						FSharpValueOption<long> item;
						if (val5 != null)
						{
							FSharpOption<int> val6 = val5;
							int o2 = val6.get_Value();
							item = FSharpValueOption<long>.NewValueSome((long)o2);
						}
						else
						{
							item = FSharpValueOption<long>.get_ValueNone();
						}
						b2.Add(item);
						FSharpOption<int> val7 = o4;
						FSharpValueOption<long> item2;
						if (val7 != null)
						{
							FSharpOption<int> val8 = val7;
							int o = val8.get_Value();
							item2 = FSharpValueOption<long>.NewValueSome((long)o);
						}
						else
						{
							item2 = FSharpValueOption<long>.get_ValueNone();
						}
						e2.Add(item2);
						s2.Add(FSharpValueOption<long>.get_ValueNone());
						sliceAxis.Add(sliceAx);
						sliceAx++;
						i++;
					}
				}
				else
				{
					int idx = (int)obj;
					b2.Add(FSharpValueOption<long>.NewValueSome((long)idx));
					e2.Add(FSharpValueOption<long>.NewValueSome((idx < 0) ? idx : ((long)idx + 1L)));
					s2.Add(FSharpValueOption<long>.get_ValueNone());
					if (sliceAx < ndim && (-shape[sliceAx] > idx || shape[sliceAx] < idx))
					{
						FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>> clo = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>>, Unit>((PrintfFormat<FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>>, Unit, string, Unit>)(object)new PrintfFormat<FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>>, Unit, string, Unit, Tuple<int, int, int>>("Index %d is out of bounds for axis %d with size %d"));
						FSharpFunc<int, int>.InvokeFast<int, Unit>((FSharpFunc<int, FSharpFunc<int, FSharpFunc<int, Unit>>>)new _0024Ndarray.SetSlice_0040597(clo), idx, sliceAx, shape[sliceAx]);
					}
					sliceAxis.Add(sliceAx);
					sliceAx++;
				}
			}
			FSharpFunc<int, Tuple<long, long, long>> indices = new _0024Ndarray.indices_0040624_002D1(shape, b2, e2, s2, sliceAxis);
			int[] indexedShape = SeqModule.ToArray<int>((IEnumerable<int>)(object)new _0024Ndarray.indexedShape_0040632(s2, indices, 0L, 0L, 0L, null, 0, 0));
			int num;
			if (HashCompare.GenericEqualityIntrinsic<int[]>(indexedShape, Shape))
			{
				List<FSharpValueOption<long>> list = s2;
				FSharpFunc<FSharpValueOption<long>, bool> val9 = new _0024Ndarray.SetSlice_0040643_002D3();
				List<FSharpValueOption<long>> list2 = list;
				bool flag = SeqModule.Exists<FSharpValueOption<long>>(val9, (IEnumerable<FSharpValueOption<long>>)list2);
				bool flag2 = flag;
				num = ((!flag2) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				int length = ArrayModule.Reduce<int>((FSharpFunc<int, FSharpFunc<int, int>>)(object)new _0024Ndarray.length_0040645(), Shape);
				object obj3 = a[a.Length - 1];
				NDArray nDArray = obj3 as NDArray;
				if (nDArray == null)
				{
					if (!IntrinsicFunctions.TypeTestGeneric<double>(obj3))
					{
						if (!IntrinsicFunctions.TypeTestGeneric<decimal>(obj3))
						{
							if (!IntrinsicFunctions.TypeTestGeneric<int>(obj3))
							{
								if (!IntrinsicFunctions.TypeTestGeneric<float>(obj3))
								{
									if (!IntrinsicFunctions.TypeTestGeneric<long>(obj3))
									{
										if (!IntrinsicFunctions.TypeTestGeneric<sbyte>(obj3))
										{
											if (!IntrinsicFunctions.TypeTestGeneric<byte>(obj3))
											{
												double[] array = obj3 as double[];
												if (array == null)
												{
													decimal[] array2 = obj3 as decimal[];
													if (array2 == null)
													{
														int[] array3 = obj3 as int[];
														if (array3 == null)
														{
															float[] array4 = obj3 as float[];
															if (array4 == null)
															{
																long[] array5 = obj3 as long[];
																if (array5 == null)
																{
																	byte[] array6 = obj3 as byte[];
																	if (array6 == null)
																	{
																		sbyte[] array7 = obj3 as sbyte[];
																		if (array7 == null)
																		{
																			IEnumerable<double> enumerable = obj3 as IEnumerable<double>;
																			if (enumerable == null)
																			{
																				IEnumerable<decimal> enumerable2 = obj3 as IEnumerable<decimal>;
																				if (enumerable2 == null)
																				{
																					IEnumerable<int> enumerable3 = obj3 as IEnumerable<int>;
																					if (enumerable3 == null)
																					{
																						IEnumerable<float> enumerable4 = obj3 as IEnumerable<float>;
																						if (enumerable4 == null)
																						{
																							IEnumerable<long> enumerable5 = obj3 as IEnumerable<long>;
																							if (enumerable5 == null)
																							{
																								IEnumerable<byte> enumerable6 = obj3 as IEnumerable<byte>;
																								if (enumerable6 == null)
																								{
																									IEnumerable<sbyte> enumerable7 = obj3 as IEnumerable<sbyte>;
																									if (enumerable7 != null)
																									{
																										IEnumerable<sbyte> v8 = enumerable7;
																										CopyFrom(SeqModule.ToArray<sbyte>(SeqModule.Take<sbyte>(length, v8)));
																									}
																									else
																									{
																										FSharpFunc<string, Unit> val10 = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, Unit>, Unit>((PrintfFormat<FSharpFunc<string, Unit>, Unit, string, Unit>)(object)new PrintfFormat<FSharpFunc<string, Unit>, Unit, string, Unit, string>("Cannot assign slice from type %s"));
																										string fullName = a[a.Length - 1].GetType().FullName;
																										val10.Invoke(fullName);
																									}
																								}
																								else
																								{
																									IEnumerable<byte> v9 = enumerable6;
																									CopyFrom(SeqModule.ToArray<byte>(SeqModule.Take<byte>(length, v9)));
																								}
																							}
																							else
																							{
																								IEnumerable<long> v10 = enumerable5;
																								CopyFrom(SeqModule.ToArray<long>(SeqModule.Take<long>(length, v10)));
																							}
																						}
																						else
																						{
																							IEnumerable<float> v11 = enumerable4;
																							CopyFrom(SeqModule.ToArray<float>(SeqModule.Take<float>(length, v11)));
																						}
																					}
																					else
																					{
																						IEnumerable<int> v12 = enumerable3;
																						CopyFrom(SeqModule.ToArray<int>(SeqModule.Take<int>(length, v12)));
																					}
																				}
																				else
																				{
																					IEnumerable<decimal> v13 = enumerable2;
																					CopyFrom(SeqModule.ToArray<decimal>(SeqModule.Take<decimal>(length, v13)));
																				}
																			}
																			else
																			{
																				IEnumerable<double> v14 = enumerable;
																				CopyFrom(SeqModule.ToArray<double>(SeqModule.Take<double>(length, v14)));
																			}
																		}
																		else
																		{
																			sbyte[] v15 = array7;
																			CopyFrom(v15);
																		}
																	}
																	else
																	{
																		byte[] v16 = array6;
																		CopyFrom(v16);
																	}
																}
																else
																{
																	long[] v17 = array5;
																	CopyFrom(v17);
																}
															}
															else
															{
																float[] v18 = array4;
																CopyFrom(v18);
															}
														}
														else
														{
															int[] v19 = array3;
															CopyFrom(v19);
														}
													}
													else
													{
														decimal[] v20 = array2;
														CopyFrom(v20);
													}
												}
												else
												{
													double[] v21 = array;
													CopyFrom(v21);
												}
											}
											else
											{
												byte v7 = (byte)obj3;
												NDArray nDArray2 = MutFull(v7);
												NDArray nDArray3 = nDArray2;
											}
										}
										else
										{
											sbyte v6 = (sbyte)obj3;
											NDArray nDArray4 = MutFull(v6);
											NDArray nDArray5 = nDArray4;
										}
									}
									else
									{
										long v5 = (long)obj3;
										NDArray nDArray6 = MutFull(v5);
										NDArray nDArray7 = nDArray6;
									}
								}
								else
								{
									float v4 = (float)obj3;
									NDArray nDArray8 = MutFull(v4);
									NDArray nDArray9 = nDArray8;
								}
							}
							else
							{
								int v3 = (int)obj3;
								NDArray nDArray10 = MutFull(v3);
								NDArray nDArray11 = nDArray10;
							}
						}
						else
						{
							decimal v2 = (decimal)obj3;
							NDArray nDArray12 = MutFull(v2);
							NDArray nDArray13 = nDArray12;
						}
					}
					else
					{
						double v = (double)obj3;
						NDArray nDArray14 = MutFull(v);
						NDArray nDArray15 = nDArray14;
					}
				}
				else
				{
					NDArray v22 = nDArray;
					SafeNDArrayHandle nDArrayHandle = v22.NDArrayHandle;
					SafeNDArrayHandle nDArrayHandle2 = NDArrayHandle;
					if (!HashCompare.GenericEqualityIntrinsic<SafeNDArrayHandle>(nDArrayHandle, nDArrayHandle2))
					{
						NDArray v26 = v22.BroadcastTo(Shape);
						v26.CopyTo(this);
						_ = null;
					}
				}
				return;
			}
			List<FSharpValueOption<long>> list3 = b2;
			FSharpFunc<FSharpValueOption<long>, string> val11 = new _0024Ndarray.b_0040675();
			List<FSharpValueOption<long>> list4 = list3;
			string text = StringModule.Concat(",", SeqModule.Map<FSharpValueOption<long>, string>(val11, (IEnumerable<FSharpValueOption<long>>)list4));
			FSharpFunc<string, string> val12 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("(%s)"));
			string text2 = text;
			string b = val12.Invoke(text2);
			List<FSharpValueOption<long>> list5 = e2;
			FSharpFunc<FSharpValueOption<long>, string> val13 = new _0024Ndarray.e_0040676();
			List<FSharpValueOption<long>> list6 = list5;
			string text3 = StringModule.Concat(",", SeqModule.Map<FSharpValueOption<long>, string>(val13, (IEnumerable<FSharpValueOption<long>>)list6));
			FSharpFunc<string, string> val14 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("(%s)"));
			string text4 = text3;
			string e = val14.Invoke(text4);
			List<FSharpValueOption<long>> list7 = s2;
			FSharpFunc<FSharpValueOption<long>, string> val15 = new _0024Ndarray.s_0040677();
			List<FSharpValueOption<long>> list8 = list7;
			string text5 = StringModule.Concat(",", SeqModule.Map<FSharpValueOption<long>, string>(val15, (IEnumerable<FSharpValueOption<long>>)list8));
			FSharpFunc<string, string> val16 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("(%s)"));
			string text6 = text5;
			string s = val16.Invoke(text6);
			FSharpTypeFunc scalar = (FSharpTypeFunc)(object)new _0024Ndarray.scalar_0040678(this, b, e, s);
			object obj4 = a[a.Length - 1];
			if (!IntrinsicFunctions.TypeTestGeneric<double>(obj4))
			{
				if (!IntrinsicFunctions.TypeTestGeneric<decimal>(obj4))
				{
					if (!IntrinsicFunctions.TypeTestGeneric<int>(obj4))
					{
						if (!IntrinsicFunctions.TypeTestGeneric<float>(obj4))
						{
							if (!IntrinsicFunctions.TypeTestGeneric<long>(obj4))
							{
								NDArray nDArray16 = obj4 as NDArray;
								if (nDArray16 != null)
								{
									NDArray y = nDArray16;
									NDArray nDArray17 = mutInvoke(this, "_slice_assign", new NDArray[2]
									{
										this,
										y
									}, new Tuple<string, string>[3]
									{
										new Tuple<string, string>("begin", b),
										new Tuple<string, string>("end", e),
										new Tuple<string, string>("step", s)
									});
									NDArray nDArray18 = nDArray17;
								}
								else
								{
									object q = obj4;
									FSharpFunc<string, FSharpFunc<object, Unit>> clo2 = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, FSharpFunc<object, Unit>>, Unit>((PrintfFormat<FSharpFunc<string, FSharpFunc<object, Unit>>, Unit, string, Unit>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<object, Unit>>, Unit, string, Unit, Tuple<string, object>>("Unhandled slice assign type %s with value %A"));
									FSharpFunc<string, object>.InvokeFast<Unit>((FSharpFunc<string, FSharpFunc<object, Unit>>)new _0024Ndarray.SetSlice_0040689_002D4(clo2), q.GetType().Name, q);
								}
							}
							else
							{
								long x5 = (long)obj4;
								long num2 = x5;
								NDArray[] inputs = new NDArray[1]
								{
									this
								};
								Tuple<string, string>[] obj5 = new Tuple<string, string>[4]
								{
									new Tuple<string, string>("begin", b),
									new Tuple<string, string>("end", e),
									new Tuple<string, string>("step", s),
									null
								};
								string item3 = "scalar";
								long num3 = num2;
								long num4 = num3;
								ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
								long num5 = num4;
								ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
								obj5[3] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(num5));
								NDArray nDArray19 = mutInvoke(this, "_slice_assign_scalar", inputs, obj5);
								NDArray nDArray20 = nDArray19;
							}
						}
						else
						{
							float x4 = (float)obj4;
							float num6 = x4;
							NDArray[] inputs2 = new NDArray[1]
							{
								this
							};
							Tuple<string, string>[] obj6 = new Tuple<string, string>[4]
							{
								new Tuple<string, string>("begin", b),
								new Tuple<string, string>("end", e),
								new Tuple<string, string>("step", s),
								null
							};
							string item4 = "scalar";
							float num7 = num6;
							float num8 = num7;
							ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
							float num9 = num8;
							ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
							obj6[3] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString(num9));
							NDArray nDArray21 = mutInvoke(this, "_slice_assign_scalar", inputs2, obj6);
							NDArray nDArray22 = nDArray21;
						}
					}
					else
					{
						int x3 = (int)obj4;
						int num10 = x3;
						NDArray[] inputs3 = new NDArray[1]
						{
							this
						};
						Tuple<string, string>[] obj7 = new Tuple<string, string>[4]
						{
							new Tuple<string, string>("begin", b),
							new Tuple<string, string>("end", e),
							new Tuple<string, string>("step", s),
							null
						};
						string item5 = "scalar";
						int num11 = num10;
						int num12 = num11;
						ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
						int num13 = num12;
						ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
						obj7[3] = new Tuple<string, string>(item5, ValueStringExtensions.ValueString(num13));
						NDArray nDArray23 = mutInvoke(this, "_slice_assign_scalar", inputs3, obj7);
						NDArray nDArray24 = nDArray23;
					}
				}
				else
				{
					decimal x2 = (decimal)obj4;
					decimal num14 = x2;
					NDArray[] inputs4 = new NDArray[1]
					{
						this
					};
					Tuple<string, string>[] obj8 = new Tuple<string, string>[4]
					{
						new Tuple<string, string>("begin", b),
						new Tuple<string, string>("end", e),
						new Tuple<string, string>("step", s),
						null
					};
					string item6 = "scalar";
					decimal num15 = num14;
					decimal num16 = num15;
					ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
					decimal num17 = num16;
					ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
					obj8[3] = new Tuple<string, string>(item6, ValueStringExtensions.ValueString(num17));
					NDArray nDArray25 = mutInvoke(this, "_slice_assign_scalar", inputs4, obj8);
					NDArray nDArray26 = nDArray25;
				}
			}
			else
			{
				double x = (double)obj4;
				double num18 = x;
				NDArray[] inputs5 = new NDArray[1]
				{
					this
				};
				Tuple<string, string>[] obj9 = new Tuple<string, string>[4]
				{
					new Tuple<string, string>("begin", b),
					new Tuple<string, string>("end", e),
					new Tuple<string, string>("step", s),
					null
				};
				string item7 = "scalar";
				double num19 = num18;
				double num20 = num19;
				ValueStringExtensions valueStringExtensions9 = ValueStringExtensions.ValueStringExtensions;
				double num21 = num20;
				ValueStringExtensions valueStringExtensions10 = valueStringExtensions9;
				obj9[3] = new Tuple<string, string>(item7, ValueStringExtensions.ValueString(num21));
				NDArray nDArray27 = mutInvoke(this, "_slice_assign_scalar", inputs5, obj9);
				NDArray nDArray28 = nDArray27;
			}
		}

		public NDArray Concat(int dim, params NDArray[] data)
		{
			Tuple<string, string>[] array = new Tuple<string, string>[2];
			string item = "num_args";
			int num = data.Length;
			int num2 = num;
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			int num3 = num2;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(num3));
			string item2 = "dim";
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(dim));
			return invoke1("Concat", data, array);
		}

		public NDArray Concat(int dim, IEnumerable<NDArray> data)
		{
			return Concat(dim, SeqModule.ToArray<NDArray>(data));
		}

		public NDArray SwapAxis(int dim1, int dim2)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[2];
			string item = "dim1";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString(dim1));
			string item2 = "dim2";
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(dim2));
			return invoke1("SwapAxis", inputs, array);
		}

		public NDArray Reshape(params int[] dims)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "shape";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)dims));
			return invoke1("Reshape", inputs, array);
		}

		public NDArray Reshape(IEnumerable<int> dims)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "shape";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)dims));
			return invoke1("Reshape", inputs, array);
		}

		public NDArray ReverseReshape(params int[] dims)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[2];
			string item = "shape";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)dims));
			string item2 = "reverse";
			bool flag = true;
			bool flag2 = flag;
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			bool flag3 = flag2;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString((object)flag3));
			return invoke1("Reshape", inputs, array);
		}

		public NDArray ReverseReshape(IEnumerable<int> dims)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[2];
			string item = "shape";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)dims));
			string item2 = "reverse";
			bool flag = true;
			bool flag2 = flag;
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			bool flag3 = flag2;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString((object)flag3));
			return invoke1("Reshape", inputs, array);
		}

		public NDArray BroadcastTo(IEnumerable<int> shape)
		{
			NDArray[] inputs = new NDArray[1]
			{
				this
			};
			Tuple<string, string>[] array = new Tuple<string, string>[1];
			string item = "shape";
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)shape));
			return invoke1("broadcast_to", inputs, array);
		}

		public NDArray MutFull(double value)
		{
			NDArray[] inputs = ArrayModule.Empty<NDArray>();
			Tuple<string, string>[] array = new Tuple<string, string>[4];
			string item = "shape";
			int[] shape = Shape;
			int[] array2 = shape;
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			int[] x = array2;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)x));
			string item2 = "value";
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(value));
			string item3 = "dtype";
			DataType value2 = DataType.get_Value();
			DataType dataType = value2;
			ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
			DataType x2 = dataType;
			ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
			array[2] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x2));
			string item4 = "ctx";
			Context context = Context;
			Context context2 = context;
			ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
			Context x3 = context2;
			ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
			array[3] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString(x3));
			return mutInvoke(this, "_full", inputs, array);
		}

		public NDArray MutFull(float value)
		{
			NDArray[] inputs = ArrayModule.Empty<NDArray>();
			Tuple<string, string>[] array = new Tuple<string, string>[4];
			string item = "shape";
			int[] shape = Shape;
			int[] array2 = shape;
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			int[] x = array2;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)x));
			string item2 = "value";
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(value));
			string item3 = "dtype";
			DataType value2 = DataType.get_Value();
			DataType dataType = value2;
			ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
			DataType x2 = dataType;
			ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
			array[2] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x2));
			string item4 = "ctx";
			Context context = Context;
			Context context2 = context;
			ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
			Context x3 = context2;
			ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
			array[3] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString(x3));
			return mutInvoke(this, "_full", inputs, array);
		}

		public NDArray MutFull(decimal value)
		{
			NDArray[] inputs = ArrayModule.Empty<NDArray>();
			Tuple<string, string>[] array = new Tuple<string, string>[4];
			string item = "shape";
			int[] shape = Shape;
			int[] array2 = shape;
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			int[] x = array2;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)x));
			string item2 = "value";
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(value));
			string item3 = "dtype";
			DataType value2 = DataType.get_Value();
			DataType dataType = value2;
			ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
			DataType x2 = dataType;
			ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
			array[2] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x2));
			string item4 = "ctx";
			Context context = Context;
			Context context2 = context;
			ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
			Context x3 = context2;
			ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
			array[3] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString(x3));
			return mutInvoke(this, "_full", inputs, array);
		}

		public NDArray MutFull(int value)
		{
			NDArray[] inputs = ArrayModule.Empty<NDArray>();
			Tuple<string, string>[] array = new Tuple<string, string>[4];
			string item = "shape";
			int[] shape = Shape;
			int[] array2 = shape;
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			int[] x = array2;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)x));
			string item2 = "value";
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(value));
			string item3 = "dtype";
			DataType value2 = DataType.get_Value();
			DataType dataType = value2;
			ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
			DataType x2 = dataType;
			ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
			array[2] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x2));
			string item4 = "ctx";
			Context context = Context;
			Context context2 = context;
			ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
			Context x3 = context2;
			ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
			array[3] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString(x3));
			return mutInvoke(this, "_full", inputs, array);
		}

		public NDArray MutFull(long value)
		{
			NDArray[] inputs = ArrayModule.Empty<NDArray>();
			Tuple<string, string>[] array = new Tuple<string, string>[4];
			string item = "shape";
			int[] shape = Shape;
			int[] array2 = shape;
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			int[] x = array2;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)x));
			string item2 = "value";
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(value));
			string item3 = "dtype";
			DataType value2 = DataType.get_Value();
			DataType dataType = value2;
			ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
			DataType x2 = dataType;
			ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
			array[2] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x2));
			string item4 = "ctx";
			Context context = Context;
			Context context2 = context;
			ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
			Context x3 = context2;
			ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
			array[3] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString(x3));
			return mutInvoke(this, "_full", inputs, array);
		}

		public NDArray MutFull(sbyte value)
		{
			NDArray[] inputs = ArrayModule.Empty<NDArray>();
			Tuple<string, string>[] array = new Tuple<string, string>[4];
			string item = "shape";
			int[] shape = Shape;
			int[] array2 = shape;
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			int[] x = array2;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)x));
			string item2 = "value";
			sbyte b = value;
			sbyte b2 = b;
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			sbyte b3 = b2;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(b3));
			string item3 = "dtype";
			DataType value2 = DataType.get_Value();
			DataType dataType = value2;
			ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
			DataType x2 = dataType;
			ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
			array[2] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x2));
			string item4 = "ctx";
			Context context = Context;
			Context context2 = context;
			ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
			Context x3 = context2;
			ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
			array[3] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString(x3));
			return mutInvoke(this, "_full", inputs, array);
		}

		public NDArray MutFull(byte value)
		{
			NDArray[] inputs = ArrayModule.Empty<NDArray>();
			Tuple<string, string>[] array = new Tuple<string, string>[4];
			string item = "shape";
			int[] shape = Shape;
			int[] array2 = shape;
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			int[] x = array2;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			array[0] = new Tuple<string, string>(item, ValueStringExtensions.ValueString((object)x));
			string item2 = "value";
			byte b = value;
			byte b2 = b;
			ValueStringExtensions valueStringExtensions3 = ValueStringExtensions.ValueStringExtensions;
			byte b3 = b2;
			ValueStringExtensions valueStringExtensions4 = valueStringExtensions3;
			array[1] = new Tuple<string, string>(item2, ValueStringExtensions.ValueString(b3));
			string item3 = "dtype";
			DataType value2 = DataType.get_Value();
			DataType dataType = value2;
			ValueStringExtensions valueStringExtensions5 = ValueStringExtensions.ValueStringExtensions;
			DataType x2 = dataType;
			ValueStringExtensions valueStringExtensions6 = valueStringExtensions5;
			array[2] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x2));
			string item4 = "ctx";
			Context context = Context;
			Context context2 = context;
			ValueStringExtensions valueStringExtensions7 = ValueStringExtensions.ValueStringExtensions;
			Context x3 = context2;
			ValueStringExtensions valueStringExtensions8 = valueStringExtensions7;
			array[3] = new Tuple<string, string>(item4, ValueStringExtensions.ValueString(x3));
			return mutInvoke(this, "_full", inputs, array);
		}

		public Array ToArray()
		{
			int[] shape = Shape;
			if (shape.Length > 0)
			{
				FSharpOption<DataType> dataType = DataType;
				Array array;
				if (dataType != null)
				{
					FSharpOption<DataType> val = dataType;
					if (val.get_Value().Tag == 0)
					{
						array = Array.CreateInstance(typeof(ushort), shape);
					}
					else
					{
						DataType dt2 = val.get_Value();
						FSharpOption<Type> type = dt2.Type;
						if (type != null)
						{
							FSharpOption<Type> val2 = type;
							Type t2 = val2.get_Value();
							array = Array.CreateInstance(t2, shape);
						}
						else
						{
							array = Array.CreateInstance(typeof(float), shape);
						}
					}
				}
				else
				{
					array = Array.CreateInstance(typeof(float), shape);
				}
				Array a = array;
				MXNDArray.syncCopyToCPUArray(UnsafeHandle, a);
				return a;
			}
			FSharpOption<DataType> dataType2 = DataType;
			if (dataType2 != null)
			{
				FSharpOption<DataType> val3 = dataType2;
				if (val3.get_Value().Tag == 0)
				{
					return Array.CreateInstance(typeof(ushort), 0);
				}
				DataType dt = val3.get_Value();
				FSharpOption<Type> type2 = dt.Type;
				if (type2 != null)
				{
					FSharpOption<Type> val4 = type2;
					Type t = val4.get_Value();
					return Array.CreateInstance(t, 0);
				}
				return Array.CreateInstance(typeof(float), 0);
			}
			return Array.CreateInstance(typeof(float), 0);
		}

		public a[] ToArray<a>()
		{
			Tuple<FSharpOption<DataType>, FSharpOption<DataType>> tuple = new Tuple<FSharpOption<DataType>, FSharpOption<DataType>>(MXNetSharp.DataType.TryFromNetType<a>(), DataType);
			if (tuple.Item1 != null)
			{
				FSharpOption<DataType> item = tuple.Item1;
				if (tuple.Item2 != null)
				{
					FSharpOption<DataType> item2 = tuple.Item2;
					DataType t2 = item2.get_Value();
					DataType value = item.get_Value();
					DataType dataType = value;
					DataType obj = t2;
					if (dataType.Equals(obj, LanguagePrimitives.get_GenericEqualityComparer()))
					{
						a[] a2 = ArrayModule.ZeroCreate<a>(Size);
						MXNDArray.syncCopyToCPU(handle.UnsafeHandle, a2);
						return a2;
					}
					NDArray[] inputs = new NDArray[1]
					{
						this
					};
					Tuple<string, string>[] array = new Tuple<string, string>[1];
					string item3 = "dtype";
					DataType dataType2 = value;
					DataType dataType3 = dataType2;
					ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
					DataType x3 = dataType3;
					ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
					array[0] = new Tuple<string, string>(item3, ValueStringExtensions.ValueString(x3));
					NDArray x2 = invoke1("cast", inputs, array);
					try
					{
						a[] a = ArrayModule.ZeroCreate<a>(Size);
						MXNDArray.syncCopyToCPU(x2.UnsafeHandle, a);
						return a;
					}
					finally
					{
						IDisposable disposable = x2 as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
							_ = null;
						}
						else
						{
							_ = null;
						}
					}
				}
				return new a[0];
			}
			throw new InvalidCastException(ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("Type %s has no corresponding MXNet type")).Invoke(typeof(a).FullName));
		}

		public float[] ToFloat32Array()
		{
			return ToArray<float>();
		}

		public double[] ToDoubleArray()
		{
			return ToArray<double>();
		}

		public int[] ToIntArray()
		{
			return ToArray<int>();
		}

		public long[] ToInt64Array()
		{
			return ToArray<long>();
		}

		public sbyte[] ToInt8Array()
		{
			return ToArray<sbyte>();
		}

		public byte[] ToUInt8Array()
		{
			return ToArray<byte>();
		}

		public a ToScalar<a>()
		{
			int sz = ArrayModule.Reduce<int>((FSharpFunc<int, FSharpFunc<int, int>>)(object)new _0024Ndarray.sz_0040759(), Shape);
			if (sz != 1)
			{
				throw new InvalidOperationException(ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int, string>>((PrintfFormat<FSharpFunc<int, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("NDArray has size %d")).Invoke(sz));
			}
			a[] a = ToArray<a>();
			Debug.Assert(a.Length == 1);
			return a[0];
		}

		public float ToFloat32Scalar()
		{
			return ToScalar<float>();
		}

		public double ToDoubleScalar()
		{
			return ToScalar<double>();
		}

		public int ToIntScalar()
		{
			return ToScalar<int>();
		}

		public long ToInt64Scalar()
		{
			return ToScalar<long>();
		}

		public sbyte ToInt8Scalar()
		{
			return ToScalar<sbyte>();
		}

		public byte ToUInt8Scalar()
		{
			return ToScalar<byte>();
		}

		public NDArray AsType(DataType dtype, bool copy)
		{
			FSharpOption<DataType> dataType = DataType;
			if (dataType != null)
			{
				FSharpOption<DataType> val = dataType;
				DataType d2 = val.get_Value();
				DataType dataType2 = d2;
				if (dataType2.Equals(dtype, LanguagePrimitives.get_GenericEqualityComparer()) && !copy)
				{
					DataType d = val.get_Value();
					return this;
				}
			}
			NDArray target = new NDArray(Shape, Context, FSharpOption<MXNetSharp.DataType>.Some(dtype), null);
			CopyTo(target);
			return target;
		}

		public NDArray AsType(DataType dtype)
		{
			return AsType(dtype, copy: true);
		}

		public override string ToString()
		{
			(DeviceTypeEnum, int) context = MXNDArray.getContext(handle.UnsafeHandle);
			int id = context.Item2;
			if (context.Item1 == (DeviceTypeEnum)0)
			{
				return ExtraTopLevelOperators.PrintFormatToString<string>((PrintfFormat<string, Unit, string, string>)(object)new PrintfFormat<string, Unit, string, string, Unit>("NDArray[EMPTY]"));
			}
			FSharpFunc<string, FSharpFunc<Context, string>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<Context, string>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<Context, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<Context, string>>, Unit, string, string, Tuple<string, Context>>("NDArray[%s] @%O"));
			_0024Ndarray.ToString_0040790_002D10 toString_0040790_002D = new _0024Ndarray.ToString_0040790_002D10(clo);
			int[] shape = Shape;
			FSharpFunc<int, string> val = new _0024Ndarray.ToString_0040790_002D12();
			int[] array = shape;
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			string[] array2 = new string[array.Length];
			FSharpFunc<string, FSharpFunc<Context, string>> val2 = toString_0040790_002D;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = val.Invoke(array[i]);
			}
			string[] array3 = array2;
			string text = ",";
			string[] array4 = array3;
			return FSharpFunc<string, Context>.InvokeFast<string>(val2, StringModule.Concat(text, (IEnumerable<string>)array4), Context);
		}

		public void Dispose(bool disposing)
		{
			if (!disposed && disposing)
			{
				handle.Dispose();
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private virtual void System_002DIDisposable_002DDispose()
		{
			Dispose();
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in System-IDisposable-Dispose
			this.System_002DIDisposable_002DDispose();
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		[CompilerGenerated]
		internal static NDArray[] invoke(string opName, NDArray[] inputs, Tuple<string, string>[] parameters)
		{
			AtomicSymbolCreator creator = AtomicSymbolCreator.FromName(opName);
			FSharpFunc<NDArray, IntPtr> val = new _0024Ndarray.inputs_004018();
			if (inputs == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr[] array = new IntPtr[inputs.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(inputs[i]);
			}
			IntPtr[] inputs2 = array;
			Tuple<string[], string[]> tuple = ArrayModule.Unzip<string, string>(parameters);
			string[] pvals = tuple.Item2;
			string[] pkeys = tuple.Item1;
			IntPtr[] array2 = MXNDArray.imperativeInvoke(creator.AtomicSymbolCreatorHandle, inputs2, pkeys, pvals);
			FSharpFunc<IntPtr, NDArray> val2 = new _0024Ndarray.clo_004021();
			IntPtr[] array3 = array2;
			if (array3 == null)
			{
				throw new ArgumentNullException("array");
			}
			NDArray[] array4 = new NDArray[array3.Length];
			for (int j = 0; j < array4.Length; j++)
			{
				array4[j] = val2.Invoke(array3[j]);
			}
			return array4;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		[CompilerGenerated]
		internal static NDArray invoke1(string opName, NDArray[] inputs, Tuple<string, string>[] parameters)
		{
			return ArrayModule.Head<NDArray>(invoke(opName, inputs, parameters));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		[CompilerGenerated]
		internal static NDArray mutInvoke(NDArray @out, string opName, NDArray[] inputs, Tuple<string, string>[] parameters)
		{
			AtomicSymbolCreator creator = AtomicSymbolCreator.FromName(opName);
			FSharpFunc<NDArray, IntPtr> val = new _0024Ndarray.inputs_004025_002D1();
			if (inputs == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr[] array = new IntPtr[inputs.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(inputs[i]);
			}
			IntPtr[] inputs2 = array;
			Tuple<string[], string[]> tuple = ArrayModule.Unzip<string, string>(parameters);
			string[] pvals = tuple.Item2;
			string[] pkeys = tuple.Item1;
			int outcount = MXNDArray.imperativeInvokeInto(creator.AtomicSymbolCreatorHandle, inputs2, new IntPtr[1]
			{
				@out.NDArrayHandle.UnsafeHandle
			}, pkeys, pvals);
			Debug.Assert(outcount == 1);
			return @out;
		}

		static NDArray()
		{
			_0024Ndarray.init_0040 = 0;
			_ = _0024Ndarray.init_0040;
		}
	}
}
