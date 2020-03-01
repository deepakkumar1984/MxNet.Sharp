using MxNet.Gluon.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Gluon.Contrib.Data
{
    public class IntervalSampler : Sampler
    {
        public override int Length => _length;

        private int _interval;

        private bool _rollover;

        private int _length;

        public IntervalSampler(int length, int interval, bool rollover= true)
        {
            _interval = interval;
            _rollover = rollover;
            _length = length;
        }

        public override IEnumerator<int> GetEnumerator()
        {
            int n = _rollover ? _interval : 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < _length; j = j + _interval)
                {
                    yield return j;
                }
            }
        }
    }
}
