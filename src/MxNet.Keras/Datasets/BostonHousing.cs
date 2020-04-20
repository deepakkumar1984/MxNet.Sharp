using MxNet.Keras.Utils;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MxNet.Keras.Datasets
{
    public class BostonHousing
    {
        public static ((NDArray, NDArray), (NDArray, NDArray)) LoadData(string path= "boston_housing.npz", float test_split= 0.2f, int seed= 113)
        {
            Debug.Assert(0 <= test_split && test_split < 1);
            path = DataUtils.GetFile(path, origin: "https://s3.amazonaws.com/keras-datasets/boston_housing.npz", file_hash: "f553886a1f8d56431e820c5b82552d9d95cfcb96d1e678153f8839538947dff5");

            var arrays = NDArray.LoadNpz(path);
            var x = arrays[0];
            var y = arrays[1];

            mx.Seed(seed);
            NDArray indices = np.arange(x.Shape[0]);
            indices = nd.Shuffle(indices.AsType(DType.Int32));
            x = x[indices];
            y = y[indices];
            int n = x.Shape[0];
            int test_n = Convert.ToInt32(test_split * n);

            var x_train = x[$":{test_n}"];
            var y_train = y[$":{test_n}"];
            var x_test = x[$"{test_n}:"];
            var y_test = y[$"{test_n}:"];
            return ((x_train, y_train), (x_test, y_test));
        }
    }
}
