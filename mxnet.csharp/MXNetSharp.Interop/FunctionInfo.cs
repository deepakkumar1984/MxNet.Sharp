using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class FunctionInfo : IEquatable<FunctionInfo>, IStructuralEquatable, IComparable<FunctionInfo>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Name_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Description_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal ArgumentInfo[] Arguments_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string ReturnTypeInfo_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Name => Name_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Description => Description_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public ArgumentInfo[] Arguments => Arguments_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string ReturnTypeInfo => ReturnTypeInfo_0040;

		public FunctionInfo(string name, string description, ArgumentInfo[] arguments, string returnTypeInfo)
		{
			Name_0040 = name;
			Description_0040 = description;
			Arguments_0040 = arguments;
			ReturnTypeInfo_0040 = returnTypeInfo;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<FunctionInfo, string>>((PrintfFormat<FSharpFunc<FunctionInfo, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<FunctionInfo, string>, Unit, string, string, FunctionInfo>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(FunctionInfo obj)
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
					IComparer genericComparer2 = LanguagePrimitives.get_GenericComparer();
					int num2 = string.CompareOrdinal(Description_0040, obj.Description_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<ArgumentInfo[]>(LanguagePrimitives.get_GenericComparer(), Arguments_0040, obj.Arguments_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					IComparer genericComparer3 = LanguagePrimitives.get_GenericComparer();
					return string.CompareOrdinal(ReturnTypeInfo_0040, obj.ReturnTypeInfo_0040);
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
			return CompareTo((FunctionInfo)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			FunctionInfo functionInfo = (FunctionInfo)obj;
			FunctionInfo functionInfo2 = functionInfo;
			if (this != null)
			{
				if ((FunctionInfo)obj != null)
				{
					int num = string.CompareOrdinal(Name_0040, functionInfo2.Name_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = string.CompareOrdinal(Description_0040, functionInfo2.Description_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<ArgumentInfo[]>(comp, Arguments_0040, functionInfo2.Arguments_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					return string.CompareOrdinal(ReturnTypeInfo_0040, functionInfo2.ReturnTypeInfo_0040);
				}
				return 1;
			}
			if ((FunctionInfo)obj != null)
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
				num = -1640531527 + ((ReturnTypeInfo_0040?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<ArgumentInfo[]>(comp, Arguments_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + ((Description_0040?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
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
				FunctionInfo functionInfo = obj as FunctionInfo;
				if (functionInfo != null)
				{
					FunctionInfo functionInfo2 = functionInfo;
					if (string.Equals(Name_0040, functionInfo2.Name_0040))
					{
						if (string.Equals(Description_0040, functionInfo2.Description_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<ArgumentInfo[]>(comp, Arguments_0040, functionInfo2.Arguments_0040))
							{
								return string.Equals(ReturnTypeInfo_0040, functionInfo2.ReturnTypeInfo_0040);
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
		public sealed override bool Equals(FunctionInfo obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (string.Equals(Name_0040, obj.Name_0040))
					{
						if (string.Equals(Description_0040, obj.Description_0040))
						{
							if (HashCompare.GenericEqualityERIntrinsic<ArgumentInfo[]>(Arguments_0040, obj.Arguments_0040))
							{
								return string.Equals(ReturnTypeInfo_0040, obj.ReturnTypeInfo_0040);
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
			FunctionInfo functionInfo = obj as FunctionInfo;
			if (functionInfo != null)
			{
				return Equals(functionInfo);
			}
			return false;
		}
	}
}
