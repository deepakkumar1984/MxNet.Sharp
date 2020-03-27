using CocoTools.NET;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class COCOEntry
    {
        public string CocoUrl { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }

    public class COCODetection : VisionDataset
    {
        public COCODetection(string root = "./mxnet/datasets/coco", string splits = "instances_val2017", 
                                Func<NDArray, NDArray, (NDArray, NDArray)> transform = null, float min_object_area = 0,
                                bool skip_empty = true, bool use_crowd = true) : base(root)
        {
            throw new NotImplementedException();
        }

        public COCO Coco
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string[] Classes => throw new NotImplementedException();

        public string AnnotaionDir => "annotations";

        public override int Length => throw new NotImplementedException();

        public override (NDArray, NDArray) this[int idx]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float[] GetImAspectRatio() => throw new NotImplementedException();

        public string ParseImagePath(COCOEntry entry) => throw new NotImplementedException();

        internal (string[], NDArrayList, float[])  LoadJsons() => throw new NotImplementedException();

        internal List<int[]> CheckLoadBbox(COCO coco, COCOEntry entry) => throw new NotImplementedException();
    }
}
