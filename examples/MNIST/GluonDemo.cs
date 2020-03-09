using System;
using System.Linq;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.NN;
using MxNet.Initializers;
using MxNet.IO;
using MxNet.Metrics;
using MxNet.Optimizers;

namespace MNIST
{
    public class GluonDemo
    {
        public static void Run()
        {
            var mnist = TestUtils.GetMNIST();
            var batch_size = 200;
            var train_data = new NDArrayIter(mnist["train_data"], mnist["train_label"], batch_size, true);
            var val_data = new NDArrayIter(mnist["test_data"], mnist["test_label"], batch_size);

            var net = new Sequential();
            net.Add(new Dense(128, ActivationActType.Relu));
            net.Add(new Dense(64, ActivationActType.Relu));
            net.Add(new Dense(10));

            var gpus = TestUtils.ListGpus();
            var ctxList = gpus.Count > 0 ? gpus.Select(x => Context.Gpu(x)).ToArray() : new[] {Context.Cpu(0)};

            net.Initialize(new Xavier(), ctxList.ToArray());
            var trainer = new Trainer(net.CollectParams(), new SGD());
            var epoch = 100;
            var metric = new Accuracy();
            var softmax_cross_entropy_loss = new SoftmaxCrossEntropyLoss();
            float lossVal = 0;
            for (var iter = 0; iter < epoch; iter++)
            {
                train_data.Reset();
                lossVal = 0;
                while (!train_data.End())
                {
                    var batch = train_data.Next();
                    var data = Utils.SplitAndLoad(batch.Data[0], ctxList);
                    var label = Utils.SplitAndLoad(batch.Label[0], ctxList);

                    var outputs = new NDArrayList();
                    using (var ag = Autograd.Record())
                    {
                        for (var i = 0; i < data.Length; i++)
                        {
                            var x = data[i];
                            var y = label[i];

                            var z = net.Call(x);
                            NDArray loss = softmax_cross_entropy_loss.Call(z, y);
                            loss.Backward();
                            lossVal += loss.Mean();
                            outputs.Add(z);
                        }

                        //outputs = Enumerable.Zip(data, label, (x, y) =>
                        //{
                        //    var z = net.Call(x);
                        //    NDArray loss = softmax_cross_entropy_loss.Call(z, y);
                        //    loss.Backward();
                        //    lossVal += loss.Mean();
                        //    return z;
                        //}).ToList();
                    }

                    metric.Update(label, outputs.ToArray());
                    trainer.Step(batch.Data[0].Shape[0]);
                }

                var (name, acc) = metric.Get();
                metric.Reset();
                Console.WriteLine($"Loss: {lossVal}");
                Console.WriteLine($"Training acc at epoch {iter}: {name}={acc}");
            }
        }
    }
}