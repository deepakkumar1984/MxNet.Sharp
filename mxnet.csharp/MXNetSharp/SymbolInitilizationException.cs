using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SymbolInitilizationException : Exception
	{
		public SymbolInitilizationException(Symbol symbol, Exception inner)
		{
			string message;
			if (inner == null)
			{
				message = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Symbol, string>>((PrintfFormat<FSharpFunc<Symbol, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Symbol, string>, Unit, string, string, Symbol>("Init failed on symbol %O")).Invoke(symbol);
			}
			else
			{
				Exception ex = inner;
				message = FSharpFunc<Symbol, string>.InvokeFast<string, string>((FSharpFunc<Symbol, FSharpFunc<string, FSharpFunc<string, string>>>)new _0024Symbol._002Dctor_004015_002D1(ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Symbol, FSharpFunc<string, FSharpFunc<string, string>>>>((PrintfFormat<FSharpFunc<Symbol, FSharpFunc<string, FSharpFunc<string, string>>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Symbol, FSharpFunc<string, FSharpFunc<string, string>>>, Unit, string, string, Tuple<Symbol, string, string>>("Init failed on symbol %O: %s %A"))), symbol, ex.Message, ex.StackTrace);
			}
			base._002Ector(message);
		}
	}
}
