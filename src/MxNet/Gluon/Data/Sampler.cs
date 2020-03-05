using System.Collections;
using System.Collections.Generic;

namespace MxNet.Gluon.Data
{
    public abstract class Sampler : IEnumerable<int>
    {
        public abstract int Length { get; }

        public abstract IEnumerator<int> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}