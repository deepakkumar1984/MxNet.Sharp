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

        public static (int, int, int, int) BBoxIOU((int, int, int, int) bbox_a, (int, int, int, int) bbox_b, float offset = 0)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public static NDArray BBox_XYXY_XYWH(NDArray xyxy)
        {
            throw new NotImplementedException();
        }

        public static (int, int, int, int) BBox_XYXY_XYWH((int, int, int, int) xyxy)
        {
            throw new NotImplementedException();
        }

        public static NDArray BBoxClipXYXY(NDArray xyxy, int width, int height)
        {
            throw new NotImplementedException();
        }

        public static (int, int, int, int) BBoxClipXYXY((int, int, int, int) xyxy, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
