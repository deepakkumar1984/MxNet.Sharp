MxNet.Sharp is divided into to types of NuGet packages:
* Framework library
* Core Redistributed Build

The MxNet.Sharp is the library with all the binding and interface build using the core MxNet build. The core library is build in various flavour like CPU, MKL, CUDA etc which you can easy search in NuGet. 

## NuGet

Install the package: Install-Package MxNet.Sharp

https://www.NuGet.org/packages/MxNet.Sharp

Add the MxNet redistributed package available as per below.

**Important: Make sure your installed CUDA version matches the CUDA version in the NuGet package.**

Check your CUDA version with the following command:
```
nvcc --version
```

You can either upgrade your CUDA install or install the MXNet package that supports your CUDA version.

MxNet Version Build: https://github.com/apache/incubator-mxnet/releases/tag/1.5.0

**Win-x64 Packages**

Name                                    | NuGet                                           |
|----------------|------------------------------------------|-------------------------------------------------|
MxNet CPU Version                        | MxNet.Runtime.Redist            |
MxNet CPU with MKL                       | MxNet-MKL.Runtime.Redist        |
MxNet for Cuda 10.1 and CuDnn 7          | MxNet-CU101.Runtime.Redist      |
MxNet for Cuda 10.1 and CuDnn 7          | MxNet-CU101MKL.Runtime.Redist   |
MxNet for Cuda 10 and CuDnn 7            | MxNet-CU100.Runtime.Redist      |
MxNet with MKL for Cuda 10 and CuDnn 7   | MxNet-CU100MKL.Runtime.Redist   |
MxNet for Cuda 9.2 and CuDnn 7           | MxNet-CU100.Runtime.Redist      |
MxNet with MKL for Cuda 9.2 and CuDnn 7  | MxNet-CU92MKL.Runtime.Redist    |
MxNet for Cuda 8.0 and CuDnn 7           | MxNet-CU100.Runtime.Redist      |
MxNet with MKL for Cuda 8.0 and CuDnn 7  | MxNet-CU80MKL.Runtime.Redist    |

**Linux-x64 Packages**

Name                                    | NuGet                                             |
|----------------|------------------------------------------|---------------------------------------------------|
MxNet CPU Version                        | MxNet.Linux.Runtime.Redist        |
MxNet CPU with MKL                       | MxNet-MKL.Linux.Runtime.Redist    |
MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                                |
MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                                |
MxNet for Cuda 10 and CuDnn 7            | **Yet to publish**                                |
MxNet with MKL for Cuda 10 and CuDnn 7   | **Yet to publish**                                |
MxNet for Cuda 9.2 and CuDnn 7           | **Yet to publish**                                |
MxNet with MKL for Cuda 9.2 and CuDnn 7  | **Yet to publish**                                |
MxNet for Cuda 8.0 and CuDnn 7           | **Yet to publish**                                |
MxNet with MKL for Cuda 8.0 and CuDnn 7  | **Yet to publish**                                |

**OSX-x64 Packages**

Name                                    | NuGet                                             |
|----------------|------------------------------------------|---------------------------------------------------|
MxNet CPU Version                        | **Yet to publish**                                |
MxNet CPU with MKL                       | **Yet to publish**                                |
MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                                |
MxNet for Cuda 10.1 and CuDnn 7          | **Yet to publish**                                |
MxNet for Cuda 10 and CuDnn 7            | **Yet to publish**                                |
MxNet with MKL for Cuda 10 and CuDnn 7   | **Yet to publish**                                |
MxNet for Cuda 9.2 and CuDnn 7           | **Yet to publish**                                |
MxNet with MKL for Cuda 9.2 and CuDnn 7  | **Yet to publish**                                |
MxNet for Cuda 8.0 and CuDnn 7           | **Yet to publish**                                |
MxNet with MKL for Cuda 8.0 and CuDnn 7  | **Yet to publish**                                |
  