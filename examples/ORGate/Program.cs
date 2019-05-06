using MxNetLib;
using MxNetLib.Metrics;
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
            uint batchSize = 1;
            var x = Symbol.Variable("x");
            var y = 2 * x;
            var trainx = new NDArray(new float[] { 0, 0, 0, 1, 1, 0, 1, 1 }, new Shape(4, 2));
            var trainy = new NDArray(new float[] { 0, 1, 1, 0 }, new Shape(4, 1));
            NDArrayIter dataIter = new NDArrayIter(trainx, trainy);
            
            var fc1 = sym.FullyConnected(x, Symbol.Variable("fc1_w"),null, 128, no_bias: true, symbol_name: "fc1");
            var fc2 = sym.Relu(sym.FullyConnected(fc1, Symbol.Variable("fc2_w"), null, 64, no_bias: true, symbol_name: "fc2"), "relu2");
            var fc3 = sym.Relu(sym.FullyConnected(fc2, Symbol.Variable("fc3_w"), null, 1, no_bias: true, symbol_name: "fc3"), "relu3");
            var output = sym.LogisticRegressionOutput(fc3, Symbol.Variable("label"), symbol_name: "model");

            Dictionary<string, NDArray> parameters = new Dictionary<string, NDArray>();
            parameters["x"] = new NDArray(new Shape(batchSize, 2));
            parameters["label"] = new NDArray(new Shape(batchSize));
            output.InferArgsMap(MXNet.Device, parameters, parameters);

            foreach (var item in parameters.ToList())
            {
                if (item.Key == "x" || item.Key == "label")
                    continue;

                //NDArray.SampleUniform(0, 1, item.Value);
                nd.RandomUniform(shape: item.Value.Shape).CopyTo(item.Value);
            }
            
            var opt = new SGDOptimizer();
            
            BaseMetric metric = new BinaryAccuracy();
            using (var exec = output.SimpleBind(MXNet.Device, parameters))
            {
                dataIter.SetBatch(batchSize);
                var argNames = output.ListArguments();
                for (int iter = 0; iter < 10000; iter++)
                {
                    
                    dataIter.Reset();
                    metric.Reset();

                    while (dataIter.Next())
                    {
                        var batch = dataIter.GetDataBatch();
                        batch.Data.CopyTo(parameters["x"]);
                        batch.Label.CopyTo(parameters["label"]);
                        exec.Forward(true);
                        exec.Backward();

                        for (var i = 0; i < argNames.Count; ++i)
                        {
                            if (argNames[i] == "x" || argNames[i] == "label")
                                continue;

                            opt.Update(iter++, exec.ArgmentArrays[i], exec.GradientArrays[i]);
                        }

                        metric.Update(batch.Label, exec.Outputs.First());
                    }

                    Console.WriteLine("Iteration: {0}, Metric: {1}", iter, metric.Get());
                }
            }
            

            

            //Pred data
            //DataFrame train_x = new DataFrame(2);
            //DataFrame train_y = new DataFrame(1);
            //train_x.AddData(0, 0);
            //train_x.AddData(0, 1);
            //train_x.AddData(1, 0);
            //train_x.AddData(1, 1);

            //train_y.AddData(0);
            //train_y.AddData(1);
            //train_y.AddData(1);
            //train_y.AddData(0);

            //DataFrameIter train = new DataFrameIter(train_x.ToVariable(), train_y.ToVariable());

            ////Build Model
            //Module model = new Module(2);
            //model.Add(new Dense(dim: 64, activation: ActivationType.ReLU, kernalInitializer: new GlorotUniform()));
            //model.Add(new Dense(dim: 32, activation: ActivationType.ReLU, kernalInitializer: new GlorotUniform()));
            //model.Add(new Dense(dim: 1, ActivationType.Sigmoid));

            ////Train
            //model.Compile(OptimizerType.Adam, LossType.MeanSquaredError, MetricType.BinaryAccuracy);
            //model.Fit(train, 1000, 2);

            //Console.ReadLine();
        }
        
    }
}
