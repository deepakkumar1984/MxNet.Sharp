using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public enum TypeFlag
	{
		None = -1,
		Float32,
		Float64,
		Float16,
		Uint8,
		Int32,
		Int8,
		Int64,
		Bool
	}
}
