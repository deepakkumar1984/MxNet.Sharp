using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SymbolInput : Symbol
	{
		internal Symbol parent;

		internal int init_0040303_002D6;

		public Symbol Parent
		{
			get
			{
				if (init_0040303_002D6 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return parent;
			}
		}

		internal SymbolInput(Symbol parent)
		{
			this.parent = parent;
			init_0040303_002D6 = 1;
		}

		public SymbolInput(Symbol parent, SafeSymbolHandle handle)
		{
			FSharpRef<SymbolInput> @this = new FSharpRef<SymbolInput>((SymbolInput)null);
			this._002Ector(parent);
			@this.set_contents(this);
			init_0040303_002D6 = 1;
			IntrinsicFunctions.CheckThis<SymbolInput>(@this.get_contents()).InternalHandle = FSharpOption<SafeSymbolHandle>.Some(handle);
		}

		public override void Initialize()
		{
			if (init_0040303_002D6 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
		}

		public override Symbol Copy()
		{
			if (init_0040303_002D6 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			IntPtr h = MXSymbol.copy(SymbolHandle.UnsafeHandle);
			return new SymbolInput(parent, new SafeSymbolHandle(h, owner: true));
		}
	}
}
