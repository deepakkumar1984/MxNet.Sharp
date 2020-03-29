using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using MxNet.Image;

namespace MxNet.GluonCV.Data
{
    public class LstDetection : Dataset<(NDArray, NDArray)>
    {
        private bool _coord_normalized;

        public int _flag;

        public List<string> _items;

        public List<NDArray> _labels;

        public LstDetection(string filename, string root= "", int flag= 1, bool coord_normalized= true)
        {
            this._flag = flag;
            this._coord_normalized = coord_normalized;
            this._items = new List<string>();
            this._labels = new List<NDArray>();
            var full_path = mx.AppPath + filename;
            using (var fin = System.IO.File.OpenText(full_path))
            {
                while(fin.EndOfStream)
                {
                    var line = fin.ReadLine().Trim().Split('\t');
                    var label = nd.Array(line.Skip(1).Take(line.Length - 2).Select(x=>Convert.ToSingle(x)).ToArray()).AsType(DType.Float32);
                    string im_path = Path.Combine(root, line.Last());
                    this._items.Add(im_path);
                    this._labels.Add(label);
                }
            }
        }

        public override (NDArray, NDArray) this[int idx]
        {
            get
            {
                var im_path = this._items[idx];
                var img = Img.ImRead(im_path, this._flag);
                var h = img.Shape[0];
                var w = img.Shape[1];
                var label = this._labels[idx];
                if (this._coord_normalized)
                {
                    label = MxNet.GluonCV.Data.RecordIO.Detection.TransformLabel(label, h, w);
                }
                else
                {
                    label = MxNet.GluonCV.Data.RecordIO.Detection.TransformLabel(label);
                }

                return (img, label);
            }
        }

        public override int Length => _items.Count;
    }
}
