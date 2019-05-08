using MxNetLib;
using System;
using MxNetLib.Metrics;
using MxNetLib.Optimizers;
using System.Collections.Generic;
using System.Linq;
using MxNetLib.NN;
using MxNetLib.NN.Layers;
using MxNetLib.NN.Initializers;

namespace MNIST
{
    class Program
    {
        static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("MXNET_ENGINE_TYPE", "NaiveEngine");
            MXNet.SetDevice(DeviceType.CPU);

            int inputDim = 28 * 28;
            int labelCount = 10;
            uint batchSize = 128;

            string trainImagePath = "./mnist_data/train-images-idx3-ubyte";
            string trainLabelPath = "./mnist_data/train-labels-idx1-ubyte";
            string valImagePath = "./mnist_data/t10k-images-idx3-ubyte";
            string valLabelPath = "./mnist_data/t10k-labels-idx1-ubyte";

            var (train, val) = MNIST(trainImagePath, trainLabelPath, valImagePath, valLabelPath, batchSize);

            //var x = Symbol.Variable("x");
            //var flat = sym.Flatten(x, "flatten");
            //var fc1 = sym.Relu(sym.FullyConnected(flat, Symbol.Variable("fc1_w"), null, 128, no_bias: true, symbol_name: "fc1"), "relu1");
            //var fc2 = sym.Relu(sym.FullyConnected(fc1, Symbol.Variable("fc2_w"), null, 128, no_bias: true, symbol_name: "fc2"), "relu2");
            //var fc3 = sym.FullyConnected(fc2, Symbol.Variable("fc3_w"), null, labelCount, no_bias: true, symbol_name: "fc3");
            //var output = sym.SoftmaxOutput(fc3, Symbol.Variable("label"), symbol_name: "model");

            //Dictionary<string, NDArray> parameters = new Dictionary<string, NDArray>();
            //parameters["x"] = new NDArray(new Shape(batchSize, (uint)inputDim));
            //parameters["label"] = new NDArray(new Shape(batchSize));
            //output.InferArgsMap(MXNet.Device, parameters, parameters);

            //foreach (var item in parameters.ToList())
            //{
            //    if (item.Key == "x" || item.Key == "label")
            //        continue;

            //    if (item.Key.EndsWith("_w"))
            //    {
            //        item.Value.SampleUniform(-0.1f, 0.1f);
            //    }
            //    else
            //    {
            //        item.Value.Constant(0);
            //    }
            //}

            //var opt = new SGD(0.1f);
            //Accuracy metric = new Accuracy();

            //train.SetBatch(batchSize);
            //var argNames = output.ListArguments();
            //DataBatch batch;
            //using (var exec = output.SimpleBind(MXNet.Device, parameters))
            //{
            //    for (int iter = 1; iter <= 10; iter++)
            //    {
            //        train.Reset();
            //        metric.Reset();

            //        while (train.Next())
            //        {
            //            batch = train.GetDataBatch();
            //            batch.Data.CopyTo(parameters["x"]);
            //            batch.Label.CopyTo(parameters["label"]);
            //            exec.Forward(true);
            //            exec.Backward();

            //            metric.Update(parameters["label"], exec.Output);
            //            for (var i = 0; i < argNames.Count; ++i)
            //            {
            //                if (argNames[i] == "x" || argNames[i] == "label")
            //                    continue;

            //                opt.Update(iter, i, exec.ArgmentArrays[i], exec.GradientArrays[i]);
            //            }
            //        }

            //        Console.WriteLine("Iteration: {0}, Metric: {1}", iter, metric.Get());
            //    }
            //}

            var model = new Module(1, 28, 28);

            model.Add(new Flatten());
            model.Add(new Dense(128, ActivationType.ReLU, new RandomUniform(-1, 1)));
            model.Add(new Dense(128, ActivationType.ReLU, new RandomUniform(-1, 1)));
            model.Add(new Dense(labelCount));

            model.Add(new Conv2D(20, Tuple.Create<uint, uint>(5, 5), activation: ActivationType.Tanh));
            model.Add(new MaxPooling2D(Tuple.Create<uint, uint>(2, 2), Tuple.Create<uint, uint>(2, 2)));
            model.Add(new Conv2D(20, Tuple.Create<uint, uint>(5, 5), activation: ActivationType.Tanh));
            model.Add(new MaxPooling2D(Tuple.Create<uint, uint>(2, 2), Tuple.Create<uint, uint>(2, 2)));
            model.Add(new Flatten());
            model.Add(new Dropout(0.5f));
            model.Add(new Dense(128, ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));
            model.Add(new Dense(10));

            model.Compile(Optimizers.SGD(0.1f), LossType.SoftmaxCategorialCrossEntropy, MetricType.Accuracy);
            model.Fit(train, 10, batchSize, val);
        }

        public static ValueTuple<DataIter, DataIter> MNIST(string trainImagesPath, string trainLabelPath, string valImagesPath, string valLabelPath, uint batch_size = 32)
        {
            var trainIter = new MXDataIter("MNISTIter")
                .SetParam("image", trainImagesPath)
                .SetParam("label", trainLabelPath)
                .SetParam("batch_size", batch_size)
                //.SetParam("flat", "1")
                .CreateDataIter();

            var valIter = new MXDataIter("MNISTIter")
                .SetParam("image", valImagesPath)
                .SetParam("label", valLabelPath)
                .SetParam("batch_size", batch_size)
                //.SetParam("flat", "1")
                .CreateDataIter();

            return ValueTuple.Create(trainIter, valIter);
        }
    }
}
