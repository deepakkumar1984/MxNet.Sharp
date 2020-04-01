using System;
using MxNet;
using NumpyDotNet;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var npx = new np.random().uniform(newdims: new shape(3, 3));
            var x = new NDArray(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new Shape(3, 3)).Reshape(new Shape(3, 3));
            var ndx = nd.Array(npx.astype(np.Int8));


            
            var buff = x.GetBuffer();
            var x1 = NDArray.LoadFromBuffer(buff);

            var zeros = nd.Zeros(new Shape(3, 3));
            x[":,3"] = x[":,2"];
            var data1 = x.AsArray<float>();
            x = nd.Flip(x, 1);
            x = nd.Square(x);
            var a = Autograd.GetSymbol(x);
            var y = nd.EqualScalar(x, 3);
            //var acc = new Accuracy();
            var data = y.GetValues<float>();
            //acc.Update(x, y);
            var eq = nd.Equal(x, y);
            for (var i = 1; i <= 100000; i++)
            {
                x.SampleUniform();
                x = nd.Square(x);
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}