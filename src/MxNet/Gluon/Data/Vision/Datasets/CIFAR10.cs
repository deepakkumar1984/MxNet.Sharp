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

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class CIFAR10 : DownloadedDataset
    {
        internal (string, string) _archive_file;

        internal string _namespace;

        internal (string, string)[] _test_data;

        internal bool _train;

        internal (string, string)[] _train_data;

        public CIFAR10(string root = "/datasets/cifar10", bool train = true,
            Func<NDArray, NDArray, (NDArray, NDArray)> transform = null) : base(mx.AppPath + root, transform)
        {
            this._train = train;
            this._archive_file = ("cifar-10-binary.tar.gz", "fab780a1e191a7eda0f345501ccd62d20f7ed891");
            this._train_data = new (string, string)[] {
                ("data_batch_1.bin", "aadd24acce27caa71bf4b10992e9e7b2d74c2540"),
                ("data_batch_2.bin", "c0ba65cce70568cd57b4e03e9ac8d2a5367c1795"),
                ("data_batch_3.bin", "1dd00a74ab1d17a6e7d73e185b69dbf31242f295"),
                ("data_batch_4.bin", "aab85764eb3584312d3c7f65fd2fd016e36a258e"),
                ("data_batch_5.bin", "26e2849e66a845b7f1e4614ae70f4889ae604628")
            };
            this._test_data = new (string, string)[] {
                ("test_batch.bin", "67eb016db431130d61cd03c7ad570b013799c88c")
            };

            this._namespace = "cifar10";
        }

        internal virtual (NDArray, NDArray) ReadBatch(string filename)
        {
            NDArray data = null;
            using (var fin = File.OpenRead(filename))
            {
                byte[] buffer = new byte[fin.Length];
                fin.Read(buffer, 0, buffer.Length);
                data = nd.Array(buffer).Reshape(-1, 3072 + 1);
            }

            return (data[":,1:"].Reshape(-1, 3, 32, 32).Transpose(new Shape(0, 2, 3, 1)), data[":,0"].AsType(DType.Int32));
        }

        public override void GetData()
        {
            (string, string)[] data_files;

            var files = _train_data.ToList();
            files.AddRange(_test_data);
            bool download = false;
            foreach (var (name, sha1) in files)
            {
                if (!File.Exists(Path.Combine(_root, name)))
                {
                    download = true;
                    break;
                }
            }

            if(download)
            {
                var @namespace = "gluon/dataset/" + _namespace;
                var data_file = Utils.Download(Utils.GetRepoFileUrl(@namespace, _archive_file.Item1), _root, sha1_hash: _archive_file.Item2);
                var file = new FileInfo(data_file);
                using (var fs = file.OpenRead())
                {
                    using (var zip = new ZipArchive(fs, ZipArchiveMode.Read))
                    {
                        zip.ExtractToDirectory(this._root);
                    }
                }
            }

            if (this._train)
            {
                data_files = this._train_data;
            }
            else
            {
                data_files = this._test_data;
            }

            NDArrayList data = new NDArrayList();
            NDArrayList label = new NDArrayList();

            foreach (var (name, _) in data_files)
            {
                var (d, l) = ReadBatch(name);
                data.Add(d);
                label.Add(l);
            }

            data = nd.Concat(data);
            label = nd.Concat(label);
            this._data = data;
            this._label = label;
        }
    }
}