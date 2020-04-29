using MxNet.Gluon.Data.Vision.Datasets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class ImageNet : ImageFolderDataset
    {
        public ImageNet(string root = "/datasets/imagenet", bool train = true, Func<NDArray, int, (NDArray, int)> transform = null) : base(root, 1, transform)
        {
            var split = train ? "train" : "val";
            Root = Path.Combine(root, split);
        }
    }
}
