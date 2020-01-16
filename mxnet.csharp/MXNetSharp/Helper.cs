using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	internal static class Helper
	{
		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static Tuple<a, string> op_LessMinusMinus<a, b>(a x, b y)
		{
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			return new Tuple<a, string>(x, ValueStringExtensions.ValueString(y));
		}
	}
}
