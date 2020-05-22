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
using System.IO.Compression;
using System.Linq;
using NumpyDotNet;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class MNIST : DownloadedDataset
    {
        internal string _namespace;
        internal (string, string) _test_data;
        internal (string, string) _test_label;
        internal bool _train;
        internal (string, string) _train_data;
        internal (string, string) _train_label;

        public MNIST(string root = "/datasets/mnist", bool train = true,
            Func<NDArray, NDArray, (NDArray, NDArray)> transform = null) : base(mx.AppPath + root, transform)
        {
            _train = train;
            _train_data = ("train-images-idx3-ubyte.gz",
                "6c95f4b05d2bf285e1bfb0e7960c31bd3b3f8a7d");
            _train_label = ("train-labels-idx1-ubyte.gz",
                "2a80914081dc54586dbdf242f9805a6b8d2a15fc");
            _test_data = ("t10k-images-idx3-ubyte.gz",
                "c3a25af1f52dad7f726cce8cacb138654b760d48");
            _test_label = ("t10k-labels-idx1-ubyte.gz",
                "763e7fa3757d93b0cdec073cef058b2004252c17");
            _namespace = "mnist";

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
            var data_file = Utils.Download(Utils.GetRepoFileUrl(@namespace, data.Item1), _root, sha1_hash: data.Item2);
            var label_file = Utils.Download(Utils.GetRepoFileUrl(@namespace, label.Item1), _root, sha1_hash: label.Item2);

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

                    _label = new NDArray(buffer.Select(x => (float) x).ToArray(), new Shape(60000));
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
                    _data = new NDArray(buffer.Select(y => (float) y).ToArray(), new Shape(60000, 28, 28, 1)) / 255;
                }
            }
        }
    }
}