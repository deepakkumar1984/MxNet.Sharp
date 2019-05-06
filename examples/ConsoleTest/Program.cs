using MxNet.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = Context.Cpu();
            Global.Device = context;
            //NDArray x_t = new NDArray(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new Shape(3, 3));
            NDArray w_t = nd.RandomUniform(new Shape(3, 3));
            //var y_t = x_t * w_t;
            Symbol x = new Symbol("x");
            Symbol w = new Symbol("w");

            var y = sym.Mean(sym.Sqrt(w * x + 2), new Shape(1));
            
            Dictionary<string, NDArray> param = new Dictionary<string, NDArray>();
            y.InferArgsMap(context, param, param);
            
            param["x"] = new NDArray(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new Shape(3, 3));
            param["w"] = nd.Ones(new Shape(3, 3));

            var exec= y.SimpleBind(context, param);
            exec.Forward(true);
            exec.Backward();
            

            Console.ReadLine();
        }
    }
}
