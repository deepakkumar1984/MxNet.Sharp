using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.NN.Initializers
{
    public abstract class BaseInitializer
    {
        public string Name { get; set; }

        public BaseInitializer(string name)
        {
            Name = name;
        }

        public abstract void Generate(NDArray x); 
    }
}
