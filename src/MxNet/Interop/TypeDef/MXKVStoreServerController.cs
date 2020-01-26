using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Interop
{
    public struct MXKVStoreServerController
    {
        public int head;
        public string body;
        public IntPtr controller_handle;
    }
}
