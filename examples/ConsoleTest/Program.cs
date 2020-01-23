using MxNetLib;
using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MXNet.SetDevice(DeviceType.CPU);
            Autograd.SetTraining(true);
            NDArray x = new NDArray(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new Shape(3, 3)).Reshape(new Shape(3, 3));
            x = nd.Square(x);
            var a = Autograd.GetSymbol(x);
            NDArray y = nd.EqualScalar(x, 3);
            //var acc = new Accuracy();
            var data = y.GetValues<float>();
            
            //acc.Update(x, y);
            var eq = nd.Equal(x, y);
            for (int i = 1; i <= 100000; i++)
            {
                x.SampleUniform();
                x = nd.Square(x);
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
