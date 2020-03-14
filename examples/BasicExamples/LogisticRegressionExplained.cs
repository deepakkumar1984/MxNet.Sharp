using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.Data;
using MxNet.Gluon.NN;
using MxNet.Initializers;
using MxNet.IO;
using MxNet.Metrics;
using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicExamples
{
    public class LogisticRegressionExplained
    {
        public static void Run()
        {
            //Logistic Regression is one of the first models newcomers to Deep Learning are implementing. 
            //The focus of this tutorial is to show how to do logistic regression using Gluon API.

            var ctx = mx.Cpu();
            int train_data_size = 1000;
            int val_data_size = 100;
            int batch_size = 10;

            var (train_x, train_ground_truth_class) = GetRandomState(train_data_size, ctx);
            var train_dataset = new ArrayDataset(train_x, train_ground_truth_class);
            var train_dataloader  = new DataLoader(train_dataset, batch_size: batch_size, shuffle: true);

            var (val_x, val_ground_truth_class) = GetRandomState(val_data_size, ctx);
            var val_dataset = new ArrayDataset(val_x, val_ground_truth_class);
            var val_dataloader = new DataLoader(val_dataset, batch_size: batch_size, shuffle: true);

            var net = new HybridSequential();
            net.Add(new Dense(units: 10, activation: ActivationType.Relu));
            net.Add(new Dense(units: 10, activation: ActivationType.Relu));
            net.Add(new Dense(units: 10, activation: ActivationType.Relu));
            net.Add(new Dense(units: 1));

            net.Initialize(new Xavier());
            var loss = new SigmoidBinaryCrossEntropyLoss();
            var trainer = new Trainer(net.CollectParams(), new SGD(learning_rate: 0.1f));

            var accuracy = new Accuracy();
            var f1 = new F1();

            float cumulative_train_loss = 0;
            int i = 0;
            foreach (var item in train_dataloader)
            {
                var data = item[0];
                var label = item[1];
            }
        }

        /// <summary>
        /// In this tutorial we will use fake dataset, which contains 10 features drawn from a normal distribution with mean equals to 0 and
        /// standard deviation equals to 1, and a class label, which can be either 0 or 1. The size of the dataset is an arbitrary value. 
        /// The function below helps us to generate a dataset. Class label y is generated via a non-random logic, 
        /// so the network would have a pattern to look for. Boundary of 3 is selected to make sure that number 
        /// of positive examples smaller than negative, but not too small
        /// </summary>
        /// <param name="size"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private static (NDArray, NDArray) GetRandomState(int size, Context ctx)
        {
            var x = nd.Random.Normal(0, 1, shape: new Shape(size, 10), ctx: ctx);
            var y = x.Sum(axis: 1) > 3;
            return (x, y);
        }
    }
}
