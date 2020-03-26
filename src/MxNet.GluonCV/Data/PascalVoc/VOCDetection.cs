using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class VOCDetection : VisionDataset
    {
        public VOCDetection(string root = "/mxnet/datasets/voc", Dictionary<int, string> splits = null, Func<NDArray, NDArray, (NDArray, NDArray)> transform = null, Dictionary<int, string> index_map = null, bool preload_label = true) : base(root)
        {
            throw new NotImplementedException();
        }

        public override int Length => throw new NotImplementedException();

        public override string[] Classes => throw new NotImplementedException();

        public override (NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        private string[] LoadItems(Dictionary<int, string> splits) => throw new NotImplementedException();

        private NDArray LoadLabel(int idx) => throw new NotImplementedException();

        private void ValidateLabel(int xmin, int ymin, int xmax, int ymax, int width, int height) => throw new NotImplementedException();

        private void ValidateClassNames(string class_list) => throw new NotImplementedException();

        private NDArrayList PreloadLabels() => throw new NotImplementedException();
    }
}
