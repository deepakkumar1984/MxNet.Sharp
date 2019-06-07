using MxNetLib;
using MxNetLib.Metrics;
using MxNetLib.NN;
using MxNetLib.NN.Data;
using MxNetLib.NN.Initializers;
using MxNetLib.NN.Layers;
using MxNetLib.Optimizers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ORGate
{
    class Program
    {
        static void Main(string[] args)
        {
            MXNet.SetDevice(DeviceType.CPU);

            //Pred data
            DataFrame train_x = new DataFrame(2);
            DataFrame train_y = new DataFrame(1);
            train_x.Load(0, 0, 0, 1, 1, 0, 1, 1);

            train_y.Load(0, 1, 1, 0);

            NDArrayIter train = new NDArrayIter(train_x.ToVariable(), train_y.ToVariable());

            //Build Model
            Module model = new Module(2);
            //BuildSymbolModel(model);
            BuildNNModel(model);
            model.Fit(train, 1000, 2);

            Console.ReadLine();
        }

        private static void BuildSymbolModel(Module model)
        {
            var x = Symbol.Variable("X");
            var fc1 = sym.Relu(sym.FullyConnected(x, Symbol.Variable("fc1_w"), 64));
            var fc2 = sym.Relu(sym.FullyConnected(fc1, Symbol.Variable("fc2_w"), 32));
            var fc3 = sym.Relu(sym.FullyConnected(fc2, Symbol.Variable("fc3_w"), 1));
            var output = sym.LogisticRegressionOutput(fc3, Symbol.Variable("label"));

            model.SetDefaultInitializer(new RandomUniform(-1, 1));
            model.Compile(output, OptimizerRegistry.Adam(), MetricType.BinaryAccuracy);
        }

        private static void BuildNNModel(Module model)
        {
            model.Add(new Dense(dim: 64, activation: ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));
            model.Add(new Dense(dim: 32, activation: ActivationType.ReLU, kernalInitializer: new GlorotUniform()));
            model.Add(new Dense(dim: 1));

            //Train
            model.Compile(OptimizerType.Adam, LossType.SigmoidBinaryCrossEntropy, MetricType.BinaryAccuracy);
        }
        
    }
}
