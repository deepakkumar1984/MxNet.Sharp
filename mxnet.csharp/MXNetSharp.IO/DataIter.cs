using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;

namespace MXNetSharp.IO
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class DataIter : IDisposable
	{
		internal DataIterDefinition definition;

		internal bool disposed;

		internal bool atEnd;

		internal SafeDataIterHandle iterHandle;

		public DataIterDefinition DataIterDefinition => definition;

		public DataIter(DataIterDefinition definition)
		{
			this.definition = definition;
			disposed = false;
			atEnd = false;
			IDictionary<string, object> parameters = this.definition.GetParameters();
			_0024Dataiter._002Dctor_004064_002D6 _002Dctor_004064_002D = new _0024Dataiter._002Dctor_004064_002D6();
			IDictionary<string, object> dictionary = parameters;
			FSharpFunc<KeyValuePair<string, object>, bool> val = new _0024Dataiter._002Dctor_004062_002D8();
			IDictionary<string, object> dictionary2 = dictionary;
			Tuple<string[], string[]> tuple = ArrayModule.Unzip<string, string>(SeqModule.ToArray<Tuple<string, string>>(SeqModule.Map<KeyValuePair<string, object>, Tuple<string, string>>((FSharpFunc<KeyValuePair<string, object>, Tuple<string, string>>)_002Dctor_004064_002D, SeqModule.Filter<KeyValuePair<string, object>>(val, (IEnumerable<KeyValuePair<string, object>>)dictionary2))));
			IntPtr h = MXDataIter.create(vals: tuple.Item2, keys: tuple.Item1, handle: this.definition.DataIterCreatorHandle);
			iterHandle = new SafeDataIterHandle(h, owner: true);
		}

		internal DataIter(IntPtr handle, DataIterInfo info, IDictionary<string, object> parameters)
			: this(new DataIterDefinition(handle, info, parameters))
		{
		}

		public void Reset()
		{
			MXDataIter.beforeFirst(iterHandle.UnsafeHandle);
			atEnd = false;
		}

		public NDArray GetData()
		{
			return new NDArray(MXDataIter.getData(iterHandle.UnsafeHandle));
		}

		public ulong[] GetIndex()
		{
			return MXDataIter.getIndex(iterHandle.UnsafeHandle);
		}

		public a GetPadNum<a>()
		{
			return MXDataIter.getPadNum<a>(iterHandle.UnsafeHandle);
		}

		public NDArray GetLabel()
		{
			return new NDArray(MXDataIter.getLabel(iterHandle.UnsafeHandle));
		}

		public bool Next()
		{
			atEnd = (atEnd || MXDataIter.next(iterHandle.UnsafeHandle) <= 0);
			return !atEnd;
		}

		public void Dispose(bool disposing)
		{
			if (!disposed && disposing)
			{
				iterHandle.Dispose();
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
	}
}
