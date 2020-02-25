using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.NN;
using MxNet.Initializers;
using MxNet.IO;
using MxNet.Metrics;
using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ORGate
{
    class Program
    {
        static void Main(string[] args)
        {
            NDArray trainX = new NDArray(new float[] { 0, 0, 0, 1, 1, 0, 1, 1 }).Reshape(4, 2);
            NDArray trainY = new NDArray(new float[] { 0, 1, 1, 0 });

            int batch_size = 2;
            var train_data = new NDArrayIter(trainX, trainY, batch_size);
            var val_data = new NDArrayIter(trainX, trainY, batch_size);

            var net = new Sequential();
            net.Add(new Dense(4, activation: ActivationActType.Relu));
            net.Add(new Dense(1));

            var gpus = TestUtils.ListGpus();
            Context[] ctxList = gpus.Count > 0 ?
                                        gpus.Select(x => (Context.Gpu(x))).ToArray() :
                                        new Context[] { Context.Cpu(0) };

            net.Initialize(new Xavier(), ctxList.ToArray());
            var trainer = new Trainer(net.CollectParams(), new SGD());
            int epoch = 1000;
            var metric = new Accuracy();
            var binary_crossentropy = new SigmoidBinaryCrossEntropyLoss();
            for (int iter = 0; iter < epoch; iter++)
            {
                train_data.Reset();
                while (!train_data.End())
                {
                    var batch = train_data.Next();
                    var data = Utils.SplitAndLoad(batch.Data[0], ctx_list: ctxList, batch_axis: 0);
                    var label = Utils.SplitAndLoad(batch.Label[0], ctx_list: ctxList, batch_axis: 0);

                    NDArrayList outputs = new NDArrayList();
                    using (var ag = Autograd.Record())
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            var x = data[i];
                            var y = label[i];

                            var z = net.Call(x);
                            NDArray loss = binary_crossentropy.Call(z, y);
                            loss.Backward();
                            outputs.Add(z);
                        }
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
