using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class AtomicSymbolInfo : IEquatable<AtomicSymbolInfo>, IStructuralEquatable, IComparable<AtomicSymbolInfo>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Name_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Description_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal ArgumentInfo[] Arguments_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string ReturnTypeInfo_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string KeyVarNumArgs_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Name => Name_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Description => Description_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public ArgumentInfo[] Arguments => Arguments_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string ReturnTypeInfo => ReturnTypeInfo_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string KeyVarNumArgs => KeyVarNumArgs_0040;

		public AtomicSymbolInfo(string name, string description, ArgumentInfo[] arguments, string returnTypeInfo, string keyVarNumArgs)
		{
			Name_0040 = name;
			Description_0040 = description;
			Arguments_0040 = arguments;
			ReturnTypeInfo_0040 = returnTypeInfo;
			KeyVarNumArgs_0040 = keyVarNumArgs;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AtomicSymbolInfo, string>>((PrintfFormat<FSharpFunc<AtomicSymbolInfo, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AtomicSymbolInfo, string>, Unit, string, string, AtomicSymbolInfo>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(AtomicSymbolInfo obj)
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
					int num4 = string.CompareOrdinal(ReturnTypeInfo_0040, obj.ReturnTypeInfo_0040);
					if (num4 < 0)
					{
						return num4;
					}
					if (num4 > 0)
					{
						return num4;
					}
					IComparer genericComparer4 = LanguagePrimitives.get_GenericComparer();
					return string.CompareOrdinal(KeyVarNumArgs_0040, obj.KeyVarNumArgs_0040);
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
			return CompareTo((AtomicSymbolInfo)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			AtomicSymbolInfo atomicSymbolInfo = (AtomicSymbolInfo)obj;
			AtomicSymbolInfo atomicSymbolInfo2 = atomicSymbolInfo;
			if (this != null)
			{
				if ((AtomicSymbolInfo)obj != null)
				{
					int num = string.CompareOrdinal(Name_0040, atomicSymbolInfo2.Name_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = string.CompareOrdinal(Description_0040, atomicSymbolInfo2.Description_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					int num3 = HashCompare.GenericComparisonWithComparerIntrinsic<ArgumentInfo[]>(comp, Arguments_0040, atomicSymbolInfo2.Arguments_0040);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					int num4 = string.CompareOrdinal(ReturnTypeInfo_0040, atomicSymbolInfo2.ReturnTypeInfo_0040);
					if (num4 < 0)
					{
						return num4;
					}
					if (num4 > 0)
					{
						return num4;
					}
					return string.CompareOrdinal(KeyVarNumArgs_0040, atomicSymbolInfo2.KeyVarNumArgs_0040);
				}
				return 1;
			}
			if ((AtomicSymbolInfo)obj != null)
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
				num = -1640531527 + ((KeyVarNumArgs_0040?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
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
				AtomicSymbolInfo atomicSymbolInfo = obj as AtomicSymbolInfo;
				if (atomicSymbolInfo != null)
				{
					AtomicSymbolInfo atomicSymbolInfo2 = atomicSymbolInfo;
					if (string.Equals(Name_0040, atomicSymbolInfo2.Name_0040))
					{
						if (string.Equals(Description_0040, atomicSymbolInfo2.Description_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<ArgumentInfo[]>(comp, Arguments_0040, atomicSymbolInfo2.Arguments_0040))
							{
								if (string.Equals(ReturnTypeInfo_0040, atomicSymbolInfo2.ReturnTypeInfo_0040))
								{
									return string.Equals(KeyVarNumArgs_0040, atomicSymbolInfo2.KeyVarNumArgs_0040);
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
		public sealed override bool Equals(AtomicSymbolInfo obj)
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
								if (string.Equals(ReturnTypeInfo_0040, obj.ReturnTypeInfo_0040))
								{
									return string.Equals(KeyVarNumArgs_0040, obj.KeyVarNumArgs_0040);
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
			AtomicSymbolInfo atomicSymbolInfo = obj as AtomicSymbolInfo;
			if (atomicSymbolInfo != null)
			{
				return Equals(atomicSymbolInfo);
			}
			return false;
		}
	}
}
