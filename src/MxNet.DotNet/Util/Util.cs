using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public class Util
    {
        public static string EnumToString<TEnum>(TEnum? _enum, List<string> convert) where TEnum : struct, IConvertible
        {
            if (_enum.HasValue)
            {
                var v = _enum.Value as object;
                return convert[(int)v];
            }

            return null;

        }
    }
}
