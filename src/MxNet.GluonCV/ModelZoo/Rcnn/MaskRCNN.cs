using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rcnn
{
    public class MaskRCNN : FasterRCNN
    {
        public MaskRCNN(HybridBlock features, HybridBlock top_features, string[] classes, int mask_channels = 256, int rcnn_max_dets = 1000, int rpn_test_pre_nms = 6000, int rpn_test_post_nms = 1000, int target_roi_scale = 1, int num_fcn_convs = 0, string norm_layer = "", FuncArgs norm_kwargs = null, string prefix = "", ParameterDict @params = null) : base(features: features, top_features: top_features, classes: classes, rpn_test_pre_nms: rpn_test_pre_nms, rpn_test_post_nms: rpn_test_post_nms, additional_output: true, prefix: prefix, @params: @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override void ResetClass(string[] classes, NDArrayDict reuse_weights = null)
        {
            throw new NotImplementedException();
        }

        public static MaskRCNN GetMaskRCNN(string name, string dataset, bool pretrained = false, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static MaskRCNN MaskRCNN_Resnet50_V1B_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static MaskRCNN MaskRCNN_FPN_Resnet50_V1B_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static MaskRCNN MaskRCNN_Resnet101_V1D_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static MaskRCNN MaskRCNN_FPN_Resnet101_V1D_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static MaskRCNN MaskRCNN_FPN_Resnet18_V1B_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static MaskRCNN MaskRCNN_FPN_BN_Resnet18_V1B_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static MaskRCNN MaskRCNN_FPN_BN_Mobilenet1_0_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }
    }
}
