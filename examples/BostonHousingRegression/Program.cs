
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;

namespace BostonHousingRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("MXNET_ENGINE_TYPE", "NaiveEngine");



            //Global.Device = Context.Cpu();

            ////Read Data
            //CsvDataFrame trainReader = new CsvDataFrame("./data/train.csv", true);
            //trainReader.ReadCsv();
            //var trainX = trainReader[1, 14];
            //var trainY = trainReader[14, 15];

            //CsvDataFrame valReader = new CsvDataFrame("./data/test.csv", true);
            //valReader.ReadCsv();

            //var valX = valReader[1, 14];
            //var valY = valReader[14, 15];

            //DataFrameIter train = new DataFrameIter(trainX, trainY);
            //DataFrameIter val = new DataFrameIter(valX, valY);

            ////Build Model
            //var model = new Module(13);
            //model.Add(new Dense(13, ActivationType.ReLU));
            //model.Add(new Dense(20, ActivationType.ReLU));
            //model.Add(new Dropout(0.25f));
            //model.Add(new Dense(20, ActivationType.ReLU));
            //model.Add(new Dense(1));

            //model.Compile(Optimizers.Adam(0.01f), LossType.MeanSquaredError, MetricType.MeanAbsoluteError);
            //model.Fit(train, 200, 32);

            Console.ReadLine();
        }

        public void ReadCsv()
        {
            List<float> data = new List<float>();
            using (TextReader fileReader = File.OpenText(_path))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.Delimiter = _delimiter;
                csv.Configuration.HasHeaderRecord = _hasHeaders;

                if (_encoding != null)
                    csv.Configuration.Encoding = _encoding;

                if (_hasHeaders)
                {
                    string[] columnNames = csv.Parser.Read();
                    _cols = (uint)columnNames.Length;
                    Columns = columnNames.ToList();
                }

                while (csv.Read())
                {
                    string[] rowData = csv.Parser.Context.Record;
                    if (_cols == 0)
                    {
                        _cols = (uint)rowData.Length;
                    }

                    foreach (string item in rowData)
                    {
                        DataList.Add(float.Parse(item));
                    }
                }
            }

            GenerateVariable();
        }
    }
}
