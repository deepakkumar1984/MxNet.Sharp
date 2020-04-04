using MxNet.Gluon;
using MxNet.GluonCV.NN;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLOV3PrefetchTargetGenerator : Block
    {
        private int _num_class;

        private BBoxCornerToCenter bbox2center;

        private BBoxCenterToCorner bbox2corner;

        public YOLOV3PrefetchTargetGenerator(int num_classes, string prefix, ParameterDict @params) : base(prefix, @params)
        {
            this._num_class = num_classes;
            this.bbox2center = new BBoxCornerToCenter(axis: -1, split: true);
            this.bbox2corner = new BBoxCenterToCorner(axis: -1, split: false);
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArray img = x;
            NDArrayList xs = args[0].NdXList;
            NDArray anchors = args[1];
            NDArray offsets = args[2];
            NDArray gt_boxes = args[3];
            NDArray gt_ids = args[4];
            NDArray gt_mixratio = args[5];

          var all_anchors = nd.Concat((from i in Enumerable.Range(0, anchors.Shape[0])
                                                select anchors[i].Reshape(-1, 2)).ToList(), dim: 0);

            var all_offsets = nd.Concat((from i in Enumerable.Range(0, anchors.Shape[0])
                                         select offsets[i].Reshape(-1, 2)).ToList(), dim: 0);

            var l = (from i in Enumerable.Range(0, anchors.Shape[0])
                    select (anchors[i].Size / 2)).ToArray();
            var num_anchors = np.cumsum(np.array((from i in Enumerable.Range(0, anchors.Shape[0])
                                                 select (anchors[i].Size / 2)).ToArray()));
            var num_offsets = np.cumsum(np.array((from i in Enumerable.Range(0, offsets.Shape[0])
                                                  select (offsets[i].Size / 2)).ToArray()));

            var _offsets = new List<int> { 0 };
            _offsets.AddRange(num_offsets.AsInt32Array());

            Debug.Assert((xs.Length == anchors.Shape[0]) && (anchors.Shape[0] == offsets.Shape[0]));
            // orig image size
            var orig_height = img.Shape[2];
            var orig_width = img.Shape[3];
            ndarray center_targets = null;
            ndarray scale_targets = null;
            ndarray weights = null;
            ndarray objectness = null;
            ndarray class_targets = null;
            using (var ag =  Autograd.Pause())
            {
                // outputs
                var shape_like = all_anchors.Reshape(1, -1, 2) * all_offsets.Reshape(-1, 1, 2).ExpandDims(0).Repeat(repeats: gt_ids.Shape[0], axis: 0);
                center_targets = nd.ZerosLike(shape_like);
                scale_targets = nd.ZerosLike(shape_like);
                weights = nd.ZerosLike(shape_like);
                objectness = nd.ZerosLike(nd.Split(weights, axis: -1, num_outputs: 2)[0]);
                class_targets = nd.OneHot(nd.Squeeze(new NDArrayList(objectness), axis: new Shape(-1)), depth: this._num_class);
                class_targets[":"] = -1;
                // for each ground-truth, find the best matching anchor within the particular grid
                // for instance, center of object 1 reside in grid (3, 4) in (16, 16) feature map
                // then only the anchor in (3, 4) is going to be matched
                var _tup_1 = this.bbox2center.Call(gt_boxes);
                NDArray gtx = _tup_1[0];
                NDArray gty = _tup_1[1];
                NDArray gtw = _tup_1[2];
                NDArray gth = _tup_1[3];
                var shift_gt_boxes = nd.Concat(new NDArrayList(-0.5f * gtw, -0.5f * gth, 0.5f * gtw, 0.5f * gth), dim: -1);
                var anchor_boxes = nd.Concat(new NDArrayList(0 * all_anchors, all_anchors), dim: -1);
                var shift_anchor_boxes = this.bbox2corner.Call(anchor_boxes);
                var ious = nd.Contrib.BoxIou(shift_anchor_boxes, shift_gt_boxes).Transpose(new Shape(1, 0, 2));
                // real value is required to process, convert to Numpy
                var matches = ious.Argmax(axis: 1).AsNumpy();
                var valid_gts = (gt_boxes >= 0).Prod(axis: -1).ArrayData;
                
                var np_gtx = gtx.AsNumpy();
                var np_gty = gty.AsNumpy();
                var np_gtw = gtw.AsNumpy();
                var np_gth = gth.AsNumpy();
                var np_anchors = all_anchors.AsNumpy();
                var np_gt_ids = gt_ids.AsNumpy();
                var np_gt_mixratios = gt_mixratio != null ? gt_mixratio.AsNumpy() : null;
                // TODO(zhreshold): the number of valid gt is not a big number, therefore for loop
                // should not be a problem right now. Switch to better solution is needed.
                foreach (var b in Enumerable.Range(0, (int)matches.shape.iDims[0]))
                {
                    foreach (var m in Enumerable.Range(0, (int)matches.shape.iDims[1]))
                    {
                        if ((int)valid_gts.GetValue(b, m) < 1)
                        {
                            break;
                        }

                        var match = Convert.ToInt32(matches[b, m]);
                        var nlayer = (int)np.nonzero(num_anchors > match)[0][0];
                        var height = xs[nlayer].Shape[2];
                        var width = xs[nlayer].Shape[3];
                        var (gtx_bm, gty_bm, gtw_bm, gth_bm) = ((ndarray)np_gtx[b, m, 0], (ndarray)np_gty[b, m, 0], (ndarray)np_gtw[b, m, 0], (ndarray)np_gth[b, m, 0]);
                        // compute the location of the gt centers
                        var loc_x = Convert.ToInt32(gtx / orig_width * width);
                        var loc_y = Convert.ToInt32(gty / orig_height * height);
                        // write back to targets
                        var index = _offsets[nlayer] + loc_y * width + loc_x;
                        center_targets[b, index, match, 0] = gtx_bm / orig_width * width - loc_x;
                        center_targets[b, index, match, 1] = gty_bm / orig_height * height - loc_y;
                        scale_targets[b, index, match, 0] = np.log(np.maximum(gtw_bm, 1) / np_anchors[match, 0]);
                        scale_targets[b, index, match, 1] = np.log(np.maximum(gth_bm, 1) / np_anchors[match, 1]);
                        weights[b, index, match, ":"] = 2 - gtw * gth / orig_width / orig_height;
                        objectness[b, index, match, 0] = np_gt_mixratios != null ? np_gt_mixratios[b, m, 0] : 1;
                        class_targets[b, index, match, ":"] = 0;
                        class_targets[b, index, match, Convert.ToInt32(np_gt_ids[b, m, 0])] = 1;
                    }
                }
                // since some stages won't see partial anchors, so we have to slice the correct targets
                objectness = this.Slice(objectness, num_anchors, num_offsets);
                center_targets = this.Slice(center_targets, num_anchors, num_offsets);
                scale_targets = this.Slice(scale_targets, num_anchors, num_offsets);
                weights = this.Slice(weights, num_anchors, num_offsets);
                class_targets = this.Slice(class_targets, num_anchors, num_offsets);
            }

            return new NDArrayOrSymbol(objectness, center_targets, scale_targets, weights, class_targets);
        }

        private NDArray Slice(ndarray x, ndarray num_anchors, ndarray num_offsets)
        {
            var anchors = new List<int> { 0 };
            anchors.AddRange(num_anchors.AsInt32Array());

            var offsets = new List<int> { 0 };
            offsets.AddRange(num_offsets.AsInt32Array());

            var ret = new List<NDArray>();
            foreach (var i in Enumerable.Range(0, (int)num_anchors.Size))
            {
                var y = (ndarray)x[":", $"{offsets[i]}:{offsets[i + 1]}", $"{anchors[i]}:{anchors[i + 1]}", ":"];
                ret.Add(y.reshape(new shape(0, -3, -1)));
            }

            return nd.Concat(ret, dim: 1);
        }
    }
}
