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
	public sealed class AuxBind : IEquatable<AuxBind>, IStructuralEquatable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Name_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FSharpOption<NDArray> NDArray_0040;

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
		public FSharpOption<int[]> Shape => Shape_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<DataType> DataType => DataType_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<StorageType> StorageType => StorageType_0040;

		public AuxBind(string name, FSharpOption<NDArray> nDArray, FSharpOption<int[]> shape, FSharpOption<DataType> dataType, FSharpOption<StorageType> storageType)
		{
			Name_0040 = name;
			NDArray_0040 = nDArray;
			Shape_0040 = shape;
			DataType_0040 = dataType;
			StorageType_0040 = storageType;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AuxBind, string>>((PrintfFormat<FSharpFunc<AuxBind, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AuxBind, string>, Unit, string, string, AuxBind>("%+A")).Invoke(this);
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
				AuxBind auxBind = obj as AuxBind;
				if (auxBind != null)
				{
					AuxBind auxBind2 = auxBind;
					if (string.Equals(Name_0040, auxBind2.Name_0040))
					{
						if (HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<NDArray>>(comp, NDArray_0040, auxBind2.NDArray_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<int[]>>(comp, Shape_0040, auxBind2.Shape_0040))
							{
								if (HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<DataType>>(comp, DataType_0040, auxBind2.DataType_0040))
								{
									return HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<StorageType>>(comp, StorageType_0040, auxBind2.StorageType_0040);
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

		public static AuxBind Named(string name)
		{
			return new AuxBind(name, null, null, null, null);
		}

		[CompilerGenerated]
		public sealed override bool Equals(AuxBind obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (string.Equals(Name_0040, obj.Name_0040))
					{
						if (HashCompare.GenericEqualityERIntrinsic<FSharpOption<NDArray>>(NDArray_0040, obj.NDArray_0040))
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
			return obj == null;
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj)
		{
			AuxBind auxBind = obj as AuxBind;
			if (auxBind != null)
			{
				return Equals(auxBind);
			}
			return false;
		}
	}
}
