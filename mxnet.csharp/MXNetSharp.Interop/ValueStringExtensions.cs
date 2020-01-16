using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	[DebuggerDisplay("{__DebugDisplay(),nq}")]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class ValueStringExtensions : IEquatable<ValueStringExtensions>, IStructuralEquatable, IComparable<ValueStringExtensions>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly ValueStringExtensions _unique_ValueStringExtensions = new ValueStringExtensions();

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
		public static ValueStringExtensions ValueStringExtensions
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_ValueStringExtensions;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal ValueStringExtensions()
		{
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ValueStringExtensions, string>>((PrintfFormat<FSharpFunc<ValueStringExtensions, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ValueStringExtensions, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ValueStringExtensions, string>>((PrintfFormat<FSharpFunc<ValueStringExtensions, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ValueStringExtensions, string>, Unit, string, string, ValueStringExtensions>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(ValueStringExtensions obj)
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
			return CompareTo((ValueStringExtensions)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			ValueStringExtensions valueStringExtensions = (ValueStringExtensions)obj;
			if (this != null)
			{
				if ((ValueStringExtensions)obj != null)
				{
					return 0;
				}
				return 1;
			}
			if ((ValueStringExtensions)obj != null)
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
				ValueStringExtensions valueStringExtensions = obj as ValueStringExtensions;
				if (valueStringExtensions != null)
				{
					ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
					return true;
				}
				return false;
			}
			return obj == null;
		}

		public static string ValueString(this IEnumerable<FSharpOption<int>> x)
		{
			string text = StringModule.Concat(",", SeqModule.Map<FSharpOption<int>, string>((FSharpFunc<FSharpOption<int>, string>)new _0024Interop.ValueString_004087(), x));
			FSharpFunc<string, string> val = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("[%s]"));
			string text2 = text;
			return val.Invoke(text2);
		}

		public static string ValueString(this IEnumerable<int> x)
		{
			string text = StringModule.Concat(",", SeqModule.Map<int, string>((FSharpFunc<int, string>)new _0024Interop.ValueString_004089_002D1(), x));
			FSharpFunc<string, string> val = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("[%s]"));
			string text2 = text;
			return val.Invoke(text2);
		}

		public static string ValueString(this IEnumerable<long> x)
		{
			string text = StringModule.Concat(",", SeqModule.Map<long, string>((FSharpFunc<long, string>)new _0024Interop.ValueString_004091_002D2(), x));
			FSharpFunc<string, string> val = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("[%s]"));
			string text2 = text;
			return val.Invoke(text2);
		}

		public static string ValueString(this IEnumerable<double> x)
		{
			string text = StringModule.Concat(",", SeqModule.Map<double, string>((FSharpFunc<double, string>)new _0024Interop.ValueString_004093_002D3(), x));
			FSharpFunc<string, string> val = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("[%s]"));
			string text2 = text;
			return val.Invoke(text2);
		}

		public static string ValueString(this bool x)
		{
			if (x)
			{
				return "1";
			}
			return "0";
		}

		public static string ValueString(this string x)
		{
			return x;
		}

		public static string ValueString(this object x)
		{
			if (!IntrinsicFunctions.TypeTestGeneric<bool>(x))
			{
				string text = x as string;
				if (text == null)
				{
					IEnumerable<int> enumerable = x as IEnumerable<int>;
					if (enumerable == null)
					{
						IEnumerable<FSharpOption<int>> enumerable2 = x as IEnumerable<FSharpOption<int>>;
						if (enumerable2 == null)
						{
							IEnumerable<double> enumerable3 = x as IEnumerable<double>;
							if (enumerable3 == null)
							{
								IEnumerable<long> enumerable4 = x as IEnumerable<long>;
								if (enumerable4 != null)
								{
									IEnumerable<long> x4 = enumerable4;
									return ValueString(x4);
								}
								if (x != null)
								{
									IFormattable formattable = x as IFormattable;
									if (formattable != null)
									{
										IFormattable formattable2 = formattable;
										return formattable2.ToString(null, CultureInfo.InvariantCulture);
									}
									return x.ToString();
								}
								return "";
							}
							IEnumerable<double> x5 = enumerable3;
							return ValueString(x5);
						}
						IEnumerable<FSharpOption<int>> x6 = enumerable2;
						return ValueString(x6);
					}
					IEnumerable<int> x3 = enumerable;
					return ValueString(x3);
				}
				return text;
			}
			bool x2 = (bool)x;
			return ValueString(x2);
		}

		[CompilerGenerated]
		public sealed override bool Equals(ValueStringExtensions obj)
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
			ValueStringExtensions valueStringExtensions = obj as ValueStringExtensions;
			if (valueStringExtensions != null)
			{
				return Equals(valueStringExtensions);
			}
			return false;
		}
	}
}
