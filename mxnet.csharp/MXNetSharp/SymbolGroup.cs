#define DEBUG
using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SymbolGroup : Symbol
	{
		internal Symbol[] symbols;

		public Symbol this[int i] => symbols[i];

		public int Count => symbols.Length;

		public override Symbol[] InputSymbols
		{
			get
			{
				Symbol[] a = ArrayModule.Collect<Symbol, Symbol>((FSharpFunc<Symbol, Symbol[]>)new _0024Symbol.a_0040667(), symbols);
				Symbol[] array = a;
				FSharpFunc<Symbol, string> val = new _0024Symbol.get_InputSymbols_0040668_002D6();
				Symbol[] array2 = array;
				if (array2 == null)
				{
					throw new ArgumentNullException("array");
				}
				string[] array3 = new string[array2.Length];
				for (int i = 0; i < array3.Length; i++)
				{
					array3[i] = val.Invoke(array2[i]);
				}
				Debug.Assert(HashCompare.GenericEqualityIntrinsic<string[]>(array3, ArgumentNames));
				return a;
			}
		}

		public SymbolGroup(params Symbol[] symbols)
		{
			this.symbols = symbols;
		}

		public SymbolGroup(IEnumerable<Symbol> symbols)
			: this(SeqModule.ToArray<Symbol>(symbols))
		{
		}

		public override void Initialize()
		{
			FSharpOption<SafeSymbolHandle> internalHandle = InternalHandle;
			if (internalHandle != null)
			{
				FSharpOption<SafeSymbolHandle> val = internalHandle;
				return;
			}
			Symbol[] array = symbols;
			FSharpFunc<Symbol, IntPtr> val2 = new _0024Symbol.symbol_0040663();
			Symbol[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr[] array3 = new IntPtr[array2.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = val2.Invoke(array2[i]);
			}
			IntPtr symbol = MXSymbol.createGroup(array3);
			InternalHandle = FSharpOption<SafeSymbolHandle>.Some(new SafeSymbolHandle(symbol, owner: true));
		}

		public override Symbol Copy()
		{
			Symbol[] array = symbols;
			FSharpFunc<Symbol, Symbol> val = new _0024Symbol.Copy_0040665_002D1();
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
			return new SymbolGroup(array3);
		}
	}
}
