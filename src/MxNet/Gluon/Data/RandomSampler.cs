using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class RandomSampler : Sampler
    {
        private int _length;

        public RandomSampler(int length)
        {
            _length = length;
        }

        public override int Length => _length;

        public override IEnumerator<int> GetEnumerator()
        {
            var x = nd.Arange(0, _length).AsType(DType.Int32);
            x = nd.Shuffle(x);
            return x.AsArray<int>().Cast<int>().GetEnumerator();
        }
    }
}
