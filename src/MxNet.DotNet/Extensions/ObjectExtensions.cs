using MxNet.DotNet.Interop;
using System;
using System.Linq;
namespace MxNet.DotNet
{

    public static class ObjectExtensions
    {
        public static string ToValueString(this object source)
        {
            return source is bool b ? (b ? "1" : "0") : source.ToString();
        }
    }

}
