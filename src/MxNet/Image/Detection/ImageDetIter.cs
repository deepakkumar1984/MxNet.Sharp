using MxNet.IO;
using MxNet.Numpy;
using MxNet.Recordio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace MxNet.Image
{
    public class ImageDetIter : ImageIter
    {
        public Shape label_shape;

        public new DetAugmenter[] auglist;

        public ImageDetIter(int batch_size, Shape data_shape, string path_imgrec = "", string path_imglist = "",
                            string path_root = "", string path_imgidx = "", bool shuffle = false, int part_index = 0,
                            int num_parts = 1, Augmenter[] aug_list = null, (float[], string)[] imglist = null,
                            string data_name = "data", string label_name = "softmax_label", string last_batch_handle = "pad")
            : base(batch_size: batch_size, data_shape: data_shape, path_imgrec: path_imgrec, path_imglist: path_imglist,
                    path_root: path_root, path_imgidx: path_imgidx, shuffle: shuffle, part_index: part_index,
                    num_parts: num_parts, aug_list: aug_list, imglist: imglist, data_name: data_name, label_name: label_name,
                    last_batch_handle: last_batch_handle)
        {
            if (aug_list == null)
            {
                this.auglist = Detection.CreateDetAugmenter(data_shape);
            }
            else
            {
                base.auglist = aug_list;
            }

            // went through all labels to get the proper label shape
            var label_shape = this.EstimateLabelShape();
            this.provide_label = new DataDesc[] {
                    new DataDesc(label_name, (this.batch_size, label_shape[0], label_shape[1]))
                };

            this.label_shape = label_shape;
        }

        private void CheckValidLabel(NDArray label)
        {
            if (label.Shape.Dimension != 2 || label.Shape[1] < 5)
            {
                var msg = $"Label with shape (1+, 5+) required, {label.Shape} received.";
                throw new Exception(msg);
            }

            var valid_label = np.where(np.logical_and(label[":, 0"] >= 0, label[":, 3"] > label[":, 1"], label[":, 4"] > label[":, 2"]))[0];
            if (valid_label.size < 1)
            {
                throw new Exception("Invalid label occurs.");
            }
        }

        private Shape EstimateLabelShape()
        {
            var max_count = 0;
            ndarray label = null;
            this.Reset();
            try
            {
                while (true)
                {
                    (label , _) = this.NextSample();
                    label = this.ParseLabel(label);
                    max_count = Math.Max(max_count, label.shape[0]);
                }
            }
            catch (StopIteration)
            {
            }

            this.Reset();
            return (max_count, label != null ? label.shape[1] : 5);
        }

        private NDArray ParseLabel(NDArray label)
        {
            ndarray raw = label.Ravel();
            if (raw.size < 7)
            {
                throw new Exception("Label shape is invalid: " + raw.shape.ToString());
            }
            var header_width = Convert.ToInt32(raw[0]);
            var obj_width = Convert.ToInt32(raw[1]);
            if ((raw.size - header_width) % obj_width != 0)
            {
                var msg = $"Label shape {raw.shape.ToString()} inconsistent with annotation width {obj_width}.";
                throw new Exception(msg);
            }

            var @out = np.reshape(raw[header_width], (-1, obj_width));
            // remove bad ground-truths
            var valid = np.where(np.logical_and(@out[":, 3"] > @out[":, 1"], @out[":, 4"] > @out[":, 2"]))[0];
            if (valid.size < 1)
            {
                throw new Exception("Encounter sample with no valid label.");
            }
            return @out[$"{valid}, :"];
        }

        public void Reshape(Shape data_shape = null, Shape label_shape = null)
        {
            if (data_shape != null)
            {
                this.CheckDataShape(data_shape);
                var shape = data_shape.Data;
                shape.Insert(0, batch_size);
                this.provide_data = new DataDesc[] {
                        new DataDesc(this.provide_data[0].Name, new Shape(shape))
                    };
                this.data_shape = data_shape;
            }
            if (label_shape != null)
            {
                this.CheckDataShape(label_shape);
                var shape = label_shape.Data;
                shape.Insert(0, batch_size);
                this.provide_label = new DataDesc[] {
                        new DataDesc(this.provide_data[0].Name, new Shape(shape))
                    };
                this.label_shape = label_shape;
            }
        }

        public (NDArray, NDArray) AugmentationTransform(NDArray data, NDArray label)
        {
            foreach (var aug in this.auglist)
            {
                var _tup_1 = aug.Call(data, label);
                data = _tup_1.Item1;
                label = _tup_1.Item2;
            }
            return (data, label);
        }

        public void CheckLabelShape(Shape label_shape)
        {
            string msg;
            if (!(label_shape.Dimension == 2))
            {
                throw new Exception("label_shape should have length 2");
            }
            if (label_shape[0] < this.label_shape[0])
            {
                msg = $"Attempts to reduce label count from {this.label_shape[0]} to {label_shape[0]}, not allowed.";
                throw new Exception(msg);
            }
            if (label_shape[1] != this.provide_label[0].Shape[2])
            {
                msg = $"label_shape object width inconsistent: {this.provide_label[0].Shape[2]} vs {label_shape[1]}.";
                throw new Exception(msg);
            }
        }

        public NDArrayList DrawNext(
                Color color,
                int thickness = 2,
                bool mean = true,
                bool std = true,
                bool clip = true,
                int? waitKey = null,
                string window_name = "draw_next",
                Dictionary<float, string> id2labels = null)
        {
            throw new NotImplementedException();
        }

        public NDArrayList DrawNext(
                Color color,
                int thickness = 2,
                NDArray mean = null,
                NDArray std = null,
                bool clip = true,
                int? waitKey = null,
                string window_name = "draw_next",
                Dictionary<float, string> id2labels = null)
        {
            throw new NotImplementedException();
        }

        public ImageDetIter SyncLabelShape(ImageDetIter it, bool verbose = false)
        {
            var train_label_shape = this.label_shape;
            var val_label_shape = it.label_shape;
            Debug.Assert(train_label_shape[1] == val_label_shape[1], "object width mismatch.");
            var max_count = Math.Max(train_label_shape[0], val_label_shape[0]);
            if (max_count > train_label_shape[0])
            {
                this.Reshape(null, (max_count, train_label_shape[1]));
            }
            if (max_count > val_label_shape[0])
            {
                it.Reshape(null, (max_count, val_label_shape[1]));
            }
            if (verbose && max_count > Math.Min(train_label_shape[0], val_label_shape[0]))
            {
                Logger.Info($"Resized label_shape to ({max_count}, {train_label_shape[1]}).");
            }

            return it;
        }
    }
}
