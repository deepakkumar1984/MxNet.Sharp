using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MxNet.OpGenerator
{
    class MxOpArg
    {
        private readonly Dictionary<string, string> _typeDict = new Dictionary<string, string>
        {
            {"boolean","bool"},
            {"boolean or None","bool?"},
            {"Shape(tuple)","NDShape"},
            {"Shape or None","NDShape"},
            {"Symbol","Symbol"},
            {"NDArray","Symbol"},
            {"NDArray-or-Symbol","NdArrayOrSymbol"},
            {"Symbol[]","List<Symbol>"},
            {"Symbol or Symbol[]","List<Symbol>"},
            {"NDArray[]","List<Symbol>"},
            {"caffe-layer-parameter","caffeLayerParameter"},
            {"NDArray-or-Symbol[]","NdArrayOrSymbol[]"},
            {"float","float"},
            {"real_t","float"},
            {"int","int"},
            {"int (non-negative)", "uint"},
            {"long (non-negative)", "ulong"},
            {"int or None","int?"},
            {"float or None","float?"},
            {"long","int64_t"},
            {"double","double"},
            {"double or None","double?"},
            {"string","string"},
            {"ptr","IntPtr" },
            {"tuple of <double>","Tuple<double>" },
            {"tuple of <int>","Tuple<int>" },
            {"tuple of <float>","Tuple<float>" },
            {"tuple of","Tuple<float>" },
        };
        public static readonly Dictionary<int, Type> DtypeMxToNp = new Dictionary<int, Type>
        {
            {0, typeof(float)},
            {1, typeof(double)},
            // {  2 , typeof(np.float16)},
            {3, typeof(byte)},
            {4, typeof(int)}
        };

        public string OrginName { get; }
        public string Name { get; }
        public string Description { get; }
        public bool IsEnum { get; } = false;
        public EnumType Enum { get; }
        public string TypeName { get; }
        public bool HasDefault { get; set; } = false;
        public string DefaultString { get; set; }
        public string DefaultStringWithObject { get; set; } = "";

        public MxOpArg()
        {

        }

        public MxOpArg(string opName = "", string argName = "", string typeString = "", string descString = "")
        {
            if (argName == "src")
            {
                argName = "data";
            }

            this.OrginName = argName;
            this.Name = GetName(argName);
            this.Description = descString;
            
            if (argName != "dtype" && typeString.StartsWith("{"))
            {
                IsEnum = true;
                Enum = new EnumType(opName + "_" + argName, typeString);
                TypeName = Enum.Name;
            }

            else if (argName == "dtype")
            {
                TypeName = "DType";
            }
            else
            {
                string typename;
                if (_typeDict.TryGetValue(typeString.Split(',').First().Replace(",", ""), out typename))
                {
                    TypeName = typename;
                }
                else
                {
                    TypeName = "Tuple<double>";
                }
            }

            if (TypeName == null)
            {
                Console.WriteLine($"{opName} {argName}");
                TypeName = "int";
            }

            if (typeString.IndexOf("default=", StringComparison.Ordinal) != -1)
            {
                HasDefault = true;
                DefaultString = typeString.Split(new string[] { "default=" }, StringSplitOptions.None)[1]
                    .Trim()
                    .Trim('\'');

                if (IsEnum)
                {
                    if (DefaultString == "None")
                    {
                        TypeName += "?";
                        DefaultString = "null";
                    }
                    else
                    {
                        DefaultString = Enum.GetDefaultValueString(DefaultString);
                    }

                }
                else if (DefaultString == "False")
                {
                    DefaultString = "false";
                }
                else if (DefaultString == "True")
                {
                    DefaultString = "true";
                }
                else if (DefaultString == "None")
                {
                    DefaultString = "null";
                }
                else if (TypeName== "NDShape")
                {
                    if (DefaultString != "()")
                    {
                        DefaultStringWithObject = $"if({Name}==null){{ {Name}= new NDShape();}}\n";
                    }

                    DefaultString = "null";
                }
                else if (TypeName.StartsWith("Tuple"))
                {
                    int r = 0;
                    bool parsed = int.TryParse(DefaultString, out r);
                    if(parsed)
                    {
                        TypeName = "int";
                        return;
                    }

                    if (DefaultString != "()")
                    {
                        if (TypeName.Contains("float"))
                        {
                            DefaultString = DefaultString.Replace(")", "f)").Replace(",", "f,");
                            DefaultString = DefaultString.Replace(",f)", ")");
                        }

                        DefaultString = DefaultString.Replace("[", "(").Replace("]", ")");
                        DefaultStringWithObject = $"if({Name}==null){{ {Name}= new {TypeName}{DefaultString};}}\n";
                    }

                    DefaultString = "null";
                }

                if (TypeName == "float")
                {
                    DefaultString = DefaultString + "f";
                }
                if (TypeName == "string")
                {
                    DefaultString = "null";
                }
                if (TypeName.StartsWith("bool"))
                {
                    if (DefaultString == "0")
                    {
                        DefaultString = "false";
                    }
                    if (DefaultString == "1")
                    {
                        DefaultString = "true";
                    }
                }
                if (TypeName == "DType" && DefaultString!= "null")
                {
                    DefaultStringWithObject = $"if({Name}==null){{ {Name}= {DType.GetCode(DefaultString)};}}\n";
                    DefaultString = "null";
                }
                if (argName == "ctx")
                {
                    TypeName = "Context";
                }
            }

            //if (argName == "weight" || argName == "bias")
            //{
            //    HasDefault = true;
            //    DefaultString = "null";
            //}
        }

        private string GetName(string argName)
        {
            return argName;
        }
    }

}
