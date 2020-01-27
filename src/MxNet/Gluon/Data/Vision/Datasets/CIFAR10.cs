using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class CIFAR10 : _DownloadedDataset
    {
        public CIFAR10(string root = "./datasets/cifar10", bool train = true, Func<NDArrayDict, NDArrayDict> transform = null) : base(root, transform)
        {
            throw new NotImplementedException();
        }

        internal virtual (NDArray, NDArray) ReadBatch() => throw new NotImplementedException();

        public void GetData() => throw new NotImplementedException();
    }
}
