using SiaDNN.Initializers;
using MxNet.NN;
using MxNet.DotNet;
using MxNet.NN.Data;
using MxNet.NN.Layers;
using System;

namespace BostonHousingRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("MXNET_ENGINE_TYPE", "NaiveEngine");
            Global.Device = Context.Cpu();

            //Read Data
            CsvDataFrame trainReader = new CsvDataFrame("./data/train.csv", true);
            trainReader.ReadCsv();
            var trainX = trainReader[1, 14];
            var trainY = trainReader[14, 15];

            CsvDataFrame valReader = new CsvDataFrame("./data/test.csv", true);
            valReader.ReadCsv();

            var valX = valReader[1, 14];
            var valY = valReader[14, 15];

            DataFrameIter train = new DataFrameIter(trainX, trainY);
            DataFrameIter val = new DataFrameIter(valX, valY);

            //Build Model
            var model = new Module(13);
            model.Add(new Dense(13, ActivationType.ReLU));
            model.Add(new Dense(20, ActivationType.ReLU));
            model.Add(new Dropout(0.25f));
            model.Add(new Dense(20, ActivationType.ReLU));
            model.Add(new Dense(1));

            model.Compile(Optimizers.Adam(0.01f), LossType.MeanSquaredError, MetricType.MeanAbsoluteError);
            model.Fit(train, 200, 32);

            Console.ReadLine();
        }
    }
}
