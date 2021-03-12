using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class ImageListDataset : Dataset<(NDArray, NDArray)>
    {
        public override (NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        public ImageListDataset(string root = ".", string[] imglist = null, int flag = 1)
        {
            throw new NotImplementedException();
        }

        public ImageListDataset(string root = ".", NDArrayList imglist = null, int flag = 1)
        {
            throw new NotImplementedException();
        }
    }
}
