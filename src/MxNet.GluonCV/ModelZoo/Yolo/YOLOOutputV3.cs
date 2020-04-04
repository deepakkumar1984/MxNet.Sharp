using MxNet.Gluon;
using MxNet.Gluon.NN;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLOOutputV3 : HybridBlock
    {
        private int _classes;

        private int _num_anchors;

        private int _num_pred;

        private int _stride;

        private Parameter anchors;

        private Parameter offsets;

        private Conv2D prediction;

        public YOLOOutputV3(int index, int num_class, NDArray anchors, int stride, (int, int)? alloc_size= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            if (!alloc_size.HasValue)
                alloc_size = (128, 128);
            this._classes = num_class;
            this._num_pred = 1 + 4 + num_class;
            this._num_anchors = anchors.Size / 2;
            this._stride = stride;
            var all_pred = this._num_pred * this._num_anchors;
            this.prediction = new Conv2D(all_pred, kernel_size: (1, 1), padding: (0, 0), strides: (1, 1));
            // anchors will be multiplied to predictions
            anchors = anchors.Reshape(1, 1, -1, 2);
            this.anchors = this.Params.GetConstant($"anchor_{index}", anchors);
            // offsets will be added to predictions
            var grid_x = np.arange(alloc_size.Value.Item2);
            var grid_y = np.arange(alloc_size.Value.Item1);
            var _tup_1 = np.meshgrid(new ndarray[] { grid_x, grid_y });
            grid_x = _tup_1[0];
            grid_y = _tup_1[1];
            // stack to (n, n, 2)
            var np_offsets = np.concatenate((grid_x[":", ":", np.newaxis], grid_y[":", ":", np.newaxis]), axis: -1);
            // expand dims to (1, 1, n, n, 2) so it's easier for broadcasting
            np_offsets = np.expand_dims(np.expand_dims(np_offsets, axis: 0), axis: 0);
            this.offsets = this.Params.GetConstant($"offset_{index}", np_offsets);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x.NdX, args[0], args[1]);

            return F(x.SymX, args[0], args[1]);
        }

        private NDArrayOrSymbol F(NDArray x, NDArray anchors, NDArray offsets)
        {
            // prediction flat to (batch, pred per pixel, height * width)
            NDArray pred = this.prediction.Call(x);
            pred = pred.Reshape(0, this._num_anchors * this._num_pred, -1);
            // transpose to (batch, height * width, num_anchor, num_pred)
            pred = pred.Transpose(axes: new Shape(0, 2, 1)).Reshape(0, -1, this._num_anchors, this._num_pred);
            // components
            var raw_box_centers = pred.SliceAxis(axis: -1, begin: 0, end: 2);
            var raw_box_scales = pred.SliceAxis(axis: -1, begin: 2, end: 4);
            var objness = pred.SliceAxis(axis: -1, begin: 4, end: 5);
            var class_pred = pred.SliceAxis(axis: -1, begin: 5, end: null);
            // valid offsets, (1, 1, height, width, 2)
            offsets = nd.SliceLike(offsets, x * 0, axes: new Shape(2, 3));
            // reshape to (1, height*width, 1, 2)
            offsets = offsets.Reshape(1, -1, 1, 2);
            var box_centers = nd.BroadcastAdd(nd.Sigmoid(raw_box_centers), offsets) * this._stride;
            var box_scales = nd.BroadcastMul(nd.Exp(raw_box_scales), anchors);
            var confidence = nd.Sigmoid(objness);
            var class_score = nd.BroadcastMul(nd.Sigmoid(class_pred), confidence);
            var wh = box_scales / 2;
            var bbox = nd.Concat(new NDArrayList(box_centers - wh, box_centers + wh), dim: -1);
            if (Autograd.IsTraining())
            {
                // during training, we don't need to convert whole bunch of info to detection results
                return new NDArrayOrSymbol(bbox.Reshape(0, -1, 4), raw_box_centers, raw_box_scales, objness, class_pred, anchors, offsets);
            }

            // prediction per class
            var bboxes = nd.Tile(bbox, reps: new Shape(this._classes, 1, 1, 1, 1));
            var scores = nd.Transpose(class_score, axes: new Shape(3, 0, 1, 2)).ExpandDims(axis: -1);
            var ids = nd.BroadcastAdd(scores * 0, nd.Arange(0, this._classes).Reshape(0, 1, 1, 1, 1));
            var detections = nd.Concat(new NDArrayList(ids, scores, bboxes), dim: -1);
            // reshape to (B, xx, 6)
            detections = nd.Reshape(detections.Transpose(axes: new Shape(1, 0, 2, 3, 4)), new Shape(0, -1, 6));
            return detections;
        }

        private NDArrayOrSymbol F(Symbol x, Symbol anchors, Symbol offsets)
        {
            // prediction flat to (batch, pred per pixel, height * width)
            Symbol pred = this.prediction.Call(x);
            pred = pred.Reshape(0, this._num_anchors * this._num_pred, -1);
            // transpose to (batch, height * width, num_anchor, num_pred)
            pred = pred.Transpose(axes: new Shape(0, 2, 1)).Reshape(0, -1, this._num_anchors, this._num_pred);
            // components
            var raw_box_centers = pred.SliceAxis(axis: -1, begin: 0, end: 2);
            var raw_box_scales = pred.SliceAxis(axis: -1, begin: 2, end: 4);
            var objness = pred.SliceAxis(axis: -1, begin: 4, end: 5);
            var class_pred = pred.SliceAxis(axis: -1, begin: 5, end: null);
            // valid offsets, (1, 1, height, width, 2)
            offsets = sym.SliceLike(offsets, x * 0, axes: new Shape(2, 3));
            // reshape to (1, height*width, 1, 2)
            offsets = offsets.Reshape(1, -1, 1, 2);
            var box_centers = sym.BroadcastAdd(sym.Sigmoid(raw_box_centers), offsets) * this._stride;
            var box_scales = sym.BroadcastMul(sym.Exp(raw_box_scales), anchors);
            var confidence = sym.Sigmoid(objness);
            var class_score = sym.BroadcastMul(sym.Sigmoid(class_pred), confidence);
            var wh = box_scales / 2;
            var bbox = sym.Concat(new SymbolList(box_centers - wh, box_centers + wh), dim: -1);
            if (Autograd.IsTraining())
            {
                // during training, we don't need to convert whole bunch of info to detection results
                return new NDArrayOrSymbol(bbox.Reshape(0, -1, 4), raw_box_centers, raw_box_scales, objness, class_pred, anchors, offsets);
            }

            // prediction per class
            var bboxes = sym.Tile(bbox, reps: new Shape(this._classes, 1, 1, 1, 1));
            var scores = sym.Transpose(class_score, axes: new Shape(3, 0, 1, 2)).ExpandDims(axis: -1);
            var ids = sym.BroadcastAdd(scores * 0, sym.Arange(0, this._classes).Reshape(0, 1, 1, 1, 1));
            var detections = sym.Concat(new SymbolList(ids, scores, bboxes), dim: -1);
            // reshape to (B, xx, 6)
            detections = sym.Reshape(detections.Transpose(axes: new Shape(1, 0, 2, 3, 4)), new Shape(0, -1, 6));
            return detections;
        }

        public void ResetClass(string[] classes, Dictionary<int, int> reuse_weights = null)
        {
            this.ClearCachedOp();
            // keep old records
            var old_classes = this._classes;
            var old_pred = this.prediction;
            var old_num_pred = this._num_pred;
            var ctx = old_pred.Params.Values()[0].ListCtx();
            this._classes = classes.Length;
            this._num_pred = 1 + 4 + classes.Length;
            var all_pred = this._num_pred * this._num_anchors;
            // to avoid deferred init, number of in_channels must be defined
            var in_channels = old_pred.Params.Values()[0].Shape[1];
            this.prediction = new Conv2D(all_pred, kernel_size: (1, 1), padding: (0, 0), strides: (1, 1), in_channels: in_channels, prefix: old_pred.Prefix);
            this.prediction.Initialize(ctx: ctx);
            if (reuse_weights != null)
            {
                var new_pred = this.prediction;
                foreach (var _tup_1 in Enumerable.Zip(old_pred.Params.Values(), new_pred.Params.Values(), (o, n) => (o, n)))
                {
                    var old_params = _tup_1.o;
                    var new_params = _tup_1.n;
                    ndarray old_data = old_params.Data();
                    ndarray new_data = new_params.Data();
                    foreach (var _tup_2 in reuse_weights)
                    {
                        var k = _tup_2.Key;
                        var v = _tup_2.Value;
                        if (k >= this._classes || v >= old_classes)
                        {
                            Logger.Warning($"reuse mapping {k}/{_classes} -> {v}/{old_classes} out of range");
                            continue;
                        }

                        foreach (var i in Enumerable.Range(0, this._num_anchors))
                        {
                            var off_new = i * this._num_pred;
                            var off_old = i * old_num_pred;
                            // copy along the first dimension
                            new_data[1 + 4 + k + off_new] = old_data[1 + 4 + v + off_old];
                            // copy non-class weights as well
                            new_data[$"{off_new}:{((1 + 4) + off_new)}"] = old_data[$"{off_old}:{((1 + 4) + off_old)}"];
                        }
                    }
                    // set data to new conv layers
                    new_params.SetData(new_data);
                }
            }
        }
    }
}
