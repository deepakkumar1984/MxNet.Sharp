using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class MXKVStore
	{
		[Serializable]
		internal sealed class pullWithSparse_00402285 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal pullWithSparse_00402285(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class pullWithSparseEx_00402298 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal pullWithSparseEx_00402298(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class pull_00402310 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal pull_00402310(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class pullEx_00402322 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal pullEx_00402322(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class vals_00402338 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal vals_00402338(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class row_ids_00402339 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal row_ids_00402339(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class vals_00402356_002D1 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal vals_00402356_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class row_ids_00402357_002D1 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal row_ids_00402357_002D1(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class pushPull_00402370 : FSharpFunc<int, IntPtr>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal pushPull_00402370(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override IntPtr Invoke(int i)
			{
				return (IntPtr)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(IntPtr))), typeof(IntPtr));
			}
		}

		[Serializable]
		internal sealed class pushPullEx_00402386 : FSharpFunc<int, object>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IntPtr ptr;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal pushPullEx_00402386(IntPtr ptr)
			{
				this.ptr = ptr;
			}

			public unsafe override object Invoke(int i)
			{
				return (object)Marshal.PtrToStructure((IntPtr)(void*)((long)ptr + (long)new IntPtr(i * sizeof(object))), typeof(object));
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static void mXInitPSEnv(uint num_vars, string[] keys, string[] vals)
		{
			Helper.throwOnError("MXInitPSEnv", CApi.MXInitPSEnv(num_vars, keys, vals));
		}

		public static void create(string type)
		{
			IntPtr @out = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStoreCreate", CApi.MXKVStoreCreate(type, out @out));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void setGradientCompression(IntPtr handle, uint num_params, string[] keys, string[] vals)
		{
			Helper.throwOnError("MXKVStoreSetGradientCompression", CApi.MXKVStoreSetGradientCompression(handle, num_params, keys, vals));
		}

		public static void free(IntPtr handle)
		{
			Helper.throwOnError("MXKVStoreFree", CApi.MXKVStoreFree(handle));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void init(IntPtr handle, uint num, int[] keys, IntPtr[] vals)
		{
			Helper.throwOnError("MXKVStoreInit", CApi.MXKVStoreInit(handle, num, keys, vals));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void initEx(IntPtr handle, uint num, string[] keys, IntPtr[] vals)
		{
			Helper.throwOnError("MXKVStoreInitEx", CApi.MXKVStoreInitEx(handle, num, keys, vals));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void push(IntPtr handle, int[] keys, IntPtr[] vals, int priority)
		{
			Helper.throwOnError("MXKVStorePush", CApi.MXKVStorePush(handle, Helper.ulength(keys), keys, vals, priority));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void pushEx(IntPtr handle, string[] keys, IntPtr[] vals, int priority)
		{
			Helper.throwOnError("MXKVStorePushEx", CApi.MXKVStorePushEx(handle, Helper.ulength(keys), keys, vals, priority));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static IntPtr[] pullWithSparse(IntPtr handle, int[] keys, int priority, bool ignore_sparse)
		{
			IntPtr vals = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStorePullWithSparse", CApi.MXKVStorePullWithSparse(handle, Helper.ulength(keys), keys, out vals, priority, ignore_sparse));
			uint num = Helper.ulength(keys);
			IntPtr ptr = vals;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new pullWithSparse_00402285(ptr);
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
			1,
			1
		})]
		public static IntPtr[] pullWithSparseEx(IntPtr handle, string[] keys, int priority, bool ignore_sparse)
		{
			IntPtr vals = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStorePullWithSparseEx", CApi.MXKVStorePullWithSparseEx(handle, Helper.ulength(keys), keys, out vals, priority, ignore_sparse));
			uint num = Helper.ulength(keys);
			IntPtr ptr = vals;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new pullWithSparseEx_00402298(ptr);
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
		public static IntPtr[] pull(IntPtr handle, int[] keys, int priority)
		{
			IntPtr vals = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStorePull", CApi.MXKVStorePull(handle, Helper.ulength(keys), keys, out vals, priority));
			uint num = Helper.ulength(keys);
			IntPtr ptr = vals;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new pull_00402310(ptr);
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
			1,
			1,
			1
		})]
		public static IntPtr[] pullEx<a, b>(IntPtr handle, a num, string[] keys, b vals, int priority)
		{
			IntPtr vals2 = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStorePullEx", CApi.MXKVStorePullEx(handle, Helper.ulength(keys), keys, out vals2, priority));
			uint num2 = Helper.ulength(keys);
			IntPtr ptr = vals2;
			int num3 = (int)num2;
			FSharpFunc<int, IntPtr> val = new pullEx_00402322(ptr);
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
			IntPtr[] array = new IntPtr[num3];
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
		public static Tuple<IntPtr[], IntPtr[]> pullRowSparse(IntPtr handle, int[] keys, int priority)
		{
			IntPtr vals2 = Helper.un<IntPtr>();
			IntPtr row_ids2 = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStorePullRowSparse", CApi.MXKVStorePullRowSparse(handle, Helper.ulength(keys), keys, out vals2, out row_ids2, priority));
			uint num = Helper.ulength(keys);
			IntPtr ptr = vals2;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new vals_00402338(ptr);
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
			IntPtr[] vals = array;
			uint num3 = Helper.ulength(keys);
			IntPtr ptr2 = row_ids2;
			int num4 = (int)num3;
			FSharpFunc<int, IntPtr> val2 = new row_ids_00402339(ptr2);
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
			IntPtr[] array2 = new IntPtr[num4];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = val2.Invoke(j);
			}
			IntPtr[] row_ids = array2;
			return new Tuple<IntPtr[], IntPtr[]>(vals, row_ids);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static Tuple<IntPtr[], IntPtr[]> pullRowSparseEx(IntPtr handle, string[] keys, int priority)
		{
			IntPtr vals2 = Helper.un<IntPtr>();
			IntPtr row_ids2 = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStorePullRowSparseEx", CApi.MXKVStorePullRowSparseEx(handle, Helper.ulength(keys), keys, out vals2, out row_ids2, priority));
			uint num = Helper.ulength(keys);
			IntPtr ptr = vals2;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new vals_00402356_002D1(ptr);
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
			IntPtr[] vals = array;
			uint num3 = Helper.ulength(keys);
			IntPtr ptr2 = row_ids2;
			int num4 = (int)num3;
			FSharpFunc<int, IntPtr> val2 = new row_ids_00402357_002D1(ptr2);
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
			IntPtr[] array2 = new IntPtr[num4];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = val2.Invoke(j);
			}
			IntPtr[] row_ids = array2;
			return new Tuple<IntPtr[], IntPtr[]>(vals, row_ids);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1,
			1
		})]
		public static IntPtr[] pushPull(IntPtr handle, int[] vkeys, int[] okeys, IntPtr[] vals, int priority)
		{
			IntPtr outs = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStorePushPull", CApi.MXKVStorePushPull(handle, Helper.ulength(vkeys), vkeys, Helper.ulength(okeys), okeys, vals, out outs, priority));
			uint num = Helper.ulength(okeys);
			IntPtr ptr = outs;
			int num2 = (int)num;
			FSharpFunc<int, IntPtr> val = new pushPull_00402370(ptr);
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
			1,
			1,
			1
		})]
		public static object[] pushPullEx(IntPtr handle, string[] vkeys, string[] okeys, IntPtr[] vals, int priority)
		{
			IntPtr outs = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStorePushPullEx", CApi.MXKVStorePushPullEx(handle, Helper.ulength(vkeys), vkeys, Helper.ulength(okeys), okeys, vals, out outs, priority));
			uint num = Helper.ulength(okeys);
			IntPtr ptr = outs;
			int num2 = (int)num;
			FSharpFunc<int, object> val = new pushPullEx_00402386(ptr);
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
			object[] array = new object[num2];
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
		public static void setUpdater(IntPtr handle, CApi.MXKVStoreUpdater updater, IntPtr updater_handle)
		{
			Helper.throwOnError("MXKVStoreSetUpdater", CApi.MXKVStoreSetUpdater(handle, updater, updater_handle));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1,
			1
		})]
		public static void setUpdaterEx(IntPtr handle, CApi.MXKVStoreUpdater updater, CApi.MXKVStoreStrUpdater str_updater, IntPtr updater_handle)
		{
			Helper.throwOnError("MXKVStoreSetUpdaterEx", CApi.MXKVStoreSetUpdaterEx(handle, updater, str_updater, updater_handle));
		}

		public static string getType(IntPtr handle)
		{
			IntPtr tp = Helper.un<IntPtr>();
			Helper.throwOnError("MXKVStoreGetType", CApi.MXKVStoreGetType(handle, out tp));
			return Helper.str(tp);
		}
	}
}
