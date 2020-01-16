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
	public class DataIterDefinition
	{
		internal IDictionary<string, object> parameters;

		internal DataIterInfo info;

		internal IntPtr handle;

		internal static Lazy<Dictionary<string, DataIterDefinition>> lookup;

		internal static int init_004016_002D14;

		public IntPtr DataIterCreatorHandle => handle;

		public string Name => info.Name_0040;

		public DataIterInfo Info => info;

		internal DataIterDefinition(IntPtr handle, DataIterInfo info, IDictionary<string, object> parameters)
		{
			this.handle = handle;
			this.info = info;
			this.parameters = parameters;
		}

		public DataIterDefinition(IntPtr handle, DataIterInfo info)
			: this(handle, info, ExtraTopLevelOperators.CreateDictionary<string, object>((IEnumerable<Tuple<string, object>>)FSharpList<Tuple<string, object>>.get_Empty()))
		{
		}

		public static DataIterDefinition FromName(string name)
		{
			DataIterDefinition value = null;
			if (init_004016_002D14 < 3)
			{
				IntrinsicFunctions.FailStaticInit();
			}
			Tuple<bool, DataIterDefinition> tuple = new Tuple<bool, DataIterDefinition>(lookup.Value.TryGetValue(name, out value), value);
			DataIterDefinition v = tuple.Item2;
			if (tuple.Item1)
			{
				return v;
			}
			throw new DataIterNotFound(name);
		}

		public DataIterDefinition WithParameters(IDictionary<string, object> kvps)
		{
			Dictionary<string, object> d = new Dictionary<string, object>(parameters);
			FSharpFunc<KeyValuePair<string, object>, Unit> val = new _0024Dataiter.WithParameters_004036(d);
			SeqModule.Iterate<KeyValuePair<string, object>>(val, (IEnumerable<KeyValuePair<string, object>>)kvps);
			return new DataIterDefinition(handle, info, d);
		}

		public IDictionary<string, object> GetParameters()
		{
			return new Dictionary<string, object>(parameters);
		}

		static DataIterDefinition()
		{
			_0024Dataiter.init_0040 = 0;
			_ = _0024Dataiter.init_0040;
		}
	}
}
