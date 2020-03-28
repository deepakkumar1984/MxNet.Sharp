using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rcnn
{
    public class FasterRCNN : RCNN
    {
        public FasterRCNN(
            HybridBlock features,
            HybridBlock top_features,
            string[] classes,
            HybridBlock box_features = null,
            int @short = 600,
            int max_size = 1000,
            int min_stage = 4,
            int max_stage = 4,
            string train_patterns = "",
            float nms_thresh = 0.3f,
            int nms_topk = 400,
            int post_nms = 100,
            string roi_mode = "align",
            (int, int)? roi_size = null,
            int strides = 16,
            float? clip = null,
            int rpn_channel = 1024,
            int base_size = 16,
            float[] scales = null,
            float[] ratios = null,
            (int, int)? alloc_size = null,
            float rpn_nms_thresh = 0.7f,
            int rpn_train_pre_nms = 12000,
            int rpn_train_post_nms = 2000,
            int rpn_test_pre_nms = 6000,
            int rpn_test_post_nms = 300,
            int rpn_min_size = 16,
            int per_device_batch_size = 1,
            int num_sample = 128,
            float pos_iou_thresh = 0.5f,
            float pos_ratio = 0.25f,
            int max_num_gt = 300,
            bool additional_output = false,
            bool force_nms = false,
            string prefix = null,
            ParameterDict @params = null) : base(features, top_features, classes, box_features, @short, max_size, train_patterns, nms_thresh, nms_topk, post_nms, roi_mode, roi_size.HasValue ? roi_size.Value : (14, 14), (strides, strides), clip, force_nms, prefix, @params)
        {
            throw new NotImplementedException();
        }

        public HybridBlock TargetGenerator => throw new NotImplementedException();

        public override void ResetClass(string[] classes, NDArrayDict reuse_weights = null)
        {
            throw new NotImplementedException();
        }

        private NDArrayOrSymbol PyramidROIFeats(NDArrayOrSymbol features, NDArrayOrSymbol rpn_rois, (int, int, int, int) roi_size, (int, int, int, int) strides, string roi_mode= "align", float roi_canonical_scale= 224, float eps= 1e-6f)
        {
            throw new NotImplementedException();
        }

        public FasterRCNN GetFasterRCNN(string name, string dataset, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_Resnet50_V1B_VOC(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_Resnet50_V1B_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_FPN_Resnet50_V1B_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_FPN_BN_Resnet50_V1B_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_Resnet50_V1B_Custom(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_Resnet101_V1D_VOC(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_Resnet101_V1D_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_FPN_Resnet101_V1D_COCO(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public FasterRCNN FasterRCNN_Resnet101_V1D_Custom(bool pretrained = false, bool pretrained_base = true, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }
    }
}
