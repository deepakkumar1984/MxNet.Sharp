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
using NumpyDotNet;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class FashionMNIST : DownloadedDataset
    {
        internal string _namespace;
        internal (string, string) _test_data;
        internal (string, string) _test_label;
        internal bool _train;
        internal (string, string) _train_data;
        internal (string, string) _train_label;

        public FashionMNIST(string root = "/datasets/fashion-mnist", bool train = true,
            Func<NDArray, NDArray, (NDArray, NDArray)> transform = null) : base(mx.AppPath + root, transform)
        {
            _train = train;
            _train_data = ("train-images-idx3-ubyte.gz",
                "0cf37b0d40ed5169c6b3aba31069a9770ac9043d");
            _train_label = ("train-labels-idx1-ubyte.gz",
                "236021d52f1e40852b06a4c3008d8de8aef1e40b");
            _test_data = ("t10k-images-idx3-ubyte.gz",
                "626ed6a7c06dd17c0eec72fa3be1740f146a2863");
            _test_label = ("t10k-labels-idx1-ubyte.gz",
                "17f9ab60e7257a1620f4ad76bbbaf857c3920701");
            _namespace = "fashion-mnist";

            GetData();
        }

        public override void GetData()
        {
            (string, string) data = default;
            (string, string) label = default;
            if (_train)
            {
                data = _train_data;
                label = _train_label;
            }
            else
            {
                data = _test_data;
                label = _test_label;
            }

            var @namespace = "gluon/dataset/" + _namespace;
            var data_file = Utils.Download(Utils.GetRepoFileUrl(@namespace, data.Item1), Path.Combine(_root, data.Item1), sha1_hash: data.Item2);
            var label_file = Utils.Download(Utils.GetRepoFileUrl(@namespace, label.Item1), Path.Combine(_root, label.Item1),
                sha1_hash: label.Item2);

            var file = new FileInfo(label_file);
            using (var fs = file.OpenRead())
            {
                using (var decompressionStream = new GZipStream(fs, CompressionMode.Decompress))
                {
                    var stream = new MemoryStream();
                    decompressionStream.CopyTo(stream);
                    var buffer = new byte[stream.Length - 8];
                    stream.Seek(8, SeekOrigin.Begin);
                    stream.Read(buffer, 0, buffer.Length);

                    _label = new NDArray(buffer.Select(x => (float)x).ToArray(), new Shape(60000));
                }
            }

            file = new FileInfo(data_file);
            using (var fs = file.OpenRead())
            {
                using (var decompressionStream = new GZipStream(fs, CompressionMode.Decompress))
                {
                    var stream = new MemoryStream();
                    decompressionStream.CopyTo(stream);
                    var buffer = new byte[stream.Length - 16];
                    stream.Seek(16, SeekOrigin.Begin);
                    stream.Read(buffer, 0, buffer.Length);
                    var x = np.array(buffer);
                    _data = new NDArray(buffer.Select(y => (float)y).ToArray(), new Shape(60000, 28, 28, 1)) / 255;
                }
            }
        }
    }
}