using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib
{
    public class Slice
    {
        public int Begin { get; set; }

        public int? End { get; set; }

        public Slice(int begin, int? end)
        {
            Begin = begin;
            End = end;
        }
    }
}
