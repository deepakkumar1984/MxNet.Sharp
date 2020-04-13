using MxNet.Gluon;
using MxNet.GluonCV.ModelZoo.SegBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo
{
    public class FCN : SegBaseModel
    {
        public FCN(int nclass, string backbone = "resnet50", bool aux = true, Context ctx = null, bool pretrained_base = true, int base_size = 520, int crop_size = 480, string prefix = "", ParameterDict @params = null) : base(nclass, aux, backbone, base_size: base_size, crop_size: crop_size, pretrained_base: pretrained_base, prefix: prefix, @params:@params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static FCN GetFCN(string dataset= "pascal_voc", string backbone= "resnet50", bool pretrained= false, string root= "", Context ctx= null, bool pretrained_base= true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static FCN GetFCN_ResNet50_VOC(bool pretrained = false, string root = "", Context ctx = null, bool pretrained_base = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static FCN GetFCN_ResNet101_COCO(bool pretrained = false, string root = "", Context ctx = null, bool pretrained_base = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static FCN GetFCN_ResNet101_VOC(bool pretrained = false, string root = "", Context ctx = null, bool pretrained_base = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static FCN GetFCN_ResNet152_COCO(bool pretrained = false, string root = "", Context ctx = null, bool pretrained_base = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static FCN GetFCN_ResNet50_ADE(bool pretrained = false, string root = "", Context ctx = null, bool pretrained_base = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        public static FCN GetFCN_ResNet101_ADE(bool pretrained = false, string root = "", Context ctx = null, bool pretrained_base = true, int base_size = 520, int crop_size = 480)
        {
            throw new NotImplementedException();
        }
    }

    public class _FCNHead : HybridBlock
    {
        public _FCNHead(int in_channels, int channels, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
