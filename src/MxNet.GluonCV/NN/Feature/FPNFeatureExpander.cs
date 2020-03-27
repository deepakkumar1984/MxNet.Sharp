using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class FPNFeatureExpander : SymbolBlock
    {
        public FPNFeatureExpander(HybridBlock network, string[] outputs, int num_filters, bool use_1x1 = true, bool use_upsample = true,
                            bool use_elewadd = true, bool use_p6 = false, bool p6_conv = true, bool no_bias = true,
                            bool pretrained = false, HybridBlock norm_layer = null, FuncArgs norm_kwargs = null, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
            throw new NotImplementedException();
        }

        public FPNFeatureExpander(SymbolBlock network, string[] outputs, int num_filters, bool use_1x1 = true, bool use_upsample = true,
                            bool use_elewadd = true, bool use_p6 = false, bool p6_conv = true, bool no_bias = true,
                            bool pretrained = false, HybridBlock norm_layer = null, FuncArgs norm_kwargs = null, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
            throw new NotImplementedException();
        }

        public FPNFeatureExpander(string network, string[] outputs, int num_filters, bool use_1x1 = true, bool use_upsample = true,
                            bool use_elewadd = true, bool use_p6 = false, bool p6_conv = true, bool no_bias = true,
                            bool pretrained = false, HybridBlock norm_layer = null, FuncArgs norm_kwargs = null, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
            throw new NotImplementedException();
        }
    }
}
