using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Core.CompilerServices;
using MXNetSharp.SymbolArgument;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class SymUtil
	{
		[Serializable]
		internal sealed class args_0040505_002D3 : FSharpFunc<Symbol, Symbol>
		{
			public Symbol search;

			public Symbol replacement;

			public FSharpFunc<SymbolOperator, Symbol> loop;

			public FSharpRef<int> count;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal args_0040505_002D3(Symbol search, Symbol replacement, FSharpFunc<SymbolOperator, Symbol> loop, FSharpRef<int> count)
			{
				this.search = search;
				this.replacement = replacement;
				this.loop = loop;
				this.count = count;
			}

			public override Symbol Invoke(Symbol a)
			{
				if (object.ReferenceEquals(search, a))
				{
					Symbol s2 = a;
					count.set_contents(count.get_contents() + 1);
					return replacement;
				}
				SymbolOperator symbolOperator = a as SymbolOperator;
				if (symbolOperator == null)
				{
					return a;
				}
				SymbolOperator s = symbolOperator;
				return loop.Invoke(s);
			}
		}

		[Serializable]
		internal sealed class loop_0040499_002D1 : FSharpFunc<Tuple<string, OpArg<Symbol>>, Tuple<string, OpArg<Symbol>>>
		{
			public Symbol search;

			public Symbol replacement;

			public FSharpFunc<SymbolOperator, Symbol> loop;

			public FSharpRef<int> count;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040499_002D1(Symbol search, Symbol replacement, FSharpFunc<SymbolOperator, Symbol> loop, FSharpRef<int> count)
			{
				this.search = search;
				this.replacement = replacement;
				this.loop = loop;
				this.count = count;
			}

			public override Tuple<string, OpArg<Symbol>> Invoke(Tuple<string, OpArg<Symbol>> a)
			{
				OpArg<Symbol> item = a.Item2;
				if (!(item is OpArg<Symbol>.VarArg))
				{
					if (item is OpArg<Symbol>.Input)
					{
						OpArg<Symbol>.Input input = (OpArg<Symbol>.Input)a.Item2;
						Symbol s4 = input.item;
						string name = a.Item1;
						if (object.ReferenceEquals(search, s4))
						{
							Symbol s3 = input.item;
							string item2 = a.Item1;
							count.set_contents(count.get_contents() + 1);
							return new Tuple<string, OpArg<Symbol>>(item2, OpArg<Symbol>.NewInput(replacement));
						}
					}
					if (a.Item2 is OpArg<Symbol>.Input)
					{
						OpArg<Symbol>.Input input2 = (OpArg<Symbol>.Input)a.Item2;
						SymbolOperator symbolOperator = input2.item as SymbolOperator;
						if (symbolOperator == null)
						{
							SymbolOutput symbolOutput = input2.item as SymbolOutput;
							if (symbolOutput == null)
							{
								return a;
							}
							SymbolOutput s = symbolOutput;
							string item3 = a.Item1;
							if (object.ReferenceEquals(search, s.Parent))
							{
								count.set_contents(count.get_contents() + 1);
								return new Tuple<string, OpArg<Symbol>>(item3, OpArg<Symbol>.NewInput(replacement.Outputs[s.Position]));
							}
							object parent = s.Parent;
							if (parent is SymbolOperator)
							{
								count.set_contents(count.get_contents() + 1);
								return new Tuple<string, OpArg<Symbol>>(item3, OpArg<Symbol>.NewInput(loop.Invoke(IntrinsicFunctions.UnboxGeneric<SymbolOperator>((object)s.Parent)).Outputs[s.Position]));
							}
							return new Tuple<string, OpArg<Symbol>>(item3, OpArg<Symbol>.NewInput(s));
						}
						SymbolOperator s2 = symbolOperator;
						string item4 = a.Item1;
						return new Tuple<string, OpArg<Symbol>>(item4, OpArg<Symbol>.NewInput(loop.Invoke(s2)));
					}
					return a;
				}
				OpArg<Symbol>.VarArg varArg = (OpArg<Symbol>.VarArg)a.Item2;
				string num = varArg.item1;
				string item5 = a.Item1;
				Symbol[] item6 = varArg.item2;
				Symbol[] array = item6;
				FSharpFunc<Symbol, Symbol> val = new args_0040505_002D3(search, replacement, loop, count);
				Symbol[] array2 = array;
				if (array2 == null)
				{
					throw new ArgumentNullException("array");
				}
				Symbol[] array3 = new Symbol[array2.Length];
				for (int i = 0; i < array3.Length; i++)
				{
					array3[i] = val.Invoke(array2[i]);
				}
				Symbol[] args = array3;
				return new Tuple<string, OpArg<Symbol>>(item5, OpArg<Symbol>.NewVarArg(num, args));
			}
		}

		[Serializable]
		internal sealed class loop_0040497 : FSharpFunc<SymbolOperator, Symbol>
		{
			public Symbol search;

			public Symbol replacement;

			public FSharpRef<int> count;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040497(Symbol search, Symbol replacement, FSharpRef<int> count)
			{
				this.search = search;
				this.replacement = replacement;
				this.count = count;
			}

			public override Symbol Invoke(SymbolOperator x)
			{
				Arguments<Symbol> operatorArguments = x.OperatorArguments;
				FSharpFunc<Tuple<string, OpArg<Symbol>>, Tuple<string, OpArg<Symbol>>> val = new loop_0040499_002D1(search, replacement, this, count);
				Arguments<Symbol> arguments = operatorArguments;
				IEnumerable<Tuple<string, OpArg<Symbol>>> enumerable = SeqModule.Map<Tuple<string, OpArg<Symbol>>, Tuple<string, OpArg<Symbol>>>(val, (IEnumerable<Tuple<string, OpArg<Symbol>>>)arguments);
				IEnumerable<Tuple<string, OpArg<Symbol>>> args = enumerable;
				return x.WithArguments(new Arguments<Symbol>(args)).SetName(x);
			}
		}

		[Serializable]
		internal sealed class loop_0040552_002D4<a> : FSharpFunc<Symbol, FSharpOption<a>> where a : Symbol
		{
			public FSharpFunc<SymbolOperator, FSharpOption<a>> loop;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040552_002D4(FSharpFunc<SymbolOperator, FSharpOption<a>> loop)
			{
				this.loop = loop;
			}

			public override FSharpOption<a> Invoke(Symbol a)
			{
				if (!IntrinsicFunctions.TypeTestGeneric<a>((object)a))
				{
					SymbolOperator symbolOperator = a as SymbolOperator;
					if (symbolOperator == null)
					{
						SymbolOutput symbolOutput = a as SymbolOutput;
						if (symbolOutput != null)
						{
							SymbolOutput s = symbolOutput;
							return tryFindType<a>(s.Parent);
						}
						return null;
					}
					SymbolOperator s2 = symbolOperator;
					return ((FSharpFunc<SymbolOperator, FSharpOption<SymbolOperator>>)(object)loop).Invoke(s2);
				}
				a h = (a)a;
				return FSharpOption<a>.Some(h);
			}
		}

		[Serializable]
		internal sealed class loop_0040547_002D3<a> : FSharpFunc<Tuple<string, OpArg<Symbol>>, FSharpOption<a>> where a : Symbol
		{
			public FSharpFunc<SymbolOperator, FSharpOption<a>> loop;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040547_002D3(FSharpFunc<SymbolOperator, FSharpOption<a>> loop)
			{
				this.loop = loop;
			}

			public override FSharpOption<a> Invoke(Tuple<string, OpArg<Symbol>> a)
			{
				OpArg<Symbol> item = a.Item2;
				if (!(item is OpArg<Symbol>.VarArg))
				{
					if (item is OpArg<Symbol>.Input)
					{
						OpArg<Symbol>.Input input = (OpArg<Symbol>.Input)a.Item2;
						if (IntrinsicFunctions.TypeTestGeneric<a>((object)input.item))
						{
							a s = (a)input.item;
							string item2 = a.Item1;
							return FSharpOption<a>.Some(s);
						}
						SymbolOperator symbolOperator = input.item as SymbolOperator;
						if (symbolOperator != null)
						{
							SymbolOperator s3 = symbolOperator;
							string item3 = a.Item1;
							return ((FSharpFunc<SymbolOperator, FSharpOption<SymbolOperator>>)(object)loop).Invoke(s3);
						}
						SymbolOutput symbolOutput = input.item as SymbolOutput;
						if (symbolOutput != null)
						{
							SymbolOutput s2 = symbolOutput;
							string item4 = a.Item1;
							return tryFindType<a>(s2.Parent);
						}
						Tuple<string, OpArg<Symbol>> otherwise = a;
					}
					else
					{
						Tuple<string, OpArg<Symbol>> otherwise = a;
					}
					return null;
				}
				OpArg<Symbol>.VarArg varArg = (OpArg<Symbol>.VarArg)a.Item2;
				string num = varArg.item1;
				string item5 = a.Item1;
				Symbol[] item6 = varArg.item2;
				return ArrayModule.TryPick<Symbol, a>((FSharpFunc<Symbol, FSharpOption<a>>)new loop_0040552_002D4<a>(loop), item6);
			}
		}

		[Serializable]
		internal sealed class loop_0040545_002D2<a> : FSharpFunc<SymbolOperator, FSharpOption<a>> where a : Symbol
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040545_002D2()
			{
			}

			public override FSharpOption<a> Invoke(SymbolOperator x)
			{
				Arguments<Symbol> operatorArguments = x.OperatorArguments;
				FSharpFunc<Tuple<string, OpArg<Symbol>>, FSharpOption<a>> val = new loop_0040547_002D3<a>(this);
				Arguments<Symbol> arguments = operatorArguments;
				return SeqModule.TryPick<Tuple<string, OpArg<Symbol>>, a>(val, (IEnumerable<Tuple<string, OpArg<Symbol>>>)arguments);
			}
		}

		[Serializable]
		internal sealed class loop_0040577_002D7 : FSharpFunc<Symbol, IEnumerable<Symbol>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040577_002D7()
			{
			}

			public override IEnumerable<Symbol> Invoke(Symbol s)
			{
				return symbolArgs(s);
			}
		}

		[Serializable]
		internal sealed class loop_0040574_002D6 : FSharpFunc<Tuple<string, OpArg<Symbol>>, IEnumerable<Symbol>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040574_002D6()
			{
			}

			public override IEnumerable<Symbol> Invoke(Tuple<string, OpArg<Symbol>> a)
			{
				OpArg<Symbol> item = a.Item2;
				if (!(item is OpArg<Symbol>.VarArg))
				{
					if (item is OpArg<Symbol>.Input)
					{
						OpArg<Symbol>.Input input = (OpArg<Symbol>.Input)a.Item2;
						Symbol s = input.item;
						string name2 = a.Item1;
						return symbolArgs(s);
					}
					return SeqModule.Empty<Symbol>();
				}
				OpArg<Symbol>.VarArg varArg = (OpArg<Symbol>.VarArg)a.Item2;
				string num = varArg.item1;
				string name = a.Item1;
				Symbol[] args = varArg.item2;
				Symbol[] array = args;
				FSharpFunc<Symbol, IEnumerable<Symbol>> val = new loop_0040577_002D7();
				Symbol[] array2 = array;
				return SeqModule.Collect<Symbol, IEnumerable<Symbol>, Symbol>(val, (IEnumerable<Symbol>)array2);
			}
		}

		[Serializable]
		internal sealed class loop_0040572_002D5 : FSharpFunc<SymbolOperator, IEnumerable<Symbol>>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040572_002D5()
			{
			}

			public override IEnumerable<Symbol> Invoke(SymbolOperator x)
			{
				Arguments<Symbol> operatorArguments = x.OperatorArguments;
				FSharpFunc<Tuple<string, OpArg<Symbol>>, IEnumerable<Symbol>> val = new loop_0040574_002D6();
				Arguments<Symbol> arguments = operatorArguments;
				return SeqModule.Collect<Tuple<string, OpArg<Symbol>>, IEnumerable<Symbol>, Symbol>(val, (IEnumerable<Tuple<string, OpArg<Symbol>>>)arguments);
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class symbolArgs_0040582 : GeneratedSequenceBase<Symbol>
		{
			public Symbol s = s;

			public FSharpFunc<SymbolOperator, IEnumerable<Symbol>> loop = loop;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int pc = pc;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public Symbol current = current;

			public symbolArgs_0040582(Symbol s, FSharpFunc<SymbolOperator, IEnumerable<Symbol>> loop, int pc, Symbol current)
			{
			}

			public override int GenerateNext(ref IEnumerable<Symbol> next)
			{
				switch (pc)
				{
				default:
				{
					Symbol symbol = this.s;
					pc = 1;
					SymbolOperator symbolOperator = symbol as SymbolOperator;
					IEnumerable<Symbol> enumerable;
					if (symbolOperator != null)
					{
						SymbolOperator o = symbolOperator;
						enumerable = loop.Invoke(o);
					}
					else
					{
						Symbol s = symbol;
						enumerable = SeqModule.Singleton<Symbol>(s);
					}
					next = enumerable;
					return 2;
				}
				case 1:
					pc = 2;
					break;
				case 2:
					break;
				}
				current = null;
				return 0;
			}

			public override void Close()
			{
				pc = 2;
			}

			public override bool get_CheckClose()
			{
				switch (pc)
				{
				default:
					return false;
				case 0:
				case 2:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override Symbol get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<Symbol> GetFreshEnumerator()
			{
				return (IEnumerator<Symbol>)(object)new symbolArgs_0040582(s, loop, 0, null);
			}
		}

		[Serializable]
		internal sealed class initNames_0040590 : FSharpFunc<Symbol, Unit>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal initNames_0040590()
			{
			}

			public override Unit Invoke(Symbol s)
			{
				s.FreezeName();
				return null;
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1,
			1
		})]
		public static FSharpOption<Symbol> tryReplaceSymbol(Symbol search, Symbol replacement, Symbol target)
		{
			SymbolOperator symbolOperator = target as SymbolOperator;
			if (symbolOperator == null)
			{
				SymbolOutput symbolOutput = target as SymbolOutput;
				if (symbolOutput != null)
				{
					SymbolOutput s = symbolOutput;
					FSharpOption<Symbol> val = tryReplaceSymbol(search, replacement, s.Parent);
					if (val != null)
					{
						FSharpOption<Symbol> val2 = val;
						Symbol o = val2.get_Value();
						Symbol symbol = o.Outputs[s.Position];
						Symbol symbol2 = symbol;
						return FSharpOption<Symbol>.Some(symbol2);
					}
					return null;
				}
				return null;
			}
			SymbolOperator s2 = symbolOperator;
			FSharpRef<int> count = new FSharpRef<int>(0);
			FSharpFunc<SymbolOperator, Symbol> loop = new loop_0040497(search, replacement, count);
			Symbol result = loop.Invoke(s2);
			if (count.get_contents() > 0)
			{
				return FSharpOption<Symbol>.Some(result);
			}
			return null;
		}

		public static FSharpOption<a> tryFindType<a>(Symbol symbol) where a : Symbol
		{
			Symbol symbol2;
			while (true)
			{
				symbol2 = symbol;
				SymbolOutput symbolOutput = symbol2 as SymbolOutput;
				if (symbolOutput == null)
				{
					break;
				}
				SymbolOutput s2 = symbolOutput;
				symbol = s2.Parent;
			}
			SymbolOperator symbolOperator = symbol2 as SymbolOperator;
			if (symbolOperator != null)
			{
				SymbolOperator s = symbolOperator;
				FSharpFunc<SymbolOperator, FSharpOption<a>> loop = new loop_0040545_002D2<a>();
				return loop.Invoke(s);
			}
			return null;
		}

		public static IEnumerable<Symbol> symbolArgs(Symbol s)
		{
			FSharpFunc<SymbolOperator, IEnumerable<Symbol>> loop = new loop_0040572_002D5();
			return (IEnumerable<Symbol>)(object)new symbolArgs_0040582(s, loop, 0, null);
		}

		public static void initNames(Symbol symbol)
		{
			SeqModule.Iterate<Symbol>((FSharpFunc<Symbol, Unit>)new initNames_0040590(), symbolArgs(symbol));
		}
	}
}
