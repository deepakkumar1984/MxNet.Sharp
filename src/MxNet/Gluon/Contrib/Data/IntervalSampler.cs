using MxNet.Gluon.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data
{
    public class IntervalSampler : Sampler, IEnumerable<int>
    {
        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IntervalSampler(int length, int interval, bool rollover= true)
        {
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
