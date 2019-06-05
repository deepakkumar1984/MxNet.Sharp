using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNetLib
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

        public static void ValidateParam(string name, string value, params string[] validValues)
        {
            if (!validValues.Contains(value))
            {
                string message = "Invalid value for " + name + ". Valid values are " + string.Join(", ", validValues);
                throw new Exception(message);
            }
        }
    }
}
