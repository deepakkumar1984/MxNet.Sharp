using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;

namespace MXNetSharp.Rtc
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class CudaKernel
	{
		internal string name;

		internal SafeCudaKernelHandle handle;

		internal CudaKernelArgument[] kernelArgs;

		public SafeCudaKernelHandle Handle => handle;

		internal CudaKernel(SafeCudaKernelHandle handle, string name, IEnumerable<CudaKernelArgument> args)
		{
			this.handle = handle;
			this.name = name;
			kernelArgs = SeqModule.ToArray<CudaKernelArgument>(args);
		}

		public unsafe void Launch(object[] args, int deviceId, Tuple<int, int, int> gridDims, Tuple<int, int, int> blockDims, uint sharedMem)
		{
			if (args.Length != kernelArgs.Length)
			{
				string paramName = "args";
				FSharpFunc<string, FSharpFunc<int, FSharpFunc<int, string>>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<int, FSharpFunc<int, string>>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<int, FSharpFunc<int, string>>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<int, FSharpFunc<int, string>>>, Unit, string, string, Tuple<string, int, int>>("CudaKernel(%s) expects %d arguments but got %d"));
				string message = FSharpFunc<string, int>.InvokeFast<int, string>((FSharpFunc<string, FSharpFunc<int, FSharpFunc<int, string>>>)new _0024Rtc.Launch_004020(clo), name, kernelArgs.Length, args.Length);
				throw new ArgumentException(message, paramName);
			}
			IntPtr[] a = ArrayModule.ZeroCreate<IntPtr>(args.Length);
			FSharpTypeFunc alloc = (FSharpTypeFunc)(object)new _0024Rtc.alloc_004022();
			for (int i = 0; i < args.Length; i++)
			{
				CudaKernelArgument j = kernelArgs[i];
				Tuple<CudaKernelArgument, object> tuple = new Tuple<CudaKernelArgument, object>(j, args[i]);
				if (tuple.Item1.IsNDArray_0040)
				{
					NDArray nDArray = tuple.Item2 as NDArray;
					if (nDArray != null)
					{
						NDArray nd = nDArray;
						if (nd.DataTypeFlag != j.Type_0040)
						{
							string name_0040 = j.Name_0040;
							FSharpFunc<TypeFlag, FSharpFunc<TypeFlag, string>> clo2 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TypeFlag, FSharpFunc<TypeFlag, string>>>((PrintfFormat<FSharpFunc<TypeFlag, FSharpFunc<TypeFlag, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TypeFlag, FSharpFunc<TypeFlag, string>>, Unit, string, string, Tuple<TypeFlag, TypeFlag>>("Expecting NDArray of type %A but is of type %A"));
							string message2 = FSharpFunc<TypeFlag, TypeFlag>.InvokeFast<string>((FSharpFunc<TypeFlag, FSharpFunc<TypeFlag, string>>)new _0024Rtc.Launch_004031_002D3(clo2), j.Type_0040, nd.DataTypeFlag);
							throw new ArgumentException(message2, name_0040);
						}
						a[i] = nd.UnsafeHandle;
						continue;
					}
					string name_00402 = j.Name_0040;
					FSharpFunc<TypeFlag, FSharpFunc<string, string>> clo3 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TypeFlag, FSharpFunc<string, string>>>((PrintfFormat<FSharpFunc<TypeFlag, FSharpFunc<string, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TypeFlag, FSharpFunc<string, string>>, Unit, string, string, Tuple<TypeFlag, string>>("Expecting NDArray of type %A but received type %A"));
					string message3 = FSharpFunc<TypeFlag, string>.InvokeFast<string>((FSharpFunc<TypeFlag, FSharpFunc<string, string>>)new _0024Rtc.Launch_004035_002D5(clo3), j.Type_0040, a.GetType().Name);
					throw new ArgumentException(message3, name_00402);
				}
				Tuple<TypeFlag, object> tuple2 = new Tuple<TypeFlag, object>(j.Type_0040, args[i]);
				IntPtr intPtr3;
				switch (tuple2.Item1)
				{
				case TypeFlag.Float32:
				{
					if (!IntrinsicFunctions.TypeTestGeneric<float>(tuple2.Item2))
					{
						goto default;
					}
					float k = (float)tuple2.Item2;
					float num11 = k;
					int num12 = 1;
					IntPtr intPtr8 = (IntPtr)stackalloc float[num12];
					IntPtr intPtr9 = intPtr8;
					int num13 = 0;
					float num14 = *(float*)((long)intPtr9 + (long)(IntPtr)(void*)((long)num13 * (long)sizeof(float))) = num11;
					intPtr3 = intPtr8;
					break;
				}
				case TypeFlag.Float64:
				{
					if (!IntrinsicFunctions.TypeTestGeneric<double>(tuple2.Item2))
					{
						goto default;
					}
					double l = (double)tuple2.Item2;
					double num19 = l;
					int num20 = 1;
					IntPtr intPtr12 = (IntPtr)stackalloc double[num20];
					IntPtr intPtr13 = intPtr12;
					int num21 = 0;
					double num22 = *(double*)((long)intPtr13 + (long)(IntPtr)(void*)((long)num21 * (long)sizeof(double))) = num19;
					intPtr3 = intPtr12;
					break;
				}
				case TypeFlag.Float16:
				{
					if (!IntrinsicFunctions.TypeTestGeneric<short>(tuple2.Item2))
					{
						goto default;
					}
					short m = (short)tuple2.Item2;
					short num5 = m;
					int num6 = 1;
					IntPtr intPtr4 = (IntPtr)stackalloc short[num6];
					IntPtr intPtr5 = intPtr4;
					int num7 = 0;
					short num8 = *(short*)((long)intPtr5 + (long)(IntPtr)(void*)((long)num7 * (long)sizeof(short))) = num5;
					intPtr3 = intPtr4;
					break;
				}
				case TypeFlag.Uint8:
				{
					if (!IntrinsicFunctions.TypeTestGeneric<byte>(tuple2.Item2))
					{
						goto default;
					}
					byte n = (byte)tuple2.Item2;
					byte b3 = n;
					int num23 = 1;
					IntPtr intPtr14 = (IntPtr)stackalloc byte[num23];
					IntPtr intPtr15 = intPtr14;
					int num24 = 0;
					byte b4 = *(byte*)((long)intPtr15 + (long)(IntPtr)(void*)((long)num24 * (long)sizeof(byte))) = b3;
					intPtr3 = intPtr14;
					break;
				}
				case TypeFlag.Int32:
				{
					if (!IntrinsicFunctions.TypeTestGeneric<int>(tuple2.Item2))
					{
						goto default;
					}
					int n2 = (int)tuple2.Item2;
					int num15 = n2;
					int num16 = 1;
					IntPtr intPtr10 = (IntPtr)stackalloc int[num16];
					IntPtr intPtr11 = intPtr10;
					int num17 = 0;
					int num18 = *(int*)((long)intPtr11 + (long)(IntPtr)(void*)((long)num17 * (long)sizeof(int))) = num15;
					intPtr3 = intPtr10;
					break;
				}
				case TypeFlag.Int8:
				{
					if (!IntrinsicFunctions.TypeTestGeneric<sbyte>(tuple2.Item2))
					{
						goto default;
					}
					sbyte n3 = (sbyte)tuple2.Item2;
					sbyte b = n3;
					int num9 = 1;
					IntPtr intPtr6 = (IntPtr)stackalloc sbyte[num9];
					IntPtr intPtr7 = intPtr6;
					int num10 = 0;
					sbyte b2 = *(sbyte*)((long)intPtr7 + (long)(IntPtr)(void*)((long)num10 * (long)sizeof(sbyte))) = b;
					intPtr3 = intPtr6;
					break;
				}
				case TypeFlag.Int64:
				{
					if (!IntrinsicFunctions.TypeTestGeneric<long>(tuple2.Item2))
					{
						goto default;
					}
					long n4 = (long)tuple2.Item2;
					long num = n4;
					int num2 = 1;
					IntPtr intPtr = (IntPtr)stackalloc long[num2];
					IntPtr intPtr2 = intPtr;
					int num3 = 0;
					long num4 = *(long*)((long)intPtr2 + (long)(IntPtr)(void*)((long)num3 * (long)sizeof(long))) = num;
					intPtr3 = intPtr;
					break;
				}
				case TypeFlag.None:
				{
					string message4 = "Kernel argument has type None";
					throw new InvalidOperationException(message4);
				}
				default:
				{
					string name_00403 = j.Name_0040;
					FSharpFunc<string, FSharpFunc<TypeFlag, FSharpFunc<string, string>>> clo4 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<TypeFlag, FSharpFunc<string, string>>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<TypeFlag, FSharpFunc<string, string>>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<TypeFlag, FSharpFunc<string, string>>>, Unit, string, string, Tuple<string, TypeFlag, string>>("Expecting argument (%s) of type %A received type %s"));
					string message5 = FSharpFunc<string, TypeFlag>.InvokeFast<string, string>((FSharpFunc<string, FSharpFunc<TypeFlag, FSharpFunc<string, string>>>)new _0024Rtc.h_004047(clo4), j.Name_0040, j.Type_0040, a.GetType().Name);
					throw new ArgumentException(message5, name_00403);
				}
				}
				IntPtr h = a[i] = intPtr3;
			}
			int gz = gridDims.Item3;
			int gy = gridDims.Item2;
			int gx = gridDims.Item1;
			int bz = blockDims.Item3;
			int by = blockDims.Item2;
			int bx = blockDims.Item1;
			MXRtc.cudaKernelCall(handle.UnsafeHandle, deviceId, a, (uint)gx, (uint)gy, (uint)gz, (uint)bx, (uint)by, (uint)bz, sharedMem);
		}

		public void Launch(object[] args, Context ctx, Tuple<int, int, int> gridDims, Tuple<int, int, int> blockDims, uint sharedMem)
		{
			if (ctx is Context.GPU)
			{
				Context.GPU gPU = (Context.GPU)ctx;
				int x = gPU.item;
				int deviceId = x;
				Launch(args, deviceId, gridDims, blockDims, sharedMem);
				return;
			}
			string paramName = "ctx";
			string message = "Cuda kernel can only be launched on GPU";
			throw new ArgumentException(message, paramName);
		}
	}
}
