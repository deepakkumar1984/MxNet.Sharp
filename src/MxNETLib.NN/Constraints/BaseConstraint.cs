using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.NN.Constraints
{
    public abstract class BaseConstraint
    {
        public Dictionary<string, object> Params = new Dictionary<string, object>();

        public abstract NDArray Call(NDArray w);

        public Dictionary<string, object> GetConfig()
        {
            return Params;
        }
    }
}
