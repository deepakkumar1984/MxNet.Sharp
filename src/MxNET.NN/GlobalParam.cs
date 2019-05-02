using MxNet.NN.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.NN
{
    public class GlobalParam
    {
        public static Context Device { get; set; }

        public static bool UseCudnn { get; set; }
    }
}
