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
	public sealed class DeviceType : IEquatable<DeviceType>, IStructuralEquatable, IComparable<DeviceType>, IComparable, IStructuralComparable
	{
		public static class Tags
		{
			public const int CPU = 0;

			public const int GPU = 1;

			public const int CPUPinned = 2;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal readonly int _tag;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DeviceType _unique_CPU = new DeviceType(0);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DeviceType _unique_GPU = new DeviceType(1);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal static readonly DeviceType _unique_CPUPinned = new DeviceType(2);

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
		public static DeviceType CPU
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_CPU;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsCPU
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
		public static DeviceType GPU
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_GPU;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsGPU
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
		public static DeviceType CPUPinned
		{
			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			get
			{
				return _unique_CPUPinned;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsCPUPinned
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
		internal DeviceType(int _tag)
		{
			this._tag = _tag;
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<DeviceType, string>>((PrintfFormat<FSharpFunc<DeviceType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<DeviceType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<DeviceType, string>>((PrintfFormat<FSharpFunc<DeviceType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<DeviceType, string>, Unit, string, string, DeviceType>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(DeviceType obj)
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
			return CompareTo((DeviceType)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			DeviceType deviceType = (DeviceType)obj;
			if (this != null)
			{
				if ((DeviceType)obj != null)
				{
					int tag = _tag;
					int tag2 = deviceType._tag;
					if (tag == tag2)
					{
						return 0;
					}
					return tag - tag2;
				}
				return 1;
			}
			if ((DeviceType)obj != null)
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
				DeviceType deviceType = obj as DeviceType;
				if (deviceType != null)
				{
					DeviceType deviceType2 = deviceType;
					int tag = _tag;
					int tag2 = deviceType2._tag;
					return tag == tag2;
				}
				return false;
			}
			return obj == null;
		}

		public static DeviceType FromInt(int n)
		{
			switch (n)
			{
			case 1:
				return CPU;
			case 2:
				return GPU;
			case 3:
				return CPUPinned;
			default:
			{
				string paramName = "n";
				string message = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int, string>>((PrintfFormat<FSharpFunc<int, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("Unknown device %d")).Invoke(n);
				throw new ArgumentException(message, paramName);
			}
			}
		}

		public DeviceTypeEnum ToEnum()
		{
			switch (Tag)
			{
			default:
				return DeviceTypeEnum.CPU;
			case 1:
				return DeviceTypeEnum.GPU;
			case 2:
				return DeviceTypeEnum.CPUPinned;
			}
		}

		public int ToInt()
		{
			return (int)ToEnum();
		}

		public static explicit operator int(DeviceType st)
		{
			return st.ToInt();
		}

		[CompilerGenerated]
		public sealed override bool Equals(DeviceType obj)
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
			DeviceType deviceType = obj as DeviceType;
			if (deviceType != null)
			{
				return Equals(deviceType);
			}
			return false;
		}
	}
}
