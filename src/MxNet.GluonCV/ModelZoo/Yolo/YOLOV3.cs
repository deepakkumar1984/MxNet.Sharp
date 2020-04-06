using MxNet.Gluon;
using MxNet.Gluon.NN;
using MxNet.GluonCV.Data;
using MxNet.GluonCV.Losses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLOV3 : HybridBlock
    {
        private string[] _classes;

        private float _ignore_iou_thresh;

        private YOLOV3Loss _loss;

        private float _pos_iou_thresh;

        private YOLOV3TargetMerger _target_generator;

        private float nms_thresh;

        private int nms_topk;

        private int post_nms;

        private HybridSequential stages;

        private HybridSequential transitions;

        private HybridSequential yolo_blocks;

        private HybridSequential yolo_outputs;

        public int NumClass => _classes.Length;

        public string[] Classes => _classes;

        public YOLOV3(HybridBlock[] stages, int[] channels, NDArray anchors, int[] strides, string[] classes, (int, int)? alloc_size= null,
                 float nms_thresh= 0.45f, int nms_topk= 400, int post_nms= 100, float pos_iou_thresh= 1,
                 float ignore_iou_thresh= 0.7f, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            this._classes = classes;
            this.nms_thresh = nms_thresh;
            this.nms_topk = nms_topk;
            this.post_nms = post_nms;
            this._pos_iou_thresh = pos_iou_thresh;
            this._ignore_iou_thresh = ignore_iou_thresh;
            if (pos_iou_thresh >= 1)
            {
                this._target_generator = new YOLOV3TargetMerger(classes.Length, ignore_iou_thresh);
            }
            else
            {
                throw new NotImplementedException($"pos_iou_thresh({pos_iou_thresh}) < 1.0 is not implemented!");
            }
            this._loss = new YOLOV3Loss();
            this.stages = new HybridSequential();
            this.transitions = new HybridSequential();
            this.yolo_blocks = new HybridSequential();
            this.yolo_outputs = new HybridSequential();
            // note that anchors and strides should be used in reverse order
            var revstrides = strides.Reverse().ToArray();
            foreach (var i in Enumerable.Range(0, stages.Length))
            {
                var stage = stages[i];
                var channel = channels[i];
                var anchor = anchors.Reverse(new Shape(0))[i];
                var stride = revstrides[i];
                this.stages.Add(stage);
                var block = new YOLODetectionBlockV3(channel, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
                this.yolo_blocks.Add(block);
                var output = new YOLOOutputV3(i, classes.Length, anchor, stride, alloc_size: alloc_size);
                this.yolo_outputs.Add(output);
                if (i > 0)
                {
                    this.transitions.Add(DarknetV3.Conv2d(channel, 1, 0, 1, norm_layer: norm_layer, norm_kwargs: norm_kwargs));
                }
            }
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args.ToList().ToNDArrays());

            return F(x.SymX, args.ToList().ToSymbols());
        }

        public NDArrayOrSymbol F(NDArray x, NDArray[] args)
        {
            if (args.Length != 0 && !Autograd.IsTraining())
            {
                throw new Exception("YOLOV3 inference only need one input data.");
            }

            var all_box_centers = new List<NDArray>();
            var all_box_scales = new List<NDArray>();
            var all_objectness = new List<NDArray>();
            var all_class_pred = new List<NDArray>();
            var all_anchors = new List<NDArray>();
            var all_offsets = new List<NDArray>();
            var all_feat_maps = new List<NDArray>();
            var all_detections = new List<NDArray>();
            var routes = new List<NDArray>();
            foreach (var item in stages._childrens)
            {
                x = item.Value.Call(x);
                routes.Add(x);
            }

            foreach (var i in Enumerable.Range(0, routes.Count))
            {
                var block = yolo_blocks[i];
                var output = yolo_outputs[i];
                var _tup_3 = block.Call(x);
                x = _tup_3[0];
                NDArray tip = _tup_3[1];
                NDArray dets = null;

                if (Autograd.IsTraining())
                {
                    var _tup_4 = output.Call(tip);
                    dets = _tup_4[0];
                    NDArray box_centers = _tup_4[1];
                    NDArray box_scales = _tup_4[2];
                    NDArray objness = _tup_4[3];
                    NDArray class_pred = _tup_4[4];
                    NDArray anchors = _tup_4[5];
                    NDArray offsets = _tup_4[6];
                    all_box_centers.Add(box_centers.Reshape(0, -3, -1));
                    all_box_scales.Add(box_scales.Reshape(0, -3, -1));
                    all_objectness.Add(objness.Reshape(0, -3, -1));
                    all_class_pred.Add(class_pred.Reshape(0, -3, -1));
                    all_anchors.Add(anchors);
                    all_offsets.Add(offsets);
                    // here we use fake featmap to reduce memory consuption, only shape[2, 3] is used
                    var fake_featmap = nd.ZerosLike(tip.SliceAxis(axis: 0, begin: 0, end: 1).SliceAxis(axis: 1, begin: 0, end: 1));
                    all_feat_maps.Add(fake_featmap);
                }
                else
                {
                    dets = output.Call(tip);
                }

                all_detections.Add(dets);
                if (i >= routes.Count - 1)
                {
                    break;
                }
                // add transition layers
                x = this.transitions[i].Call(x);
                // upsample feature map reverse to shallow layers
                var upsample = Upsample(x, stride: 2);
                var route_now = routes.ToArray().Reverse().ToArray()[i + 1];
                x = nd.Concat(new NDArrayList(nd.SliceLike(upsample, route_now * 0, axes: new Shape(2, 3)), route_now), dim: 1);
            }

            if (Autograd.IsTraining())
            {
                // during training, the network behaves differently since we don't need detection results
                if (Autograd.IsRecording())
                {
                    // generate losses and return them directly
                    var box_preds = nd.Concat(all_detections, dim: 1);
                    var all_preds = (from p in new List<NDArrayList> {
                            all_objectness,
                            all_box_centers,
                            all_box_scales,
                            all_class_pred
                        }
                                     select nd.Concat(p, dim: 1)).ToList();
                    var all_targets = this._target_generator.Call(box_preds, args.ToNDArrayOrSymbols()).NdXList;
                    var lossx = all_preds;
                    lossx.AddRange(all_targets);
                    return this._loss.Call(new NDArrayOrSymbol(lossx.ToArray()));
                }

                // return raw predictions, this is only used in DataLoader transform function.
                return new NDArrayOrSymbol(nd.Concat(all_detections, dim: 1),
                        nd.Concat(all_anchors, dim: 1),
                        nd.Concat(all_offsets, dim: 1),
                        nd.Concat(all_feat_maps, dim: 1),
                        nd.Concat(all_box_centers, dim: 1),
                        nd.Concat(all_box_scales, dim: 1),
                        nd.Concat(all_objectness, dim: 1),
                        nd.Concat(all_class_pred, dim: 1));
            }

            // concat all detection results from different stages
            var result = nd.Concat(all_detections, dim: 1);
            // apply nms per class
            if (this.nms_thresh > 0 && this.nms_thresh < 1)
            {
                result = nd.Contrib.BoxNms(result, overlap_thresh: this.nms_thresh, valid_thresh: 0.01f, topk: this.nms_topk, id_index: 0, score_index: 1, coord_start: 2, force_suppress: false);
                if (this.post_nms > 0)
                {
                    result = result.SliceAxis(axis: 1, begin: 0, end: this.post_nms);
                }
            }
            var ids = result.SliceAxis(axis: -1, begin: 0, end: 1);
            var scores = result.SliceAxis(axis: -1, begin: 1, end: 2);
            var bboxes = result.SliceAxis(axis: -1, begin: 2, end: null);
            return new NDArrayOrSymbol(ids, scores, bboxes);
        }

        public NDArrayOrSymbol F(Symbol x, Symbol[] args)
        {
            if (args.Length != 0 && !Autograd.IsTraining())
            {
                throw new Exception("YOLOV3 inference only need one input data.");
            }

            var all_box_centers = new List<Symbol>();
            var all_box_scales = new List<Symbol>();
            var all_objectness = new List<Symbol>();
            var all_class_pred = new List<Symbol>();
            var all_anchors = new List<Symbol>();
            var all_offsets = new List<Symbol>();
            var all_feat_maps = new List<Symbol>();
            var all_detections = new List<Symbol>();
            var routes = new List<Symbol>();
            foreach (var item in stages._childrens)
            {
                x = item.Value.Call(x);
                routes.Add(x);
            }

            foreach (var i in Enumerable.Range(0, routes.Count))
            {
                var block = yolo_blocks[i];
                var output = yolo_outputs[i];
                var _tup_3 = block.Call(x);
                x = _tup_3[0];
                Symbol tip = _tup_3[1];
                Symbol dets = null;

                if (Autograd.IsTraining())
                {
                    var _tup_4 = output.Call(tip);
                    dets = _tup_4[0];
                    Symbol box_centers = _tup_4[1];
                    Symbol box_scales = _tup_4[2];
                    Symbol objness = _tup_4[3];
                    Symbol class_pred = _tup_4[4];
                    Symbol anchors = _tup_4[5];
                    Symbol offsets = _tup_4[6];
                    all_box_centers.Add(box_centers.Reshape(0, -3, -1));
                    all_box_scales.Add(box_scales.Reshape(0, -3, -1));
                    all_objectness.Add(objness.Reshape(0, -3, -1));
                    all_class_pred.Add(class_pred.Reshape(0, -3, -1));
                    all_anchors.Add(anchors);
                    all_offsets.Add(offsets);
                    // here we use fake featmap to reduce memory consuption, only shape[2, 3] is used
                    var fake_featmap = sym.ZerosLike(tip.SliceAxis(axis: 0, begin: 0, end: 1).SliceAxis(axis: 1, begin: 0, end: 1));
                    all_feat_maps.Add(fake_featmap);
                }
                else
                {
                    dets = output.Call(tip);
                }

                all_detections.Add(dets);
                if (i >= routes.Count - 1)
                {
                    break;
                }
                // add transition layers
                x = this.transitions[i].Call(x);
                // upsample feature map reverse to shallow layers
                var upsample = Upsample(x, stride: 2);
                var route_now = routes.ToArray().Reverse().ToArray()[i + 1];
                x = sym.Concat(new SymbolList(sym.SliceLike(upsample, route_now * 0, axes: new Shape(2, 3)), route_now), dim: 1);
            }

            if (Autograd.IsTraining())
            {
                // during training, the network behaves differently since we don't need detection results
                if (Autograd.IsRecording())
                {
                    // generate losses and return them directly
                    var box_preds = sym.Concat(all_detections, dim: 1);
                    var all_preds = (from p in new List<SymbolList> {
                            all_objectness,
                            all_box_centers,
                            all_box_scales,
                            all_class_pred
                        }
                                     select sym.Concat(p, dim: 1)).ToList();
                    var all_targets = this._target_generator.Call(box_preds, args.ToNDArrayOrSymbols()).SymXList;
                    var lossx = all_preds;
                    lossx.AddRange(all_targets);
                    return this._loss.Call(new NDArrayOrSymbol(lossx.ToArray()));
                }

                // return raw predictions, this is only used in DataLoader transform function.
                return new NDArrayOrSymbol(sym.Concat(all_detections, dim: 1),
                        sym.Concat(all_anchors, dim: 1),
                        sym.Concat(all_offsets, dim: 1),
                        sym.Concat(all_feat_maps, dim: 1),
                        sym.Concat(all_box_centers, dim: 1),
                        sym.Concat(all_box_scales, dim: 1),
                        sym.Concat(all_objectness, dim: 1),
                        sym.Concat(all_class_pred, dim: 1));
            }

            // concat all detection results from different stages
            var result = sym.Concat(all_detections, dim: 1);
            // apply nms per class
            if (this.nms_thresh > 0 && this.nms_thresh < 1)
            {
                result = sym.Contrib.BoxNms(result, overlap_thresh: this.nms_thresh, valid_thresh: 0.01f, topk: this.nms_topk, id_index: 0, score_index: 1, coord_start: 2, force_suppress: false);
                if (this.post_nms > 0)
                {
                    result = result.SliceAxis(axis: 1, begin: 0, end: this.post_nms);
                }
            }
            var ids = result.SliceAxis(axis: -1, begin: 0, end: 1);
            var scores = result.SliceAxis(axis: -1, begin: 1, end: 2);
            var bboxes = result.SliceAxis(axis: -1, begin: 2, end: null);
            return new NDArrayOrSymbol(ids, scores, bboxes);
        }

        internal static NDArrayOrSymbol Upsample(NDArrayOrSymbol x, int stride= 2)
        {
            return nd.Repeat(nd.Repeat(x, axis: -1, repeats: stride), axis: -2, repeats: stride);
        }

        public void SetNms(float nms_thresh= 0.45f, int nms_topk= 400, int post_nms= 100)
        {
            this.ClearCachedOp();
            this.nms_thresh = nms_thresh;
            this.nms_topk = nms_topk;
            this.post_nms = post_nms;
        }

        public void ResetClass(string[] classes, Dictionary<int, int> reuse_weights = null)
        {
            this.ClearCachedOp();
            var old_classes = this._classes;
            this._classes = classes;
            if (this._pos_iou_thresh >= 1)
            {
                this._target_generator = new YOLOV3TargetMerger(classes.Length, this._ignore_iou_thresh);
            }
            var new_map = new Dictionary<int, int>();

            foreach (var x in reuse_weights)
            {
                var k = x.Key;
                var v = x.Value;
                if (v < 0 || v >= old_classes.Length)
                {
                    throw new Exception($"Index {v} out of bounds for old class names");
                }

                if (k < 0 || k >= classes.Length)
                {
                    throw new Exception($"Index {k} out of bounds for new class names");
                }

                new_map[k] = v;
            }

            reuse_weights = new_map;

            foreach (YOLOOutputV3 output in this.yolo_outputs._childrens.Values)
            {
                output.ResetClass(classes, reuse_weights: reuse_weights);
            }
        }

        public static YOLOV3 GetYOLOV3(string name, HybridBlock[] stages, int[] filters, NDArray anchors, int[] strides, string[] classes,
               string dataset, bool pretrained= false, Context ctx= null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            var net = new YOLOV3(stages, filters, anchors, strides, classes: classes, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
            if (pretrained)
            {
                var full_name = string.Join("_", "yolo3", name, dataset);
                net.LoadParameters(ModelStore.GetModelFile(full_name, tag: "pretrained", root: root), ctx: ctx);
            }

            return net;
        }

        public static YOLOV3 YOLO3_Darknet53_VOC(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            pretrained_base = pretrained ? false : pretrained_base;
            var base_net = DarknetV3.Darknet53(pretrained: pretrained_base, norm_layer: norm_layer, norm_kwargs: norm_kwargs, ctx: ctx, root: root);
            var stages = new List<HybridBlock> {
                new HybridBlock(base_net.features._childrens.Take(15).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.features._childrens.Skip(15).Take(9).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.features._childrens.Skip(24).ToDictionary(x=> x.Key, x=>x.Value))
            };

            Array anchorsArray = new int[,] { {10,13,16,30,33,23 },{ 30, 61, 62, 45, 59, 119 },{ 116, 90, 156, 198, 373, 326 } };
            var anchors = nd.Array(anchorsArray);
            var strides = new int[] { 8, 16, 32 };

            var classes = VOCDetection.CLASSES;
            return GetYOLOV3("darknet53", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "voc", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
        }

        public static YOLOV3 YOLO3_Darknet53_COCO(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            pretrained_base = pretrained ? false : pretrained_base;
            var base_net = DarknetV3.Darknet53(pretrained: pretrained_base, norm_layer: norm_layer, norm_kwargs: norm_kwargs, ctx: ctx, root: root);
            var stages = new List<HybridBlock> {
                new HybridBlock(base_net.features._childrens.Take(15).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.features._childrens.Skip(15).Take(9).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.features._childrens.Skip(24).ToDictionary(x=> x.Key, x=>x.Value))
            };

            Array anchorsArray = new int[,] { { 10, 13, 16, 30, 33, 23 }, { 30, 61, 62, 45, 59, 119 }, { 116, 90, 156, 198, 373, 326 } };
            var anchors = nd.Array(anchorsArray);
            var strides = new int[] { 8, 16, 32 };

            var classes = VOCDetection.CLASSES;
            return GetYOLOV3("darknet53", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "coco", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
        }

        public static YOLOV3 YOLO3_Darknet53_Custom(string[] classes, string transfer = "", bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            if (pretrained)
                Logger.Warning("Custom models don't provide `pretrained` weights, ignored.");

            if (string.IsNullOrWhiteSpace(transfer))
            {
                pretrained_base = pretrained ? false : pretrained_base;
                var base_net = DarknetV3.Darknet53(pretrained: pretrained_base, norm_layer: norm_layer, norm_kwargs: norm_kwargs, ctx: ctx, root: root);
                var stages = new List<HybridBlock> {
                new HybridBlock(base_net.features._childrens.Take(15).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.features._childrens.Skip(15).Take(9).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.features._childrens.Skip(24).ToDictionary(x=> x.Key, x=>x.Value))
            };

                Array anchorsArray = new int[,] { { 10, 13, 16, 30, 33, 23 }, { 30, 61, 62, 45, 59, 119 }, { 116, 90, 156, 198, 373, 326 } };
                var anchors = nd.Array(anchorsArray);
                var strides = new int[] { 8, 16, 32 };

                return GetYOLOV3("darknet53", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
            }
            else
            {
                YOLOV3 net = Models.GetModel<YOLOV3>( "YOLO3_Darknet53_" + transfer.ToString(), pretrained: true, classes, ctx, root);
                var reuse_classes = (from x in classes
                                     where net.Classes.Contains(x)
                                     select classes.ToList().IndexOf(x)).ToDictionary(i => i, i => i);
                net.ResetClass(classes, reuse_weights: reuse_classes);

                return net;
            }
        }

        public static YOLOV3 YOLO3_Mobilenet1_0_VOC(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            pretrained_base = pretrained ? false : pretrained_base;
            var base_net = MobileNet.GetMobileNet(multiplier: 1, pretrained: pretrained_base, ctx, root);
            var stages = new List<HybridBlock> {
                new HybridBlock(base_net.Features._childrens.Take(33).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(33).Take(69).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(69).Take(base_net.Features._childrens.Count - 2 - 69).ToDictionary(x=> x.Key, x=>x.Value))
            };

            Array anchorsArray = new int[,] { { 10, 13, 16, 30, 33, 23 }, { 30, 61, 62, 45, 59, 119 }, { 116, 90, 156, 198, 373, 326 } };
            var anchors = nd.Array(anchorsArray);
            var strides = new int[] { 8, 16, 32 };

            var classes = VOCDetection.CLASSES;
            return GetYOLOV3("mobilenet1.0", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "voc", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
        }

        public static YOLOV3 YOLO3_Mobilenet1_0_COCO(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            pretrained_base = pretrained ? false : pretrained_base;
            var base_net = MobileNet.GetMobileNet(multiplier: 1, pretrained: pretrained_base, ctx, root);
            var stages = new List<HybridBlock> {
                new HybridBlock(base_net.Features._childrens.Take(33).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(33).Take(69).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(69).Take(base_net.Features._childrens.Count - 2 - 69).ToDictionary(x=> x.Key, x=>x.Value))
            };

            Array anchorsArray = new int[,] { { 10, 13, 16, 30, 33, 23 }, { 30, 61, 62, 45, 59, 119 }, { 116, 90, 156, 198, 373, 326 } };
            var anchors = nd.Array(anchorsArray);
            var strides = new int[] { 8, 16, 32 };

            var classes = VOCDetection.CLASSES;
            return GetYOLOV3("mobilenet1.0", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "coco", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
        }

        public static YOLOV3 YOLO3_Mobilenet1_0_Custom(string[] classes, string transfer = "", bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            if (pretrained)
                Logger.Warning("Custom models don't provide `pretrained` weights, ignored.");

            if (string.IsNullOrWhiteSpace(transfer))
            {
                pretrained_base = pretrained ? false : pretrained_base;
                var base_net = MobileNet.GetMobileNet(multiplier: 1, pretrained: pretrained_base, ctx, root);
                var stages = new List<HybridBlock> {
                    new HybridBlock(base_net.Features._childrens.Take(33).ToDictionary(x=> x.Key, x=>x.Value)),
                    new HybridBlock(base_net.Features._childrens.Skip(33).Take(69).ToDictionary(x=> x.Key, x=>x.Value)),
                    new HybridBlock(base_net.Features._childrens.Skip(69).Take(base_net.Features._childrens.Count - 2 - 69).ToDictionary(x=> x.Key, x=>x.Value))
                };

                Array anchorsArray = new int[,] { { 10, 13, 16, 30, 33, 23 }, { 30, 61, 62, 45, 59, 119 }, { 116, 90, 156, 198, 373, 326 } };
                var anchors = nd.Array(anchorsArray);
                var strides = new int[] { 8, 16, 32 };

                return GetYOLOV3("mobilenet1.0", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
            }
            else
            {
                YOLOV3 net = Models.GetModel<YOLOV3>("YOLO3_Mobilenet1_0_" + transfer.ToString(), pretrained: true, classes, ctx, root);
                var reuse_classes = (from x in classes
                                     where net.Classes.Contains(x)
                                     select classes.ToList().IndexOf(x)).ToDictionary(i => i, i => i);
                net.ResetClass(classes, reuse_weights: reuse_classes);

                return net;
            }
        }

        public static YOLOV3 YOLO3_Mobilenet0_25_VOC(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            pretrained_base = pretrained ? false : pretrained_base;
            var base_net = MobileNet.GetMobileNet(multiplier: 0.25f, pretrained: pretrained_base, ctx, root);
            var stages = new List<HybridBlock> {
                new HybridBlock(base_net.Features._childrens.Take(33).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(33).Take(69).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(69).Take(base_net.Features._childrens.Count - 2 - 69).ToDictionary(x=> x.Key, x=>x.Value))
            };

            Array anchorsArray = new int[,] { { 10, 13, 16, 30, 33, 23 }, { 30, 61, 62, 45, 59, 119 }, { 116, 90, 156, 198, 373, 326 } };
            var anchors = nd.Array(anchorsArray);
            var strides = new int[] { 8, 16, 32 };

            var classes = VOCDetection.CLASSES;
            return GetYOLOV3("mobilenet0.25", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "coco", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
        }

        public static YOLOV3 YOLO3_Mobilenet0_25_COCO(bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            pretrained_base = pretrained ? false : pretrained_base;
            var base_net = MobileNet.GetMobileNet(multiplier: 0.25f, pretrained: pretrained_base, ctx, root);
            var stages = new List<HybridBlock> {
                new HybridBlock(base_net.Features._childrens.Take(33).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(33).Take(69).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(69).Take(base_net.Features._childrens.Count - 2 - 69).ToDictionary(x=> x.Key, x=>x.Value))
            };

            Array anchorsArray = new int[,] { { 10, 13, 16, 30, 33, 23 }, { 30, 61, 62, 45, 59, 119 }, { 116, 90, 156, 198, 373, 326 } };
            var anchors = nd.Array(anchorsArray);
            var strides = new int[] { 8, 16, 32 };

            var classes = VOCDetection.CLASSES;
            return GetYOLOV3("mobilenet0.25", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "coco", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
        }

        public static YOLOV3 YOLO3_Mobilenet0_25_Custom(string[] classes, string transfer = "", bool pretrained_base = true, bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            if (pretrained)
                Logger.Warning("Custom models don't provide `pretrained` weights, ignored.");

            if (string.IsNullOrWhiteSpace(transfer))
            {
                pretrained_base = pretrained ? false : pretrained_base;
                var base_net = MobileNet.GetMobileNet(multiplier: 0.25f, pretrained: pretrained_base, ctx, root);
                var stages = new List<HybridBlock> {
                new HybridBlock(base_net.Features._childrens.Take(33).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(33).Take(69).ToDictionary(x=> x.Key, x=>x.Value)),
                new HybridBlock(base_net.Features._childrens.Skip(69).Take(base_net.Features._childrens.Count - 2 - 69).ToDictionary(x=> x.Key, x=>x.Value))
                    };

                Array anchorsArray = new int[,] { { 10, 13, 16, 30, 33, 23 }, { 30, 61, 62, 45, 59, 119 }, { 116, 90, 156, 198, 373, 326 } };
                var anchors = nd.Array(anchorsArray);
                var strides = new int[] { 8, 16, 32 };

                return GetYOLOV3("mobilenet0.25", stages.ToArray(), new int[] { 512, 256, 128 }, anchors, strides, classes, "", pretrained: pretrained, ctx: ctx, root: root, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
            }
            else
            {
                YOLOV3 net = Models.GetModel<YOLOV3>("yolo3_mobilenet0.25_" + transfer.ToString(), pretrained: true, classes, ctx, root);
                var reuse_classes = (from x in classes
                                     where net.Classes.Contains(x)
                                     select classes.ToList().IndexOf(x)).ToDictionary(i => i, i => i);
                net.ResetClass(classes, reuse_weights: reuse_classes);

                return net;
            }
        }
    }
}
