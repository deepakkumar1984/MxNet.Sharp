using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class InferShapeResult<a> : IEquatable<InferShapeResult<a>>, IStructuralEquatable, IComparable<InferShapeResult<a>>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal bool Complete_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal a[][] AuxShapes_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal a[][] InputShapes_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal a[][] OutputShapes_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public bool Complete => Complete_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public a[][] AuxShapes => AuxShapes_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public a[][] InputShapes => InputShapes_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public a[][] OutputShapes => OutputShapes_0040;

		public InferShapeResult(bool complete, a[][] auxShapes, a[][] inputShapes, a[][] outputShapes)
		{
			Complete_0040 = complete;
			AuxShapes_0040 = auxShapes;
			InputShapes_0040 = inputShapes;
			OutputShapes_0040 = outputShapes;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ((FSharpFunc<InferShapeResult<InferShapeResult<a>>, string>)(object)ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<InferShapeResult<a>, string>>((PrintfFormat<FSharpFunc<InferShapeResult<a>, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<InferShapeResult<FSharpFunc<InferShapeResult<a>, string>>, string>, Unit, string, string, InferShapeResult<FSharpFunc<InferShapeResult<a>, string>>>("%+A"))).Invoke((InferShapeResult<InferShapeResult<a>>)(object)this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(InferShapeResult<a> obj)
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
					int num2 = HashCompare.GenericComparisonWithComparerIntrinsic<a[][]>(LanguagePrimitives.get_GenericComparer(), AuxShapes_0040, obj.AuxShapes_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<a[][]>(LanguagePrimitives.get_GenericComparer(), InputShapes_0040, obj.InputShapes_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<a[][]>(LanguagePrimitives.get_GenericComparer(), OutputShapes_0040, obj.OutputShapes_0040);
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
			return CompareTo((InferShapeResult<a>)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			InferShapeResult<a> inferShapeResult = (InferShapeResult<a>)obj;
			InferShapeResult<a> inferShapeResult2 = inferShapeResult;
			if (this != null)
			{
				if ((InferShapeResult<a>)obj != null)
				{
					bool complete_0040 = Complete_0040;
					bool complete_00402 = inferShapeResult2.Complete_0040;
					int num = ((complete_0040 ? 1 : 0) >= (complete_00402 ? 1 : 0)) ? (((complete_0040 ? 1 : 0) > (complete_00402 ? 1 : 0)) ? 1 : 0) : (-1);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = HashCompare.GenericComparisonWithComparerIntrinsic<a[][]>(comp, AuxShapes_0040, inferShapeResult2.AuxShapes_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<a[][]>(comp, InputShapes_0040, inferShapeResult2.InputShapes_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<a[][]>(comp, OutputShapes_0040, inferShapeResult2.OutputShapes_0040);
				}
				return 1;
			}
			if ((InferShapeResult<a>)obj != null)
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
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<a[][]>(comp, OutputShapes_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<a[][]>(comp, InputShapes_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<a[][]>(comp, AuxShapes_0040) + ((num << 6) + (num >> 2)));
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
				InferShapeResult<a> inferShapeResult = obj as InferShapeResult<a>;
				if (inferShapeResult != null)
				{
					InferShapeResult<a> inferShapeResult2 = inferShapeResult;
					if (Complete_0040 == inferShapeResult2.Complete_0040)
					{
						if (HashCompare.GenericEqualityWithComparerIntrinsic<a[][]>(comp, AuxShapes_0040, inferShapeResult2.AuxShapes_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<a[][]>(comp, InputShapes_0040, inferShapeResult2.InputShapes_0040))
							{
								return HashCompare.GenericEqualityWithComparerIntrinsic<a[][]>(comp, OutputShapes_0040, inferShapeResult2.OutputShapes_0040);
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
		public sealed override bool Equals(InferShapeResult<a> obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (Complete_0040 == obj.Complete_0040)
					{
						if (HashCompare.GenericEqualityERIntrinsic<a[][]>(AuxShapes_0040, obj.AuxShapes_0040))
						{
							if (HashCompare.GenericEqualityERIntrinsic<a[][]>(InputShapes_0040, obj.InputShapes_0040))
							{
								return HashCompare.GenericEqualityERIntrinsic<a[][]>(OutputShapes_0040, obj.OutputShapes_0040);
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
			InferShapeResult<a> inferShapeResult = obj as InferShapeResult<a>;
			if (inferShapeResult != null)
			{
				return Equals(inferShapeResult);
			}
			return false;
		}
	}
}
