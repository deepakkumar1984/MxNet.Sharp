using MxNet.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Cuda
{
    /// <summary>
    /// Utilities for NVTX usage in MXNet
    /// </summary>
    public class NVTX
    {
        public static int RED = 0xFF0000;

        public static int GREEN = 0x00FF00;

        public static int BLUE = 0x0000FF;

        public static int YELLOW = 0xB58900;

        public static int ORANGE = 0xCB4B16;

        public static int RED1 = 0xDC322F;

        public static int MAGENTA = 0xD33682;

        public static int VIOLET = 0x6C71C4;

        public static int BLUE1 = 0x268BD2;

        public static int CYAN = 0x2AA198;

        public static int GREEN1 = 0x859900;

        public static void RangePush(string name, int color = 0xCB4B16)
        {
            NativeMethods.MXNVTXRangePush(name, color);
        }

        // Ends a NVTX range.
        public static void RangePop()
        {
            NativeMethods.MXNVTXRangePop();
        }

        public class Range : IDisposable
        {
            private int color;

            private string name;

            public Range(string name, int color = 0xCB4B16)
            {
                this.name = name;
                this.color = color;
                RangePush(this.name, this.color);
            }

            public void Dispose()
            {
                RangePop();
            }
        }
    }

    
}
