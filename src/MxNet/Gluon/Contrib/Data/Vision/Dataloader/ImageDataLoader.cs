using MxNet.Gluon.Data;
using MxNet.Image;
using MxNet.Numpy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data.Vision
{
    public class ImageDataLoader : IEnumerable<(ndarray, ndarray)>
    {
        public int Length => throw new NotImplementedRelease1Exception();

        public ImageDataLoader(int batch_size, Shape data_shape, string path_imgrec= null, string path_imglist= null, string path_root= ".",
                 int part_index= 0, int num_parts= 1, Augmenter[] aug_list= null, List<(string, float[])> imglist= null,
                 DType dtype= null, bool shuffle= false, Sampler<int> sampler= null, string last_batch= null, BatchSampler batch_sampler= null,
                 Func<(ndarray, ndarray)[], (ndarray, ndarray)>  batchify_fn = null,  int num_workers= 0, bool pin_memory= false,
                 int pin_device_id= 0, int? prefetch= null, bool thread_pool= false, int timeout= 120)
        {
            throw new NotImplementedRelease1Exception();
        }

        public IEnumerator<(ndarray, ndarray)> GetEnumerator()
        {
            throw new NotImplementedRelease1Exception();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedRelease1Exception();
        }
    }
}
