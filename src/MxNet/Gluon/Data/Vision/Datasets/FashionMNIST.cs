using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class FashionMNIST : MNIST
    {
        public FashionMNIST(string root = "/datasets/fashion-mnist", bool train = true, Func<NDArray, NDArray, (NDArray, NDArray)> transform = null) : base(root, train, transform)
        {
            _train = train;
            _train_data = ("train-images-idx3-ubyte.gz",
                            "0cf37b0d40ed5169c6b3aba31069a9770ac9043d");
            _train_label = ("train-labels-idx1-ubyte.gz",
                             "236021d52f1e40852b06a4c3008d8de8aef1e40b");
            _test_data = ("t10k-images-idx3-ubyte.gz",
                           "626ed6a7c06dd17c0eec72fa3be1740f146a2863");
            _test_label = ("t10k-labels-idx1-ubyte.gz",
                            "17f9ab60e7257a1620f4ad76bbbaf857c3920701");
            _namespace = "fashion-mnist";
        }
    }
}
