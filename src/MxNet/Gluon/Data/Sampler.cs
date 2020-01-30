using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public abstract class Sampler : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();

        public abstract int Len();
    }
}
