using System.Collections.Generic;
using MxNet.Gluon.Data;

namespace MxNet.Gluon.Contrib.Data
{
    public class IntervalSampler : Sampler
    {
        private readonly int _interval;

        private readonly int _length;

        private readonly bool _rollover;

        public IntervalSampler(int length, int interval, bool rollover = true)
        {
            _interval = interval;
            _rollover = rollover;
            _length = length;
        }

        public override int Length => _length;

        public override IEnumerator<int> GetEnumerator()
        {
            var n = _rollover ? _interval : 1;
            for (var i = 0; i < n; i++)
            for (var j = i; j < _length; j = j + _interval)
                yield return j;
        }
    }
}