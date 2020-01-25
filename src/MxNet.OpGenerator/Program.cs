using System;
using System.IO;

namespace MxNet.OpGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            OpWrapperGenerator opWrapperGenerator = new OpWrapperGenerator();
            opWrapperGenerator.LoadMxOps();

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
