using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class FashionMNIST : MNIST
    {
        public FashionMNIST(string root = "./datasets/fashion-mnist", bool train = true, Func<NDArrayDict, NDArrayDict> transform = null) : base(root, train, transform)
        {
            throw new NotImplementedException();
        }
    }
}
