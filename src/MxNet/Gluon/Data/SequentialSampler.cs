using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class SequentialSampler : Sampler
    {
        private int _length;

        public SequentialSampler(int length)
        {
            _length = length;
        }

        public override int Length =>_length;

        public override IEnumerator<int> GetEnumerator()
        {
            return Enumerable.Range(0, _length).GetEnumerator();
        }
    }
}
