using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms
{
    public class Pose
    {
        public static NDArray FlipHeatmap(NDArray heatmap, List<(int, int)> joint_pairs, bool shift = false)
        {
            throw new NotImplementedException();
        }

        public static NDArray FlipJoints3d(NDArray joints_3d, int width, List<(int, int)> joint_pairs)
        {
            throw new NotImplementedException();
        }

        public static NDArray TransformPredictions(NDArray coords, bool center, float scale, (int, int) output_size)
        {
            throw new NotImplementedException();
        }

        public static NDArray GetAffineTransform(bool center, float scale, int rot, (int, int) output_size, NDArray shift = null, int inv = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArray AffineTransform(int[] pt, NDArray t)
        {
            throw new NotImplementedException();
        }

        public static NDArray Get3rdPoint(float[] a, float[] b)
        {
            throw new NotImplementedException();
        }

        public static float[] GetDir(float[] src_point, int rot_rad)
        {
            throw new NotImplementedException();
        }

        public static NDArray Crop(NDArray img, bool center, float scale, (int, int) output_size, int rot = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArray TransformPreds(NDArray coords, bool center, float scale, (int, int) output_size)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) GetMaxPred(NDArray batch_heatmaps)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) GetFinalPreds(NDArray batch_heatmaps, bool center, float scale)
        {
            throw new NotImplementedException();
        }

        public static (int, int, int, int) UpscaleBboxFn((int, int, int, int) bbox, object img, float scale = 1.25f)
        {
            throw new NotImplementedException();
        }

        public static void CropResizeNormalize(NDArray img, List<(int, int, int, int)> bbox_list, (int, int) output_size, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public static Tuple<object, List<object>> DetectorToSimplePose(NDArray img, NDArray class_ids, NDArray scores, List<(int, int, int, int)> bounding_boxs, (int, int)? output_shape = null,float scale = 1.25f, Context ctx = null, float thr = 0.5f, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) HeatmapToCoord(NDArray heatmaps, List<(int, int, int, int)> bbox_list)
        {
            throw new NotImplementedException();
        }

        // Adjust bound
        public static (NDArray, NDArray) RefineBound((float, float) ul, (float, float) br)
        {
            throw new NotImplementedException();
        }

        // Random crop bbox
        public static ((float, float), (float, float)) RandomCropBbox(object ul, object br)
        {
            throw new NotImplementedException();
        }

        // Take random sample
        public static ((float, float), (float, float)) RandomSampleBbox((float, float) ul,
            (float, float) br,
            int w,
            int h,
            int im_width,
            int im_height)
        {
            throw new NotImplementedException();
        }

        // Count number of visible joints given bound ul, br
        public static (NDArray, NDArray) CountVisible((float, float) ul, (float, float) br, NDArray joints_3d)
        {
            throw new NotImplementedException();
        }

        public static void CvCropBox(
            NDArray img,
            (float, float) ul,
            (float, float) br,
            int resH,
            int resW,
            int pad_val = 0)
        {
            throw new NotImplementedException();
        }

        public static void CvRotate(NDArray img, float rot, int resW, int resH)
        {
            throw new NotImplementedException();
        }

        public static (int, int) TransformBox(
            (int, int) pt,
            (float, float) ul,
            (float, float) br,
            int inpH,
            int inpW,
            int resH,
            int resW)
        {
            throw new NotImplementedException();
        }

        public static NDArray DrawGaussian(NDArray img, int[] pt, float sigma, int sig = 1)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) AlphaPoseDetectionProcessor(
            NDArray img,
            NDArray boxes,
            NDArray class_idxs,
            NDArray scores,
            float thr = 0.5f)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) AlphaPoseImageCropper(NDArray source_img, NDArray boxes, NDArray scores, (int, int)? output_shape = null)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) HeatmapToCcoordAlphaPose(NDArray hms, NDArray boxes)
        {
            throw new NotImplementedException();
        }

        public static (float, float) TransformBoxInvert(
            int[] pt,
            (float, float) ul,
            (float, float) br,
            int resH,
            int resW)
        {
            throw new NotImplementedException();
        }

        public static Tuple<object, object> detector_to_alpha_pose(
            NDArray img,
            NDArray class_ids,
            NDArray scores,
            NDArray bounding_boxs,
            (int, int)? output_shape = null,
            Context ctx = null,
            float thr = 0.5f)
        {
            throw new NotImplementedException();
        }
    }
}
