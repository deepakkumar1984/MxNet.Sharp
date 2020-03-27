using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Utils
{
    public class BBox
    {
        public static NDArray BBoxIOU(NDArray bbox_a, NDArray bbox_b, float offset= 0)
        {
            throw new NotImplementedException();
        }

        public static NDArray BBox_XYWH_XYXY(NDArray xywh)
        {
            throw new NotImplementedException();
        }

        public static NDArray BBox_XYXY_XYWH(NDArray xyxy)
        {
            throw new NotImplementedException();
        }

        public static NDArray BBoxClipXYXY(NDArray xyxy, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
