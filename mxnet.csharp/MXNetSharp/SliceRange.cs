using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SliceRange
	{
		internal FSharpOption<long> stop;

		internal FSharpOption<long> step;

		internal FSharpOption<long> start;

		public FSharpOption<long> Start => start;

		public FSharpOption<long> Stop => stop;

		public FSharpOption<long> Step => step;

		public SliceRange([OptionalArgument] FSharpOption<long> start, [OptionalArgument] FSharpOption<long> stop, [OptionalArgument] FSharpOption<long> step)
		{
			this.start = start;
			this.stop = stop;
			this.step = step;
		}
	}
}
