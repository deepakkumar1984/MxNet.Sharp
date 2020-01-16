using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MXNetSharp
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class Util
	{
		[Serializable]
		internal sealed class convertArray_0040465 : FSharpFunc<double, float>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040465()
			{
			}

			public override float Invoke(double value)
			{
				return (float)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040465_002D1 : FSharpFunc<int, float>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040465_002D1()
			{
			}

			public override float Invoke(int value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040465_002D2 : FSharpFunc<long, float>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040465_002D2()
			{
			}

			public override float Invoke(long value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040465_002D3 : FSharpFunc<decimal, float>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040465_002D3()
			{
			}

			public override float Invoke(decimal value)
			{
				return (float)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040465_002D4 : FSharpFunc<sbyte, float>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040465_002D4()
			{
			}

			public override float Invoke(sbyte value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040465_002D5 : FSharpFunc<byte, float>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040465_002D5()
			{
			}

			public override float Invoke(byte value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040465_002D6 : FSharpFunc<bool, float>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040465_002D6()
			{
			}

			public override float Invoke(bool x)
			{
				if (x)
				{
					return 1f;
				}
				return 0f;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040465_002D7<a> : FSharpFunc<a, float>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040465_002D7()
			{
			}

			public override float Invoke(a x)
			{
				return (float)Convert.ChangeType(x, typeof(float));
			}
		}

		[Serializable]
		internal sealed class convertArray_0040466_002D8 : FSharpFunc<float, double>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040466_002D8()
			{
			}

			public override double Invoke(float value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040466_002D9 : FSharpFunc<int, double>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040466_002D9()
			{
			}

			public override double Invoke(int value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040466_002D10 : FSharpFunc<long, double>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040466_002D10()
			{
			}

			public override double Invoke(long value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040466_002D11 : FSharpFunc<decimal, double>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040466_002D11()
			{
			}

			public override double Invoke(decimal value)
			{
				return Convert.ToDouble(value);
			}
		}

		[Serializable]
		internal sealed class convertArray_0040466_002D12 : FSharpFunc<sbyte, double>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040466_002D12()
			{
			}

			public override double Invoke(sbyte value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040466_002D13 : FSharpFunc<byte, double>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040466_002D13()
			{
			}

			public override double Invoke(byte value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040466_002D14 : FSharpFunc<bool, double>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040466_002D14()
			{
			}

			public override double Invoke(bool x)
			{
				if (x)
				{
					return 1.0;
				}
				return 0.0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040466_002D15<a> : FSharpFunc<a, double>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040466_002D15()
			{
			}

			public override double Invoke(a x)
			{
				return (double)Convert.ChangeType(x, typeof(double));
			}
		}

		[Serializable]
		internal sealed class convertArray_0040467_002D16 : FSharpFunc<float, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040467_002D16()
			{
			}

			public override int Invoke(float value)
			{
				return (int)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040467_002D17 : FSharpFunc<double, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040467_002D17()
			{
			}

			public override int Invoke(double value)
			{
				return (int)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040467_002D18 : FSharpFunc<long, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040467_002D18()
			{
			}

			public override int Invoke(long value)
			{
				return (int)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040467_002D19 : FSharpFunc<decimal, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040467_002D19()
			{
			}

			public override int Invoke(decimal value)
			{
				return (int)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040467_002D20 : FSharpFunc<sbyte, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040467_002D20()
			{
			}

			public override int Invoke(sbyte value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040467_002D21 : FSharpFunc<byte, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040467_002D21()
			{
			}

			public override int Invoke(byte value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040467_002D22 : FSharpFunc<bool, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040467_002D22()
			{
			}

			public override int Invoke(bool x)
			{
				if (x)
				{
					return 1;
				}
				return 0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040467_002D23<a> : FSharpFunc<a, int>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040467_002D23()
			{
			}

			public override int Invoke(a x)
			{
				return (int)Convert.ChangeType(x, typeof(int));
			}
		}

		[Serializable]
		internal sealed class convertArray_0040468_002D24 : FSharpFunc<float, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040468_002D24()
			{
			}

			public override long Invoke(float value)
			{
				return (long)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040468_002D25 : FSharpFunc<double, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040468_002D25()
			{
			}

			public override long Invoke(double value)
			{
				return (long)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040468_002D26 : FSharpFunc<int, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040468_002D26()
			{
			}

			public override long Invoke(int value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040468_002D27 : FSharpFunc<decimal, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040468_002D27()
			{
			}

			public override long Invoke(decimal value)
			{
				return (long)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040468_002D28 : FSharpFunc<sbyte, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040468_002D28()
			{
			}

			public override long Invoke(sbyte value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040468_002D29 : FSharpFunc<byte, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040468_002D29()
			{
			}

			public override long Invoke(byte value)
			{
				return value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040468_002D30 : FSharpFunc<bool, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040468_002D30()
			{
			}

			public override long Invoke(bool x)
			{
				if (x)
				{
					return 1L;
				}
				return 0L;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040468_002D31<a> : FSharpFunc<a, long>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040468_002D31()
			{
			}

			public override long Invoke(a x)
			{
				return (long)Convert.ChangeType(x, typeof(long));
			}
		}

		[Serializable]
		internal sealed class convertArray_0040469_002D32 : FSharpFunc<float, sbyte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040469_002D32()
			{
			}

			public override sbyte Invoke(float value)
			{
				return (sbyte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040469_002D33 : FSharpFunc<double, sbyte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040469_002D33()
			{
			}

			public override sbyte Invoke(double value)
			{
				return (sbyte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040469_002D34 : FSharpFunc<int, sbyte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040469_002D34()
			{
			}

			public override sbyte Invoke(int value)
			{
				return (sbyte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040469_002D35 : FSharpFunc<long, sbyte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040469_002D35()
			{
			}

			public override sbyte Invoke(long value)
			{
				return (sbyte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040469_002D36 : FSharpFunc<decimal, sbyte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040469_002D36()
			{
			}

			public override sbyte Invoke(decimal value)
			{
				return (sbyte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040469_002D37 : FSharpFunc<byte, sbyte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040469_002D37()
			{
			}

			public override sbyte Invoke(byte value)
			{
				return (sbyte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040469_002D38 : FSharpFunc<bool, sbyte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040469_002D38()
			{
			}

			public override sbyte Invoke(bool x)
			{
				if (x)
				{
					return 1;
				}
				return 0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040469_002D39<a> : FSharpFunc<a, sbyte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040469_002D39()
			{
			}

			public override sbyte Invoke(a x)
			{
				return (sbyte)Convert.ChangeType(x, typeof(sbyte));
			}
		}

		[Serializable]
		internal sealed class convertArray_0040470_002D40 : FSharpFunc<float, byte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040470_002D40()
			{
			}

			public override byte Invoke(float value)
			{
				return (byte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040470_002D41 : FSharpFunc<double, byte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040470_002D41()
			{
			}

			public override byte Invoke(double value)
			{
				return (byte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040470_002D42 : FSharpFunc<int, byte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040470_002D42()
			{
			}

			public override byte Invoke(int value)
			{
				return (byte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040470_002D43 : FSharpFunc<long, byte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040470_002D43()
			{
			}

			public override byte Invoke(long value)
			{
				return (byte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040470_002D44 : FSharpFunc<decimal, byte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040470_002D44()
			{
			}

			public override byte Invoke(decimal value)
			{
				return (byte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040470_002D45 : FSharpFunc<sbyte, byte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040470_002D45()
			{
			}

			public override byte Invoke(sbyte value)
			{
				return (byte)value;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040470_002D46 : FSharpFunc<bool, byte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040470_002D46()
			{
			}

			public override byte Invoke(bool x)
			{
				if (x)
				{
					return 1;
				}
				return 0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040470_002D47<a> : FSharpFunc<a, byte>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040470_002D47()
			{
			}

			public override byte Invoke(a x)
			{
				return (byte)Convert.ChangeType(x, typeof(byte));
			}
		}

		[Serializable]
		internal sealed class convertArray_0040471_002D48 : FSharpFunc<float, bool>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040471_002D48()
			{
			}

			public override bool Invoke(float x)
			{
				return x != 0f;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040471_002D49 : FSharpFunc<double, bool>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040471_002D49()
			{
			}

			public override bool Invoke(double x)
			{
				return x != 0.0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040471_002D50 : FSharpFunc<int, bool>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040471_002D50()
			{
			}

			public override bool Invoke(int x)
			{
				return x != 0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040471_002D51 : FSharpFunc<long, bool>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040471_002D51()
			{
			}

			public override bool Invoke(long x)
			{
				return x != 0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040471_002D52 : FSharpFunc<decimal, bool>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040471_002D52()
			{
			}

			public override bool Invoke(decimal x)
			{
				return !(x == 0m);
			}
		}

		[Serializable]
		internal sealed class convertArray_0040471_002D53 : FSharpFunc<sbyte, bool>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040471_002D53()
			{
			}

			public override bool Invoke(sbyte x)
			{
				return x != 0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040471_002D54 : FSharpFunc<byte, bool>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040471_002D54()
			{
			}

			public override bool Invoke(byte x)
			{
				return x != 0;
			}
		}

		[Serializable]
		internal sealed class convertArray_0040471_002D55<a> : FSharpFunc<a, bool>
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal convertArray_0040471_002D55()
			{
			}

			public override bool Invoke(a x)
			{
				return (bool)Convert.ChangeType(x, typeof(bool));
			}
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		internal static string valueStringHelper<a, b>(a _arg1, b x)
		{
			throw new NotSupportedException("Dynamic invocation of ValueString is not supported");
		}

		public static string valueString<t>(t x)
		{
			ValueStringExtensions valueStringExtensions = ValueStringExtensions.ValueStringExtensions;
			ValueStringExtensions valueStringExtensions2 = valueStringExtensions;
			return ValueStringExtensions.ValueString(x);
		}

		[CompilationArgumentCounts(new int[]
		{
			1,
			1
		})]
		public static Array convertArray<a>(a[] a, DataType dtype)
		{
			switch (dtype.Tag)
			{
			default:
			{
				string text = "float16 not supported yet";
				throw Operators.Failure(text);
			}
			case 1:
			{
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
				{
					return (float[])(object)a;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
				{
					double[] array88 = (double[])(object)a;
					double[] array89 = array88;
					FSharpFunc<double, float> val25 = new convertArray_0040465();
					double[] array90 = array89;
					if (array90 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array91 = new float[array90.Length];
					for (int num19 = 0; num19 < array91.Length; num19++)
					{
						array91[num19] = val25.Invoke(array90[num19]);
					}
					return array91;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
				{
					int[] array92 = (int[])(object)a;
					int[] array93 = array92;
					FSharpFunc<int, float> val26 = new convertArray_0040465_002D1();
					int[] array94 = array93;
					if (array94 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array95 = new float[array94.Length];
					for (int num20 = 0; num20 < array95.Length; num20++)
					{
						array95[num20] = val26.Invoke(array94[num20]);
					}
					return array95;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
				{
					long[] array96 = (long[])(object)a;
					long[] array97 = array96;
					FSharpFunc<long, float> val27 = new convertArray_0040465_002D2();
					long[] array98 = array97;
					if (array98 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array99 = new float[array98.Length];
					for (int num21 = 0; num21 < array99.Length; num21++)
					{
						array99[num21] = val27.Invoke(array98[num21]);
					}
					return array99;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
				{
					decimal[] array100 = (decimal[])(object)a;
					decimal[] array101 = array100;
					FSharpFunc<decimal, float> val28 = new convertArray_0040465_002D3();
					decimal[] array102 = array101;
					if (array102 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array103 = new float[array102.Length];
					for (int num22 = 0; num22 < array103.Length; num22++)
					{
						array103[num22] = val28.Invoke(array102[num22]);
					}
					return array103;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
				{
					sbyte[] array104 = (sbyte[])(object)a;
					sbyte[] array105 = array104;
					FSharpFunc<sbyte, float> val29 = new convertArray_0040465_002D4();
					sbyte[] array106 = array105;
					if (array106 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array107 = new float[array106.Length];
					for (int num23 = 0; num23 < array107.Length; num23++)
					{
						array107[num23] = val29.Invoke(array106[num23]);
					}
					return array107;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
				{
					byte[] array108 = (byte[])(object)a;
					byte[] array109 = array108;
					FSharpFunc<byte, float> val30 = new convertArray_0040465_002D5();
					byte[] array110 = array109;
					if (array110 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array111 = new float[array110.Length];
					for (int num24 = 0; num24 < array111.Length; num24++)
					{
						array111[num24] = val30.Invoke(array110[num24]);
					}
					return array111;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
				{
					bool[] array112 = (bool[])(object)a;
					bool[] array113 = array112;
					FSharpFunc<bool, float> val31 = new convertArray_0040465_002D6();
					bool[] array114 = array113;
					if (array114 == null)
					{
						throw new ArgumentNullException("array");
					}
					float[] array115 = new float[array114.Length];
					for (int num25 = 0; num25 < array115.Length; num25++)
					{
						array115[num25] = val31.Invoke(array114[num25]);
					}
					return array115;
				}
				FSharpFunc<a, float> val32 = new convertArray_0040465_002D7<a>();
				if (a == null)
				{
					throw new ArgumentNullException("array");
				}
				float[] array116 = new float[a.Length];
				for (int num26 = 0; num26 < array116.Length; num26++)
				{
					array116[num26] = val32.Invoke(a[num26]);
				}
				return array116;
			}
			case 2:
			{
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
				{
					float[] array117 = (float[])(object)a;
					float[] array118 = array117;
					FSharpFunc<float, double> val33 = new convertArray_0040466_002D8();
					float[] array119 = array118;
					if (array119 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array120 = new double[array119.Length];
					for (int num27 = 0; num27 < array120.Length; num27++)
					{
						array120[num27] = val33.Invoke(array119[num27]);
					}
					return array120;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
				{
					return (double[])(object)a;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
				{
					int[] array121 = (int[])(object)a;
					int[] array122 = array121;
					FSharpFunc<int, double> val34 = new convertArray_0040466_002D9();
					int[] array123 = array122;
					if (array123 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array124 = new double[array123.Length];
					for (int num28 = 0; num28 < array124.Length; num28++)
					{
						array124[num28] = val34.Invoke(array123[num28]);
					}
					return array124;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
				{
					long[] array125 = (long[])(object)a;
					long[] array126 = array125;
					FSharpFunc<long, double> val35 = new convertArray_0040466_002D10();
					long[] array127 = array126;
					if (array127 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array128 = new double[array127.Length];
					for (int num29 = 0; num29 < array128.Length; num29++)
					{
						array128[num29] = val35.Invoke(array127[num29]);
					}
					return array128;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
				{
					decimal[] array129 = (decimal[])(object)a;
					decimal[] array130 = array129;
					FSharpFunc<decimal, double> val36 = new convertArray_0040466_002D11();
					decimal[] array131 = array130;
					if (array131 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array132 = new double[array131.Length];
					for (int num30 = 0; num30 < array132.Length; num30++)
					{
						array132[num30] = val36.Invoke(array131[num30]);
					}
					return array132;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
				{
					sbyte[] array133 = (sbyte[])(object)a;
					sbyte[] array134 = array133;
					FSharpFunc<sbyte, double> val37 = new convertArray_0040466_002D12();
					sbyte[] array135 = array134;
					if (array135 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array136 = new double[array135.Length];
					for (int num31 = 0; num31 < array136.Length; num31++)
					{
						array136[num31] = val37.Invoke(array135[num31]);
					}
					return array136;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
				{
					byte[] array137 = (byte[])(object)a;
					byte[] array138 = array137;
					FSharpFunc<byte, double> val38 = new convertArray_0040466_002D13();
					byte[] array139 = array138;
					if (array139 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array140 = new double[array139.Length];
					for (int num32 = 0; num32 < array140.Length; num32++)
					{
						array140[num32] = val38.Invoke(array139[num32]);
					}
					return array140;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
				{
					bool[] array141 = (bool[])(object)a;
					bool[] array142 = array141;
					FSharpFunc<bool, double> val39 = new convertArray_0040466_002D14();
					bool[] array143 = array142;
					if (array143 == null)
					{
						throw new ArgumentNullException("array");
					}
					double[] array144 = new double[array143.Length];
					for (int num33 = 0; num33 < array144.Length; num33++)
					{
						array144[num33] = val39.Invoke(array143[num33]);
					}
					return array144;
				}
				FSharpFunc<a, double> val40 = new convertArray_0040466_002D15<a>();
				if (a == null)
				{
					throw new ArgumentNullException("array");
				}
				double[] array145 = new double[a.Length];
				for (int num34 = 0; num34 < array145.Length; num34++)
				{
					array145[num34] = val40.Invoke(a[num34]);
				}
				return array145;
			}
			case 3:
			{
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
				{
					float[] array175 = (float[])(object)a;
					float[] array176 = array175;
					FSharpFunc<float, int> val49 = new convertArray_0040467_002D16();
					float[] array177 = array176;
					if (array177 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array178 = new int[array177.Length];
					for (int num43 = 0; num43 < array178.Length; num43++)
					{
						array178[num43] = val49.Invoke(array177[num43]);
					}
					return array178;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
				{
					double[] array179 = (double[])(object)a;
					double[] array180 = array179;
					FSharpFunc<double, int> val50 = new convertArray_0040467_002D17();
					double[] array181 = array180;
					if (array181 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array182 = new int[array181.Length];
					for (int num44 = 0; num44 < array182.Length; num44++)
					{
						array182[num44] = val50.Invoke(array181[num44]);
					}
					return array182;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
				{
					return (int[])(object)a;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
				{
					long[] array183 = (long[])(object)a;
					long[] array184 = array183;
					FSharpFunc<long, int> val51 = new convertArray_0040467_002D18();
					long[] array185 = array184;
					if (array185 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array186 = new int[array185.Length];
					for (int num45 = 0; num45 < array186.Length; num45++)
					{
						array186[num45] = val51.Invoke(array185[num45]);
					}
					return array186;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
				{
					decimal[] array187 = (decimal[])(object)a;
					decimal[] array188 = array187;
					FSharpFunc<decimal, int> val52 = new convertArray_0040467_002D19();
					decimal[] array189 = array188;
					if (array189 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array190 = new int[array189.Length];
					for (int num46 = 0; num46 < array190.Length; num46++)
					{
						array190[num46] = val52.Invoke(array189[num46]);
					}
					return array190;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
				{
					sbyte[] array191 = (sbyte[])(object)a;
					sbyte[] array192 = array191;
					FSharpFunc<sbyte, int> val53 = new convertArray_0040467_002D20();
					sbyte[] array193 = array192;
					if (array193 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array194 = new int[array193.Length];
					for (int num47 = 0; num47 < array194.Length; num47++)
					{
						array194[num47] = val53.Invoke(array193[num47]);
					}
					return array194;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
				{
					byte[] array195 = (byte[])(object)a;
					byte[] array196 = array195;
					FSharpFunc<byte, int> val54 = new convertArray_0040467_002D21();
					byte[] array197 = array196;
					if (array197 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array198 = new int[array197.Length];
					for (int num48 = 0; num48 < array198.Length; num48++)
					{
						array198[num48] = val54.Invoke(array197[num48]);
					}
					return array198;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
				{
					bool[] array199 = (bool[])(object)a;
					bool[] array200 = array199;
					FSharpFunc<bool, int> val55 = new convertArray_0040467_002D22();
					bool[] array201 = array200;
					if (array201 == null)
					{
						throw new ArgumentNullException("array");
					}
					int[] array202 = new int[array201.Length];
					for (int num49 = 0; num49 < array202.Length; num49++)
					{
						array202[num49] = val55.Invoke(array201[num49]);
					}
					return array202;
				}
				FSharpFunc<a, int> val56 = new convertArray_0040467_002D23<a>();
				if (a == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array203 = new int[a.Length];
				for (int num50 = 0; num50 < array203.Length; num50++)
				{
					array203[num50] = val56.Invoke(a[num50]);
				}
				return array203;
			}
			case 4:
			{
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
				{
					float[] array59 = (float[])(object)a;
					float[] array60 = array59;
					FSharpFunc<float, long> val17 = new convertArray_0040468_002D24();
					float[] array61 = array60;
					if (array61 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array62 = new long[array61.Length];
					for (int num11 = 0; num11 < array62.Length; num11++)
					{
						array62[num11] = val17.Invoke(array61[num11]);
					}
					return array62;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
				{
					double[] array63 = (double[])(object)a;
					double[] array64 = array63;
					FSharpFunc<double, long> val18 = new convertArray_0040468_002D25();
					double[] array65 = array64;
					if (array65 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array66 = new long[array65.Length];
					for (int num12 = 0; num12 < array66.Length; num12++)
					{
						array66[num12] = val18.Invoke(array65[num12]);
					}
					return array66;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
				{
					int[] array67 = (int[])(object)a;
					int[] array68 = array67;
					FSharpFunc<int, long> val19 = new convertArray_0040468_002D26();
					int[] array69 = array68;
					if (array69 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array70 = new long[array69.Length];
					for (int num13 = 0; num13 < array70.Length; num13++)
					{
						array70[num13] = val19.Invoke(array69[num13]);
					}
					return array70;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
				{
					return (long[])(object)a;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
				{
					decimal[] array71 = (decimal[])(object)a;
					decimal[] array72 = array71;
					FSharpFunc<decimal, long> val20 = new convertArray_0040468_002D27();
					decimal[] array73 = array72;
					if (array73 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array74 = new long[array73.Length];
					for (int num14 = 0; num14 < array74.Length; num14++)
					{
						array74[num14] = val20.Invoke(array73[num14]);
					}
					return array74;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
				{
					sbyte[] array75 = (sbyte[])(object)a;
					sbyte[] array76 = array75;
					FSharpFunc<sbyte, long> val21 = new convertArray_0040468_002D28();
					sbyte[] array77 = array76;
					if (array77 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array78 = new long[array77.Length];
					for (int num15 = 0; num15 < array78.Length; num15++)
					{
						array78[num15] = val21.Invoke(array77[num15]);
					}
					return array78;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
				{
					byte[] array79 = (byte[])(object)a;
					byte[] array80 = array79;
					FSharpFunc<byte, long> val22 = new convertArray_0040468_002D29();
					byte[] array81 = array80;
					if (array81 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array82 = new long[array81.Length];
					for (int num16 = 0; num16 < array82.Length; num16++)
					{
						array82[num16] = val22.Invoke(array81[num16]);
					}
					return array82;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
				{
					bool[] array83 = (bool[])(object)a;
					bool[] array84 = array83;
					FSharpFunc<bool, long> val23 = new convertArray_0040468_002D30();
					bool[] array85 = array84;
					if (array85 == null)
					{
						throw new ArgumentNullException("array");
					}
					long[] array86 = new long[array85.Length];
					for (int num17 = 0; num17 < array86.Length; num17++)
					{
						array86[num17] = val23.Invoke(array85[num17]);
					}
					return array86;
				}
				FSharpFunc<a, long> val24 = new convertArray_0040468_002D31<a>();
				if (a == null)
				{
					throw new ArgumentNullException("array");
				}
				long[] array87 = new long[a.Length];
				for (int num18 = 0; num18 < array87.Length; num18++)
				{
					array87[num18] = val24.Invoke(a[num18]);
				}
				return array87;
			}
			case 5:
			{
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
				{
					float[] array146 = (float[])(object)a;
					float[] array147 = array146;
					FSharpFunc<float, sbyte> val41 = new convertArray_0040469_002D32();
					float[] array148 = array147;
					if (array148 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array149 = new sbyte[array148.Length];
					for (int num35 = 0; num35 < array149.Length; num35++)
					{
						array149[num35] = val41.Invoke(array148[num35]);
					}
					return array149;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
				{
					double[] array150 = (double[])(object)a;
					double[] array151 = array150;
					FSharpFunc<double, sbyte> val42 = new convertArray_0040469_002D33();
					double[] array152 = array151;
					if (array152 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array153 = new sbyte[array152.Length];
					for (int num36 = 0; num36 < array153.Length; num36++)
					{
						array153[num36] = val42.Invoke(array152[num36]);
					}
					return array153;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
				{
					int[] array154 = (int[])(object)a;
					int[] array155 = array154;
					FSharpFunc<int, sbyte> val43 = new convertArray_0040469_002D34();
					int[] array156 = array155;
					if (array156 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array157 = new sbyte[array156.Length];
					for (int num37 = 0; num37 < array157.Length; num37++)
					{
						array157[num37] = val43.Invoke(array156[num37]);
					}
					return array157;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
				{
					long[] array158 = (long[])(object)a;
					long[] array159 = array158;
					FSharpFunc<long, sbyte> val44 = new convertArray_0040469_002D35();
					long[] array160 = array159;
					if (array160 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array161 = new sbyte[array160.Length];
					for (int num38 = 0; num38 < array161.Length; num38++)
					{
						array161[num38] = val44.Invoke(array160[num38]);
					}
					return array161;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
				{
					decimal[] array162 = (decimal[])(object)a;
					decimal[] array163 = array162;
					FSharpFunc<decimal, sbyte> val45 = new convertArray_0040469_002D36();
					decimal[] array164 = array163;
					if (array164 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array165 = new sbyte[array164.Length];
					for (int num39 = 0; num39 < array165.Length; num39++)
					{
						array165[num39] = val45.Invoke(array164[num39]);
					}
					return array165;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
				{
					return (sbyte[])(object)a;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
				{
					byte[] array166 = (byte[])(object)a;
					byte[] array167 = array166;
					FSharpFunc<byte, sbyte> val46 = new convertArray_0040469_002D37();
					byte[] array168 = array167;
					if (array168 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array169 = new sbyte[array168.Length];
					for (int num40 = 0; num40 < array169.Length; num40++)
					{
						array169[num40] = val46.Invoke(array168[num40]);
					}
					return array169;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
				{
					bool[] array170 = (bool[])(object)a;
					bool[] array171 = array170;
					FSharpFunc<bool, sbyte> val47 = new convertArray_0040469_002D38();
					bool[] array172 = array171;
					if (array172 == null)
					{
						throw new ArgumentNullException("array");
					}
					sbyte[] array173 = new sbyte[array172.Length];
					for (int num41 = 0; num41 < array173.Length; num41++)
					{
						array173[num41] = val47.Invoke(array172[num41]);
					}
					return array173;
				}
				FSharpFunc<a, sbyte> val48 = new convertArray_0040469_002D39<a>();
				if (a == null)
				{
					throw new ArgumentNullException("array");
				}
				sbyte[] array174 = new sbyte[a.Length];
				for (int num42 = 0; num42 < array174.Length; num42++)
				{
					array174[num42] = val48.Invoke(a[num42]);
				}
				return array174;
			}
			case 6:
			{
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
				{
					float[] array30 = (float[])(object)a;
					float[] array31 = array30;
					FSharpFunc<float, byte> val9 = new convertArray_0040470_002D40();
					float[] array32 = array31;
					if (array32 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array33 = new byte[array32.Length];
					for (int num3 = 0; num3 < array33.Length; num3++)
					{
						array33[num3] = val9.Invoke(array32[num3]);
					}
					return array33;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
				{
					double[] array34 = (double[])(object)a;
					double[] array35 = array34;
					FSharpFunc<double, byte> val10 = new convertArray_0040470_002D41();
					double[] array36 = array35;
					if (array36 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array37 = new byte[array36.Length];
					for (int num4 = 0; num4 < array37.Length; num4++)
					{
						array37[num4] = val10.Invoke(array36[num4]);
					}
					return array37;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
				{
					int[] array38 = (int[])(object)a;
					int[] array39 = array38;
					FSharpFunc<int, byte> val11 = new convertArray_0040470_002D42();
					int[] array40 = array39;
					if (array40 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array41 = new byte[array40.Length];
					for (int num5 = 0; num5 < array41.Length; num5++)
					{
						array41[num5] = val11.Invoke(array40[num5]);
					}
					return array41;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
				{
					long[] array42 = (long[])(object)a;
					long[] array43 = array42;
					FSharpFunc<long, byte> val12 = new convertArray_0040470_002D43();
					long[] array44 = array43;
					if (array44 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array45 = new byte[array44.Length];
					for (int num6 = 0; num6 < array45.Length; num6++)
					{
						array45[num6] = val12.Invoke(array44[num6]);
					}
					return array45;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
				{
					decimal[] array46 = (decimal[])(object)a;
					decimal[] array47 = array46;
					FSharpFunc<decimal, byte> val13 = new convertArray_0040470_002D44();
					decimal[] array48 = array47;
					if (array48 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array49 = new byte[array48.Length];
					for (int num7 = 0; num7 < array49.Length; num7++)
					{
						array49[num7] = val13.Invoke(array48[num7]);
					}
					return array49;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
				{
					sbyte[] array50 = (sbyte[])(object)a;
					sbyte[] array51 = array50;
					FSharpFunc<sbyte, byte> val14 = new convertArray_0040470_002D45();
					sbyte[] array52 = array51;
					if (array52 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array53 = new byte[array52.Length];
					for (int num8 = 0; num8 < array53.Length; num8++)
					{
						array53[num8] = val14.Invoke(array52[num8]);
					}
					return array53;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
				{
					return (byte[])(object)a;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
				{
					bool[] array54 = (bool[])(object)a;
					bool[] array55 = array54;
					FSharpFunc<bool, byte> val15 = new convertArray_0040470_002D46();
					bool[] array56 = array55;
					if (array56 == null)
					{
						throw new ArgumentNullException("array");
					}
					byte[] array57 = new byte[array56.Length];
					for (int num9 = 0; num9 < array57.Length; num9++)
					{
						array57[num9] = val15.Invoke(array56[num9]);
					}
					return array57;
				}
				FSharpFunc<a, byte> val16 = new convertArray_0040470_002D47<a>();
				if (a == null)
				{
					throw new ArgumentNullException("array");
				}
				byte[] array58 = new byte[a.Length];
				for (int num10 = 0; num10 < array58.Length; num10++)
				{
					array58[num10] = val16.Invoke(a[num10]);
				}
				return array58;
			}
			case 7:
			{
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
				{
					float[] array = (float[])(object)a;
					float[] array2 = array;
					FSharpFunc<float, bool> val = new convertArray_0040471_002D48();
					float[] array3 = array2;
					if (array3 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array4 = new bool[array3.Length];
					for (int i = 0; i < array4.Length; i++)
					{
						array4[i] = val.Invoke(array3[i]);
					}
					return array4;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
				{
					double[] array5 = (double[])(object)a;
					double[] array6 = array5;
					FSharpFunc<double, bool> val2 = new convertArray_0040471_002D49();
					double[] array7 = array6;
					if (array7 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array8 = new bool[array7.Length];
					for (int j = 0; j < array8.Length; j++)
					{
						array8[j] = val2.Invoke(array7[j]);
					}
					return array8;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
				{
					int[] array9 = (int[])(object)a;
					int[] array10 = array9;
					FSharpFunc<int, bool> val3 = new convertArray_0040471_002D50();
					int[] array11 = array10;
					if (array11 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array12 = new bool[array11.Length];
					for (int k = 0; k < array12.Length; k++)
					{
						array12[k] = val3.Invoke(array11[k]);
					}
					return array12;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
				{
					long[] array13 = (long[])(object)a;
					long[] array14 = array13;
					FSharpFunc<long, bool> val4 = new convertArray_0040471_002D51();
					long[] array15 = array14;
					if (array15 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array16 = new bool[array15.Length];
					for (int l = 0; l < array16.Length; l++)
					{
						array16[l] = val4.Invoke(array15[l]);
					}
					return array16;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
				{
					decimal[] array17 = (decimal[])(object)a;
					decimal[] array18 = array17;
					FSharpFunc<decimal, bool> val5 = new convertArray_0040471_002D52();
					decimal[] array19 = array18;
					if (array19 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array20 = new bool[array19.Length];
					for (int m = 0; m < array20.Length; m++)
					{
						array20[m] = val5.Invoke(array19[m]);
					}
					return array20;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
				{
					sbyte[] array21 = (sbyte[])(object)a;
					sbyte[] array22 = array21;
					FSharpFunc<sbyte, bool> val6 = new convertArray_0040471_002D53();
					sbyte[] array23 = array22;
					if (array23 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array24 = new bool[array23.Length];
					for (int n = 0; n < array24.Length; n++)
					{
						array24[n] = val6.Invoke(array23[n]);
					}
					return array24;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
				{
					byte[] array25 = (byte[])(object)a;
					byte[] array26 = array25;
					FSharpFunc<byte, bool> val7 = new convertArray_0040471_002D54();
					byte[] array27 = array26;
					if (array27 == null)
					{
						throw new ArgumentNullException("array");
					}
					bool[] array28 = new bool[array27.Length];
					for (int num = 0; num < array28.Length; num++)
					{
						array28[num] = val7.Invoke(array27[num]);
					}
					return array28;
				}
				if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
				{
					return (bool[])(object)a;
				}
				FSharpFunc<a, bool> val8 = new convertArray_0040471_002D55<a>();
				if (a == null)
				{
					throw new ArgumentNullException("array");
				}
				bool[] array29 = new bool[a.Length];
				for (int num2 = 0; num2 < array29.Length; num2++)
				{
					array29[num2] = val8.Invoke(a[num2]);
				}
				return array29;
			}
			}
		}
	}
}
