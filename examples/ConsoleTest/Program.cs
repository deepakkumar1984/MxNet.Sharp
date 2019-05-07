using MxNetLib;
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
            NDArray x = new NDArray(new Shape(32, 32));
            nd.RandomNormal(shape: x.Shape).CopyTo(x);

            for (int i = 1; i <= 100000; i++)
            {
                x = nd.Square(x);
                Console.WriteLine(i);
                x.WaitToRead();
            }

            Console.ReadLine();
        }
    }
}
