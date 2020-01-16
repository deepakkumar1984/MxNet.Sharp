using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class Parameter : Variable
	{
		internal FSharpOption<StorageType> storageType;

		internal FSharpOption<OpReqType> opReqType;

		internal FSharpOption<NDArray> ndarray;

		internal FSharpOption<IInitializer> init;

		internal FSharpOption<NDArray> grad;

		internal FSharpOption<DataType> dataType;

		internal FSharpOption<int[]> shape_0040107;

		internal int init_0040105_002D16;

		public FSharpOption<int[]> Shape
		{
			get
			{
				if (init_0040105_002D16 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return shape_0040107;
			}
		}

		public FSharpOption<NDArray> Grad
		{
			get
			{
				if (init_0040105_002D16 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return grad;
			}
		}

		public FSharpOption<OpReqType> OpReqType
		{
			get
			{
				if (init_0040105_002D16 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return opReqType;
			}
		}

		public FSharpOption<NDArray> NDArray
		{
			get
			{
				if (init_0040105_002D16 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return ndarray;
			}
		}

		public FSharpOption<DataType> DataType
		{
			get
			{
				if (init_0040105_002D16 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return dataType;
			}
		}

		public FSharpOption<StorageType> StorageType
		{
			get
			{
				if (init_0040105_002D16 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return storageType;
			}
		}

		public FSharpOption<IInitializer> Initializer
		{
			get
			{
				if (init_0040105_002D16 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return init;
			}
		}

		public ArgBind Binding
		{
			get
			{
				if (init_0040105_002D16 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return new ArgBind(Name, NDArray, Grad, OpReqType, Shape, DataType, StorageType);
			}
		}

		public Parameter([OptionalArgument] FSharpOption<string> name, [OptionalArgument] FSharpOption<IEnumerable<int>> shape, [OptionalArgument] FSharpOption<OpReqType> opReqType, [OptionalArgument] FSharpOption<NDArray> grad, [OptionalArgument] FSharpOption<NDArray> ndarray, [OptionalArgument] FSharpOption<DataType> dataType, [OptionalArgument] FSharpOption<StorageType> storageType, [OptionalArgument] FSharpOption<IInitializer> init)
		{
			this.opReqType = opReqType;
			this.grad = grad;
			this.ndarray = ndarray;
			this.dataType = dataType;
			this.storageType = storageType;
			this.init = init;
			Tuple<FSharpOption<NDArray>, FSharpOption<IEnumerable<int>>> tuple = new Tuple<FSharpOption<NDArray>, FSharpOption<IEnumerable<int>>>(this.ndarray, shape);
			object obj;
			if (tuple.Item1 == null)
			{
				if (tuple.Item2 != null)
				{
					IEnumerable<int> s3 = tuple.Item2.get_Value();
					int[] array = SeqModule.ToArray<int>(s3);
					int[] array2 = array;
					obj = FSharpOption<int[]>.Some(array2);
				}
				else
				{
					obj = null;
				}
			}
			else
			{
				FSharpOption<NDArray> item = tuple.Item1;
				if (tuple.Item2 != null)
				{
					FSharpOption<IEnumerable<int>> item2 = tuple.Item2;
					IEnumerable<int> s2 = item2.get_Value();
					NDArray value = item.get_Value();
					int[] s = SeqModule.ToArray<int>(s2);
					if (value.Shape.Length != s.Length)
					{
						string paramName = "shape";
						FSharpFunc<int[], FSharpFunc<int[], string>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int[], FSharpFunc<int[], string>>>((PrintfFormat<FSharpFunc<int[], FSharpFunc<int[], string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int[], FSharpFunc<int[], string>>, Unit, string, string, Tuple<int[], int[]>>("NDArray shape %A is not compatable with given parameter shape %A"));
						string message = FSharpFunc<int[], int[]>.InvokeFast<string>((FSharpFunc<int[], FSharpFunc<int[], string>>)new _0024Executor._002Dctor_0040113_002D9(clo), value.Shape, s);
						throw new ArgumentException(message, paramName);
					}
					ArrayModule.Iterate2<int, int>((FSharpFunc<int, FSharpFunc<int, Unit>>)(object)new _0024Executor._002Dctor_0040117_002D11(value, s), value.Shape, s);
					int[] shape2 = value.Shape;
					int[] array3 = shape2;
					obj = FSharpOption<int[]>.Some(array3);
				}
				else
				{
					NDArray ndarray2 = item.get_Value();
					int[] shape3 = ndarray2.Shape;
					int[] array4 = shape3;
					obj = FSharpOption<int[]>.Some(array4);
				}
			}
			shape_0040107 = (FSharpOption<int[]>)obj;
			init_0040105_002D16 = 1;
			if (name != null)
			{
				FSharpOption<string> val = name;
				string i = base.Name = val.get_Value();
			}
		}
	}
}
