using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class DataIterInfo : IEquatable<DataIterInfo>, IStructuralEquatable, IComparable<DataIterInfo>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Name_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Description_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal ArgumentInfo[] Arguments_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Name => Name_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Description => Description_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public ArgumentInfo[] Arguments => Arguments_0040;

		public DataIterInfo(string name, string description, ArgumentInfo[] arguments)
		{
			Name_0040 = name;
			Description_0040 = description;
			Arguments_0040 = arguments;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<DataIterInfo, string>>((PrintfFormat<FSharpFunc<DataIterInfo, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<DataIterInfo, string>, Unit, string, string, DataIterInfo>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(DataIterInfo obj)
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
					return HashCompare.GenericComparisonWithComparerIntrinsic<ArgumentInfo[]>(LanguagePrimitives.get_GenericComparer(), Arguments_0040, obj.Arguments_0040);
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
			return CompareTo((DataIterInfo)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			DataIterInfo dataIterInfo = (DataIterInfo)obj;
			DataIterInfo dataIterInfo2 = dataIterInfo;
			if (this != null)
			{
				if ((DataIterInfo)obj != null)
				{
					int num = string.CompareOrdinal(Name_0040, dataIterInfo2.Name_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					int num2 = string.CompareOrdinal(Description_0040, dataIterInfo2.Description_0040);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					return HashCompare.GenericComparisonWithComparerIntrinsic<ArgumentInfo[]>(comp, Arguments_0040, dataIterInfo2.Arguments_0040);
				}
				return 1;
			}
			if ((DataIterInfo)obj != null)
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
				DataIterInfo dataIterInfo = obj as DataIterInfo;
				if (dataIterInfo != null)
				{
					DataIterInfo dataIterInfo2 = dataIterInfo;
					if (string.Equals(Name_0040, dataIterInfo2.Name_0040))
					{
						if (string.Equals(Description_0040, dataIterInfo2.Description_0040))
						{
							return HashCompare.GenericEqualityWithComparerIntrinsic<ArgumentInfo[]>(comp, Arguments_0040, dataIterInfo2.Arguments_0040);
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
		public sealed override bool Equals(DataIterInfo obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (string.Equals(Name_0040, obj.Name_0040))
					{
						if (string.Equals(Description_0040, obj.Description_0040))
						{
							return HashCompare.GenericEqualityERIntrinsic<ArgumentInfo[]>(Arguments_0040, obj.Arguments_0040);
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
			DataIterInfo dataIterInfo = obj as DataIterInfo;
			if (dataIterInfo != null)
			{
				return Equals(dataIterInfo);
			}
			return false;
		}
	}
}
