# MxNet

Apache MXNet (incubating) is a deep learning framework designed for both efficiency and flexibility. It allows you to mix symbolic and imperative programming to maximize efficiency and productivity. At its core, MXNet contains a dynamic dependency scheduler that automatically parallelizes both symbolic and imperative operations on the fly. A graph optimization layer on top of that makes symbolic execution fast and memory efficient. MXNet is portable and lightweight, scaling effectively to multiple GPUs and multiple machines.

MxNet.Sharp is a CSharp binding coving all the Imperative, Symbolic and Gluon API's with an easy to use interface. The Gluon library in Apache MXNet provides a clear, concise, and simple API for deep learning. It makes it easy to prototype, build, and train deep learning models without sacrificing training speed.

## Nuget

Install the package: Install-Package MxNet.Sharp

https://www.nuget.org/packages/MxNet.Sharp

Add the MxNet redistributed package available as per below. For GPU please make sure you have the correct version of CUDA installed as per package. Latest version is 1.5.0

| Type        |  Name                           | Nuget                                       |
|-------------|---------------------------------|---------------------------------------------|
| MxNet-CPU   | MxNet CPU Version               | Install-Package MxNet.Runtime.Redist        |
| MxNet-MKL   | MxNet CPU with MKL              | Install-Package MxNet-MKL.Runtime.Redist    |
| MxNet-CU101 | MxNet with Cuda 10.1 and CuDnn 7| Install-Package MxNet-CU101.Runtime.Redist  |
| MxNet-CU100 | MxNet with Cuda 10 and CuDnn 7  | Install-Package MxNet-CU100.Runtime.Redist  |

More package to come for Cuda 92 and Cuda 80 with Linux and OSX.

## Symbolic Example
```csharp
model.SetInput(784);

var x = Symbol.Variable("X");
var fc1 = sym.Relu(sym.FullyConnected(x, Symbol.Variable("fc1_w"), 128));
var fc2 = sym.Relu(sym.FullyConnected(fc1, Symbol.Variable("fc2_w"), 128));
var fc3 = sym.FullyConnected(fc2, Symbol.Variable("fc3_w"), 10);
var output = sym.SoftmaxOutput(fc3, Symbol.Variable("label"), symbol_name: "model");

```
## Gluon MNIST Example

Demo as per: https://mxnet.apache.org/api/python/docs/tutorials/packages/gluon/image/mnist.html

```csharp
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
                            new Context[] { Context.Cpu(0), Context.Cpu(1) }; //Set Multiple GPU's

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

        NDArray[] outputs = null;
        using (var ag = Autograd.Record())
        {
            outputs = Enumerable.Zip(data, label, (x, y) =>
            {
                var z = net.Call(x);
                NDArray loss = softmax_cross_entropy_loss.Call(z, y);
                loss.Backward();
                return z;
            }).ToList().ToNDArrays();
        }

        metric.Update(label, outputs);
        trainer.Step(batch.Data[0].Shape[0]);
    }

    var (name, acc) = metric.Get();
    metric.Reset();
    Console.WriteLine($"Training acc at epoch {iter}: {name}={acc}");
}
```
