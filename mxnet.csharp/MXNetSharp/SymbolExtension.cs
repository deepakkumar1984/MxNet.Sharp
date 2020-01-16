using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Core.CompilerServices;
using MXNetSharp.SymbolArgument;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[AutoOpen]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class SymbolExtension
	{
		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class visited_0040609 : IEqualityComparer<Symbol>
		{
			private bool System_002DCollections_002DGeneric_002DIEqualityComparer_00601_002DEquals(Symbol x, Symbol y)
			{
				return object.ReferenceEquals(x, y);
			}

			bool IEqualityComparer<Symbol>.Equals(Symbol x, Symbol y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in System-Collections-Generic-IEqualityComparer`1-Equals
				return this.System_002DCollections_002DGeneric_002DIEqualityComparer_00601_002DEquals(x, y);
			}

			private int System_002DCollections_002DGeneric_002DIEqualityComparer_00601_002DGetHashCode(Symbol obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}

			int IEqualityComparer<Symbol>.GetHashCode(Symbol obj)
			{
				//ILSpy generated this explicit interface implementation from .override directive in System-Collections-Generic-IEqualityComparer`1-GetHashCode
				return this.System_002DCollections_002DGeneric_002DIEqualityComparer_00601_002DGetHashCode(obj);
			}
		}

		[Serializable]
		[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		internal sealed class loop_0040623_002D13 : GeneratedSequenceBase<Parameter>
		{
			public FSharpFunc<Symbol, IEnumerable<Parameter>> loop = loop;

			public SymbolGroup s = s;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<int> @enum = @enum;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IEnumerator<Parameter> enum0 = enum0;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int pc = pc;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public Parameter current = current;

			public loop_0040623_002D13(FSharpFunc<Symbol, IEnumerable<Parameter>> loop, SymbolGroup s, IEnumerator<int> @enum, IEnumerator<Parameter> enum0, int pc, Parameter current)
			{
			}

			public override int GenerateNext(ref IEnumerable<Parameter> next)
			{
				switch (pc)
				{
				default:
					@enum = OperatorIntrinsics.RangeInt32(0, 1, s.Count - 1).GetEnumerator();
					pc = 1;
					goto IL_0066;
				case 3:
					if (enum0.MoveNext())
					{
						Parameter parameter = enum0.Current;
						pc = 3;
						current = parameter;
						return 1;
					}
					goto case 2;
				case 2:
					pc = 1;
					IntrinsicFunctions.Dispose<IEnumerator<Parameter>>(enum0);
					enum0 = null;
					goto IL_0066;
				case 1:
					pc = 4;
					IntrinsicFunctions.Dispose<IEnumerator<int>>(@enum);
					@enum = null;
					pc = 4;
					break;
				case 4:
					break;
					IL_0066:
					if (@enum.MoveNext())
					{
						int i = @enum.Current;
						enum0 = loop.Invoke(s[i]).GetEnumerator();
						pc = 2;
						goto case 3;
					}
					goto case 1;
				}
				current = null;
				return 0;
			}

			public override void Close()
			{
				Exception ex = null;
				while (true)
				{
					switch (pc)
					{
					default:
						try
						{
							switch (pc)
							{
							default:
								pc = 1;
								IntrinsicFunctions.Dispose<IEnumerator<Parameter>>(enum0);
								goto case 1;
							case 1:
								pc = 4;
								IntrinsicFunctions.Dispose<IEnumerator<int>>(@enum);
								break;
							case 0:
							case 4:
								break;
							}
							pc = 4;
							current = null;
							Unit val = null;
						}
						catch (object obj)
						{
							Exception e = (Exception)obj;
							ex = e;
							Unit val = null;
						}
						break;
					case 4:
						if (ex == null)
						{
							return;
						}
						throw ex;
					}
				}
			}

			public override bool get_CheckClose()
			{
				switch (pc)
				{
				default:
					return true;
				case 2:
					return true;
				case 1:
					return true;
				case 0:
				case 4:
					return false;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override Parameter get_LastGenerated()
			{
				return current;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public override IEnumerator<Parameter> GetFreshEnumerator()
			{
				return (IEnumerator<Parameter>)(object)new loop_0040623_002D13(loop, s, null, null, 0, null);
			}
		}

		[Serializable]
		internal sealed class loop_0040634_002D15 : FSharpFunc<Symbol, IEnumerable<Parameter>>
		{
			public FSharpFunc<Symbol, IEnumerable<Parameter>> loop;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040634_002D15(FSharpFunc<Symbol, IEnumerable<Parameter>> loop)
			{
				this.loop = loop;
			}

			public override IEnumerable<Parameter> Invoke(Symbol a)
			{
				SymbolOperator symbolOperator = a as SymbolOperator;
				if (symbolOperator == null)
				{
					SymbolOutput symbolOutput = a as SymbolOutput;
					if (symbolOutput == null)
					{
						Parameter parameter = a as Parameter;
						if (parameter != null)
						{
							Parameter p = parameter;
							return SeqModule.Singleton<Parameter>(p);
						}
						return SeqModule.Empty<Parameter>();
					}
					SymbolOutput s = symbolOutput;
					return loop.Invoke(s.Parent);
				}
				SymbolOperator s2 = symbolOperator;
				FSharpFunc<Symbol, IEnumerable<Parameter>> val = loop;
				SymbolOperator symbolOperator2 = s2;
				return val.Invoke((Symbol)symbolOperator2);
			}
		}

		[Serializable]
		internal sealed class loop_0040629_002D14 : FSharpFunc<Tuple<string, OpArg<Symbol>>, IEnumerable<Parameter>>
		{
			public FSharpFunc<Symbol, IEnumerable<Parameter>> loop;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040629_002D14(FSharpFunc<Symbol, IEnumerable<Parameter>> loop)
			{
				this.loop = loop;
			}

			public override IEnumerable<Parameter> Invoke(Tuple<string, OpArg<Symbol>> a)
			{
				OpArg<Symbol> item = a.Item2;
				if (!(item is OpArg<Symbol>.VarArg))
				{
					if (item is OpArg<Symbol>.Input)
					{
						OpArg<Symbol>.Input input = (OpArg<Symbol>.Input)a.Item2;
						SymbolOperator symbolOperator = input.item as SymbolOperator;
						if (symbolOperator != null)
						{
							SymbolOperator s3 = symbolOperator;
							string item2 = a.Item1;
							FSharpFunc<Symbol, IEnumerable<Parameter>> val = loop;
							SymbolOperator symbolOperator2 = s3;
							return val.Invoke((Symbol)symbolOperator2);
						}
						SymbolOutput symbolOutput = input.item as SymbolOutput;
						if (symbolOutput != null)
						{
							SymbolOutput s2 = symbolOutput;
							string item3 = a.Item1;
							return loop.Invoke(s2.Parent);
						}
						Parameter parameter = input.item as Parameter;
						if (parameter != null)
						{
							Parameter s = parameter;
							string item4 = a.Item1;
							return SeqModule.Singleton<Parameter>(s);
						}
						Tuple<string, OpArg<Symbol>> otherwise = a;
					}
					else
					{
						Tuple<string, OpArg<Symbol>> otherwise = a;
					}
					return SeqModule.Empty<Parameter>();
				}
				OpArg<Symbol>.VarArg varArg = (OpArg<Symbol>.VarArg)a.Item2;
				string num = varArg.item1;
				string item5 = a.Item1;
				Symbol[] item6 = varArg.item2;
				Symbol[] array = item6;
				FSharpFunc<Symbol, IEnumerable<Parameter>> val2 = new loop_0040634_002D15(loop);
				Symbol[] array2 = array;
				return SeqModule.Collect<Symbol, IEnumerable<Parameter>, Parameter>(val2, (IEnumerable<Symbol>)array2);
			}
		}

		[Serializable]
		internal sealed class loop_0040615_002D12 : FSharpFunc<Symbol, IEnumerable<Parameter>>
		{
			public HashSet<Symbol> visited;

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal loop_0040615_002D12(HashSet<Symbol> visited)
			{
				this.visited = visited;
			}

			public override IEnumerable<Parameter> Invoke(Symbol symbol)
			{
				Parameter parameter;
				while (true)
				{
					if (!visited.Add(symbol))
					{
						return SeqModule.Empty<Parameter>();
					}
					Symbol symbol2 = symbol;
					parameter = (symbol2 as Parameter);
					if (parameter != null)
					{
						break;
					}
					SymbolOutput symbolOutput = symbol2 as SymbolOutput;
					if (symbolOutput == null)
					{
						SymbolGroup symbolGroup = symbol2 as SymbolGroup;
						if (symbolGroup == null)
						{
							SymbolOperator symbolOperator = symbol2 as SymbolOperator;
							if (symbolOperator != null)
							{
								SymbolOperator s = symbolOperator;
								Arguments<Symbol> operatorArguments = s.OperatorArguments;
								FSharpFunc<Tuple<string, OpArg<Symbol>>, IEnumerable<Parameter>> val = new loop_0040629_002D14(this);
								Arguments<Symbol> arguments = operatorArguments;
								return SeqModule.Collect<Tuple<string, OpArg<Symbol>>, IEnumerable<Parameter>, Parameter>(val, (IEnumerable<Tuple<string, OpArg<Symbol>>>)arguments);
							}
							return SeqModule.Empty<Parameter>();
						}
						SymbolGroup s2 = symbolGroup;
						return (IEnumerable<Parameter>)(object)new loop_0040623_002D13(this, s2, null, null, 0, null);
					}
					SymbolOutput s3 = symbolOutput;
					symbol = s3.Parent;
				}
				Parameter p = parameter;
				return SeqModule.Singleton<Parameter>(p);
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			0
		})]
		public static Bindings Symbol_002Eget_Bindings(Symbol P_0)
		{
			HashSet<Symbol> visited = new HashSet<Symbol>(new visited_0040609());
			FSharpFunc<Symbol, IEnumerable<Parameter>> loop = new loop_0040615_002D12(visited);
			IEnumerable<Parameter> enumerable = loop.Invoke(P_0);
			IEnumerable<Parameter> enumerable2 = enumerable;
			return BindingsModule.inputs(SeqModule.Cast<Variable>((IEnumerable)enumerable2));
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			3
		})]
		public static Executor Symbol_002EBind(Symbol x, Context context, int batchSize, IEnumerable<Bind> bindings)
		{
			Bindings bindmap = BindingsModule.inferShapes(x, BindingsModule.batchSize(batchSize, Symbol_002Eget_Bindings(x).WithBindings(bindings)));
			return new Executor(x, context, bindmap);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			2
		})]
		public static Executor Symbol_002EBind(Symbol x, Context context, IEnumerable<Bind> bindings)
		{
			Bindings bindmap = BindingsModule.inferShapes(x, Symbol_002Eget_Bindings(x).WithBindings(bindings));
			return new Executor(x, context, bindmap);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			2
		})]
		public static Executor Symbol_002EBind(Symbol x, Context context, int batchSize)
		{
			Bindings bindmap = BindingsModule.inferShapes(x, BindingsModule.batchSize(batchSize, Symbol_002Eget_Bindings(x)));
			return new Executor(x, context, bindmap);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Executor Symbol_002EBind(Symbol x, Context context)
		{
			Bindings bindmap = BindingsModule.inferShapes(x, Symbol_002Eget_Bindings(x));
			return new Executor(x, context, bindmap);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Executor Symbol_002EEval(Symbol x, Context context)
		{
			Executor exe = Symbol_002EBind(x, context);
			exe.Forward(isTraining: false);
			return exe;
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			2
		})]
		public static Executor Symbol_002EEval(Symbol x, Context context, Bindings bindings)
		{
			Executor exe = Symbol_002EBind(x, context, bindings);
			exe.Forward(isTraining: false);
			return exe;
		}
	}
}
