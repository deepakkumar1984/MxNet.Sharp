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

namespace MNIST
{
    public class GluonDemo
    {
        public static void Run()
        {
            var mnist = TestUtils.GetMNIST();
            uint batch_size = 100;
            var train_data = new NDArrayIter(mnist["train_data"], mnist["train_label"], batch_size, true);
            var val_data = new NDArrayIter(mnist["test_data"], mnist["test_label"], batch_size);

            var net = new Sequential();
            net.Add(new Dense(128, activation: ActivationActType.Relu));
            net.Add(new Dense(64, activation: ActivationActType.Relu));
            net.Add(new Dense(10));

            var gpus = TestUtils.ListGpus();
            List<Context> ctxList = gpus.Count > 0 ?
                                        gpus.Select(x => (Context.Gpu(x))).ToList() :
                                        new List<Context>() { Context.Cpu(0), Context.Cpu(1) };

            net.Initialize(new Xavier(magnitude: 2.24f), ctxList.ToArray());
            var trainer = new Trainer(net.CollectParams(), new SGD());
        }
    }
}
