using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[Serializable]
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	[NoComparison]
	[DebuggerDisplay("{__DebugDisplay(),nq}")]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public abstract class Bind : IEquatable<Bind>, IStructuralEquatable
	{
		public static class Tags
		{
			public const int AuxBinding = 0;

			public const int ArgBinding = 1;
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(AuxBinding_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class AuxBinding : Bind
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly AuxBind item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public AuxBind Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal AuxBinding(AuxBind item)
			{
				this.item = item;
			}
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(ArgBinding_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class ArgBinding : Bind
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly ArgBind item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public ArgBind Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ArgBinding(ArgBind item)
			{
				this.item = item;
			}
		}

		internal class AuxBinding_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal AuxBinding _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public AuxBind Item
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return _obj.item;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public AuxBinding_0040DebugTypeProxy(AuxBinding obj)
			{
				_obj = obj;
			}
		}

		internal class ArgBinding_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ArgBinding _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public ArgBind Item
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return _obj.item;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public ArgBinding_0040DebugTypeProxy(ArgBinding obj)
			{
				_obj = obj;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Tag
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return (this is ArgBinding) ? 1 : 0;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsAuxBinding
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is AuxBinding;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsArgBinding
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is ArgBinding;
			}
		}

		public string Name
		{
			get
			{
				if (!(this is ArgBinding))
				{
					AuxBinding auxBinding = (AuxBinding)this;
					AuxBind r = auxBinding.item;
					return r.Name_0040;
				}
				ArgBinding argBinding = (ArgBinding)this;
				ArgBind r2 = argBinding.item;
				return r2.Name_0040;
			}
		}

		public FSharpOption<int[]> Shape
		{
			get
			{
				if (!(this is ArgBinding))
				{
					AuxBinding auxBinding = (AuxBinding)this;
					return auxBinding.item.Shape_0040;
				}
				ArgBinding argBinding = (ArgBinding)this;
				return argBinding.item.Shape_0040;
			}
		}

		public FSharpOption<DataType> DataType
		{
			get
			{
				if (!(this is ArgBinding))
				{
					AuxBinding auxBinding = (AuxBinding)this;
					return auxBinding.item.DataType_0040;
				}
				ArgBinding argBinding = (ArgBinding)this;
				return argBinding.item.DataType_0040;
			}
		}

		public FSharpOption<NDArray> Grad
		{
			get
			{
				if (!(this is ArgBinding))
				{
					AuxBinding auxBinding = (AuxBinding)this;
					AuxBind a = auxBinding.item;
					return null;
				}
				ArgBinding argBinding = (ArgBinding)this;
				ArgBind a2 = argBinding.item;
				return a2.Grad_0040;
			}
		}

		public FSharpOption<NDArray> NDArray
		{
			get
			{
				if (!(this is ArgBinding))
				{
					AuxBinding auxBinding = (AuxBinding)this;
					AuxBind a = auxBinding.item;
					return a.NDArray_0040;
				}
				ArgBinding argBinding = (ArgBinding)this;
				ArgBind a2 = argBinding.item;
				return a2.NDArray_0040;
			}
		}

		public bool HasNDArray => FSharpOption<MXNetSharp.NDArray>.get_IsSome(NDArray);

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal Bind()
		{
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static Bind NewAuxBinding(AuxBind item)
		{
			return new AuxBinding(item);
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static Bind NewArgBinding(ArgBind item)
		{
			return new ArgBinding(item);
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Bind, string>>((PrintfFormat<FSharpFunc<Bind, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Bind, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Bind, string>>((PrintfFormat<FSharpFunc<Bind, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Bind, string>, Unit, string, string, Bind>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				int num = 0;
				if (this is AuxBinding)
				{
					AuxBinding auxBinding = (AuxBinding)this;
					num = 0;
					return -1640531527 + (auxBinding.item.GetHashCode(comp) + ((num << 6) + (num >> 2)));
				}
				ArgBinding argBinding = (ArgBinding)this;
				num = 1;
				return -1640531527 + (argBinding.item.GetHashCode(comp) + ((num << 6) + (num >> 2)));
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
				Bind bind = obj as Bind;
				if (bind != null)
				{
					Bind bind2 = bind;
					int num = (this is ArgBinding) ? 1 : 0;
					Bind bind3 = bind2;
					int num2 = (bind3 is ArgBinding) ? 1 : 0;
					if (num == num2)
					{
						if (this is AuxBinding)
						{
							AuxBinding auxBinding = (AuxBinding)this;
							AuxBinding auxBinding2 = (AuxBinding)bind2;
							AuxBind item = auxBinding.item;
							AuxBind item2 = auxBinding2.item;
							return item.Equals(item2, comp);
						}
						ArgBinding argBinding = (ArgBinding)this;
						ArgBinding argBinding2 = (ArgBinding)bind2;
						ArgBind item3 = argBinding.item;
						ArgBind item4 = argBinding2.item;
						return item3.Equals(item4, comp);
					}
					return false;
				}
				return false;
			}
			return obj == null;
		}

		public Bind WithShape(IEnumerable<int> s)
		{
			if (!(this is ArgBinding))
			{
				AuxBinding auxBinding = (AuxBinding)this;
				AuxBind b = auxBinding.item;
				AuxBind auxBind = b;
				AuxBind auxBind2 = new AuxBind(auxBind.Name_0040, auxBind.NDArray_0040, FSharpOption<int[]>.Some(ArrayModule.OfSeq<int>(s)), auxBind.DataType_0040, auxBind.StorageType_0040);
				AuxBind item = auxBind2;
				return NewAuxBinding(item);
			}
			ArgBinding argBinding = (ArgBinding)this;
			ArgBind b2 = argBinding.item;
			ArgBind argBind = b2;
			ArgBind argBind2 = new ArgBind(argBind.Name_0040, argBind.NDArray_0040, argBind.Grad_0040, argBind.OpReqType_0040, FSharpOption<int[]>.Some(ArrayModule.OfSeq<int>(s)), argBind.DataType_0040, argBind.StorageType_0040);
			ArgBind item2 = argBind2;
			return NewArgBinding(item2);
		}

		public Bind WithNDArray(NDArray ndarray)
		{
			if (!(this is ArgBinding))
			{
				AuxBinding auxBinding = (AuxBinding)this;
				AuxBind a = auxBinding.item;
				AuxBind auxBind = a;
				return NewAuxBinding(new AuxBind(auxBind.Name_0040, FSharpOption<MXNetSharp.NDArray>.Some(ndarray), auxBind.Shape_0040, auxBind.DataType_0040, auxBind.StorageType_0040));
			}
			ArgBinding argBinding = (ArgBinding)this;
			ArgBind a2 = argBinding.item;
			ArgBind argBind = a2;
			return NewArgBinding(new ArgBind(argBind.Name_0040, FSharpOption<MXNetSharp.NDArray>.Some(ndarray), argBind.Grad_0040, argBind.OpReqType_0040, argBind.Shape_0040, argBind.DataType_0040, argBind.StorageType_0040));
		}

		public static Bind Arg(string name, [OptionalArgument] FSharpOption<NDArray> ndarray, [OptionalArgument] FSharpOption<NDArray> grad, [OptionalArgument] FSharpOption<OpReqType> opReqType, [OptionalArgument] FSharpOption<IEnumerable<int>> shape, [OptionalArgument] FSharpOption<DataType> dataType, [OptionalArgument] FSharpOption<StorageType> storageType)
		{
			ArgBind argBind = ArgBind.Named(name);
			return NewArgBinding(new ArgBind(name, ndarray, grad, opReqType, OptionModule.Map<IEnumerable<int>, int[]>((FSharpFunc<IEnumerable<int>, int[]>)new _0024Executor.Arg_004088(), shape), dataType, storageType));
		}

		public static Bind Aux(string name, [OptionalArgument] FSharpOption<NDArray> ndarray, [OptionalArgument] FSharpOption<int[]> shape, [OptionalArgument] FSharpOption<DataType> dataType, [OptionalArgument] FSharpOption<StorageType> storageType)
		{
			AuxBind auxBind = AuxBind.Named(name);
			return NewAuxBinding(new AuxBind(name, ndarray, OptionModule.Map<int[], int[]>((FSharpFunc<int[], int[]>)new _0024Executor.Aux_004097(), shape), dataType, storageType));
		}

		[CompilerGenerated]
		public sealed override bool Equals(Bind obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					int num = (this is ArgBinding) ? 1 : 0;
					int num2 = (obj is ArgBinding) ? 1 : 0;
					if (num == num2)
					{
						if (this is AuxBinding)
						{
							AuxBinding auxBinding = (AuxBinding)this;
							AuxBinding auxBinding2 = (AuxBinding)obj;
							return auxBinding.item.Equals(auxBinding2.item);
						}
						ArgBinding argBinding = (ArgBinding)this;
						ArgBinding argBinding2 = (ArgBinding)obj;
						return argBinding.item.Equals(argBinding2.item);
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
			Bind bind = obj as Bind;
			if (bind != null)
			{
				return Equals(bind);
			}
			return false;
		}
	}
}
