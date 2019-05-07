using System;
using System.Collections.Generic;
using System.Text;
using MxNet.DotNet;

namespace MxNet.NN.Layers
{
    public class SliceChannel : BaseLayer, ILayer
    {
        public int NumOutputs { get; set; }

        public int Axis { get; set; }

        public bool Squeeze { get; set; }

        public SliceChannel(int numOutputs, int axis = 1, bool squeeze = false)
            : base("slicechannel")
        {
            NumOutputs = numOutputs;
            Axis = axis;
            Squeeze = squeeze;
        }

        public Symbol Build(Symbol x)
        {
            return ops.NN.SliceChannel(x, NumOutputs, Axis, Squeeze, ID);
        }
    }
}
