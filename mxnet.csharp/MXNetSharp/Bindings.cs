using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class Bindings : IEnumerable<Bind>
	{
		internal IDictionary<string, Bind> bindings;

		public IDictionary<string, Bind> Bindings => bindings;

		public Bind this[Variable v]
		{
			get
			{
				Bind value = null;
				Tuple<bool, Bind> tuple = new Tuple<bool, Bind>(TryGetValue(v.Name, out value), value);
				bool scc = tuple.Item1;
				Bind b = tuple.Item2;
				if (!scc)
				{
					throw new KeyNotFoundException(ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("No binding for %s")).Invoke(b.Name));
				}
				return b;
			}
		}

		public Bindings(IDictionary<string, Bind> bindings)
		{
			this.bindings = bindings;
		}

		public Bindings()
			: this((IDictionary<string, Bind>)MapModule.Empty<string, Bind>())
		{
		}

		public bool TryGetValue(string name, out Bind value)
		{
			Bind value2 = null;
			Tuple<bool, Bind> tuple = new Tuple<bool, Bind>(bindings.TryGetValue(name, out value2), value2);
			Bind v = tuple.Item2;
			bool scc = tuple.Item1;
			value = v;
			return scc;
		}

		public Bindings WithBindings(IEnumerable<Bind> newBindings)
		{
			Dictionary<string, Bind> d = new Dictionary<string, Bind>(bindings);
			SeqModule.Iterate<Bind>((FSharpFunc<Bind, Unit>)new _0024Executor.WithBindings_0040175(d), newBindings);
			return new Bindings(d);
		}

		public Bindings InferShapes(Symbol symbol)
		{
			string[] argNames = symbol.ArgumentNames;
			Tuple<string, int[]>[] array = ArrayModule.Choose<string, Tuple<string, int[]>>((FSharpFunc<string, FSharpOption<Tuple<string, int[]>>>)new _0024Executor.result_0040182(this), argNames);
			FSharpFunc<int, uint> val = new _0024Executor.result_0040186_002D1();
			Tuple<string, int[]>[] array2 = array;
			uint[] array3 = ArrayModule.ZeroCreate<uint>(ArrayModule.Length<Tuple<string, int[]>>(array2) + 1);
			for (int i = 1; i < array3.Length; i++)
			{
				array3[i] = array3[i - 1] + val.Invoke(ArrayModule.Length<int>(array2[i - 1].Item2));
			}
			int[] array4 = ArrayModule.ZeroCreate<int>((int)array3[array3.Length - 1]);
			Tuple<string, int[]>[] array5 = array2;
			FSharpFunc<Tuple<string, int[]>, string> val2 = new _0024Executor.result_0040186_002D2();
			Tuple<string, int[]>[] array6 = array5;
			if (array6 == null)
			{
				throw new ArgumentNullException("array");
			}
			string[] array7 = new string[array6.Length];
			for (int j = 0; j < array7.Length; j++)
			{
				array7[j] = val2.Invoke(array6[j]);
			}
			string[] item = array7;
			int num = 0;
			for (int k = 0; k < array2.Length; k++)
			{
				int[] item2 = array2[k].Item2;
				for (int l = 0; l < item2.Length; l++)
				{
					array4[num] = item2[l];
					num++;
				}
			}
			Tuple<string[], uint[], int[]> tuple = new Tuple<string[], uint[], int[]>(item, array3, array4);
			InferShapeResult<uint> result = MXSymbol.inferShapePartial(symbol.UnsafeHandle, tuple.Item1, tuple.Item2, tuple.Item3);
			Bind[] auxBindings = ArrayModule.Map2<string, uint[], Bind>((FSharpFunc<string, FSharpFunc<uint[], Bind>>)(object)new _0024Executor.auxBindings_0040191(this), symbol.AuxiliaryStateNames, result.AuxShapes_0040);
			Bind[] outBindings = ArrayModule.Map2<string, uint[], Bind>((FSharpFunc<string, FSharpFunc<uint[], Bind>>)(object)new _0024Executor.outBindings_0040201(this), symbol.OutputNames, result.OutputShapes_0040);
			Bind[] inBindings = ArrayModule.Map2<string, uint[], Bind>((FSharpFunc<string, FSharpFunc<uint[], Bind>>)(object)new _0024Executor.inBindings_0040211(this), argNames, result.InputShapes_0040);
			return WithBindings((IEnumerable<Bind>)(object)new _0024Executor.InferShapes_0040218(auxBindings, outBindings, inBindings, null, null, 0, null));
		}

		public Bindings InferTypes(Symbol symbol)
		{
			string[] argNames = symbol.ArgumentNames;
			Tuple<string[], int[]> tuple = ArrayModule.Unzip<string, int>(ArrayModule.Choose<string, Tuple<string, int>>((FSharpFunc<string, FSharpOption<Tuple<string, int>>>)new _0024Executor.result_0040224_002D3(this), argNames));
			InferTypeResult result = MXSymbol.inferTypePartial(symbol.UnsafeHandle, tuple.Item1, tuple.Item2);
			Bind[] auxBindings = ArrayModule.Map2<string, int, Bind>((FSharpFunc<string, FSharpFunc<int, Bind>>)(object)new _0024Executor.auxBindings_0040233_002D1(this), symbol.AuxiliaryStateNames, result.AuxTypes_0040);
			Bind[] outBindings = ArrayModule.Map2<string, int, Bind>((FSharpFunc<string, FSharpFunc<int, Bind>>)(object)new _0024Executor.outBindings_0040242_002D1(this), symbol.OutputNames, result.OutputTypes_0040);
			Bind[] inBindings = ArrayModule.Map2<string, int, Bind>((FSharpFunc<string, FSharpFunc<int, Bind>>)(object)new _0024Executor.inBindings_0040251_002D1(this), argNames, result.InputTypes_0040);
			return WithBindings((IEnumerable<Bind>)(object)new _0024Executor.InferTypes_0040257(auxBindings, outBindings, inBindings, null, null, 0, null));
		}

		public NDArray NDArray(Variable v)
		{
			FSharpOption<NDArray> nDArray = this[v].NDArray;
			if (nDArray != null)
			{
				FSharpOption<NDArray> val = nDArray;
				return val.get_Value();
			}
			throw new NullReferenceException(ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("NDArray not set for binding %s")).Invoke(v.Name));
		}

		public NDArray Grad(Variable v)
		{
			FSharpOption<NDArray> grad = this[v].Grad;
			if (grad != null)
			{
				FSharpOption<NDArray> val = grad;
				return val.get_Value();
			}
			throw new NullReferenceException(ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("Grad not set for binding %s")).Invoke(v.Name));
		}

		private virtual IEnumerator<Bind> System_002DCollections_002DGeneric_002DIEnumerable_00601_002DGetEnumerator()
		{
			return bindings.Values.GetEnumerator();
		}

		IEnumerator<Bind> IEnumerable<Bind>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in System-Collections-Generic-IEnumerable`1-GetEnumerator
			return this.System_002DCollections_002DGeneric_002DIEnumerable_00601_002DGetEnumerator();
		}

		private virtual IEnumerator System_002DCollections_002DIEnumerable_002DGetEnumerator()
		{
			return bindings.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in System-Collections-IEnumerable-GetEnumerator
			return this.System_002DCollections_002DIEnumerable_002DGetEnumerator();
		}
	}
}
