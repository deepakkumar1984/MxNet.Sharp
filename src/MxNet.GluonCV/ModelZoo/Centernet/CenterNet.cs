using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Centernet
{
    public class CenterNet : HybridBlock
    {
        public int NumClasses => throw new NotImplementedException();

        public CenterNet(HybridBlock base_network, Dictionary<string, Dictionary<string, object>> heads, int classes, int head_conv_channel = 0, float scale = 4, int topk = 100, bool flip_test = false, int nms_thresh = 0, int nms_topk = 400, int post_nms = 100, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public void SetNms(int nms_thresh = 0, int nms_topk = 400, int post_nms = 100)
        {
            throw new NotImplementedException();
        }

        public void ResetClass(int classes, NDArrayDict reuse_weight = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet GetCenterNet(string dataset, bool pretrained = false, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet18_V1B_VOC(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet18_V1B_DcnV2_VOC(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet18_V1B_COCO(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet18_V1B_DcnV2_COCO(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet50_V1B_VOC(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet50_V1B_DcnV2_VOC(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet50_V1B_COCO(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet50_V1B_DcnV2_COCO(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet101_V1B_VOC(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet101_V1B_DcnV2_VOC(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet101_V1B_COCO(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Resnet101_V1B_DcnV2_COCO(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Dla34_VOC(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Dla34_DcnV2_VOC(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Dla34_COCO(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static CenterNet CenterNet_Dla34_DcnV2_COCO(bool pretrained = false, bool pretrained_base = true, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }
    }
}
