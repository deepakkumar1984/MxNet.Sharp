using Microsoft.FSharp.Core;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class PrimitiveOperators
	{
		[Serializable]
		internal sealed class op_Exponentiation_0040145<t1, t2, a, b> : FSharpFunc<InternalPrimitiveOperatorHelpers.PowerOp, a, t1, FSharpFunc<t2, b>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal op_Exponentiation_0040145()
			{
			}

			public override FSharpFunc<t2, b> Invoke(InternalPrimitiveOperatorHelpers.PowerOp arg0, a arg1, t1 arg2)
			{
				throw new NotSupportedException("Dynamic invocation of op_DynamicAssignment is not supported");
			}
		}

		public static y exp<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Exp is not supported");
		}

		public static y log<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Log is not supported");
		}

		public static y abs<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Abs is not supported");
		}

		public static y acos<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Acos is not supported");
		}

		public static y asin<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Asin is not supported");
		}

		public static y atan<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Atan is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static y atan2<t1, t2, y>(t1 x, t2 y)
		{
			throw new NotSupportedException("Dynamic invocation of Atan2 is not supported");
		}

		public static y ceiling<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Ceiling is not supported");
		}

		public static y floor<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Floor is not supported");
		}

		public static y truncate<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Truncate is not supported");
		}

		public static y round<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Round is not supported");
		}

		public static y log10<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Log10 is not supported");
		}

		public static y sqrt<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Sqrt is not supported");
		}

		public static y cos<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Cos is not supported");
		}

		public static y cosh<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Cosh is not supported");
		}

		public static y sin<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Sin is not supported");
		}

		public static y sinh<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Sinh is not supported");
		}

		public static y tan<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Tan is not supported");
		}

		public static y tanh<t, y>(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Tanh is not supported");
		}

		public static y operator -(t x)
		{
			throw new NotSupportedException("Dynamic invocation of Negate is not supported");
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static b op_Exponentiation<t1, a, t2, b>(t1 x, t2 y)
		{
			InternalPrimitiveOperatorHelpers.PowerOp powerOp = InternalPrimitiveOperatorHelpers.PowerOp.PowerOp;
			op_Exponentiation_0040145<t1, t2, a, b> op_Exponentiation_0040 = new op_Exponentiation_0040145<t1, t2, a, b>();
			if (0 == 0)
			{
				throw new NotSupportedException("Dynamic invocation of get_Instance is not supported");
			}
			return FSharpFunc<InternalPrimitiveOperatorHelpers.PowerOp, a>.InvokeFast<t1, t2, b>((FSharpFunc<InternalPrimitiveOperatorHelpers.PowerOp, FSharpFunc<a, FSharpFunc<t1, FSharpFunc<t2, b>>>>)(object)op_Exponentiation_0040, powerOp, (a)(object)null, x, y);
		}
	}
}
