using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Centernet
{
    public class DeconvDLA : HybridBlock
    {
        public DeconvDLA(string base_network, bool pretrained_base, int down_ratio, int last_level, int out_channels, bool use_dcnv2 = false, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static DeconvDLA GetDeconvDLA(string base_network, bool pretrained_base, Context ctx = null, float scale = 4, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static DeconvDLA Dla34_DeConv(string base_network, bool pretrained_base, Context ctx = null, float scale = 4, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static DeconvDLA Dla34_DeConv_DcnV2(string base_network, bool pretrained_base, Context ctx = null, float scale = 4, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }
    }
}
