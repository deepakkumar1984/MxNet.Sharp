using System;
using System.Collections.Generic;
using System.Text;
using MxNet.NN.Backend;

namespace MxNet.NN.Layers
{
    public class RepeatVector : BaseLayer, ILayer
    {
        public int NumTimes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RepeatVector(int numTimes)
            :base("repeatvector")
        {
            NumTimes = numTimes;
        }

        public Symbol Build(Symbol data)
        {
            return new Operator("repeat").SetInput("data", data).SetParam("repeats", NumTimes).CreateSymbol(ID);
        }
        
    }
}
