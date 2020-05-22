# Create a neural network

Now let’s look how to create neural networks in Gluon. In addition the NDArray package (nd) that we just covered, we now will also import the neural network nn package from gluon.

```csharp
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.NN;
```

## Create your neural network’s first layer

Let’s start with a dense layer with 2 output units.

```csharp
layer.Initialize();
```

Then initialize its weights with the default initialization method, which draws random values uniformly from  [−0.7,0.7].

```csharp
layer.Initialize();
```

Then we do a forward pass with random data. We create a  (3,4)  shape random input x and feed into the layer to compute the output.

```csharp
var x = nd.Random.Uniform(-1, 1, new Shape(3, 4));
var y = layer.Call(x);
```

As can be seen, the layer’s input limit of 2 produced a  (3,2)  shape output from our  (3,4)  input. Note that we didn’t specify the input size of layer before (though we can specify it with the argument in_units=4 here), the system will automatically infer it during the first time we feed in data, create and initialize the weights. So we can access the weight after the first forward pass:

```csharp
var weight = layer.Params["weight"].Data();
```

# Chain layers into a neural network
Let’s first consider a simple case that a neural network is a chain of layers. During the forward pass, we run layers sequentially one-by-one. The following code implements a famous network called LeNet through nn.Sequential.

```csharp
var net = new Sequential();

// Similar to Dense, it is not necessary to specify the input channels
// by the argument `in_channels`, which will be  automatically inferred
// in the first forward pass. Also, we apply a relu activation on the
// output. In addition, we can use a tuple to specify a  non-square
// kernel size, such as `kernel_size=(2,4)`
net.Add(new Conv2D(channels: 6, kernel_size: (5, 5), activation: ActivationType.Relu),
    // One can also use a tuple to specify non-symmetric pool and stride sizes
    new MaxPool2D(pool_size: (2, 2), strides: (2, 2)),
    new Conv2D(channels: 16, kernel_size: (3, 3), activation: ActivationType.Relu),
    new MaxPool2D(pool_size: (2, 2), strides: (2, 2)),
    // The dense layer will automatically reshape the 4-D output of last
    // max pooling layer into the 2-D shape: (x.shape[0], x.size/x.shape[0])
    new Dense(120, activation: ActivationType.Relu),
    new Dense(84, activation: ActivationType.Relu),
    new Dense(10)
);
```

The usage of nn.Sequential is similar to nn.Dense. In fact, both of them are subclasses of nn.Block. The following codes show how to initialize the weights and run the forward pass.

```csharp
net.Initialize();
// Input shape is (batch_size, color_channels, height, width)
var x = nd.Random.Uniform(shape: new Shape(4, 1, 28, 28));
NDArray y = net.Call(x);
Console.WriteLine(y.Shape);
```

We can use [] to index a particular layer. For example, the following accesses the 1st layer’s weight and 6th layer’s bias.

```csharp
Console.WriteLine(net[0].Params["weight"].Data().Shape);
Console.WriteLine(net[5].Params["bias"].Data().Shape);
```