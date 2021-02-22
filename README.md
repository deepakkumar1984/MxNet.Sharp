# Work In Progress version 2.0. There will be breaking change as per RFC: https://github.com/apache/incubator-mxnet/issues/16167

[![Gitter](https://badges.gitter.im/mxnet-sharp/community.svg)](https://gitter.im/mxnet-sharp/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
![MxNet.Sharp CI](https://github.com/tech-quantum/MxNet.Sharp/workflows/MxNet.Sharp%20Build/badge.svg)

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

**MxNet.Sharp**

MxNet.Sharp is a CSharp binding coving all the Imperative, Symbolic and Gluon API's with an easy to use interface. The Gluon library in Apache MXNet provides a clear, concise, and simple API for deep learning. It makes it easy to prototype, build, and train deep learning models without sacrificing training speed.

**High Level Arch**


![High Level Arch](https://raw.githubusercontent.com/SciSharp/MxNet.Sharp/master/HLA.PNG)

## Nuget

Install the package: Install-Package MxNet.Sharp

https://www.nuget.org/packages/MxNet.Sharp

Add the MxNet redistributed package available as per below.

**Important: Make sure your installed CUDA version matches the CUDA version in the nuget package.**

Check your CUDA version with the following command:
```
nvcc --version
```

You can either upgrade your CUDA install or install the MXNet package that supports your CUDA version.

MxNet Version Build: https://github.com/apache/incubator-mxnet/releases/tag/1.5.0

**Win-x64 Packages**

| Type           |  Name                                    | Nuget                                           |
|----------------|------------------------------------------|-------------------------------------------------|
| MxNet-CPU      | MxNet CPU Version                        | Install-Package MxNet.Runtime.Redist            |
| MxNet-MKL      | MxNet CPU with MKL                       | Install-Package MxNet-MKL.Runtime.Redist        |
| MxNet-CU101    | MxNet for Cuda 10.1 and CuDnn 7          | Install-Package MxNet-CU101.Runtime.Redist      |
| MxNet-CU101MKL | MxNet for Cuda 10.1 and CuDnn 7          | Install-Package MxNet-CU101MKL.Runtime.Redist   |
| MxNet-CU100    | MxNet for Cuda 10 and CuDnn 7            | Install-Package MxNet-CU100.Runtime.Redist      |
| MxNet-CU100MKL | MxNet with MKL for Cuda 10 and CuDnn 7   | Install-Package MxNet-CU100MKL.Runtime.Redist   |
| MxNet-CU92     | MxNet for Cuda 9.2 and CuDnn 7           | Install-Package MxNet-CU100.Runtime.Redist      |
| MxNet-CU92MKL  | MxNet with MKL for Cuda 9.2 and CuDnn 7  | Install-Package MxNet-CU92MKL.Runtime.Redist    |
| MxNet-CU80     | MxNet for Cuda 8.0 and CuDnn 7           | Install-Package MxNet-CU100.Runtime.Redist      |
| MxNet-CU80MKL  | MxNet with MKL for Cuda 8.0 and CuDnn 7  | Install-Package MxNet-CU80MKL.Runtime.Redist    |

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
  

## Gluon MNIST Example

Demo as per: https://mxnet.apache.org/api/python/docs/tutorials/packages/gluon/image/mnist.html

```csharp
var mnist = TestUtils.GetMNIST(); //Get the MNIST dataset, it will download if not found
var batch_size = 200; //Set training batch size
var train_data = new NDArrayIter(mnist["train_data"], mnist["train_label"], batch_size, true);
var val_data = new NDArrayIter(mnist["test_data"], mnist["test_label"], batch_size);

// Define simple network with dense layers
var net = new Sequential();
net.Add(new Dense(128, ActivationType.Relu));
net.Add(new Dense(64, ActivationType.Relu));
net.Add(new Dense(10));

//Set context, multi-gpu supported
var gpus = TestUtils.ListGpus();
var ctx = gpus.Count > 0 ? gpus.Select(x => Context.Gpu(x)).ToArray() : new[] {Context.Cpu(0)};

//Initialize the weights
net.Initialize(new Xavier(magnitude: 2.24f), ctx);

//Create the trainer with all the network parameters and set the optimizer
var trainer = new Trainer(net.CollectParams(), new Adam());

var epoch = 10;
var metric = new Accuracy(); //Use Accuracy as the evaluation metric.
var softmax_cross_entropy_loss = new SoftmaxCELoss();
float lossVal = 0; //For loss calculation
for (var iter = 0; iter < epoch; iter++)
{
    var tic = DateTime.Now;
    // Reset the train data iterator.
    train_data.Reset();
    lossVal = 0;

    // Loop over the train data iterator.
    while (!train_data.End())
    {
        var batch = train_data.Next();

        // Splits train data into multiple slices along batch_axis
        // and copy each slice into a context.
        var data = Utils.SplitAndLoad(batch.Data[0], ctx, batch_axis: 0);

        // Splits train labels into multiple slices along batch_axis
        // and copy each slice into a context.
        var label = Utils.SplitAndLoad(batch.Label[0], ctx, batch_axis: 0);

        var outputs = new NDArrayList();

        // Inside training scope
        using (var ag = Autograd.Record())
        {
            outputs = Enumerable.Zip(data, label, (x, y) =>
            {
                var z = net.Call(x);

                // Computes softmax cross entropy loss.
                NDArray loss = softmax_cross_entropy_loss.Call(z, y);

                // Backpropagate the error for one iteration.
                loss.Backward();
                lossVal += loss.Mean();
                return z;
            }).ToList();
        }

        // Updates internal evaluation
        metric.Update(label, outputs.ToArray());

        // Make one step of parameter update. Trainer needs to know the
        // batch size of data to normalize the gradient by 1/batch_size.
        trainer.Step(batch.Data[0].Shape[0]);
    }

    var toc = DateTime.Now;

    // Gets the evaluation result.
    var (name, acc) = metric.Get();

    // Reset evaluation result to initial state.
    metric.Reset();
    Console.Write($"Loss: {lossVal} ");
    Console.WriteLine($"Training acc at epoch {iter}: {name}={(acc * 100).ToString("0.##")}%, Duration: {(toc - tic).TotalSeconds.ToString("0.#")}s");
}
```

Reached accuracy of 98% within 6th epoch.

![alt text](https://raw.githubusercontent.com/tech-quantum/MxNet.Sharp/master/examples/MNIST/MnistTrain.PNG "MNIST Training")


# Documentation (In Progress)

https://mxnet.tech-quantum.com/
