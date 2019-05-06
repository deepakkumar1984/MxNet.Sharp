using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MxNetLib.OpGenerator
{
    class OpWrapperGenerator
    {
        private List<string> black = new List<string>(){ "_set_value", "_NDArray" };

        private List<MxOp> ops = new List<MxOp>();

        public void LoadMxOps()
        {
            int r = NativeMethods.MXSymbolListAtomicSymbolCreators(out uint numSymbolCreators, out IntPtr symbolCreatorsPtr);
            Debug.Assert(r == 0);
            IntPtr[] symbolCreators = new IntPtr[numSymbolCreators];
            Marshal.Copy(symbolCreatorsPtr, symbolCreators, 0, (int)numSymbolCreators);

            for (int i = 0; i < numSymbolCreators; i++)
            {
                r = NativeMethods.MXSymbolGetAtomicSymbolInfo(symbolCreators[i],
                out IntPtr namePtr,
                out IntPtr descriptionPtr,
                out uint numArgs,
                out IntPtr argNamesPtr,
                out IntPtr argTypeInfosPtr,
                out IntPtr argDescriptionsPtr,
                out IntPtr keyVarNumArgsPtr,
                out IntPtr returnTypePtr);
                string name = Marshal.PtrToStringAnsi(namePtr);
                if (name == null)
                {
                    Console.WriteLine($"error namePtr {i}");
                    continue; ;
                }

                if (black.Contains(name))
                {
                    continue;
                }

                if (name.ToLower().Contains("backward"))
                    continue;

                string description = Marshal.PtrToStringAnsi(descriptionPtr);

                IntPtr[] argNamesArray = new IntPtr[numArgs];
                IntPtr[] argTypeInfosArray = new IntPtr[numArgs];
                IntPtr[] argDescriptionsArray = new IntPtr[numArgs];
                if (numArgs > 0)
                {
                    Marshal.Copy(argNamesPtr, argNamesArray, 0, (int)numArgs);
                    Marshal.Copy(argTypeInfosPtr, argTypeInfosArray, 0, (int)numArgs);
                    Marshal.Copy(argDescriptionsPtr, argDescriptionsArray, 0, (int)numArgs);

                }

                List<MxOpArg> args = new List<MxOpArg>();
                for (int j = 0; j < numArgs; j++)
                {
                    string descriptions = Marshal.PtrToStringAnsi(argDescriptionsArray[j]);
                    if (descriptions == null || descriptions.Contains("Deprecated"))
                    {
                        continue;
                    }

                    MxOpArg arg = new MxOpArg(name,
                        Marshal.PtrToStringAnsi(argNamesArray[j]),
                        Marshal.PtrToStringAnsi(argTypeInfosArray[j]),
                        descriptions
                        );

                    args.Add(arg);
                }

                ops.Add(new MxOp(name, description, args));
            }
        }

        public string GenerateEnum()
        {
            string enumClassFinal = @"using System;
                                using System.Collections.Generic;
                                using System.Linq;
                                using System.Text;
                                using System.Threading.Tasks;

                                namespace MxNetLib
                                {
                                    [ClassData]
                                }";

            string enumList = "";
            foreach (var item in ops)
            {
                enumList += item.GetEnumClassString();
            }

            return enumClassFinal.Replace("[ClassData]", enumList);
        }

        public string GenerateClass(string name, OpNdArrayOrSymbol optype, string opClsName = "")
        {
            string finalClass = @"using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Text;
                                    using System.Threading.Tasks;

                                    namespace MxNetLib
                                    {
                                        public partial class [ClassName]
                                        {
                                            [ClassData]
                                        }
                                    }";

            finalClass = finalClass.Replace("[ClassName]", name);

            string stringBuilder = "";
            foreach (var item in ops.Where(x => (x.ClsName == opClsName)).ToList())
            {
                stringBuilder += item.GetOpClassString(true, optype) + "\n\n"; ;
            }

            stringBuilder = stringBuilder.Replace("string symbol_name=\"\", )", "string symbol_name=\"\")");

            return finalClass.Replace("[ClassData]", stringBuilder);
        }

        public string GenerateSymbolClass()
        {
            string finalClass = @"using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Text;
                                    using System.Threading.Tasks;

                                    namespace MxNetLib
                                    {
                                        public partial class sym
                                        {
                                            [ClassData]
                                        }
                                    }";

            string stringBuilder = "";
            foreach (var item in ops)
            {
                stringBuilder += item.GetOpClassString(true, OpNdArrayOrSymbol.Symbol) + "\n\n"; ;
            }

            return finalClass.Replace("[ClassData]", stringBuilder);
        }

        public string GenerateSymbolImageClass()
        {
            string finalClass = @"using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Text;
                                    using System.Threading.Tasks;

                                    namespace MxNetLib
                                    {
                                        public partial class SymImage
                                        {
                                            [ClassData]
                                        }
                                    }";

            string stringBuilder = "";
            foreach (var item in ops.Where(x => (x.ClsName == "Image")).ToList())
            {
                stringBuilder += item.GetOpClassString(true, OpNdArrayOrSymbol.Symbol) + "\n\n"; ;
            }

            return finalClass.Replace("[ClassData]", stringBuilder);
        }
    }
}
