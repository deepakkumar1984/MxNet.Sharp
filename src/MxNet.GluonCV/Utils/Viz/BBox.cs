using NumpyDotNet;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.Utils
{
    public static class Viz
    {
        public static NDArray PlotBBox(NDArray img, NDArray bboxes, NDArray scores = null, NDArray labels = null, float thresh= 0.5f, string[] class_names= null, Dictionary<int, Color> colors= null, bool absolute_coordinates= true, float scale= 1)
        {
            if (labels != null && !(bboxes.Shape[0] == labels.Shape[0]))
            {
                throw new Exception($"The length of labels and bboxes mismatch, {labels.Shape[0]} vs {bboxes.Shape[0]}");
            }
            if (scores != null && !(bboxes.Shape[0] == scores.Shape[0]))
            {
                throw new Exception($"The length of scores and bboxes mismatch, {scores.Shape[0]} vs {bboxes.Shape[0]}");
            }
            
            if (bboxes.Shape[0] < 1)
            {
                return img;
            }

            if (!absolute_coordinates)
            {
                // convert to absolute coordinates using image shape
                var height = img.Shape[0];
                var width = img.Shape[1];
                ndarray npx = bboxes;
                npx[":", (0, 2)] = (ndarray)npx[":", (0, 2)] * width;
                npx[":", (1, 3)] = (ndarray)npx[":", (1, 3)] * height;
                bboxes = npx;
            }
            else
            {
                bboxes *= scale;
            }

            // use random colors if None is provided
            if (colors == null)
            {
                colors = new Dictionary<int, Color>();
            }

            Mat mat = img;

            for (int i = 0;i<bboxes.Shape[0];i++)
            {
                var bbox = bboxes[i];
                var score = scores.Ravel()[i].AsScalar<float>();
                var label = labels.Ravel()[i].AsScalar<float>();
                if (scores != null && score < thresh)
                {
                    continue;
                }

                if (labels != null && label < 0)
                {
                    continue;
                }

                var cls_id = labels != null ? Convert.ToInt32(label) : -1;
                if (!colors.ContainsKey(cls_id))
                {
                    colors[cls_id] = Color.FromArgb(IntRnd.Uniform(0, 255), IntRnd.Uniform(0, 255), IntRnd.Uniform(0, 255));
                }

                var box_data = bbox.AsType(DType.Int32).AsArray<int>().OfType<int>().ToList();
                var xmin = box_data[0];
                var ymin = box_data[1];
                var xmax = box_data[2];
                var ymax = box_data[3];
                var bcolor = colors[cls_id];
               
                Cv2.Rectangle(mat, new OpenCvSharp.Point(xmin, ymin), new OpenCvSharp.Point(xmax, ymax), new Scalar(bcolor.R, bcolor.B, bcolor.G), 2);
                string class_name = "";
                if (class_names != null && cls_id < class_names.Length)
                {
                    class_name = class_names[cls_id];
                }
                else
                {
                    class_name = cls_id >= 0 ? cls_id.ToString() : "";
                }

                var scorePer = scores != null ? $"{Convert.ToInt32(score * 100)}%" : "";
                if (!string.IsNullOrEmpty(class_name) || scores != null)
                {
                    var y = ymin - 15 > 15 ? ymin - 15 : ymin + 15;
                    Cv2.PutText(mat, $"{class_name} {scorePer}", new OpenCvSharp.Point(xmin, y), HersheyFonts.HersheySimplex, Math.Min(scale / 2, 2), new Scalar(bcolor.R, bcolor.B, bcolor.G), Math.Min(Convert.ToInt32(scale), 5), lineType: LineTypes.AntiAlias);
                }
            }

            return mat;
        }
    }
}
