using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class FusedRNN : Initializer
    {
        public FusedRNN(int num_hidden, int num_layers, string mode, bool bidirectional = false, float forget_bias = 1)
        {
            throw new NotImplementedException();
        }

        public override void InitWeight(string name, NDArray arr)
        {
            throw new NotImplementedException();
        }
    }
}
