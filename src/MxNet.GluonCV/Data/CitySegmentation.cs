using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class CitySegmentation : SegmentationDataset
    {
        public CitySegmentation(string root = "~/.mxnet/datasets/citys", string split = "train", string mode = null, Func<NDArray, NDArray> transform = null, int base_size = 520, int crop_size = 480) : base(root, split, mode, transform, base_size, crop_size)
        {
        }

        public override NDArrayList this[int idx] => base[idx];

        public override int Length => throw new NotImplementedException();

        internal override NDArray MaskTransform(NDArray mask)
        {
            throw new NotImplementedException();
        }

        internal NDArray ClassToIndex(NDArray mask) => throw new NotImplementedException();
    }
}
