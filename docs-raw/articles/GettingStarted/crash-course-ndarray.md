# Manipulate data with NDArray

We’ll start by introducing the NDArray, MXNet’s primary tool for storing and transforming data. If you’ve worked with NumSharp before, you’ll notice that an NDArray is, by design, similar to NumSharp multi-dimensional array.

## Get started
To get started, import the MxNet namespace

```csharp
using MxNet;
```

Next, let’s see how to create a 2D array (also called a matrix) with values from two sets of numbers: 1, 2, 3 and 4, 5, 6. This might also be referred to as a tuple of a tuple of integers.

```csharp
var x = nd.Array(new float[,] { { 1, 2, 3 }, { 4, 5, 6 } });
```

We can also create a very simple matrix with the same shape (2 rows by 3 columns), but fill it with 1's.

```csharp
var x = nd.Ones(new Shape(2, 3));
```

Often we’ll want to create arrays whose values are sampled randomly. For example, sampling values uniformly between -1 and 1. Here we create the same shape, but with random sampling.

```csharp
var y = nd.Random.Uniform(-1, 1, new Shape(2, 3));
```

You can also fill an array of a given shape with a given value, such as 2.0.

```csharp
var y = nd.Full(2.0, new Shape(2, 3));
```

As with NumSharp, the dimensions of each NDArray are accessible by accessing the .Shape attribute. We can also query its size, which is equal to the product of the components of the shape. In addition, .DataType tells the data type of the stored values.

```csharp
Console.WriteLine(x.Shape);
Console.WriteLine(x.Size);
Console.WriteLine(x.DataType);
```

## Operations

NDArray supports a large number of standard mathematical operations, such as element-wise multiplication:

```csharp
var x = nd.Full(2, new Shape(2, 3));
var y = nd.Ones(new Shape(2, 3));
var z = x * y;
```

Exponentiation:
```csharp
z = y.Exp();
```

And transposing a matrix to compute a proper matrix-matrix product:
```csharp
z = nd.Dot(x, y.T)
```

## Indexing
MXNet NDArrays support slicing in all the ridiculous ways you might imagine accessing your data. Here’s an example of reading a particular element, which returns a 1D array with shape (1,1).

```csharp
var z = x["2,3"];
```

Read the second and third columns from y.
```csharp
var z = x[":,1:3"];
```

and write to a specific element.
```csharp
x[":,1:3"] = 2.0;
```

Multi-dimensional slicing is also supported.
```csharp
x["1:2,0:2"] = 4.0;
```

## Converting between MXNet NDArray and NumPy Array

Converting MXNet NDArrays to and from NumPy is easy. All the conversion is implicit, so just assigning the MxNet NDArray to Numpy Array variable and vice versa is enough.