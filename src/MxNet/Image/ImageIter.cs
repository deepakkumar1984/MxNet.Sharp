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
using System.Collections.Generic;
using MxNet.IO;

namespace MxNet.Image
{
    public class ImageIter : DataIter
    {
        public ImageIter(int batch_size, Shape data_shape, int label_width = 1,
            string path_imgrec = null, string[] path_imglist = null, string path_root = null,
            string path_imgidx = null, bool shuffle = false, int part_index = 0, int num_parts = 1,
            Augmenter[] aug_list = null, Dictionary<string, float> imglist = null,
            string data_name = "data", string label_name = "softmax_label", DType dtype = null,
            string last_batch_handle = "pad") : base(batch_size)
        {
            throw new NotImplementedException();
        }

        public override NDArrayList GetData()
        {
            throw new NotImplementedException();
        }

        public override int[] GetIndex()
        {
            throw new NotImplementedException();
        }

        public override NDArrayList GetLabel()
        {
            throw new NotImplementedException();
        }

        public override int GetPad()
        {
            throw new NotImplementedException();
        }

        public override bool IterNext()
        {
            throw new NotImplementedException();
        }

        public override bool End()
        {
            throw new NotImplementedException();
        }

        public override DataBatch Next()
        {
            throw new NotImplementedException();
        }

        public DataBatch NextSample()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public void HardReset()
        {
            throw new NotImplementedException();
        }

        private int Batchify(DataBatch batch_data, DataBatch batch_label, int start = 0)
        {
            throw new NotImplementedException();
        }

        public void CheckDataShape(Shape data_shape)
        {
            throw new NotImplementedException();
        }

        public void CheckValidImage(NDArray data)
        {
            throw new NotImplementedException();
        }

        public NDArray ReadImage(string fname)
        {
            throw new NotImplementedException();
        }

        public NDArray AugmentationTransform(NDArray data)
        {
            throw new NotImplementedException();
        }

        public NDArray PostProcessData(NDArray datum)
        {
            throw new NotImplementedException();
        }
    }
}