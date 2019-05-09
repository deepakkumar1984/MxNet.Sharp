using MxNetLib;
using System;
using MxNetLib.Metrics;
using MxNetLib.Optimizers;
using System.Collections.Generic;
using System.Linq;
using MxNetLib.NN;
using MxNetLib.NN.Layers;
using MxNetLib.NN.Initializers;
using MxNetLib.NN.Data;

namespace MNIST
{
    class Program
    {
        static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("MXNET_ENGINE_TYPE", "NaiveEngine");
            MXNet.SetDevice(DeviceType.CPU);
            uint batchSize = 200;

            string trainImagePath = "./mnist_data/train-images-idx3-ubyte";
            string trainLabelPath = "./mnist_data/train-labels-idx1-ubyte";
            string valImagePath = "./mnist_data/t10k-images-idx3-ubyte";
            string valLabelPath = "./mnist_data/t10k-labels-idx1-ubyte";

            var (train, val) = DataSetParser.MNIST(trainImagePath, trainLabelPath, valImagePath, valLabelPath, batchSize, 1);
            var model = new Module();
            BuildNNModel(model);
            //BuildSymbolModel(model);
            //BuildConvNNModel(model);

            ImageDataFrame frame = new ImageDataFrame(1, 28, 28);
            frame.LoadImages("test_4.png");

            NDArray test = frame.ToVariable().Reshape(new Shape(1, 784));
            model.Fit(train, 1, batchSize, val);

            var prediction = model.Predict(test);
            var num = nd.Argmax(prediction, 1);

            string modelFolder = "../../../model";
            model.SaveModel(modelFolder);
            model.SaveCheckpoint(modelFolder);

            var loadedModel = Module.LoadModel(modelFolder);
            loadedModel.LoadCheckpoint(modelFolder);
        }

        private static void BuildSymbolModel(Module model)
        {
            model.SetInput(784);
            var x = Symbol.Variable("X");
            var fc1 = sym.Relu(sym.FullyConnected(x, Symbol.Variable("fc1_w"), 128));
            var fc2 = sym.Relu(sym.FullyConnected(fc1, Symbol.Variable("fc2_w"), 128));
            var fc3 = sym.FullyConnected(fc2, Symbol.Variable("fc3_w"), 10);
            var output = sym.SoftmaxOutput(fc3, Symbol.Variable("label"), symbol_name: "model");

            model.SetDefaultInitializer(new RandomUniform(-1, 1));
            model.Compile(output, OptimizerRegistry.SGD(), MetricType.Accuracy);
        }

        private static void BuildNNModel(Module model)
        {
            //FC model 
            model.SetInput(784);

            model.Add(new Dense(128, ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));
            model.Add(new Dense(128, ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));
            model.Add(new Dense(10));

            model.Compile(OptimizerRegistry.SGD(), LossType.SoftmaxCategorialCrossEntropy, MetricType.Accuracy);
        }

        private static void BuildConvNNModel(Module model)
        {
            //LeCunn model 
            model.SetInput(1, 28, 28);

            model.Add(new Conv2D(20, Tuple.Create<uint, uint>(5, 5), activation: ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));
            model.Add(new MaxPooling2D(Tuple.Create<uint, uint>(2, 2), Tuple.Create<uint, uint>(2, 2)));

            model.Add(new Conv2D(20, Tuple.Create<uint, uint>(5, 5), activation: ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));
            model.Add(new MaxPooling2D(Tuple.Create<uint, uint>(2, 2), Tuple.Create<uint, uint>(2, 2)));

            model.Add(new Flatten());
            model.Add(new Dropout(0.5f));
            model.Add(new Dense(128, ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));

            model.Add(new Dense(10));

            model.Compile(OptimizerRegistry.SGD(), LossType.SoftmaxCategorialCrossEntropy, MetricType.Accuracy);
        }
    }
}
