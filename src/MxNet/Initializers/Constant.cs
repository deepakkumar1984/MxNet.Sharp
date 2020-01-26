using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Constant : Initializer
    {
        public float Value { get; set; }

        public Constant(float value)
        {
            Value = value;
        }

        public override void InitWeight(string name, NDArray arr)
        {
            arr.Constant(Value);
        }
    }
}
