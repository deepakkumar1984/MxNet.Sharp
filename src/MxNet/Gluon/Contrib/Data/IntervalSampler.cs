using MxNet.Gluon.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib.Data
{
    public class IntervalSampler : Sampler
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

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override int Len()
        {
            throw new NotImplementedException();
        }
    }
}
