using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Utils
{
    public class PBlock
    {
        public static NDArray RecursiveVisit(Block net, Func<Block, bool> callback, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public static void SetLrMult(Block net, string pattern, float mult, bool verbose)
        {
            throw new NotImplementedException();
        }

        public static bool FreezeBNCallback(Block net, bool use_global_stats = true)
        {
            throw new NotImplementedException();
        }

        public static bool FreezeBN(Block net, bool use_global_stats = true)
        {
            throw new NotImplementedException();
        }

        public static void PurgeModelNAN(Block net, float nan= 0, float posinf= 0, float neginf= 0, bool verbose= false)
        {
            throw new NotImplementedException();
        }
    }
}
