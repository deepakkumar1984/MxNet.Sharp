using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class SegmentationDataset : VisionDataset
    {
        public SegmentationDataset(string root, string split, string mode, Func<NDArray, NDArray> transform, int base_size= 520, int crop_size= 480)
        {
            throw new NotImplementedException();
        }

        public override NDArrayList this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        public override string[] Classes => throw new NotImplementedException();

        internal (NDArray, NDArray) ValSyncTransform(NDArray img, NDArray mask)
        {
            throw new NotImplementedException();
        }

        internal (NDArray, NDArray) SyncTransform(NDArray img, NDArray mask)
        {
            throw new NotImplementedException();
        }

        internal NDArray ImgTransform(NDArray img)
        {
            throw new NotImplementedException();
        }

        internal virtual NDArray MaskTransform(NDArray mask)
        {
            throw new NotImplementedException();
        }

        public override int NumClass => throw new NotImplementedException();

        public virtual int PredOffset => 0;

        public static NDArrayList MsBatchifyFn(NDArrayList data) => throw new NotImplementedException();
    }
}
