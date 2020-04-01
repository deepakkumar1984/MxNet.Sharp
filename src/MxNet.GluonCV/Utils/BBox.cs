using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Utils
{
    public class BBox
    {
        public static ndarray BBoxIOU(ndarray bbox_a, ndarray bbox_b, float offset= 0)
        {
            if (bbox_a.shape.iDims[1] < 4 || bbox_b.shape.iDims[1] < 4)
            {
                throw new Exception("Bounding boxes axis 1 must have at least length 4");
            }

            var tl = np.maximum(bbox_a[":", null, ":2"], bbox_b[":", ":2"]);
            var br = np.minimum(bbox_a[":", null, "2:4"], bbox_b[":", "2:4"]);
            var area_i = np.prod(br - tl + offset, axis: 2) * (tl < br).All(axis: 2);
            var area_a = np.prod((ndarray)bbox_a[":", "2:4"] - (ndarray)bbox_a[":",":2"] + offset, axis: 1);
            var area_b = np.prod((ndarray)bbox_b[":", "2:4"] - (ndarray)bbox_b[":",":2"] + offset, axis: 1);
            return (ndarray)(area_i / ((ndarray)area_a[":", null] + area_b - area_i));
        }

        public static ndarray BBox_XYWH_XYXY(ndarray xywh)
        {
            if (!(xywh.Size % 4 == 0))
            {
                throw new Exception($"Bounding boxes must have n * 4 elements, given {xywh.shape}");
            }

            var xyxy = np.hstack(new List<object>() { xywh[":", ":2"], (xywh[":", ":2"] + np.maximum(0, (ndarray)xywh[":", "2:4"] - 1)) });
            return xyxy;
        }

        public static (int, int, int, int) BBox_XYWH_XYXY((int, int, int, int) xywh)
        {
            var w = Math.Max(xywh.Item3 - 1, 0);
            var h = Math.Max(xywh.Item4 - 1, 0);
            return (xywh.Item1, xywh.Item2, xywh.Item1 + w, xywh.Item2 + h);
        }

        public static ndarray BBox_XYXY_XYWH(ndarray xyxy)
        {
            if (!(xyxy.Size % 4 == 0))
            {
                throw new Exception($"Bounding boxes must have n * 4 elements, given {xyxy.shape}");
            }

            var xywh = np.hstack(new List<object>() { xyxy[":", ":2"], ((ndarray)xyxy[":", "2:4"] + xyxy[":", ":2"] + 1) });
            return xywh;
        }

        public static (int, int, int, int) BBox_XYXY_XYWH((int, int, int, int) xyxy)
        {
            var x1 = xyxy.Item1;
            var y1 = xyxy.Item2;
            var w = xyxy.Item3 - x1 + 1;
            var h = xyxy.Item4 - y1 + 1;
            return (x1, y1, w, h);
        }

        public static ndarray BBoxClipXYXY(ndarray xyxy, int width, int height)
        {
            if (!(xyxy.size % 4 == 0))
            {
                throw new Exception($"Bounding boxes must have n * 4 elements, given {xyxy.shape}");
            }

            var x1 = np.minimum(width - 1, np.maximum(0, xyxy[":", 0]));
            var y1 = np.minimum(height - 1, np.maximum(0, xyxy[":", 1]));
            var x2 = np.minimum(width - 1, np.maximum(0, xyxy[":", 2]));
            var y2 = np.minimum(height - 1, np.maximum(0, xyxy[":", 3]));
            return np.hstack(new List<object>() { x1, y1, x2, y2 });
        }

        public static (int, int, int, int) BBoxClipXYXY((int, int, int, int) xyxy, int width, int height)
        {
            int x1 = Math.Min(width - 1, Math.Max(0, xyxy.Item1));
            int y1 = Math.Min(height - 1, Math.Max(0, xyxy.Item2));
            int x2 = Math.Min(width - 1, Math.Max(0, xyxy.Item3));
            int y2 = Math.Min(height - 1, Math.Max(0, xyxy.Item4));
            return (x1, y1, x2, y2);
        }
    }
}
