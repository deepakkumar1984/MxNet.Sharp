using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class Constant : Parameter
	{
		internal int init_0040157_002D18;

		public Constant(NDArray ndarray, [OptionalArgument] FSharpOption<string> name)
			: base(name, FSharpOption<IEnumerable<int>>.Some((IEnumerable<int>)ndarray.Shape), FSharpOption<MXNetSharp.OpReqType>.Some(MXNetSharp.OpReqType.NullOp), FSharpOption<MXNetSharp.NDArray>.Some(new NDArray()), FSharpOption<MXNetSharp.NDArray>.Some(ndarray), ndarray.DataType, FSharpOption<MXNetSharp.StorageType>.Some(ndarray.StorageType), null)
		{
			init_0040157_002D18 = 1;
		}
	}
}
