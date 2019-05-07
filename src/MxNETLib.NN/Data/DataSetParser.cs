using MxNet.DotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN.Data
{
    public class DataSetParser
    {
        public static ValueTuple<DataIter, DataIter> MNIST(string trainImagesPath, string trainLabelPath, string valImagesPath, string valLabelPath, uint batch_size=32)
        {
            var trainIter = new MXDataIter("MNISTIter")
                .SetParam("image", trainImagesPath)
                .SetParam("label", trainLabelPath)
                .SetParam("batch_size", batch_size)
                .SetParam("dtype", "float32")
                .CreateDataIter();

            var valIter = new MXDataIter("MNISTIter")
                .SetParam("image", valImagesPath)
                .SetParam("label", valLabelPath)
                .SetParam("batch_size", batch_size)
                .SetParam("dtype", "float32")
                .CreateDataIter();

            return ValueTuple.Create(trainIter, valIter);
        }
    }
}
