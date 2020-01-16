using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
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
	public sealed class DataType : IEquatable<DataType>, IStructuralEquatable, IComparable<DataType>, IComparable, IStructuralComparable
	{
		public static class Tags
		{
			public const int Float16 = 0;

			public const int Float32 = 1;

			public const int Float64 = 2;

			public const int Int32 = 3;

			public const int Int64 = 4;

			public const int Int8 = 5;

			public const int UInt8 = 6;

			public const int Bool = 7;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal readonly int _tag;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DataType _unique_Float16 = new DataType(0);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DataType _unique_Float32 = new DataType(1);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DataType _unique_Float64 = new DataType(2);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DataType _unique_Int32 = new DataType(3);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DataType _unique_Int64 = new DataType(4);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DataType _unique_Int8 = new DataType(5);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DataType _unique_UInt8 = new DataType(6);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DataType _unique_Bool = new DataType(7);

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
		public static DataType Float16
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
		public static DataType Float32
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
		public static DataType Float64
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
		public static DataType Int32
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
		public static DataType Int64
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
				return Tag == 4;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static DataType Int8
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
				return Tag == 5;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static DataType UInt8
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_UInt8;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsUInt8
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static DataType Bool
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_Bool;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsBool
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return Tag == 7;
			}
		}

		public FSharpOption<Type> Type
		{
			get
			{
				switch (Tag)
				{
				default:
					return null;
				case 1:
					return FSharpOption<System.Type>.Some(typeof(float));
				case 2:
					return FSharpOption<System.Type>.Some(typeof(double));
				case 3:
					return FSharpOption<System.Type>.Some(typeof(int));
				case 4:
					return FSharpOption<System.Type>.Some(typeof(long));
				case 5:
					return FSharpOption<System.Type>.Some(typeof(sbyte));
				case 6:
					return FSharpOption<System.Type>.Some(typeof(byte));
				case 7:
					return FSharpOption<System.Type>.Some(typeof(bool));
				}
			}
		}

		public TypeFlag TypeFlag
		{
			get
			{
				switch (Tag)
				{
				default:
					return TypeFlag.Float16;
				case 1:
					return TypeFlag.Float32;
				case 2:
					return TypeFlag.Float64;
				case 3:
					return TypeFlag.Int32;
				case 4:
					return TypeFlag.Int64;
				case 5:
					return TypeFlag.Int8;
				case 6:
					return TypeFlag.Uint8;
				case 7:
					return TypeFlag.Bool;
				}
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal DataType(int _tag)
		{
			this._tag = _tag;
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<DataType, string>>((PrintfFormat<FSharpFunc<DataType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<DataType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(DataType obj)
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
			return CompareTo((DataType)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			DataType dataType = (DataType)obj;
			if (this != null)
			{
				if ((DataType)obj != null)
				{
					int tag = _tag;
					int tag2 = dataType._tag;
					if (tag == tag2)
					{
						return 0;
					}
					return tag - tag2;
				}
				return 1;
			}
			if ((DataType)obj != null)
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
				DataType dataType = obj as DataType;
				if (dataType != null)
				{
					DataType dataType2 = dataType;
					int tag = _tag;
					int tag2 = dataType2._tag;
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
				return "int64";
			case 5:
				return "int8";
			case 6:
				return "uint8";
			case 7:
				return "bool";
			}
		}

		public static FSharpOption<DataType> FromTypeFlag(TypeFlag typeflag)
		{
			switch (typeflag)
			{
			case TypeFlag.None:
				return null;
			case TypeFlag.Float16:
				return FSharpOption<DataType>.Some(Float16);
			case TypeFlag.Float32:
				return FSharpOption<DataType>.Some(Float32);
			case TypeFlag.Float64:
				return FSharpOption<DataType>.Some(Float64);
			case TypeFlag.Int32:
				return FSharpOption<DataType>.Some(Int32);
			case TypeFlag.Int64:
				return FSharpOption<DataType>.Some(Int64);
			case TypeFlag.Int8:
				return FSharpOption<DataType>.Some(Int8);
			case TypeFlag.Uint8:
				return FSharpOption<DataType>.Some(UInt8);
			case TypeFlag.Bool:
				return FSharpOption<DataType>.Some(Bool);
			default:
				return null;
			}
		}

		public static FSharpOption<DataType> FromInt(int typeFlagInt)
		{
			return FromTypeFlag((TypeFlag)typeFlagInt);
		}

		public static DataType FromNetType(Type t)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(float)))
			{
				return Float32;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(double)))
			{
				return Float64;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(int)))
			{
				return Int32;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(long)))
			{
				return Int64;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(sbyte)))
			{
				return Int8;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(byte)))
			{
				return UInt8;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(bool)))
			{
				return Bool;
			}
			FSharpFunc<string, DataType> val = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, DataType>, DataType>((PrintfFormat<FSharpFunc<string, DataType>, Unit, string, DataType>)(object)new PrintfFormat<FSharpFunc<string, DataType>, Unit, string, DataType, string>("No corresponding MXNet type for type %s"));
			string name = t.Name;
			return val.Invoke(name);
		}

		public static FSharpOption<DataType> TryFromNetType(Type t)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(float)))
			{
				return FSharpOption<DataType>.Some(Float32);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(double)))
			{
				return FSharpOption<DataType>.Some(Float64);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(int)))
			{
				return FSharpOption<DataType>.Some(Int32);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(long)))
			{
				return FSharpOption<DataType>.Some(Int64);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(sbyte)))
			{
				return FSharpOption<DataType>.Some(Int8);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(byte)))
			{
				return FSharpOption<DataType>.Some(UInt8);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(t, typeof(bool)))
			{
				return FSharpOption<DataType>.Some(Bool);
			}
			return null;
		}

		public static DataType FromNetType<a>()
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				return Float32;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
			{
				return Float64;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
			{
				return Int32;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
			{
				return Int64;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
			{
				return Int8;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
			{
				return UInt8;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
			{
				return Bool;
			}
			FSharpFunc<string, DataType> val = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, DataType>, DataType>((PrintfFormat<FSharpFunc<string, DataType>, Unit, string, DataType>)(object)new PrintfFormat<FSharpFunc<string, DataType>, Unit, string, DataType, string>("No corresponding MXNet type for type %s"));
			string name = typeof(a).Name;
			return val.Invoke(name);
		}

		public static FSharpOption<DataType> TryFromNetType<a>()
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				return FSharpOption<DataType>.Some(Float32);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
			{
				return FSharpOption<DataType>.Some(Float64);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
			{
				return FSharpOption<DataType>.Some(Int32);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
			{
				return FSharpOption<DataType>.Some(Int64);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
			{
				return FSharpOption<DataType>.Some(Int8);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
			{
				return FSharpOption<DataType>.Some(UInt8);
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
			{
				return FSharpOption<DataType>.Some(Bool);
			}
			return null;
		}

		[CompilerGenerated]
		public sealed override bool Equals(DataType obj)
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
			DataType dataType = obj as DataType;
			if (dataType != null)
			{
				return Equals(dataType);
			}
			return false;
		}
	}
}
