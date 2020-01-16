using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp
{
	[Serializable]
	[NoComparison]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class ArgBind : IEquatable<ArgBind>, IStructuralEquatable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Name_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FSharpOption<NDArray> NDArray_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FSharpOption<NDArray> Grad_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FSharpOption<OpReqType> OpReqType_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FSharpOption<int[]> Shape_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FSharpOption<DataType> DataType_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FSharpOption<StorageType> StorageType_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Name => Name_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<NDArray> NDArray => NDArray_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<NDArray> Grad => Grad_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<OpReqType> OpReqType => OpReqType_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<int[]> Shape => Shape_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<DataType> DataType => DataType_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<StorageType> StorageType => StorageType_0040;

		public ArgBind(string name, FSharpOption<NDArray> nDArray, FSharpOption<NDArray> grad, FSharpOption<OpReqType> opReqType, FSharpOption<int[]> shape, FSharpOption<DataType> dataType, FSharpOption<StorageType> storageType)
		{
			Name_0040 = name;
			NDArray_0040 = nDArray;
			Grad_0040 = grad;
			OpReqType_0040 = opReqType;
			Shape_0040 = shape;
			DataType_0040 = dataType;
			StorageType_0040 = storageType;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ArgBind, string>>((PrintfFormat<FSharpFunc<ArgBind, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ArgBind, string>, Unit, string, string, ArgBind>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				int num = 0;
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<FSharpOption<StorageType>>(comp, StorageType_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<FSharpOption<DataType>>(comp, DataType_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<FSharpOption<int[]>>(comp, Shape_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<FSharpOption<OpReqType>>(comp, OpReqType_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<FSharpOption<NDArray>>(comp, Grad_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<FSharpOption<NDArray>>(comp, NDArray_0040) + ((num << 6) + (num >> 2)));
				return -1640531527 + ((Name_0040?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
			}
			return 0;
		}

		[CompilerGenerated]
		public sealed override int GetHashCode()
		{
			return GetHashCode(LanguagePrimitives.get_GenericEqualityComparer());
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj, IEqualityComparer comp)
		{
			if (this != null)
			{
				ArgBind argBind = obj as ArgBind;
				if (argBind != null)
				{
					ArgBind argBind2 = argBind;
					if (string.Equals(Name_0040, argBind2.Name_0040))
					{
						if (HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<NDArray>>(comp, NDArray_0040, argBind2.NDArray_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<NDArray>>(comp, Grad_0040, argBind2.Grad_0040))
							{
								if (HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<OpReqType>>(comp, OpReqType_0040, argBind2.OpReqType_0040))
								{
									if (HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<int[]>>(comp, Shape_0040, argBind2.Shape_0040))
									{
										if (HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<DataType>>(comp, DataType_0040, argBind2.DataType_0040))
										{
											return HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<StorageType>>(comp, StorageType_0040, argBind2.StorageType_0040);
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return obj == null;
		}

		public static ArgBind Named(string name)
		{
			return new ArgBind(name, null, null, null, null, null, null);
		}

		[CompilerGenerated]
		public sealed override bool Equals(ArgBind obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (string.Equals(Name_0040, obj.Name_0040))
					{
						if (HashCompare.GenericEqualityERIntrinsic<FSharpOption<NDArray>>(NDArray_0040, obj.NDArray_0040))
						{
							if (HashCompare.GenericEqualityERIntrinsic<FSharpOption<NDArray>>(Grad_0040, obj.Grad_0040))
							{
								if (HashCompare.GenericEqualityERIntrinsic<FSharpOption<OpReqType>>(OpReqType_0040, obj.OpReqType_0040))
								{
									if (HashCompare.GenericEqualityERIntrinsic<FSharpOption<int[]>>(Shape_0040, obj.Shape_0040))
									{
										if (HashCompare.GenericEqualityERIntrinsic<FSharpOption<DataType>>(DataType_0040, obj.DataType_0040))
										{
											return HashCompare.GenericEqualityERIntrinsic<FSharpOption<StorageType>>(StorageType_0040, obj.StorageType_0040);
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return obj == null;
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj)
		{
			ArgBind argBind = obj as ArgBind;
			if (argBind != null)
			{
				return Equals(argBind);
			}
			return false;
		}
	}
}
