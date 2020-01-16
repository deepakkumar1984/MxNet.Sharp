#define DEBUG
using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class MXAutograd
	{
		[Serializable]
		internal sealed class g_00402484 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal g_00402484(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class st_00402485 : FSharpFunc<int, int>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal st_00402485(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override int Invoke(int i)
			{
				return (int)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(int))), typeof(int));
			}
		}

		public static bool setIsRecording(bool is_recording)
		{
			int prev = Helper.un<int>();
			Helper.throwOnError("MXAutogradSetIsRecording", CApi.MXAutogradSetIsRecording(is_recording ? 1 : 0, out prev));
			return prev != 0;
		}

		public static bool setIsTraining(bool is_training)
		{
			int prev = Helper.un<int>();
			Helper.throwOnError("MXAutogradSetIsTraining", CApi.MXAutogradSetIsTraining(is_training ? 1 : 0, out prev));
			return prev != 0;
		}

		public static bool isRecording()
		{
			bool curr = Helper.un<bool>();
			Helper.throwOnError("MXAutogradIsRecording", CApi.MXAutogradIsRecording(out curr));
			return curr;
		}

		public static bool isTraining()
		{
			bool curr = Helper.un<bool>();
			Helper.throwOnError("MXAutogradIsTraining", CApi.MXAutogradIsTraining(out curr));
			return curr;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void markVariables(IntPtr[] var_handles, uint[] reqs_array, IntPtr[] grad_handles)
		{
			Debug.Assert(Helper.ulength(var_handles) == Helper.ulength(reqs_array));
			Debug.Assert(Helper.ulength(var_handles) == Helper.ulength(grad_handles));
			Helper.throwOnError("MXAutogradMarkVariables", CApi.MXAutogradMarkVariables(Helper.ulength(var_handles), var_handles, reqs_array, grad_handles));
		}

		public static void computeGradient(IntPtr[] output_handles)
		{
			Helper.throwOnError("MXAutogradComputeGradient", CApi.MXAutogradComputeGradient(Helper.ulength(output_handles), output_handles));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void backward(IntPtr[] output_handles, IntPtr[] ograd_handles, bool retain_graph)
		{
			Debug.Assert(Helper.ulength(output_handles) == Helper.ulength(ograd_handles));
			Helper.throwOnError("MXAutogradBackward", CApi.MXAutogradBackward(Helper.ulength(output_handles), output_handles, ograd_handles, retain_graph ? 1 : 0));
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
		public static Tuple<IntPtr[], int[]> backwardEx(IntPtr[] output_handles, IntPtr[] ograd_handles, IntPtr[] var_handles, bool retain_graph, bool create_graph, bool is_train)
		{
			IntPtr grad_handles = Helper.un<IntPtr>();
			IntPtr grad_stypes = Helper.un<IntPtr>();
			int retain_graph2 = retain_graph ? 1 : 0;
			int create_graph2 = create_graph ? 1 : 0;
			int is_train2 = is_train ? 1 : 0;
			Helper.throwOnError("MXAutogradBackwardEx", CApi.MXAutogradBackwardEx(Helper.ulength(output_handles), output_handles, ograd_handles, Helper.ulength(var_handles), var_handles, retain_graph2, create_graph2, is_train2, out grad_handles, out grad_stypes));
			int num = var_handles.Length;
			IntPtr ptr = grad_handles;
			int num2 = num;
			FSharpFunc<int, IntPtr> val = new g_00402484(ptr);
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
			IntPtr[] g = array;
			int num3 = var_handles.Length;
			IntPtr ptr2 = grad_stypes;
			int num4 = num3;
			FSharpFunc<int, int> val2 = new st_00402485(ptr2);
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
			int[] st = array2;
			return new Tuple<IntPtr[], int[]>(g, st);
		}

		public static IntPtr getSymbol(IntPtr handle)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXAutogradGetSymbol", CApi.MXAutogradGetSymbol(handle, out @out));
			return @out;
		}
	}
}
