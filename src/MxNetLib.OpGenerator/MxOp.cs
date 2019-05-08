using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Text;

namespace MxNetLib.OpGenerator
{    /// <summary>
     /// 
     /// </summary>
    enum OpNdArrayOrSymbol
    {
        Symbol,
        NDArray
    }

    internal class MxOp
    {
        private static readonly Regex R = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);

        public string Name { get; set; }

        public string Description { get; set; }
        private List<MxOpArg> Args { get; set; }
        private List<MxOpArg> argsLocal;
        private readonly List<MxOpArg> _argCss;
        public string ClsName;

        public MxOp(string name, string description, List<MxOpArg> args)
        {
            this.Name = name;
            if(name.StartsWith("_image"))
            {
                ClsName = "Image";
            }
            else if (name.StartsWith("_contrib"))
            {
                ClsName = "Contrib";
            }
            else
            {
                ClsName = "";
            }

            this.Description = description;
            argsLocal = new List<MxOpArg>();
            var nameArg = new MxOpArg(name,
                "symbol_name",
                "string",
                "name of the resulting symbol");
            nameArg.HasDefault = true;
            nameArg.DefaultString = "\"\"";
            argsLocal.AddRange(args);
            this.Args = args.ToList();
            Args.Add(nameArg);
            this._argCss = args.Where(w => !w.HasDefault).Concat(args.Where(w => w.HasDefault)).ToList();
            this._argCss.Add(nameArg);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="useName"></param>
        /// <param name="opNdArrayOrSymbol"></param>
        /// <returns></returns>
        public string GetOpDefinitionString(bool useName, OpNdArrayOrSymbol opNdArrayOrSymbol, ref string enumret)
        {

            string ndArrayOrSymbol = "";
            switch (opNdArrayOrSymbol)
            {
                case OpNdArrayOrSymbol.Symbol:
                    ndArrayOrSymbol = "Symbol";
                    break;
                case OpNdArrayOrSymbol.NDArray:
                    ndArrayOrSymbol = "NDArray";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opNdArrayOrSymbol), opNdArrayOrSymbol, null);
            }

            string ret = "";
            List<MxOpArg> argsLocal = this._argCss.Skip(useName ? 0 : 1).ToList();
            switch (opNdArrayOrSymbol)
            {
                case OpNdArrayOrSymbol.Symbol:
           
                    break;
                case OpNdArrayOrSymbol.NDArray:
                    if (useName)
                    {
                        argsLocal = this._argCss.Skip(1).ToList();
                        argsLocal.Insert(0, new MxOpArg("", "@out", "NDArray-or-Symbol", "output Ndarray") { });
                    }
              
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opNdArrayOrSymbol), opNdArrayOrSymbol, null);
            }

            //enum
            if (useName)
            {
                foreach (var arg in argsLocal.Where(w => w.IsEnum))
                {
                    enumret += $"/// <summary>\n/// {arg.Description.Replace("\n", "")}\n/// </summary>\n";
                    enumret += arg.Enum.GetDefinitionString() + "\n";
                    ret += arg.Enum.GetConvertString() + "\n";
                }
            }

            //comments 
            ret += $"/// <summary>\n/// {Description.Replace("\n", "")}\n/// </summary>\n";

            foreach (var arg in argsLocal)
            {
                ret += $"/// <param name=\"{arg.Name}\">{arg.Description.Replace("\n", "")}</param>\n";
            }

            ret += $" /// <returns>returns new symbol</returns>\n";
            ret += $"public static {ndArrayOrSymbol} {ConvertName(Name)}(";

            foreach (var arg in argsLocal)
            {
                if (arg.TypeName == "NdArrayOrSymbol")
                {
                    ret += $"{ndArrayOrSymbol} {arg.Name}";
                }
                else if (arg.TypeName == "NdArrayOrSymbol[]")
                {
                    ret += $"{ndArrayOrSymbol}[] {arg.Name}";
                }
                else
                {
                    ret += $"{arg.TypeName} {arg.Name}";
                }
                if (arg.HasDefault)
                {

                    ret += $"={arg.DefaultString}";
                }
                ret += ",\n";
            }

            if (argsLocal.Count > 0)
            {
                ret = ret.Substring(0, ret.Length - 2);
            }

            ret += ")\n{";

            foreach (var arg in argsLocal)
            {
                ret += arg.DefaultStringWithObject;
            }

            ret += $"\nreturn new Operator(\"{Name}\")\n";

            foreach (var arg in _argCss)
            {
                if (arg.TypeName == "NdArrayOrSymbol" ||
                    arg.TypeName == "NdArrayOrSymbol[]" ||
                    arg.Name == "symbol_name")
                {
                    continue;
                }

                if (arg.IsEnum)
                {
                    ret += $".SetParam(\"{arg.OrginName}\", Util.EnumToString<{arg.Enum.Name}>({arg.Name}, {arg.Enum.Name}))\n";
                }
                else
                {
                    ret += $".SetParam(\"{arg.OrginName}\", {arg.Name})\n";
                }
            }


            foreach (var arg in Args)
            {
                if (arg.TypeName != "NdArrayOrSymbol")
                {
                    continue;
                }
                ret += $".SetInput(\"{arg.OrginName}\", {arg.Name})\n";
            }

            foreach (var arg in Args)
            {
                if (arg.TypeName != "NdArrayOrSymbol[]")
                {
                    continue;
                }
                ret += $".AddInput({arg.Name})\n";
            }

            switch (opNdArrayOrSymbol)
            {
                case OpNdArrayOrSymbol.Symbol:
                {
                    if (useName)
                    {
                        ret += ".CreateSymbol(symbol_name);\n";
                    }
                    else
                    {
                        ret += ".CreateSymbol();\n";
                    }
                   }
                    break;
                case OpNdArrayOrSymbol.NDArray:
                    if (useName)
                    {
                        ret += ".Invoke(@out);\n";
                    }
                    else
                    {
                        ret += ".Invoke();\n";
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opNdArrayOrSymbol), opNdArrayOrSymbol, null);
            }
    
            ret += "}";
            return ret;
        }

        private string ConvertName(string name)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            name = name.Replace("_image_", "");
            name = name.Replace("_contrib_", "");
            var ret = R.Replace(name, "_");
            return textInfo.ToTitleCase(ret).Replace("_", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetEnumClassString()
        {
            string enumret = "";

            foreach (var arg in Args.Where(w => w.IsEnum))
            {
                enumret += GetSummary(arg.Description);
                enumret += arg.Enum.GetDefinitionString() + "\n";
            }

            return enumret;
        }

        public string GetOpClassString(bool useName, OpNdArrayOrSymbol opNdArrayOrSymbol)
        {
            string ndArrayOrSymbol = "";
            switch (opNdArrayOrSymbol)
            {
                case OpNdArrayOrSymbol.Symbol:
                    ndArrayOrSymbol = "Symbol";
                    break;
                case OpNdArrayOrSymbol.NDArray:
                    ndArrayOrSymbol = "NDArray";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opNdArrayOrSymbol), opNdArrayOrSymbol, null);
            }

            string ret = "";

            if (useName)
            {
                foreach (var arg in argsLocal.Where(w => w.IsEnum))
                {
                    ret += arg.Enum.GetConvertString() + "\n";
                }
            }

            //comments 
            ret += GetSummary(Description);

            foreach (var arg in argsLocal)
            {
                ret += $"/// <param name=\"{arg.Name}\">{arg.Description.Replace("\n", "")}</param>\n";
            }

            ret += $" /// <returns>returns new symbol</returns>\n";
            ret += $"public static {ndArrayOrSymbol} {ConvertName(Name)}(";

            foreach (var arg in _argCss)
            {
                if(arg.Name == "symbol_name" && opNdArrayOrSymbol == OpNdArrayOrSymbol.NDArray)
                {
                    continue;
                }

                if (arg.TypeName == "NdArrayOrSymbol")
                {
                    ret += $"{ndArrayOrSymbol} {arg.Name}";
                }
                else if (arg.TypeName == "NdArrayOrSymbol[]")
                {
                    ret += $"{ndArrayOrSymbol}[] {arg.Name}";
                }
                else
                {
                    ret += $"{arg.TypeName} {arg.Name}";
                }
                if (arg.HasDefault)
                {
                    ret += $"={arg.DefaultString}";
                }

                ret += ", ";
            }

            if (argsLocal.Count > 0)
            {
                ret = ret.Substring(0, ret.Length - 2);
            }

            ret += ")\n{";

            foreach (var arg in argsLocal)
            {
                ret += arg.DefaultStringWithObject;
            }

            ret += $"\nreturn new Operator(\"{Name}\")\n";

            foreach (var arg in Args)
            {
                if (arg.TypeName == "NdArrayOrSymbol" ||
                    arg.TypeName == "NdArrayOrSymbol[]" ||
                    arg.Name == "symbol_name")
                {
                    continue;
                }

                if (arg.IsEnum)
                {
                    ret += $".SetParam(\"{arg.OrginName}\", Util.EnumToString<{arg.Enum.Name}>({arg.Name},{arg.Enum.Name}Convert))\n";
                }
                else
                {
                    ret += $".SetParam(\"{arg.OrginName}\", {arg.Name})\n";
                }
            }


            foreach (var arg in Args)
            {
                if (arg.TypeName != "NdArrayOrSymbol")
                {
                    continue;
                }
                ret += $".SetInput(\"{arg.OrginName}\", {arg.Name})\n";
            }

            foreach (var arg in Args)
            {
                if (arg.TypeName != "NdArrayOrSymbol[]")
                {
                    continue;
                }
                ret += $".AddInput({arg.Name})\n";
            }

            switch (opNdArrayOrSymbol)
            {
                case OpNdArrayOrSymbol.Symbol:
                    ret += ".CreateSymbol(symbol_name);\n";
                    break;
                case OpNdArrayOrSymbol.NDArray:
                    ret += ".Invoke();\n";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opNdArrayOrSymbol), opNdArrayOrSymbol, null);
            }

            ret += "}";
            return ret;
        }

        private string GetSummary(string desc)
        {
            StringBuilder summary = new StringBuilder();
            summary.AppendLine("///<summary>");

            foreach (var item in desc.Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    summary.AppendLine("///<para> </para>");
                    continue;
                }

                summary.AppendLine(string.Format("///<para>{0}</para>", item));
            }

            summary.AppendLine("///</summary>");

            return summary.ToString();
        }
    }
}