<div align="center">
  <a href="https://mxnet.apache.org/"><img src="https://raw.githubusercontent.com/dmlc/web-data/master/mxnet/image/mxnet_logo_2.png"></a><br>
</div>

Apache MXNet (incubating) for Deep Learning
=====


Apache MXNet (incubating) is a deep learning framework designed for both *efficiency* and *flexibility*.
It allows you to ***mix*** [symbolic and imperative programming](https://mxnet.apache.org/api/architecture/program_model)
to ***maximize*** efficiency and productivity.
At its core, MXNet contains a dynamic dependency scheduler that automatically parallelizes both symbolic and imperative operations on the fly.
A graph optimization layer on top of that makes symbolic execution fast and memory efficient.
MXNet is portable and lightweight, scaling effectively to multiple GPUs and multiple machines.

MXNet is more than a deep learning project. It is a collection of
[blue prints and guidelines](https://mxnet.apache.org/api/architecture/overview) for building
deep learning systems, and interesting insights of DL systems for hackers.

**MxNet.Sharp**

MxNet.Sharp is a CSharp binding coving all the Imperative, Symbolic and Gluon API's with an easy to use interface. The Gluon library in Apache MXNet provides a clear, concise, and simple API for deep learning. It makes it easy to prototype, build, and train deep learning models without sacrificing training speed.

## Nuget

Install the package: Install-Package MxNet.Sharp

https://www.nuget.org/packages/MxNet.Sharp

Add the MxNet redistributed package available as per below. For GPU please make sure you have the correct version of CUDA installed as per package. 

MxNet Version Build: https://github.com/apache/incubator-mxnet/releases/tag/1.5.0

**Win-x64 Packages**

| Type           |  Name                                    | Nuget                                       |
|----------------|------------------------------------------|---------------------------------------------|
| MxNet-CPU      | MxNet CPU Version                        | Install-Package MxNet.Runtime.Redist        |
| MxNet-MKL      | MxNet CPU with MKL                       | Install-Package MxNet-MKL.Runtime.Redist    |
| MxNet-CU101    | MxNet for Cuda 10.1 and CuDnn 7          | Install-Package MxNet-CU101.Runtime.Redist  |
| MxNet-CU101MKL | MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                          |
| MxNet-CU100    | MxNet for Cuda 10 and CuDnn 7            | Install-Package MxNet-CU100.Runtime.Redist  |
| MxNet-CU100MKL | MxNet with MKL for Cuda 10 and CuDnn 7   | **Yet to publish**                          |
| MxNet-CU92     | MxNet for Cuda 9.2 and CuDnn 7           | Install-Package MxNet-CU100.Runtime.Redist  |
| MxNet-CU92MKL  | MxNet with MKL for Cuda 9.2 and CuDnn 7  | **Yet to publish**                          |
| MxNet-CU80     | MxNet for Cuda 8.0 and CuDnn 7           | Install-Package MxNet-CU100.Runtime.Redist  |
| MxNet-CU80MKL  | MxNet with MKL for Cuda 8.0 and CuDnn 7  | **Yet to publish**                          |

**Linux-x64 Packages**

| Type           |  Name                                    | Nuget                                             |
|----------------|------------------------------------------|---------------------------------------------------|
| MxNet-CPU      | MxNet CPU Version                        | Install-Package MxNet.Linux.Runtime.Redist        |
| MxNet-MKL      | MxNet CPU with MKL                       | Install-Package MxNet-MKL.Linux.Runtime.Redist    |
| MxNet-CU101    | MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                                |
| MxNet-CU101MKL | MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                                |
| MxNet-CU100    | MxNet for Cuda 10 and CuDnn 7            | **Yet to publish**                                |
| MxNet-CU100MKL | MxNet with MKL for Cuda 10 and CuDnn 7   | **Yet to publish**                                |
| MxNet-CU92     | MxNet for Cuda 9.2 and CuDnn 7           | **Yet to publish**                                |
| MxNet-CU92MKL  | MxNet with MKL for Cuda 9.2 and CuDnn 7  | **Yet to publish**                                |
| MxNet-CU80     | MxNet for Cuda 8.0 and CuDnn 7           | **Yet to publish**                                |
| MxNet-CU80MKL  | MxNet with MKL for Cuda 8.0 and CuDnn 7  | **Yet to publish**                                |

**OSX-x64 Packages**

| Type           |  Name                                    | Nuget                                             |
|----------------|------------------------------------------|---------------------------------------------------|
| MxNet-CPU      | MxNet CPU Version                        | **Yet to publish**                                |
| MxNet-MKL      | MxNet CPU with MKL                       | **Yet to publish**                                |
| MxNet-CU101    | MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                                |
| MxNet-CU101MKL | MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                                |
| MxNet-CU100    | MxNet for Cuda 10 and CuDnn 7            | **Yet to publish**                                |
| MxNet-CU100MKL | MxNet with MKL for Cuda 10 and CuDnn 7   | **Yet to publish**                                |
| MxNet-CU92     | MxNet for Cuda 9.2 and CuDnn 7           | **Yet to publish**                                |
| MxNet-CU92MKL  | MxNet with MKL for Cuda 9.2 and CuDnn 7  | **Yet to publish**                                |
| MxNet-CU80     | MxNet for Cuda 8.0 and CuDnn 7           | **Yet to publish**                                |
| MxNet-CU80MKL  | MxNet with MKL for Cuda 8.0 and CuDnn 7  | **Yet to publish**                                |
  
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
