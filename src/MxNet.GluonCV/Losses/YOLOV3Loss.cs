using System;
using System.Collections.Generic;
using System.Text;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.Losses;

namespace MxNet.GluonCV.Losses
{
    public class YOLOV3Loss : Loss
    {
        private L1Loss _l1_loss;

        private SigmoidBinaryCrossEntropyLoss _sigmoid_ce;

        public (NDArrayOrSymbol, NDArrayOrSymbol, NDArrayOrSymbol, NDArrayOrSymbol) LossOutput { get; set; }

        public YOLOV3Loss(float? weight = null, int? batch_axis = null, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            _sigmoid_ce = new SigmoidBinaryCrossEntropyLoss(from_sigmoid: false);
            _l1_loss = new L1Loss();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol objness, NDArrayOrSymbol box_centers, NDArrayOrSymbol box_scales = null, params object[] args)
        {
            NDArrayOrSymbol cls_preds = args[0] as NDArrayOrSymbol;
            NDArrayOrSymbol objness_t = args[1] as NDArrayOrSymbol;
            NDArrayOrSymbol center_t = args[2] as NDArrayOrSymbol;
            NDArrayOrSymbol scale_t = args[3] as NDArrayOrSymbol;
            NDArrayOrSymbol weight_t = args[4] as NDArrayOrSymbol;
            NDArrayOrSymbol class_t = args[5] as NDArrayOrSymbol;
            NDArrayOrSymbol class_mask = args[6] as NDArrayOrSymbol;


            if (objness.IsNDArray)
                return F(objness.NdX, box_centers, box_scales, cls_preds, objness_t, center_t, scale_t, weight_t, class_t, class_mask);

            return F(objness.SymX, box_centers, box_scales, cls_preds, objness_t, center_t, scale_t, weight_t, class_t, class_mask);
        }

        private NDArrayOrSymbol F(NDArray objness, NDArray box_centers,  NDArray box_scales, NDArray cls_preds, NDArray objness_t, NDArray center_t, NDArray scale_t, NDArray weight_t, NDArray class_t, NDArray class_mask)
        {
            var denorm = nd.Cast(nd.ShapeArray(objness_t).SliceAxis(axis: 0, begin: 1, end: null).Prod(), "float32");
            weight_t = nd.BroadcastMul(weight_t, objness_t);
            var hard_objness_t = nd.Where(objness_t > 0, nd.OnesLike(objness_t), objness_t);
            var new_objness_mask = nd.Where(objness_t > 0, objness_t, objness_t >= 0);
            var obj_loss = nd.BroadcastMul(this._sigmoid_ce.Call(objness, hard_objness_t, new_objness_mask), denorm);
            var center_loss = nd.BroadcastMul(this._sigmoid_ce.Call(box_centers, center_t, weight_t), denorm * 2);
            var scale_loss = nd.BroadcastMul(this._l1_loss.Call(box_scales, scale_t, weight_t), denorm * 2);
            var denorm_class = nd.Cast(nd.ShapeArray(class_t).SliceAxis(axis: 0, begin: 1, end: null).Prod(), "float32");
            class_mask = nd.BroadcastMul(class_mask, objness_t);
            var cls_loss = nd.BroadcastMul(this._sigmoid_ce.Call(cls_preds, class_t, class_mask), denorm_class);

            LossOutput = (obj_loss, center_loss, scale_loss, cls_loss);
            return obj_loss;
        }

        private NDArrayOrSymbol F(Symbol objness, Symbol box_centers,  Symbol box_scales, Symbol cls_preds, Symbol objness_t, Symbol center_t, Symbol scale_t, Symbol weight_t, Symbol class_t, Symbol class_mask)
        {
            var denorm = sym.Cast(sym.ShapeArray(objness_t).SliceAxis(axis: 0, begin: 1, end: null).Prod(), "float32");
            weight_t = sym.BroadcastMul(weight_t, objness_t);
            var hard_objness_t = sym.Where(sym.GreaterScalar(objness_t,0), sym.OnesLike(objness_t), objness_t);
            var new_objness_mask = sym.Where(sym.GreaterScalar(objness_t, 0), objness_t, sym.GreaterEqualScalar(objness_t, 0));
            var obj_loss = sym.BroadcastMul(this._sigmoid_ce.Call(objness, hard_objness_t, new_objness_mask), denorm);
            var center_loss = sym.BroadcastMul(this._sigmoid_ce.Call(box_centers, center_t, weight_t), denorm * 2);
            var scale_loss = sym.BroadcastMul(this._l1_loss.Call(box_scales, scale_t, weight_t), denorm * 2);
            var denorm_class = sym.Cast(sym.ShapeArray(class_t).SliceAxis(axis: 0, begin: 1, end: null).Prod(), "float32");
            class_mask = sym.BroadcastMul(class_mask, objness_t);
            var cls_loss = sym.BroadcastMul(this._sigmoid_ce.Call(cls_preds, class_t, class_mask), denorm_class);

            LossOutput = (obj_loss, center_loss, scale_loss, cls_loss);
            return obj_loss;
        }
    }
}
