/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using MxNet.Image;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class ImageFolderDataset : Dataset<(NDArray, int)>
    {
        internal List<string> _exts;
        internal List<(string, int)> items;
        internal List<string> synsets;
        public ImageFolderDataset(string root, int flag = 1, Func<NDArray, int, (NDArray, int)> transform = null)
        {
            if (transform != null)
            {
                throw new Exception("Directly apply transform to dataset is deprecated. Please use dataset.transform() or dataset.transform_first() instead...");
            }

            Root = root;
            Flag = flag;
            TransformFn = transform;
            this._exts = new List<string> {
                ".jpg",
                ".jpeg",
                ".png"
            };
            this.ListImages(this.Root);
        }

        public override (NDArray, int) this[int idx]
        {
            get
            {
                var img = Img.ImRead(this.items[idx].Item1, this.Flag);
                var label = this.items[idx].Item2;
                if (this.TransformFn != null)
                {
                    return this.TransformFn(img, label);
                }

                return (img, label);
            }
        }

        public override int Length => items.Count;

        public string Root { get; set; }
        public int Flag { get; set; }
        public Func<NDArray, int, (NDArray, int)> TransformFn { get; }

        private void ListImages(string root)
        {
            this.synsets = new List<string>();
            this.items = new List<(string, int)>();
            foreach (var folder in Directory.GetDirectories(root).OrderBy(_p_1 => _p_1).ToList())
            {
                var path = Path.Combine(root, folder);
                if (!Directory.Exists(path))
                {
                    Logger.Warning("Ignoring {path}, which is not a directory.");
                    continue;
                }

                var label = this.synsets.Count;
                this.synsets.Add(folder);
                foreach (var fn in Directory.GetFiles(path).OrderBy(_p_2 => _p_2).ToList())
                {
                    var filename = Path.Combine(path, fn);
                    var ext = Path.GetExtension(filename);
                    if (!this._exts.Contains(ext.ToLower()))
                    {
                        Logger.Warning($"Ignoring {filename} of type {ext}. Only support {string.Join(",", this._exts)}");
                        continue;
                    }

                    this.items.Add((filename, label));
                }
            }
        }
    }
}