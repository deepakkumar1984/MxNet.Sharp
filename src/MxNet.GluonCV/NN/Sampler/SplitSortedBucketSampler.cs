using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class SplitSortedBucketSampler : Sampler
    {
        public SplitSortedBucketSampler(Array sort_keys, int batch_size, int mult= 32, int num_parts= 1, int part_index= 0, bool shuffle= false, int seed= 233)
        {
            throw new NotImplementedException();
        }

        public override int Length => throw new NotImplementedException();

        public override IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
