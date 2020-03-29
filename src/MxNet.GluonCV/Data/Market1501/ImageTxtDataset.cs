using MxNet.Gluon.Data;
using MxNet.Image;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class ImageTxtDataset : Dataset<(NDArray, string)>
    {
        private int _flag;

        private Func<NDArray, NDArray> _transform;

        private List<(string, string)> _items;

        public ImageTxtDataset(List<(string, string)> items, int flag = 1, Func<NDArray, NDArray> transform = null)
        {
            this._flag = flag;
            this._transform = transform;
            this._items = items;
        }

        public override (NDArray, string) this[int idx]
        {
            get
            {
                var fpath = this._items[idx].Item1;
                var img = Img.ImRead(fpath, this._flag);
                var label = this._items[idx].Item2;
                if (this._transform != null)
                {
                    img = this._transform(img);
                }
                return (img, label);
            }
        }

        public override int Length => _items.Count;
    }
}
