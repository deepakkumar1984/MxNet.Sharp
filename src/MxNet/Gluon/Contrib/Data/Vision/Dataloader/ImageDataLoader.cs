using MxNet.Gluon.Data;
using MxNet.Gluon.Data.Vision.Datasets;
using MxNet.Gluon.NN;
using MxNet.Image;
using MxNet.Numpy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MxNet.Gluon.Contrib.Data.Vision
{
    public class ImageDataLoader : IEnumerable<(ndarray, ndarray)>
    {
        public int Length => throw new NotImplementedRelease1Exception();

        private MxNet.Gluon.Data.DataLoader _iter = null;

        public ImageDataLoader(int batch_size, Shape data_shape, string path_imgrec= null, string path_imglist= null, string path_root= ".",
                 int part_index= 0, int num_parts= 1, HybridBlock[] aug_list= null, List<(float[], string)> imglist= null,
                 DType dtype= null, bool shuffle= false, Sampler<int> sampler= null, string last_batch= null, BatchSampler batch_sampler= null,
                 Func<(ndarray, ndarray)[], (ndarray, ndarray)>  batchify_fn = null,  int num_workers= 0, bool pin_memory= false,
                 int pin_device_id= 0, int? prefetch= null, bool thread_pool= false, int timeout= 120)
        {
            HybridSequential augmenter = null;
            Dataset<(ndarray, ndarray)> dataset = null;
            Debug.Assert(new List<string> {
                    "int32",
                    "float32",
                    "int64",
                    "float64"
                }.Contains(dtype), dtype + " label not supported");

            Logger.Info($"Using {num_workers} workers for decoding...");
            Logger.Info("Set `num_workers` variable to a larger number to speed up loading (it requires shared memory to work and may occupy more memory).");
            var class_name = this.GetType().Name;
            if (!string.IsNullOrEmpty(path_imgrec))
            {
                Logger.Info($"{class_name}: loading recordio {path_imgrec}...");
                //dataset = new ImageRecordDataset(path_imgrec, flag: 1); //ToDo: Check for the class implementation issue

            }
            else if (path_imglist != null)
            {
                Logger.Info($"{class_name}: loading image list {path_imglist}...");
                dataset = new ImageListDataset(path_root, path_imglist, flag: 1);
            }
            else if (imglist != null)
            {
                Logger.Info($"{class_name}: loading image list...");
                dataset = new ImageListDataset(path_root, imglist, flag: 1);
            }
            else
            {
                throw new Exception("Either path_imgrec, path_imglist, or imglist must be provided");
            }
            if (num_parts > 1)
            {
                dataset = dataset.Shard(num_parts, part_index);
            }
            if (aug_list == null)
            {
                // apply default transforms
                augmenter = DataLoader.CreateImageAugment(data_shape, mean: false);
            }
            else
            {
                augmenter = new HybridSequential();

                foreach (var aug in aug_list)
                {
                    augmenter.Add(aug);
                }
            }

            augmenter.Hybridize();
            this._iter = new MxNet.Gluon.Data.DataLoader(
                dataset.TransformFirst(augmenter),
                batch_size: batch_size,
                shuffle: shuffle,
                sampler: sampler,
                last_batch: last_batch,
                batch_sampler: batch_sampler,
                batchify_fn: batchify_fn,
                num_workers: num_workers,
                pin_memory: pin_memory,
                pin_device_id: pin_device_id,
                prefetch: prefetch,
                thread_pool: thread_pool,
                timeout: timeout);
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
