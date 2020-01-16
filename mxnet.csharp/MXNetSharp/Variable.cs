using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class Variable : Symbol
	{
		internal int init_0040314_002D7;

		public Variable()
		{
			init_0040314_002D7 = 1;
		}

		public Variable(string name)
		{
			FSharpRef<Variable> @this = new FSharpRef<Variable>((Variable)null);
			this._002Ector();
			@this.set_contents(this);
			init_0040314_002D7 = 1;
			IntrinsicFunctions.CheckThis<Variable>(@this.get_contents()).InternalName = FSharpOption<string>.Some(name);
		}

		public override void Initialize()
		{
			if (init_0040314_002D7 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			FSharpOption<SafeSymbolHandle> internalHandle = InternalHandle;
			if (internalHandle != null)
			{
				FSharpOption<SafeSymbolHandle> val = internalHandle;
				return;
			}
			FSharpOption<string> internalName = InternalName;
			string text;
			if (internalName != null)
			{
				FSharpOption<string> val2 = internalName;
				string j = val2.get_Value();
				text = j;
			}
			else
			{
				text = GeneratedName;
			}
			string i = text;
			InternalHandle = FSharpOption<SafeSymbolHandle>.Some(new SafeSymbolHandle(MXSymbol.createVariable(i), owner: true));
		}

		public override Symbol Copy()
		{
			if (init_0040314_002D7 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			Initialize();
			return new Variable(Name);
		}
	}
}
