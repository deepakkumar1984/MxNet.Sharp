using CocoTools.NET;
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
    public class COCOInstance : VisionDataset
    {
        private List<COCO> _coco;

        private float[] _im_aspect_ratios;

        private float _min_object_area;

        private string _root;

        private bool _skip_empty;

        private string[] _splits;

        private string[] _items;

        private NDArrayList _labels;

        private NDArrayList _segms;

        private Func<NDArray, NDArray, NDArray, (NDArray, NDArray, NDArray)> _transform;

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

        public COCOInstance(string root = "/datasets/coco", string splits = "instances_val2017",
                                Func<NDArray, NDArray, NDArray, (NDArray, NDArray, NDArray)> transform = null, float min_object_area = 0,
                                bool skip_empty = true) : base(root)
        {
            this._root = mx.AppPath + root;
            this._transform = transform;
            this._min_object_area = min_object_area;
            this._skip_empty = skip_empty;
            this._splits = new string[] { splits };
            // to avoid trouble, we always use contiguous IDs except dealing with cocoapi
            this.IndexMap = new Dictionary<string, int>();
            for (int i = 0; i < CLASSES.Count; i++)
                IndexMap.Add(CLASSES[i], i);
            this.JsonIdToContiguous = new Dictionary<int, int>();
            this.ContiguousIdToJson = new Dictionary<int, int>();
            this._coco = new List<COCO>();
            (_items, _labels, _segms, _im_aspect_ratios) = this.LoadJson();
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
                    throw new NotImplementedException($"Currently we don't support evaluating {this._coco.Count} JSON files");
                }

                return this._coco[0];
            }
        }

        public override string[] Classes => CLASSES.ToArray();

        public override int Length => _items.Length;

        public override (NDArray, NDArray, NDArray) this[int idx]
        {
            get
            {
                var img_path = this._items[idx];
                var label = this._labels[idx];
                var segm = this._segms[idx];
                var img = Img.ImRead(img_path, 1);
                if (this._transform != null)
                {
                    return this._transform(img, label, segm);
                }

                return (img, label, segm);
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

        internal (string[], NDArrayList, NDArrayList, float[]) LoadJson()
        {
            var items = new List<string>();
            var labels = new List<NDArray>();
            var im_aspect_ratios = new List<float>();
            var segms = new List<NDArray>();
            
            foreach (var split in this._splits)
            {
                var anno = Path.Combine(this._root, "annotations", split) + ".json";
                var _coco = new COCO(anno);
                this._coco.Add(_coco);
                var classes = (from c in _coco.LoadCats(_coco.GetCatIds())
                               select c.Name).ToList();
                if (!(classes.Count == this.Classes.Length))
                {
                    throw new Exception("Incompatible category names with COCO: ");
                }

                var json_id_to_contiguous = _coco.GetCatIds().Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)).ToDictionary(_tup_1 => _tup_1.Item2, _tup_1 => _tup_1.Item1);
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
                var image_ids = _coco.GetImgIds().OrderBy(_p_3 => _p_3).ToArray();

                foreach (var entry in _coco.LoadImgs(image_ids))
                {
                    var splitpaths = entry.CocoUrl.Split('/');
                    var dirname = splitpaths[splitpaths.Length - 2];
                    var filename = splitpaths[splitpaths.Length - 1];
                    var abs_path = Path.Combine(this._root, dirname, filename);
                    if (!File.Exists(abs_path))
                    {
                        throw new FileNotFoundException($"Image: {abs_path} not exists.");
                    }

                    var (label, segm) = this.CheckLoadBbox(_coco, entry);
                    // skip images without objects
                    if (this._skip_empty && label == null)
                    {
                        continue;
                    }

                    im_aspect_ratios.Add(entry.Width / entry.Height);
                    items.Add(abs_path);
                    labels.Add(label);
                    segms.Add(segm);
                }
            }
            return (items.ToArray(), labels, segms, im_aspect_ratios.ToArray());
        }

        internal (NDArray, NDArrayList) CheckLoadBbox(COCO coco, COCOEntry entry)
        {
            var entry_id = new int[] { entry.ID };
            var ann_ids = coco.GetAnnIds(imgIds: entry_id, iscrowd: null);
            var objs = coco.LoadAnns(ann_ids);
            // check valid bboxes
            var valid_objs = new List<int>();
            var valid_segs = new List<NDArray>();
            var width = entry.Width;
            var height = entry.Height;
            foreach (var obj in objs)
            {
                if (obj.Ignore)
                {
                    continue;
                }

                // crowd objs cannot be used for segmentation
                if (obj.IsCrowd)
                {
                    continue;
                }
                // need accurate floating point box representation
                var (x1, y1, w, h) = obj.BBox;
                var x2 = x1 + Math.Max(0, w);
                var y2 = y1 + Math.Max(0, h);
                // clip to image boundary
                x1 = Math.Min(width, Math.Max(0, x1));
                y1 = Math.Min(height, Math.Max(0, y1));
                x2 = Math.Min(width, Math.Max(0, x2));
                y2 = Math.Min(height, Math.Max(0, y2));
                // require non-zero seg area and more than 1x1 box size
                if (obj.Area > this._min_object_area && x2 > x1 && y2 > y1 && (x2 - x1) * (y2 - y1) >= 4)
                {
                    var contiguous_cid = this.JsonIdToContiguous[obj.ID];
                    valid_objs.AddRange(new List<int> {
                            x1,
                            y1,
                            x2,
                            y2,
                            contiguous_cid
                        });

                    var segs = obj.Segmentation;
                    valid_segs.AddRange((from p in segs
                                       where p.Length >= 6
                                       select nd.Array(p).Reshape(-1, 2).AsType(DType.Float32)).ToList());
                }
            }

            // there is no easy way to return a polygon placeholder: None is returned
            // in validation, None cannot be used for batchify -> drop label in transform
            // in training: empty images should be be skipped
            NDArray ret = null;
            if (valid_objs.Count == 0)
            {
                return (null, null);
            }
            else
            {
                ret = nd.Array(valid_objs.ToArray()).AsType(DType.Float32).Reshape(new Shape(-1, 5));
            }

            return (ret, valid_segs);
        }
    }
}
