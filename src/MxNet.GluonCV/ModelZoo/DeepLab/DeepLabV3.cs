using MxNet.Gluon;
using MxNet.Gluon.NN;
using MxNet.GluonCV.ModelZoo.SegBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.DeepLab
{
    public class DeepLabV3 : SegBaseModel
    {
        public DeepLabV3(int nclass,  string backbone = "resnet50", bool aux = true, Context ctx = null, bool pretrained_base = true, int? height = null, int? width = null, int base_size = 520, int crop_size = 480, string prefix = null, ParameterDict @params = null) : base(nclass, aux, backbone, height, width, base_size, crop_size, pretrained_base, prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Demo(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Predict(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        private HybridSequential ASPPConv(int in_channels, int out_channels, float atrous_rate, string norm_layer, FuncArgs norm_kwargs)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3 GetDeeplab(string dataset= "pascal_voc", string  backbone= "resnet50", bool pretrained= false,   string root= "~/.mxnet/models", Context ctx= null, int? height = null, int? width = null, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3 GetDeepLab_ResNet101_COCO(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, int? height = null, int? width = null, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3 GetDeepLab_ResNet152_COCO(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, int? height = null, int? width = null, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3 GetDeepLab_ResNet101_VOC(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, int? height = null, int? width = null, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3 GetDeepLab_ResNet152_VOC(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, int? height = null, int? width = null, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3 GetDeepLab_ResNet101_ADE(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, int? height = null, int? width = null, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static DeepLabV3 GetDeepLab_ResNet152_ADE(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, int? height = null, int? width = null, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        class _DeepLabHead : HybridBlock
        {
            public _DeepLabHead(int nclass, string norm_layer= "BatchNorm", FuncArgs norm_kwargs = null, int height= 60, int width= 60, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
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
        }

        class _AsppPooling : HybridBlock
        {
            public _AsppPooling(int in_channels, int out_channels, string norm_layer, FuncArgs norm_kwargs, int height= 60, int width= 60, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
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
            public _ASPP(int in_channels, float atrous_rates, string norm_layer, FuncArgs norm_kwargs, int height= 60, int width= 60, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
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
