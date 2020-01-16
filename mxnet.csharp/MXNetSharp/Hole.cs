using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class Hole : Variable
	{
		internal int init_0040487_002D9;

		public Hole()
		{
			init_0040487_002D9 = 1;
		}

		public override Symbol Copy()
		{
			if (init_0040487_002D9 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			return new Hole();
		}
	}
}
