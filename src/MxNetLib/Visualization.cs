using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib
{
    public class Visualization
    {
        private static string[] StringToTuple(string str) => throw new NotImplementedException();

        public static void PrintSummary(Symbol symbol, Shape shape= null, int line_length= 120, float[] positions= null)
        {
            throw new NotImplementedException();
        }

        public void plot_network(Symbol symbol, string title = "plot", string save_format = "pdf", Shape shape = null,
                        DType dtype = null, Dictionary<string, string> node_attrs = null, bool hide_weights = true) => throw new NotImplementedException();
    }
}
