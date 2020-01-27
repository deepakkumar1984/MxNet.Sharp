using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class MNIST : _DownloadedDataset
    {
        public MNIST(string root = "./datasets/mnist", bool train = true, Func<NDArrayDict, NDArrayDict> transform = null) : base(root, transform)
        {
            throw new NotImplementedException();
        }

        public void GetData() => throw new NotImplementedException();
    }
}
