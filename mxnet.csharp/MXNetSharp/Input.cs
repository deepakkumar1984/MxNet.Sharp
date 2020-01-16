using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class Input : Parameter
	{
		internal int init_0040148_002D17;

		public Input([OptionalArgument] FSharpOption<string> name, [OptionalArgument] FSharpOption<IEnumerable<int>> shape, [OptionalArgument] FSharpOption<NDArray> ndarray, [OptionalArgument] FSharpOption<DataType> dataType, [OptionalArgument] FSharpOption<StorageType> storageType)
			: base(name, shape, FSharpOption<MXNetSharp.OpReqType>.Some(MXNetSharp.OpReqType.NullOp), FSharpOption<MXNetSharp.NDArray>.Some(new NDArray()), ndarray, dataType, storageType, null)
		{
			init_0040148_002D17 = 1;
		}
	}
}
