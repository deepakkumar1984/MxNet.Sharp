using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Core.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class BindingsModule
	{
		[Serializable]
		internal sealed class mapAux_0040314 : FSharpFunc<Bind, Tuple<string, Bind>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal mapAux_0040314()
			{
			}

			public override Tuple<string, Bind> Invoke(Bind x)
			{
				return new Tuple<string, Bind>(x.Name, x);
			}
		}

		[Serializable]
		internal sealed class mapAux_0040310_002D1 : FSharpFunc<Bind, Bind>
		{
			public FSharpFunc<AuxBind, AuxBind> f;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal mapAux_0040310_002D1(FSharpFunc<AuxBind, AuxBind> f)
			{
				this.f = f;
			}

			public override Bind Invoke(Bind _arg1)
			{
				if (!(_arg1 is Bind.AuxBinding))
				{
					return _arg1;
				}
				Bind.AuxBinding auxBinding = (Bind.AuxBinding)_arg1;
				AuxBind a = auxBinding.item;
				return Bind.NewAuxBinding(f.Invoke(a));
			}
		}

		[Serializable]
		internal sealed class mapArg_0040325 : FSharpFunc<Bind, Tuple<string, Bind>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal mapArg_0040325()
			{
			}

			public override Tuple<string, Bind> Invoke(Bind x)
			{
				return new Tuple<string, Bind>(x.Name, x);
			}
		}

		[Serializable]
		internal sealed class mapArg_0040321_002D1 : FSharpFunc<Bind, Bind>
		{
			public FSharpFunc<ArgBind, ArgBind> f;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal mapArg_0040321_002D1(FSharpFunc<ArgBind, ArgBind> f)
			{
				this.f = f;
			}

			public override Bind Invoke(Bind _arg1)
			{
				if (!(_arg1 is Bind.ArgBinding))
				{
					return _arg1;
				}
				Bind.ArgBinding argBinding = (Bind.ArgBinding)_arg1;
				ArgBind a = argBinding.item;
				return Bind.NewArgBinding(f.Invoke(a));
			}
		}

		[Serializable]
		internal sealed class map_0040332 : FSharpFunc<Bind, Tuple<string, Bind>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal map_0040332()
			{
			}

			public override Tuple<string, Bind> Invoke(Bind x)
			{
				return new Tuple<string, Bind>(x.Name, x);
			}
		}

		[Serializable]
		internal sealed class mapSymbolArgs_0040344 : FSharpFunc<ArgBind, ArgBind>
		{
			public FSharpFunc<ArgBind, ArgBind> f;

			public FSharpSet<string> argNames;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal mapSymbolArgs_0040344(FSharpFunc<ArgBind, ArgBind> f, FSharpSet<string> argNames)
			{
				this.f = f;
				this.argNames = argNames;
			}

			public override ArgBind Invoke(ArgBind a)
			{
				if (argNames.Contains(a.Name_0040))
				{
					return f.Invoke(a);
				}
				return a;
			}
		}

		[Serializable]
		internal sealed class freezeGraph_0040352 : FSharpFunc<ArgBind, ArgBind>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal freezeGraph_0040352()
			{
			}

			public override ArgBind Invoke(ArgBind a)
			{
				return new ArgBind(a.Name_0040, a.NDArray_0040, a.Grad_0040, FSharpOption<OpReqType>.Some(OpReqType.NullOp), a.Shape_0040, a.DataType_0040, a.StorageType_0040);
			}
		}

		[Serializable]
		internal sealed class inputs_0040356_002D2 : FSharpFunc<Variable, Bind>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal inputs_0040356_002D2()
			{
			}

			public override Bind Invoke(Variable v)
			{
				return BindModule.fromVariable(v);
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class batchSize_0040365_002D1 : GeneratedSequenceBase<int>
		{
			public int batchSize = batchSize;

			public int[] a = a;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int pc = pc;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int current = current;

			public batchSize_0040365_002D1(int batchSize, int[] a, int pc, int current)
			{
			}

			public override int GenerateNext(ref IEnumerable<int> next)
			{
				int[] array;
				FSharpOption<int> val;
				FSharpOption<int> val2;
				int num;
				Tuple<int, int> tuple;
				Tuple<int, int> tuple2;
				int item;
				int item2;
				int num2;
				int num3;
				int[] array2;
				int num4;
				int num5;
				switch (pc)
				{
				default:
					pc = 1;
					current = batchSize;
					return 1;
				case 1:
					pc = 2;
					array = a;
					val = FSharpOption<int>.Some(1);
					val2 = null;
					num = array.Length;
					if (val != null)
					{
						goto IL_00a3;
					}
					if (val2 != null)
					{
						FSharpOption<int> val3 = val2;
						if (val3.get_Value() < 0)
						{
							goto IL_00a3;
						}
						int value = val3.get_Value();
						tuple = new Tuple<int, int>(0, value);
					}
					else
					{
						tuple = new Tuple<int, int>(0, 0 + num - 1);
					}
					goto IL_010a;
				case 2:
					pc = 3;
					break;
				case 3:
					break;
					IL_010a:
					tuple2 = tuple;
					item = tuple2.Item1;
					item2 = tuple2.Item2;
					num2 = item2 - item + 1;
					num3 = ((num2 >= 0) ? num2 : 0);
					array2 = new int[num3];
					num4 = 0;
					num5 = num3 - 1;
					if (num5 >= num4)
					{
						do
						{
							array2[num4] = array[item + num4];
							num4++;
						}
						while (num4 != num5 + 1);
					}
					next = array2;
					return 2;
					IL_00a3:
					if (val != null)
					{
						FSharpOption<int> val4 = val;
						if (val2 == null && val4.get_Value() <= 0 + num)
						{
							int value2 = val4.get_Value();
							tuple = new Tuple<int, int>(value2, 0 + num - 1);
							goto IL_010a;
						}
					}
					if (val != null)
					{
						FSharpOption<int> val5 = val;
						if (val2 != null)
						{
							FSharpOption<int> val6 = val2;
							int value3 = val6.get_Value();
							int value4 = val5.get_Value();
							tuple = new Tuple<int, int>(value4, value3);
							goto IL_010a;
						}
					}
					throw new IndexOutOfRangeException();
				}
				current = 0;
				return 0;
			}

			public override void Close()
			{
				pc = 3;
			}

			public override bool get_CheckClose()
			{
				switch (pc)
				{
				default:
					return false;
				case 1:
					return false;
				case 0:
				case 3:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override int get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<int> GetFreshEnumerator()
			{
				return (IEnumerator<int>)(object)new batchSize_0040365_002D1(batchSize, a, 0, 0);
			}
		}

		[Serializable]
		internal sealed class batchSize_0040362 : FSharpFunc<Bind, Bind>
		{
			public int batchSize;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal batchSize_0040362(int batchSize)
			{
				this.batchSize = batchSize;
			}

			public override Bind Invoke(Bind x)
			{
				FSharpOption<int[]> shape = x.Shape;
				if (shape != null)
				{
					FSharpOption<int[]> val = shape;
					int[] a2 = val.get_Value();
					if (a2.Length > 0 && a2[0] == 0)
					{
						int[] a = val.get_Value();
						return x.WithShape((IEnumerable<int>)SeqModule.ToList<int>((IEnumerable<int>)(object)new batchSize_0040365_002D1(batchSize, a, 0, 0)));
					}
				}
				return x;
			}
		}

		[Serializable]
		internal sealed class defaultOpReqType_0040373 : FSharpFunc<ArgBind, ArgBind>
		{
			public OpReqType opReqType;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal defaultOpReqType_0040373(OpReqType opReqType)
			{
				this.opReqType = opReqType;
			}

			public override ArgBind Invoke(ArgBind a)
			{
				if (a.OpReqType_0040 == null)
				{
					return new ArgBind(a.Name_0040, a.NDArray_0040, a.Grad_0040, FSharpOption<OpReqType>.Some(opReqType), a.Shape_0040, a.DataType_0040, a.StorageType_0040);
				}
				return a;
			}
		}

		[Serializable]
		internal sealed class fillNDArray_0040394_002D3 : FSharpFunc<int[], string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public FSharpFunc<int[], string> clo3;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal fillNDArray_0040394_002D3(FSharpFunc<int[], string> clo3)
			{
				this.clo3 = clo3;
			}

			public override string Invoke(int[] arg30)
			{
				return clo3.Invoke(arg30);
			}
		}

		[Serializable]
		internal sealed class fillNDArray_0040394_002D2 : FSharpFunc<string, FSharpFunc<int[], string>>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public FSharpFunc<string, FSharpFunc<int[], string>> clo2;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal fillNDArray_0040394_002D2(FSharpFunc<string, FSharpFunc<int[], string>> clo2)
			{
				this.clo2 = clo2;
			}

			public override FSharpFunc<int[], string> Invoke(string arg20)
			{
				FSharpFunc<int[], string> clo = clo2.Invoke(arg20);
				return new fillNDArray_0040394_002D3(clo);
			}
		}

		[Serializable]
		internal sealed class fillNDArray_0040394_002D1 : FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>> clo1;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal fillNDArray_0040394_002D1(FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>> clo1)
			{
				this.clo1 = clo1;
			}

			public override FSharpFunc<string, FSharpFunc<int[], string>> Invoke(int[] arg10)
			{
				FSharpFunc<string, FSharpFunc<int[], string>> clo = clo1.Invoke(arg10);
				return new fillNDArray_0040394_002D2(clo);
			}
		}

		[Serializable]
		internal sealed class fillNDArray_0040398_002D6 : FSharpFunc<int[], string>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public FSharpFunc<int[], string> clo3;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal fillNDArray_0040398_002D6(FSharpFunc<int[], string> clo3)
			{
				this.clo3 = clo3;
			}

			public override string Invoke(int[] arg30)
			{
				return clo3.Invoke(arg30);
			}
		}

		[Serializable]
		internal sealed class fillNDArray_0040398_002D5 : FSharpFunc<string, FSharpFunc<int[], string>>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public FSharpFunc<string, FSharpFunc<int[], string>> clo2;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal fillNDArray_0040398_002D5(FSharpFunc<string, FSharpFunc<int[], string>> clo2)
			{
				this.clo2 = clo2;
			}

			public override FSharpFunc<int[], string> Invoke(string arg20)
			{
				FSharpFunc<int[], string> clo = clo2.Invoke(arg20);
				return new fillNDArray_0040398_002D6(clo);
			}
		}

		[Serializable]
		internal sealed class fillNDArray_0040398_002D4 : FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>> clo1;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal fillNDArray_0040398_002D4(FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>> clo1)
			{
				this.clo1 = clo1;
			}

			public override FSharpFunc<string, FSharpFunc<int[], string>> Invoke(int[] arg10)
			{
				FSharpFunc<string, FSharpFunc<int[], string>> clo = clo1.Invoke(arg10);
				return new fillNDArray_0040398_002D5(clo);
			}
		}

		[Serializable]
		internal sealed class fillNDArray_0040382 : FSharpFunc<Bind, Bind>
		{
			public FSharpFunc<Bind, NDArray> f;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal fillNDArray_0040382(FSharpFunc<Bind, NDArray> f)
			{
				this.f = f;
			}

			public override Bind Invoke(Bind a)
			{
				//IL_0167: Unknown result type (might be due to invalid IL or missing references)
				if (a.NDArray == null)
				{
					NDArray nd = f.Invoke(a);
					FSharpOption<int[]> shape = a.Shape;
					if (shape != null)
					{
						FSharpOption<int[]> val = shape;
						int[] s3 = val.get_Value();
						if (HashCompare.GenericEqualityIntrinsic<int[]>(s3, nd.Shape))
						{
							int[] s2 = val.get_Value();
							return a.WithNDArray(nd);
						}
						if (shape != null)
						{
							FSharpOption<int[]> val2 = shape;
							int[] s = val2.get_Value();
							int[] nds = nd.Shape;
							if (s.Length == 0)
							{
								return a.WithNDArray(nd).WithShape(nds);
							}
							if (s.Length != nds.Length)
							{
								FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>>((PrintfFormat<FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>, Unit, string, string, Tuple<int[], string, int[]>>("Given NDArray shape %A does not match binding %s shape %A"));
								throw new RankException(FSharpFunc<int[], string>.InvokeFast<int[], string>((FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>)new fillNDArray_0040394_002D1(clo), nds, a.Name, s));
							}
							for (int i = 0; i < s.Length; i++)
							{
								if (s[i] > 0 && s[i] != nds[i])
								{
									FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>> clo2 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>>((PrintfFormat<FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>, Unit, string, string, Tuple<int[], string, int[]>>("Given NDArray shape %A does not match binding %s shape %A"));
									throw new RankException(FSharpFunc<int[], string>.InvokeFast<int[], string>((FSharpFunc<int[], FSharpFunc<string, FSharpFunc<int[], string>>>)new fillNDArray_0040398_002D4(clo2), nds, a.Name, s));
								}
							}
							return a.WithNDArray(nd).WithShape(nds);
						}
						throw new MatchFailureException("C:\\git\\MXNetSharp\\MXNetSharp\\executor.fs", 386, 26);
					}
					return a.WithNDArray(nd).WithShape(nd.Shape);
				}
				return a;
			}
		}

		[Serializable]
		internal sealed class init_0040412 : FSharpFunc<Bind, Bind>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal init_0040412()
			{
			}

			public override Bind Invoke(Bind a)
			{
				if (a is Bind.ArgBinding)
				{
					Bind.ArgBinding argBinding = (Bind.ArgBinding)a;
					ArgBind b2 = argBinding.item;
					if (FSharpOption<NDArray>.get_IsNone(b2.Grad_0040))
					{
						ArgBind b = argBinding.item;
						ArgBind argBind = b;
						return Bind.NewArgBinding(new ArgBind(argBind.Name_0040, argBind.NDArray_0040, FSharpOption<NDArray>.Some(MX.ZerosLike(a.NDArray.get_Value())), argBind.OpReqType_0040, argBind.Shape_0040, argBind.DataType_0040, argBind.StorageType_0040));
					}
				}
				return a;
			}
		}

		[Serializable]
		internal sealed class init_0040407_002D1 : FSharpFunc<Bind, NDArray>
		{
			public FSharpFunc<Bind, FSharpFunc<int[], NDArray>> f;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal init_0040407_002D1(FSharpFunc<Bind, FSharpFunc<int[], NDArray>> f)
			{
				this.f = f;
			}

			public override NDArray Invoke(Bind x)
			{
				FSharpOption<int[]> shape2 = x.Shape;
				int[] array;
				if (shape2 != null)
				{
					FSharpOption<int[]> val = shape2;
					int[] s = val.get_Value();
					array = s;
				}
				else
				{
					array = ArrayModule.Empty<int>();
				}
				int[] shape = array;
				return FSharpFunc<Bind, int[]>.InvokeFast<NDArray>(f, x, shape);
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings mapAux(FSharpFunc<AuxBind, AuxBind> f, Bindings bm)
		{
			mapAux_0040314 mapAux_0040 = new mapAux_0040314();
			FSharpFunc<Bind, Bind> val = new mapAux_0040310_002D1(f);
			IDictionary<string, Bind> dictionary = ExtraTopLevelOperators.CreateDictionary<string, Bind>(SeqModule.Map<Bind, Tuple<string, Bind>>((FSharpFunc<Bind, Tuple<string, Bind>>)mapAux_0040, SeqModule.Map<Bind, Bind>(val, (IEnumerable<Bind>)bm)));
			IDictionary<string, Bind> bindings = dictionary;
			return new Bindings(bindings);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings mapArg(FSharpFunc<ArgBind, ArgBind> f, Bindings bm)
		{
			mapArg_0040325 mapArg_0040 = new mapArg_0040325();
			FSharpFunc<Bind, Bind> val = new mapArg_0040321_002D1(f);
			IDictionary<string, Bind> dictionary = ExtraTopLevelOperators.CreateDictionary<string, Bind>(SeqModule.Map<Bind, Tuple<string, Bind>>((FSharpFunc<Bind, Tuple<string, Bind>>)mapArg_0040, SeqModule.Map<Bind, Bind>(val, (IEnumerable<Bind>)bm)));
			IDictionary<string, Bind> bindings = dictionary;
			return new Bindings(bindings);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings map(FSharpFunc<Bind, Bind> f, Bindings bm)
		{
			IDictionary<string, Bind> dictionary = ExtraTopLevelOperators.CreateDictionary<string, Bind>(SeqModule.Map<Bind, Tuple<string, Bind>>((FSharpFunc<Bind, Tuple<string, Bind>>)new map_0040332(), SeqModule.Map<Bind, Bind>(f, (IEnumerable<Bind>)bm)));
			IDictionary<string, Bind> bindings = dictionary;
			return new Bindings(bindings);
		}

		public static Bindings ofSeq(IEnumerable<Bind> l)
		{
			return new Bindings().WithBindings(l);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings inferShapes(Symbol s, Bindings bm)
		{
			return bm.InferShapes(s);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static Bindings mapSymbolArgs(Symbol symbol, FSharpFunc<ArgBind, ArgBind> f, Bindings bm)
		{
			string[] argumentNames = symbol.ArgumentNames;
			string[] array = argumentNames;
			FSharpSet<string> argNames = SetModule.OfSeq<string>((IEnumerable<string>)array);
			return mapArg(new mapSymbolArgs_0040344(f, argNames), bm);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings freezeGraph(Symbol symbol, Bindings bm)
		{
			return mapSymbolArgs(symbol, new freezeGraph_0040352(), bm);
		}

		public static Bindings inputs(IEnumerable<Variable> variables)
		{
			return ofSeq(SeqModule.Map<Variable, Bind>((FSharpFunc<Variable, Bind>)new inputs_0040356_002D2(), variables));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings batchSize(int batchSize, Bindings bm)
		{
			FSharpFunc<Bind, Bind> val = new batchSize_0040362(batchSize);
			return ofSeq(SeqModule.Map<Bind, Bind>(val, (IEnumerable<Bind>)bm));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings defaultOpReqType(OpReqType opReqType, Bindings bm)
		{
			return mapArg(new defaultOpReqType_0040373(opReqType), bm);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings fillNDArray(FSharpFunc<Bind, NDArray> f, Bindings bm)
		{
			return map(new fillNDArray_0040382(f), bm);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Bindings init(FSharpFunc<Bind, FSharpFunc<int[], NDArray>> f, Bindings bm)
		{
			return map(new init_0040412(), fillNDArray(new init_0040407_002D1(f), defaultOpReqType(OpReqType.WriteTo, bm)));
		}
	}
}
