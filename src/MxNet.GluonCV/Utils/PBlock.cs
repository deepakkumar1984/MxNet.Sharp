using MxNet.Gluon;
using MxNet.Gluon.NN;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MxNet.GluonCV.Utils
{
    public class PBlock
    {
        public static void RecursiveVisit(Block net, Action<Block, bool> callback, bool use_global_stats = true)
        {
            callback(net, use_global_stats);
            
            foreach (var _tup_1 in net._childrens)
            {
                var child = _tup_1.Value;
                RecursiveVisit(child, callback, use_global_stats);
            }
        }

        public static void SetLrMult(Block net, string pattern, float mult, bool verbose)
        {
            var regex = new Regex(pattern);
            foreach (var p in net.CollectParams())
            {
                var key = p.Key;
                var value = p.Value;
                if (!regex.Match(key).Success)
                {
                    continue;
                }

                value.Lr_Mult = mult;

                if (verbose)
                {
                    Console.WriteLine($"Set lr_mult of {value.Name} to {mult}");
                }
            }
        }

        public static void FreezeBNCallback(Block net, bool use_global_stats = true)
        {
            if (net.GetType().Name == "BatchNorm")
            {
                ((BatchNorm)net).Use_Global_Stats = use_global_stats;
            }
        }

        public static void FreezeBN(Block net, bool use_global_stats = true)
        {
            RecursiveVisit(net, FreezeBNCallback, use_global_stats);
        }

        public static void PurgeModelNAN(Block net, float nan= 0, float posinf= 0, float neginf= 0, bool verbose= false)
        {
            foreach (var p in net.CollectParams())
            {
                var k = p.Key;
                var v = p.Value;
                var np_data = v.Data().AsNumpy();
                if (np.isfinite(np_data).All() != null)
                {
                    if (verbose)
                    {
                        Console.WriteLine(k, $": Overwritten {(np_data.size - np.isfinite(np_data).Sum())} values...");
                    }

                    var new_data = np.nan_to_num(np_data);
                    v.SetData(nd.Array(new_data));
                }
            }
        }
    }
}
