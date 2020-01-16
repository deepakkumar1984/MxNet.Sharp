using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.SymbolArgument
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class VarArg<a> : IEquatable<VarArg<a>>, IStructuralEquatable, IComparable<VarArg<a>>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Name_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal a[] Inputs_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal FSharpOption<string> NumArgsName_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Name => Name_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public a[] Inputs => Inputs_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public FSharpOption<string> NumArgsName => NumArgsName_0040;

		public VarArg(string name, a[] inputs, FSharpOption<string> numArgsName)
		{
			Name_0040 = name;
			Inputs_0040 = inputs;
			NumArgsName_0040 = numArgsName;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ((FSharpFunc<VarArg<VarArg<a>>, string>)(object)ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<VarArg<a>, string>>((PrintfFormat<FSharpFunc<VarArg<a>, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<VarArg<FSharpFunc<VarArg<a>, string>>, string>, Unit, string, string, VarArg<FSharpFunc<VarArg<a>, string>>>("%+A"))).Invoke((VarArg<VarArg<a>>)(object)this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(VarArg<a> obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					IComparer genericComparer = LanguagePrimitives.get_GenericComparer();
					int num = string.CompareOrdinal(Name_0040, obj.Name_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = HashCompare.GenericComparisonWithComparerIntrinsic<a[]>(LanguagePrimitives.get_GenericComparer(), Inputs_0040, obj.Inputs_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<FSharpOption<string>>(LanguagePrimitives.get_GenericComparer(), NumArgsName_0040, obj.NumArgsName_0040);
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
			return CompareTo((VarArg<a>)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			VarArg<a> varArg = (VarArg<a>)obj;
			VarArg<a> varArg2 = varArg;
			if (this != null)
			{
				if ((VarArg<a>)obj != null)
				{
					int num = string.CompareOrdinal(Name_0040, varArg2.Name_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = HashCompare.GenericComparisonWithComparerIntrinsic<a[]>(comp, Inputs_0040, varArg2.Inputs_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<FSharpOption<string>>(comp, NumArgsName_0040, varArg2.NumArgsName_0040);
				}
				return 1;
			}
			if ((VarArg<a>)obj != null)
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
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<FSharpOption<string>>(comp, NumArgsName_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<a[]>(comp, Inputs_0040) + ((num << 6) + (num >> 2)));
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
				VarArg<a> varArg = obj as VarArg<a>;
				if (varArg != null)
				{
					VarArg<a> varArg2 = varArg;
					if (string.Equals(Name_0040, varArg2.Name_0040))
					{
						if (HashCompare.GenericEqualityWithComparerIntrinsic<a[]>(comp, Inputs_0040, varArg2.Inputs_0040))
						{
							return HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<string>>(comp, NumArgsName_0040, varArg2.NumArgsName_0040);
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
		public sealed override bool Equals(VarArg<a> obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (string.Equals(Name_0040, obj.Name_0040))
					{
						if (HashCompare.GenericEqualityERIntrinsic<a[]>(Inputs_0040, obj.Inputs_0040))
						{
							return HashCompare.GenericEqualityERIntrinsic<FSharpOption<string>>(NumArgsName_0040, obj.NumArgsName_0040);
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
			VarArg<a> varArg = obj as VarArg<a>;
			if (varArg != null)
			{
				return Equals(varArg);
			}
			return false;
		}
	}
}
