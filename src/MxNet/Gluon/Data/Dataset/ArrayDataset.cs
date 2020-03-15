using System;
using System.Collections.Generic;
using System.Linq;

namespace MxNet.Gluon.Data
{
    public class ArrayDataset : Dataset<(NDArray, NDArray)>
    {
        public ArrayDataset(params (NDArray, NDArray)[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException("Need atleast 1 array");
            Data = new List<(NDArray, NDArray)>();
            Length = args[0].Item1.Shape[0];

            for (var i = 0; i < args.Length; i++)
                Data.Add(args[i]);
        }

        public override (NDArray, NDArray) this[int idx]
        {
            get
            {
                return (Data[0].Item1.SliceAxis(0, idx, idx + 1), Data[0].Item2.SliceAxis(0, idx, idx + 1));
            }
        }

        public override int Length { get; }
    }
}