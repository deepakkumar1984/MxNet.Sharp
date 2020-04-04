using MxNet.Gluon;
using MxNet.GluonCV.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLOV3DynamicTargetGeneratorSimple : HybridBlock
    {
        public BBoxBatchIOU _batch_iou;

        public float _ignore_iou_thresh;

        public int _num_class;

        public YOLOV3DynamicTargetGeneratorSimple(int num_class, float ignore_iou_thresh, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            this._num_class = num_class;
            this._ignore_iou_thresh = ignore_iou_thresh;
            this._batch_iou = new BBoxBatchIOU();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0]);

            return F(x.SymX, args[0]);
        }

        private NDArrayOrSymbol F(NDArray box_preds, NDArray gt_boxes)
        {
            NDArray objness_t = null;
            NDArray center_t = null;
            NDArray scale_t = null;
            NDArray weight_t = null;
            NDArray class_t = null;

            using (var ag = Autograd.Pause()) 
            {
                box_preds = box_preds.Reshape(0, -1, 4);
                objness_t = nd.ZerosLike(box_preds.SliceAxis(axis: -1, begin: 0, end: 1));
                center_t = nd.ZerosLike(box_preds.SliceAxis(axis: -1, begin: 0, end: 2));
                scale_t = nd.ZerosLike(box_preds.SliceAxis(axis: -1, begin: 0, end: 2));
                weight_t = nd.ZerosLike(box_preds.SliceAxis(axis: -1, begin: 0, end: 2));
                class_t = nd.OnesLike(objness_t.Tile(reps: new Shape(this._num_class))) * -1;
                var batch_ious = this._batch_iou.Call(box_preds, gt_boxes);
                var ious_max = nd.Max(batch_ious, axis: new Shape(-1), keepdims: true);
                objness_t = (ious_max > this._ignore_iou_thresh) * -1;
            }

            return new NDArrayOrSymbol(objness_t, center_t, scale_t, weight_t, class_t);
        }

        private NDArrayOrSymbol F(Symbol box_preds, Symbol gt_boxes)
        {
            Symbol objness_t = null;
            Symbol center_t = null;
            Symbol scale_t = null;
            Symbol weight_t = null;
            Symbol class_t = null;

            using (var ag = Autograd.Pause())
            {
                box_preds = box_preds.Reshape(0, -1, 4);
                objness_t = sym.ZerosLike(box_preds.SliceAxis(axis: -1, begin: 0, end: 1));
                center_t = sym.ZerosLike(box_preds.SliceAxis(axis: -1, begin: 0, end: 2));
                scale_t = sym.ZerosLike(box_preds.SliceAxis(axis: -1, begin: 0, end: 2));
                weight_t = sym.ZerosLike(box_preds.SliceAxis(axis: -1, begin: 0, end: 2));
                class_t = sym.OnesLike(objness_t.Tile(reps: new Shape(this._num_class))) * -1;
                var batch_ious = this._batch_iou.Call(box_preds, gt_boxes);
                var ious_max = sym.Max(batch_ious, axis: new Shape(-1), keepdims: true);
                objness_t = (ious_max > this._ignore_iou_thresh) * -1;
            }

            return new NDArrayOrSymbol(objness_t, center_t, scale_t, weight_t, class_t);
        }
    }
}
