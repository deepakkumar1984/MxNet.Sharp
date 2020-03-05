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