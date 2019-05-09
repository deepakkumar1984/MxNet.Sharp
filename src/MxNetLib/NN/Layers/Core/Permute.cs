using System;
using System.Collections.Generic;
using System.Text;
using MxNetLib;

namespace MxNetLib.NN.Layers
{
    public class Permute : BaseLayer
    {
        /// <summary>
        /// 
        /// </summary>
        public Permute()
            :base("permute")
        {
        }

        public override Symbol Build(Symbol data)
        {
            return sym.Transpose(data);
        }
        
    }
}
