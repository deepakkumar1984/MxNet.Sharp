using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public interface ISymbolComposable
	{
		override Symbol ComposedWith(Symbol P_0);
	}
}
