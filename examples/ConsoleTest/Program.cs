using System;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.NN;
using MxNet.GluonCV.Data.Transforms.Presets;
using MxNet.Image;
using NumpyDotNet;
using OpenCvSharp;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var arrays = NDArray.LoadNpz(@"C:\Users\deepa\Downloads\imdb.npz");
            Console.ReadLine();
        }
    }
}