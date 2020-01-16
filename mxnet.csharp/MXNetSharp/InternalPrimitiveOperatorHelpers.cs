using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class InternalPrimitiveOperatorHelpers
	{
		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class Dummy1 : IEquatable<Dummy1>, IStructuralEquatable, IComparable<Dummy1>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly Dummy1 _unique_Dummy1 = new Dummy1();

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
			public static Dummy1 Dummy1
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Dummy1;
				}
			}

			public static Dummy1 Instance => Dummy1;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Dummy1()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Dummy1, string>>((PrintfFormat<FSharpFunc<Dummy1, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Dummy1, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Dummy1, string>>((PrintfFormat<FSharpFunc<Dummy1, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Dummy1, string>, Unit, string, string, Dummy1>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(Dummy1 obj)
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
				return CompareTo((Dummy1)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				Dummy1 dummy = (Dummy1)obj;
				if (this != null)
				{
					if ((Dummy1)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((Dummy1)obj != null)
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
					Dummy1 dummy = obj as Dummy1;
					if (dummy != null)
					{
						Dummy1 dummy2 = dummy;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			[CompilerGenerated]
			public sealed override bool Equals(Dummy1 obj)
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
				Dummy1 dummy = obj as Dummy1;
				if (dummy != null)
				{
					return Equals(dummy);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class Dummy2 : IEquatable<Dummy2>, IStructuralEquatable, IComparable<Dummy2>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly Dummy2 _unique_Dummy2 = new Dummy2();

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
			public static Dummy2 Dummy2
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Dummy2;
				}
			}

			public static Dummy2 Instance => Dummy2;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Dummy2()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Dummy2, string>>((PrintfFormat<FSharpFunc<Dummy2, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Dummy2, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Dummy2, string>>((PrintfFormat<FSharpFunc<Dummy2, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Dummy2, string>, Unit, string, string, Dummy2>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(Dummy2 obj)
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
				return CompareTo((Dummy2)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				Dummy2 dummy = (Dummy2)obj;
				if (this != null)
				{
					if ((Dummy2)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((Dummy2)obj != null)
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
					Dummy2 dummy = obj as Dummy2;
					if (dummy != null)
					{
						Dummy2 dummy2 = dummy;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			[CompilerGenerated]
			public sealed override bool Equals(Dummy2 obj)
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
				Dummy2 dummy = obj as Dummy2;
				if (dummy != null)
				{
					return Equals(dummy);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ExpOp : IEquatable<ExpOp>, IStructuralEquatable, IComparable<ExpOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ExpOp _unique_ExpOp = new ExpOp();

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
			public static ExpOp ExpOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_ExpOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ExpOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ExpOp, string>>((PrintfFormat<FSharpFunc<ExpOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ExpOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ExpOp, string>>((PrintfFormat<FSharpFunc<ExpOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ExpOp, string>, Unit, string, string, ExpOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ExpOp obj)
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
				return CompareTo((ExpOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ExpOp expOp = (ExpOp)obj;
				if (this != null)
				{
					if ((ExpOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((ExpOp)obj != null)
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
					ExpOp expOp = obj as ExpOp;
					if (expOp != null)
					{
						ExpOp expOp2 = expOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Exp<T>(ExpOp ExpOp, T x)
			{
				return OperatorIntrinsics.ExpDynamic<T>(x);
			}

			public static Y Exp<T, Y>(ExpOp ExpOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyExp is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(ExpOp obj)
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
				ExpOp expOp = obj as ExpOp;
				if (expOp != null)
				{
					return Equals(expOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class LogOp : IEquatable<LogOp>, IStructuralEquatable, IComparable<LogOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly LogOp _unique_LogOp = new LogOp();

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
			public static LogOp LogOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_LogOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal LogOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<LogOp, string>>((PrintfFormat<FSharpFunc<LogOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<LogOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<LogOp, string>>((PrintfFormat<FSharpFunc<LogOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<LogOp, string>, Unit, string, string, LogOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(LogOp obj)
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
				return CompareTo((LogOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				LogOp logOp = (LogOp)obj;
				if (this != null)
				{
					if ((LogOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((LogOp)obj != null)
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
					LogOp logOp = obj as LogOp;
					if (logOp != null)
					{
						LogOp logOp2 = logOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Log<T>(LogOp LogOp, T x)
			{
				return OperatorIntrinsics.LogDynamic<T>(x);
			}

			public static Y Log<T, Y>(LogOp LogOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyLog is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(LogOp obj)
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
				LogOp logOp = obj as LogOp;
				if (logOp != null)
				{
					return Equals(logOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class AbsOp : IEquatable<AbsOp>, IStructuralEquatable, IComparable<AbsOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly AbsOp _unique_AbsOp = new AbsOp();

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
			public static AbsOp AbsOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_AbsOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal AbsOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AbsOp, string>>((PrintfFormat<FSharpFunc<AbsOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AbsOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AbsOp, string>>((PrintfFormat<FSharpFunc<AbsOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AbsOp, string>, Unit, string, string, AbsOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(AbsOp obj)
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
				return CompareTo((AbsOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				AbsOp absOp = (AbsOp)obj;
				if (this != null)
				{
					if ((AbsOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((AbsOp)obj != null)
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
					AbsOp absOp = obj as AbsOp;
					if (absOp != null)
					{
						AbsOp absOp2 = absOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Abs<T>(AbsOp AbsOp, T x)
			{
				return OperatorIntrinsics.AbsDynamic<T>(x);
			}

			public static Y Abs<T, Y>(AbsOp AbsOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyAbs is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(AbsOp obj)
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
				AbsOp absOp = obj as AbsOp;
				if (absOp != null)
				{
					return Equals(absOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class AcosOp : IEquatable<AcosOp>, IStructuralEquatable, IComparable<AcosOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly AcosOp _unique_AcosOp = new AcosOp();

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
			public static AcosOp AcosOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_AcosOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal AcosOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AcosOp, string>>((PrintfFormat<FSharpFunc<AcosOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AcosOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AcosOp, string>>((PrintfFormat<FSharpFunc<AcosOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AcosOp, string>, Unit, string, string, AcosOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(AcosOp obj)
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
				return CompareTo((AcosOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				AcosOp acosOp = (AcosOp)obj;
				if (this != null)
				{
					if ((AcosOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((AcosOp)obj != null)
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
					AcosOp acosOp = obj as AcosOp;
					if (acosOp != null)
					{
						AcosOp acosOp2 = acosOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Acos<T>(AcosOp AcosOp, T x)
			{
				return OperatorIntrinsics.AcosDynamic<T>(x);
			}

			public static Y Acos<T, Y>(AcosOp AcosOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyAcos is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(AcosOp obj)
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
				AcosOp acosOp = obj as AcosOp;
				if (acosOp != null)
				{
					return Equals(acosOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class AsinOp : IEquatable<AsinOp>, IStructuralEquatable, IComparable<AsinOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly AsinOp _unique_AsinOp = new AsinOp();

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
			public static AsinOp AsinOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_AsinOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal AsinOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AsinOp, string>>((PrintfFormat<FSharpFunc<AsinOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AsinOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AsinOp, string>>((PrintfFormat<FSharpFunc<AsinOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AsinOp, string>, Unit, string, string, AsinOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(AsinOp obj)
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
				return CompareTo((AsinOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				AsinOp asinOp = (AsinOp)obj;
				if (this != null)
				{
					if ((AsinOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((AsinOp)obj != null)
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
					AsinOp asinOp = obj as AsinOp;
					if (asinOp != null)
					{
						AsinOp asinOp2 = asinOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Asin<T>(AsinOp AsinOp, T x)
			{
				return OperatorIntrinsics.AsinDynamic<T>(x);
			}

			public static Y Asin<T, Y>(AsinOp AsinOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyAsin is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(AsinOp obj)
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
				AsinOp asinOp = obj as AsinOp;
				if (asinOp != null)
				{
					return Equals(asinOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class AtanOp : IEquatable<AtanOp>, IStructuralEquatable, IComparable<AtanOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly AtanOp _unique_AtanOp = new AtanOp();

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
			public static AtanOp AtanOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_AtanOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal AtanOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AtanOp, string>>((PrintfFormat<FSharpFunc<AtanOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AtanOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AtanOp, string>>((PrintfFormat<FSharpFunc<AtanOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AtanOp, string>, Unit, string, string, AtanOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(AtanOp obj)
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
				return CompareTo((AtanOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				AtanOp atanOp = (AtanOp)obj;
				if (this != null)
				{
					if ((AtanOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((AtanOp)obj != null)
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
					AtanOp atanOp = obj as AtanOp;
					if (atanOp != null)
					{
						AtanOp atanOp2 = atanOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Atan<T>(AtanOp AtanOp, T x)
			{
				return OperatorIntrinsics.AtanDynamic<T>(x);
			}

			public static Y Atan<T, Y>(AtanOp AtanOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyAtan is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(AtanOp obj)
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
				AtanOp atanOp = obj as AtanOp;
				if (atanOp != null)
				{
					return Equals(atanOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class AtanOp2 : IEquatable<AtanOp2>, IStructuralEquatable, IComparable<AtanOp2>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly AtanOp2 _unique_AtanOp2 = new AtanOp2();

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
			public static AtanOp2 AtanOp2
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_AtanOp2;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal AtanOp2()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AtanOp2, string>>((PrintfFormat<FSharpFunc<AtanOp2, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AtanOp2, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<AtanOp2, string>>((PrintfFormat<FSharpFunc<AtanOp2, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<AtanOp2, string>, Unit, string, string, AtanOp2>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(AtanOp2 obj)
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
				return CompareTo((AtanOp2)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				AtanOp2 atanOp = (AtanOp2)obj;
				if (this != null)
				{
					if ((AtanOp2)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((AtanOp2)obj != null)
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
					AtanOp2 atanOp = obj as AtanOp2;
					if (atanOp != null)
					{
						AtanOp2 atanOp2 = atanOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Atan2<T>(AtanOp2 AtanOp2, T x, T y)
			{
				return OperatorIntrinsics.Atan2Dynamic<T, T>(x, y);
			}

			public static Y Atan2<T, T2, Y>(AtanOp2 AtanOp2, T x, T2 y)
			{
				throw new NotSupportedException("Dynamic invocation of ArcTan2 is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(AtanOp2 obj)
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
				AtanOp2 atanOp = obj as AtanOp2;
				if (atanOp != null)
				{
					return Equals(atanOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class CeilingOp : IEquatable<CeilingOp>, IStructuralEquatable, IComparable<CeilingOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly CeilingOp _unique_CeilingOp = new CeilingOp();

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
			public static CeilingOp CeilingOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_CeilingOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal CeilingOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<CeilingOp, string>>((PrintfFormat<FSharpFunc<CeilingOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<CeilingOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<CeilingOp, string>>((PrintfFormat<FSharpFunc<CeilingOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<CeilingOp, string>, Unit, string, string, CeilingOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(CeilingOp obj)
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
				return CompareTo((CeilingOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				CeilingOp ceilingOp = (CeilingOp)obj;
				if (this != null)
				{
					if ((CeilingOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((CeilingOp)obj != null)
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
					CeilingOp ceilingOp = obj as CeilingOp;
					if (ceilingOp != null)
					{
						CeilingOp ceilingOp2 = ceilingOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Ceiling<T>(CeilingOp CeilingOp, T x)
			{
				return OperatorIntrinsics.CeilingDynamic<T>(x);
			}

			public static Y Ceiling<T, Y>(CeilingOp CeilingOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyCeiling is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(CeilingOp obj)
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
				CeilingOp ceilingOp = obj as CeilingOp;
				if (ceilingOp != null)
				{
					return Equals(ceilingOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class FloorOp : IEquatable<FloorOp>, IStructuralEquatable, IComparable<FloorOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly FloorOp _unique_FloorOp = new FloorOp();

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
			public static FloorOp FloorOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_FloorOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal FloorOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<FloorOp, string>>((PrintfFormat<FSharpFunc<FloorOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<FloorOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<FloorOp, string>>((PrintfFormat<FSharpFunc<FloorOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<FloorOp, string>, Unit, string, string, FloorOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(FloorOp obj)
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
				return CompareTo((FloorOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				FloorOp floorOp = (FloorOp)obj;
				if (this != null)
				{
					if ((FloorOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((FloorOp)obj != null)
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
					FloorOp floorOp = obj as FloorOp;
					if (floorOp != null)
					{
						FloorOp floorOp2 = floorOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Floor<T>(FloorOp FloorOp, T x)
			{
				return OperatorIntrinsics.FloorDynamic<T>(x);
			}

			public static Y Floor<T, Y>(FloorOp FloorOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyFloor is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(FloorOp obj)
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
				FloorOp floorOp = obj as FloorOp;
				if (floorOp != null)
				{
					return Equals(floorOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class TruncateOp : IEquatable<TruncateOp>, IStructuralEquatable, IComparable<TruncateOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly TruncateOp _unique_TruncateOp = new TruncateOp();

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
			public static TruncateOp TruncateOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_TruncateOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal TruncateOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TruncateOp, string>>((PrintfFormat<FSharpFunc<TruncateOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TruncateOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TruncateOp, string>>((PrintfFormat<FSharpFunc<TruncateOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TruncateOp, string>, Unit, string, string, TruncateOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(TruncateOp obj)
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
				return CompareTo((TruncateOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				TruncateOp truncateOp = (TruncateOp)obj;
				if (this != null)
				{
					if ((TruncateOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((TruncateOp)obj != null)
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
					TruncateOp truncateOp = obj as TruncateOp;
					if (truncateOp != null)
					{
						TruncateOp truncateOp2 = truncateOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Truncate<T>(TruncateOp TruncateOp, T x)
			{
				return OperatorIntrinsics.TruncateDynamic<T>(x);
			}

			public static Y Truncate<T, Y>(TruncateOp TruncateOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyTruncate is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(TruncateOp obj)
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
				TruncateOp truncateOp = obj as TruncateOp;
				if (truncateOp != null)
				{
					return Equals(truncateOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class RoundOp : IEquatable<RoundOp>, IStructuralEquatable, IComparable<RoundOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RoundOp _unique_RoundOp = new RoundOp();

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
			public static RoundOp RoundOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_RoundOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal RoundOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<RoundOp, string>>((PrintfFormat<FSharpFunc<RoundOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<RoundOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<RoundOp, string>>((PrintfFormat<FSharpFunc<RoundOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<RoundOp, string>, Unit, string, string, RoundOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(RoundOp obj)
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
				return CompareTo((RoundOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				RoundOp roundOp = (RoundOp)obj;
				if (this != null)
				{
					if ((RoundOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((RoundOp)obj != null)
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
					RoundOp roundOp = obj as RoundOp;
					if (roundOp != null)
					{
						RoundOp roundOp2 = roundOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Round<T>(RoundOp RoundOp, T x)
			{
				return OperatorIntrinsics.RoundDynamic<T>(x);
			}

			public static Y Round<T, Y>(RoundOp RoundOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyRound is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(RoundOp obj)
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
				RoundOp roundOp = obj as RoundOp;
				if (roundOp != null)
				{
					return Equals(roundOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class Log10Op : IEquatable<Log10Op>, IStructuralEquatable, IComparable<Log10Op>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly Log10Op _unique_Log10Op = new Log10Op();

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
			public static Log10Op Log10Op
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Log10Op;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Log10Op()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Log10Op, string>>((PrintfFormat<FSharpFunc<Log10Op, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Log10Op, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Log10Op, string>>((PrintfFormat<FSharpFunc<Log10Op, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Log10Op, string>, Unit, string, string, Log10Op>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(Log10Op obj)
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
				return CompareTo((Log10Op)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				Log10Op log10Op = (Log10Op)obj;
				if (this != null)
				{
					if ((Log10Op)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((Log10Op)obj != null)
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
					Log10Op log10Op = obj as Log10Op;
					if (log10Op != null)
					{
						Log10Op log10Op2 = log10Op;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Log10<T>(Log10Op Log10Op, T x)
			{
				return OperatorIntrinsics.Log10Dynamic<T>(x);
			}

			public static Y Log10<T, Y>(Log10Op Log10Op, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyLog10 is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(Log10Op obj)
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
				Log10Op log10Op = obj as Log10Op;
				if (log10Op != null)
				{
					return Equals(log10Op);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class SqrtOp : IEquatable<SqrtOp>, IStructuralEquatable, IComparable<SqrtOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SqrtOp _unique_SqrtOp = new SqrtOp();

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
			public static SqrtOp SqrtOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_SqrtOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal SqrtOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SqrtOp, string>>((PrintfFormat<FSharpFunc<SqrtOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SqrtOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SqrtOp, string>>((PrintfFormat<FSharpFunc<SqrtOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SqrtOp, string>, Unit, string, string, SqrtOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(SqrtOp obj)
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
				return CompareTo((SqrtOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				SqrtOp sqrtOp = (SqrtOp)obj;
				if (this != null)
				{
					if ((SqrtOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((SqrtOp)obj != null)
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
					SqrtOp sqrtOp = obj as SqrtOp;
					if (sqrtOp != null)
					{
						SqrtOp sqrtOp2 = sqrtOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Sqrt<T>(SqrtOp SqrtOp, T x)
			{
				return OperatorIntrinsics.SqrtDynamic<T, T>(x);
			}

			public static Y Sqrt<T, Y>(SqrtOp SqrtOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplySqrt is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(SqrtOp obj)
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
				SqrtOp sqrtOp = obj as SqrtOp;
				if (sqrtOp != null)
				{
					return Equals(sqrtOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class CosOp : IEquatable<CosOp>, IStructuralEquatable, IComparable<CosOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly CosOp _unique_CosOp = new CosOp();

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
			public static CosOp CosOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_CosOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal CosOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<CosOp, string>>((PrintfFormat<FSharpFunc<CosOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<CosOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<CosOp, string>>((PrintfFormat<FSharpFunc<CosOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<CosOp, string>, Unit, string, string, CosOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(CosOp obj)
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
				return CompareTo((CosOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				CosOp cosOp = (CosOp)obj;
				if (this != null)
				{
					if ((CosOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((CosOp)obj != null)
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
					CosOp cosOp = obj as CosOp;
					if (cosOp != null)
					{
						CosOp cosOp2 = cosOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Cos<T>(CosOp CosOp, T x)
			{
				return OperatorIntrinsics.CosDynamic<T>(x);
			}

			public static Y Cos<T, Y>(CosOp CosOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyCos is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(CosOp obj)
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
				CosOp cosOp = obj as CosOp;
				if (cosOp != null)
				{
					return Equals(cosOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class CoshOp : IEquatable<CoshOp>, IStructuralEquatable, IComparable<CoshOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly CoshOp _unique_CoshOp = new CoshOp();

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
			public static CoshOp CoshOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_CoshOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal CoshOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<CoshOp, string>>((PrintfFormat<FSharpFunc<CoshOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<CoshOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<CoshOp, string>>((PrintfFormat<FSharpFunc<CoshOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<CoshOp, string>, Unit, string, string, CoshOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(CoshOp obj)
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
				return CompareTo((CoshOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				CoshOp coshOp = (CoshOp)obj;
				if (this != null)
				{
					if ((CoshOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((CoshOp)obj != null)
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
					CoshOp coshOp = obj as CoshOp;
					if (coshOp != null)
					{
						CoshOp coshOp2 = coshOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Cosh<T>(CoshOp CoshOp, T x)
			{
				return OperatorIntrinsics.CoshDynamic<T>(x);
			}

			public static Y Cosh<T, Y>(CoshOp CoshOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyCosh is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(CoshOp obj)
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
				CoshOp coshOp = obj as CoshOp;
				if (coshOp != null)
				{
					return Equals(coshOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class SinOp : IEquatable<SinOp>, IStructuralEquatable, IComparable<SinOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SinOp _unique_SinOp = new SinOp();

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
			public static SinOp SinOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_SinOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal SinOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SinOp, string>>((PrintfFormat<FSharpFunc<SinOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SinOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SinOp, string>>((PrintfFormat<FSharpFunc<SinOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SinOp, string>, Unit, string, string, SinOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(SinOp obj)
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
				return CompareTo((SinOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				SinOp sinOp = (SinOp)obj;
				if (this != null)
				{
					if ((SinOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((SinOp)obj != null)
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
					SinOp sinOp = obj as SinOp;
					if (sinOp != null)
					{
						SinOp sinOp2 = sinOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Sin<T>(SinOp SinOp, T x)
			{
				return OperatorIntrinsics.SinDynamic<T>(x);
			}

			public static Y Sin<T, Y>(SinOp SinOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplySin is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(SinOp obj)
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
				SinOp sinOp = obj as SinOp;
				if (sinOp != null)
				{
					return Equals(sinOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class SinhOp : IEquatable<SinhOp>, IStructuralEquatable, IComparable<SinhOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SinhOp _unique_SinhOp = new SinhOp();

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
			public static SinhOp SinhOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_SinhOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal SinhOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SinhOp, string>>((PrintfFormat<FSharpFunc<SinhOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SinhOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SinhOp, string>>((PrintfFormat<FSharpFunc<SinhOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SinhOp, string>, Unit, string, string, SinhOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(SinhOp obj)
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
				return CompareTo((SinhOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				SinhOp sinhOp = (SinhOp)obj;
				if (this != null)
				{
					if ((SinhOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((SinhOp)obj != null)
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
					SinhOp sinhOp = obj as SinhOp;
					if (sinhOp != null)
					{
						SinhOp sinhOp2 = sinhOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Sinh<T>(SinhOp SinhOp, T x)
			{
				return OperatorIntrinsics.SinhDynamic<T>(x);
			}

			public static Y Sinh<T, Y>(SinhOp SinhOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplySinh is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(SinhOp obj)
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
				SinhOp sinhOp = obj as SinhOp;
				if (sinhOp != null)
				{
					return Equals(sinhOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class TanOp : IEquatable<TanOp>, IStructuralEquatable, IComparable<TanOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly TanOp _unique_TanOp = new TanOp();

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
			public static TanOp TanOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_TanOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal TanOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TanOp, string>>((PrintfFormat<FSharpFunc<TanOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TanOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TanOp, string>>((PrintfFormat<FSharpFunc<TanOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TanOp, string>, Unit, string, string, TanOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(TanOp obj)
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
				return CompareTo((TanOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				TanOp tanOp = (TanOp)obj;
				if (this != null)
				{
					if ((TanOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((TanOp)obj != null)
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
					TanOp tanOp = obj as TanOp;
					if (tanOp != null)
					{
						TanOp tanOp2 = tanOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Tan<T>(TanOp TanOp, T x)
			{
				return OperatorIntrinsics.TanDynamic<T>(x);
			}

			public static Y Tan<T, Y>(TanOp TanOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyTan is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(TanOp obj)
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
				TanOp tanOp = obj as TanOp;
				if (tanOp != null)
				{
					return Equals(tanOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class TanhOp : IEquatable<TanhOp>, IStructuralEquatable, IComparable<TanhOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly TanhOp _unique_TanhOp = new TanhOp();

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
			public static TanhOp TanhOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_TanhOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal TanhOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TanhOp, string>>((PrintfFormat<FSharpFunc<TanhOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TanhOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TanhOp, string>>((PrintfFormat<FSharpFunc<TanhOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TanhOp, string>, Unit, string, string, TanhOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(TanhOp obj)
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
				return CompareTo((TanhOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				TanhOp tanhOp = (TanhOp)obj;
				if (this != null)
				{
					if ((TanhOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((TanhOp)obj != null)
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
					TanhOp tanhOp = obj as TanhOp;
					if (tanhOp != null)
					{
						TanhOp tanhOp2 = tanhOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Tanh<T>(TanhOp TanhOp, T x)
			{
				return OperatorIntrinsics.TanhDynamic<T>(x);
			}

			public static Y Tanh<T, Y>(TanhOp TanhOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyTanh is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(TanhOp obj)
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
				TanhOp tanhOp = obj as TanhOp;
				if (tanhOp != null)
				{
					return Equals(tanhOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class NegateOp : IEquatable<NegateOp>, IStructuralEquatable, IComparable<NegateOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly NegateOp _unique_NegateOp = new NegateOp();

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
			public static NegateOp NegateOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NegateOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal NegateOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<NegateOp, string>>((PrintfFormat<FSharpFunc<NegateOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<NegateOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<NegateOp, string>>((PrintfFormat<FSharpFunc<NegateOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<NegateOp, string>, Unit, string, string, NegateOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(NegateOp obj)
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
				return CompareTo((NegateOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				NegateOp negateOp = (NegateOp)obj;
				if (this != null)
				{
					if ((NegateOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((NegateOp)obj != null)
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
					NegateOp negateOp = obj as NegateOp;
					if (negateOp != null)
					{
						NegateOp negateOp2 = negateOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static T Negate<T>(NegateOp NegateOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of op_UnaryNegation is not supported");
			}

			public static Y Negate<T, Y>(NegateOp NegateOp, T x)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyNegate is not supported");
			}

			[CompilerGenerated]
			public sealed override bool Equals(NegateOp obj)
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
				NegateOp negateOp = obj as NegateOp;
				if (negateOp != null)
				{
					return Equals(negateOp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class PowerOp : IEquatable<PowerOp>, IStructuralEquatable, IComparable<PowerOp>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PowerOp _unique_PowerOp = new PowerOp();

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
			public static PowerOp PowerOp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_PowerOp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal PowerOp()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<PowerOp, string>>((PrintfFormat<FSharpFunc<PowerOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<PowerOp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public override string ToString()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<PowerOp, string>>((PrintfFormat<FSharpFunc<PowerOp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<PowerOp, string>, Unit, string, string, PowerOp>("%+A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(PowerOp obj)
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
				return CompareTo((PowerOp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				PowerOp powerOp = (PowerOp)obj;
				if (this != null)
				{
					if ((PowerOp)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((PowerOp)obj != null)
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
					PowerOp powerOp = obj as PowerOp;
					if (powerOp != null)
					{
						PowerOp powerOp2 = powerOp;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public static FSharpFunc<b, a> op_DynamicAssignment<a, b>(PowerOp PowerOp, Dummy1 Dummy1, a a)
			{
				return new op_DynamicAssignment_0040118<a, b>(a);
			}

			public static FSharpFunc<y, s> op_DynamicAssignment<t, y, s>(PowerOp PowerOp, Dummy2 Dummy2, t a)
			{
				return new op_DynamicAssignment_0040119_002D1<t, y, s>(a);
			}

			[CompilerGenerated]
			public sealed override bool Equals(PowerOp obj)
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
				PowerOp powerOp = obj as PowerOp;
				if (powerOp != null)
				{
					return Equals(powerOp);
				}
				return false;
			}
		}

		[Serializable]
		internal sealed class op_DynamicAssignment_0040118<a, b> : FSharpFunc<b, a>
		{
			public a a;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal op_DynamicAssignment_0040118(a a)
			{
				this.a = a;
			}

			public override a Invoke(b b)
			{
				a val = this.a;
				return OperatorIntrinsics.PowDynamic<a, b>(val, b);
			}
		}

		[Serializable]
		internal sealed class op_DynamicAssignment_0040119_002D1<t, y, s> : FSharpFunc<y, s>
		{
			public t a;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal op_DynamicAssignment_0040119_002D1(t a)
			{
				this.a = a;
			}

			public override s Invoke(y b)
			{
				throw new NotSupportedException("Dynamic invocation of ApplyPow is not supported");
			}
		}

		[Serializable]
		internal sealed class powerHelper_0040120<a, c, d, e, b> : FSharpFunc<a, b, c, FSharpFunc<d, e>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal powerHelper_0040120()
			{
			}

			public override FSharpFunc<d, e> Invoke(a arg0, b arg1, c arg2)
			{
				throw new NotSupportedException("Dynamic invocation of op_DynamicAssignment is not supported");
			}
		}

		public static a chooseType<a>()
		{
			throw new NotSupportedException("Dynamic invocation of get_Instance is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y expHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Exp is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y logHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Log is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y absHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Abs is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y acosHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Acos is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y asinHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Asin is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y atanHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Atan is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		internal static y atan2Helper<op, t, t2, y>(op t, t x, t2 y)
		{
			throw new NotSupportedException("Dynamic invocation of Atan2 is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y ceilingHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Ceiling is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y floorHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Floor is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y truncateHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Truncate is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y roundHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Round is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y log10Helper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Log10 is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y sqrtHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Sqrt is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y cosHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Cos is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y coshHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Cosh is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y sinHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Sin is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y sinhHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Sinh is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y tanHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Tan is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y tanhHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Tanh is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static y negateHelper<op, t, y>(op t, t x)
		{
			throw new NotSupportedException("Dynamic invocation of Negate is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static e powerHelper<a, b, c, d, e>(a t, c a, d b)
		{
			powerHelper_0040120<a, c, d, e, b> powerHelper_0040 = new powerHelper_0040120<a, c, d, e, b>();
			if (0 == 0)
			{
				throw new NotSupportedException("Dynamic invocation of get_Instance is not supported");
			}
			return FSharpFunc<c, d>.InvokeFast<c, d, e>((FSharpFunc<c, FSharpFunc<d, FSharpFunc<c, FSharpFunc<d, e>>>>)(object)powerHelper_0040, (c)t, (d)(b)(object)null, a, b);
		}
	}
}
