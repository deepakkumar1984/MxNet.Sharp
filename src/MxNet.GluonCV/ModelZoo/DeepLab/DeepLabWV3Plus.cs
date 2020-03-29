using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.DeepLab
{
    public class DeepLabWV3Plus : HybridBlock
    {
        public DeepLabWV3Plus(int nclass, string backbone = "wideresnet", bool aux = false, Context ctx = null, bool pretrained_base = true, int? height = null, int? width = null, int base_size = 520, int crop_size = 480, bool dilated = true, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol Demo(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol Predict(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3Plus GetDeepLabV3Plus(string dataset = "citys", string backbone = "wideresnet", bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3Plus GetDeeplabPlus_V3_WiderResNet_Citys(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential ASPPConv(int in_channels, int out_channels, float atrous_rate, string norm_layer, FuncArgs norm_kwargs)
        {
            throw new NotImplementedException();
        }

        class _DeepLabHead : HybridBlock
        {
            public _DeepLabHead(int nclass, int c1_channels = 128, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, int height = 240, int width = 240, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
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
            public _AsppPooling(int in_channels, int out_channels, string norm_layer, FuncArgs norm_kwargs, int height = 60, int width = 60, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
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
            public _ASPP(int in_channels, int out_channels, string norm_layer, FuncArgs norm_kwargs, int height = 60, int width = 60, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
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
