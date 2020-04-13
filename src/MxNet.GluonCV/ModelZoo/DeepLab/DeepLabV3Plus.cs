using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.DeepLab
{
    public class DeepLabV3Plus : HybridBlock
    {
        public DeepLabV3Plus(int nclass, string backbone= "xception", bool aux= true, Context ctx = null, bool pretrained_base= true, int? height= null, int? width= null, int base_size= 576, int crop_size= 512, bool dilated= true, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public (NDArrayOrSymbol, NDArrayOrSymbol, NDArrayOrSymbol) BaseForward(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol Demo(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol Evaluate(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3Plus GetDeepLabV3Plus(string dataset = "pascal_voc", string backbone = "xception", bool pretrained = false, string root = "", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3Plus GetDeeplabPlus_Xception_COCO(bool pretrained = false, string root = "", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential ASPPConv(int in_channels, int out_channels, float atrous_rate, string norm_layer, FuncArgs norm_kwargs)
        {
            throw new NotImplementedException();
        }

        class _DeepLabHead : HybridBlock
        {
            public _DeepLabHead(int nclass, int c1_channels = 128, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, int height= 128, int width= 128, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
            {
                throw new NotImplementedException();
            }

            public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
            {
                throw new NotImplementedException();
            }
        }

        class _AsppPooling : HybridBlock
        {
            public _AsppPooling(int in_channels, int out_channels, string norm_layer, FuncArgs norm_kwargs, int height= 64, int width= 64, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
            {
                throw new NotImplementedException();
            }

            public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
            {
                throw new NotImplementedException();
            }
        }

        class _ASPP : HybridBlock
        {
            public _ASPP(int in_channels, int out_channels, string norm_layer, FuncArgs norm_kwargs, int height = 64, int width = 64, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
            {
                throw new NotImplementedException();
            }

            public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
            {
                throw new NotImplementedException();
            }
        }
    }
}
