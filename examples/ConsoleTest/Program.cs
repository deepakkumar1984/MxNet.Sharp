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

            Symbol a = Symbol.Variable("a");
            Symbol b = Symbol.Variable("b");
            

            Symbol y = 2 * a  + b;

            var dict = new SortedDictionary<string, NDArray>();
            y.InferArgsMap(context, dict, dict);

            dict["a"] = new NDArray(new float[] { 1, 2 }, new Shape(2));
            dict["b"] = new NDArray(new float[] { 2, 3 }, new Shape(2));

            var exec = y.SimpleBind(MxNet.NN.GlobalParam.Device, dict);
            
            exec.Forward(true);
            exec.Backward(exec.Outputs);
            
            var y_data = exec.Outputs[0];
            Console.ReadLine();
        }
    }
}
