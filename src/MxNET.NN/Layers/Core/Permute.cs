using System;
using System.Collections.Generic;
using System.Text;
using MxNet.DotNet;

namespace MxNet.NN.Layers
{
    public class Permute : BaseLayer, ILayer
    {
        /// <summary>
        /// 
        /// </summary>
        public Permute()
            :base("permute")
        {
        }

        public Symbol Build(Symbol data)
        {
            return Operators.transpose(ID, data);
        }
        
    }
}
