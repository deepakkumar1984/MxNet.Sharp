using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class ADE20KSegmentation : SegmentationDataset
    {
        public ADE20KSegmentation(string root = "~/.mxnet/datasets/ade", string split = "train", string mode = null, Func<NDArray, NDArray> transform = null, int base_size = 520, int crop_size = 480) : base(root, split, mode, transform, base_size, crop_size)
        {
            throw new NotImplementedException();
        }

        public override NDArrayList this[int idx] => throw new NotImplementedException();

        internal override NDArray MaskTransform(NDArray mask)
        {
            throw new NotImplementedException();
        }

        public override int Length => throw new NotImplementedException();

        public override string[] Classes => throw new NotImplementedException();

        public override int PredOffset => 1;

        public static (string[], string[]) GetAde20kPairs(string folder, string split = "train")
        {
            throw new NotImplementedException();
        }
    }
}
