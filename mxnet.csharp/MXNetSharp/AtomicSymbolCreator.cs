using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class AtomicSymbolCreator
	{
		internal AtomicSymbolInfo info;

		internal IntPtr handle;

		internal List<string> aliases;

		internal static IDictionary<string, AtomicSymbolCreator> lookup;

		internal static int init_004012_002D4;

		public string Name => info.Name_0040;

		public IntPtr AtomicSymbolCreatorHandle => handle;

		public AtomicSymbolInfo Info => info;

		internal AtomicSymbolCreator(IntPtr handle, AtomicSymbolInfo info)
		{
			this.handle = handle;
			this.info = info;
			aliases = new List<string>();
		}

		internal void AddAlias(string name)
		{
			aliases.Add(name);
		}

		public static AtomicSymbolCreator FromName(string name)
		{
			AtomicSymbolCreator value = null;
			if (init_004012_002D4 < 3)
			{
				IntrinsicFunctions.FailStaticInit();
			}
			Tuple<bool, AtomicSymbolCreator> tuple = new Tuple<bool, AtomicSymbolCreator>(lookup.TryGetValue(name, out value), value);
			AtomicSymbolCreator v = tuple.Item2;
			if (tuple.Item1)
			{
				return v;
			}
			throw new AtomicSymbolCreatorNotFound(name);
		}

		static AtomicSymbolCreator()
		{
			_0024Atomicsymbol.init_0040 = 0;
			_ = _0024Atomicsymbol.init_0040;
		}
	}
}
