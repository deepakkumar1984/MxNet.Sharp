using Microsoft.FSharp.Core;
using System.Collections.Generic;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class BindModule
	{
		public static Bind fromVariable(Variable v)
		{
			Parameter parameter = v as Parameter;
			if (parameter != null)
			{
				Parameter p = parameter;
				ArgBind binding = p.Binding;
				ArgBind item = binding;
				return Bind.NewArgBinding(item);
			}
			ArgBind argBind = ArgBind.Named(v.Name);
			ArgBind item2 = argBind;
			return Bind.NewArgBinding(item2);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bind shape(IEnumerable<int> shape, Bind b)
		{
			return b.WithShape(shape);
		}

		public static Bind noGrad(Bind b)
		{
			if (!(b is Bind.ArgBinding))
			{
				Bind.AuxBinding auxBinding = (Bind.AuxBinding)b;
				return b;
			}
			Bind.ArgBinding argBinding = (Bind.ArgBinding)b;
			ArgBind b2 = argBinding.item;
			ArgBind argBind = b2;
			return Bind.NewArgBinding(new ArgBind(argBind.Name_0040, argBind.NDArray_0040, argBind.Grad_0040, FSharpOption<OpReqType>.Some(OpReqType.NullOp), argBind.Shape_0040, argBind.DataType_0040, argBind.StorageType_0040));
		}

		public static Bind gradWriteTo(Bind b)
		{
			if (!(b is Bind.ArgBinding))
			{
				Bind.AuxBinding auxBinding = (Bind.AuxBinding)b;
				return b;
			}
			Bind.ArgBinding argBinding = (Bind.ArgBinding)b;
			ArgBind b2 = argBinding.item;
			ArgBind argBind = b2;
			return Bind.NewArgBinding(new ArgBind(argBind.Name_0040, argBind.NDArray_0040, argBind.Grad_0040, FSharpOption<OpReqType>.Some(OpReqType.WriteTo), argBind.Shape_0040, argBind.DataType_0040, argBind.StorageType_0040));
		}

		public static Bind gradWriteInPlace(Bind b)
		{
			if (!(b is Bind.ArgBinding))
			{
				Bind.AuxBinding auxBinding = (Bind.AuxBinding)b;
				return b;
			}
			Bind.ArgBinding argBinding = (Bind.ArgBinding)b;
			ArgBind b2 = argBinding.item;
			ArgBind argBind = b2;
			return Bind.NewArgBinding(new ArgBind(argBind.Name_0040, argBind.NDArray_0040, argBind.Grad_0040, FSharpOption<OpReqType>.Some(OpReqType.WriteInplace), argBind.Shape_0040, argBind.DataType_0040, argBind.StorageType_0040));
		}

		public static Bind gradAddTo(Bind b)
		{
			if (!(b is Bind.ArgBinding))
			{
				Bind.AuxBinding auxBinding = (Bind.AuxBinding)b;
				return b;
			}
			Bind.ArgBinding argBinding = (Bind.ArgBinding)b;
			ArgBind b2 = argBinding.item;
			ArgBind argBind = b2;
			return Bind.NewArgBinding(new ArgBind(argBind.Name_0040, argBind.NDArray_0040, argBind.Grad_0040, FSharpOption<OpReqType>.Some(OpReqType.AddTo), argBind.Shape_0040, argBind.DataType_0040, argBind.StorageType_0040));
		}
	}
}
