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
	public sealed class NewAxis : IEquatable<NewAxis>, IStructuralEquatable, IComparable<NewAxis>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly NewAxis _unique_NewAxis = new NewAxis();

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Tag
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return 0;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static NewAxis NewAxis
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_NewAxis;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal NewAxis()
		{
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<NewAxis, string>>((PrintfFormat<FSharpFunc<NewAxis, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<NewAxis, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<NewAxis, string>>((PrintfFormat<FSharpFunc<NewAxis, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<NewAxis, string>, Unit, string, string, NewAxis>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(NewAxis obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					return 0;
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
			return CompareTo((NewAxis)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			NewAxis newAxis = (NewAxis)obj;
			if (this != null)
			{
				if ((NewAxis)obj != null)
				{
					return 0;
				}
				return 1;
			}
			if ((NewAxis)obj != null)
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
				return 0;
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
				NewAxis newAxis = obj as NewAxis;
				if (newAxis != null)
				{
					NewAxis newAxis2 = newAxis;
					return true;
				}
				return false;
			}
			return obj == null;
		}

		[CompilerGenerated]
		public sealed override bool Equals(NewAxis obj)
		{
			if (this != null)
			{
				return obj != null;
			}
			return obj == null;
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj)
		{
			NewAxis newAxis = obj as NewAxis;
			if (newAxis != null)
			{
				return Equals(newAxis);
			}
			return false;
		}
	}
}
