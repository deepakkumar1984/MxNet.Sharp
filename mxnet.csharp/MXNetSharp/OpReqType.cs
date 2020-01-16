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
	public sealed class OpReqType : IEquatable<OpReqType>, IStructuralEquatable, IComparable<OpReqType>, IComparable, IStructuralComparable
	{
		public static class Tags
		{
			public const int NullOp = 0;

			public const int WriteTo = 1;

			public const int WriteInplace = 2;

			public const int AddTo = 3;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal readonly int _tag;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly OpReqType _unique_NullOp = new OpReqType(0);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly OpReqType _unique_WriteTo = new OpReqType(1);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly OpReqType _unique_WriteInplace = new OpReqType(2);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly OpReqType _unique_AddTo = new OpReqType(3);

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
		public static OpReqType NullOp
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_NullOp;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsNullOp
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
		public static OpReqType WriteTo
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_WriteTo;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsWriteTo
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
		public static OpReqType WriteInplace
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_WriteInplace;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsWriteInplace
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
		public static OpReqType AddTo
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_AddTo;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsAddTo
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return Tag == 3;
			}
		}

		public int OpReqTypeInt
		{
			get
			{
				switch (Tag)
				{
				default:
					return 0;
				case 1:
					return 1;
				case 2:
					return 2;
				case 3:
					return 3;
				}
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal OpReqType(int _tag)
		{
			this._tag = _tag;
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<OpReqType, string>>((PrintfFormat<FSharpFunc<OpReqType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<OpReqType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<OpReqType, string>>((PrintfFormat<FSharpFunc<OpReqType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<OpReqType, string>, Unit, string, string, OpReqType>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(OpReqType obj)
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
			return CompareTo((OpReqType)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			OpReqType opReqType = (OpReqType)obj;
			if (this != null)
			{
				if ((OpReqType)obj != null)
				{
					int tag = _tag;
					int tag2 = opReqType._tag;
					if (tag == tag2)
					{
						return 0;
					}
					return tag - tag2;
				}
				return 1;
			}
			if ((OpReqType)obj != null)
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
				OpReqType opReqType = obj as OpReqType;
				if (opReqType != null)
				{
					OpReqType opReqType2 = opReqType;
					int tag = _tag;
					int tag2 = opReqType2._tag;
					return tag == tag2;
				}
				return false;
			}
			return obj == null;
		}

		public static OpReqType FromInt(int i)
		{
			switch (i)
			{
			case 0:
				return NullOp;
			case 1:
				return WriteTo;
			case 2:
				return WriteInplace;
			case 3:
				return AddTo;
			default:
			{
				string paramName = "i";
				string message = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int, string>>((PrintfFormat<FSharpFunc<int, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("OpReqType must be in {0,1,2,3}. Received %d")).Invoke(i);
				throw new ArgumentException(message, paramName);
			}
			}
		}

		public static explicit operator int(OpReqType st)
		{
			return st.OpReqTypeInt;
		}

		public static explicit operator uint(OpReqType st)
		{
			return (uint)st.OpReqTypeInt;
		}

		[CompilerGenerated]
		public sealed override bool Equals(OpReqType obj)
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
			OpReqType opReqType = obj as OpReqType;
			if (opReqType != null)
			{
				return Equals(opReqType);
			}
			return false;
		}
	}
}
