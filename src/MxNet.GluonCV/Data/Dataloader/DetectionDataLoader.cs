using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class DetectionDataLoader : Gluon.Data.Vision.DataLoader
    {
        public DetectionDataLoader(Dataset<NDArray> dataset, int? batch_size = null, bool shuffle = false, Sampler sampler = null, string last_batch = null, BatchSampler batch_sampler = null, Func<NDArrayList, NDArrayList> batchify_fn = null, int num_workers = 0) : base(dataset, batch_size, shuffle, sampler, last_batch, batch_sampler, batchify_fn, num_workers)
        {
            throw new NotImplementedException();
        }
    }
}
