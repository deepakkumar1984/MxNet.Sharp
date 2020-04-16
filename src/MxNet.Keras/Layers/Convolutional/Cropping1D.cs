using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Layers
{
    public class Cropping1D : _Cropping
    {
        public Cropping1D((int, int)? cropping = null, string data_format = "")
            : base(cropping.HasValue ? cropping.Value : (1, 1), data_format)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
