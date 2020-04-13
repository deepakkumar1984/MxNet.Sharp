using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace MxNet.GluonCV.Data
{
    public class VOCDetection : VisionDataset
    {
        private string _anno_path;

        private Dictionary<int, Shape> _im_shapes;

        private string _image_path;

        private (string, string)[] _items;

        private NDArrayList _label_cache;

        private string _root;

        private Dictionary<int, string> _splits;

        private Func<NDArray, NDArray, (NDArray, NDArray)> _transform;

        private Dictionary<string, int> index_map;

        public static string[] CLASSES
        {
            get
            {
                return new string[] { "aeroplane", "bicycle", "bird", "boat", "bottle", "bus", "car", "cat", "chair", "cow", "diningtable", "dog", "horse", "motorbike", "person", "pottedplant", "sheep", "sofa", "train", "tvmonitor" };
            }
        }

        public VOCDetection(string root = "/datasets/voc", Dictionary<int, string> splits = null, Func<NDArray, NDArray, (NDArray, NDArray)> transform = null, Dictionary<int, string> index_map = null, bool preload_label = true) : base(root)
        {
            this._root = mx.AppPath + root;
            this._transform = transform;
            this._splits = splits;
            this._items = this.LoadItems(splits);
            this._anno_path = Path.Combine("{0}", "Annotations", "{1}.xml");
            this._image_path = Path.Combine("{0}", "JPEGImages", "{1}.jpg");
            this.index_map = new Dictionary<string, int>();
            foreach (var i in Enumerable.Range(0, CLASSES.Length))
            {
                index_map.Add(i, CLASSES[i]);
            }

            this._label_cache = preload_label ? this.PreloadLabels() : null;
        }

        public override int Length => CLASSES.Length;

        public override string[] Classes => CLASSES;

        public override (NDArray, NDArray, NDArray) this[int idx]
        {
            get
            {
                var img_id = this._items[idx];
                var img_path = string.Format(this._image_path, img_id);
                var label = this._label_cache != null ? this._label_cache[idx] : this.LoadLabel(idx);
                var imgmat = Cv2.ImRead(img_path,  ImreadModes.Color);
                var img = NDArray.LoadCV2Mat(imgmat);
                if (this._transform != null)
                {
                    (img, label) = this._transform(img, label);
                }

                return (img, label.Copy(), null);
            }
        }

        private (string, string)[] LoadItems(Dictionary<int, string> splits)
        {
            (string, string)[] ids = null;
            foreach (var _tup_1 in splits)
            {
                var year = _tup_1.Key;
                var name = _tup_1.Value;
                var root = Path.Combine(this._root, "VOC" + year.ToString());
                var lf = Path.Combine(root, "ImageSets", "Main", name + ".txt");
                var lines = File.ReadAllLines(lf);
                ids = (from line in lines
                        select (root, line.Trim())).ToArray();
            }

            return ids;
        }

        private NDArray LoadLabel(int idx)
        {
            int difficult = 0;
            var img_id = this._items[idx];
            var anno_path = string.Format(this._anno_path, img_id);
            XmlDocument root = new XmlDocument();
            root.Load(anno_path);
            var size = root.SelectSingleNode("size");
            var width = Convert.ToInt32(size.SelectSingleNode("width").InnerText);
            var height = Convert.ToInt32(size.SelectSingleNode("height").InnerText);
            if (!this._im_shapes.ContainsKey(idx))
            {
                // store the shapes for later usage
                this._im_shapes[idx] = new Shape(width, height);
            }
            var label = new List<int>();
            foreach (XmlNode obj in root.SelectNodes("object"))
            {
                try
                {
                    difficult = Convert.ToInt32(obj.SelectSingleNode("difficult").InnerText);
                }
                catch (Exception)
                {
                    difficult = 0;
                }
                var cls_name = obj.SelectSingleNode("name").InnerText.Trim().ToLower();
                if (!this.Classes.Contains(cls_name))
                {
                    continue;
                }
                var cls_id = this.index_map[cls_name];
                var xml_box = obj.SelectSingleNode("bndbox");
                var xmin = Convert.ToInt32(xml_box.SelectSingleNode("xmin").InnerText) - 1;
                var ymin = Convert.ToInt32(xml_box.SelectSingleNode("ymin").InnerText) - 1;
                var xmax = Convert.ToInt32(xml_box.SelectSingleNode("xmax").InnerText) - 1;
                var ymax = Convert.ToInt32(xml_box.SelectSingleNode("ymax").InnerText) - 1;
                try
                {
                    this.ValidateLabel(xmin, ymin, xmax, ymax, width, height);
                }
                catch (Exception e)
                {
                    throw new Exception($"Invalid label at {anno_path}, {e}");
                }

                label.AddRange(new List<int> {
                        xmin,
                        ymin,
                        xmax,
                        ymax,
                        cls_id,
                        difficult
                    });
            }

            return nd.Array(label.ToArray()).Reshape(-1, 6);
        }

        private void ValidateLabel(int xmin, int ymin, int xmax, int ymax, int width, int height)
        {
            Debug.Assert((0 <= xmin) && (xmin < width), $"xmin must in [0, {width}), given {xmin}");
            Debug.Assert((0 <= ymin) && (ymin < height), $"ymin must in [0, {height}), given {ymin}");
            Debug.Assert((xmin < xmax) && (xmax <= width), $"xmax must in (xmin, {width}], given {xmax}");
            Debug.Assert((ymin < ymax) && (ymax <= height), $"ymax must in (ymin, {height}], given {ymax}");
        }

        private void ValidateClassNames(string[] class_list)
        {
            Debug.Assert((from c in class_list
                             select c.Any(x=>char.IsLower(x))).ToList().Count == 0, "uppercase characters");
            var stripped = (from c in class_list
                            where c.Trim() != c
                            select c).ToList();
            if (stripped.Count > 0)
            {
                Logger.Warning($"white space removed for {string.Join(",", stripped)}");
            }
        }

        private NDArrayList PreloadLabels()
        {
            return (from idx in Enumerable.Range(0, this.Length)
                    select this.LoadLabel(idx)).ToList();
        }
    }
}
