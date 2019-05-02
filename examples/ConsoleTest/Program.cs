using MxNet.NN.Backend;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = Context.Cpu();
            MxNet.NN.GlobalParam.Device = context;

            Symbol x = Symbol.Variable("x");
            Symbol w = Symbol.Variable("w");
            Symbol b = Symbol.Variable("b");

            Symbol y = w * x;

            var dict = new SortedDictionary<string, NDArray>();
            y.InferArgsMap(context, dict, dict);

            dict["x"] = new NDArray(new float[] { 3 }, new Shape(1));
            dict["w"] = new NDArray(new float[] { 2 }, new Shape(1));
            dict["b"] = new NDArray(new float[] { 1 }, new Shape(1));

            var exec = y.SimpleBind(MxNet.NN.GlobalParam.Device, dict);
            
            exec.Forward(true);
            exec.Backward();
            
            var y_data = exec.Outputs[0];
            Console.ReadLine();
        }
    }
}
