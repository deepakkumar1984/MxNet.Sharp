using MxNet.Gluon.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data
{
    public class IntervalSampler : Sampler
    {
        public override int Length => throw new NotImplementedException();

        public IntervalSampler(int length, int interval, bool rollover= true)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
