using MxNet;
using MxNet.Gluon.NN;
using MxNet.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MxNet.Initializers;
using MxNet.Gluon;
using MxNet.Optimizers;
using MxNet.Metrics;

namespace MNIST
{
    public class GluonDemo
    {
        public static void Run()
        {
            var mnist = TestUtils.GetMNIST();
            int batch_size = 100;
            var train_data = new NDArrayIter(mnist["train_data"], mnist["train_label"], batch_size, true);
            var val_data = new NDArrayIter(mnist["test_data"], mnist["test_label"], batch_size);

            var net = new Sequential();
            net.Add(new Dense(128, activation: ActivationActType.Relu));
            net.Add(new Dense(64, activation: ActivationActType.Relu));
            net.Add(new Dense(10));

            var gpus = TestUtils.ListGpus();
            Context[] ctxList = gpus.Count > 0 ?
                                        gpus.Select(x => (Context.Gpu(x))).ToArray() :
                                        new Context[] { Context.Cpu(0) };

            net.Initialize(new Xavier(magnitude: 2.24f), ctxList.ToArray());
            var trainer = new Trainer(net.CollectParams(), new SGD());
            int epoch = 10;
            var metric = new Accuracy();
            var softmax_cross_entropy_loss = new SoftmaxCrossEntropyLoss();
            for (int iter = 0; iter < epoch; iter++)
            {
                train_data.Reset();
                while (!train_data.End())
                {
                    var batch = train_data.Next();
                    var data = Utils.SplitAndLoad(batch.Data[0], ctx_list: ctxList, batch_axis: 0);
                    var label = Utils.SplitAndLoad(batch.Label[0], ctx_list: ctxList, batch_axis: 0);

                    List<NDArray> outputs = new List<NDArray>();
                    using (var ag = Autograd.Record())
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            var x = data[i];
                            var y = label[i];
                            
                            var z = net.Call(x);
                            var z1 = z.NdX.AsArray<float>();
                            NDArray loss = softmax_cross_entropy_loss.Call(z, y);
                            var loss1 = loss.AsArray<float>();
                            loss.Backward();
                            var loss2 = loss.AsArray<float>();
                            outputs.Add(z);
                        }

                        //outputs = Enumerable.Zip(data, label, (x, y) =>
                        //{
                        //    var z = net.Call(x);
                        //    NDArray loss = softmax_cross_entropy_loss.Call(z, y);
                        //    loss.Backward();
                        //    return z;
                        //}).ToList().ToNDArrays();
                    }

                    metric.Update(label, outputs.ToArray());
                    trainer.Step(batch.Data[0].Shape[0]);
                }

                var (name, acc) = metric.Get();
                metric.Reset();
                Console.WriteLine($"Training acc at epoch {iter}: {name}={acc}");
            }
        }
    }
}
