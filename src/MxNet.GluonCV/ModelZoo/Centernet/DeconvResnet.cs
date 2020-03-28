using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Centernet
{
    public class DeConvResnet : HybridBlock
    {
        public DeConvResnet(string base_network= "resnet18_v1b", (int, int, int)? deconv_filters= null, (int, int, int)? deconv_kernels= null,
                 bool pretrained_base= true, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, bool use_dcnv2= false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private (int, int, int) GetConvCfg(int deconv_kernel)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeDeconvLayer(int num_filters, int num_kernels)
        {
            throw new NotImplementedException();
        }

        public static DeConvResnet GetDeconvResnet(string base_network, bool pretrained = false, Context ctx = null, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static DeConvResnet Resnet18_V1B_DeConv(string base_network, bool pretrained = false, Context ctx = null, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static DeConvResnet Resnet18_V1B_DeConv_DcnV2(string base_network, bool pretrained = false, Context ctx = null, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static DeConvResnet Resnet50_V1B_DeConv(string base_network, bool pretrained = false, Context ctx = null, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static DeConvResnet Resnet50_V1B_DeConv_DcnV2(string base_network, bool pretrained = false, Context ctx = null, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static DeConvResnet Resnet101_V1B_DeConv(string base_network, bool pretrained = false, Context ctx = null, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static DeConvResnet Resnet101_V1B_DeConv_DcnV2(string base_network, bool pretrained = false, Context ctx = null, bool use_dcnv2 = false, string prefix = null, ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }
    }
}
