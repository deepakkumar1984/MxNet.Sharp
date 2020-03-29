using MxNet.Gluon;
using MxNet.Gluon.NN;
using MxNet.GluonCV.ModelZoo.SegBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo
{
    public class PSPNet : SegBaseModel
    {
        public PSPNet(int nclass, string backbone = "resnet50", bool aux = true, int base_size = 520, int crop_size = 480, string prefix = null, ParameterDict @params = null) : base(nclass, aux, backbone, base_size: base_size, crop_size: crop_size, prefix: prefix, @params: @params)
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

        private HybridSequential _PSP1x1Conv(int in_channels, int out_channels, string norm_layer, FuncArgs norm_kwargs)
        {
            throw new NotImplementedException();
        }

        public static PSPNet GetPSP(string dataset= "pascal_voc", string backbone= "resnet50", bool pretrained= false, string root= "~/.mxnet/models", Context ctx= null, bool pretrained_base= true, bool aux = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static PSPNet GetPSP_ResNet101_COCO(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool pretrained_base = true, bool aux = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static PSPNet GetPSP_ResNet101_VOC(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool pretrained_base = true, bool aux = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static PSPNet GetPSP_ResNet101_ADE(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool pretrained_base = true, bool aux = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static PSPNet GetPSP_ResNet101_Citys(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool pretrained_base = true, bool aux = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static PSPNet GetPSP_ResNet50_ADE(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool pretrained_base = true, bool aux = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }
    }

    class _PyramidPooling : HybridBlock
    {
        public _PyramidPooling(int in_channels, int height= 60, int width= 60, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol Pool(NDArrayOrSymbol x, int size)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol Upsample(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol Demo(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }
    }

    class _PSPHead : HybridBlock
    {
        public _PSPHead(int nclass, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, int feature_map_height= 60, int feature_map_width= 60, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
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
}
