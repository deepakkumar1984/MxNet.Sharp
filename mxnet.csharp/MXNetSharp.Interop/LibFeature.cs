using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Interop
{
	[Serializable]
	[Struct]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public struct LibFeature : IEquatable<LibFeature>, IStructuralEquatable, IComparable<LibFeature>, IComparable, IStructuralComparable
	{
		internal string name_0040;

		internal byte enabled_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal string name => name_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal byte enabled => enabled_0040;

		public string Name => name_0040;

		public bool Enabled => enabled_0040 != 0;

		[CompilerGenerated]
		public sealed override int CompareTo(LibFeature obj)
		{
			IComparer genericComparer = LanguagePrimitives.get_GenericComparer();
			int num = string.CompareOrdinal(name_0040, obj.name_0040);
			if (num < 0)
			{
				return num;
			}
			if (num > 0)
			{
				return num;
			}
			IComparer genericComparer2 = LanguagePrimitives.get_GenericComparer();
			byte b = enabled_0040;
			byte b2 = obj.enabled_0040;
			if ((uint)b < (uint)b2)
			{
				return -1;
			}
			return ((uint)b > (uint)b2) ? 1 : 0;
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj)
		{
			return CompareTo((LibFeature)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			LibFeature libFeature = (LibFeature)obj;
			int num = string.CompareOrdinal(name_0040, libFeature.name_0040);
			if (num < 0)
			{
				return num;
			}
			if (num > 0)
			{
				return num;
			}
			byte b = enabled_0040;
			byte b2 = libFeature.enabled_0040;
			if ((uint)b < (uint)b2)
			{
				return -1;
			}
			return ((uint)b > (uint)b2) ? 1 : 0;
		}

		[CompilerGenerated]
		public sealed override int GetHashCode(IEqualityComparer comp)
		{
			int num = 0;
			num = -1640531527 + (enabled_0040 + ((num << 6) + (num >> 2)));
			return -1640531527 + ((name_0040?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
		}

		[CompilerGenerated]
		public sealed override int GetHashCode()
		{
			return GetHashCode(LanguagePrimitives.get_GenericEqualityComparer());
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj, IEqualityComparer comp)
		{
			if (IntrinsicFunctions.TypeTestGeneric<LibFeature>(obj))
			{
				LibFeature libFeature = (LibFeature)obj;
				if (string.Equals(name_0040, libFeature.name_0040))
				{
					return enabled_0040 == libFeature.enabled_0040;
				}
				return false;
			}
			return false;
		}

		[CompilerGenerated]
		public sealed override bool Equals(LibFeature obj)
		{
			if (string.Equals(name_0040, obj.name_0040))
			{
				return enabled_0040 == obj.enabled_0040;
			}
			return false;
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj)
		{
			if (IntrinsicFunctions.TypeTestGeneric<LibFeature>(obj))
			{
				LibFeature obj2 = (LibFeature)obj;
				return Equals(obj2);
			}
			return false;
		}
	}
}
