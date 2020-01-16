using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Control;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MXNetSharp
{
	[Serializable]
	[AbstractClass]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public abstract class Symbol
	{
		internal static long count;

		internal Lazy<long> sid;

		internal FSharpOption<string> InternalName_0040;

		internal FSharpOption<SafeSymbolHandle> InternalHandle_0040;

		internal static int init_004021_002D10;

		public Symbol NoArg => new ImplicitVariable();

		public long Id => sid.Value;

		public string GeneratedName
		{
			get
			{
				FSharpFunc<string, FSharpFunc<long, string>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<long, string>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<long, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<long, string>>, Unit, string, string, Tuple<string, long>>("%s!%d"));
				return FSharpFunc<string, long>.InvokeFast<string>((FSharpFunc<string, FSharpFunc<long, string>>)new _0024Symbol.get_GeneratedName_004027(clo), GetType().Name, Id);
			}
		}

		public FSharpOption<string> InternalName
		{
			get
			{
				return InternalName_0040;
			}
			set
			{
				InternalName_0040 = value;
			}
		}

		public FSharpOption<SafeSymbolHandle> InternalHandle
		{
			get
			{
				return InternalHandle_0040;
			}
			set
			{
				InternalHandle_0040 = value;
			}
		}

		public bool IsInitialized => FSharpOption<SafeSymbolHandle>.get_IsSome(InternalHandle);

		public string Name
		{
			get
			{
				if (IsInitialized)
				{
					FSharpOption<string> name = MXSymbol.getName(UnsafeHandle);
					if (name != null)
					{
						FSharpOption<string> val = name;
						return val.get_Value();
					}
					FSharpOption<string> internalName = InternalName;
					if (internalName != null)
					{
						FSharpOption<string> val2 = internalName;
						return val2.get_Value();
					}
					return GeneratedName;
				}
				FSharpOption<string> internalName2 = InternalName;
				if (internalName2 != null)
				{
					FSharpOption<string> val3 = internalName2;
					return val3.get_Value();
				}
				return GeneratedName;
			}
			set
			{
				if (IsInitialized)
				{
					string text = "Cannot set name. Symbol has already been created.";
					throw Operators.Failure(text);
				}
				InternalName = FSharpOption<string>.Some(value);
			}
		}

		public SafeSymbolHandle SymbolHandle
		{
			get
			{
				FSharpOption<SafeSymbolHandle> internalHandle = InternalHandle;
				if (internalHandle != null)
				{
					FSharpOption<SafeSymbolHandle> val = internalHandle;
					return val.get_Value();
				}
				Initialize();
				FSharpOption<SafeSymbolHandle> internalHandle2 = InternalHandle;
				if (internalHandle2 != null)
				{
					FSharpOption<SafeSymbolHandle> val2 = internalHandle2;
					return val2.get_Value();
				}
				throw new SymbolInitilizationException(this, null);
			}
		}

		public IntPtr UnsafeHandle => SymbolHandle.UnsafeHandle;

		public int OutputCount => (int)MXSymbol.getNumOutputs(UnsafeHandle);

		public SymbolOutput[] Outputs
		{
			get
			{
				int i = OutputCount;
				int num = i;
				FSharpFunc<int, SymbolOutput> val = new _0024Symbol.get_Outputs_004071(this);
				if (num < 0)
				{
					object[] args = new object[3]
					{
						ErrorStrings.get_InputMustBeNonNegativeString(),
						"count",
						num
					};
					string message = string.Format("{0}\n{1} = {2}", args);
					throw new ArgumentException(message, "count");
				}
				SymbolOutput[] array = new SymbolOutput[num];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = val.Invoke(j);
				}
				return array;
			}
		}

		public string[] OutputNames => MXSymbol.listOutputs(UnsafeHandle);

		public string[] ArgumentNames => MXSymbol.listArguments(UnsafeHandle);

		public string[] AuxiliaryStateNames => MXSymbol.listAuxiliaryStates(UnsafeHandle);

		public override Symbol[] InputSymbols
		{
			get
			{
				IntPtr[] inputSymbols = MXSymbol.getInputSymbols(UnsafeHandle);
				FSharpFunc<IntPtr, Symbol> val = new _0024Symbol.get_InputSymbols_004079(this);
				IntPtr[] array = inputSymbols;
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				Symbol[] array2 = new Symbol[array.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = val.Invoke(array[i]);
				}
				return array2;
			}
		}

		public abstract override Symbol Copy();

		public abstract override void Initialize();

		public Symbol()
		{
			sid = LazyExtensions.Create<long>((FSharpFunc<Unit, long>)new _0024Symbol._002Dctor_004024_002D4());
			InternalName_0040 = null;
			InternalHandle_0040 = null;
		}

		public void FreezeName()
		{
			if (!IsInitialized)
			{
				FSharpOption<string> internalName = InternalName;
				if (internalName != null)
				{
					FSharpOption<string> val = internalName;
				}
				else
				{
					InternalName = FSharpOption<string>.Some(GeneratedName);
				}
			}
		}

		public Symbol SetName(string name)
		{
			Name = name;
			return this;
		}

		public Symbol SetName(Symbol symbol)
		{
			FSharpOption<string> internalName = symbol.InternalName;
			if (internalName != null)
			{
				FSharpOption<string> val = internalName;
				string i = val.get_Value();
				return SetName(i);
			}
			return this;
		}

		public SymbolOperators.Concat Concat(int dim, params Symbol[] data)
		{
			return new SymbolOperators.Concat(FSharpOption<IEnumerable<Symbol>>.Some((IEnumerable<Symbol>)data), FSharpOption<int>.Some(dim));
		}

		public SymbolOperators.Concat Concat(int dim, IEnumerable<Symbol> data)
		{
			return new SymbolOperators.Concat(FSharpOption<IEnumerable<Symbol>>.Some(data), FSharpOption<int>.Some(dim));
		}

		public SymbolOperators.Reshape Reshape(params int[] dims)
		{
			return new SymbolOperators.Reshape(FSharpOption<Symbol>.Some(this), FSharpOption<IEnumerable<int>>.Some((IEnumerable<int>)dims));
		}

		public SymbolOperators.Reshape Reshape(IEnumerable<int> dims)
		{
			return new SymbolOperators.Reshape(FSharpOption<Symbol>.Some(this), FSharpOption<IEnumerable<int>>.Some(dims));
		}

		public SymbolOperators.Reshape ReverseReshape(params int[] dims)
		{
			return new SymbolOperators.Reshape(FSharpOption<Symbol>.Some(this), FSharpOption<IEnumerable<int>>.Some((IEnumerable<int>)dims), FSharpOption<bool>.Some(true));
		}

		public SymbolOperators.Reshape ReverseReshape(IEnumerable<int> dims)
		{
			return new SymbolOperators.Reshape(FSharpOption<Symbol>.Some(this), FSharpOption<IEnumerable<int>>.Some(dims), FSharpOption<bool>.Some(true));
		}

		public SymbolOperators.Slice Slice(IEnumerable<FSharpOption<int>> startIndices, IEnumerable<FSharpOption<int>> endIndices, IEnumerable<FSharpOption<int>> stepIndices)
		{
			return new SymbolOperators.Slice(this, startIndices, endIndices, FSharpOption<IEnumerable<FSharpOption<int>>>.Some(stepIndices));
		}

		public SymbolOperators.Slice GetSlice(params object[] a)
		{
			List<FSharpOption<int>> b = new List<FSharpOption<int>>();
			List<FSharpOption<int>> e = new List<FSharpOption<int>>();
			List<FSharpOption<int>> s = new List<FSharpOption<int>>();
			List<int> sliceAxis = new List<int>();
			List<int> newAxis = new List<int>();
			int i = 0;
			int sliceAx = 0;
			for (; i < a.Length; i++)
			{
				object obj = a[i];
				if (!IntrinsicFunctions.TypeTestGeneric<int>(obj))
				{
					if (!IntrinsicFunctions.TypeTestGeneric<FSharpOption<int>>(obj))
					{
						SliceRange sliceRange = obj as SliceRange;
						if (sliceRange == null)
						{
							NewAxis newAxis2 = obj as NewAxis;
							if (newAxis2 != null)
							{
								newAxis.Add(sliceAx);
								continue;
							}
							FSharpFunc<object, Unit> val = ExtraTopLevelOperators.PrintFormatToStringThenFail<FSharpFunc<object, Unit>, Unit>((PrintfFormat<FSharpFunc<object, Unit>, Unit, string, Unit>)(object)new PrintfFormat<FSharpFunc<object, Unit>, Unit, string, Unit, object>("invalid argument to get slice %A"));
							object obj2 = a[i];
							val.Invoke(obj2);
							continue;
						}
						SliceRange r = sliceRange;
						FSharpOption<long> start = r.Start;
						if (start != null)
						{
							FSharpOption<long> val2 = start;
							long v3 = val2.get_Value();
							b.Add(FSharpOption<int>.Some((int)v3));
						}
						else
						{
							b.Add(null);
						}
						FSharpOption<long> stop = r.Stop;
						if (stop != null)
						{
							FSharpOption<long> val3 = stop;
							long v2 = val3.get_Value();
							e.Add(FSharpOption<int>.Some((int)((v2 < 0) ? v2 : ((int)v2 + 1))));
						}
						else
						{
							e.Add(null);
						}
						FSharpOption<long> step = r.Step;
						if (step != null)
						{
							FSharpOption<long> val4 = step;
							long v = val4.get_Value();
							s.Add(FSharpOption<int>.Some((int)v));
						}
						else
						{
							s.Add(null);
						}
						sliceAxis.Add(sliceAx);
						sliceAx++;
					}
					else
					{
						FSharpOption<int> o3 = (FSharpOption<int>)obj;
						FSharpOption<int> o4 = OptionModule.Map<int, int>((FSharpFunc<int, int>)new _0024Symbol.o2_0040107(), (FSharpOption<int>)a[i + 1]);
						FSharpOption<int> val5 = o3;
						object item;
						if (val5 != null)
						{
							FSharpOption<int> val6 = val5;
							int o2 = val6.get_Value();
							item = FSharpOption<int>.Some(o2);
						}
						else
						{
							item = null;
						}
						b.Add((FSharpOption<int>)item);
						FSharpOption<int> val7 = o4;
						object item2;
						if (val7 != null)
						{
							FSharpOption<int> val8 = val7;
							int o = val8.get_Value();
							item2 = FSharpOption<int>.Some(o);
						}
						else
						{
							item2 = null;
						}
						e.Add((FSharpOption<int>)item2);
						s.Add(null);
						sliceAxis.Add(sliceAx);
						sliceAx++;
						i++;
					}
				}
				else
				{
					int idx = (int)obj;
					b.Add(FSharpOption<int>.Some(idx));
					e.Add(FSharpOption<int>.Some((idx < 0) ? idx : (idx + 1)));
					s.Add(null);
					sliceAxis.Add(sliceAx);
					sliceAx++;
				}
			}
			return Slice(b, e, s);
		}

		public static SymbolOperators.PlusScalar operator +(Symbol x, double y)
		{
			return new SymbolOperators.PlusScalar(x, y);
		}

		public static SymbolOperators.PlusScalar operator +(double y, Symbol x)
		{
			return new SymbolOperators.PlusScalar(x, y);
		}

		public static SymbolOperators.ElemwiseAdd operator +(Symbol x, Symbol y)
		{
			return new SymbolOperators.ElemwiseAdd(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.BroadcastAdd op_DotPlus(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastAdd(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.MinusScalar operator -(Symbol x, double y)
		{
			return new SymbolOperators.MinusScalar(x, y);
		}

		public static SymbolOperators.RminusScalar operator -(double y, Symbol x)
		{
			return new SymbolOperators.RminusScalar(x, y);
		}

		public static SymbolOperators.ElemwiseSub operator -(Symbol x, Symbol y)
		{
			return new SymbolOperators.ElemwiseSub(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.BroadcastSub op_DotMinus(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastSub(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.DivScalar operator /(Symbol x, double y)
		{
			return new SymbolOperators.DivScalar(x, y);
		}

		public static SymbolOperators.RdivScalar operator /(double y, Symbol x)
		{
			return new SymbolOperators.RdivScalar(x, y);
		}

		public static SymbolOperators.ElemwiseDiv operator /(Symbol x, Symbol y)
		{
			return new SymbolOperators.ElemwiseDiv(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.BroadcastDiv op_DotDivide(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastDiv(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.MulScalar operator *(Symbol x, double y)
		{
			return new SymbolOperators.MulScalar(x, y);
		}

		public static SymbolOperators.MulScalar operator *(double y, Symbol x)
		{
			return new SymbolOperators.MulScalar(x, y);
		}

		public static SymbolOperators.ElemwiseMul operator *(Symbol x, Symbol y)
		{
			return new SymbolOperators.ElemwiseMul(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.BroadcastMul op_DotMultiply(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastMul(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.PowerScalar ApplyPow(Symbol x, double y)
		{
			return new SymbolOperators.PowerScalar(x, y);
		}

		public static SymbolOperators.RpowerScalar ApplyPow(double y, Symbol x)
		{
			return new SymbolOperators.RpowerScalar(x, y);
		}

		public static SymbolOperators.Power ApplyPow(Symbol x, Symbol y)
		{
			return new SymbolOperators.Power(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.BroadcastPower op_DotMultiplyMultiply(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastPower(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public SymbolOperators.MulScalar Negate()
		{
			double y = -1.0;
			return y * this;
		}

		public SymbolOperators.MulScalar ApplyNegate()
		{
			return Negate();
		}

		public static SymbolOperators.MulScalar operator -(Symbol x)
		{
			return x.Negate();
		}

		public static SymbolOperators.ModScalar operator %(Symbol x, double y)
		{
			return new SymbolOperators.ModScalar(x, y);
		}

		public static SymbolOperators.RmodScalar operator %(double y, Symbol x)
		{
			return new SymbolOperators.RmodScalar(x, y);
		}

		public static SymbolOperators.BroadcastMod operator %(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastMod(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.EqualScalar op_DotEquals(Symbol x, double y)
		{
			return new SymbolOperators.EqualScalar(x, y);
		}

		public static SymbolOperators.EqualScalar op_DotEquals(double y, Symbol x)
		{
			return new SymbolOperators.EqualScalar(x, y);
		}

		public static SymbolOperators.BroadcastEqual op_DotEquals(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastEqual(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.NotEqualScalar op_DotLessGreater(Symbol x, double y)
		{
			return new SymbolOperators.NotEqualScalar(x, y);
		}

		public static SymbolOperators.NotEqualScalar op_DotLessGreater(double y, Symbol x)
		{
			return new SymbolOperators.NotEqualScalar(x, y);
		}

		public static SymbolOperators.BroadcastNotEqual op_DotLessGreater(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastNotEqual(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.GreaterScalar op_DotGreater(Symbol x, double y)
		{
			return new SymbolOperators.GreaterScalar(x, y);
		}

		public static SymbolOperators.LesserScalar op_DotGreater(double y, Symbol x)
		{
			return new SymbolOperators.LesserScalar(x, y);
		}

		public static SymbolOperators.BroadcastGreater op_DotGreater(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastGreater(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.LesserScalar op_DotLess(Symbol x, double y)
		{
			return new SymbolOperators.LesserScalar(x, y);
		}

		public static SymbolOperators.GreaterScalar op_DotLess(double y, Symbol x)
		{
			return new SymbolOperators.GreaterScalar(x, y);
		}

		public static SymbolOperators.BroadcastLesser op_DotLess(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastLesser(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.GreaterEqualScalar op_DotGreaterEquals(Symbol x, double y)
		{
			return new SymbolOperators.GreaterEqualScalar(x, y);
		}

		public static SymbolOperators.LesserEqualScalar op_DotGreaterEquals(double y, Symbol x)
		{
			return new SymbolOperators.LesserEqualScalar(x, y);
		}

		public static SymbolOperators.BroadcastGreaterEqual op_DotGreaterEquals(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastGreaterEqual(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.LesserEqualScalar op_DotLessEquals(Symbol x, double y)
		{
			return new SymbolOperators.LesserEqualScalar(x, y);
		}

		public static SymbolOperators.GreaterEqualScalar op_DotLessEquals(double y, Symbol x)
		{
			return new SymbolOperators.GreaterEqualScalar(x, y);
		}

		public static SymbolOperators.BroadcastLesserEqual op_DotLessEquals(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastLesserEqual(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.LogicalAndScalar op_DotAmpAmp(Symbol x, bool y)
		{
			return new SymbolOperators.LogicalAndScalar(x, (!y) ? 0.0 : 1.0);
		}

		public static SymbolOperators.LogicalAndScalar op_DotAmpAmp(bool y, Symbol x)
		{
			return new SymbolOperators.LogicalAndScalar(x, (!y) ? 0.0 : 1.0);
		}

		public static SymbolOperators.LogicalAndScalar op_DotAmpAmp(Symbol x, double y)
		{
			return new SymbolOperators.LogicalAndScalar(x, y);
		}

		public static SymbolOperators.LogicalAndScalar op_DotAmpAmp(double y, Symbol x)
		{
			return new SymbolOperators.LogicalAndScalar(x, y);
		}

		public static SymbolOperators.LogicalAnd op_DotAmpAmp(Symbol x, Symbol y)
		{
			return new SymbolOperators.LogicalAnd(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.BroadcastLogicalAnd op_DotDotAmpAmp(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastLogicalAnd(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.LogicalOrScalar op_DotBarBar(Symbol x, bool y)
		{
			return new SymbolOperators.LogicalOrScalar(x, (!y) ? 0.0 : 1.0);
		}

		public static SymbolOperators.LogicalOrScalar op_DotBarBar(bool y, Symbol x)
		{
			return new SymbolOperators.LogicalOrScalar(x, (!y) ? 0.0 : 1.0);
		}

		public static SymbolOperators.LogicalOrScalar op_DotBarBar(Symbol x, double y)
		{
			return new SymbolOperators.LogicalOrScalar(x, y);
		}

		public static SymbolOperators.LogicalOrScalar op_DotBarBar(double y, Symbol x)
		{
			return new SymbolOperators.LogicalOrScalar(x, y);
		}

		public static SymbolOperators.LogicalOr op_DotBarBar(Symbol x, Symbol y)
		{
			return new SymbolOperators.LogicalOr(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.BroadcastLogicalOr op_DotDotBarBar(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastLogicalOr(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.LogicalXorScalar op_DotHatHat(Symbol x, bool y)
		{
			return new SymbolOperators.LogicalXorScalar(x, (!y) ? 0.0 : 1.0);
		}

		public static SymbolOperators.LogicalXorScalar op_DotHatHat(bool y, Symbol x)
		{
			return new SymbolOperators.LogicalXorScalar(x, (!y) ? 0.0 : 1.0);
		}

		public static SymbolOperators.LogicalXorScalar op_DotHatHat(Symbol x, double y)
		{
			return new SymbolOperators.LogicalXorScalar(x, y);
		}

		public static SymbolOperators.LogicalXorScalar op_DotHatHat(double y, Symbol x)
		{
			return new SymbolOperators.LogicalXorScalar(x, y);
		}

		public static SymbolOperators.LogicalXor op_DotHatHat(Symbol x, Symbol y)
		{
			return new SymbolOperators.LogicalXor(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public static SymbolOperators.BroadcastLogicalXor op_DotDotHatHat(Symbol x, Symbol y)
		{
			return new SymbolOperators.BroadcastLogicalXor(FSharpOption<Symbol>.Some(x), FSharpOption<Symbol>.Some(y));
		}

		public SymbolOperators.Exp Exp()
		{
			return new SymbolOperators.Exp(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Exp ApplyExp()
		{
			return new SymbolOperators.Exp(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Exp(Symbol x)
		{
			return new SymbolOperators.Exp(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Log Log()
		{
			return new SymbolOperators.Log(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Log ApplyLog()
		{
			return new SymbolOperators.Log(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Log(Symbol x)
		{
			return new SymbolOperators.Log(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Abs Abs()
		{
			return new SymbolOperators.Abs(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Abs ApplyAbs()
		{
			return new SymbolOperators.Abs(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Abs(Symbol x)
		{
			return new SymbolOperators.Abs(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Arccos Acos()
		{
			return new SymbolOperators.Arccos(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Arccos ApplyAcos()
		{
			return new SymbolOperators.Arccos(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Acos(Symbol x)
		{
			return new SymbolOperators.Arccos(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Arcsin Asin()
		{
			return new SymbolOperators.Arcsin(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Arcsin ApplyAsin()
		{
			return new SymbolOperators.Arcsin(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Asin(Symbol x)
		{
			return new SymbolOperators.Arcsin(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Arctan Atan()
		{
			return new SymbolOperators.Arctan(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Arctan ApplyAtan()
		{
			return new SymbolOperators.Arctan(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Atan(Symbol x)
		{
			return new SymbolOperators.Arctan(FSharpOption<Symbol>.Some(x));
		}

		public static SymbolOperators.NpiArctan2 Atan2<g, h>(g x, h y) where g : Symbol where h : Symbol
		{
			return new SymbolOperators.NpiArctan2(FSharpOption<Symbol>.Some((Symbol)(object)x), FSharpOption<Symbol>.Some((Symbol)(object)y));
		}

		public static SymbolOperators.NpiArctan2Scalar Atan2<f>(f x, double y) where f : Symbol
		{
			return new SymbolOperators.NpiArctan2Scalar((Symbol)(object)x, y);
		}

		public static SymbolOperators.NpiRarctan2Scalar Atan2<e>(double y, e x) where e : Symbol
		{
			return new SymbolOperators.NpiRarctan2Scalar((Symbol)(object)x, y);
		}

		public static SymbolOperators.NpiArctan2 ArcTan2<c, d>(c x, d y) where c : Symbol where d : Symbol
		{
			return new SymbolOperators.NpiArctan2(FSharpOption<Symbol>.Some((Symbol)(object)x), FSharpOption<Symbol>.Some((Symbol)(object)y));
		}

		public static SymbolOperators.NpiArctan2Scalar ArcTan2<b>(b x, double y) where b : Symbol
		{
			return new SymbolOperators.NpiArctan2Scalar((Symbol)(object)x, y);
		}

		public static SymbolOperators.NpiRarctan2Scalar AtcTan2<a>(double y, a x) where a : Symbol
		{
			return new SymbolOperators.NpiRarctan2Scalar((Symbol)(object)x, y);
		}

		public SymbolOperators.Ceil Ceiling()
		{
			return new SymbolOperators.Ceil(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Ceil ApplyCeiling()
		{
			return new SymbolOperators.Ceil(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Ceiling(Symbol x)
		{
			return new SymbolOperators.Ceil(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Floor Floor()
		{
			return new SymbolOperators.Floor(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Floor ApplyFloor()
		{
			return new SymbolOperators.Floor(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Floor(Symbol x)
		{
			return new SymbolOperators.Floor(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Trunc Truncate()
		{
			return new SymbolOperators.Trunc(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Trunc ApplyTruncate()
		{
			return new SymbolOperators.Trunc(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Truncate(Symbol x)
		{
			return new SymbolOperators.Trunc(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Round Round()
		{
			return new SymbolOperators.Round(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Round ApplyRound()
		{
			return new SymbolOperators.Round(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Round(Symbol x)
		{
			return new SymbolOperators.Round(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Log10 Log10()
		{
			return new SymbolOperators.Log10(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Log10 ApplyLog10()
		{
			return new SymbolOperators.Log10(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Log10(Symbol x)
		{
			return new SymbolOperators.Log10(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Sqrt Sqrt()
		{
			return new SymbolOperators.Sqrt(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Sqrt ApplySqrt()
		{
			return new SymbolOperators.Sqrt(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Sqrt(Symbol x)
		{
			return new SymbolOperators.Sqrt(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Cos Cos()
		{
			return new SymbolOperators.Cos(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Cos ApplyCos()
		{
			return new SymbolOperators.Cos(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Cos(Symbol x)
		{
			return new SymbolOperators.Cos(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Cosh Cosh()
		{
			return new SymbolOperators.Cosh(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Cosh ApplyCosh()
		{
			return new SymbolOperators.Cosh(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Cosh(Symbol x)
		{
			return new SymbolOperators.Cosh(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Sin Sin()
		{
			return new SymbolOperators.Sin(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Sin ApplySin()
		{
			return new SymbolOperators.Sin(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Sin(Symbol x)
		{
			return new SymbolOperators.Sin(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Sinh Sinh()
		{
			return new SymbolOperators.Sinh(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Sinh ApplySinh()
		{
			return new SymbolOperators.Sinh(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Sinh(Symbol x)
		{
			return new SymbolOperators.Sinh(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Tan Tan()
		{
			return new SymbolOperators.Tan(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Tan ApplyTan()
		{
			return new SymbolOperators.Tan(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Tan(Symbol x)
		{
			return new SymbolOperators.Tan(FSharpOption<Symbol>.Some(x));
		}

		public SymbolOperators.Tanh Tanh()
		{
			return new SymbolOperators.Tanh(FSharpOption<Symbol>.Some(this));
		}

		public SymbolOperators.Tanh ApplyTanh()
		{
			return new SymbolOperators.Tanh(FSharpOption<Symbol>.Some(this));
		}

		public static Symbol Tanh(Symbol x)
		{
			return new SymbolOperators.Tanh(FSharpOption<Symbol>.Some(x));
		}

		public static a op_DotGreaterGreater<a>(Symbol x, a y) where a : Symbol
		{
			FSharpOption<Symbol> val = OptionModule.Bind<Hole, Symbol>((FSharpFunc<Hole, FSharpOption<Symbol>>)new _0024Symbol.op_DotGreaterGreater_0040275<a>(x, y), SymUtil.tryFindType<Hole>((Symbol)(object)y));
			if (val != null)
			{
				FSharpOption<Symbol> val2 = val;
				Symbol h = val2.get_Value();
				object obj = h;
				object obj2 = obj;
				return IntrinsicFunctions.UnboxGeneric<a>(obj2);
			}
			Symbol symbol = (Symbol)(object)y;
			SymbolOperator symbolOperator = symbol as SymbolOperator;
			if (symbolOperator != null)
			{
				SymbolOperator s = symbolOperator;
				return IntrinsicFunctions.UnboxGeneric<a>((object)s.ComposedWith(x));
			}
			return y;
		}

		public static SymbolOperator op_DotBarGreater<a, b>(a x, b f) where a : Symbol where b : SymbolOperator
		{
			FSharpFunc<Unit, SymbolOperator> _f = new _0024Symbol._f_0040284<b>(f);
			((Symbol)(object)f).Initialize();
			SymbolOperator fcopy = IntrinsicFunctions.UnboxGeneric<SymbolOperator>((object)((Symbol)(object)f).Copy());
			SymbolOperator symbolOperator = fcopy;
			Symbol symbol = (Symbol)(object)x;
			SymbolOperator symbolOperator2 = symbolOperator;
			FSharpOption<Symbol> val = OptionModule.Bind<Hole, Symbol>((FSharpFunc<Hole, FSharpOption<Symbol>>)new _0024Symbol.op_DotBarGreater_0040287(symbol, symbolOperator2), SymUtil.tryFindType<Hole>(symbolOperator2));
			if (val != null)
			{
				FSharpOption<Symbol> val2 = val;
				Symbol value = val2.get_Value();
				return IntrinsicFunctions.UnboxGeneric<SymbolOperator>((object)value);
			}
			Symbol symbol2 = symbolOperator2;
			SymbolOperator symbolOperator3 = symbol2 as SymbolOperator;
			if (symbolOperator3 != null)
			{
				SymbolOperator symbolOperator4 = symbolOperator3;
				return IntrinsicFunctions.UnboxGeneric<SymbolOperator>((object)symbolOperator4.ComposedWith(symbol));
			}
			return symbolOperator2;
		}

		[CompilerGenerated]
		internal static long nameId()
		{
			if (init_004021_002D10 < 1)
			{
				IntrinsicFunctions.FailStaticInit();
			}
			return Interlocked.Increment(ref count);
		}

		static Symbol()
		{
			_0024Symbol.init_0040 = 0;
			_ = _0024Symbol.init_0040;
		}
	}
}
