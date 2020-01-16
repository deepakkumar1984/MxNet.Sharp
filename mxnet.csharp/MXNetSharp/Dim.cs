using Microsoft.FSharp.Core;
using System.Diagnostics;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class Dim
	{
		[Literal]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const int Copy = 0;

		[Literal]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const int Infer = -1;

		[Literal]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const int CopyRest = -2;

		[Literal]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const int Product = -3;

		[Literal]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const int Split = -4;
	}
}
