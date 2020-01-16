using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Operator
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class BackwardStorageTypes : IEquatable<BackwardStorageTypes>, IStructuralEquatable, IComparable<BackwardStorageTypes>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal StorageType[] InputGrad_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal StorageType[] OutputGrad_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal StorageType[] Input_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal StorageType[] Output_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal StorageType[] Auxiliary_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public StorageType[] InputGrad => InputGrad_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public StorageType[] OutputGrad => OutputGrad_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public StorageType[] Input => Input_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public StorageType[] Output => Output_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public StorageType[] Auxiliary => Auxiliary_0040;

		public BackwardStorageTypes(StorageType[] inputGrad, StorageType[] outputGrad, StorageType[] input, StorageType[] output, StorageType[] auxiliary)
		{
			InputGrad_0040 = inputGrad;
			OutputGrad_0040 = outputGrad;
			Input_0040 = input;
			Output_0040 = output;
			Auxiliary_0040 = auxiliary;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<BackwardStorageTypes, string>>((PrintfFormat<FSharpFunc<BackwardStorageTypes, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<BackwardStorageTypes, string>, Unit, string, string, BackwardStorageTypes>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(BackwardStorageTypes obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					int num = HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(LanguagePrimitives.get_GenericComparer(), InputGrad_0040, obj.InputGrad_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(LanguagePrimitives.get_GenericComparer(), OutputGrad_0040, obj.OutputGrad_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(LanguagePrimitives.get_GenericComparer(), Input_0040, obj.Input_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					int num4 = HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(LanguagePrimitives.get_GenericComparer(), Output_0040, obj.Output_0040);
					if (num4 < 0)
					{
						return num4;
					}
					if (num4 > 0)
					{
						return num4;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(LanguagePrimitives.get_GenericComparer(), Auxiliary_0040, obj.Auxiliary_0040);
				}
				return 1;
			}
			if (obj != null)
			{
				return -1;
			}
			return 0;
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj)
		{
			return CompareTo((BackwardStorageTypes)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			BackwardStorageTypes backwardStorageTypes = (BackwardStorageTypes)obj;
			BackwardStorageTypes backwardStorageTypes2 = backwardStorageTypes;
			if (this != null)
			{
				if ((BackwardStorageTypes)obj != null)
				{
					int num = HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(comp, InputGrad_0040, backwardStorageTypes2.InputGrad_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(comp, OutputGrad_0040, backwardStorageTypes2.OutputGrad_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(comp, Input_0040, backwardStorageTypes2.Input_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					int num4 = HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(comp, Output_0040, backwardStorageTypes2.Output_0040);
					if (num4 < 0)
					{
						return num4;
					}
					if (num4 > 0)
					{
						return num4;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<StorageType[]>(comp, Auxiliary_0040, backwardStorageTypes2.Auxiliary_0040);
				}
				return 1;
			}
			if ((BackwardStorageTypes)obj != null)
			{
				return -1;
			}
			return 0;
		}

		[CompilerGenerated]
		public sealed override int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				int num = 0;
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<StorageType[]>(comp, Auxiliary_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<StorageType[]>(comp, Output_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<StorageType[]>(comp, Input_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<StorageType[]>(comp, OutputGrad_0040) + ((num << 6) + (num >> 2)));
				return -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<StorageType[]>(comp, InputGrad_0040) + ((num << 6) + (num >> 2)));
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
				BackwardStorageTypes backwardStorageTypes = obj as BackwardStorageTypes;
				if (backwardStorageTypes != null)
				{
					BackwardStorageTypes backwardStorageTypes2 = backwardStorageTypes;
					if (HashCompare.GenericEqualityWithComparerIntrinsic<StorageType[]>(comp, InputGrad_0040, backwardStorageTypes2.InputGrad_0040))
					{
						if (HashCompare.GenericEqualityWithComparerIntrinsic<StorageType[]>(comp, OutputGrad_0040, backwardStorageTypes2.OutputGrad_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<StorageType[]>(comp, Input_0040, backwardStorageTypes2.Input_0040))
							{
								if (HashCompare.GenericEqualityWithComparerIntrinsic<StorageType[]>(comp, Output_0040, backwardStorageTypes2.Output_0040))
								{
									return HashCompare.GenericEqualityWithComparerIntrinsic<StorageType[]>(comp, Auxiliary_0040, backwardStorageTypes2.Auxiliary_0040);
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
		public sealed override bool Equals(BackwardStorageTypes obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (HashCompare.GenericEqualityERIntrinsic<StorageType[]>(InputGrad_0040, obj.InputGrad_0040))
					{
						if (HashCompare.GenericEqualityERIntrinsic<StorageType[]>(OutputGrad_0040, obj.OutputGrad_0040))
						{
							if (HashCompare.GenericEqualityERIntrinsic<StorageType[]>(Input_0040, obj.Input_0040))
							{
								if (HashCompare.GenericEqualityERIntrinsic<StorageType[]>(Output_0040, obj.Output_0040))
								{
									return HashCompare.GenericEqualityERIntrinsic<StorageType[]>(Auxiliary_0040, obj.Auxiliary_0040);
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
			BackwardStorageTypes backwardStorageTypes = obj as BackwardStorageTypes;
			if (backwardStorageTypes != null)
			{
				return Equals(backwardStorageTypes);
			}
			return false;
		}
	}
}
