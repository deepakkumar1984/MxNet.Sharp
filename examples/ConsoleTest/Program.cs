using MxNet.DotNet;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = Context.Cpu();
            Global.Device = context;
            MXNet mx = new MXNet();
            

            Symbol a = Symbol.Variable("a");
            Symbol b = Symbol.Variable("b");


            //Symbol y = 2 * a  + b;
            var y = mx.sym.Minimum(a, 3);
            var dict = new SortedDictionary<string, NDArray>();
            y.InferArgsMap(context, dict, dict);

            dict["a"] = new NDArray(new float[] { 1, 2, 3, 4, 5, 6 }, new Shape(3, 2));
            dict["b"] = new NDArray(new float[] { 6, 5, 4, 3, 2, 1 }, new Shape(2, 3));

            var exec = y.SimpleBind(Global.Device, dict);
            
            exec.Forward(true);
            exec.Backward(exec.Outputs);
            
            var y_data = exec.Outputs[0];
            Console.ReadLine();
        }
    }
}
