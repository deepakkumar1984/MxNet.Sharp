using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class MHPV1Segmentation : SegmentationDataset
    {
        public MHPV1Segmentation(string root = "/datasets/mhp/LV-MHP-v1", string split = "train", string mode = null, Func<NDArray, NDArray> transform = null, int base_size = 788, int crop_size = 480) : base(root, split, mode, transform, base_size, crop_size)
        {
            throw new NotImplementedException();
        }

        public new(NDArray, NDArray) this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private NDArray MaskTransform(NDArray mask)
        {
            throw new NotImplementedException();
        }

        public override int Length => throw new NotImplementedException();

        public override string[] Classes => throw new NotImplementedException();

        public override int PredOffset => throw new NotImplementedException();
    }
}
