using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.MSCoco
{
    public class COCOSegmentation : SegmentationDataset
    {
        public COCOSegmentation(string root = "/mxnet/datasets/coco", string split = "train", string mode = null, Func<NDArray, NDArray> transform = null, int base_size = 520, int crop_size = 480) : base(root, split, mode, transform, base_size, crop_size)
        {
            throw new NotImplementedException();
        }

        public override (NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        public override string[] Classes => throw new NotImplementedException();

        private NDArray GenSegMask(NDArray target, int h, int w) => throw new NotImplementedException();

        private int[] PreProcess(int[] ids, string ids_file) => throw new NotImplementedException();
    }
}
