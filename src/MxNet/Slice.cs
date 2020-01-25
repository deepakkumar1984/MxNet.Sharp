using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet
{
    public class Slice
    {
        public uint Begin { get; set; }

        public uint? End { get; set; }

        public Slice(uint begin, uint? end)
        {
            Begin = begin;
            End = end;
        }
    }
}
