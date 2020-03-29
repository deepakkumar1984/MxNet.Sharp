using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLOV3 : HybridBlock
    {
        public int NumClass => throw new NotImplementedException();

        public string[] Classes => throw new NotImplementedException();

        public YOLOV3(HybridBlock stages, int[] channels, int[] anchors, int[] strides, string[] classes, (int, int)? alloc_size= null,
                 float nms_thresh= 0.45f, int nms_topk= 400, int post_nms= 100, float pos_iou_thresh= 1,
                 float ignore_iou_thresh= 0.7f, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private NDArrayOrSymbol Upsample(NDArrayOrSymbol x, int stride= 2)
        {
            throw new NotImplementedException();
        }

        public void SetNms(float nms_thresh= 0.45f, int nms_topk= 400, int post_nms= 100)
        {
            throw new NotImplementedException();
        }

        public void ResetClass(string[] classes, NDArrayDict reuse_weights = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 GetYOLOV3(string name, HybridBlock stages, float[] filters, int[] anchors, int[] strides, string[] classes,
               string dataset, bool pretrained= false, Context ctx= null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Darknet53_VOC(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Darknet53_COCO(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Darknet53_Custom(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Mobilenet1_0_VOC(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Mobilenet1_0_COCO(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Mobilenet1_0_Custom(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Mobilenet0_25_VOC(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Mobilenet0_25_COCO(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static YOLOV3 YOLO3_Mobilenet0_25_Custom(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }
    }
}
