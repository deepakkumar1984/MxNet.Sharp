using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class Autograd
	{
		[Serializable]
		internal sealed class pause_004014<a> : FSharpFunc<Unit, a>
		{
			public FSharpFunc<Unit, a> f;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal pause_004014(FSharpFunc<Unit, a> f)
			{
				this.f = f;
			}

			public override a Invoke(Unit _arg1)
			{
				bool flag = MXAutograd.setIsRecording(is_recording: false);
				bool flag2 = flag;
				a result = ((FSharpFunc<Unit, Unit>)(object)f).Invoke((Unit)null);
				bool flag3 = MXAutograd.setIsRecording(is_recording: true);
				bool flag4 = flag3;
				return result;
			}
		}

		[Serializable]
		internal sealed class record_004022<a> : FSharpFunc<Unit, a>
		{
			public FSharpFunc<Unit, a> f;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal record_004022(FSharpFunc<Unit, a> f)
			{
				this.f = f;
			}

			public override a Invoke(Unit _arg1)
			{
				bool flag = MXAutograd.setIsRecording(is_recording: true);
				bool flag2 = flag;
				a result = ((FSharpFunc<Unit, Unit>)(object)f).Invoke((Unit)null);
				bool flag3 = MXAutograd.setIsRecording(is_recording: false);
				bool flag4 = flag3;
				return result;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class s_004031_002D1 : Symbol
		{
			public FSharpFunc<IntPtr, Symbol> makeSymbol = makeSymbol;

			public IntPtr handle = handle;

			public s_004031_002D1(FSharpFunc<IntPtr, Symbol> makeSymbol, IntPtr handle)
			{
			}

			public override void Initialize()
			{
			}

			public override Symbol Copy()
			{
				return makeSymbol.Invoke(MXSymbol.copy(handle));
			}
		}

		[Serializable]
		internal sealed class makeSymbol_004030 : FSharpFunc<IntPtr, Symbol>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal makeSymbol_004030()
			{
			}

			public override Symbol Invoke(IntPtr handle)
			{
				Symbol s = new s_004031_002D1(this, handle);
				s.InternalHandle = FSharpOption<SafeSymbolHandle>.Some(new SafeSymbolHandle(handle, owner: true));
				return s;
			}
		}

		[Serializable]
		internal sealed class computeGradient_004041 : FSharpFunc<NDArray, IntPtr>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal computeGradient_004041()
			{
			}

			public override IntPtr Invoke(NDArray x)
			{
				return x.UnsafeHandle;
			}
		}

		[Serializable]
		internal sealed class a_004047_002D1 : FSharpFunc<NDArray, IntPtr>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal a_004047_002D1()
			{
			}

			public override IntPtr Invoke(NDArray a)
			{
				return a.UnsafeHandle;
			}
		}

		[Serializable]
		internal sealed class req_004048 : FSharpFunc<OpReqType, uint>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal req_004048()
			{
			}

			public override uint Invoke(OpReqType x)
			{
				return (uint)x.OpReqTypeInt;
			}
		}

		[Serializable]
		internal sealed class g_004049_002D1 : FSharpFunc<NDArray, IntPtr>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal g_004049_002D1()
			{
			}

			public override IntPtr Invoke(NDArray g)
			{
				return g.UnsafeHandle;
			}
		}

		[Serializable]
		internal sealed class headHandles_004053 : FSharpFunc<NDArray, IntPtr>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal headHandles_004053()
			{
			}

			public override IntPtr Invoke(NDArray x)
			{
				return x.UnsafeHandle;
			}
		}

		[Serializable]
		internal sealed class handles_004058_002D1 : FSharpFunc<NDArray, IntPtr>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal handles_004058_002D1()
			{
			}

			public override IntPtr Invoke(NDArray x)
			{
				return x.UnsafeHandle;
			}
		}

		[Serializable]
		internal sealed class varHandles_004062 : FSharpFunc<NDArray, IntPtr>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal varHandles_004062()
			{
			}

			public override IntPtr Invoke(NDArray x)
			{
				return x.UnsafeHandle;
			}
		}

		[Serializable]
		internal sealed class grad_004064 : FSharpFunc<IntPtr, NDArray>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal grad_004064()
			{
			}

			public override NDArray Invoke(IntPtr x)
			{
				return new NDArray(x);
			}
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal static object lck => _0024Autograd.lck_00407;

		public static bool isRecording()
		{
			return MXAutograd.isRecording();
		}

		public static bool isTraining()
		{
			return MXAutograd.isTraining();
		}

		public static bool setIsRecording(bool recording)
		{
			return MXAutograd.setIsRecording(recording);
		}

		public static bool setIsTraining(bool training)
		{
			return MXAutograd.setIsTraining(training);
		}

		public static a pause<a>(FSharpFunc<Unit, a> f)
		{
			object lck = Autograd.lck;
			FSharpFunc<Unit, a> val = new pause_004014<a>(f);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(lck, ref lockTaken);
				return val.Invoke((Unit)null);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(lck);
					_ = null;
				}
				else
				{
					_ = null;
				}
			}
		}

		public static a record<a>(FSharpFunc<Unit, a> f)
		{
			object lck = Autograd.lck;
			FSharpFunc<Unit, a> val = new record_004022<a>(f);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(lck, ref lockTaken);
				return val.Invoke((Unit)null);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(lck);
					_ = null;
				}
				else
				{
					_ = null;
				}
			}
		}

		public static Symbol symbol(NDArray ndarray)
		{
			FSharpFunc<IntPtr, Symbol> val = new makeSymbol_004030();
			return val.Invoke(MXAutograd.getSymbol(ndarray.UnsafeHandle));
		}

		public static void computeGradient(IEnumerable<NDArray> ndarrays)
		{
			MXAutograd.computeGradient(SeqModule.ToArray<IntPtr>(SeqModule.Map<NDArray, IntPtr>((FSharpFunc<NDArray, IntPtr>)new computeGradient_004041(), ndarrays)));
		}

		public static void markVariables(IEnumerable<Tuple<NDArray, OpReqType, NDArray>> vars)
		{
			Tuple<NDArray[], OpReqType[], NDArray[]> tuple = ArrayModule.Unzip3<NDArray, OpReqType, NDArray>(SeqModule.ToArray<Tuple<NDArray, OpReqType, NDArray>>(vars));
			OpReqType[] req2 = tuple.Item2;
			NDArray[] g2 = tuple.Item3;
			NDArray[] a2 = tuple.Item1;
			NDArray[] array = a2;
			FSharpFunc<NDArray, IntPtr> val = new a_004047_002D1();
			NDArray[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr[] array3 = new IntPtr[array2.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = val.Invoke(array2[i]);
			}
			IntPtr[] a = array3;
			OpReqType[] array4 = req2;
			FSharpFunc<OpReqType, uint> val2 = new req_004048();
			OpReqType[] array5 = array4;
			if (array5 == null)
			{
				throw new ArgumentNullException("array");
			}
			uint[] array6 = new uint[array5.Length];
			for (int j = 0; j < array6.Length; j++)
			{
				array6[j] = val2.Invoke(array5[j]);
			}
			uint[] req = array6;
			NDArray[] array7 = g2;
			FSharpFunc<NDArray, IntPtr> val3 = new g_004049_002D1();
			NDArray[] array8 = array7;
			if (array8 == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr[] array9 = new IntPtr[array8.Length];
			for (int k = 0; k < array9.Length; k++)
			{
				array9[k] = val3.Invoke(array8[k]);
			}
			IntPtr[] g = array9;
			MXAutograd.markVariables(a, req, g);
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
		public static NDArray[] grad(bool train, bool retainGraph, bool createGraph, IEnumerable<NDArray> headGrads, IEnumerable<NDArray> heads, IEnumerable<NDArray> variables)
		{
			IntPtr[] headHandles = SeqModule.ToArray<IntPtr>(SeqModule.Map<NDArray, IntPtr>((FSharpFunc<NDArray, IntPtr>)new headHandles_004053(), heads));
			object obj;
			if (SeqModule.IsEmpty<NDArray>(headGrads))
			{
				obj = null;
			}
			else
			{
				IntPtr[] handles = SeqModule.ToArray<IntPtr>(SeqModule.Map<NDArray, IntPtr>((FSharpFunc<NDArray, IntPtr>)new handles_004058_002D1(), headGrads));
				if (handles.Length != headHandles.Length)
				{
					string paramName = "headGrads";
					string message = "headGrads must be empty or of the same length as heads";
					throw new ArgumentException(message, paramName);
				}
				obj = handles;
			}
			IntPtr[] hgradHandles = (IntPtr[])obj;
			IntPtr[] varHandles = SeqModule.ToArray<IntPtr>(SeqModule.Map<NDArray, IntPtr>((FSharpFunc<NDArray, IntPtr>)new varHandles_004062(), variables));
			Tuple<IntPtr[], int[]> tuple = MXAutograd.backwardEx(headHandles, hgradHandles, varHandles, retainGraph, createGraph, train);
			IntPtr[] h = tuple.Item1;
			int[] _st = tuple.Item2;
			IntPtr[] array = h;
			FSharpFunc<IntPtr, NDArray> val = new grad_004064();
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
			return array3;
		}
	}
}
