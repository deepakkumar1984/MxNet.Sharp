using System;
using System.Collections.Generic;
using System.Text;
using MxNet.DotNet;

namespace MxNet.NN.Layers
{
    public class Dropout : BaseLayer, ILayer
    {
        public float Rate { get; set; }

        public DropoutMode Mode { get; set; }

        public Dropout(float rate, DropoutMode mode = DropoutMode.Training)
            :base("dropout")
        {

        }

        public Symbol Build(Symbol data)
        {
            return ops.NN.Dropout(data, Rate, Mode, ID);
        }
        
    }
}
