using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class SymbolOutput : Symbol
	{
		internal int position;

		internal Symbol parent;

		internal int init_0040290_002D5;

		public Symbol Parent
		{
			get
			{
				if (init_0040290_002D5 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return parent;
			}
		}

		public int Position
		{
			get
			{
				if (init_0040290_002D5 < 1)
				{
					IntrinsicFunctions.FailInit();
				}
				return position;
			}
		}

		internal SymbolOutput(Symbol parent, int position)
		{
			this.parent = parent;
			this.position = position;
			init_0040290_002D5 = 1;
		}

		public SymbolOutput(Symbol parent, int position, SafeSymbolHandle handle)
		{
			FSharpRef<SymbolOutput> @this = new FSharpRef<SymbolOutput>((SymbolOutput)null);
			this._002Ector(parent, position);
			@this.set_contents(this);
			init_0040290_002D5 = 1;
			IntrinsicFunctions.CheckThis<SymbolOutput>(@this.get_contents()).InternalHandle = FSharpOption<SafeSymbolHandle>.Some(handle);
		}

		public override void Initialize()
		{
			if (init_0040290_002D5 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
		}

		public override Symbol Copy()
		{
			if (init_0040290_002D5 < 1)
			{
				IntrinsicFunctions.FailInit();
			}
			IntPtr h = MXSymbol.copy(SymbolHandle.UnsafeHandle);
			return new SymbolOutput(parent, position, new SafeSymbolHandle(h, owner: true));
		}
	}
}
