using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MxNet.OpGenerator
{
    class EnumType
    {
        private static readonly Regex TypeReg = new Regex("'(.*?)'");
        private static readonly Regex TypeRangeReg = new Regex("{(.*)}");
        private readonly string[] _enumValues = null;

        public string Name { get; }
        public EnumType(string typeName = "ElementWiseOpType", string typeString = "{'avg', 'max', 'sum'}")
        {
            Name = ToCamelCase(typeName);

            if (typeString.StartsWith("{"))
            {

                var rangematch = TypeRangeReg.Match(typeString);
                if (rangematch.Success)
                {

                    var matchs = TypeReg.Matches(rangematch.Groups[1].Value);
                    List<string> enums = new List<string>();
                    foreach (Match item in matchs)
                    {
                        enums.Add(item.Groups[1].Value);
                    }
                    _enumValues = enums.ToArray();
                }
            }
        }


        public string GetDefinitionString()
        {
            string ret = "";
            ret += $"public enum {Name}\n{{";
            foreach (var value in _enumValues)
            {
                if (value == "null")
                {
                    ret += $"Null,\n";
                }
                else
                {
                    ret += $"{ToCamelCase(value)},\n";
                }
            }
            if (_enumValues.Length > 0)
            {
                ret = ret.Substring(0, ret.Length - 2);
            }

            ret += "\n};";
            return ret;
        }



        public string GetConvertString()
        {
            string ret = "";
            ret += $"private static readonly List<string> {Name}Convert = new List<string>(){{";
            foreach (var value in _enumValues)
            {
                ret += $"\"{value}\",";
            }
            if (_enumValues.Length > 0)
            {
                ret = ret.Substring(0, ret.Length - 1);
            }

            ret += "};";
            return ret;
        }

        public string GetDefaultValueString(string value = "")
        {
            return Name + "." + ToCamelCase(value);
        }

        private static string ToCamelCase(string name)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(name).Replace("_", "");
        }
    }
}
