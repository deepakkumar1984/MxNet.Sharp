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
using System;
using System.IO;

namespace MxNet.Gluon.Data
{
    public abstract class DownloadedDataset : Dataset<(NDArray, NDArray)>
    {
        internal NDArrayList _data;
        internal NDArrayList _label;
        internal string _root;
        internal Func<NDArray, NDArray, (NDArray, NDArray)> _transform;

        public DownloadedDataset(string root, Func<NDArray, NDArray, (NDArray, NDArray)> transform)
        {
            _transform = transform;
            _data = null;
            _label = null;
            _root = root;
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
        }

        public override (NDArray, NDArray) this[int idx]
        {
            get
            {
                if (_transform != null)
                    return _transform(_data[idx], _label[idx]);

                return (_data[idx], _label[idx]);
            }
        }

        public override int Length => _label.Length;

        public abstract void GetData();
    }
}