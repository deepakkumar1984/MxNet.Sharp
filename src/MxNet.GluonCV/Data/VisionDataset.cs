using MxNet;
using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public abstract class VisionDataset : Dataset<NDArrayList>
    {
        public abstract override NDArrayList this[int idx] { get; }

        public abstract override int Length { get; }

        public abstract string[] Classes { get; }

        public virtual int NumClass => Classes.Length;
    }
}
