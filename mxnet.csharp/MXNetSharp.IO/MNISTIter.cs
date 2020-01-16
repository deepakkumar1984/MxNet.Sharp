using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;

namespace MXNetSharp.IO
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class MNISTIter : DataIter
	{
		internal bool silent;

		internal bool shuffle;

		internal int seed;

		internal long prefetchBuffer;

		internal int partIndex;

		internal int numParts;

		internal string label;

		internal string image;

		internal bool flat;

		internal FSharpOption<DataType> dtype;

		internal string ctx;

		internal int batchSize;

		public string Image => image;

		public string Label => label;

		public int BatchSize => batchSize;

		public bool Shuffle => shuffle;

		public bool Flat => flat;

		public int Seed => seed;

		public bool Silent => silent;

		public int NumParts => numParts;

		public int PartIndex => partIndex;

		public long PrefetchBuffer => prefetchBuffer;

		public DeviceType DeviceType
		{
			get
			{
				string a = ctx.ToLower();
				if (!string.Equals(a, "cpu"))
				{
					if (string.Equals(a, "gpu"))
					{
						return DeviceType.GPU;
					}
					string text = "Internal error in CSVIter. Device type can only be one of 'cpu' or 'gpu'";
					throw Operators.Failure(text);
				}
				return DeviceType.CPU;
			}
		}

		public FSharpOption<DataType> DataType => dtype;

		internal MNISTIter(IntPtr creatorHandle, DataIterInfo info, string image, string label, int batchSize, bool shuffle, bool flat, int seed, bool silent, int numParts, int partIndex, long prefetchBuffer, string ctx, FSharpOption<DataType> dtype)
			: base(creatorHandle, info, ExtraTopLevelOperators.CreateDictionary<string, object>((IEnumerable<Tuple<string, object>>)FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("image", image), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("label", label), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("batch_size", batchSize), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("shuffle", shuffle), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("flat", flat), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("seed", seed), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("silent", silent), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("num_parts", numParts), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("part_index", partIndex), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("prefetch_buffer", prefetchBuffer), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("ctx", ctx), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("dtype", dtype), FSharpList<Tuple<string, object>>.get_Empty()))))))))))))))
		{
			this.image = image;
			this.label = label;
			this.batchSize = batchSize;
			this.shuffle = shuffle;
			this.flat = flat;
			this.seed = seed;
			this.silent = silent;
			this.numParts = numParts;
			this.partIndex = partIndex;
			this.prefetchBuffer = prefetchBuffer;
			this.ctx = ctx;
			this.dtype = dtype;
			if (this.batchSize >= 0)
			{
				return;
			}
			string paramName = "batchSize";
			string message = "MNISTIter: batch size must be non-negative";
			throw new ArgumentException(message, paramName);
		}

		public MNISTIter([OptionalArgument] FSharpOption<string> image, [OptionalArgument] FSharpOption<string> label, [OptionalArgument] FSharpOption<int> batchSize, [OptionalArgument] FSharpOption<bool> shuffle, [OptionalArgument] FSharpOption<bool> flat, [OptionalArgument] FSharpOption<int> seed, [OptionalArgument] FSharpOption<bool> silent, [OptionalArgument] FSharpOption<int> numParts, [OptionalArgument] FSharpOption<int> partIndex, [OptionalArgument] FSharpOption<long> prefetchBuffer, [OptionalArgument] FSharpOption<DeviceType> deviceType, [OptionalArgument] FSharpOption<DataType> dataType)
		{
			DataIterDefinition def = DataIterDefinition.FromName("MNISTIter");
			string image2 = Operators.DefaultArg<string>(image, "./train-images-idx3-ubyte");
			string label2 = Operators.DefaultArg<string>(label, "./train-labels-idx1-ubyte");
			int batchSize2 = Operators.DefaultArg<int>(batchSize, 128);
			bool shuffle2 = Operators.DefaultArg<bool>(shuffle, true);
			bool flat2 = Operators.DefaultArg<bool>(flat, false);
			int seed2 = Operators.DefaultArg<int>(seed, 0);
			bool silent2 = Operators.DefaultArg<bool>(silent, false);
			int numParts2 = Operators.DefaultArg<int>(numParts, 1);
			int partIndex2 = Operators.DefaultArg<int>(partIndex, 0);
			long prefetchBuffer2 = Operators.DefaultArg<long>(prefetchBuffer, 4L);
			object obj;
			switch (Operators.DefaultArg<DeviceType>(deviceType, DeviceType.GPU).Tag)
			{
			case 0:
			case 2:
				obj = "cpu";
				break;
			default:
				obj = "gpu";
				break;
			}
			this._002Ector(def.DataIterCreatorHandle, def.Info, image2, label2, batchSize2, shuffle2, flat2, seed2, silent2, numParts2, partIndex2, prefetchBuffer2, (string)obj, dataType);
		}
	}
}
