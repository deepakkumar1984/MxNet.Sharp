using CocoTools.NET;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class COCOInstance : VisionDataset
    {
        public COCOInstance(string root = "./mxnet/datasets/coco", string splits = "instances_val2017",
                                Func<NDArray, NDArray, (NDArray, NDArray)> transform = null, float min_object_area = 0,
                                bool skip_empty = true) : base(root)
        {
            throw new NotImplementedException();
        }

        public COCO Coco => throw new NotImplementedException();

        public override string[] Classes => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        public override (NDArray, NDArray) this[int idx]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float[] GetImAspectRatio() => throw new NotImplementedException();

        internal (string[], NDArrayList, float[]) LoadJsons() => throw new NotImplementedException();

        internal List<int[]> CheckLoadBbox(COCO coco, COCOEntry entry) => throw new NotImplementedException();
    }
}
