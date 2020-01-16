using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class ArrayConverter
	{
		internal ArrayConverter()
		{
		}

		public static float[] Float32(float[] a)
		{
			return a;
		}

		public static float[] Float32(double[] a)
		{
			FSharpFunc<double, float> val = new _0024Coretypes.Float32_0040264();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			float[] array = new float[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static float[] Float32(int[] a)
		{
			FSharpFunc<int, float> val = new _0024Coretypes.Float32_0040265_002D1();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			float[] array = new float[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static float[] Float32(long[] a)
		{
			FSharpFunc<long, float> val = new _0024Coretypes.Float32_0040266_002D2();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			float[] array = new float[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static float[] Float32(decimal[] a)
		{
			FSharpFunc<decimal, float> val = new _0024Coretypes.Float32_0040267_002D3();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			float[] array = new float[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static float[] Float32(sbyte[] a)
		{
			FSharpFunc<sbyte, float> val = new _0024Coretypes.Float32_0040268_002D4();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			float[] array = new float[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static float[] Float32(byte[] a)
		{
			FSharpFunc<byte, float> val = new _0024Coretypes.Float32_0040269_002D5();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			float[] array = new float[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static float[] Float32(bool[] a)
		{
			FSharpFunc<bool, float> val = new _0024Coretypes.Float32_0040270_002D6();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			float[] array = new float[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static float[] Float32<a>(a[] a)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				return (float[])(object)a;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
			{
				double[] array = (double[])(object)a;
				double[] array2 = array;
				FSharpFunc<double, float> val = new _0024Coretypes.Float32_0040275_002D7();
				double[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				float[] array4 = new float[array3.Length];
				for (int i = 0; i < array4.Length; i++)
				{
					array4[i] = val.Invoke(array3[i]);
				}
				return array4;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
			{
				int[] array5 = (int[])(object)a;
				int[] array6 = array5;
				FSharpFunc<int, float> val2 = new _0024Coretypes.Float32_0040277_002D8();
				int[] array7 = array6;
				if (array7 == null)
				{
					throw new ArgumentNullException("array");
				}
				float[] array8 = new float[array7.Length];
				for (int j = 0; j < array8.Length; j++)
				{
					array8[j] = val2.Invoke(array7[j]);
				}
				return array8;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
			{
				long[] array9 = (long[])(object)a;
				long[] array10 = array9;
				FSharpFunc<long, float> val3 = new _0024Coretypes.Float32_0040279_002D9();
				long[] array11 = array10;
				if (array11 == null)
				{
					throw new ArgumentNullException("array");
				}
				float[] array12 = new float[array11.Length];
				for (int k = 0; k < array12.Length; k++)
				{
					array12[k] = val3.Invoke(array11[k]);
				}
				return array12;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
			{
				decimal[] array13 = (decimal[])(object)a;
				decimal[] array14 = array13;
				FSharpFunc<decimal, float> val4 = new _0024Coretypes.Float32_0040281_002D10();
				decimal[] array15 = array14;
				if (array15 == null)
				{
					throw new ArgumentNullException("array");
				}
				float[] array16 = new float[array15.Length];
				for (int l = 0; l < array16.Length; l++)
				{
					array16[l] = val4.Invoke(array15[l]);
				}
				return array16;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
			{
				sbyte[] array17 = (sbyte[])(object)a;
				sbyte[] array18 = array17;
				FSharpFunc<sbyte, float> val5 = new _0024Coretypes.Float32_0040283_002D11();
				sbyte[] array19 = array18;
				if (array19 == null)
				{
					throw new ArgumentNullException("array");
				}
				float[] array20 = new float[array19.Length];
				for (int m = 0; m < array20.Length; m++)
				{
					array20[m] = val5.Invoke(array19[m]);
				}
				return array20;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
			{
				byte[] array21 = (byte[])(object)a;
				byte[] array22 = array21;
				FSharpFunc<byte, float> val6 = new _0024Coretypes.Float32_0040285_002D12();
				byte[] array23 = array22;
				if (array23 == null)
				{
					throw new ArgumentNullException("array");
				}
				float[] array24 = new float[array23.Length];
				for (int n = 0; n < array24.Length; n++)
				{
					array24[n] = val6.Invoke(array23[n]);
				}
				return array24;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
			{
				bool[] array25 = (bool[])(object)a;
				bool[] array26 = array25;
				FSharpFunc<bool, float> val7 = new _0024Coretypes.Float32_0040287_002D13();
				bool[] array27 = array26;
				if (array27 == null)
				{
					throw new ArgumentNullException("array");
				}
				float[] array28 = new float[array27.Length];
				for (int num = 0; num < array28.Length; num++)
				{
					array28[num] = val7.Invoke(array27[num]);
				}
				return array28;
			}
			FSharpFunc<a, float> val8 = new _0024Coretypes.Float32_0040289_002D14<a>();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			float[] array29 = new float[a.Length];
			for (int num2 = 0; num2 < array29.Length; num2++)
			{
				array29[num2] = val8.Invoke(a[num2]);
			}
			return array29;
		}

		public static double[] Float64(float[] a)
		{
			FSharpFunc<float, double> val = new _0024Coretypes.Float64_0040290();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			double[] array = new double[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static double[] Float64(double[] a)
		{
			return a;
		}

		public static double[] Float64(int[] a)
		{
			FSharpFunc<int, double> val = new _0024Coretypes.Float64_0040292_002D1();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			double[] array = new double[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static double[] Float64(long[] a)
		{
			FSharpFunc<long, double> val = new _0024Coretypes.Float64_0040293_002D2();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			double[] array = new double[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static double[] Float64(decimal[] a)
		{
			FSharpFunc<decimal, double> val = new _0024Coretypes.Float64_0040294_002D3();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			double[] array = new double[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static double[] Float64(sbyte[] a)
		{
			FSharpFunc<sbyte, double> val = new _0024Coretypes.Float64_0040295_002D4();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			double[] array = new double[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static double[] Float64(byte[] a)
		{
			FSharpFunc<byte, double> val = new _0024Coretypes.Float64_0040296_002D5();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			double[] array = new double[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static double[] Float64(bool[] a)
		{
			FSharpFunc<bool, double> val = new _0024Coretypes.Float64_0040297_002D6();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			double[] array = new double[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static double[] Float64<a>(a[] a)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				float[] array = (float[])(object)a;
				float[] array2 = array;
				FSharpFunc<float, double> val = new _0024Coretypes.Float64_0040300_002D7();
				float[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				double[] array4 = new double[array3.Length];
				for (int i = 0; i < array4.Length; i++)
				{
					array4[i] = val.Invoke(array3[i]);
				}
				return array4;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(double)))
			{
				return (double[])(object)a;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
			{
				int[] array5 = (int[])(object)a;
				int[] array6 = array5;
				FSharpFunc<int, double> val2 = new _0024Coretypes.Float64_0040304_002D8();
				int[] array7 = array6;
				if (array7 == null)
				{
					throw new ArgumentNullException("array");
				}
				double[] array8 = new double[array7.Length];
				for (int j = 0; j < array8.Length; j++)
				{
					array8[j] = val2.Invoke(array7[j]);
				}
				return array8;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
			{
				long[] array9 = (long[])(object)a;
				long[] array10 = array9;
				FSharpFunc<long, double> val3 = new _0024Coretypes.Float64_0040306_002D9();
				long[] array11 = array10;
				if (array11 == null)
				{
					throw new ArgumentNullException("array");
				}
				double[] array12 = new double[array11.Length];
				for (int k = 0; k < array12.Length; k++)
				{
					array12[k] = val3.Invoke(array11[k]);
				}
				return array12;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
			{
				decimal[] array13 = (decimal[])(object)a;
				decimal[] array14 = array13;
				FSharpFunc<decimal, double> val4 = new _0024Coretypes.Float64_0040308_002D10();
				decimal[] array15 = array14;
				if (array15 == null)
				{
					throw new ArgumentNullException("array");
				}
				double[] array16 = new double[array15.Length];
				for (int l = 0; l < array16.Length; l++)
				{
					array16[l] = val4.Invoke(array15[l]);
				}
				return array16;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
			{
				sbyte[] array17 = (sbyte[])(object)a;
				sbyte[] array18 = array17;
				FSharpFunc<sbyte, double> val5 = new _0024Coretypes.Float64_0040310_002D11();
				sbyte[] array19 = array18;
				if (array19 == null)
				{
					throw new ArgumentNullException("array");
				}
				double[] array20 = new double[array19.Length];
				for (int m = 0; m < array20.Length; m++)
				{
					array20[m] = val5.Invoke(array19[m]);
				}
				return array20;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
			{
				byte[] array21 = (byte[])(object)a;
				byte[] array22 = array21;
				FSharpFunc<byte, double> val6 = new _0024Coretypes.Float64_0040312_002D12();
				byte[] array23 = array22;
				if (array23 == null)
				{
					throw new ArgumentNullException("array");
				}
				double[] array24 = new double[array23.Length];
				for (int n = 0; n < array24.Length; n++)
				{
					array24[n] = val6.Invoke(array23[n]);
				}
				return array24;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
			{
				bool[] array25 = (bool[])(object)a;
				bool[] array26 = array25;
				FSharpFunc<bool, double> val7 = new _0024Coretypes.Float64_0040314_002D13();
				bool[] array27 = array26;
				if (array27 == null)
				{
					throw new ArgumentNullException("array");
				}
				double[] array28 = new double[array27.Length];
				for (int num = 0; num < array28.Length; num++)
				{
					array28[num] = val7.Invoke(array27[num]);
				}
				return array28;
			}
			FSharpFunc<a, double> val8 = new _0024Coretypes.Float64_0040316_002D14<a>();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			double[] array29 = new double[a.Length];
			for (int num2 = 0; num2 < array29.Length; num2++)
			{
				array29[num2] = val8.Invoke(a[num2]);
			}
			return array29;
		}

		public static int[] Int32(float[] a)
		{
			FSharpFunc<float, int> val = new _0024Coretypes.Int32_0040317();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array = new int[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static int[] Int32(double[] a)
		{
			FSharpFunc<double, int> val = new _0024Coretypes.Int32_0040318_002D1();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array = new int[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static int[] Int32(int[] a)
		{
			return a;
		}

		public static int[] Int32(long[] a)
		{
			FSharpFunc<long, int> val = new _0024Coretypes.Int32_0040320_002D2();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array = new int[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static int[] Int32(decimal[] a)
		{
			FSharpFunc<decimal, int> val = new _0024Coretypes.Int32_0040321_002D3();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array = new int[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static int[] Int32(sbyte[] a)
		{
			FSharpFunc<sbyte, int> val = new _0024Coretypes.Int32_0040322_002D4();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array = new int[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static int[] Int32(byte[] a)
		{
			FSharpFunc<byte, int> val = new _0024Coretypes.Int32_0040323_002D5();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array = new int[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static int[] Int32(bool[] a)
		{
			FSharpFunc<bool, int> val = new _0024Coretypes.Int32_0040324_002D6();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array = new int[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static int[] Int32<a>(a[] a)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				float[] array = (float[])(object)a;
				float[] array2 = array;
				FSharpFunc<float, int> val = new _0024Coretypes.Int32_0040327_002D7();
				float[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array4 = new int[array3.Length];
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
				FSharpFunc<double, int> val2 = new _0024Coretypes.Int32_0040329_002D8();
				double[] array7 = array6;
				if (array7 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array8 = new int[array7.Length];
				for (int j = 0; j < array8.Length; j++)
				{
					array8[j] = val2.Invoke(array7[j]);
				}
				return array8;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(int)))
			{
				return (int[])(object)a;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
			{
				long[] array9 = (long[])(object)a;
				long[] array10 = array9;
				FSharpFunc<long, int> val3 = new _0024Coretypes.Int32_0040333_002D9();
				long[] array11 = array10;
				if (array11 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array12 = new int[array11.Length];
				for (int k = 0; k < array12.Length; k++)
				{
					array12[k] = val3.Invoke(array11[k]);
				}
				return array12;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
			{
				decimal[] array13 = (decimal[])(object)a;
				decimal[] array14 = array13;
				FSharpFunc<decimal, int> val4 = new _0024Coretypes.Int32_0040335_002D10();
				decimal[] array15 = array14;
				if (array15 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array16 = new int[array15.Length];
				for (int l = 0; l < array16.Length; l++)
				{
					array16[l] = val4.Invoke(array15[l]);
				}
				return array16;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
			{
				sbyte[] array17 = (sbyte[])(object)a;
				sbyte[] array18 = array17;
				FSharpFunc<sbyte, int> val5 = new _0024Coretypes.Int32_0040337_002D11();
				sbyte[] array19 = array18;
				if (array19 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array20 = new int[array19.Length];
				for (int m = 0; m < array20.Length; m++)
				{
					array20[m] = val5.Invoke(array19[m]);
				}
				return array20;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
			{
				byte[] array21 = (byte[])(object)a;
				byte[] array22 = array21;
				FSharpFunc<byte, int> val6 = new _0024Coretypes.Int32_0040339_002D12();
				byte[] array23 = array22;
				if (array23 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array24 = new int[array23.Length];
				for (int n = 0; n < array24.Length; n++)
				{
					array24[n] = val6.Invoke(array23[n]);
				}
				return array24;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
			{
				bool[] array25 = (bool[])(object)a;
				bool[] array26 = array25;
				FSharpFunc<bool, int> val7 = new _0024Coretypes.Int32_0040341_002D13();
				bool[] array27 = array26;
				if (array27 == null)
				{
					throw new ArgumentNullException("array");
				}
				int[] array28 = new int[array27.Length];
				for (int num = 0; num < array28.Length; num++)
				{
					array28[num] = val7.Invoke(array27[num]);
				}
				return array28;
			}
			FSharpFunc<a, int> val8 = new _0024Coretypes.Int32_0040343_002D14<a>();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			int[] array29 = new int[a.Length];
			for (int num2 = 0; num2 < array29.Length; num2++)
			{
				array29[num2] = val8.Invoke(a[num2]);
			}
			return array29;
		}

		public static long[] Int64(float[] a)
		{
			FSharpFunc<float, long> val = new _0024Coretypes.Int64_0040344();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array = new long[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static long[] Int64(double[] a)
		{
			FSharpFunc<double, long> val = new _0024Coretypes.Int64_0040345_002D1();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array = new long[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static long[] Int64(int[] a)
		{
			FSharpFunc<int, long> val = new _0024Coretypes.Int64_0040346_002D2();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array = new long[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static long[] Int64(long[] a)
		{
			return a;
		}

		public static long[] Int64(decimal[] a)
		{
			FSharpFunc<decimal, long> val = new _0024Coretypes.Int64_0040348_002D3();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array = new long[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static long[] Int64(sbyte[] a)
		{
			FSharpFunc<sbyte, long> val = new _0024Coretypes.Int64_0040349_002D4();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array = new long[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static long[] Int64(byte[] a)
		{
			FSharpFunc<byte, long> val = new _0024Coretypes.Int64_0040350_002D5();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array = new long[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static long[] Int64(bool[] a)
		{
			FSharpFunc<bool, long> val = new _0024Coretypes.Int64_0040351_002D6();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array = new long[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static long[] Int64<a>(a[] a)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				float[] array = (float[])(object)a;
				float[] array2 = array;
				FSharpFunc<float, long> val = new _0024Coretypes.Int64_0040354_002D7();
				float[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				long[] array4 = new long[array3.Length];
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
				FSharpFunc<double, long> val2 = new _0024Coretypes.Int64_0040356_002D8();
				double[] array7 = array6;
				if (array7 == null)
				{
					throw new ArgumentNullException("array");
				}
				long[] array8 = new long[array7.Length];
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
				FSharpFunc<int, long> val3 = new _0024Coretypes.Int64_0040358_002D9();
				int[] array11 = array10;
				if (array11 == null)
				{
					throw new ArgumentNullException("array");
				}
				long[] array12 = new long[array11.Length];
				for (int k = 0; k < array12.Length; k++)
				{
					array12[k] = val3.Invoke(array11[k]);
				}
				return array12;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(long)))
			{
				return (long[])(object)a;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(decimal)))
			{
				decimal[] array13 = (decimal[])(object)a;
				decimal[] array14 = array13;
				FSharpFunc<decimal, long> val4 = new _0024Coretypes.Int64_0040362_002D10();
				decimal[] array15 = array14;
				if (array15 == null)
				{
					throw new ArgumentNullException("array");
				}
				long[] array16 = new long[array15.Length];
				for (int l = 0; l < array16.Length; l++)
				{
					array16[l] = val4.Invoke(array15[l]);
				}
				return array16;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
			{
				sbyte[] array17 = (sbyte[])(object)a;
				sbyte[] array18 = array17;
				FSharpFunc<sbyte, long> val5 = new _0024Coretypes.Int64_0040364_002D11();
				sbyte[] array19 = array18;
				if (array19 == null)
				{
					throw new ArgumentNullException("array");
				}
				long[] array20 = new long[array19.Length];
				for (int m = 0; m < array20.Length; m++)
				{
					array20[m] = val5.Invoke(array19[m]);
				}
				return array20;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
			{
				byte[] array21 = (byte[])(object)a;
				byte[] array22 = array21;
				FSharpFunc<byte, long> val6 = new _0024Coretypes.Int64_0040366_002D12();
				byte[] array23 = array22;
				if (array23 == null)
				{
					throw new ArgumentNullException("array");
				}
				long[] array24 = new long[array23.Length];
				for (int n = 0; n < array24.Length; n++)
				{
					array24[n] = val6.Invoke(array23[n]);
				}
				return array24;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
			{
				bool[] array25 = (bool[])(object)a;
				bool[] array26 = array25;
				FSharpFunc<bool, long> val7 = new _0024Coretypes.Int64_0040368_002D13();
				bool[] array27 = array26;
				if (array27 == null)
				{
					throw new ArgumentNullException("array");
				}
				long[] array28 = new long[array27.Length];
				for (int num = 0; num < array28.Length; num++)
				{
					array28[num] = val7.Invoke(array27[num]);
				}
				return array28;
			}
			FSharpFunc<a, long> val8 = new _0024Coretypes.Int64_0040370_002D14<a>();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			long[] array29 = new long[a.Length];
			for (int num2 = 0; num2 < array29.Length; num2++)
			{
				array29[num2] = val8.Invoke(a[num2]);
			}
			return array29;
		}

		public static sbyte[] Int8(float[] a)
		{
			FSharpFunc<float, sbyte> val = new _0024Coretypes.Int8_0040371();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			sbyte[] array = new sbyte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static sbyte[] Int8(double[] a)
		{
			FSharpFunc<double, sbyte> val = new _0024Coretypes.Int8_0040372_002D1();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			sbyte[] array = new sbyte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static sbyte[] Int8(int[] a)
		{
			FSharpFunc<int, sbyte> val = new _0024Coretypes.Int8_0040373_002D2();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			sbyte[] array = new sbyte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static sbyte[] Int8(long[] a)
		{
			FSharpFunc<long, sbyte> val = new _0024Coretypes.Int8_0040374_002D3();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			sbyte[] array = new sbyte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static sbyte[] Int8(decimal[] a)
		{
			FSharpFunc<decimal, sbyte> val = new _0024Coretypes.Int8_0040375_002D4();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			sbyte[] array = new sbyte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static sbyte[] Int8(sbyte[] a)
		{
			return a;
		}

		public static sbyte[] Int8(byte[] a)
		{
			FSharpFunc<byte, sbyte> val = new _0024Coretypes.Int8_0040377_002D5();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			sbyte[] array = new sbyte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static sbyte[] Int8(bool[] a)
		{
			FSharpFunc<bool, sbyte> val = new _0024Coretypes.Int8_0040378_002D6();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			sbyte[] array = new sbyte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static sbyte[] Int8<a>(a[] a)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				float[] array = (float[])(object)a;
				float[] array2 = array;
				FSharpFunc<float, sbyte> val = new _0024Coretypes.Int8_0040381_002D7();
				float[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				sbyte[] array4 = new sbyte[array3.Length];
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
				FSharpFunc<double, sbyte> val2 = new _0024Coretypes.Int8_0040383_002D8();
				double[] array7 = array6;
				if (array7 == null)
				{
					throw new ArgumentNullException("array");
				}
				sbyte[] array8 = new sbyte[array7.Length];
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
				FSharpFunc<int, sbyte> val3 = new _0024Coretypes.Int8_0040385_002D9();
				int[] array11 = array10;
				if (array11 == null)
				{
					throw new ArgumentNullException("array");
				}
				sbyte[] array12 = new sbyte[array11.Length];
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
				FSharpFunc<long, sbyte> val4 = new _0024Coretypes.Int8_0040387_002D10();
				long[] array15 = array14;
				if (array15 == null)
				{
					throw new ArgumentNullException("array");
				}
				sbyte[] array16 = new sbyte[array15.Length];
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
				FSharpFunc<decimal, sbyte> val5 = new _0024Coretypes.Int8_0040389_002D11();
				decimal[] array19 = array18;
				if (array19 == null)
				{
					throw new ArgumentNullException("array");
				}
				sbyte[] array20 = new sbyte[array19.Length];
				for (int m = 0; m < array20.Length; m++)
				{
					array20[m] = val5.Invoke(array19[m]);
				}
				return array20;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(sbyte)))
			{
				return (sbyte[])(object)a;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
			{
				byte[] array21 = (byte[])(object)a;
				byte[] array22 = array21;
				FSharpFunc<byte, sbyte> val6 = new _0024Coretypes.Int8_0040393_002D12();
				byte[] array23 = array22;
				if (array23 == null)
				{
					throw new ArgumentNullException("array");
				}
				sbyte[] array24 = new sbyte[array23.Length];
				for (int n = 0; n < array24.Length; n++)
				{
					array24[n] = val6.Invoke(array23[n]);
				}
				return array24;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
			{
				bool[] array25 = (bool[])(object)a;
				bool[] array26 = array25;
				FSharpFunc<bool, sbyte> val7 = new _0024Coretypes.Int8_0040395_002D13();
				bool[] array27 = array26;
				if (array27 == null)
				{
					throw new ArgumentNullException("array");
				}
				sbyte[] array28 = new sbyte[array27.Length];
				for (int num = 0; num < array28.Length; num++)
				{
					array28[num] = val7.Invoke(array27[num]);
				}
				return array28;
			}
			FSharpFunc<a, sbyte> val8 = new _0024Coretypes.Int8_0040397_002D14<a>();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			sbyte[] array29 = new sbyte[a.Length];
			for (int num2 = 0; num2 < array29.Length; num2++)
			{
				array29[num2] = val8.Invoke(a[num2]);
			}
			return array29;
		}

		public static byte[] UInt8(float[] a)
		{
			FSharpFunc<float, byte> val = new _0024Coretypes.UInt8_0040398();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			byte[] array = new byte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static byte[] UInt8(double[] a)
		{
			FSharpFunc<double, byte> val = new _0024Coretypes.UInt8_0040399_002D1();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			byte[] array = new byte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static byte[] UInt8(int[] a)
		{
			FSharpFunc<int, byte> val = new _0024Coretypes.UInt8_0040400_002D2();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			byte[] array = new byte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static byte[] UInt8(long[] a)
		{
			FSharpFunc<long, byte> val = new _0024Coretypes.UInt8_0040401_002D3();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			byte[] array = new byte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static byte[] UInt8(decimal[] a)
		{
			FSharpFunc<decimal, byte> val = new _0024Coretypes.UInt8_0040402_002D4();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			byte[] array = new byte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static byte[] UInt8(sbyte[] a)
		{
			FSharpFunc<sbyte, byte> val = new _0024Coretypes.UInt8_0040403_002D5();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			byte[] array = new byte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static byte[] UInt8(byte[] a)
		{
			return a;
		}

		public static byte[] UInt8(bool[] a)
		{
			FSharpFunc<bool, byte> val = new _0024Coretypes.UInt8_0040405_002D6();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			byte[] array = new byte[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static byte[] UInt8<a>(a[] a)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				float[] array = (float[])(object)a;
				float[] array2 = array;
				FSharpFunc<float, byte> val = new _0024Coretypes.UInt8_0040408_002D7();
				float[] array3 = array2;
				if (array3 == null)
				{
					throw new ArgumentNullException("array");
				}
				byte[] array4 = new byte[array3.Length];
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
				FSharpFunc<double, byte> val2 = new _0024Coretypes.UInt8_0040410_002D8();
				double[] array7 = array6;
				if (array7 == null)
				{
					throw new ArgumentNullException("array");
				}
				byte[] array8 = new byte[array7.Length];
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
				FSharpFunc<int, byte> val3 = new _0024Coretypes.UInt8_0040412_002D9();
				int[] array11 = array10;
				if (array11 == null)
				{
					throw new ArgumentNullException("array");
				}
				byte[] array12 = new byte[array11.Length];
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
				FSharpFunc<long, byte> val4 = new _0024Coretypes.UInt8_0040414_002D10();
				long[] array15 = array14;
				if (array15 == null)
				{
					throw new ArgumentNullException("array");
				}
				byte[] array16 = new byte[array15.Length];
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
				FSharpFunc<decimal, byte> val5 = new _0024Coretypes.UInt8_0040416_002D11();
				decimal[] array19 = array18;
				if (array19 == null)
				{
					throw new ArgumentNullException("array");
				}
				byte[] array20 = new byte[array19.Length];
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
				FSharpFunc<sbyte, byte> val6 = new _0024Coretypes.UInt8_0040418_002D12();
				sbyte[] array23 = array22;
				if (array23 == null)
				{
					throw new ArgumentNullException("array");
				}
				byte[] array24 = new byte[array23.Length];
				for (int n = 0; n < array24.Length; n++)
				{
					array24[n] = val6.Invoke(array23[n]);
				}
				return array24;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(byte)))
			{
				return (byte[])(object)a;
			}
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(bool)))
			{
				bool[] array25 = (bool[])(object)a;
				bool[] array26 = array25;
				FSharpFunc<bool, byte> val7 = new _0024Coretypes.UInt8_0040422_002D13();
				bool[] array27 = array26;
				if (array27 == null)
				{
					throw new ArgumentNullException("array");
				}
				byte[] array28 = new byte[array27.Length];
				for (int num = 0; num < array28.Length; num++)
				{
					array28[num] = val7.Invoke(array27[num]);
				}
				return array28;
			}
			FSharpFunc<a, byte> val8 = new _0024Coretypes.UInt8_0040424_002D14<a>();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			byte[] array29 = new byte[a.Length];
			for (int num2 = 0; num2 < array29.Length; num2++)
			{
				array29[num2] = val8.Invoke(a[num2]);
			}
			return array29;
		}

		public static bool[] Bool(float[] a)
		{
			FSharpFunc<float, bool> val = new _0024Coretypes.Bool_0040425();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			bool[] array = new bool[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static bool[] Bool(double[] a)
		{
			FSharpFunc<double, bool> val = new _0024Coretypes.Bool_0040426_002D1();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			bool[] array = new bool[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static bool[] Bool(int[] a)
		{
			FSharpFunc<int, bool> val = new _0024Coretypes.Bool_0040427_002D2();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			bool[] array = new bool[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static bool[] Bool(long[] a)
		{
			FSharpFunc<long, bool> val = new _0024Coretypes.Bool_0040428_002D3();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			bool[] array = new bool[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static bool[] Bool(decimal[] a)
		{
			FSharpFunc<decimal, bool> val = new _0024Coretypes.Bool_0040429_002D4();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			bool[] array = new bool[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static bool[] Bool(sbyte[] a)
		{
			FSharpFunc<sbyte, bool> val = new _0024Coretypes.Bool_0040430_002D5();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			bool[] array = new bool[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static bool[] Bool(byte[] a)
		{
			FSharpFunc<byte, bool> val = new _0024Coretypes.Bool_0040431_002D6();
			if (a == null)
			{
				throw new ArgumentNullException("array");
			}
			bool[] array = new bool[a.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = val.Invoke(a[i]);
			}
			return array;
		}

		public static bool[] Bool(bool[] a)
		{
			return a;
		}

		public static bool[] Bool<a>(a[] a)
		{
			if (HashCompare.GenericEqualityIntrinsic<Type>(typeof(a), typeof(float)))
			{
				float[] array = (float[])(object)a;
				float[] array2 = array;
				FSharpFunc<float, bool> val = new _0024Coretypes.Bool_0040435_002D7();
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
				FSharpFunc<double, bool> val2 = new _0024Coretypes.Bool_0040437_002D8();
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
				FSharpFunc<int, bool> val3 = new _0024Coretypes.Bool_0040439_002D9();
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
				FSharpFunc<long, bool> val4 = new _0024Coretypes.Bool_0040441_002D10();
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
				FSharpFunc<decimal, bool> val5 = new _0024Coretypes.Bool_0040443_002D11();
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
				FSharpFunc<sbyte, bool> val6 = new _0024Coretypes.Bool_0040445_002D12();
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
				FSharpFunc<byte, bool> val7 = new _0024Coretypes.Bool_0040447_002D13();
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
			FSharpFunc<a, bool> val8 = new _0024Coretypes.Bool_0040451_002D14<a>();
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
