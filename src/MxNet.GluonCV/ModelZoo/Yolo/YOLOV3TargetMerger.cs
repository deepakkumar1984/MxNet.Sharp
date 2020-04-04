using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLOV3TargetMerger : HybridBlock
    {
        private bool _label_smooth;

        private int _num_class;

        private YOLOV3DynamicTargetGeneratorSimple _dynamic_target;

        public YOLOV3TargetMerger(int num_class, float ignore_iou_thresh, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            this._num_class = num_class;
            this._dynamic_target = new YOLOV3DynamicTargetGeneratorSimple(num_class, ignore_iou_thresh);
            this._label_smooth = false;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0], args[1], args[2], args[3], args[4], args[5]);

            return F(x.SymX, args[0], args[1], args[2], args[3], args[4], args[5]);
        }

        private NDArrayOrSymbol F(NDArray box_preds, NDArray gt_boxes, NDArray obj_t, NDArray centers_t, NDArray scales_t, NDArray weights_t, NDArray clas_t)
        {
            using (var ag = Autograd.Pause()) 
            {
                NDArrayList dynamic_t = this._dynamic_target.Call(box_preds, gt_boxes).NdXList;
                // use fixed target to override dynamic targets
                var _tup_1 = Enumerable.Zip(dynamic_t, new List<NDArray> {
                                            obj_t,
                                            centers_t,
                                            scales_t,
                                            weights_t,
                                            clas_t
                                        }, (i0, i1) => {
                                            return (i0, i1);
                                        }).ToList();
                var obj = _tup_1[0];
                var centers = _tup_1[1];
                var scales = _tup_1[2];
                var weights = _tup_1[3];
                var clas = _tup_1[4];
                var mask = obj.i1 > 0;
                var objectness = nd.Where(mask, obj.i1, obj.i0);
                var mask2 = mask.Tile(reps: new Shape(2));
                var center_targets = nd.Where(mask2, centers.i1, centers.i0);
                var scale_targets = nd.Where(mask2, scales.i1, scales.i0);
                var weights1 = nd.Where(mask2, weights.i1, weights.i0);
                var mask3 = mask.Tile(reps: new Shape(this._num_class));
                var class_targets = nd.Where(mask3, clas.i1, clas.i0);
                var smooth_weight = 1 / this._num_class;
                if (this._label_smooth)
                {
                    smooth_weight = (int)Math.Min(1 / this._num_class, 1 / 40);
                    class_targets = nd.Where(class_targets > 0.5f, class_targets - smooth_weight, class_targets);
                    class_targets = nd.Where((class_targets < -0.5f) + (class_targets > 0.5f), class_targets, nd.OnesLike(class_targets) * smooth_weight);
                }

                
                var class_mask = mask.Tile(reps: new Shape(this._num_class)) * (class_targets >= 0);
                return new NDArrayOrSymbol((from x in new List<NDArray> {
                        objectness,
                        center_targets,
                        scale_targets,
                        weights1,
                        class_targets,
                        class_mask
                    }
                        select nd.StopGradient(x)).ToArray());
            }
        }

        private NDArrayOrSymbol F(Symbol box_preds, Symbol gt_boxes, Symbol obj_t, Symbol centers_t, Symbol scales_t, Symbol weights_t, Symbol clas_t)
        {
            using (var ag = Autograd.Pause())
            {
                SymbolList dynamic_t = this._dynamic_target.Call(box_preds, gt_boxes).SymXList;
                // use fixed target to override dynamic targets
                var _tup_1 = Enumerable.Zip(dynamic_t, new List<Symbol> {
                                            obj_t,
                                            centers_t,
                                            scales_t,
                                            weights_t,
                                            clas_t
                                        }, (i0, i1) => {
                                            return (i0, i1);
                                        }).ToList();
                var obj = _tup_1[0];
                var centers = _tup_1[1];
                var scales = _tup_1[2];
                var weights = _tup_1[3];
                var clas = _tup_1[4];
                var mask = obj.i1 > 0;
                var objectness = sym.Where(mask, obj.i1, obj.i0);
                var mask2 = mask.Tile(reps: new Shape(2));
                var center_targets = sym.Where(mask2, centers.i1, centers.i0);
                var scale_targets = sym.Where(mask2, scales.i1, scales.i0);
                var weights1 = sym.Where(mask2, weights.i1, weights.i0);
                var mask3 = mask.Tile(reps: new Shape(this._num_class));
                var class_targets = sym.Where(mask3, clas.i1, clas.i0);
                var smooth_weight = 1 / this._num_class;
                if (this._label_smooth)
                {
                    smooth_weight = (int)Math.Min(1 / this._num_class, 1 / 40);
                    class_targets = sym.Where(class_targets > 0.5f, class_targets - smooth_weight, class_targets);
                    class_targets = sym.Where((class_targets < -0.5f) + (class_targets > 0.5f), class_targets, sym.OnesLike(class_targets) * smooth_weight);
                }


                var class_mask = mask.Tile(reps: new Shape(this._num_class)) * (class_targets >= 0);
                return new NDArrayOrSymbol((from x in new List<Symbol> {
                        objectness,
                        center_targets,
                        scale_targets,
                        weights1,
                        class_targets,
                        class_mask
                    }
                                            select sym.StopGradient(x)).ToArray());
            }
        }
    }
}
