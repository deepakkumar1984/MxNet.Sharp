using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;

namespace MXNetSharp.SymbolArgument
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	internal static class Dict
	{
		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static IDictionary<k, v> addReplace<k, v>(IDictionary<k, v> src, IDictionary<k, v> dest)
		{
			Dictionary<k, v> d = new Dictionary<k, v>(dest);
			IEnumerator<KeyValuePair<k, v>> enumerator = src.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<k, v> kvp = enumerator.Current;
					d[kvp.Key] = kvp.Value;
				}
				Unit val = null;
				return d;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
					_ = null;
				}
				else
				{
					_ = null;
				}
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static IDictionary<k, v> addIgnore<k, v>(IDictionary<k, v> src, IDictionary<k, v> dest)
		{
			Dictionary<k, v> d = new Dictionary<k, v>(dest);
			IEnumerator<KeyValuePair<k, v>> enumerator = src.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<k, v> kvp = enumerator.Current;
					if (!d.ContainsKey(kvp.Key))
					{
						d[kvp.Key] = kvp.Value;
					}
				}
				Unit val = null;
				return d;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
					_ = null;
				}
				else
				{
					_ = null;
				}
			}
		}
	}
}
