using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class InferTypeResult : IEquatable<InferTypeResult>, IStructuralEquatable, IComparable<InferTypeResult>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal bool Complete_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int[] AuxTypes_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int[] InputTypes_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int[] OutputTypes_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public bool Complete => Complete_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public int[] AuxTypes => AuxTypes_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public int[] InputTypes => InputTypes_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public int[] OutputTypes => OutputTypes_0040;

		public InferTypeResult(bool complete, int[] auxTypes, int[] inputTypes, int[] outputTypes)
		{
			Complete_0040 = complete;
			AuxTypes_0040 = auxTypes;
			InputTypes_0040 = inputTypes;
			OutputTypes_0040 = outputTypes;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<InferTypeResult, string>>((PrintfFormat<FSharpFunc<InferTypeResult, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<InferTypeResult, string>, Unit, string, string, InferTypeResult>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(InferTypeResult obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					IComparer genericComparer = LanguagePrimitives.get_GenericComparer();
					bool complete_0040 = Complete_0040;
					bool complete_00402 = obj.Complete_0040;
					int num = ((complete_0040 ? 1 : 0) >= (complete_00402 ? 1 : 0)) ? (((complete_0040 ? 1 : 0) > (complete_00402 ? 1 : 0)) ? 1 : 0) : (-1);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = HashCompare.GenericComparisonWithComparerIntrinsic<int[]>(LanguagePrimitives.get_GenericComparer(), AuxTypes_0040, obj.AuxTypes_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<int[]>(LanguagePrimitives.get_GenericComparer(), InputTypes_0040, obj.InputTypes_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<int[]>(LanguagePrimitives.get_GenericComparer(), OutputTypes_0040, obj.OutputTypes_0040);
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
			return CompareTo((InferTypeResult)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			InferTypeResult inferTypeResult = (InferTypeResult)obj;
			InferTypeResult inferTypeResult2 = inferTypeResult;
			if (this != null)
			{
				if ((InferTypeResult)obj != null)
				{
					bool complete_0040 = Complete_0040;
					bool complete_00402 = inferTypeResult2.Complete_0040;
					int num = ((complete_0040 ? 1 : 0) >= (complete_00402 ? 1 : 0)) ? (((complete_0040 ? 1 : 0) > (complete_00402 ? 1 : 0)) ? 1 : 0) : (-1);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = HashCompare.GenericComparisonWithComparerIntrinsic<int[]>(comp, AuxTypes_0040, inferTypeResult2.AuxTypes_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<int[]>(comp, InputTypes_0040, inferTypeResult2.InputTypes_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<int[]>(comp, OutputTypes_0040, inferTypeResult2.OutputTypes_0040);
				}
				return 1;
			}
			if ((InferTypeResult)obj != null)
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
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<int[]>(comp, OutputTypes_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<int[]>(comp, InputTypes_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<int[]>(comp, AuxTypes_0040) + ((num << 6) + (num >> 2)));
				return -1640531527 + ((Complete_0040 ? 1 : 0) + ((num << 6) + (num >> 2)));
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
				InferTypeResult inferTypeResult = obj as InferTypeResult;
				if (inferTypeResult != null)
				{
					InferTypeResult inferTypeResult2 = inferTypeResult;
					if (Complete_0040 == inferTypeResult2.Complete_0040)
					{
						if (HashCompare.GenericEqualityWithComparerIntrinsic<int[]>(comp, AuxTypes_0040, inferTypeResult2.AuxTypes_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<int[]>(comp, InputTypes_0040, inferTypeResult2.InputTypes_0040))
							{
								return HashCompare.GenericEqualityWithComparerIntrinsic<int[]>(comp, OutputTypes_0040, inferTypeResult2.OutputTypes_0040);
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
		public sealed override bool Equals(InferTypeResult obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (Complete_0040 == obj.Complete_0040)
					{
						if (HashCompare.GenericEqualityERIntrinsic<int[]>(AuxTypes_0040, obj.AuxTypes_0040))
						{
							if (HashCompare.GenericEqualityERIntrinsic<int[]>(InputTypes_0040, obj.InputTypes_0040))
							{
								return HashCompare.GenericEqualityERIntrinsic<int[]>(OutputTypes_0040, obj.OutputTypes_0040);
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
			InferTypeResult inferTypeResult = obj as InferTypeResult;
			if (inferTypeResult != null)
			{
				return Equals(inferTypeResult);
			}
			return false;
		}
	}
}
