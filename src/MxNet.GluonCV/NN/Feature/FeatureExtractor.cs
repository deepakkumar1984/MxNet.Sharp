using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class FeatureExtractor : SymbolBlock
    {
        public FeatureExtractor(HybridBlock network, string[] outputs, string[] inputs = null, bool pretrained = false, Context ctx = null, ParameterDict @params = null) : base(null, null, @params)
        {
            if (ctx == null)
                ctx = mx.Cpu();

            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            base.Construct(p_i, p_o, p_p);
        }

        public FeatureExtractor(Symbol network, string[] outputs, string[] inputs = null, bool pretrained = false, Context ctx = null, ParameterDict @params = null) : base(null, null, @params)
        {
            if (ctx == null)
                ctx = mx.Cpu();

            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            base.Construct(p_i, p_o, p_p);
        }

        public FeatureExtractor(string network, string[] outputs, string[] inputs = null, bool pretrained = false, Context ctx = null, ParameterDict @params = null) : base(null, null, @params)
        {
            if (ctx == null)
                ctx = mx.Cpu();

            var (p_i, p_o, p_p) = __internal__.ParseNetwork(network, outputs, inputs, pretrained, ctx);
            base.Construct(p_i, p_o, p_p);
        }
    }
}
