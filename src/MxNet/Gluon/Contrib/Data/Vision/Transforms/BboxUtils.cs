using MxNet.Gluon.Probability.Distributions.Constraints;
using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data.Vision.Transforms
{
    public class BboxUtils
    {
        private static void _check_bbox_shape(ndarray bbox)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static ndarray BboxCrop(ndarray bbox, ndarray crop_box= null, bool allow_outside_center= true)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static ndarray BboxFlip(ndarray bbox, (int, int) size, bool flip_x = false, bool flip_y = false)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static ndarray BboxResize(ndarray bbox, (int, int) in_size, (int, int) out_size)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static ndarray BboxTranslate(ndarray bbox, float x_offset= 0, float y_offset= 0)
        {
            throw new NotImplementedRelease1Exception();
        }

        public static ndarray BboxIou(ndarray bbox_a, ndarray bbox_b, float offset= 0)
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

        public static ndarray BboxRandomCropWithConstraints(ndarray bbox, (int, int) size, float min_scale= 0.3f, float max_scale= 1,
                                      float max_aspect_ratio= 2, Constraint[] constraints= null, int max_trial= 50)
        {
            throw new NotImplementedRelease1Exception();
        }
    }
}
