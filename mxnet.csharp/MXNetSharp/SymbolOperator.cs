#define DEBUG
using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using MXNetSharp.SymbolArgument;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SymbolOperator : Symbol, ISymbolComposable
	{
		internal Arguments<Symbol> operatorArguments;

		internal AtomicSymbolCreator creator;

		internal AtomicSymbolCreator AtomicSymbolCreator => creator;

		public Arguments<Symbol> OperatorArguments => operatorArguments;

		public override Symbol[] InputSymbols
		{
			get
			{
				string[] args = ArgumentNames;
				Symbol[] inputs = base.InputSymbols;
				Dictionary<string, Symbol> d = new Dictionary<string, Symbol>();
				Arguments<Symbol> arguments = OperatorArguments;
				FSharpFunc<Tuple<string, OpArg<Symbol>>, Unit> val = new _0024Symbol.get_InputSymbols_0040374_002D1(d);
				Arguments<Symbol> arguments2 = arguments;
				SeqModule.Iterate<Tuple<string, OpArg<Symbol>>>(val, (IEnumerable<Tuple<string, OpArg<Symbol>>>)arguments2);
				return ArrayModule.MapIndexed<string, Symbol>((FSharpFunc<int, FSharpFunc<string, Symbol>>)(object)new _0024Symbol.get_InputSymbols_0040390_002D5(inputs, d), args);
			}
		}

		public SymbolOperator(AtomicSymbolCreator creator, Arguments<Symbol> operatorArguments)
		{
			this.creator = creator;
			this.operatorArguments = operatorArguments;
		}

		public SymbolOperator(string name, Arguments<Symbol> args)
			: this(AtomicSymbolCreator.FromName(name), args)
		{
		}

		public override string ToString()
		{
			FSharpFunc<string, FSharpFunc<string, string>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<string, string>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string, Tuple<string, string>>("%s(%s)"));
			_0024Symbol.ToString_0040342 toString_0040 = new _0024Symbol.ToString_0040342(clo);
			string name = GetType().Name;
			Arguments<Symbol> arguments = operatorArguments;
			FSharpFunc<Tuple<string, OpArg<Symbol>>, FSharpOption<string>> val = new _0024Symbol.ToString_0040345_002D2();
			Arguments<Symbol> arguments2 = arguments;
			return FSharpFunc<string, string>.InvokeFast<string>((FSharpFunc<string, FSharpFunc<string, string>>)toString_0040, name, StringModule.Concat(", ", SeqModule.Choose<Tuple<string, OpArg<Symbol>>, string>(val, (IEnumerable<Tuple<string, OpArg<Symbol>>>)arguments2)));
		}

		public override Symbol Copy()
		{
			Arguments<Symbol> arguments = OperatorArguments;
			FSharpFunc<Tuple<string, OpArg<Symbol>>, Tuple<string, OpArg<Symbol>>> val = new _0024Symbol.Copy_0040359();
			Arguments<Symbol> arguments2 = arguments;
			IEnumerable<Tuple<string, OpArg<Symbol>>> enumerable = SeqModule.Map<Tuple<string, OpArg<Symbol>>, Tuple<string, OpArg<Symbol>>>(val, (IEnumerable<Tuple<string, OpArg<Symbol>>>)arguments2);
			IEnumerable<Tuple<string, OpArg<Symbol>>> args = enumerable;
			return WithArguments(new Arguments<Symbol>(args)).SetName(Name);
		}

		public override Symbol WithArguments(Arguments<Symbol> args)
		{
			return new SymbolOperator(creator, args);
		}

		public override Symbol ComposedWith(Symbol symbol)
		{
			FSharpRef<bool> inserted = new FSharpRef<bool>(false);
			Arguments<Symbol> arguments = operatorArguments;
			FSharpFunc<Tuple<string, OpArg<Symbol>>, Tuple<string, OpArg<Symbol>>> val = new _0024Symbol.args_0040406_002D1(symbol, inserted);
			Arguments<Symbol> arguments2 = arguments;
			Tuple<string, OpArg<Symbol>>[] args = SeqModule.ToArray<Tuple<string, OpArg<Symbol>>>(SeqModule.Map<Tuple<string, OpArg<Symbol>>, Tuple<string, OpArg<Symbol>>>(val, (IEnumerable<Tuple<string, OpArg<Symbol>>>)arguments2));
			if (inserted.get_contents())
			{
				return WithArguments(new Arguments<Symbol>(args)).SetName(this);
			}
			FSharpFunc<SymbolOperator, FSharpFunc<Symbol, Symbol>> clo = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<SymbolOperator, FSharpFunc<Symbol, Symbol>>, Symbol>((PrintfFormat<FSharpFunc<SymbolOperator, FSharpFunc<Symbol, Symbol>>, Unit, string, Symbol>)(object)new PrintfFormat<FSharpFunc<SymbolOperator, FSharpFunc<Symbol, Symbol>>, Unit, string, Symbol, Tuple<SymbolOperator, Symbol>>("Could not compose %O with %O"));
			return FSharpFunc<SymbolOperator, Symbol>.InvokeFast<Symbol>((FSharpFunc<SymbolOperator, FSharpFunc<Symbol, Symbol>>)new _0024Symbol.ComposedWith_0040421(clo), this, symbol);
		}

		public override void Initialize()
		{
			FSharpOption<SafeSymbolHandle> internalHandle = InternalHandle;
			if (internalHandle != null)
			{
				FSharpOption<SafeSymbolHandle> val = internalHandle;
			}
			else
			{
				try
				{
					List<string> inputKeys = new List<string>();
					List<Symbol> inputValues = new List<Symbol>();
					List<string> pKeys = new List<string>();
					List<string> pValues = new List<string>();
					string name = Operators.DefaultArg<string>(InternalName, GeneratedName);
					ArgumentInfo[] arguments_0040 = creator.Info.Arguments_0040;
					foreach (ArgumentInfo a in arguments_0040)
					{
						OpArg<Symbol> value = null;
						Tuple<bool, OpArg<Symbol>> tuple = new Tuple<bool, OpArg<Symbol>>(operatorArguments.Args.TryGetValue(a.Name_0040, out value), value);
						OpArg<Symbol> v3 = tuple.Item2;
						if (tuple.Item1)
						{
							OpArg<Symbol> opArg = v3;
							OpArg<Symbol> opArg2 = opArg;
							if (!(opArg2 is OpArg<Symbol>.VarArg))
							{
								if (opArg2 is OpArg<Symbol>.Parameter)
								{
									OpArg<Symbol>.Parameter parameter = (OpArg<Symbol>.Parameter)opArg;
									if (parameter.item != null)
									{
										object o = parameter.item.get_Value();
										pKeys.Add(a.Name_0040);
										pValues.Add(ValueStringExtensions.ValueString(o));
									}
								}
								else
								{
									Symbol k = ((OpArg<Symbol>.Input)opArg).item;
									inputKeys.Add(a.Name_0040);
									Symbol symbol2 = k;
									ImplicitVariable implicitVariable = symbol2 as ImplicitVariable;
									if (implicitVariable != null)
									{
										ImplicitVariable v2 = implicitVariable;
										if (!v2.IsInitialized)
										{
											ImplicitVariable v = implicitVariable;
											FSharpFunc<string, FSharpFunc<string, string>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<string, string>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string, Tuple<string, string>>("%s_%s"));
											v.Name = FSharpFunc<string, string>.InvokeFast<string>((FSharpFunc<string, FSharpFunc<string, string>>)new _0024Symbol.Initialize_0040440(clo), name, a.Name_0040);
										}
									}
									inputValues.Add(k);
								}
							}
							else
							{
								OpArg<Symbol>.VarArg varArg = (OpArg<Symbol>.VarArg)opArg;
								Symbol[] j = varArg.item2;
								string item = varArg.item1;
								inputValues.AddRange(j);
								pKeys.Add(item);
								pValues.Add(ValueStringExtensions.ValueString(inputValues.Count));
							}
						}
						else
						{
							string typeInfo_0040 = a.TypeInfo_0040;
							if (string.Equals(typeInfo_0040, "NDArray-or-Symbol") || string.Equals(typeInfo_0040, "Symbol"))
							{
								inputKeys.Add(a.Name_0040);
								ImplicitVariable i = new ImplicitVariable();
								FSharpFunc<string, FSharpFunc<string, string>> clo2 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<string, string>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string, Tuple<string, string>>("%s_%s"));
								i.Name = FSharpFunc<string, string>.InvokeFast<string>((FSharpFunc<string, FSharpFunc<string, string>>)new _0024Symbol.Initialize_0040457_002D2(clo2), name, a.Name_0040);
								inputValues.Add(i);
							}
						}
					}
					string[] keys2 = pKeys.ToArray();
					string[] vals = pValues.ToArray();
					Debug.Assert(keys2.Length == vals.Length);
					IntPtr symbol = MXSymbol.createAtomicSymbol(creator.AtomicSymbolCreatorHandle, keys2, vals);
					List<Symbol> list = inputValues;
					FSharpFunc<Symbol, IntPtr> val2 = new _0024Symbol.ivals_0040465();
					List<Symbol> list2 = list;
					IntPtr[] ivals = SeqModule.ToArray<IntPtr>(SeqModule.Map<Symbol, IntPtr>(val2, (IEnumerable<Symbol>)list2));
					if (inputKeys.Count != inputValues.Count)
					{
						MXSymbol.compose(symbol, name, null, ivals);
					}
					else
					{
						string[] keys = inputKeys.ToArray();
						Tuple<string[], IntPtr[]> tuple2 = ArrayModule.Unzip<string, IntPtr>(SeqModule.ToArray<Tuple<string, IntPtr>>(SeqModule.Map<Tuple<string, Symbol>, Tuple<string, IntPtr>>((FSharpFunc<Tuple<string, Symbol>, Tuple<string, IntPtr>>)new _0024Symbol.Initialize_0040477_002D4(), SeqModule.Filter<Tuple<string, Symbol>>((FSharpFunc<Tuple<string, Symbol>, bool>)new _0024Symbol.Initialize_0040472_002D5(), SeqModule.Zip<string, Symbol>((IEnumerable<string>)keys, (IEnumerable<Symbol>)inputValues)))));
						MXSymbol.compose(symbol, name, tuple2.Item1, tuple2.Item2);
					}
					InternalHandle = FSharpOption<SafeSymbolHandle>.Some(new SafeSymbolHandle(symbol, owner: true));
					Unit val3 = null;
				}
				catch (object obj)
				{
					Exception e = (Exception)obj;
					throw new SymbolInitilizationException(this, e);
				}
			}
		}

		private virtual Symbol MXNetSharp_002DISymbolComposable_002DComposedWith(Symbol y)
		{
			return ComposedWith(y);
		}

		Symbol ISymbolComposable.ComposedWith(Symbol y)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-ISymbolComposable-ComposedWith
			return this.MXNetSharp_002DISymbolComposable_002DComposedWith(y);
		}
	}
}
