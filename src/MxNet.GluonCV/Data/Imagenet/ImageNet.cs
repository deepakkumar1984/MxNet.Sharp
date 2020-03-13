using MxNet.Gluon.Data.Vision.Datasets;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class ImageNet : ImageFolderDataset
    {
        public ImageNet(string root = "~/.mxnet/datasets/imagenet", bool train = true, Func<(NDArray, int), (NDArray, int)> transform = null) : base(root, 1, transform)
        {
            throw new NotImplementedException();
        }
    }
}
