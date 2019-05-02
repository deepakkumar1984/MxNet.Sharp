using System;
using System.Collections.Generic;
using System.Text;
using MxNet.NN.Backend;

namespace SiaDNN.Initializers
{
    public class Bilinear : BaseInitializer
    {
        public string Name
        {
            get
            {
                return "bilinear";
            }
        }

        public override void Operator(string name, NDArray array)
        {
            base.InitBilinear(array);
        }

    }
}
