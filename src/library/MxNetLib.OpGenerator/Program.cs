using System;
using System.IO;

namespace MxNetLib.OpGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            OpWrapperGenerator opWrapperGenerator = new OpWrapperGenerator();
            opWrapperGenerator.LoadMxOps();
            //var (symbol, ndArray, enums) = opWrapperGenerator.ParseAllOps();

            //symbol = symbol.Replace("\n", "\r\n");
            //ndArray = ndArray.Replace("\n", "\r\n");
            //enums = enums.Replace("\n", "\r\n");

            //string strSymbol = @"using System;
            //                    using System.Collections.Generic;
            //                    using System.Linq;
            //                    using System.Text;
            //                    using System.Threading.Tasks;
            //                    // ReSharper disable UnusedMember.Global

            //                    namespace mxnet.csharp
            //                    {
            //                        public partial class Symbol
            //                        {
            //                    " + symbol +
            //                        @"}
            //                    }
            //                    ";
            //File.WriteAllText(@"..\..\..\..\mxnet.csharp\OperatorWarpSymbol.cs", strSymbol);


            //string strNdArray = @"using System;
            //                        using System.Collections.Generic;
            //                        using System.Linq;
            //                        using System.Text;
            //                        using System.Threading.Tasks;
            //                        // ReSharper disable UnusedMember.Global

            //                        namespace mxnet.csharp
            //                        {
            //                            public partial class NdArray
            //                            {
            //                        " + ndArray +
            //                                                       @"}
            //                        }
            //                        ";
            //File.WriteAllText(@"..\..\..\..\mxnet.csharp\OperatorWarpNdArray.cs", strNdArray);


            string strEnum = opWrapperGenerator.GenerateEnum();
            File.WriteAllText(@"..\..\..\Generated\MxOpEnumerations.cs", strEnum);

            string ndarrayOps = opWrapperGenerator.GenerateClass("nd", OpNdArrayOrSymbol.NDArray);
            File.WriteAllText(@"..\..\..\Generated\NdOps\Ops.cs", ndarrayOps);

            ndarrayOps = opWrapperGenerator.GenerateClass("NdImgApi", OpNdArrayOrSymbol.NDArray, "Image");
            File.WriteAllText(@"..\..\..\Generated\NdOps\NdImgApi.cs", ndarrayOps);

            ndarrayOps = opWrapperGenerator.GenerateClass("NdContribApi", OpNdArrayOrSymbol.NDArray, "Contrib");
            File.WriteAllText(@"..\..\..\Generated\NdOps\NdContribApi.cs", ndarrayOps);

            string symops = opWrapperGenerator.GenerateClass("sym", OpNdArrayOrSymbol.Symbol);
            File.WriteAllText(@"..\..\..\Generated\SymOps\Ops.cs", symops);

            symops = opWrapperGenerator.GenerateClass("SymImgApi", OpNdArrayOrSymbol.Symbol, "Image");
            File.WriteAllText(@"..\..\..\Generated\SymOps\ImgApi.cs", symops);

            symops = opWrapperGenerator.GenerateClass("SymContribApi", OpNdArrayOrSymbol.Symbol, "Contrib");
            File.WriteAllText(@"..\..\..\Generated\SymOps\ContribApi.cs", symops);
        }
    }
}
