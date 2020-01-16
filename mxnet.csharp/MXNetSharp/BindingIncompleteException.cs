using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class BindingIncompleteException : Exception
	{
		public BindingIncompleteException(FSharpOption<Bind> bind, string fieldOrName)
		{
			string message;
			if (bind != null)
			{
				Bind bind2 = bind.get_Value();
				Bind bind3 = bind2;
				object obj;
				if (!(bind3 is Bind.ArgBinding))
				{
					Bind.AuxBinding auxBinding = (Bind.AuxBinding)bind3;
					obj = "Aux";
				}
				else
				{
					Bind.ArgBinding argBinding = (Bind.ArgBinding)bind3;
					obj = "Arg";
				}
				message = FSharpFunc<string, string>.InvokeFast<string, string>((FSharpFunc<string, FSharpFunc<string, FSharpFunc<string, string>>>)new _0024Executor._002Dctor_0040442_002D14(ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<string, FSharpFunc<string, string>>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<string, FSharpFunc<string, string>>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<string, FSharpFunc<string, string>>>, Unit, string, string, Tuple<string, string, string>>("Bindings incomplete. Expecting %s in  %s binding '%s'"))), fieldOrName, (string)obj, bind2.Name);
			}
			else
			{
				message = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("Bindings incomplete. No binding for '%s'.")).Invoke(fieldOrName);
			}
			base._002Ector(message);
		}
	}
}
