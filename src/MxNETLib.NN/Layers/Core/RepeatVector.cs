using System;
using System.Collections.Generic;
using System.Text;
using MxNetLib;

namespace MxNetLib.NN.Layers
{
    public class RepeatVector : BaseLayer
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

        public override Symbol Build(Symbol data)
        {
            return new Operator("repeat").SetInput("data", data).SetParam("repeats", NumTimes).CreateSymbol(ID);
        }
        
    }
}
