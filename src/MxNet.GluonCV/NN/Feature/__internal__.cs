using MxNet.Gluon;
using MxNet.GluonCV.ModelZoo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    internal class __internal__
    {
        public static (Symbol, SymbolList, ParameterDict) ParseNetwork(HybridBlock network, string[] outputs, string[] inputs, bool pretrained, Context ctx)
        {
            var inputSymbols = inputs.Select(x => (Symbol.Var(x))).ToArray();
            Symbol input = null;
           
            if (inputSymbols.Length == 1)
            {
                input = inputSymbols[0];
            }
            else
            {
                input = Symbol.Group(inputSymbols);
            }

            ParameterDict @params = network.CollectParams();
            var prefix = network.Prefix;
            input = network.Call(input);
            
            Debug.Assert(outputs.Length > 0, "At least one outputs must be specified.");
            outputs = (from @out in outputs
                       select @out.EndsWith("_output") ? @out : @out + "_output").ToArray();
            var outputSymbols = (from @out in outputs
                       select input[prefix + @out]).ToArray();
            return (input, outputSymbols, @params);
        }

        public static (SymbolList, SymbolList, ParameterDict) ParseNetwork(Symbol network, string[] outputs, string[] inputs, bool pretrained, Context ctx)
        {
            var inputSymbols = inputs.Select(x => (Symbol.Var(x))).ToArray();
            Symbol input = network;

            if (inputSymbols.Length == 1)
            {
                input = inputSymbols[0];
            }
            else
            {
                input = Symbol.Group(inputSymbols);
            }

            ParameterDict @params = null;
            string prefix = "";

            Debug.Assert(outputs.Length > 0, "At least one outputs must be specified.");
            outputs = (from @out in outputs
                       select @out.EndsWith("_output") ? @out : @out + "_output").ToArray();
            var outputSymbols = (from @out in outputs
                                 select network[prefix + @out]).ToArray();
            return (input, outputSymbols, @params);
        }

        public static (SymbolList, SymbolList, ParameterDict) ParseNetwork(string network, string[] outputs, string[] inputs, bool pretrained, Context ctx)
        {
            var net = Models.GetModel<ResNetV1>(network, pretrained: pretrained, ctx: ctx);
            return ParseNetwork(net, outputs, inputs, pretrained, ctx);
        }
    }
}
