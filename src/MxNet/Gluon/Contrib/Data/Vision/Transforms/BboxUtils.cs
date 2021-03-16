using MxNet.Gluon.Probability.Distributions.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data.Vision.Transforms
{
    public class BboxUtils
    {
        private static void _check_bbox_shape(NDArray bbox)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static NDArray BboxCrop(NDArray bbox, NDArray crop_box= null, bool allow_outside_center= true)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static NDArray BboxFlip(NDArray bbox, (int, int) size, bool flip_x = false, bool flip_y = false)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static NDArray BboxResize(NDArray bbox, (int, int) in_size, (int, int) out_size)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static NDArray BboxTranslate(NDArray bbox, float x_offset= 0, float y_offset= 0)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static NDArray BboxIou(NDArray bbox_a, NDArray bbox_b, float offset= 0)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static (int, int, int, int) Bbox_XYWH_to_XYXY((int, int, int, int)  xywh)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static (int, int, int, int) Bbox_XYXY_to_XYWH((int, int, int, int) xyxy)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static (int, int, int, int) BboxClipXYXY((int, int, int, int) xyxy, int width, int height)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static NDArray BboxRandomCropWithConstraints(NDArray bbox, (int, int) size, float min_scale= 0.3f, float max_scale= 1,
                                      float max_aspect_ratio= 2, Constraint[] constraints= null, int max_trial= 50)
        {
            throw new NotImplementedRelease1Exception();
        }
    }
}
