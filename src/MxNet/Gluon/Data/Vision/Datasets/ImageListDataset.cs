using MxNet.Image;
using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class ImageListDataset : Dataset<(ndarray, ndarray)>
    {
        private int _flag;

        public object _handle;

        public List<string> _imgkeys;

        public Dictionary<string, (ndarray, string)> _imglist;

        public string _root;

        public override (ndarray, ndarray) this[int idx]
        {
            get
            {
                var key = this._imgkeys[idx];
                var img = Img.ImRead(this._imglist[key].Item2, this._flag);
                var label = this._imglist[key].Item1;
                return (img, label);
            }
        }

        public override int Length => _imgkeys.Count;

        public ImageListDataset(string root = ".", string imglist = null, int flag = 1)
        {
            //this._root = root;
            //this._flag = flag;
            //this._imglist = new Dictionary<object, object>
            //{
            //};
            //this._imgkeys = new List<string>();
            //this._handle = null;
            //var index = 1;
            //foreach (var img in imglist)
            //{
            //    var fname = os.path.join(this._root, img);
            //    var key = index.ToString();
            //    index += 1;
            //    if (img.Length > 2)
            //    {
            //        var label = array_fn(img[:: - 1]);
            //    }
            //    else
            //    {
            //        label = np.array(img[0]);
            //    }

            //    this._imglist[key] = (label, os.path.join(this._root, img[-1]));
            //    this._imgkeys.Add(key);
            //}

            throw new NotImplementedRelease1Exception();
        }

        public ImageListDataset(string root = ".", List<(float[], string)> imglist = null, int flag = 1)
        {
            //this._root = root;
            //this._flag = flag;
            //this._imglist = new Dictionary<object, object>
            //{
            //};
            //this._imgkeys = new List<string>();
            //this._handle = null;
            //var index = 1;
            //foreach (var img in imglist)
            //{
            //    var fname = os.path.join(this._root, img);
            //    var key = index.ToString();
            //    index += 1;
            //    if (img.Length > 2)
            //    {
            //        var label = array_fn(img[:: - 1]);
            //    }
            //    else
            //    {
            //        label = np.array(img[0]);
            //    }

            //    this._imglist[key] = (label, os.path.join(this._root, img[-1]));
            //    this._imgkeys.Add(key);
            //}

            throw new NotImplementedRelease1Exception();
        }

    }
}
