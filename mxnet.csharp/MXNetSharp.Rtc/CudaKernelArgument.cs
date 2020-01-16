using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp.Rtc
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public sealed class CudaKernelArgument : IEquatable<CudaKernelArgument>, IStructuralEquatable, IComparable<CudaKernelArgument>, IComparable, IStructuralComparable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string Name_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal bool IsNDArray_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal bool IsConst_0040;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal TypeFlag Type_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Name => Name_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public bool IsNDArray => IsNDArray_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public bool IsConst => IsConst_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public TypeFlag Type => Type_0040;

		public CudaKernelArgument(string name, bool isNDArray, bool isConst, TypeFlag type)
		{
			Name_0040 = name;
			IsNDArray_0040 = isNDArray;
			IsConst_0040 = isConst;
			Type_0040 = type;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<CudaKernelArgument, string>>((PrintfFormat<FSharpFunc<CudaKernelArgument, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<CudaKernelArgument, string>, Unit, string, string, CudaKernelArgument>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(CudaKernelArgument obj)
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
					bool isNDArray_0040 = IsNDArray_0040;
					bool isNDArray_00402 = obj.IsNDArray_0040;
					int num2 = ((isNDArray_0040 ? 1 : 0) >= (isNDArray_00402 ? 1 : 0)) ? (((isNDArray_0040 ? 1 : 0) > (isNDArray_00402 ? 1 : 0)) ? 1 : 0) : (-1);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					IComparer genericComparer3 = LanguagePrimitives.get_GenericComparer();
					bool isConst_0040 = IsConst_0040;
					bool isConst_00402 = obj.IsConst_0040;
					int num3 = ((isConst_0040 ? 1 : 0) >= (isConst_00402 ? 1 : 0)) ? (((isConst_0040 ? 1 : 0) > (isConst_00402 ? 1 : 0)) ? 1 : 0) : (-1);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					IComparer genericComparer4 = LanguagePrimitives.get_GenericComparer();
					TypeFlag type_0040 = Type_0040;
					TypeFlag type_00402 = obj.Type_0040;
					if (type_0040 < type_00402)
					{
						return -1;
					}
					return (type_0040 > type_00402) ? 1 : 0;
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
			return CompareTo((CudaKernelArgument)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			CudaKernelArgument cudaKernelArgument = (CudaKernelArgument)obj;
			CudaKernelArgument cudaKernelArgument2 = cudaKernelArgument;
			if (this != null)
			{
				if ((CudaKernelArgument)obj != null)
				{
					int num = string.CompareOrdinal(Name_0040, cudaKernelArgument2.Name_0040);
					if (num < 0)
					{
						return num;
					}
					if (num > 0)
					{
						return num;
					}
					bool isNDArray_0040 = IsNDArray_0040;
					bool isNDArray_00402 = cudaKernelArgument2.IsNDArray_0040;
					int num2 = ((isNDArray_0040 ? 1 : 0) >= (isNDArray_00402 ? 1 : 0)) ? (((isNDArray_0040 ? 1 : 0) > (isNDArray_00402 ? 1 : 0)) ? 1 : 0) : (-1);
					if (num2 < 0)
					{
						return num2;
					}
					if (num2 > 0)
					{
						return num2;
					}
					bool isConst_0040 = IsConst_0040;
					bool isConst_00402 = cudaKernelArgument2.IsConst_0040;
					int num3 = ((isConst_0040 ? 1 : 0) >= (isConst_00402 ? 1 : 0)) ? (((isConst_0040 ? 1 : 0) > (isConst_00402 ? 1 : 0)) ? 1 : 0) : (-1);
					if (num3 < 0)
					{
						return num3;
					}
					if (num3 > 0)
					{
						return num3;
					}
					TypeFlag type_0040 = Type_0040;
					TypeFlag type_00402 = cudaKernelArgument2.Type_0040;
					if (type_0040 < type_00402)
					{
						return -1;
					}
					return (type_0040 > type_00402) ? 1 : 0;
				}
				return 1;
			}
			if ((CudaKernelArgument)obj != null)
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
				num = (int)(-1640531527 + (Type_0040 + ((num << 6) + (num >> 2))));
				num = -1640531527 + ((IsConst_0040 ? 1 : 0) + ((num << 6) + (num >> 2)));
				num = -1640531527 + ((IsNDArray_0040 ? 1 : 0) + ((num << 6) + (num >> 2)));
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
				CudaKernelArgument cudaKernelArgument = obj as CudaKernelArgument;
				if (cudaKernelArgument != null)
				{
					CudaKernelArgument cudaKernelArgument2 = cudaKernelArgument;
					if (string.Equals(Name_0040, cudaKernelArgument2.Name_0040))
					{
						if (IsNDArray_0040 == cudaKernelArgument2.IsNDArray_0040)
						{
							if (IsConst_0040 == cudaKernelArgument2.IsConst_0040)
							{
								return Type_0040 == cudaKernelArgument2.Type_0040;
							}
							return false;
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
		public sealed override bool Equals(CudaKernelArgument obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (string.Equals(Name_0040, obj.Name_0040))
					{
						if (IsNDArray_0040 == obj.IsNDArray_0040)
						{
							if (IsConst_0040 == obj.IsConst_0040)
							{
								return Type_0040 == obj.Type_0040;
							}
							return false;
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
			CudaKernelArgument cudaKernelArgument = obj as CudaKernelArgument;
			if (cudaKernelArgument != null)
			{
				return Equals(cudaKernelArgument);
			}
			return false;
		}
	}
}
