using MxNet;
using MxNet.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN.Data
{
    public class DataSetParser
    {
        public static ValueTuple<DataIter, DataIter> MNIST(string trainImagesPath, string trainLabelPath, string valImagesPath, string valLabelPath, uint batch_size = 32, int flat = 0)
        {
            var trainIter = new MXDataIter("MNISTIter");
            trainIter.SetParam("image", trainImagesPath);
            trainIter.SetParam("label", trainLabelPath);
            trainIter.SetParam("batch_size", batch_size);
            trainIter.SetParam("dtype", "float32");
            trainIter.SetParam("flat", flat.ToString());

            var valIter = new MXDataIter("MNISTIter");
            valIter.SetParam("image", valImagesPath);
            valIter.SetParam("label", valLabelPath);
            valIter.SetParam("batch_size", batch_size);
            valIter.SetParam("dtype", "float32");
            valIter.SetParam("flat", flat.ToString());

            return ValueTuple.Create(trainIter, valIter);
        }
    }
}
