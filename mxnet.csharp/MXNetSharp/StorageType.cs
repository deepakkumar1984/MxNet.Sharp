using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[Serializable]
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	[DebuggerDisplay("{__DebugDisplay(),nq}")]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class StorageType : IEquatable<StorageType>, IStructuralEquatable, IComparable<StorageType>, IComparable, IStructuralComparable
	{
		public static class Tags
		{
			public const int Undefined = 0;

			public const int Default = 1;

			public const int RowSparse = 2;

			public const int CSR = 3;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal readonly int _tag;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly StorageType _unique_Undefined = new StorageType(0);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly StorageType _unique_Default = new StorageType(1);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly StorageType _unique_RowSparse = new StorageType(2);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly StorageType _unique_CSR = new StorageType(3);

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[field: DebuggerNonUserCode]
		public int Tag
		{
			[DebuggerNonUserCode]
			get;
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static StorageType Undefined
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_Undefined;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsUndefined
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return Tag == 0;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static StorageType Default
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_Default;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsDefault
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return Tag == 1;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static StorageType RowSparse
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_RowSparse;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsRowSparse
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return Tag == 2;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static StorageType CSR
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_CSR;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsCSR
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return Tag == 3;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal StorageType(int _tag)
		{
			this._tag = _tag;
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<StorageType, string>>((PrintfFormat<FSharpFunc<StorageType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<StorageType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(StorageType obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					int tag = _tag;
					int tag2 = obj._tag;
					if (tag == tag2)
					{
						return 0;
					}
					return tag - tag2;
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
			return CompareTo((StorageType)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			StorageType storageType = (StorageType)obj;
			if (this != null)
			{
				if ((StorageType)obj != null)
				{
					int tag = _tag;
					int tag2 = storageType._tag;
					if (tag == tag2)
					{
						return 0;
					}
					return tag - tag2;
				}
				return 1;
			}
			if ((StorageType)obj != null)
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
				return _tag;
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
				StorageType storageType = obj as StorageType;
				if (storageType != null)
				{
					StorageType storageType2 = storageType;
					int tag = _tag;
					int tag2 = storageType2._tag;
					return tag == tag2;
				}
				return false;
			}
			return obj == null;
		}

		public static StorageType FromInt(int n)
		{
			switch (n)
			{
			case -1:
				return Undefined;
			case 0:
				return Default;
			case 1:
				return RowSparse;
			case 2:
				return CSR;
			default:
			{
				string paramName = "n";
				string message = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int, string>>((PrintfFormat<FSharpFunc<int, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("Storage type %d is not surported")).Invoke(n);
				throw new ArgumentException(message, paramName);
			}
			}
		}

		public int ToInt()
		{
			switch (Tag)
			{
			default:
				return -1;
			case 1:
				return 0;
			case 2:
				return 1;
			case 3:
				return 2;
			}
		}

		public static explicit operator int(StorageType st)
		{
			return st.ToInt();
		}

		public override string ToString()
		{
			switch (Tag)
			{
			default:
				return "csr";
			case 1:
				return "default";
			case 2:
				return "row_sparse";
			case 0:
				return "";
			}
		}

		[CompilerGenerated]
		public sealed override bool Equals(StorageType obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					int tag = _tag;
					int tag2 = obj._tag;
					return tag == tag2;
				}
				return false;
			}
			return obj == null;
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj)
		{
			StorageType storageType = obj as StorageType;
			if (storageType != null)
			{
				return Equals(storageType);
			}
			return false;
		}
	}
}
