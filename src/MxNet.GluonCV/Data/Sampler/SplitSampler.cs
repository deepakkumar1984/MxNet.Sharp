using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class SplitSampler : Sampler
    {
        public SplitSampler(int length, int num_parts= 1, int part_index= 0)
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
