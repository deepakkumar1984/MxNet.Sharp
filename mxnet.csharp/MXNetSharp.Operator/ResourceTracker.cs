using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace MXNetSharp.Operator
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class ResourceTracker : IDisposable
	{
		internal string name;

		internal long id;

		internal static long idCounter;

		internal static ConcurrentDictionary<long, ResourceTracker> lookup;

		internal static CApi.CustomOpDelFunc delete;

		internal bool disposed;

		internal object lck;

		internal List<ResourceType> resources;

		internal Dictionary<string, IntPtr> cache;

		internal static int init_0040135_002D13;

		public long Id => id;

		public ResourceTracker(long id, string name)
		{
			this.id = id;
			this.name = name;
			disposed = false;
			lck = new object();
			resources = new List<ResourceType>();
			cache = new Dictionary<string, IntPtr>();
		}

		public static ResourceTracker CreateStored(string name)
		{
			if (init_0040135_002D13 < 2)
			{
				IntrinsicFunctions.FailStaticInit();
			}
			long id = Interlocked.Increment(ref idCounter);
			ResourceTracker o = new ResourceTracker(id, name);
			if (init_0040135_002D13 < 3)
			{
				IntrinsicFunctions.FailStaticInit();
			}
			lookup[id] = o;
			return o;
		}

		public IntPtr Alloc(int size)
		{
			object obj = lck;
			FSharpFunc<Unit, IntPtr> val = new _0024Customop.Alloc_0040161(this, size);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				return val.Invoke((Unit)null);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
					_ = null;
				}
				else
				{
					_ = null;
				}
			}
		}

		public IntPtr StringArray(string[] strs)
		{
			object obj = lck;
			FSharpFunc<Unit, IntPtr> val = new _0024Customop.StringArray_0040170(this, strs);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				return val.Invoke((Unit)null);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
					_ = null;
				}
				else
				{
					_ = null;
				}
			}
		}

		public IntPtr CachedStringArray(string[] strs)
		{
			FSharpFunc<string, string> val = new _0024Customop.key_0040183();
			string key = StringModule.Concat("|", SeqModule.Map<string, string>(val, (IEnumerable<string>)strs));
			object obj = lck;
			FSharpFunc<Unit, IntPtr> val2 = new _0024Customop.CachedStringArray_0040185(this, strs, key);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				return val2.Invoke((Unit)null);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
					_ = null;
				}
				else
				{
					_ = null;
				}
			}
		}

		public IntPtr DelgatePointer(Delegate d)
		{
			object obj = lck;
			FSharpFunc<Unit, Unit> val = new _0024Customop.DelgatePointer_0040198(this, d);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				Unit val2 = val.Invoke((Unit)null);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
					_ = null;
				}
				else
				{
					_ = null;
				}
			}
			return Marshal.GetFunctionPointerForDelegate(d);
		}

		public unsafe void WriteMxCallbackList(ref CApi.MXCallbackList ptr, Tuple<Delegate, IntPtr>[] l)
		{
			IntPtr current = default(IntPtr);
			IntPtr[] cbPtrArray = SeqModule.ToArray<IntPtr>((IEnumerable<IntPtr>)(object)new _0024Customop.cbPtrArray_0040207(this, l, 0, current));
			IntPtr cbPtr = Alloc(cbPtrArray.Length * sizeof(IntPtr));
			Marshal.Copy(cbPtrArray, 0, cbPtr, cbPtrArray.Length);
			IntPtr current2 = default(IntPtr);
			IntPtr[] ctxPtrArray = SeqModule.ToArray<IntPtr>((IEnumerable<IntPtr>)(object)new _0024Customop.ctxPtrArray_0040214(this, l, 0, current2));
			IntPtr ctxPtr = Alloc(ctxPtrArray.Length * sizeof(IntPtr));
			Marshal.Copy(ctxPtrArray, 0, ctxPtr, ctxPtrArray.Length);
			int N = ptr.num_callbacks = cbPtrArray.Length;
			ptr.callbacks = cbPtr;
			ptr.contexts = ctxPtr;
		}

		public void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					object obj = lck;
					FSharpFunc<Unit, Unit> val = new _0024Customop.Dispose_0040227(this);
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						Unit val2 = val.Invoke((Unit)null);
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(obj);
							_ = null;
						}
						else
						{
							_ = null;
						}
					}
				}
				disposed = true;
			}
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

		static ResourceTracker()
		{
			_0024Customop.init_0040 = 0;
			_ = _0024Customop.init_0040;
		}
	}
}
