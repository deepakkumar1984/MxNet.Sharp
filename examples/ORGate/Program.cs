using SiaDNN.Initializers;
using MxNet.NN;
using MxNet.DotNet;
using MxNet.NN.Data;
using MxNet.NN.Layers;
using System;

namespace ORGate
{
    class Program
    {
        static void Main(string[] args)
        {
            Global.Device = Context.Cpu();

            //Pred data
            DataFrame train_x = new DataFrame(2);
            DataFrame train_y = new DataFrame(1);
            train_x.AddData(0, 0);
            train_x.AddData(0, 1);
            train_x.AddData(1, 0);
            train_x.AddData(1, 1);

            train_y.AddData(0);
            train_y.AddData(1);
            train_y.AddData(1);
            train_y.AddData(0);

            DataFrameIter train = new DataFrameIter(train_x.ToVariable(), train_y.ToVariable());

            //Build Model
            Sequential model = new Sequential(2);
            model.Add(new Dense(dim: 64, activation: ActivationType.ReLU, kernalInitializer: new GlorotUniform()));
            model.Add(new Dense(dim: 32, activation: ActivationType.ReLU, kernalInitializer: new GlorotUniform()));
            model.Add(new Dense(dim: 1, ActivationType.Sigmoid));

            //Train
            model.Compile(OptimizerType.Adam, LossType.MeanSquaredError, MetricType.BinaryAccuracy);
            model.Fit(train, 1000, 2);
            
            Console.ReadLine();
        }
        
    }
}
