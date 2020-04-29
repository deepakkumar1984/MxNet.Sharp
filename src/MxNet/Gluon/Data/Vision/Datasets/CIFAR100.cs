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

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class CIFAR100 : CIFAR10
    {
        public bool _fine_label;

        public CIFAR100(string root = "./datasets/cifar100", bool fine_label = false, bool train = true,
            Func<NDArray, NDArray, (NDArray, NDArray)> transform = null)
            : base(root, train, transform)
        {
            this._train = train;
            this._archive_file = ("cifar-100-binary.tar.gz", "a0bb982c76b83111308126cc779a992fa506b90b");
            this._train_data = new (string, string)[] {
                ("train.bin", "e207cd2e05b73b1393c74c7f5e7bea451d63e08e")
            };
            this._test_data = new (string, string)[] {
                ("test.bin", "8fb6623e830365ff53cf14adec797474f5478006")
            };
            this._fine_label = fine_label;
            this._namespace = "cifar100";
        }

        internal override (NDArray, NDArray) ReadBatch(string filename)
        {
            NDArray data = null;
            using (var fin = File.OpenRead(filename))
            {
                byte[] buffer = new byte[fin.Length];
                fin.Read(buffer, 0, buffer.Length);
                data = nd.Array(buffer).Reshape(-1, 3072 + 1);
            }

            return (data[":,2:"].Reshape(-1, 3, 32, 32).Transpose(new Shape(0, 2, 3, 1)), data[$":,{0 + (_fine_label ? 1 : 0)}"].AsType(DType.Int32));
        }
    }
}