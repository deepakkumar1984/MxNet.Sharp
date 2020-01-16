using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class ArgumentInfo : IEquatable<ArgumentInfo>, IStructuralEquatable, IComparable<ArgumentInfo>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Name_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Description_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string TypeInfo_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Name => Name_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Description => Description_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string TypeInfo => TypeInfo_0040;

		public ArgumentInfo(string name, string description, string typeInfo)
		{
			Name_0040 = name;
			Description_0040 = description;
			TypeInfo_0040 = typeInfo;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ArgumentInfo, string>>((PrintfFormat<FSharpFunc<ArgumentInfo, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ArgumentInfo, string>, Unit, string, string, ArgumentInfo>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(ArgumentInfo obj)
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
					IComparer genericComparer3 = LanguagePrimitives.get_GenericComparer();
					return string.CompareOrdinal(TypeInfo_0040, obj.TypeInfo_0040);
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
			return CompareTo((ArgumentInfo)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			ArgumentInfo argumentInfo = (ArgumentInfo)obj;
			ArgumentInfo argumentInfo2 = argumentInfo;
			if (this != null)
			{
				if ((ArgumentInfo)obj != null)
				{
					int num = string.CompareOrdinal(Name_0040, argumentInfo2.Name_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = string.CompareOrdinal(Description_0040, argumentInfo2.Description_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					return string.CompareOrdinal(TypeInfo_0040, argumentInfo2.TypeInfo_0040);
				}
				return 1;
			}
			if ((ArgumentInfo)obj != null)
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
				num = -1640531527 + ((TypeInfo_0040?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
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
				ArgumentInfo argumentInfo = obj as ArgumentInfo;
				if (argumentInfo != null)
				{
					ArgumentInfo argumentInfo2 = argumentInfo;
					if (string.Equals(Name_0040, argumentInfo2.Name_0040))
					{
						if (string.Equals(Description_0040, argumentInfo2.Description_0040))
						{
							return string.Equals(TypeInfo_0040, argumentInfo2.TypeInfo_0040);
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
		public sealed override bool Equals(ArgumentInfo obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (string.Equals(Name_0040, obj.Name_0040))
					{
						if (string.Equals(Description_0040, obj.Description_0040))
						{
							return string.Equals(TypeInfo_0040, obj.TypeInfo_0040);
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
			ArgumentInfo argumentInfo = obj as ArgumentInfo;
			if (argumentInfo != null)
			{
				return Equals(argumentInfo);
			}
			return false;
		}
	}
}
