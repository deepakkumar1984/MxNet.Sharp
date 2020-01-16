using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;

namespace MXNetSharp.IO
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class CSVIter : DataIter
	{
		internal bool roundBatch;

		internal long prefetchBuffer;

		internal int[] labelShape;

		internal string labelCsv;

		internal FSharpOption<DataType> dtype;

		internal int[] dataShape;

		internal string dataCsv;

		internal string ctx;

		internal int batchSize;

		public string DataCsv => dataCsv;

		public IEnumerable<int> DataShape => ArrayModule.ToSeq<int>(dataShape);

		public FSharpOption<string> LabelCsv
		{
			get
			{
				if (string.IsNullOrEmpty(labelCsv))
				{
					return null;
				}
				return FSharpOption<string>.Some(labelCsv);
			}
		}

		public IEnumerable<int> LabelShape => ArrayModule.ToSeq<int>(labelShape);

		public int BatchSize => batchSize;

		public bool RoundBatch => roundBatch;

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

		internal CSVIter(IntPtr creatorHandle, DataIterInfo info, string dataCsv, int[] dataShape, string labelCsv, int[] labelShape, int batchSize, bool roundBatch, long prefetchBuffer, string ctx, FSharpOption<DataType> dtype)
			: base(creatorHandle, info, ExtraTopLevelOperators.CreateDictionary<string, object>((IEnumerable<Tuple<string, object>>)FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("data_csv", dataCsv), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("data_shape", dataShape), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("label_csv", labelCsv), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("label_shape", labelShape), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("batch_size", batchSize), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("round_batch", roundBatch), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("prefetch_buffer", prefetchBuffer), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("ctx", ctx), FSharpList<Tuple<string, object>>.Cons(new Tuple<string, object>("dtype", dtype), FSharpList<Tuple<string, object>>.get_Empty())))))))))))
		{
			this.dataCsv = dataCsv;
			this.dataShape = dataShape;
			this.labelCsv = labelCsv;
			this.labelShape = labelShape;
			this.batchSize = batchSize;
			this.roundBatch = roundBatch;
			this.prefetchBuffer = prefetchBuffer;
			this.ctx = ctx;
			this.dtype = dtype;
			if (this.batchSize >= 0)
			{
				return;
			}
			string paramName = "batchSize";
			string message = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("CSVIter (%s): batch size must be non-negative")).Invoke(this.dataCsv);
			throw new ArgumentException(message, paramName);
		}

		public CSVIter(string dataCsv, IEnumerable<int> dataShape, [OptionalArgument] FSharpOption<string> labelCsv, [OptionalArgument] FSharpOption<IEnumerable<int>> labelShape, [OptionalArgument] FSharpOption<int> batchSize, [OptionalArgument] FSharpOption<bool> roundBatch, [OptionalArgument] FSharpOption<long> prefetchBuffer, [OptionalArgument] FSharpOption<DeviceTypeEnum> deviceType, [OptionalArgument] FSharpOption<DataType> dtype)
		{
			DataIterDefinition def = DataIterDefinition.FromName("CSVIter");
			int[] dataShape2 = SeqModule.ToArray<int>(dataShape);
			string labelCsv2 = Operators.DefaultArg<string>(labelCsv, (string)null);
			int[] labelShape2 = SeqModule.ToArray<int>(Operators.DefaultArg<IEnumerable<int>>(labelShape, SeqModule.Singleton<int>(1)));
			int batchSize2 = Operators.DefaultArg<int>(batchSize, 0);
			bool roundBatch2 = Operators.DefaultArg<bool>(roundBatch, true);
			long prefetchBuffer2 = Operators.DefaultArg<long>(prefetchBuffer, 4L);
			object obj;
			switch (Operators.DefaultArg<DeviceTypeEnum>(deviceType, DeviceTypeEnum.GPU))
			{
			case DeviceTypeEnum.CPU:
			case DeviceTypeEnum.CPUPinned:
				obj = "cpu";
				break;
			default:
				obj = "gpu";
				break;
			}
			this._002Ector(def.DataIterCreatorHandle, def.Info, dataCsv, dataShape2, labelCsv2, labelShape2, batchSize2, roundBatch2, prefetchBuffer2, (string)obj, dtype);
		}
	}
}
