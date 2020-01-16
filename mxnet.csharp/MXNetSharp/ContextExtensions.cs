using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class ContextExtensions
	{
		internal ContextExtensions()
		{
		}

		public static NDArray CopyFrom(this Context ctx, float[] data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(data, shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, double[] data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(data, shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, int[] data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(data, shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, long[] data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(data, shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, sbyte[] data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(data, shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, byte[] data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(data, shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, IEnumerable<float> data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(SeqModule.ToArray<float>(data), shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, IEnumerable<double> data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(SeqModule.ToArray<double>(data), shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, IEnumerable<int> data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(SeqModule.ToArray<int>(data), shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, IEnumerable<long> data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(SeqModule.ToArray<long>(data), shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, IEnumerable<sbyte> data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(SeqModule.ToArray<sbyte>(data), shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, IEnumerable<byte> data, IEnumerable<int> shape)
		{
			return NDArray.CopyFrom(SeqModule.ToArray<byte>(data), shape, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, Array data)
		{
			return NDArray.CopyFrom(data, ctx);
		}

		public static NDArray CopyFrom(this Context ctx, NDArray data)
		{
			return NDArray.CopyFrom(data, ctx);
		}

		public static NDArray RandomUniform(this Context ctx, IEnumerable<int> shape, double low = 0.0, double high = 1.0, [Optional] GeneratedArgumentTypes.FloatDType dtype)
		{
			return MX.RandomUniformNDArray(ctx, low, high, shape, dtype);
		}

		public static NDArray RandomNormal(this Context ctx, IEnumerable<int> shape, double loc = 0.0, double scale = 1.0, [Optional] GeneratedArgumentTypes.FloatDType dtype)
		{
			return MX.RandomNormalNDArray(ctx, loc, scale, shape, dtype);
		}

		public static NDArray RandomGamma(this Context ctx, IEnumerable<int> shape, double alpha = 1.0, double beta = 1.0, [Optional] GeneratedArgumentTypes.FloatDType dtype)
		{
			return MX.RandomGammaNDArray(ctx, alpha, beta, shape, dtype);
		}

		public static NDArray RandomExponential(this Context ctx, IEnumerable<int> shape, double lam = 1.0, [Optional] GeneratedArgumentTypes.FloatDType dtype)
		{
			return MX.RandomExponentialNDArray(ctx, lam, shape, dtype);
		}

		public static NDArray RandomPoisson(this Context ctx, IEnumerable<int> shape, double lam = 1.0, [Optional] GeneratedArgumentTypes.FloatDType dtype)
		{
			return MX.RandomPoissonNDArray(ctx, lam, shape, dtype);
		}

		public static NDArray RandomNegativeBinomial(this Context ctx, IEnumerable<int> shape, int k = 1, double p = 1.0, [Optional] GeneratedArgumentTypes.FloatDType dtype)
		{
			return MX.RandomNegativeBinomialNDArray(ctx, k, p, shape, dtype);
		}

		public static NDArray RandomGeneralizedNegativeBinomial(this Context ctx, IEnumerable<int> shape, double mu = 1.0, double alpha = 1.0, [Optional] GeneratedArgumentTypes.FloatDType dtype)
		{
			return MX.RandomGeneralizedNegativeBinomialNDArray(ctx, mu, alpha, shape, dtype);
		}

		public static NDArray RandomRandint(this Context ctx, IEnumerable<int> shape, long low, long high, [Optional] GeneratedArgumentTypes.RandomRandintDtype dtype)
		{
			return MX.RandomRandintNDArray(low, high, ctx, shape, dtype);
		}

		public static NDArray ZerosWithoutDtype(this Context ctx, IEnumerable<int> shape)
		{
			return MX.ZerosWithoutDtypeNDArray(ctx, shape);
		}

		public static NDArray Zeros(this Context ctx, IEnumerable<int> shape, [Optional] DataType dtype)
		{
			return MX.ZerosNDArray(ctx, shape, dtype);
		}

		public static NDArray Eye(this Context ctx, long N, [Optional] long M, [Optional] long k, [Optional] DataType dtype)
		{
			return MX.EyeNDArray(N, ctx, M, k, dtype);
		}

		public static NDArray Ones(this Context ctx, IEnumerable<int> shape, [Optional] DataType dtype)
		{
			return MX.OnesNDArray(ctx, shape, dtype);
		}

		public static NDArray[] Full(this Context ctx, IEnumerable<int> shape, double value, [Optional] DataType dtype)
		{
			return MX.FullNDArray(ctx, value, shape, dtype);
		}

		public static NDArray Arange(this Context ctx, double start, [Optional] [OptionalArgument] FSharpOption<double> stop, [Optional] [OptionalArgument] FSharpOption<double> step, [Optional] [OptionalArgument] FSharpOption<int> repeat, [Optional] [OptionalArgument] FSharpOption<bool> inferRange, [Optional] [OptionalArgument] FSharpOption<DataType> dtype)
		{
			return MX.ArangeNDArray(start, ctx, stop, step, repeat, inferRange, dtype);
		}

		public static NDArray ArangeLike(this Context ctx, NDArray data, [Optional] double start, [Optional] double step, [Optional] int repeat, [Optional] int axis)
		{
			return MX.ContribArangeLike(data, ctx, FSharpOption<double>.Some(start), FSharpOption<double>.Some(step), FSharpOption<int>.Some(repeat), FSharpOption<int>.Some(axis));
		}

		public static NDArray Linspace(this Context ctx, double start, [Optional] double stop, [Optional] double step, [Optional] int repeat, [Optional] bool inferRange, [Optional] DataType dtype)
		{
			return MX.LinspaceNDArray(start, ctx, FSharpOption<double>.Some(stop), FSharpOption<double>.Some(step), FSharpOption<int>.Some(repeat), FSharpOption<bool>.Some(inferRange), FSharpOption<DataType>.Some(dtype));
		}
	}
}
