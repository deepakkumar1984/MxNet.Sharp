using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public class Global
    {
        public static Context Device { get; set; }

        public static bool UseCudnn { get; set; }
    }
}
