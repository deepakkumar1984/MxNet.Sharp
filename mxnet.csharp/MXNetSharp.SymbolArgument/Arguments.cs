using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MXNetSharp.SymbolArgument
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class Arguments<a> : IEnumerable<Tuple<string, OpArg<a>>>
	{
		internal string[] ordering;

		internal IDictionary<string, OpArg<a>> args;

		public IDictionary<string, OpArg<a>> Args => args;

		public string[] Ordering => ordering;

		public Arguments(IDictionary<string, OpArg<a>> args, string[] ordering)
		{
			this.args = args;
			this.ordering = ordering;
		}

		public Arguments(IEnumerable<Tuple<string, OpArg<a>>> args)
			: this(ExtraTopLevelOperators.CreateDictionary<string, OpArg<a>>(args), SeqModule.ToArray<string>(SeqModule.Map<Tuple<string, OpArg<a>>, string>((FSharpFunc<Tuple<string, OpArg<a>>, string>)new _0024Operator._002Dctor_004032<a>(), args)))
		{
		}

		public Arguments<a> AddReplace(Arguments<a> args2)
		{
			IDictionary<string, OpArg<a>> dest = args;
			return new Arguments<a>(Dict.addReplace(args2.Args, dest), Ordering);
		}

		public Arguments<a> AddIgnore(Arguments<a> args2)
		{
			IDictionary<string, OpArg<a>> dest = args;
			return new Arguments<a>(Dict.addIgnore(args2.Args, dest), Ordering);
		}

		public a GetInput(string name)
		{
			OpArg<a> opArg = args[name];
			if (opArg is OpArg<a>.Input)
			{
				OpArg<a>.Input input = (OpArg<a>.Input)opArg;
				return input.item;
			}
			OpArg<a> w = opArg;
			FSharpFunc<string, FSharpFunc<OpArg<a>, a>> clo = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, FSharpFunc<OpArg<a>, a>>, a>((PrintfFormat<FSharpFunc<string, FSharpFunc<OpArg<a>, a>>, Unit, string, a>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<OpArg<FSharpFunc<string, FSharpFunc<OpArg<a>, a>>>, FSharpFunc<string, FSharpFunc<OpArg<a>, a>>>>, Unit, string, FSharpFunc<string, FSharpFunc<OpArg<a>, a>>, Tuple<string, OpArg<FSharpFunc<string, FSharpFunc<OpArg<a>, a>>>>>("Expecting %s to be an input but is a %A"));
			return FSharpFunc<string, OpArg<string>>.InvokeFast<a>((FSharpFunc<string, FSharpFunc<OpArg<string>, a>>)(object)new _0024Operator.GetInput_004040<a>(clo), name, (OpArg<string>)(object)w);
		}

		public FSharpOption<object> GetParameter(string name)
		{
			OpArg<a> opArg = args[name];
			if (opArg is OpArg<a>.Parameter)
			{
				OpArg<a>.Parameter parameter = (OpArg<a>.Parameter)opArg;
				return parameter.item;
			}
			OpArg<a> w = opArg;
			FSharpFunc<string, FSharpFunc<OpArg<a>, FSharpOption<object>>> clo = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, FSharpFunc<OpArg<a>, FSharpOption<object>>>, FSharpOption<object>>((PrintfFormat<FSharpFunc<string, FSharpFunc<OpArg<a>, FSharpOption<object>>>, Unit, string, FSharpOption<object>>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<OpArg<FSharpFunc<string, FSharpFunc<OpArg<a>, FSharpOption<object>>>>, FSharpOption<object>>>, Unit, string, FSharpOption<object>, Tuple<string, OpArg<FSharpFunc<string, FSharpFunc<OpArg<a>, FSharpOption<object>>>>>>("Expecting %s to be an parameter but is a %A"));
			return FSharpFunc<string, OpArg<string>>.InvokeFast<FSharpOption<object>>((FSharpFunc<string, FSharpFunc<OpArg<string>, FSharpOption<object>>>)(object)new _0024Operator.GetParameter_004044<a>(clo), name, (OpArg<string>)(object)w);
		}

		public v GetParameter<v>(string name, v def)
		{
			OpArg<a> opArg = args[name];
			if (opArg is OpArg<a>.Parameter)
			{
				OpArg<a>.Parameter parameter = (OpArg<a>.Parameter)opArg;
				if (parameter.item != null)
				{
					FSharpOption<object> item = parameter.item;
					if (IntrinsicFunctions.TypeTestGeneric<v>(item.get_Value()))
					{
						return (v)item.get_Value();
					}
					object v = item.get_Value();
					return IntrinsicFunctions.UnboxGeneric<v>(Convert.ChangeType(v, typeof(v)));
				}
				return def;
			}
			OpArg<a> w = opArg;
			FSharpFunc<string, FSharpFunc<OpArg<a>, v>> clo = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, FSharpFunc<OpArg<a>, v>>, v>((PrintfFormat<FSharpFunc<string, FSharpFunc<OpArg<a>, v>>, Unit, string, v>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<OpArg<FSharpFunc<string, FSharpFunc<OpArg<a>, v>>>, v>>, Unit, string, v, Tuple<string, OpArg<FSharpFunc<string, FSharpFunc<OpArg<a>, v>>>>>("Expecting %s to be an parameter but is a %A"));
			return FSharpFunc<string, OpArg<string>>.InvokeFast<v>((FSharpFunc<string, FSharpFunc<OpArg<string>, v>>)(object)new _0024Operator.GetParameter_004050_002D2<a, v>(clo), name, (OpArg<string>)(object)w);
		}

		public a[] GetVarArg(string name)
		{
			OpArg<a> opArg = args[name];
			if (opArg is OpArg<a>.VarArg)
			{
				OpArg<a>.VarArg varArg = (OpArg<a>.VarArg)opArg;
				a[] v = varArg.item2;
				string d = varArg.item1;
				return v;
			}
			OpArg<a> w = opArg;
			FSharpFunc<string, FSharpFunc<OpArg<a>, a[]>> clo = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<string, FSharpFunc<OpArg<a>, a[]>>, a[]>((PrintfFormat<FSharpFunc<string, FSharpFunc<OpArg<a>, a[]>>, Unit, string, a[]>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<OpArg<FSharpFunc<string, FSharpFunc<OpArg<a>, a[]>>>, FSharpFunc<string, FSharpFunc<OpArg<a>, a[]>>[]>>, Unit, string, FSharpFunc<string, FSharpFunc<OpArg<a>, a[]>>[], Tuple<string, OpArg<FSharpFunc<string, FSharpFunc<OpArg<a>, a[]>>>>>("Expecting %s to be a var arg but is a %A"));
			return FSharpFunc<string, OpArg<string>>.InvokeFast<a[]>((FSharpFunc<string, FSharpFunc<OpArg<string>, a[]>>)(object)new _0024Operator.GetVarArg_004054<a>(clo), name, (OpArg<string>)(object)w);
		}

		private virtual IEnumerator<Tuple<string, OpArg<a>>> System_002DCollections_002DGeneric_002DIEnumerable_00601_002DGetEnumerator()
		{
			return ((IEnumerable<Tuple<string, OpArg<a>>>)(object)new _0024Operator.System_002DCollections_002DGeneric_002DIEnumerable_002D1_002DGetEnumerator_004058<a>(this, null, null, 0, null)).GetEnumerator();
		}

		IEnumerator<Tuple<string, OpArg<a>>> IEnumerable<Tuple<string, OpArg<a>>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in System-Collections-Generic-IEnumerable`1-GetEnumerator
			return this.System_002DCollections_002DGeneric_002DIEnumerable_00601_002DGetEnumerator();
		}

		private virtual IEnumerator System_002DCollections_002DIEnumerable_002DGetEnumerator()
		{
			return ((IEnumerable<Tuple<string, OpArg<a>>>)this).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in System-Collections-IEnumerable-GetEnumerator
			return this.System_002DCollections_002DIEnumerable_002DGetEnumerator();
		}
	}
}
