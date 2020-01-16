using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class ImplicitVariable : Variable
	{
		internal int init_0040333_002D8;

		public ImplicitVariable()
		{
			init_0040333_002D8 = 1;
		}

		public override Symbol Copy()
		{
			if (init_0040333_002D8 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			return new ImplicitVariable();
		}
	}
}
