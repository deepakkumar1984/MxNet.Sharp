using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.SymbolArgument
{
	[Serializable]
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	[NoComparison]
	[DebuggerDisplay("{__DebugDisplay(),nq}")]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public abstract class OpArg<a> : IEquatable<OpArg<a>>, IStructuralEquatable
	{
		public static class Tags
		{
			public const int VarArg = 0;

			public const int Parameter = 1;

			public const int Input = 2;
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(OpArg<>.VarArg_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class VarArg : OpArg<a>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly string item1;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly a[] item2;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public string Item1
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public a[] Item2
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal VarArg(string item1, a[] item2)
			{
				this.item1 = item1;
				this.item2 = item2;
			}
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(OpArg<>.Parameter_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class Parameter : OpArg<a>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly FSharpOption<object> item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public FSharpOption<object> Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Parameter(FSharpOption<object> item)
			{
				this.item = item;
			}
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(OpArg<>.Input_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class Input : OpArg<a>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly a item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public a Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Input(a item)
			{
				this.item = item;
			}
		}

		internal class VarArg_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal VarArg _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public string Item1
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return _obj.item1;
				}
			}

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public a[] Item2
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return _obj.item2;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public VarArg_0040DebugTypeProxy(VarArg obj)
			{
				_obj = obj;
			}
		}

		internal class Parameter_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Parameter _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public FSharpOption<object> Item
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
			public Parameter_0040DebugTypeProxy(Parameter obj)
			{
				_obj = obj;
			}
		}

		internal class Input_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Input _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public a Item
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
			public Input_0040DebugTypeProxy(Input obj)
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
				return (this is Input) ? 2 : ((this is Parameter) ? 1 : 0);
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsVarArg
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is VarArg;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsParameter
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is Parameter;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsInput
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is Input;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal OpArg()
		{
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static OpArg<a> NewVarArg(string item1, a[] item2)
		{
			return new VarArg(item1, item2);
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static OpArg<a> NewParameter(FSharpOption<object> item)
		{
			return new Parameter(item);
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static OpArg<a> NewInput(a item)
		{
			return new Input(item);
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ((FSharpFunc<OpArg<OpArg<a>>, string>)(object)ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<OpArg<a>, string>>((PrintfFormat<FSharpFunc<OpArg<a>, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<OpArg<FSharpFunc<OpArg<a>, string>>, string>, Unit, string, string, string>("%+0.8A"))).Invoke((OpArg<OpArg<a>>)(object)this);
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ((FSharpFunc<OpArg<OpArg<a>>, string>)(object)ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<OpArg<a>, string>>((PrintfFormat<FSharpFunc<OpArg<a>, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<OpArg<FSharpFunc<OpArg<a>, string>>, string>, Unit, string, string, OpArg<FSharpFunc<OpArg<a>, string>>>("%+A"))).Invoke((OpArg<OpArg<a>>)(object)this);
		}

		[CompilerGenerated]
		public sealed override int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				int num = 0;
				if (!(this is VarArg))
				{
					if (this is Parameter)
					{
						Parameter parameter = (Parameter)this;
						num = 1;
						return -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<FSharpOption<object>>(comp, parameter.item) + ((num << 6) + (num >> 2)));
					}
					if (this is Input)
					{
						Input input = (Input)this;
						num = 2;
						a item = input.item;
						return -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<a>(comp, item) + ((num << 6) + (num >> 2)));
					}
				}
				VarArg varArg = (VarArg)this;
				num = 0;
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<a[]>(comp, varArg.item2) + ((num << 6) + (num >> 2)));
				return -1640531527 + ((varArg.item1?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
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
				OpArg<a> opArg = obj as OpArg<a>;
				if (opArg != null)
				{
					OpArg<a> opArg2 = opArg;
					int num = (this is Input) ? 2 : ((this is Parameter) ? 1 : 0);
					OpArg<a> opArg3 = opArg2;
					int num2 = (opArg3 is Input) ? 2 : ((opArg3 is Parameter) ? 1 : 0);
					if (num == num2)
					{
						if (!(this is VarArg))
						{
							if (this is Parameter)
							{
								Parameter parameter = (Parameter)this;
								Parameter parameter2 = (Parameter)opArg2;
								return HashCompare.GenericEqualityWithComparerIntrinsic<FSharpOption<object>>(comp, parameter.item, parameter2.item);
							}
							if (this is Input)
							{
								Input input = (Input)this;
								Input input2 = (Input)opArg2;
								a item = input.item;
								a item2 = input2.item;
								return HashCompare.GenericEqualityWithComparerIntrinsic<a>(comp, item, item2);
							}
						}
						VarArg varArg = (VarArg)this;
						VarArg varArg2 = (VarArg)opArg2;
						if (string.Equals(varArg.item1, varArg2.item1))
						{
							return HashCompare.GenericEqualityWithComparerIntrinsic<a[]>(comp, varArg.item2, varArg2.item2);
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
		public sealed override bool Equals(OpArg<a> obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					int num = (this is Input) ? 2 : ((this is Parameter) ? 1 : 0);
					int num2 = (obj is Input) ? 2 : ((obj is Parameter) ? 1 : 0);
					if (num == num2)
					{
						if (!(this is VarArg))
						{
							if (this is Parameter)
							{
								Parameter parameter = (Parameter)this;
								Parameter parameter2 = (Parameter)obj;
								return HashCompare.GenericEqualityERIntrinsic<FSharpOption<object>>(parameter.item, parameter2.item);
							}
							if (this is Input)
							{
								Input input = (Input)this;
								Input input2 = (Input)obj;
								a item = input.item;
								a item2 = input2.item;
								return HashCompare.GenericEqualityERIntrinsic<a>(item, item2);
							}
						}
						VarArg varArg = (VarArg)this;
						VarArg varArg2 = (VarArg)obj;
						if (string.Equals(varArg.item1, varArg2.item1))
						{
							return HashCompare.GenericEqualityERIntrinsic<a[]>(varArg.item2, varArg2.item2);
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
			OpArg<a> opArg = obj as OpArg<a>;
			if (opArg != null)
			{
				return Equals(opArg);
			}
			return false;
		}
	}
}
