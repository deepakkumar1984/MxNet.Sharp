using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MXNetSharp.Rtc
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class CudaModule
	{
		internal SafeCudaModuleHandle handle;

		public SafeCudaModuleHandle Handle => handle;

		internal CudaModule(SafeCudaModuleHandle handle)
		{
			this.handle = handle;
		}

		public CudaModule(string src, [OptionalArgument] FSharpOption<IEnumerable<string>> options, [OptionalArgument] FSharpOption<IEnumerable<string>> exports)
			: this(new SafeCudaModuleHandle(MXRtc.cudaModuleCreate(src, Operators.DefaultArg<string[]>(OptionModule.Map<IEnumerable<string>, string[]>((FSharpFunc<IEnumerable<string>, string[]>)new _0024Rtc.options_004061(), options), ArrayModule.Empty<string>()), Operators.DefaultArg<string[]>(OptionModule.Map<IEnumerable<string>, string[]>((FSharpFunc<IEnumerable<string>, string[]>)new _0024Rtc.exports_004062(), exports), ArrayModule.Empty<string>())), owner: true))
		{
		}

		public CudaKernel Kernel(string name, IEnumerable<CudaKernelArgument> args)
		{
			CudaKernelArgument[] args2 = SeqModule.ToArray<CudaKernelArgument>(args);
			FSharpFunc<bool, int> bint = new _0024Rtc.bint_004067();
			CudaKernelArgument[] array = args2;
			FSharpFunc<CudaKernelArgument, Tuple<int, int, int>> val = new _0024Rtc.Kernel_004070(bint);
			CudaKernelArgument[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			Tuple<int, int, int>[] array3 = new Tuple<int, int, int>[array2.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = val.Invoke(array2[i]);
			}
			Tuple<int[], int[], int[]> tuple = ArrayModule.Unzip3<int, int, int>(array3);
			int[] isNDArray = tuple.Item1;
			int[] isConst = tuple.Item2;
			int[] dtype = tuple.Item3;
			IntPtr h2 = MXRtc.cudaKernelCreate(handle.UnsafeHandle, name, isNDArray, isConst, dtype);
			SafeCudaKernelHandle h = new SafeCudaKernelHandle(h2, owner: true);
			return new CudaKernel(h, name, args2);
		}

		public CudaKernel Kernel(string name, string signature)
		{
			Regex pattern = new Regex("^\\s*(const)?\\s*([\\w_]+)\\s*(\\*)?\\s*([\\w_]+)?\\s*$");
			CudaKernelArgument[] args = ArrayModule.MapIndexed<string, CudaKernelArgument>((FSharpFunc<int, FSharpFunc<string, CudaKernelArgument>>)(object)new _0024Rtc.args_004081_002D6(pattern), Regex.Replace(signature, "\\s+", " ").Split(new char[1]
			{
				','
			}));
			return Kernel(name, args);
		}
	}
}
