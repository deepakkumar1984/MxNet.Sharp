using CocoTools.NET;
using MxNet.GluonCV.Utils;
using MxNet.Image;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.Data
{
    

    public class COCODetection : VisionDataset
    {
        private List<COCO> _coco;

        private float[] _im_aspect_ratios;

        private float _min_object_area;

        private string _root;

        private bool _skip_empty;

        private string[] _splits;

        private string[] _items;

        private NDArrayList _labels;

        private Func<NDArray, NDArray, (NDArray, NDArray)> _transform;

        private bool _use_crowd;

        public Dictionary<int, int> ContiguousIdToJson { get; set; }

        public Dictionary<string, int> IndexMap { get; set; }

        public Dictionary<int, int> JsonIdToContiguous { get; set; }

        public List<string> CLASSES = new List<string> {
                "person",
                "bicycle",
                "car",
                "motorcycle",
                "airplane",
                "bus",
                "train",
                "truck",
                "boat",
                "traffic light",
                "fire hydrant",
                "stop sign",
                "parking meter",
                "bench",
                "bird",
                "cat",
                "dog",
                "horse",
                "sheep",
                "cow",
                "elephant",
                "bear",
                "zebra",
                "giraffe",
                "backpack",
                "umbrella",
                "handbag",
                "tie",
                "suitcase",
                "frisbee",
                "skis",
                "snowboard",
                "sports ball",
                "kite",
                "baseball bat",
                "baseball glove",
                "skateboard",
                "surfboard",
                "tennis racket",
                "bottle",
                "wine glass",
                "cup",
                "fork",
                "knife",
                "spoon",
                "bowl",
                "banana",
                "apple",
                "sandwich",
                "orange",
                "broccoli",
                "carrot",
                "hot dog",
                "pizza",
                "donut",
                "cake",
                "chair",
                "couch",
                "potted plant",
                "bed",
                "dining table",
                "toilet",
                "tv",
                "laptop",
                "mouse",
                "remote",
                "keyboard",
                "cell phone",
                "microwave",
                "oven",
                "toaster",
                "sink",
                "refrigerator",
                "book",
                "clock",
                "vase",
                "scissors",
                "teddy bear",
                "hair drier",
                "toothbrush"
            };

        public COCODetection(string root = "/datasets/coco", string splits = "instances_val2017", 
                                Func<NDArray, NDArray, (NDArray, NDArray)> transform = null, float min_object_area = 0,
                                bool skip_empty = true, bool use_crowd = true) : base(root)
        {
            this._root = mx.AppPath  + root;
            this._transform = transform;
            this._min_object_area = min_object_area;
            this._skip_empty = skip_empty;
            this._use_crowd = use_crowd;
           
            this._splits = new string[] { splits };
            // to avoid trouble, we always use contiguous IDs except dealing with cocoapi
            this.IndexMap = new Dictionary<string, int>();
            for (int i = 0; i < CLASSES.Count; i++)
                IndexMap.Add(CLASSES[i], i);

            this.JsonIdToContiguous = new Dictionary<int, int>();
            this.ContiguousIdToJson = new Dictionary<int, int>();
            this._coco = new List<COCO>();
            (_items, _labels, _im_aspect_ratios) = this.LoadJsons();
        }

        public COCO Coco
        {
            get
            {
                if (this._coco.Count == 0)
                {
                    throw new Exception("No coco objects found, dataset not initialized.");
                }
                if (this._coco.Count > 1)
                {
                    throw new NotSupportedException($"Currently we don't support evaluating {this._coco.Count} JSON files.  Please use single JSON dataset and evaluate one by one");
                }

                return this._coco[0];
            }
        }

        public override string[] Classes => CLASSES.ToArray();

        public string AnnotaionDir => "annotations";

        public override int Length => _items.Length;

        public override (NDArray, NDArray, NDArray) this[int idx]
        {
            get
            {
                var img_path = this._items[idx];
                var label = this._labels[idx];
                var img = Img.ImRead(img_path, 1);
                if (this._transform != null)
                {
                    (img, label) = this._transform(img, label);
                }

                return (img, label, null);
            }
        }

        public float[] GetImAspectRatio()
        {
            if (this._im_aspect_ratios != null)
            {
                return this._im_aspect_ratios;
            }

            this._im_aspect_ratios = new float[this._items.Length];
            foreach (var _tup_1 in this._items.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
            {
                var i = _tup_1.Item1;
                var img_path = _tup_1.Item2;
                using (var im = Cv2.ImRead(img_path))
                {
                    var w = im.Width;
                    var h = im.Height;
                    this._im_aspect_ratios[i] = 1.0f * w / h;
                }
            }

            return this._im_aspect_ratios;
        }

        public string ParseImagePath(COCOEntry entry)
        {
            var splitpaths = entry.CocoUrl.Split('/');
            var dirname = splitpaths[splitpaths.Length - 2];
            var filename = splitpaths[splitpaths.Length - 1];
            var abs_path = Path.Combine(this._root, dirname, filename);
            return abs_path;
        }

        internal (string[], NDArrayList, float[])  LoadJsons()
        {
            var items = new List<string>();
            var labels = new List<NDArray>();
            var im_aspect_ratios = new List<float>();
            // lazy import pycocotools
            
            foreach (var split in this._splits)
            {
                var anno = Path.Combine(this._root, this.AnnotaionDir, split) + ".json";
                var coco = new COCO(anno);
                this._coco.Add(coco);
                var classes = (from c in coco.LoadCats(coco.GetCatIds())
                               select c.Name).ToList();
                if (!(classes.Count == this.Classes.Length))
                {
                    throw new Exception("Incompatible category names with COCO: ");
                }

                var json_id_to_contiguous = coco.GetCatIds().Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)).ToDictionary(_tup_1 => _tup_1.Item2, _tup_1 => _tup_1.Item1);
                if (this.JsonIdToContiguous == null)
                {
                    this.JsonIdToContiguous = json_id_to_contiguous;
                    this.ContiguousIdToJson = this.JsonIdToContiguous.ToDictionary(_tup_2 => _tup_2.Value, _tup_2 => _tup_2.Key);
                }
                else
                {
                    Debug.Assert(this.JsonIdToContiguous.Count == json_id_to_contiguous.Count);
                }

                // iterate through the annotations
                var image_ids = coco.GetImgIds().OrderBy(_p_3 => _p_3).ToList();
                foreach (var entry in coco.LoadImgs(image_ids.ToArray()))
                {
                    var abs_path = this.ParseImagePath(entry);
                    if (!File.Exists(abs_path))
                    {
                        throw new FileNotFoundException($"Image: {abs_path} not exists.");
                    }
                    var label = this.CheckLoadBbox(coco, entry);
                    if (label == null)
                    {
                        continue;
                    }

                    im_aspect_ratios.Add(entry.Width / entry.Height);
                    items.Add(abs_path);
                    labels.Add(label);
                }
            }
            return (items.ToArray(), labels, im_aspect_ratios.ToArray());
        }

        internal NDArray CheckLoadBbox(COCO coco, COCOEntry entry)
        {
            var entry_id = new int[] { entry.ID };
          
            var ann_ids = coco.GetAnnIds(imgIds: entry_id, iscrowd: null);
            var objs = coco.LoadAnns(ann_ids);
            // check valid bboxes
            var valid_objs = new List<int>();
            var width = entry.Width;
            var height = entry.Height;
            foreach (var obj in objs)
            {
                if (obj.Area < this._min_object_area)
                {
                    continue;
                }
                if (obj.Ignore)
                {
                    continue;
                }
                if (!this._use_crowd && obj.IsCrowd)
                {
                    continue;
                }

                // convert from (x, y, w, h) to (xmin, ymin, xmax, ymax) and clip bound
                var (xmin, ymin, xmax, ymax) = BBox.BBoxClipXYXY(BBox.BBox_XYWH_XYXY(obj.BBox), width, height);
                // require non-zero box area
                if (obj.Area > 0 && xmax > xmin && ymax > ymin)
                {
                    var contiguous_cid = this.JsonIdToContiguous[obj.ID];
                    valid_objs.AddRange(new List<int> {
                            xmin,
                            ymin,
                            xmax,
                            ymax,
                            contiguous_cid
                    });
                }
            }

            if (valid_objs.Count == 0)
            {
                if (!this._skip_empty)
                {
                    // dummy invalid labels if no valid objects are found
                    valid_objs.AddRange(new List<int>
                    {
                        -1,
                        -1,
                        -1,
                        -1,
                        -1
                    });
                }
            }

            var ret = nd.Array(valid_objs.ToArray()).Reshape(new Shape(-1, 5));
            return ret;
        }
    }
}
