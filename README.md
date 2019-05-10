# MxNet

Apache MXNet (incubating) is a deep learning framework designed for both efficiency and flexibility. It allows you to mix symbolic and imperative programming to maximize efficiency and productivity. At its core, MXNet contains a dynamic dependency scheduler that automatically parallelizes both symbolic and imperative operations on the fly. A graph optimization layer on top of that makes symbolic execution fast and memory efficient. MXNet is portable and lightweight, scaling effectively to multiple GPUs and multiple machines.

MXNet is more than a deep learning project. It is a collection of blue prints and guidelines for building deep learning systems, and interesting insights of DL systems for hackers.

mxnetlib is a CSharp binding coving all the Imperative and Symbolic API's with an easy to use interface. Also developed a high level interface to build and train model. 

## Symbolic Example
```csharp
model.SetInput(784);

var x = Symbol.Variable("X");
var fc1 = sym.Relu(sym.FullyConnected(x, Symbol.Variable("fc1_w"), 128));
var fc2 = sym.Relu(sym.FullyConnected(fc1, Symbol.Variable("fc2_w"), 128));
var fc3 = sym.FullyConnected(fc2, Symbol.Variable("fc3_w"), 10);
var output = sym.SoftmaxOutput(fc3, Symbol.Variable("label"), symbol_name: "model");

model.SetDefaultInitializer(new RandomUniform(-1, 1));
model.Compile(output, OptimizerRegistry.SGD(), MetricType.Accuracy);
```

## High Level API Example
```csharp
model.SetInput(784);

model.Add(new Dense(128, ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));
model.Add(new Dense(128, ActivationType.ReLU, kernalInitializer: new RandomUniform(-1, 1)));
model.Add(new Dense(10));

model.Compile(OptimizerRegistry.SGD(), LossType.SoftmaxCategorialCrossEntropy, MetricType.Accuracy);
```

## Train and Inference

```csharp

//Training for 10 epoch
model.Fit(train, 10, batchSize, val);

//Load test data
ImageDataFrame frame = new ImageDataFrame(1, 28, 28);
frame.LoadImages("test_6.png", "test_4.png", "test_4.png", "test_6.png");
NDArray test = frame.ToVariable().Ravel() / 255;

// Predict
var prediction = model.Predict(test).Argmax();
Console.WriteLine(prediction.ToString());
```

## Saving and Loading model and checkpoint

```csharp
string modelFolder = "../../../model";
model.SaveModel(modelFolder);
model.SaveCheckpoint(modelFolder);

var loadedModel = Module.LoadModel(modelFolder);
loadedModel.LoadCheckpoint(modelFolder);
```
