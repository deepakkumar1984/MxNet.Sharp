using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[AutoOpen]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class GeneratedArgumentTypes
	{
		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribBilinearResize2DMode : IEquatable<ContribBilinearResize2DMode>, IStructuralEquatable, IComparable<ContribBilinearResize2DMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Like = 0;

				public const int OddScale = 1;

				public const int Size = 2;

				public const int ToEvenDown = 3;

				public const int ToEvenUp = 4;

				public const int ToOddDown = 5;

				public const int ToOddUp = 6;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribBilinearResize2DMode _unique_Like = new ContribBilinearResize2DMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribBilinearResize2DMode _unique_OddScale = new ContribBilinearResize2DMode(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribBilinearResize2DMode _unique_Size = new ContribBilinearResize2DMode(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribBilinearResize2DMode _unique_ToEvenDown = new ContribBilinearResize2DMode(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribBilinearResize2DMode _unique_ToEvenUp = new ContribBilinearResize2DMode(4);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribBilinearResize2DMode _unique_ToOddDown = new ContribBilinearResize2DMode(5);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribBilinearResize2DMode _unique_ToOddUp = new ContribBilinearResize2DMode(6);

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
			public static ContribBilinearResize2DMode Like
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Like;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsLike
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
			public static ContribBilinearResize2DMode OddScale
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_OddScale;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsOddScale
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
			public static ContribBilinearResize2DMode Size
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Size;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSize
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
			public static ContribBilinearResize2DMode ToEvenDown
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_ToEvenDown;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsToEvenDown
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static ContribBilinearResize2DMode ToEvenUp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_ToEvenUp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsToEvenUp
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static ContribBilinearResize2DMode ToOddDown
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_ToOddDown;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsToOddDown
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 5;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static ContribBilinearResize2DMode ToOddUp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_ToOddUp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsToOddUp
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 6;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ContribBilinearResize2DMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribBilinearResize2DMode, string>>((PrintfFormat<FSharpFunc<ContribBilinearResize2DMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribBilinearResize2DMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribBilinearResize2DMode obj)
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
				return CompareTo((ContribBilinearResize2DMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribBilinearResize2DMode contribBilinearResize2DMode = (ContribBilinearResize2DMode)obj;
				if (this != null)
				{
					if ((ContribBilinearResize2DMode)obj != null)
					{
						int tag = _tag;
						int tag2 = contribBilinearResize2DMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ContribBilinearResize2DMode)obj != null)
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
					ContribBilinearResize2DMode contribBilinearResize2DMode = obj as ContribBilinearResize2DMode;
					if (contribBilinearResize2DMode != null)
					{
						ContribBilinearResize2DMode contribBilinearResize2DMode2 = contribBilinearResize2DMode;
						int tag = _tag;
						int tag2 = contribBilinearResize2DMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "like";
				case 1:
					return "odd_scale";
				case 2:
					return "size";
				case 3:
					return "to_even_down";
				case 4:
					return "to_even_up";
				case 5:
					return "to_odd_down";
				case 6:
					return "to_odd_up";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribBilinearResize2DMode obj)
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
				ContribBilinearResize2DMode contribBilinearResize2DMode = obj as ContribBilinearResize2DMode;
				if (contribBilinearResize2DMode != null)
				{
					return Equals(contribBilinearResize2DMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class Format : IEquatable<Format>, IStructuralEquatable, IComparable<Format>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Center = 0;

				public const int Corner = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly Format _unique_Center = new Format(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly Format _unique_Corner = new Format(1);

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
			public static Format Center
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Center;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsCenter
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
			public static Format Corner
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Corner;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsCorner
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
			internal Format(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Format, string>>((PrintfFormat<FSharpFunc<Format, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Format, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(Format obj)
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
				return CompareTo((Format)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				Format format = (Format)obj;
				if (this != null)
				{
					if ((Format)obj != null)
					{
						int tag = _tag;
						int tag2 = format._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((Format)obj != null)
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
					Format format = obj as Format;
					if (format != null)
					{
						Format format2 = format;
						int tag = _tag;
						int tag2 = format2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "center";
				}
				return "corner";
			}

			[CompilerGenerated]
			public sealed override bool Equals(Format obj)
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
				Format format = obj as Format;
				if (format != null)
				{
					return Equals(format);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class LeakyReLUType : IEquatable<LeakyReLUType>, IStructuralEquatable, IComparable<LeakyReLUType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Elu = 0;

				public const int Gelu = 1;

				public const int Leaky = 2;

				public const int Prelu = 3;

				public const int Rrelu = 4;

				public const int Selu = 5;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly LeakyReLUType _unique_Elu = new LeakyReLUType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly LeakyReLUType _unique_Gelu = new LeakyReLUType(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly LeakyReLUType _unique_Leaky = new LeakyReLUType(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly LeakyReLUType _unique_Prelu = new LeakyReLUType(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly LeakyReLUType _unique_Rrelu = new LeakyReLUType(4);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly LeakyReLUType _unique_Selu = new LeakyReLUType(5);

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
			public static LeakyReLUType Elu
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Elu;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsElu
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
			public static LeakyReLUType Gelu
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Gelu;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsGelu
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
			public static LeakyReLUType Leaky
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Leaky;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsLeaky
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
			public static LeakyReLUType Prelu
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Prelu;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsPrelu
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static LeakyReLUType Rrelu
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Rrelu;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsRrelu
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static LeakyReLUType Selu
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Selu;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSelu
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 5;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal LeakyReLUType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<LeakyReLUType, string>>((PrintfFormat<FSharpFunc<LeakyReLUType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<LeakyReLUType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(LeakyReLUType obj)
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
				return CompareTo((LeakyReLUType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				LeakyReLUType leakyReLUType = (LeakyReLUType)obj;
				if (this != null)
				{
					if ((LeakyReLUType)obj != null)
					{
						int tag = _tag;
						int tag2 = leakyReLUType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((LeakyReLUType)obj != null)
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
					LeakyReLUType leakyReLUType = obj as LeakyReLUType;
					if (leakyReLUType != null)
					{
						LeakyReLUType leakyReLUType2 = leakyReLUType;
						int tag = _tag;
						int tag2 = leakyReLUType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "elu";
				case 1:
					return "gelu";
				case 2:
					return "leaky";
				case 3:
					return "prelu";
				case 4:
					return "rrelu";
				case 5:
					return "selu";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(LeakyReLUType obj)
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
				LeakyReLUType leakyReLUType = obj as LeakyReLUType;
				if (leakyReLUType != null)
				{
					return Equals(leakyReLUType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ActType : IEquatable<ActType>, IStructuralEquatable, IComparable<ActType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Relu = 0;

				public const int Sigmoid = 1;

				public const int Softrelu = 2;

				public const int Softsign = 3;

				public const int Tanh = 4;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ActType _unique_Relu = new ActType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ActType _unique_Sigmoid = new ActType(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ActType _unique_Softrelu = new ActType(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ActType _unique_Softsign = new ActType(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ActType _unique_Tanh = new ActType(4);

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
			public static ActType Relu
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Relu;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsRelu
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
			public static ActType Sigmoid
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Sigmoid;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSigmoid
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
			public static ActType Softrelu
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Softrelu;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSoftrelu
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
			public static ActType Softsign
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Softsign;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSoftsign
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static ActType Tanh
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Tanh;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsTanh
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ActType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ActType, string>>((PrintfFormat<FSharpFunc<ActType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ActType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ActType obj)
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
				return CompareTo((ActType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ActType actType = (ActType)obj;
				if (this != null)
				{
					if ((ActType)obj != null)
					{
						int tag = _tag;
						int tag2 = actType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ActType)obj != null)
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
					ActType actType = obj as ActType;
					if (actType != null)
					{
						ActType actType2 = actType;
						int tag = _tag;
						int tag2 = actType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "relu";
				case 1:
					return "sigmoid";
				case 2:
					return "softrelu";
				case 3:
					return "softsign";
				case 4:
					return "tanh";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ActType obj)
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
				ActType actType = obj as ActType;
				if (actType != null)
				{
					return Equals(actType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class CudnnTune : IEquatable<CudnnTune>, IStructuralEquatable, IComparable<CudnnTune>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Fastest = 0;

				public const int LimitedWorkspace = 1;

				public const int Off = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly CudnnTune _unique_Fastest = new CudnnTune(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly CudnnTune _unique_LimitedWorkspace = new CudnnTune(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly CudnnTune _unique_Off = new CudnnTune(2);

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
			public static CudnnTune Fastest
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Fastest;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFastest
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
			public static CudnnTune LimitedWorkspace
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_LimitedWorkspace;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsLimitedWorkspace
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
			public static CudnnTune Off
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Off;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsOff
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
			internal CudnnTune(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<CudnnTune, string>>((PrintfFormat<FSharpFunc<CudnnTune, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<CudnnTune, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(CudnnTune obj)
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
				return CompareTo((CudnnTune)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				CudnnTune cudnnTune = (CudnnTune)obj;
				if (this != null)
				{
					if ((CudnnTune)obj != null)
					{
						int tag = _tag;
						int tag2 = cudnnTune._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((CudnnTune)obj != null)
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
					CudnnTune cudnnTune = obj as CudnnTune;
					if (cudnnTune != null)
					{
						CudnnTune cudnnTune2 = cudnnTune;
						int tag = _tag;
						int tag2 = cudnnTune2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "fastest";
				case 1:
					return "limited_workspace";
				case 2:
					return "off";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(CudnnTune obj)
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
				CudnnTune cudnnTune = obj as CudnnTune;
				if (cudnnTune != null)
				{
					return Equals(cudnnTune);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ConvolutionLayout : IEquatable<ConvolutionLayout>, IStructuralEquatable, IComparable<ConvolutionLayout>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int NCDHW = 0;

				public const int NCHW = 1;

				public const int NCW = 2;

				public const int NDHWC = 3;

				public const int NHWC = 4;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionLayout _unique_NCDHW = new ConvolutionLayout(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionLayout _unique_NCHW = new ConvolutionLayout(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionLayout _unique_NCW = new ConvolutionLayout(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionLayout _unique_NDHWC = new ConvolutionLayout(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionLayout _unique_NHWC = new ConvolutionLayout(4);

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
			public static ConvolutionLayout NCDHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCDHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCDHW
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
			public static ConvolutionLayout NCHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCHW
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
			public static ConvolutionLayout NCW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCW
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
			public static ConvolutionLayout NDHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NDHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNDHWC
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static ConvolutionLayout NHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNHWC
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ConvolutionLayout(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ConvolutionLayout, string>>((PrintfFormat<FSharpFunc<ConvolutionLayout, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ConvolutionLayout, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ConvolutionLayout obj)
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
				return CompareTo((ConvolutionLayout)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ConvolutionLayout convolutionLayout = (ConvolutionLayout)obj;
				if (this != null)
				{
					if ((ConvolutionLayout)obj != null)
					{
						int tag = _tag;
						int tag2 = convolutionLayout._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ConvolutionLayout)obj != null)
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
					ConvolutionLayout convolutionLayout = obj as ConvolutionLayout;
					if (convolutionLayout != null)
					{
						ConvolutionLayout convolutionLayout2 = convolutionLayout;
						int tag = _tag;
						int tag2 = convolutionLayout2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "NCDHW";
				case 1:
					return "NCHW";
				case 2:
					return "NCW";
				case 3:
					return "NDHWC";
				case 4:
					return "NHWC";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ConvolutionLayout obj)
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
				ConvolutionLayout convolutionLayout = obj as ConvolutionLayout;
				if (convolutionLayout != null)
				{
					return Equals(convolutionLayout);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class BlankLabel : IEquatable<BlankLabel>, IStructuralEquatable, IComparable<BlankLabel>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int First = 0;

				public const int Last = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly BlankLabel _unique_First = new BlankLabel(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly BlankLabel _unique_Last = new BlankLabel(1);

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
			public static BlankLabel First
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_First;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFirst
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
			public static BlankLabel Last
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Last;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsLast
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
			internal BlankLabel(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<BlankLabel, string>>((PrintfFormat<FSharpFunc<BlankLabel, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<BlankLabel, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(BlankLabel obj)
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
				return CompareTo((BlankLabel)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				BlankLabel blankLabel = (BlankLabel)obj;
				if (this != null)
				{
					if ((BlankLabel)obj != null)
					{
						int tag = _tag;
						int tag2 = blankLabel._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((BlankLabel)obj != null)
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
					BlankLabel blankLabel = obj as BlankLabel;
					if (blankLabel != null)
					{
						BlankLabel blankLabel2 = blankLabel;
						int tag = _tag;
						int tag2 = blankLabel2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "first";
				}
				return "last";
			}

			[CompilerGenerated]
			public sealed override bool Equals(BlankLabel obj)
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
				BlankLabel blankLabel = obj as BlankLabel;
				if (blankLabel != null)
				{
					return Equals(blankLabel);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class DeconvolutionLayout : IEquatable<DeconvolutionLayout>, IStructuralEquatable, IComparable<DeconvolutionLayout>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int NCDHW = 0;

				public const int NCHW = 1;

				public const int NCW = 2;

				public const int NDHWC = 3;

				public const int NHWC = 4;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly DeconvolutionLayout _unique_NCDHW = new DeconvolutionLayout(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly DeconvolutionLayout _unique_NCHW = new DeconvolutionLayout(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly DeconvolutionLayout _unique_NCW = new DeconvolutionLayout(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly DeconvolutionLayout _unique_NDHWC = new DeconvolutionLayout(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly DeconvolutionLayout _unique_NHWC = new DeconvolutionLayout(4);

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
			public static DeconvolutionLayout NCDHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCDHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCDHW
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
			public static DeconvolutionLayout NCHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCHW
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
			public static DeconvolutionLayout NCW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCW
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
			public static DeconvolutionLayout NDHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NDHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNDHWC
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static DeconvolutionLayout NHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNHWC
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal DeconvolutionLayout(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<DeconvolutionLayout, string>>((PrintfFormat<FSharpFunc<DeconvolutionLayout, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<DeconvolutionLayout, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(DeconvolutionLayout obj)
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
				return CompareTo((DeconvolutionLayout)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				DeconvolutionLayout deconvolutionLayout = (DeconvolutionLayout)obj;
				if (this != null)
				{
					if ((DeconvolutionLayout)obj != null)
					{
						int tag = _tag;
						int tag2 = deconvolutionLayout._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((DeconvolutionLayout)obj != null)
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
					DeconvolutionLayout deconvolutionLayout = obj as DeconvolutionLayout;
					if (deconvolutionLayout != null)
					{
						DeconvolutionLayout deconvolutionLayout2 = deconvolutionLayout;
						int tag = _tag;
						int tag2 = deconvolutionLayout2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "NCDHW";
				case 1:
					return "NCHW";
				case 2:
					return "NCW";
				case 3:
					return "NDHWC";
				case 4:
					return "NHWC";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(DeconvolutionLayout obj)
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
				DeconvolutionLayout deconvolutionLayout = obj as DeconvolutionLayout;
				if (deconvolutionLayout != null)
				{
					return Equals(deconvolutionLayout);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class DropoutMode : IEquatable<DropoutMode>, IStructuralEquatable, IComparable<DropoutMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Always = 0;

				public const int Training = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly DropoutMode _unique_Always = new DropoutMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly DropoutMode _unique_Training = new DropoutMode(1);

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
			public static DropoutMode Always
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Always;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsAlways
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
			public static DropoutMode Training
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Training;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsTraining
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
			internal DropoutMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<DropoutMode, string>>((PrintfFormat<FSharpFunc<DropoutMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<DropoutMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(DropoutMode obj)
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
				return CompareTo((DropoutMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				DropoutMode dropoutMode = (DropoutMode)obj;
				if (this != null)
				{
					if ((DropoutMode)obj != null)
					{
						int tag = _tag;
						int tag2 = dropoutMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((DropoutMode)obj != null)
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
					DropoutMode dropoutMode = obj as DropoutMode;
					if (dropoutMode != null)
					{
						DropoutMode dropoutMode2 = dropoutMode;
						int tag = _tag;
						int tag2 = dropoutMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "always";
				}
				return "training";
			}

			[CompilerGenerated]
			public sealed override bool Equals(DropoutMode obj)
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
				DropoutMode dropoutMode = obj as DropoutMode;
				if (dropoutMode != null)
				{
					return Equals(dropoutMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class FloatDType : IEquatable<FloatDType>, IStructuralEquatable, IComparable<FloatDType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Float16 = 0;

				public const int Float32 = 1;

				public const int Float64 = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly FloatDType _unique_Float16 = new FloatDType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly FloatDType _unique_Float32 = new FloatDType(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly FloatDType _unique_Float64 = new FloatDType(2);

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
			public static FloatDType Float16
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Float16;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFloat16
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
			public static FloatDType Float32
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Float32;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFloat32
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
			public static FloatDType Float64
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Float64;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFloat64
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
			internal FloatDType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<FloatDType, string>>((PrintfFormat<FSharpFunc<FloatDType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<FloatDType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(FloatDType obj)
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
				return CompareTo((FloatDType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				FloatDType floatDType = (FloatDType)obj;
				if (this != null)
				{
					if ((FloatDType)obj != null)
					{
						int tag = _tag;
						int tag2 = floatDType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((FloatDType)obj != null)
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
					FloatDType floatDType = obj as FloatDType;
					if (floatDType != null)
					{
						FloatDType floatDType2 = floatDType;
						int tag = _tag;
						int tag2 = floatDType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "float16";
				case 1:
					return "float32";
				case 2:
					return "float64";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(FloatDType obj)
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
				FloatDType floatDType = obj as FloatDType;
				if (floatDType != null)
				{
					return Equals(floatDType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class PoolType : IEquatable<PoolType>, IStructuralEquatable, IComparable<PoolType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Avg = 0;

				public const int Lp = 1;

				public const int Max = 2;

				public const int Sum = 3;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolType _unique_Avg = new PoolType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolType _unique_Lp = new PoolType(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolType _unique_Max = new PoolType(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolType _unique_Sum = new PoolType(3);

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
			public static PoolType Avg
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Avg;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsAvg
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
			public static PoolType Lp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Lp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsLp
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
			public static PoolType Max
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Max;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsMax
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
			public static PoolType Sum
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Sum;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSum
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
			internal PoolType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<PoolType, string>>((PrintfFormat<FSharpFunc<PoolType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<PoolType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(PoolType obj)
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
				return CompareTo((PoolType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				PoolType poolType = (PoolType)obj;
				if (this != null)
				{
					if ((PoolType)obj != null)
					{
						int tag = _tag;
						int tag2 = poolType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((PoolType)obj != null)
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
					PoolType poolType = obj as PoolType;
					if (poolType != null)
					{
						PoolType poolType2 = poolType;
						int tag = _tag;
						int tag2 = poolType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "avg";
				case 1:
					return "lp";
				case 2:
					return "max";
				case 3:
					return "sum";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(PoolType obj)
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
				PoolType poolType = obj as PoolType;
				if (poolType != null)
				{
					return Equals(poolType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class PoolingConvention : IEquatable<PoolingConvention>, IStructuralEquatable, IComparable<PoolingConvention>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Full = 0;

				public const int Same = 1;

				public const int Valid = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingConvention _unique_Full = new PoolingConvention(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingConvention _unique_Same = new PoolingConvention(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingConvention _unique_Valid = new PoolingConvention(2);

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
			public static PoolingConvention Full
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Full;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFull
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
			public static PoolingConvention Same
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Same;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSame
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
			public static PoolingConvention Valid
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Valid;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsValid
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
			internal PoolingConvention(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<PoolingConvention, string>>((PrintfFormat<FSharpFunc<PoolingConvention, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<PoolingConvention, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(PoolingConvention obj)
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
				return CompareTo((PoolingConvention)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				PoolingConvention poolingConvention = (PoolingConvention)obj;
				if (this != null)
				{
					if ((PoolingConvention)obj != null)
					{
						int tag = _tag;
						int tag2 = poolingConvention._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((PoolingConvention)obj != null)
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
					PoolingConvention poolingConvention = obj as PoolingConvention;
					if (poolingConvention != null)
					{
						PoolingConvention poolingConvention2 = poolingConvention;
						int tag = _tag;
						int tag2 = poolingConvention2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "full";
				case 1:
					return "same";
				case 2:
					return "valid";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(PoolingConvention obj)
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
				PoolingConvention poolingConvention = obj as PoolingConvention;
				if (poolingConvention != null)
				{
					return Equals(poolingConvention);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class PoolingLayout : IEquatable<PoolingLayout>, IStructuralEquatable, IComparable<PoolingLayout>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int NCDHW = 0;

				public const int NCHW = 1;

				public const int NCW = 2;

				public const int NDHWC = 3;

				public const int NHWC = 4;

				public const int NWC = 5;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingLayout _unique_NCDHW = new PoolingLayout(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingLayout _unique_NCHW = new PoolingLayout(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingLayout _unique_NCW = new PoolingLayout(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingLayout _unique_NDHWC = new PoolingLayout(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingLayout _unique_NHWC = new PoolingLayout(4);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PoolingLayout _unique_NWC = new PoolingLayout(5);

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
			public static PoolingLayout NCDHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCDHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCDHW
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
			public static PoolingLayout NCHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCHW
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
			public static PoolingLayout NCW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCW
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
			public static PoolingLayout NDHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NDHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNDHWC
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static PoolingLayout NHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNHWC
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static PoolingLayout NWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNWC
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 5;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal PoolingLayout(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<PoolingLayout, string>>((PrintfFormat<FSharpFunc<PoolingLayout, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<PoolingLayout, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(PoolingLayout obj)
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
				return CompareTo((PoolingLayout)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				PoolingLayout poolingLayout = (PoolingLayout)obj;
				if (this != null)
				{
					if ((PoolingLayout)obj != null)
					{
						int tag = _tag;
						int tag2 = poolingLayout._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((PoolingLayout)obj != null)
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
					PoolingLayout poolingLayout = obj as PoolingLayout;
					if (poolingLayout != null)
					{
						PoolingLayout poolingLayout2 = poolingLayout;
						int tag = _tag;
						int tag2 = poolingLayout2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "NCDHW";
				case 1:
					return "NCHW";
				case 2:
					return "NCW";
				case 3:
					return "NDHWC";
				case 4:
					return "NHWC";
				case 5:
					return "NWC";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(PoolingLayout obj)
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
				PoolingLayout poolingLayout = obj as PoolingLayout;
				if (poolingLayout != null)
				{
					return Equals(poolingLayout);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class SoftmaxActivationMode : IEquatable<SoftmaxActivationMode>, IStructuralEquatable, IComparable<SoftmaxActivationMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Channel = 0;

				public const int Instance = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SoftmaxActivationMode _unique_Channel = new SoftmaxActivationMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SoftmaxActivationMode _unique_Instance = new SoftmaxActivationMode(1);

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
			public static SoftmaxActivationMode Channel
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Channel;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsChannel
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
			public static SoftmaxActivationMode Instance
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Instance;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsInstance
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
			internal SoftmaxActivationMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SoftmaxActivationMode, string>>((PrintfFormat<FSharpFunc<SoftmaxActivationMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SoftmaxActivationMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(SoftmaxActivationMode obj)
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
				return CompareTo((SoftmaxActivationMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				SoftmaxActivationMode softmaxActivationMode = (SoftmaxActivationMode)obj;
				if (this != null)
				{
					if ((SoftmaxActivationMode)obj != null)
					{
						int tag = _tag;
						int tag2 = softmaxActivationMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((SoftmaxActivationMode)obj != null)
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
					SoftmaxActivationMode softmaxActivationMode = obj as SoftmaxActivationMode;
					if (softmaxActivationMode != null)
					{
						SoftmaxActivationMode softmaxActivationMode2 = softmaxActivationMode;
						int tag = _tag;
						int tag2 = softmaxActivationMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "channel";
				}
				return "instance";
			}

			[CompilerGenerated]
			public sealed override bool Equals(SoftmaxActivationMode obj)
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
				SoftmaxActivationMode softmaxActivationMode = obj as SoftmaxActivationMode;
				if (softmaxActivationMode != null)
				{
					return Equals(softmaxActivationMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class SampleType : IEquatable<SampleType>, IStructuralEquatable, IComparable<SampleType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Bilinear = 0;

				public const int Nearest = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SampleType _unique_Bilinear = new SampleType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SampleType _unique_Nearest = new SampleType(1);

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
			public static SampleType Bilinear
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Bilinear;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsBilinear
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
			public static SampleType Nearest
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Nearest;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNearest
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
			internal SampleType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SampleType, string>>((PrintfFormat<FSharpFunc<SampleType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SampleType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(SampleType obj)
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
				return CompareTo((SampleType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				SampleType sampleType = (SampleType)obj;
				if (this != null)
				{
					if ((SampleType)obj != null)
					{
						int tag = _tag;
						int tag2 = sampleType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((SampleType)obj != null)
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
					SampleType sampleType = obj as SampleType;
					if (sampleType != null)
					{
						SampleType sampleType2 = sampleType;
						int tag = _tag;
						int tag2 = sampleType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "bilinear";
				}
				return "nearest";
			}

			[CompilerGenerated]
			public sealed override bool Equals(SampleType obj)
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
				SampleType sampleType = obj as SampleType;
				if (sampleType != null)
				{
					return Equals(sampleType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class MultiInputMode : IEquatable<MultiInputMode>, IStructuralEquatable, IComparable<MultiInputMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Concat = 0;

				public const int Sum = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly MultiInputMode _unique_Concat = new MultiInputMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly MultiInputMode _unique_Sum = new MultiInputMode(1);

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
			public static MultiInputMode Concat
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Concat;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsConcat
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
			public static MultiInputMode Sum
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Sum;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSum
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
			internal MultiInputMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<MultiInputMode, string>>((PrintfFormat<FSharpFunc<MultiInputMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<MultiInputMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(MultiInputMode obj)
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
				return CompareTo((MultiInputMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				MultiInputMode multiInputMode = (MultiInputMode)obj;
				if (this != null)
				{
					if ((MultiInputMode)obj != null)
					{
						int tag = _tag;
						int tag2 = multiInputMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((MultiInputMode)obj != null)
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
					MultiInputMode multiInputMode = obj as MultiInputMode;
					if (multiInputMode != null)
					{
						MultiInputMode multiInputMode2 = multiInputMode;
						int tag = _tag;
						int tag2 = multiInputMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "concat";
				}
				return "sum";
			}

			[CompilerGenerated]
			public sealed override bool Equals(MultiInputMode obj)
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
				MultiInputMode multiInputMode = obj as MultiInputMode;
				if (multiInputMode != null)
				{
					return Equals(multiInputMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class PadMode : IEquatable<PadMode>, IStructuralEquatable, IComparable<PadMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Constant = 0;

				public const int Edge = 1;

				public const int Reflect = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PadMode _unique_Constant = new PadMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PadMode _unique_Edge = new PadMode(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PadMode _unique_Reflect = new PadMode(2);

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
			public static PadMode Constant
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Constant;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsConstant
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
			public static PadMode Edge
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Edge;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsEdge
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
			public static PadMode Reflect
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Reflect;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsReflect
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
			internal PadMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<PadMode, string>>((PrintfFormat<FSharpFunc<PadMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<PadMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(PadMode obj)
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
				return CompareTo((PadMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				PadMode padMode = (PadMode)obj;
				if (this != null)
				{
					if ((PadMode)obj != null)
					{
						int tag = _tag;
						int tag2 = padMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((PadMode)obj != null)
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
					PadMode padMode = obj as PadMode;
					if (padMode != null)
					{
						PadMode padMode2 = padMode;
						int tag = _tag;
						int tag2 = padMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "constant";
				case 1:
					return "edge";
				case 2:
					return "reflect";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(PadMode obj)
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
				PadMode padMode = obj as PadMode;
				if (padMode != null)
				{
					return Equals(padMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribDequantizeOutType : IEquatable<ContribDequantizeOutType>, IStructuralEquatable, IComparable<ContribDequantizeOutType>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribDequantizeOutType _unique_Float32 = new ContribDequantizeOutType();

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
			public static ContribDequantizeOutType Float32
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Float32;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ContribDequantizeOutType()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribDequantizeOutType, string>>((PrintfFormat<FSharpFunc<ContribDequantizeOutType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribDequantizeOutType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribDequantizeOutType obj)
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
				return CompareTo((ContribDequantizeOutType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribDequantizeOutType contribDequantizeOutType = (ContribDequantizeOutType)obj;
				if (this != null)
				{
					if ((ContribDequantizeOutType)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((ContribDequantizeOutType)obj != null)
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
					ContribDequantizeOutType contribDequantizeOutType = obj as ContribDequantizeOutType;
					if (contribDequantizeOutType != null)
					{
						ContribDequantizeOutType contribDequantizeOutType2 = contribDequantizeOutType;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				return "float32";
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribDequantizeOutType obj)
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
				ContribDequantizeOutType contribDequantizeOutType = obj as ContribDequantizeOutType;
				if (contribDequantizeOutType != null)
				{
					return Equals(contribDequantizeOutType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribQuantizedConvLayout : IEquatable<ContribQuantizedConvLayout>, IStructuralEquatable, IComparable<ContribQuantizedConvLayout>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int NCDHW = 0;

				public const int NCHW = 1;

				public const int NCW = 2;

				public const int NDHWC = 3;

				public const int NHWC = 4;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedConvLayout _unique_NCDHW = new ContribQuantizedConvLayout(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedConvLayout _unique_NCHW = new ContribQuantizedConvLayout(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedConvLayout _unique_NCW = new ContribQuantizedConvLayout(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedConvLayout _unique_NDHWC = new ContribQuantizedConvLayout(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedConvLayout _unique_NHWC = new ContribQuantizedConvLayout(4);

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
			public static ContribQuantizedConvLayout NCDHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCDHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCDHW
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
			public static ContribQuantizedConvLayout NCHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCHW
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
			public static ContribQuantizedConvLayout NCW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCW
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
			public static ContribQuantizedConvLayout NDHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NDHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNDHWC
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static ContribQuantizedConvLayout NHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNHWC
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ContribQuantizedConvLayout(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribQuantizedConvLayout, string>>((PrintfFormat<FSharpFunc<ContribQuantizedConvLayout, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribQuantizedConvLayout, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribQuantizedConvLayout obj)
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
				return CompareTo((ContribQuantizedConvLayout)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribQuantizedConvLayout contribQuantizedConvLayout = (ContribQuantizedConvLayout)obj;
				if (this != null)
				{
					if ((ContribQuantizedConvLayout)obj != null)
					{
						int tag = _tag;
						int tag2 = contribQuantizedConvLayout._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ContribQuantizedConvLayout)obj != null)
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
					ContribQuantizedConvLayout contribQuantizedConvLayout = obj as ContribQuantizedConvLayout;
					if (contribQuantizedConvLayout != null)
					{
						ContribQuantizedConvLayout contribQuantizedConvLayout2 = contribQuantizedConvLayout;
						int tag = _tag;
						int tag2 = contribQuantizedConvLayout2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "NCDHW";
				case 1:
					return "NCHW";
				case 2:
					return "NCW";
				case 3:
					return "NDHWC";
				case 4:
					return "NHWC";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribQuantizedConvLayout obj)
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
				ContribQuantizedConvLayout contribQuantizedConvLayout = obj as ContribQuantizedConvLayout;
				if (contribQuantizedConvLayout != null)
				{
					return Equals(contribQuantizedConvLayout);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribQuantizedPoolingLayout : IEquatable<ContribQuantizedPoolingLayout>, IStructuralEquatable, IComparable<ContribQuantizedPoolingLayout>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int NCDHW = 0;

				public const int NCHW = 1;

				public const int NCW = 2;

				public const int NDHWC = 3;

				public const int NHWC = 4;

				public const int NWC = 5;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedPoolingLayout _unique_NCDHW = new ContribQuantizedPoolingLayout(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedPoolingLayout _unique_NCHW = new ContribQuantizedPoolingLayout(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedPoolingLayout _unique_NCW = new ContribQuantizedPoolingLayout(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedPoolingLayout _unique_NDHWC = new ContribQuantizedPoolingLayout(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedPoolingLayout _unique_NHWC = new ContribQuantizedPoolingLayout(4);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizedPoolingLayout _unique_NWC = new ContribQuantizedPoolingLayout(5);

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
			public static ContribQuantizedPoolingLayout NCDHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCDHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCDHW
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
			public static ContribQuantizedPoolingLayout NCHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCHW
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
			public static ContribQuantizedPoolingLayout NCW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCW
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
			public static ContribQuantizedPoolingLayout NDHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NDHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNDHWC
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static ContribQuantizedPoolingLayout NHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNHWC
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static ContribQuantizedPoolingLayout NWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNWC
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 5;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ContribQuantizedPoolingLayout(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribQuantizedPoolingLayout, string>>((PrintfFormat<FSharpFunc<ContribQuantizedPoolingLayout, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribQuantizedPoolingLayout, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribQuantizedPoolingLayout obj)
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
				return CompareTo((ContribQuantizedPoolingLayout)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribQuantizedPoolingLayout contribQuantizedPoolingLayout = (ContribQuantizedPoolingLayout)obj;
				if (this != null)
				{
					if ((ContribQuantizedPoolingLayout)obj != null)
					{
						int tag = _tag;
						int tag2 = contribQuantizedPoolingLayout._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ContribQuantizedPoolingLayout)obj != null)
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
					ContribQuantizedPoolingLayout contribQuantizedPoolingLayout = obj as ContribQuantizedPoolingLayout;
					if (contribQuantizedPoolingLayout != null)
					{
						ContribQuantizedPoolingLayout contribQuantizedPoolingLayout2 = contribQuantizedPoolingLayout;
						int tag = _tag;
						int tag2 = contribQuantizedPoolingLayout2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "NCDHW";
				case 1:
					return "NCHW";
				case 2:
					return "NCW";
				case 3:
					return "NDHWC";
				case 4:
					return "NHWC";
				case 5:
					return "NWC";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribQuantizedPoolingLayout obj)
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
				ContribQuantizedPoolingLayout contribQuantizedPoolingLayout = obj as ContribQuantizedPoolingLayout;
				if (contribQuantizedPoolingLayout != null)
				{
					return Equals(contribQuantizedPoolingLayout);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribQuantizeOutType : IEquatable<ContribQuantizeOutType>, IStructuralEquatable, IComparable<ContribQuantizeOutType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Int8 = 0;

				public const int Uint8 = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizeOutType _unique_Int8 = new ContribQuantizeOutType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizeOutType _unique_Uint8 = new ContribQuantizeOutType(1);

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
			public static ContribQuantizeOutType Int8
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Int8;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsInt8
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
			public static ContribQuantizeOutType Uint8
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Uint8;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsUint8
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
			internal ContribQuantizeOutType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribQuantizeOutType, string>>((PrintfFormat<FSharpFunc<ContribQuantizeOutType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribQuantizeOutType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribQuantizeOutType obj)
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
				return CompareTo((ContribQuantizeOutType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribQuantizeOutType contribQuantizeOutType = (ContribQuantizeOutType)obj;
				if (this != null)
				{
					if ((ContribQuantizeOutType)obj != null)
					{
						int tag = _tag;
						int tag2 = contribQuantizeOutType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ContribQuantizeOutType)obj != null)
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
					ContribQuantizeOutType contribQuantizeOutType = obj as ContribQuantizeOutType;
					if (contribQuantizeOutType != null)
					{
						ContribQuantizeOutType contribQuantizeOutType2 = contribQuantizeOutType;
						int tag = _tag;
						int tag2 = contribQuantizeOutType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "int8";
				}
				return "uint8";
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribQuantizeOutType obj)
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
				ContribQuantizeOutType contribQuantizeOutType = obj as ContribQuantizeOutType;
				if (contribQuantizeOutType != null)
				{
					return Equals(contribQuantizeOutType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribQuantizeV2OutType : IEquatable<ContribQuantizeV2OutType>, IStructuralEquatable, IComparable<ContribQuantizeV2OutType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Auto = 0;

				public const int Int8 = 1;

				public const int Uint8 = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizeV2OutType _unique_Auto = new ContribQuantizeV2OutType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizeV2OutType _unique_Int8 = new ContribQuantizeV2OutType(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribQuantizeV2OutType _unique_Uint8 = new ContribQuantizeV2OutType(2);

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
			public static ContribQuantizeV2OutType Auto
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Auto;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsAuto
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
			public static ContribQuantizeV2OutType Int8
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Int8;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsInt8
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
			public static ContribQuantizeV2OutType Uint8
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Uint8;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsUint8
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
			internal ContribQuantizeV2OutType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribQuantizeV2OutType, string>>((PrintfFormat<FSharpFunc<ContribQuantizeV2OutType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribQuantizeV2OutType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribQuantizeV2OutType obj)
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
				return CompareTo((ContribQuantizeV2OutType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribQuantizeV2OutType contribQuantizeV2OutType = (ContribQuantizeV2OutType)obj;
				if (this != null)
				{
					if ((ContribQuantizeV2OutType)obj != null)
					{
						int tag = _tag;
						int tag2 = contribQuantizeV2OutType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ContribQuantizeV2OutType)obj != null)
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
					ContribQuantizeV2OutType contribQuantizeV2OutType = obj as ContribQuantizeV2OutType;
					if (contribQuantizeV2OutType != null)
					{
						ContribQuantizeV2OutType contribQuantizeV2OutType2 = contribQuantizeV2OutType;
						int tag = _tag;
						int tag2 = contribQuantizeV2OutType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "auto";
				case 1:
					return "int8";
				case 2:
					return "uint8";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribQuantizeV2OutType obj)
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
				ContribQuantizeV2OutType contribQuantizeV2OutType = obj as ContribQuantizeV2OutType;
				if (contribQuantizeV2OutType != null)
				{
					return Equals(contribQuantizeV2OutType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribRequantizeOutType : IEquatable<ContribRequantizeOutType>, IStructuralEquatable, IComparable<ContribRequantizeOutType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Auto = 0;

				public const int Int8 = 1;

				public const int Uint8 = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribRequantizeOutType _unique_Auto = new ContribRequantizeOutType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribRequantizeOutType _unique_Int8 = new ContribRequantizeOutType(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribRequantizeOutType _unique_Uint8 = new ContribRequantizeOutType(2);

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
			public static ContribRequantizeOutType Auto
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Auto;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsAuto
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
			public static ContribRequantizeOutType Int8
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Int8;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsInt8
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
			public static ContribRequantizeOutType Uint8
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Uint8;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsUint8
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
			internal ContribRequantizeOutType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribRequantizeOutType, string>>((PrintfFormat<FSharpFunc<ContribRequantizeOutType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribRequantizeOutType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribRequantizeOutType obj)
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
				return CompareTo((ContribRequantizeOutType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribRequantizeOutType contribRequantizeOutType = (ContribRequantizeOutType)obj;
				if (this != null)
				{
					if ((ContribRequantizeOutType)obj != null)
					{
						int tag = _tag;
						int tag2 = contribRequantizeOutType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ContribRequantizeOutType)obj != null)
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
					ContribRequantizeOutType contribRequantizeOutType = obj as ContribRequantizeOutType;
					if (contribRequantizeOutType != null)
					{
						ContribRequantizeOutType contribRequantizeOutType2 = contribRequantizeOutType;
						int tag = _tag;
						int tag2 = contribRequantizeOutType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "auto";
				case 1:
					return "int8";
				case 2:
					return "uint8";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribRequantizeOutType obj)
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
				ContribRequantizeOutType contribRequantizeOutType = obj as ContribRequantizeOutType;
				if (contribRequantizeOutType != null)
				{
					return Equals(contribRequantizeOutType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class SampleMultinomialDtype : IEquatable<SampleMultinomialDtype>, IStructuralEquatable, IComparable<SampleMultinomialDtype>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Float16 = 0;

				public const int Float32 = 1;

				public const int Float64 = 2;

				public const int Int32 = 3;

				public const int Uint8 = 4;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SampleMultinomialDtype _unique_Float16 = new SampleMultinomialDtype(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SampleMultinomialDtype _unique_Float32 = new SampleMultinomialDtype(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SampleMultinomialDtype _unique_Float64 = new SampleMultinomialDtype(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SampleMultinomialDtype _unique_Int32 = new SampleMultinomialDtype(3);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SampleMultinomialDtype _unique_Uint8 = new SampleMultinomialDtype(4);

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
			public static SampleMultinomialDtype Float16
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Float16;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFloat16
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
			public static SampleMultinomialDtype Float32
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Float32;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFloat32
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
			public static SampleMultinomialDtype Float64
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Float64;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsFloat64
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
			public static SampleMultinomialDtype Int32
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Int32;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsInt32
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
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static SampleMultinomialDtype Uint8
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Uint8;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsUint8
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return Tag == 4;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal SampleMultinomialDtype(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SampleMultinomialDtype, string>>((PrintfFormat<FSharpFunc<SampleMultinomialDtype, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SampleMultinomialDtype, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(SampleMultinomialDtype obj)
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
				return CompareTo((SampleMultinomialDtype)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				SampleMultinomialDtype sampleMultinomialDtype = (SampleMultinomialDtype)obj;
				if (this != null)
				{
					if ((SampleMultinomialDtype)obj != null)
					{
						int tag = _tag;
						int tag2 = sampleMultinomialDtype._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((SampleMultinomialDtype)obj != null)
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
					SampleMultinomialDtype sampleMultinomialDtype = obj as SampleMultinomialDtype;
					if (sampleMultinomialDtype != null)
					{
						SampleMultinomialDtype sampleMultinomialDtype2 = sampleMultinomialDtype;
						int tag = _tag;
						int tag2 = sampleMultinomialDtype2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "float16";
				case 1:
					return "float32";
				case 2:
					return "float64";
				case 3:
					return "int32";
				case 4:
					return "uint8";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(SampleMultinomialDtype obj)
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
				SampleMultinomialDtype sampleMultinomialDtype = obj as SampleMultinomialDtype;
				if (sampleMultinomialDtype != null)
				{
					return Equals(sampleMultinomialDtype);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class RandomRandintDtype : IEquatable<RandomRandintDtype>, IStructuralEquatable, IComparable<RandomRandintDtype>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Int32 = 0;

				public const int Int64 = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RandomRandintDtype _unique_Int32 = new RandomRandintDtype(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RandomRandintDtype _unique_Int64 = new RandomRandintDtype(1);

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
			public static RandomRandintDtype Int32
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Int32;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsInt32
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
			public static RandomRandintDtype Int64
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Int64;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsInt64
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
			internal RandomRandintDtype(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<RandomRandintDtype, string>>((PrintfFormat<FSharpFunc<RandomRandintDtype, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<RandomRandintDtype, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(RandomRandintDtype obj)
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
				return CompareTo((RandomRandintDtype)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				RandomRandintDtype randomRandintDtype = (RandomRandintDtype)obj;
				if (this != null)
				{
					if ((RandomRandintDtype)obj != null)
					{
						int tag = _tag;
						int tag2 = randomRandintDtype._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((RandomRandintDtype)obj != null)
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
					RandomRandintDtype randomRandintDtype = obj as RandomRandintDtype;
					if (randomRandintDtype != null)
					{
						RandomRandintDtype randomRandintDtype2 = randomRandintDtype;
						int tag = _tag;
						int tag2 = randomRandintDtype2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "int32";
				}
				return "int64";
			}

			[CompilerGenerated]
			public sealed override bool Equals(RandomRandintDtype obj)
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
				RandomRandintDtype randomRandintDtype = obj as RandomRandintDtype;
				if (randomRandintDtype != null)
				{
					return Equals(randomRandintDtype);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class RNNMode : IEquatable<RNNMode>, IStructuralEquatable, IComparable<RNNMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Gru = 0;

				public const int Lstm = 1;

				public const int RnnRelu = 2;

				public const int RnnTanh = 3;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RNNMode _unique_Gru = new RNNMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RNNMode _unique_Lstm = new RNNMode(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RNNMode _unique_RnnRelu = new RNNMode(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RNNMode _unique_RnnTanh = new RNNMode(3);

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
			public static RNNMode Gru
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Gru;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsGru
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
			public static RNNMode Lstm
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Lstm;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsLstm
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
			public static RNNMode RnnRelu
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_RnnRelu;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsRnnRelu
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
			public static RNNMode RnnTanh
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_RnnTanh;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsRnnTanh
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
			internal RNNMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<RNNMode, string>>((PrintfFormat<FSharpFunc<RNNMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<RNNMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(RNNMode obj)
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
				return CompareTo((RNNMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				RNNMode rNNMode = (RNNMode)obj;
				if (this != null)
				{
					if ((RNNMode)obj != null)
					{
						int tag = _tag;
						int tag2 = rNNMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((RNNMode)obj != null)
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
					RNNMode rNNMode = obj as RNNMode;
					if (rNNMode != null)
					{
						RNNMode rNNMode2 = rNNMode;
						int tag = _tag;
						int tag2 = rNNMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "gru";
				case 1:
					return "lstm";
				case 2:
					return "rnn_relu";
				case 3:
					return "rnn_tanh";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(RNNMode obj)
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
				RNNMode rNNMode = obj as RNNMode;
				if (rNNMode != null)
				{
					return Equals(rNNMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class Normalization : IEquatable<Normalization>, IStructuralEquatable, IComparable<Normalization>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Batch = 0;

				public const int Null = 1;

				public const int Valid = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly Normalization _unique_Batch = new Normalization(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly Normalization _unique_Null = new Normalization(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly Normalization _unique_Valid = new Normalization(2);

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
			public static Normalization Batch
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Batch;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsBatch
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
			public static Normalization Null
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Null;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNull
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
			public static Normalization Valid
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Valid;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsValid
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
			internal Normalization(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Normalization, string>>((PrintfFormat<FSharpFunc<Normalization, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Normalization, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(Normalization obj)
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
				return CompareTo((Normalization)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				Normalization normalization = (Normalization)obj;
				if (this != null)
				{
					if ((Normalization)obj != null)
					{
						int tag = _tag;
						int tag2 = normalization._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((Normalization)obj != null)
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
					Normalization normalization = obj as Normalization;
					if (normalization != null)
					{
						Normalization normalization2 = normalization;
						int tag = _tag;
						int tag2 = normalization2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "batch";
				case 1:
					return "null";
				case 2:
					return "valid";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(Normalization obj)
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
				Normalization normalization = obj as Normalization;
				if (normalization != null)
				{
					return Equals(normalization);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class PickMode : IEquatable<PickMode>, IStructuralEquatable, IComparable<PickMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Clip = 0;

				public const int Wrap = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PickMode _unique_Clip = new PickMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly PickMode _unique_Wrap = new PickMode(1);

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
			public static PickMode Clip
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Clip;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsClip
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
			public static PickMode Wrap
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Wrap;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsWrap
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
			internal PickMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<PickMode, string>>((PrintfFormat<FSharpFunc<PickMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<PickMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(PickMode obj)
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
				return CompareTo((PickMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				PickMode pickMode = (PickMode)obj;
				if (this != null)
				{
					if ((PickMode)obj != null)
					{
						int tag = _tag;
						int tag2 = pickMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((PickMode)obj != null)
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
					PickMode pickMode = obj as PickMode;
					if (pickMode != null)
					{
						PickMode pickMode2 = pickMode;
						int tag = _tag;
						int tag2 = pickMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "clip";
				}
				return "wrap";
			}

			[CompilerGenerated]
			public sealed override bool Equals(PickMode obj)
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
				PickMode pickMode = obj as PickMode;
				if (pickMode != null)
				{
					return Equals(pickMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class TakeMode : IEquatable<TakeMode>, IStructuralEquatable, IComparable<TakeMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Clip = 0;

				public const int Raise = 1;

				public const int Wrap = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly TakeMode _unique_Clip = new TakeMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly TakeMode _unique_Raise = new TakeMode(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly TakeMode _unique_Wrap = new TakeMode(2);

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
			public static TakeMode Clip
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Clip;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsClip
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
			public static TakeMode Raise
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Raise;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsRaise
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
			public static TakeMode Wrap
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Wrap;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsWrap
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
			internal TakeMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<TakeMode, string>>((PrintfFormat<FSharpFunc<TakeMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<TakeMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(TakeMode obj)
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
				return CompareTo((TakeMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				TakeMode takeMode = (TakeMode)obj;
				if (this != null)
				{
					if ((TakeMode)obj != null)
					{
						int tag = _tag;
						int tag2 = takeMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((TakeMode)obj != null)
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
					TakeMode takeMode = obj as TakeMode;
					if (takeMode != null)
					{
						TakeMode takeMode2 = takeMode;
						int tag = _tag;
						int tag2 = takeMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "clip";
				case 1:
					return "raise";
				case 2:
					return "wrap";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(TakeMode obj)
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
				TakeMode takeMode = obj as TakeMode;
				if (takeMode != null)
				{
					return Equals(takeMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class RetTyp : IEquatable<RetTyp>, IStructuralEquatable, IComparable<RetTyp>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Both = 0;

				public const int Indices = 1;

				public const int Mask = 2;

				public const int Value = 3;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RetTyp _unique_Both = new RetTyp(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RetTyp _unique_Indices = new RetTyp(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RetTyp _unique_Mask = new RetTyp(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly RetTyp _unique_Value = new RetTyp(3);

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
			public static RetTyp Both
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Both;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsBoth
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
			public static RetTyp Indices
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Indices;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsIndices
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
			public static RetTyp Mask
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Mask;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsMask
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
			public static RetTyp Value
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Value;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsValue
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
			internal RetTyp(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<RetTyp, string>>((PrintfFormat<FSharpFunc<RetTyp, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<RetTyp, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(RetTyp obj)
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
				return CompareTo((RetTyp)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				RetTyp retTyp = (RetTyp)obj;
				if (this != null)
				{
					if ((RetTyp)obj != null)
					{
						int tag = _tag;
						int tag2 = retTyp._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((RetTyp)obj != null)
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
					RetTyp retTyp = obj as RetTyp;
					if (retTyp != null)
					{
						RetTyp retTyp2 = retTyp;
						int tag = _tag;
						int tag2 = retTyp2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "both";
				case 1:
					return "indices";
				case 2:
					return "mask";
				case 3:
					return "value";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(RetTyp obj)
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
				RetTyp retTyp = obj as RetTyp;
				if (retTyp != null)
				{
					return Equals(retTyp);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribDeformableConvolutionLayout : IEquatable<ContribDeformableConvolutionLayout>, IStructuralEquatable, IComparable<ContribDeformableConvolutionLayout>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int NCDHW = 0;

				public const int NCHW = 1;

				public const int NCW = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribDeformableConvolutionLayout _unique_NCDHW = new ContribDeformableConvolutionLayout(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribDeformableConvolutionLayout _unique_NCHW = new ContribDeformableConvolutionLayout(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribDeformableConvolutionLayout _unique_NCW = new ContribDeformableConvolutionLayout(2);

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
			public static ContribDeformableConvolutionLayout NCDHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCDHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCDHW
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
			public static ContribDeformableConvolutionLayout NCHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCHW
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
			public static ContribDeformableConvolutionLayout NCW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCW
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
			internal ContribDeformableConvolutionLayout(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribDeformableConvolutionLayout, string>>((PrintfFormat<FSharpFunc<ContribDeformableConvolutionLayout, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribDeformableConvolutionLayout, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribDeformableConvolutionLayout obj)
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
				return CompareTo((ContribDeformableConvolutionLayout)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribDeformableConvolutionLayout contribDeformableConvolutionLayout = (ContribDeformableConvolutionLayout)obj;
				if (this != null)
				{
					if ((ContribDeformableConvolutionLayout)obj != null)
					{
						int tag = _tag;
						int tag2 = contribDeformableConvolutionLayout._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ContribDeformableConvolutionLayout)obj != null)
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
					ContribDeformableConvolutionLayout contribDeformableConvolutionLayout = obj as ContribDeformableConvolutionLayout;
					if (contribDeformableConvolutionLayout != null)
					{
						ContribDeformableConvolutionLayout contribDeformableConvolutionLayout2 = contribDeformableConvolutionLayout;
						int tag = _tag;
						int tag2 = contribDeformableConvolutionLayout2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "NCDHW";
				case 1:
					return "NCHW";
				case 2:
					return "NCW";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribDeformableConvolutionLayout obj)
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
				ContribDeformableConvolutionLayout contribDeformableConvolutionLayout = obj as ContribDeformableConvolutionLayout;
				if (contribDeformableConvolutionLayout != null)
				{
					return Equals(contribDeformableConvolutionLayout);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ContribModulatedDeformableConvolutionLayout : IEquatable<ContribModulatedDeformableConvolutionLayout>, IStructuralEquatable, IComparable<ContribModulatedDeformableConvolutionLayout>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int NCDHW = 0;

				public const int NCHW = 1;

				public const int NCW = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribModulatedDeformableConvolutionLayout _unique_NCDHW = new ContribModulatedDeformableConvolutionLayout(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribModulatedDeformableConvolutionLayout _unique_NCHW = new ContribModulatedDeformableConvolutionLayout(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ContribModulatedDeformableConvolutionLayout _unique_NCW = new ContribModulatedDeformableConvolutionLayout(2);

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
			public static ContribModulatedDeformableConvolutionLayout NCDHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCDHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCDHW
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
			public static ContribModulatedDeformableConvolutionLayout NCHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCHW
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
			public static ContribModulatedDeformableConvolutionLayout NCW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCW
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
			internal ContribModulatedDeformableConvolutionLayout(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ContribModulatedDeformableConvolutionLayout, string>>((PrintfFormat<FSharpFunc<ContribModulatedDeformableConvolutionLayout, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ContribModulatedDeformableConvolutionLayout, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ContribModulatedDeformableConvolutionLayout obj)
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
				return CompareTo((ContribModulatedDeformableConvolutionLayout)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ContribModulatedDeformableConvolutionLayout contribModulatedDeformableConvolutionLayout = (ContribModulatedDeformableConvolutionLayout)obj;
				if (this != null)
				{
					if ((ContribModulatedDeformableConvolutionLayout)obj != null)
					{
						int tag = _tag;
						int tag2 = contribModulatedDeformableConvolutionLayout._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ContribModulatedDeformableConvolutionLayout)obj != null)
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
					ContribModulatedDeformableConvolutionLayout contribModulatedDeformableConvolutionLayout = obj as ContribModulatedDeformableConvolutionLayout;
					if (contribModulatedDeformableConvolutionLayout != null)
					{
						ContribModulatedDeformableConvolutionLayout contribModulatedDeformableConvolutionLayout2 = contribModulatedDeformableConvolutionLayout;
						int tag = _tag;
						int tag2 = contribModulatedDeformableConvolutionLayout2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "NCDHW";
				case 1:
					return "NCHW";
				case 2:
					return "NCW";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ContribModulatedDeformableConvolutionLayout obj)
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
				ContribModulatedDeformableConvolutionLayout contribModulatedDeformableConvolutionLayout = obj as ContribModulatedDeformableConvolutionLayout;
				if (contribModulatedDeformableConvolutionLayout != null)
				{
					return Equals(contribModulatedDeformableConvolutionLayout);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class ConvolutionV1Layout : IEquatable<ConvolutionV1Layout>, IStructuralEquatable, IComparable<ConvolutionV1Layout>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int NCDHW = 0;

				public const int NCHW = 1;

				public const int NDHWC = 2;

				public const int NHWC = 3;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionV1Layout _unique_NCDHW = new ConvolutionV1Layout(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionV1Layout _unique_NCHW = new ConvolutionV1Layout(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionV1Layout _unique_NDHWC = new ConvolutionV1Layout(2);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly ConvolutionV1Layout _unique_NHWC = new ConvolutionV1Layout(3);

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
			public static ConvolutionV1Layout NCDHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCDHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCDHW
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
			public static ConvolutionV1Layout NCHW
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NCHW;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNCHW
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
			public static ConvolutionV1Layout NDHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NDHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNDHWC
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
			public static ConvolutionV1Layout NHWC
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_NHWC;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsNHWC
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
			internal ConvolutionV1Layout(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ConvolutionV1Layout, string>>((PrintfFormat<FSharpFunc<ConvolutionV1Layout, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ConvolutionV1Layout, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(ConvolutionV1Layout obj)
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
				return CompareTo((ConvolutionV1Layout)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				ConvolutionV1Layout convolutionV1Layout = (ConvolutionV1Layout)obj;
				if (this != null)
				{
					if ((ConvolutionV1Layout)obj != null)
					{
						int tag = _tag;
						int tag2 = convolutionV1Layout._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((ConvolutionV1Layout)obj != null)
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
					ConvolutionV1Layout convolutionV1Layout = obj as ConvolutionV1Layout;
					if (convolutionV1Layout != null)
					{
						ConvolutionV1Layout convolutionV1Layout2 = convolutionV1Layout;
						int tag = _tag;
						int tag2 = convolutionV1Layout2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "NCDHW";
				case 1:
					return "NCHW";
				case 2:
					return "NDHWC";
				case 3:
					return "NHWC";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(ConvolutionV1Layout obj)
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
				ConvolutionV1Layout convolutionV1Layout = obj as ConvolutionV1Layout;
				if (convolutionV1Layout != null)
				{
					return Equals(convolutionV1Layout);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class GridGeneratorTransformType : IEquatable<GridGeneratorTransformType>, IStructuralEquatable, IComparable<GridGeneratorTransformType>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Affine = 0;

				public const int Warp = 1;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly GridGeneratorTransformType _unique_Affine = new GridGeneratorTransformType(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly GridGeneratorTransformType _unique_Warp = new GridGeneratorTransformType(1);

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
			public static GridGeneratorTransformType Affine
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Affine;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsAffine
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
			public static GridGeneratorTransformType Warp
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Warp;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsWarp
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
			internal GridGeneratorTransformType(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<GridGeneratorTransformType, string>>((PrintfFormat<FSharpFunc<GridGeneratorTransformType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<GridGeneratorTransformType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(GridGeneratorTransformType obj)
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
				return CompareTo((GridGeneratorTransformType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				GridGeneratorTransformType gridGeneratorTransformType = (GridGeneratorTransformType)obj;
				if (this != null)
				{
					if ((GridGeneratorTransformType)obj != null)
					{
						int tag = _tag;
						int tag2 = gridGeneratorTransformType._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((GridGeneratorTransformType)obj != null)
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
					GridGeneratorTransformType gridGeneratorTransformType = obj as GridGeneratorTransformType;
					if (gridGeneratorTransformType != null)
					{
						GridGeneratorTransformType gridGeneratorTransformType2 = gridGeneratorTransformType;
						int tag = _tag;
						int tag2 = gridGeneratorTransformType2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				if (Tag != 1)
				{
					return "affine";
				}
				return "warp";
			}

			[CompilerGenerated]
			public sealed override bool Equals(GridGeneratorTransformType obj)
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
				GridGeneratorTransformType gridGeneratorTransformType = obj as GridGeneratorTransformType;
				if (gridGeneratorTransformType != null)
				{
					return Equals(gridGeneratorTransformType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class L2NormalizationMode : IEquatable<L2NormalizationMode>, IStructuralEquatable, IComparable<L2NormalizationMode>, IComparable, IStructuralComparable
		{
			public static class Tags
			{
				public const int Channel = 0;

				public const int Instance = 1;

				public const int Spatial = 2;
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int _tag;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly L2NormalizationMode _unique_Channel = new L2NormalizationMode(0);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly L2NormalizationMode _unique_Instance = new L2NormalizationMode(1);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly L2NormalizationMode _unique_Spatial = new L2NormalizationMode(2);

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
			public static L2NormalizationMode Channel
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Channel;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsChannel
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
			public static L2NormalizationMode Instance
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Instance;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsInstance
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
			public static L2NormalizationMode Spatial
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Spatial;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public bool IsSpatial
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
			internal L2NormalizationMode(int _tag)
			{
				this._tag = _tag;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<L2NormalizationMode, string>>((PrintfFormat<FSharpFunc<L2NormalizationMode, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<L2NormalizationMode, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(L2NormalizationMode obj)
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
				return CompareTo((L2NormalizationMode)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				L2NormalizationMode l2NormalizationMode = (L2NormalizationMode)obj;
				if (this != null)
				{
					if ((L2NormalizationMode)obj != null)
					{
						int tag = _tag;
						int tag2 = l2NormalizationMode._tag;
						if (tag == tag2)
						{
							return 0;
						}
						return tag - tag2;
					}
					return 1;
				}
				if ((L2NormalizationMode)obj != null)
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
					L2NormalizationMode l2NormalizationMode = obj as L2NormalizationMode;
					if (l2NormalizationMode != null)
					{
						L2NormalizationMode l2NormalizationMode2 = l2NormalizationMode;
						int tag = _tag;
						int tag2 = l2NormalizationMode2._tag;
						return tag == tag2;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				switch (Tag)
				{
				default:
					return "channel";
				case 1:
					return "instance";
				case 2:
					return "spatial";
				}
			}

			[CompilerGenerated]
			public sealed override bool Equals(L2NormalizationMode obj)
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
				L2NormalizationMode l2NormalizationMode = obj as L2NormalizationMode;
				if (l2NormalizationMode != null)
				{
					return Equals(l2NormalizationMode);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class SpatialTransformerTransformType : IEquatable<SpatialTransformerTransformType>, IStructuralEquatable, IComparable<SpatialTransformerTransformType>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SpatialTransformerTransformType _unique_Affine = new SpatialTransformerTransformType();

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
			public static SpatialTransformerTransformType Affine
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Affine;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal SpatialTransformerTransformType()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SpatialTransformerTransformType, string>>((PrintfFormat<FSharpFunc<SpatialTransformerTransformType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SpatialTransformerTransformType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(SpatialTransformerTransformType obj)
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
				return CompareTo((SpatialTransformerTransformType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				SpatialTransformerTransformType spatialTransformerTransformType = (SpatialTransformerTransformType)obj;
				if (this != null)
				{
					if ((SpatialTransformerTransformType)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((SpatialTransformerTransformType)obj != null)
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
					SpatialTransformerTransformType spatialTransformerTransformType = obj as SpatialTransformerTransformType;
					if (spatialTransformerTransformType != null)
					{
						SpatialTransformerTransformType spatialTransformerTransformType2 = spatialTransformerTransformType;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				return "affine";
			}

			[CompilerGenerated]
			public sealed override bool Equals(SpatialTransformerTransformType obj)
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
				SpatialTransformerTransformType spatialTransformerTransformType = obj as SpatialTransformerTransformType;
				if (spatialTransformerTransformType != null)
				{
					return Equals(spatialTransformerTransformType);
				}
				return false;
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[RequireQualifiedAccess]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public sealed class SamplerType : IEquatable<SamplerType>, IStructuralEquatable, IComparable<SamplerType>, IComparable, IStructuralComparable
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal static readonly SamplerType _unique_Bilinear = new SamplerType();

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
			public static SamplerType Bilinear
			{
				[CompilationMapping(/*Could not decode attribute arguments.*/)]
				get
				{
					return _unique_Bilinear;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal SamplerType()
			{
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal object __DebugDisplay()
			{
				return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<SamplerType, string>>((PrintfFormat<FSharpFunc<SamplerType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<SamplerType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(SamplerType obj)
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
				return CompareTo((SamplerType)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				SamplerType samplerType = (SamplerType)obj;
				if (this != null)
				{
					if ((SamplerType)obj != null)
					{
						return 0;
					}
					return 1;
				}
				if ((SamplerType)obj != null)
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
					SamplerType samplerType = obj as SamplerType;
					if (samplerType != null)
					{
						SamplerType samplerType2 = samplerType;
						return true;
					}
					return false;
				}
				return obj == null;
			}

			public override string ToString()
			{
				return "bilinear";
			}

			[CompilerGenerated]
			public sealed override bool Equals(SamplerType obj)
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
				SamplerType samplerType = obj as SamplerType;
				if (samplerType != null)
				{
					return Equals(samplerType);
				}
				return false;
			}
		}
	}
}
