using _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class LibFeature
	{
		[Serializable]
		internal sealed class fs_00405 : FSharpFunc<Unit, MXNetSharp.Interop.LibFeature[]>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal fs_00405()
			{
			}

			public override MXNetSharp.Interop.LibFeature[] Invoke(Unit unitVar)
			{
				return MXLib.infoFeatures();
			}
		}

		[Serializable]
		internal sealed class lookup_00406 : FSharpFunc<MXNetSharp.Interop.LibFeature, Tuple<string, bool>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal lookup_00406()
			{
			}

			public override Tuple<string, bool> Invoke(MXNetSharp.Interop.LibFeature x)
			{
				return new Tuple<string, bool>(x.Name, x.Enabled);
			}
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal static Lazy<MXNetSharp.Interop.LibFeature[]> fs => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.fs_00405;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static IDictionary<string, bool> lookup => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.lookup_00406;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CUDNN => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CUDNN_004012;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool NCCL => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.NCCL_004013;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CUDA_RTC => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CUDA_RTC_004014;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool TENSORRT => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.TENSORRT_004015;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CPU_SSE => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CPU_SSE_004016;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CPU_SSE2 => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CPU_SSE2_004017;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CPU_SSE3 => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CPU_SSE3_004018;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CPU_SSE4_1 => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CPU_SSE4_1_004019;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CPU_SSE4_2 => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CPU_SSE4_2_004020;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CPU_SSE4A => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CPU_SSE4A_004021;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CPU_AVX => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CPU_AVX_004022;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CPU_AVX2 => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CPU_AVX2_004023;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool OPENMP => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.OPENMP_004024;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool SSE => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.SSE_004025;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool F16C => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.F16C_004026;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool JEMALLOC => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.JEMALLOC_004027;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool BLAS_OPEN => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.BLAS_OPEN_004028;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool BLAS_ATLAS => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.BLAS_ATLAS_004029;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool BLAS_MKL => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.BLAS_MKL_004030;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool BLAS_APPLE => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.BLAS_APPLE_004031;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool LAPACK => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.LAPACK_004032;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool MKLDNN => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.MKLDNN_004033;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool OPENCV => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.OPENCV_004034;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CAFFE => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CAFFE_004035;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool PROFILER => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.PROFILER_004036;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool DIST_KVSTORE => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.DIST_KVSTORE_004037;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool CXX14 => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.CXX14_004038;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool INT64_TENSOR_SIZE => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.INT64_TENSOR_SIZE_004039;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool SIGNAL_HANDLER => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.SIGNAL_HANDLER_004040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool DEBUG => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.DEBUG_004041;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static bool TVM_OP => _003CStartupCode_0024MXNetSharp_003E._0024MXNetSharp.LibFeature.TVM_OP_004042;

		public static bool isEnabled(string name)
		{
			bool value;
			Tuple<bool, bool> tuple = new Tuple<bool, bool>(lookup.TryGetValue(name, out value), value);
			bool v = tuple.Item2;
			if (tuple.Item1)
			{
				return v;
			}
			return false;
		}
	}
}
