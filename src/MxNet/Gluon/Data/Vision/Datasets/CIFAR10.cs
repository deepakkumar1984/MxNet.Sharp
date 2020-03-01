using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class CIFAR10 : _DownloadedDataset
    {
        public CIFAR10(string root = "/datasets/cifar10", bool train = true, Func<NDArray, NDArray, (NDArray, NDArray)> transform = null) : base(mx.AppPath + root, transform)
        {
            throw new NotImplementedException();
        }

        internal virtual (NDArray, NDArray) ReadBatch() => throw new NotImplementedException();

        public override void GetData() => throw new NotImplementedException();
    }
}
