using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Core;
using MXNetSharp.SymbolArgument;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SymbolComposable<a> : SymbolOperator where a : SymbolOperator
	{
		internal a rootSymbol;

		internal Symbol argSymbol;

		public override Symbol[] InputSymbols => ((Symbol)(object)rootSymbol).InputSymbols;

		public SymbolComposable(Symbol argSymbol, a rootSymbol)
			: base(((SymbolOperator)(object)rootSymbol).AtomicSymbolCreator, ((SymbolOperator)(object)rootSymbol).OperatorArguments)
		{
			this.argSymbol = argSymbol;
			this.rootSymbol = rootSymbol;
		}

		public override Symbol ComposedWith(Symbol symbol)
		{
			FSharpFunc<SymbolOperator, Symbol> val = new _0024Symbol.loop_0040597_002D8<a>(this, symbol);
			return new SymbolComposable<a>(argSymbol, IntrinsicFunctions.UnboxGeneric<a>((object)val.Invoke((SymbolOperator)(object)rootSymbol)));
		}

		public override Symbol WithArguments(Arguments<Symbol> args)
		{
			return new SymbolComposable<a>(argSymbol, IntrinsicFunctions.UnboxGeneric<a>((object)((SymbolOperator)(object)rootSymbol).WithArguments(args)));
		}

		public override Symbol Copy()
		{
			FSharpFunc<SymbolOperator, Symbol> val = new _0024Symbol.loop_0040628_002D10<a>(this);
			return new SymbolComposable<a>(argSymbol, IntrinsicFunctions.UnboxGeneric<a>((object)val.Invoke((SymbolOperator)(object)rootSymbol)));
		}
	}
}
